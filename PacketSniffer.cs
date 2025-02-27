using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Porus
{
    public partial class PacketSniffer : Form
    {
        private System.Threading.Thread snifferThread;
        private bool isSniffing = false;
        private System.Net.Sockets.Socket mainSocket;

        public PacketSniffer()
        {
            InitializeComponent();
            try
            {
                // Get and display the first available local IP address
                txtIPAddress.Text = GetLocalIPAddresses().FirstOrDefault();
            }
            catch (Exception)
            {
            }
        }

        static string[] GetLocalIPAddresses()
        {
            IPAddress[] ipAddresses = Dns.GetHostAddresses(Dns.GetHostName());
            return ipAddresses.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork)
                              .Select(ip => ip.ToString())
                              .ToArray();
        }

        private void PacketSniffer_Load(object sender, EventArgs e)
        {
            // Set DataGridView properties for full-width columns
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Initialize DataGridView columns
            dataGridView1.Columns.Add("SourceIP", "Source IP");
            dataGridView1.Columns.Add("DestinationIP", "Destination IP");
            dataGridView1.Columns.Add("Protocol", "Protocol");
            dataGridView1.Columns.Add("SourcePort", "Source Port");
            dataGridView1.Columns.Add("DestinationPort", "Destination Port");
            dataGridView1.Columns.Add("Length", "Packet Length");
            dataGridView1.Columns.Add("HexData", "Hex Data");

            // Optional: Set minimum width to avoid squeezing too much
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.MinimumWidth = 100; // Adjust as needed
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isSniffing)
            {
                string ipAddress = txtIPAddress.Text.Trim();
                if (string.IsNullOrEmpty(ipAddress))
                {
                    MessageBox.Show("Enter a valid IP Address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    isSniffing = true;
                    snifferThread = new System.Threading.Thread(() => StartSniffing(ipAddress)) { IsBackground = true };
                    snifferThread.Start();

                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error starting sniffer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void StartSniffing(string ipAddress)
        {
            try
            {
                // Parse and bind the IP address
                IPAddress localIP = IPAddress.Parse(ipAddress);
                mainSocket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
                mainSocket.Bind(new IPEndPoint(localIP, 0));
                mainSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

                // Enable promiscuous mode to capture all packets
                byte[] inValue = new byte[] { 1, 0, 0, 0 };
                mainSocket.IOControl(IOControlCode.ReceiveAll, inValue, null);

                byte[] buffer = new byte[65536];

                while (isSniffing)
                {
                    try
                    {
                        // Receive packets
                        int bytesReceived = mainSocket.Receive(buffer);
                        if (bytesReceived > 0)
                        {
                            ProcessPacket(buffer, bytesReceived);
                        }
                    }
                    catch (SocketException ex)
                    {
                        if (!isSniffing)
                            break; // Exit loop if stopped
                        MessageBox.Show($"Socket error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during sniffing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                mainSocket?.Close();
                mainSocket = null;
            }
        }


        private void ProcessPacket(byte[] buffer, int length)
        {
            if (length < 20) return; // Minimum IP header size is 20 bytes

            string sourceIP = $"{buffer[12]}.{buffer[13]}.{buffer[14]}.{buffer[15]}";
            string destinationIP = $"{buffer[16]}.{buffer[17]}.{buffer[18]}.{buffer[19]}";
            int protocol = buffer[9];

            // ✅ Protocol Identification
            string protocolType;
            Color rowColor = Color.White; // Default color
            bool isSuspicious = false;
            string alertReason = "Normal";

            switch (protocol)
            {
                case 1: protocolType = "ICMP (Ping Requests)"; break;
                case 6: protocolType = "TCP (Transmission Control Protocol)"; break;
                case 17: protocolType = "UDP (User Datagram Protocol)"; break;
                case 41: protocolType = "IPv6 (Encapsulation)"; break;
                case 50: protocolType = "ESP (Encapsulating Security Payload)"; break;
                case 58: protocolType = "ICMPv6 (IPv6 Message)"; break;
                case 89: protocolType = "OSPF (Routing Protocol)"; break;
                default:
                    protocolType = $"Unknown ({protocol})";
                    rowColor = Color.Orange; // Unusual protocol, mark as warning
                    alertReason = "Unknown Protocol";
                    isSuspicious = true;
                    break;
            }

            // ✅ Extract Source & Destination Ports (for TCP/UDP)
            int sourcePort = (buffer[20] << 8) | buffer[21];
            int destinationPort = (buffer[22] << 8) | buffer[23];

            // ✅ Detect Malformed Packets (Invalid Checksum)
            if (!ValidateChecksum(buffer))
            {
                rowColor = Color.Red;
                alertReason = "Invalid Checksum (Corrupt Packet)";
                isSuspicious = true;
            }

            // ✅ Detect Port Scanning (Too many packets from the same IP)
            if (DetectFloodAttack(sourceIP))
            {
                rowColor = Color.Yellow;
                alertReason = "Possible Port Scanning / DDoS";
                isSuspicious = true;
            }

            // ✅ Detect Suspicious Payloads (SQL Injection, Shellcode, etc.)
            string payloadData = Encoding.ASCII.GetString(buffer.Skip(40).ToArray());
            if (IsSuspiciousPayload(payloadData))
            {
                rowColor = Color.Red;
                alertReason = "Malicious Payload Detected!";
                isSuspicious = true;
            }

            // ✅ Convert Hex Data (First 20 Bytes)
            string hexData = BitConverter.ToString(buffer, 0, Math.Min(20, length)).Replace("-", " ");

            // ✅ Update UI
            Invoke((MethodInvoker)delegate
            {
                int rowIndex = dataGridView1.Rows.Add(sourceIP, destinationIP, protocolType, sourcePort, destinationPort, length, hexData, alertReason);
                dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = rowColor;
            });
        }
        private bool ValidateChecksum(byte[] buffer)
        {
            int checksum = (buffer[10] << 8) + buffer[11];
            return checksum != 0; // If checksum is 0, it's likely corrupted
        }
        private bool IsSuspiciousPayload(string data)
        {
            string[] blacklist = { "SELECT", "DROP", "<script>", "admin'", "--", "0x90" };
            return blacklist.Any(word => data.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private static Dictionary<string, int> packetCounts = new Dictionary<string, int>();
        private bool DetectFloodAttack(string sourceIP)
        {
            if (!packetCounts.ContainsKey(sourceIP))
                packetCounts[sourceIP] = 0;

            packetCounts[sourceIP]++;

            if (packetCounts[sourceIP] > 50) // More than 50 packets in short time
            {
                return true; // Suspicious port scan detected
            }

            return false;
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (isSniffing)
            {
                isSniffing = false;
                mainSocket?.Close();
                mainSocket = null;
                snifferThread?.Join();

                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }
    }
}
