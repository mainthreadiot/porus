using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Porus
{
    public partial class UDP : Form
    {
        private UdpClient udpClient;
        private IPEndPoint serverEndPoint;
        public UDP()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                btnConnect.Enabled = false;
                udpClient = new UdpClient(); // Do not bind to a specific port
                serverEndPoint = new IPEndPoint(IPAddress.Parse(txtServerIP.Text), Convert.ToInt32(txtServerPort.Text));

                MessageBox.Show("Ready to send data over UDP.", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch (Exception ex)
            {
                btnConnect.Enabled = true;
                MessageBox.Show($"Connection failed: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (udpClient == null || serverEndPoint == null)
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

                // Send the message via UDP
                udpClient.Send(dataToSend, dataToSend.Length, serverEndPoint);

                // Start a task to handle receiving the response asynchronously
                Task.Run(() => ReceiveResponse());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during communication: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to handle receiving the response asynchronously
        private void ReceiveResponse()
        {
            try
            {
                // Receive the response
                byte[] receivedBuffer = udpClient.Receive(ref serverEndPoint);

                string responseMessage = chkIsSecure.Checked
                    ? DecryptMessage(receivedBuffer)
                    : Encoding.UTF8.GetString(receivedBuffer);

                // Update the UI with the received message (must be done on the UI thread)
                Invoke(new Action(() =>
                {
                    txtReceive.Text = responseMessage;
                }));
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during receive
                Invoke(new Action(() =>
                {
                    MessageBox.Show($"Error during receiving response: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }
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

        private void txtSend_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtServerPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the key press
            }
        }

        private void txtServerIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ignore the key press
            }
        }

        private void UDP_Load(object sender, EventArgs e)
        {
           
        }                
    }
}
