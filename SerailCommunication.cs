using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace Porus
{
    public partial class SerailCommunication : Form
    {
        private SerialPort serialPort;

        public SerailCommunication()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Initialize the SerialPort object
                serialPort = new SerialPort
                {
                    PortName = cmbSerialCommunication.Text.
                    ToString(),
                    BaudRate = Convert.ToInt32(cmbBaudRate.Text),
                    DataBits = Convert.ToInt32(cmbDataSize.Text),
                    Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text.ToString()),
                    StopBits = StopBits.One // Default to 1 stop bit
                };

                // Open the serial port
                serialPort.Open();
                serialPort.DataReceived += SerialPort_DataReceived;

                MessageBox.Show("Connection successful!", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Read the received data
                string receivedData = serialPort.ReadExisting();

                // Update the UI with the received data (on the UI thread)
                Invoke(new Action(() =>
                {
                    txtReceive.Text += receivedData + Environment.NewLine;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error receiving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SerailCommunication_Load(object sender, EventArgs e)
        {
           
        }      
        
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    // Send the text from the txtSend TextBox
                    serialPort.WriteLine(txtSend.Text);
                    MessageBox.Show("Message sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Serial port is not connected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SerailCommunication_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
    }
}
