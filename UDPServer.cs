using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Porus
{
    public partial class UDPServer : Form
    {
        private UdpClient udpListener;
        private IPEndPoint endPoint;
        public UDPServer()
        {
            InitializeComponent();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            try
            {
                btnReceive.Enabled = false;
                // Get the port from txtPort
                int port = Convert.ToInt32(txtPort.Text);

                // Create an endpoint for receiving messages
                endPoint = new IPEndPoint(IPAddress.Any, port);

                // Initialize UdpClient
                udpListener = new UdpClient();
                udpListener.Client.Bind(endPoint);

                // Start listening for incoming messages asynchronously
                MessageBox.Show("Listening for incoming UDP messages...", "Listening", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BeginReceive();
            }
            catch (Exception ex)
            {
                btnReceive.Enabled = true;
                MessageBox.Show($"Error starting listener: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void BeginReceive()
        {
            try
            {
                // Asynchronously receive data from the client
                while (true)
                {
                    var receivedData = await udpListener.ReceiveAsync();
                    string message = Encoding.UTF8.GetString(receivedData.Buffer);

                    // Display the received message in txtReceive
                    txtReceive.Text = message;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error receiving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UDPServer_Load(object sender, EventArgs e)
        {
         
        }
             
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                btnReceive.Enabled = true;
                if (udpListener != null)
                {
                    udpListener.Close();
                    MessageBox.Show("UDP listener stopped.", "Stopped", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {

            }
        }

        private void btnExportText_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if there's any text in the TextBox
                if (string.IsNullOrWhiteSpace(txtReceive.Text))
                {
                    MessageBox.Show("The textbox is empty. Please enter some text before exporting.", "No Text", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Open a FolderBrowserDialog to let the user select a folder
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "Select a folder to save the text file";
                    folderDialog.ShowNewFolderButton = true;

                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedFolder = folderDialog.SelectedPath;
                        string filePath = Path.Combine(selectedFolder, "log_" + DateTime.Now.ToString("ddMMyyHHmmss") + ".txt");

                        // Write the content of the TextBox to a text file
                        File.WriteAllText(filePath, txtReceive.Text);

                        MessageBox.Show($"Text successfully exported to:\n{filePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while exporting the text: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the key press
            }
        }
    }
}
