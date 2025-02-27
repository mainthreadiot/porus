using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Porus
{
    public partial class Thread : Form
    {
       

        public Thread()
        {
            InitializeComponent();
            
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            })
            {
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    // Implement saving logic
                }
            }
        }
        private async void DisplaySystemInformationAsync(Panel panelSystemInfo)
        {
            try
            {
                // Clear previous controls if any
                panelSystemInfo.Controls.Clear();

                // Add a "loading" label while fetching data
                Label loadingLabel = new Label
                {
                    Text = "Loading system information...",
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.Gray
                };
                panelSystemInfo.Controls.Add(loadingLabel);

                // Run the fetching logic in a separate task
                var systemInfo = await Task.Run(() => FetchSystemInformation());

                // Clear loading label
                panelSystemInfo.Controls.Clear();

                // Add the fetched system information to the panel
                DisplaySystemInformation(panelSystemInfo, systemInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching system information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Tuple<string, string, string>> FetchSystemInformation()
        {
            var systemInfo = new List<Tuple<string, string, string>>();

            // Add system information (Unicode icon, label, value)
            systemInfo.Add(Tuple.Create("🖥️", "Operating System", Environment.OSVersion.ToString()));
            systemInfo.Add(Tuple.Create("💻", "Architecture", Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit"));
            systemInfo.Add(Tuple.Create("🧠", "Processor", GetProcessorInfo()));
            systemInfo.Add(Tuple.Create("🔢", "Processor Cores", Environment.ProcessorCount.ToString()));
            systemInfo.Add(Tuple.Create("💾", "Total Memory", $"{GetTotalPhysicalMemory()} MB"));
            systemInfo.Add(Tuple.Create("📂", "Available Memory", $"{GetAvailableMemory()} MB"));

            // Storage Details
            foreach (var drive in System.IO.DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    systemInfo.Add(Tuple.Create("📀", $"Drive {drive.Name}", $"{drive.TotalFreeSpace / (1024 * 1024)} MB Free of {drive.TotalSize / (1024 * 1024)} MB"));
                }
            }

            // Network Details
            systemInfo.Add(Tuple.Create("🌐", "Host Name", Dns.GetHostName()));
            systemInfo.Add(Tuple.Create("📡", "IP Addresses", string.Join(", ", GetLocalIPAddresses())));

            // GPU Details
            systemInfo.Add(Tuple.Create("🎮", "GPU", GetGPUInfo()));

            // User Details
            systemInfo.Add(Tuple.Create("👤", "User Name", Environment.UserName));
            systemInfo.Add(Tuple.Create("🖥️", "Machine Name", Environment.MachineName));

            // Battery Details
            systemInfo.Add(Tuple.Create("🔋", "Battery Status", $"{SystemInformation.PowerStatus.BatteryLifePercent * 100}%"));
            systemInfo.Add(Tuple.Create("🔌", "Power Source", SystemInformation.PowerStatus.PowerLineStatus.ToString()));

            return systemInfo;
        }

        private void DisplaySystemInformation(Panel panelSystemInfo, List<Tuple<string, string, string>> systemInfo)
        {
            Panel container = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10)
            };
            panelSystemInfo.Controls.Add(container);

            // Add Title
            Label title = new Label
            {
                Text = "System Information",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 50,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(50, 50, 50)
            };
            container.Controls.Add(title);

            int offsetY = 60;
            int cardHeight = 60;
            int cardPadding = 15;

            // Add cards dynamically
            foreach (var info in systemInfo)
            {
                Panel card = new Panel
                {
                    Height = cardHeight,
                    Width = container.Width - 40,
                    Top = offsetY,
                    Left = 20,
                    BackColor = Color.FromArgb(245, 245, 245),
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label iconLabel = new Label
                {
                    Text = info.Item1, // Unicode icon
                    Font = new Font("Segoe UI Emoji", 24),
                    Size = new Size(40, 40),
                    Location = new Point(10, (cardHeight - 40) / 2),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.FromArgb(50, 50, 50)
                };
                card.Controls.Add(iconLabel);

                Label label = new Label
                {
                    Text = info.Item2, // Label text
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(60, 10),
                    ForeColor = Color.FromArgb(50, 50, 50),
                    AutoSize = true
                };
                card.Controls.Add(label);

                Label value = new Label
                {
                    Text = info.Item3, // Value text
                    Font = new Font("Segoe UI", 10),
                    Location = new Point(60, 30),
                    ForeColor = Color.FromArgb(80, 80, 80),
                    AutoSize = true
                };
                card.Controls.Add(value);

                container.Controls.Add(card);
                offsetY += cardHeight + cardPadding;
            }
        }



        // Helper Functions
        private string GetProcessorInfo()
        {
            using (var searcher = new ManagementObjectSearcher("select * from Win32_Processor"))
            {
                foreach (var obj in searcher.Get())
                {
                    return obj["Name"].ToString();
                }
            }
            return "Unknown Processor";
        }

        private long GetTotalPhysicalMemory()
        {
            using (var searcher = new ManagementObjectSearcher("select * from Win32_ComputerSystem"))
            {
                foreach (var obj in searcher.Get())
                {
                    return Convert.ToInt64(obj["TotalPhysicalMemory"]) / (1024 * 1024);
                }
            }
            return 0;
        }

        private long GetAvailableMemory()
        {
            using (var searcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem"))
            {
                foreach (var obj in searcher.Get())
                {
                    return Convert.ToInt64(obj["FreePhysicalMemory"]) / 1024;
                }
            }
            return 0;
        }

        private string[] GetLocalIPAddresses()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            return host.AddressList.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                   .Select(ip => ip.ToString()).ToArray();
        }

        private string GetGPUInfo()
        {
            using (var searcher = new ManagementObjectSearcher("select * from Win32_VideoController"))
            {
                foreach (var obj in searcher.Get())
                {
                    return obj["Name"].ToString();
                }
            }
            return "Unknown GPU";
        }
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e) => Close();

        private async void Thread_Load(object sender, EventArgs e) => await CheckInternetStatusAsync();

        private async Task CheckInternetStatusAsync()
        {
            bool isOnline = await Task.Run(IsInternetAvailable);
            LoadSystemInfo();
            
             //toolStripStatusLabel.Text = isOnline ? "Online" : "Offline";
             //toolStripStatusLabel.ForeColor = isOnline ? Color.Green : Color.Red;
        }
        private void LoadSystemInfo()
        {
            DisplaySystemInformationAsync(panelSystemInfo);
        }

        private bool IsInternetAvailable()
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send("8.8.8.8", 3000);
                    return reply.Status == IPStatus.Success;
                }
            }
            catch
            {
                return false;
            }
        }

        private void OpenChildForm<T>(string title) where T : Form, new()
        {
            try
            {
                // Ensure panelSystemInfo is behind
               
               // panelSystemInfo.Dock = DockStyle.Right; // Or Top, Bottom, etc., as needed
                panelSystemInfo.SendToBack();
                // Check if a form of type T is already open
                foreach (Form form in this.MdiChildren)
                {
                    if (form is T)
                    {
                        // Bring the already open form to the front
                        form.BringToFront();
                        form.Focus();
                        return;
                    }
                }

                // Create and show a new child form
                T childForm = new T
                {
                    MdiParent = this, // Set as child form
                    Text = title,
                    StartPosition = FormStartPosition.CenterScreen
                };

                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening the form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void profileToolStripMenuItem_Click(object sender, EventArgs e) => OpenChildForm<PortScanner>("Profile");
        private void portCheckerToolStripMenuItem_Click(object sender, EventArgs e) => OpenChildForm<PortChecker>("Port Checker");
        private void checksumToolStripMenuItem_Click(object sender, EventArgs e) => OpenChildForm<Checksum>("Checksum");
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MQTT mQTT = new MQTT();
            mQTT.Show();
        }
        private void barcodeConversionToolStripMenuItem_Click(object sender, EventArgs e) => OpenChildForm<Barcode>("Barcode");
        private void qRCodeConversionToolStripMenuItem_Click(object sender, EventArgs e) => OpenChildForm<QRCode>("QRCode");
        private void toolStripMenuItem2_Click(object sender, EventArgs e) => OpenChildForm<TCP>("TCP Client");
        private void tCPToolStripMenuItem_Click(object sender, EventArgs e) => OpenChildForm<TCPServer>("TCP Server");
        private void uDPToolStripMenuItem_Click(object sender, EventArgs e) => OpenChildForm<UDP>("UDP");
        private void uDPServerToolStripMenuItem_Click(object sender, EventArgs e) => OpenChildForm<UDPServer>("UDP Server");
        private void serialCommunicationToolStripMenuItem_Click(object sender, EventArgs e) => OpenChildForm<SerailCommunication>("Serial Communication");
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => OpenChildForm<AboutUs>("About Us");
        private void contentsToolStripMenuItem_Click(object sender, EventArgs e) => OpenChildForm<License>("License");
        private void imageToBase64ToolStripMenuItem_Click(object sender, EventArgs e) => OpenChildForm<Base64Conversion>("Base64 Conversion");

        private void pictureBox2_Click(object sender, EventArgs e) => OpenChildForm<PortChecker>("Port Checker");
        private void pictureBox3_Click(object sender, EventArgs e) => OpenChildForm<PortScanner>("Port Scanner");
        private void pictureBox4_Click(object sender, EventArgs e) 
        {
            MQTT mQTT = new MQTT();
            mQTT.Show();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            OpenChildForm<TCP>("TCP Client");
            OpenChildForm<TCPServer>("TCP Server");
            OpenChildForm<UDP>("UDP");
            OpenChildForm<UDPServer>("UDP Server");
            OpenChildForm<SerailCommunication>("Serial Communication");
        }
        private void pictureBox6_Click(object sender, EventArgs e) => OpenChildForm<Checksum>("Checksum");
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            OpenChildForm<Barcode>("Barcode");
            OpenChildForm<QRCode>("QRCode");
        }
        private void pictureBox1_Click(object sender, EventArgs e) => OpenChildForm<AboutUs>("About Us");

        private void modbusToolStripMenuItem_Click(object sender, EventArgs e) => OpenChildForm<Socket>("Socket");

        private void packetSniffingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<PacketSniffer>("Packet Sniffer");
        }

        private void panelSystemInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void showSystemInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelSystemInfo.Visible = true ;
        }

       
    }
}
