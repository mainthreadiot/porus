using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Porus
{

    public partial class PortChecker : Form
    {
        public PortChecker()
        {
            InitializeComponent();
        }
        private bool IsValidIP(string ipAddress)
        {
            return System.Net.IPAddress.TryParse(ipAddress, out _);
        }
        private async void btnCheck_Click(object sender, EventArgs e)
        {

            string ipAddress = txtPortCheckerIP.Text.Trim();
            string portText = txtPortCheckerPort.Text.Trim();

            int port = 0;

            if (!IsValidIP(ipAddress))
            {
                lblStatus.Text = "Please enter a valid IP address.";
                lblStatus.ForeColor = System.Drawing.Color.Red;               
                btnCheck.Enabled = true;
                return;
            }
            if (!int.TryParse(portText, out port) || port < 1 || port > 65535)
            {
                lblStatus.Text = "Please enter a valid port number (1-65535).";
                lblStatus.ForeColor = System.Drawing.Color.Red;
               
                btnCheck.Enabled = true;
                return;
            }
            // Try to parse the port number
            if (int.TryParse(txtPortCheckerPort.Text, out port))
            {
                // Check if the port is within a valid range (1 - 65535)
                if (port > 0 && port <= 65535)
                {
                    lblStatus.Text = "Checking... This may take a few seconds..."; // Inform the user that the check is in progress
                    lblStatus.ForeColor = System.Drawing.Color.Black;

                    // Run the port check asynchronously to avoid freezing the UI
                    bool isPortOpen = await Task.Run(() => CheckPort(ipAddress, port));

                    // Display the result based on the port status
                    if (isPortOpen)
                    {
                        lblStatus.Text = $"Port {port} is OPEN on {ipAddress}.";
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblStatus.Text = $"Port {port} is CLOSED on {ipAddress}.";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblStatus.Text = "Invalid port number.";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblStatus.Text = "Please enter a valid port number.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool CheckPort(string ipAddress, int port)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    client.Connect(ipAddress, port);  // Try connecting to the IP and Port
                    return true; // Port is open
                }
            }
            catch (SocketException)
            {
                return false; // Port is closed
            }
        }
        private string GetLocalIPAddress()
        {
            string localIP = string.Empty;

            foreach (var networkInterface in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                var ipProperties = networkInterface.GetIPProperties();
                foreach (var address in ipProperties.UnicastAddresses)
                {
                    // Filter IPv4 addresses that are not Loopback (127.0.0.1)
                    if (address.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && !System.Net.IPAddress.IsLoopback(address.Address))
                    {
                        localIP = address.Address.ToString();
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(localIP))
                {
                    break;
                }
            }

            return localIP != string.Empty ? localIP : "IP not found";
        }
        private void btnGetCurrentIP_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the local machine's IP address
                string localIP = GetLocalIPAddress();

                // Display the IP in a label or text box
                txtPortCheckerIP.Text = localIP;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving IP address: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PortChecker_Load(object sender, EventArgs e)
        {
            txtPortCheckerIP.ShortcutsEnabled = true;            

        }
              
        private async void BtnCheckLatency_Click(object sender, EventArgs e)
        {
            string hostname = txtPortCheckerIP.Text.Trim();

            if (string.IsNullOrEmpty(hostname))
            {
                MessageBox.Show("Please enter a valid hostname or IP address.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Ping the specified host
                using (Ping ping = new Ping())
                {
                    lblResult.Text = "Pinging... Please wait.";
                    lblResult.ForeColor = System.Drawing.Color.Black;

                    PingReply reply = await ping.SendPingAsync(hostname, 5000); // 5000ms timeout

                    if (reply.Status == IPStatus.Success)
                    {
                        lblResult.Text = $"Latency to {hostname}: {reply.RoundtripTime} ms";
                        lblResult.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblResult.Text = $"Ping failed: {reply.Status}";
                        lblResult.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = $"Error: {ex.Message}";
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void txtPortCheckerIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ignore the key press
            }
        }

        private void txtPortCheckerPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the key press
            }
        }
    }


}
