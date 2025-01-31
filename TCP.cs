using System;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Porus
{
    public partial class TCP : Form
    {
        public TCP()
        {
            InitializeComponent();
        }

        private const string ServerIp = "127.0.0.1"; // Replace with your server IP
        private const int ServerPort = 12345; // Replace with your server port
        private TcpClient client;
        private NetworkStream stream;
        private bool isConnected = false;

        // TEA Encryption Method
        public static byte[] EncryptMessage(string message)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            Array.Resize(ref messageBytes, (messageBytes.Length + 7) / 8 * 8);  // Pad message to be multiple of 8 bytes

            uint[] data = new uint[messageBytes.Length / 4];
            for (int i = 0; i < messageBytes.Length; i += 4)
            {
                data[i / 4] = BitConverter.ToUInt32(messageBytes, i);
            }

            uint[] encryptedData = TEAEncrypt(data);

            byte[] encryptedBytes = new byte[encryptedData.Length * 4];
            for (int i = 0; i < encryptedData.Length; i++)
            {
                Array.Copy(BitConverter.GetBytes(encryptedData[i]), 0, encryptedBytes, i * 4, 4);
            }

            return encryptedBytes;
        }

        // TEA Decryption Method
        public static string DecryptMessage(byte[] encryptedMessage)
        {
            uint[] encryptedData = new uint[encryptedMessage.Length / 4];
            for (int i = 0; i < encryptedMessage.Length; i += 4)
            {
                encryptedData[i / 4] = BitConverter.ToUInt32(encryptedMessage, i);
            }

            uint[] decryptedData = TEADecrypt(encryptedData);

            byte[] decryptedBytes = new byte[decryptedData.Length * 4];
            for (int i = 0; i < decryptedData.Length; i++)
            {
                Array.Copy(BitConverter.GetBytes(decryptedData[i]), 0, decryptedBytes, i * 4, 4);
            }

            return Encoding.UTF8.GetString(decryptedBytes).TrimEnd('\0');
        }

        // TEA Encryption algorithm
        private static uint[] TEAEncrypt(uint[] data)
        {
            const uint delta = 0x9e3779b9;
            uint sum = 0;
            uint[] encryptedData = new uint[data.Length];
            for (int i = 0; i < data.Length; i += 2)
            {
                uint left = data[i];
                uint right = data[i + 1];

                for (int round = 0; round < 32; round++)
                {
                    sum += delta;
                    left += ((right << 4) + 0x9e3779b9) ^ (right + sum) ^ ((right >> 5) + 0x9e3779b9);
                    right += ((left << 4) + 0x9e3779b9) ^ (left + sum) ^ ((left >> 5) + 0x9e3779b9);
                }

                encryptedData[i] = left;
                encryptedData[i + 1] = right;
            }

            return encryptedData;
        }

        // TEA Decryption algorithm
        private static uint[] TEADecrypt(uint[] data)
        {
            const uint delta = 0x9e3779b9;
            uint sum = 0xC6EF3720;  // 32 rounds of encryption
            uint[] decryptedData = new uint[data.Length];
            for (int i = 0; i < data.Length; i += 2)
            {
                uint left = data[i];
                uint right = data[i + 1];

                for (int round = 0; round < 32; round++)
                {
                    right -= ((left << 4) + 0x9e3779b9) ^ (left + sum) ^ ((left >> 5) + 0x9e3779b9);
                    left -= ((right << 4) + 0x9e3779b9) ^ (right + sum) ^ ((right >> 5) + 0x9e3779b9);
                    sum -= delta;
                }

                decryptedData[i] = left;
                decryptedData[i + 1] = right;
            }

            return decryptedData;
        }

        private async void btnConnect_Click_1(object sender, EventArgs e)
        {
            if (isConnected)
            {
                MessageBox.Show("Already connected.", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                client = new TcpClient();
                await client.ConnectAsync(txtIPAddress.Text, Convert.ToInt32(txtPort.Text));
                stream = client.GetStream();
                isConnected = true;
                MessageBox.Show("Connected to the server.", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSend_Click_1(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                MessageBox.Show("Please connect to the server first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string messageToSend = txtSend.Text;
            if (string.IsNullOrEmpty(messageToSend))
            {
                MessageBox.Show("Please enter a message to send.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                byte[] dataToSend;
                if (chkIsSecure.Checked)
                {
                    // Encrypt the message if encryption is enabled
                    dataToSend = EncryptMessage(messageToSend);
                }
                else
                {
                    // Send plain text
                    dataToSend = Encoding.UTF8.GetBytes(messageToSend);
                }

                // Send the message asynchronously
                await stream.WriteAsync(dataToSend, 0, dataToSend.Length);

                // Receive response from the server asynchronously
                byte[] receivedBuffer = new byte[256];
                int bytesRead = await stream.ReadAsync(receivedBuffer, 0, receivedBuffer.Length);
                byte[] receivedData = new byte[bytesRead];
                Array.Copy(receivedBuffer, receivedData, bytesRead);

                string responseMessage = chkIsSecure.Checked
                    ? DecryptMessage(receivedData)
                    : Encoding.UTF8.GetString(receivedData);

                txtReceive.Text = responseMessage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during communication: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the key press
            }
        }

        private void txtIPAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ignore the key press
            }
        }

        private void TCP_Load(object sender, EventArgs e)
        {  
            
        }               
    }
}
