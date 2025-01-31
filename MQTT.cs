using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace Porus
{
    public partial  class MQTT : Form
    {
        private int childFormNumber = 0;
        public static IMqttClient mqttClient;
        public static IMqttClientOptions mqttOptions;
        public static string QoS;
        public static string ClientId;
        public MQTT()
        {
            InitializeComponent();
            try { LoadMqttSettings(); } catch { }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void subscriberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Subscriber childForm = new Subscriber();
            childForm.MdiParent = this;
            childForm.Text = "Subscriber " + childFormNumber++;
            childForm.Show();
        }

        private void publisherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Publisher childForm = new Publisher();
            childForm.MdiParent = this;
            childForm.Text = "Subscriber " + childFormNumber++;
            childForm.Show();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            if (mqttClient != null && mqttClient.IsConnected)
            {
                MessageBox.Show("Already connected.", "MQTT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            QoS = cmbQoS.Text;
            ClientId = txtClientID.Text;

            try
            {
                if (cmbProtocol.SelectedItem == "" || cmbProtocol.SelectedItem == string.Empty)
                {
                    MessageBox.Show("Please Select Protocol.", "MQTT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtPort.Text == "" || txtPort.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter Port.", "MQTT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtHost.Text == "" || txtHost.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter Broker IP.", "MQTT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // MQTT options setup
                string protocol = cmbProtocol.SelectedItem.ToString();
                int port = int.Parse(txtPort.Text);
                string host = txtHost.Text;

                mqttOptions = new MqttClientOptionsBuilder()
                    .WithClientId(txtClientID.Text)
                    .WithTcpServer(host, port)
                    .WithCredentials(txtUseradmin.Text, txtPassword.Text)
                    .WithCleanSession()
                    .Build();

                mqttClient = new MqttFactory().CreateMqttClient();

                // Handlers for events
                mqttClient.UseConnectedHandler(async args =>
                {
                    MessageBox.Show("Connected to MQTT broker.", "MQTT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await mqttClient.SubscribeAsync(new MQTTnet.Client.Subscribing.MqttClientSubscribeOptionsBuilder()
                        .WithTopicFilter("default/topic")
                        .Build());
                });

                mqttClient.UseDisconnectedHandler(args =>
                {
                    MessageBox.Show("Disconnected from MQTT broker.", "MQTT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });

                mqttClient.UseApplicationMessageReceivedHandler(args =>
                {
                    string message = Encoding.UTF8.GetString(args.ApplicationMessage.Payload);
                    MessageBox.Show($"Received message: {message}", "MQTT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });

                btnSubscriber.Enabled = true;
                btnPublisher.Enabled = true;

                // Connect to the broker
                await mqttClient.ConnectAsync(mqttOptions);

                // Save MQTT settings to mqtt.json
                SaveMqttSettingsToJson();
            }
            catch (Exception ex)
            {
                btnConnect.Enabled = true;
                MessageBox.Show($"Connection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadMqttSettings()
        {
            if (File.Exists("mqtt.json"))
            {
                string json = File.ReadAllText("mqtt.json");
                var mqttSettings = JsonConvert.DeserializeObject<dynamic>(json);

                // Populate the form controls with the saved settings
                txtHost.Text = mqttSettings.Host;
                txtPort.Text = mqttSettings.Port;
                txtClientID.Text = mqttSettings.ClientId;
                cmbProtocol.SelectedItem = mqttSettings.Protocol;
                txtUseradmin.Text = mqttSettings.Username;
                txtPassword.Text = mqttSettings.Password;
            }
            else
            {
                MessageBox.Show("No MQTT settings found.", "MQTT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Method to save MQTT settings to a JSON file
        private void SaveMqttSettingsToJson()
        {
            var mqttSettings = new
            {
                Host = txtHost.Text,
                Port = txtPort.Text,
                ClientId = txtClientID.Text,
                Protocol = cmbProtocol.SelectedItem.ToString(),
                Username = txtUseradmin.Text,
                Password = txtPassword.Text
            };

            string json = JsonConvert.SerializeObject(mqttSettings, Formatting.Indented);
            File.WriteAllText("mqtt.json", json);
        }

        private async void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                btnConnect.Enabled = true;
                await MQTT.mqttClient.DisconnectAsync();
                    MessageBox.Show("Disconnected from the MQTT broker.", "MQTT Disconnection", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while disconnecting: {ex.Message}", "MQTT Disconnection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubscriber_Click(object sender, EventArgs e)
        {
            Subscriber childForm = new Subscriber();
            childForm.MdiParent = this;
            childForm.Text = "Subscriber";
            childForm.Show();
        }

        private void btnPublisher_Click(object sender, EventArgs e)
        {
            Publisher childForm = new Publisher();
            childForm.MdiParent = this;
            childForm.Text = "Publisher";
            childForm.Show();
        }

        private void MQTT_Load(object sender, EventArgs e)
        {
            txtClientID.Text = Guid.NewGuid().ToString();
            LoadButtons();
        }
        private const string JsonFile = "buttons.json";


        private void LoadButtons()
        {
            panelButtons.Controls.Clear(); // Clear existing buttons

            if (!File.Exists(JsonFile) || new FileInfo(JsonFile).Length == 0)
            {
                return; // If file doesn't exist or is empty, return without doing anything
            }

            try
            {
                string json = File.ReadAllText(JsonFile);
                List<ButtonInfo> buttons = JsonConvert.DeserializeObject<List<ButtonInfo>>(json) ?? new List<ButtonInfo>();

                int xPosition = 10; // Horizontal position for the first button
                int yPosition = 10; // Vertical position for the first row of buttons
                int buttonWidth = 100; // Fixed width for buttons
                int buttonHeight = 40; // Fixed height for buttons
                int deleteButtonWidth = 60; // Width of the delete button
                int columnCount = 0; // Track number of buttons in the current row
                int maxColumns = 3; // Max buttons in one row before wrapping

                foreach (var btnInfo in buttons)
                {
                    Button btn = new Button
                    {
                        Text = btnInfo.Name,
                        Tag = btnInfo.Command,
                        
                        Size = new System.Drawing.Size(buttonWidth, buttonHeight), // Set size for main button
                        Location = new System.Drawing.Point(xPosition, yPosition) // Set location for main button
                    };

                    // Add click event to show the command
                    btn.Click += (s, e) =>
                    {
                        if (MQTT.mqttClient == null || !MQTT.mqttClient.IsConnected)
                        {
                            MessageBox.Show("Please connect to the broker first.", "MQTT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string topic = btnInfo.TopicName; // Use txtProfileName as the topic
                        string payload = btnInfo.Command;  // Use txtClientID as the message

                        int qosLevel = int.Parse(MQTT.QoS.ToString().Split('-')[0].Trim()); // Get QoS level (0, 1, or 2)

                        try
                        {
                            var message = new MqttApplicationMessageBuilder()
                                .WithTopic(topic)
                                .WithPayload(payload)
                                .WithQualityOfServiceLevel((MQTTnet.Protocol.MqttQualityOfServiceLevel)qosLevel)
                                .Build();

                            MQTT.mqttClient.PublishAsync(message);

                            MessageBox.Show("4=published successfully.", "MQTT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Publish failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    // Create the delete button and position it to the right of the main button
                    Button deleteBtn = new Button
                    {
                        Text = "Delete",
                        Size = new System.Drawing.Size(deleteButtonWidth, buttonHeight), // Set size for delete button
                        Location = new System.Drawing.Point(xPosition + buttonWidth + 10, yPosition) // Position delete button next to the main button
                    };

                    // Delete button click event
                    deleteBtn.Click += (s, e) =>
                    {
                        // Remove the button and delete button from the panel
                        panelButtons.Controls.Remove(btn);
                        panelButtons.Controls.Remove(deleteBtn);

                        // Remove the button from the list and update JSON file
                        buttons.Remove(btnInfo);
                        File.WriteAllText(JsonFile, JsonConvert.SerializeObject(buttons, Formatting.Indented));

                        // Refresh the panel to reflect the changes
                        LoadButtons();
                    };

                    panelButtons.Controls.Add(btn);
                    panelButtons.Controls.Add(deleteBtn);

                    columnCount++; // Increase column count
                    if (columnCount >= maxColumns)
                    {
                        // Move to the next row after 3 buttons
                        columnCount = 0;
                        xPosition = 10; // Reset to first column
                        yPosition += buttonHeight + 10; // Move down by button height and a little extra spacing
                    }
                    else
                    {
                        // Move to next column for the next button
                        xPosition += buttonWidth + deleteButtonWidth + 20; // Account for the delete button width and extra spacing
                    }
                }

                panelButtons.AutoScroll = true; // Enable scrolling if needed
            }
            catch (JsonException)
            {
                MessageBox.Show("Error reading JSON file. Resetting data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                File.WriteAllText(JsonFile, "[]"); // Reset the file to an empty JSON array
            }
        }

       
        private void txtHost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ignore the key press
            }
        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the key press
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateButtonForm form = new CreateButtonForm();
            form.Show();
        }
    }
    public class ButtonInfo
    {
        public string Name { get; set; }
        public string Command { get; set; }
        public string TopicName { get; set; }
    }
}
