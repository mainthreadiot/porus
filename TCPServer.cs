using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Porus
{
    public partial class TCPServer : Form
    {
        private TcpListener tcpListener;
        private bool isListening = false;
        private int connectedClients = 0;
        private readonly object lockObj = new object();

        public TCPServer()
        {
            InitializeComponent();
        }

        private async void btnReceive_Click(object sender, EventArgs e)
        {
            int port;
            btnReceive.Enabled = false;
            if (int.TryParse(txtPort.Text, out port))
            {
                await StartListeningAsync(port);
            }
            else
            {
                MessageBox.Show("Please enter a valid port number.");
            }
        }

        private async Task StartListeningAsync(int port)
        {
            if (isListening)
            {
                MessageBox.Show("Already listening for connections.");
                return;
            }

            try
            {
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();
                isListening = true;
                lock (lockObj)
                {
                    connectedClients++;
                }
                lblActiveConnections.Text = $"Active connections: {connectedClients}";
                txtReceive.AppendText($"Listening on port {port}...\r\n");

                // Asynchronously listen for clients
                await Task.Run(() => ListenForClientsAsync());
            }
            catch (Exception ex)
            {
                btnReceive.Enabled = true;
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task ListenForClientsAsync()
        {
            while (isListening)
            {
                try
                {
                    // Accept client connection asynchronously
                    TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                    txtReceive.Invoke((MethodInvoker)(() => txtReceive.AppendText("Client connected.\r\n")));

                    // Handle the client's communication asynchronously
                    _ = HandleClientCommAsync(tcpClient);
                }
                catch (Exception ex)
                {
                    txtReceive.Invoke((MethodInvoker)(() => txtReceive.AppendText($"Error accepting client: {ex.Message}\r\n")));
                }
            }
        }

        private async Task HandleClientCommAsync(TcpClient tcpClient)
        {
            NetworkStream stream = tcpClient.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                while (true)
                {
                    // Asynchronously read data from client
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Client disconnected

                    string receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    txtReceive.Invoke((MethodInvoker)(() => txtReceive.AppendText($"Received: {receivedData}\r\n")));
                }
            }
            catch (Exception ex)
            {
                txtReceive.Invoke((MethodInvoker)(() => txtReceive.AppendText($"Error receiving data: {ex.Message}\r\n")));
            }
            finally
            {
                tcpClient.Close();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnReceive.Enabled = true;
            if (isListening)
            {
                isListening = false;
                tcpListener.Stop();
                lock (lockObj)
                {
                    connectedClients--;
                }
                lblActiveConnections.Text = $"Active connections: {connectedClients}";
                txtReceive.AppendText("Listener stopped.\r\n");
            }
            else
            {
                MessageBox.Show("Listener is not running.");
            }
        }

        private void TCPServer_Load(object sender, EventArgs e)
        {
          
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
                        string filePath = Path.Combine(selectedFolder, "log_"+DateTime.Now.ToString("ddMMyyHHmmss")+".txt");

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
