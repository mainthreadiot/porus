using System;
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

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e) => Close();

        private async void Thread_Load(object sender, EventArgs e) => await CheckInternetStatusAsync();

        private async Task CheckInternetStatusAsync()
        {
            bool isOnline = await Task.Run(IsInternetAvailable);
            // toolStripStatusLabel.Text = isOnline ? "Online" : "Offline";
            // toolStripStatusLabel.ForeColor = isOnline ? Color.Green : Color.Red;
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
                T childForm = new T { MdiParent = this, Text = title };
                childForm.Show();
            }
            catch(Exception ae)
            {

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
    }
}
