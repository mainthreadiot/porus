using System;
using System.IO;
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
                if (serialPort != null && serialPort.IsOpen)
                {
                    MessageBox.Show("Serial port is already open.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ensure a port is selected
                if (string.IsNullOrWhiteSpace(cmbSerialCommunication.Text))
                {
                    MessageBox.Show("Please select a valid COM port.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                serialPort = new SerialPort
                {
                    PortName = cmbSerialCommunication.Text,
                    BaudRate = int.TryParse(cmbBaudRate.Text, out int baud) ? baud : 9600,
                    DataBits = int.TryParse(cmbDataSize.Text, out int dataBits) && (dataBits == 7 || dataBits == 8) ? dataBits : 8,  // FIXED: Default to 8 if invalid
                    Parity = Enum.TryParse(cmbParity.Text, out Parity parity) ? parity : Parity.None,
                    StopBits = StopBits.One
                };


                // Open the serial port
                serialPort.Open();
                serialPort.DataReceived += SerialPort_DataReceived;

                MessageBox.Show("Connection successful!", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access denied. The COM port might be in use by another application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Invalid COM port selected. Please check the available ports.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show("Error accessing the serial port. Make sure it is available and not in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (txtReceive != null && !txtReceive.IsDisposed)
                    {
                        txtReceive.AppendText(receivedData + Environment.NewLine);

                        // Auto-scroll to bottom
                        txtReceive.SelectionStart = txtReceive.Text.Length;
                        txtReceive.ScrollToCaret();
                    }
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
        private void btnListenCOM1_Click(object sender, EventArgs e) => ListenToPort("COM1");
        static void ListenToPort(string portName)
        {
            try
            {
                using (SerialPort serialPort = new SerialPort(portName))
                {
                    // Configure the serial port settings
                    serialPort.BaudRate = 9600;
                    serialPort.Parity = Parity.None;
                    serialPort.StopBits = StopBits.One;
                    serialPort.DataBits = 8;
                    serialPort.Handshake = Handshake.None;

                    // Open the port
                    serialPort.Open();
                    Console.WriteLine($"Started listening on {portName}");

                    while (true)
                    {
                        try
                        {
                            string data = serialPort.ReadLine(); // Read data line by line
                            Console.WriteLine($"[{portName}] Received: {data}");
                        }
                        catch (TimeoutException)
                        {
                            // Ignore timeout errors, as they are normal for ports
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error on {portName}: {ex.Message}");
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort == null)
                {
                    MessageBox.Show("Serial port is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!serialPort.IsOpen)
                {
                    MessageBox.Show("Serial port is not open. Please connect first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSend.Text))
                {
                    MessageBox.Show("Please enter a message to send.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                serialPort.WriteLine(txtSend.Text);
                MessageBox.Show("Message sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Serial port is closed. Please reconnect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ae)
            {
                MessageBox.Show("I/O error occurred. The port might be disconnected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access to the port is denied. It might be in use by another application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Close();  // Close the serial port
                    serialPort.Dispose();  // Release resources
                    MessageBox.Show("Serial port closed successfully.", "Disconnected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Serial port is already closed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error closing serial port: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        static void StartSimulator(string portName)
        {
            try
            {
                // Initialize the SerialPort
                serialPort1 = new SerialPort(portName)
                {
                    BaudRate = 9600,
                    Parity = Parity.None,
                    StopBits = StopBits.One,
                    DataBits = 8,
                    Handshake = Handshake.None
                };

                // Open the port
                serialPort1.Open();
                Console.WriteLine($"Port {portName} is open.");

                // Attach DataReceived event handler
               // serialPort1.DataReceived += SerialPort_DataReceived;

                // Start sending simulated data in a separate thread
                System.Threading.Thread sendThread = new System.Threading.Thread(SimulateDataSending);
                sendThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        //static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    try
        //    {
        //        // Read incoming data
        //        string receivedData = serialPort1.ReadLine();
        //        Console.WriteLine($"[Simulator] Received: {receivedData}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"[Receiver Error] {ex.Message}");
        //    }
        //}
        static void SimulateDataSending()
        {
            while (true)
            {
                try
                {
                    // Simulate sending data
                    string message = $"Simulated Data: {DateTime.Now}";
                    serialPort1.WriteLine(message);
                    Console.WriteLine($"[Simulator] Sent: {message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Simulator Error] {ex.Message}");
                }

                System.Threading.Thread.Sleep(2000); // Send data every 2 seconds
            }
        }
        static SerialPort serialPort1;

        private void btnListenCOM1_Click_1(object sender, EventArgs e)
        {
            string comPort = "COM1"; // Set to the desired port
            StartSimulator(comPort);

            Console.WriteLine("Press Enter to stop the simulator...");
            Console.ReadLine();

            // Cleanup
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }

        }

        private void btnClipboard_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReceive.Text))
            {
                Clipboard.SetText(txtReceive.Text);
                MessageBox.Show("Copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No text to copy!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin|Hex Files (*.hex)|*.hex|All Files (*.*)|*.*",
                Title = "Select Firmware File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFirmwarePath.Text = openFileDialog.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirmwarePath.Text) || !File.Exists(txtFirmwarePath.Text))
            {
                MessageBox.Show("Please select a valid firmware file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (serialPort == null || !serialPort.IsOpen)
            {
                MessageBox.Show("Serial port is not connected. Connect first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           System.Threading.Thread firmwareThread = new System.Threading.Thread(() => SendFirmware(txtFirmwarePath.Text));
            firmwareThread.IsBackground = true;
            firmwareThread.Start();
        }
        private void SendFirmware(string filePath)
        {
            try
            {
                byte[] firmwareData = File.ReadAllBytes(filePath);
                int chunkSize = 256;  // Send in chunks of 256 bytes
                int totalChunks = (int)Math.Ceiling((double)firmwareData.Length / chunkSize);

                Invoke(new Action(() => label5.Text = "Sending Firmware..."));

                for (int i = 0; i < totalChunks; i++)
                {
                    int start = i * chunkSize;
                    int length = Math.Min(chunkSize, firmwareData.Length - start);
                    byte[] chunk = new byte[length];
                    Array.Copy(firmwareData, start, chunk, 0, length);

                    serialPort.Write(chunk, 0, chunk.Length);
                    System.Threading.Thread.Sleep(50); // Give the device time to process

                    Invoke(new Action(() => label5.Text = Convert.ToString((i + 1) / (double)totalChunks * 100)));
                }

                Invoke(new Action(() => label5.Text = "Firmware Update Complete!"));
                MessageBox.Show("Firmware update successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => label5.Text = "Update Failed"));
                MessageBox.Show($"Firmware update failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
