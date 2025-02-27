using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Porus
{
    public partial class Subscriber : Form
    {
        private IMqttClient _mqttClient;
        private IMqttClientOptions _options;
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        public Subscriber()
        {
            InitializeComponent();
            _mqttClient = MQTT.mqttClient;
            //InitializeMqttClient();
        }

        private async void InitializeMqttClient()
        {
            try
            {
                var factory = new MqttFactory();
                _mqttClient = factory.CreateMqttClient();

                _options = new MqttClientOptionsBuilder()
                    .WithClientId(Guid.NewGuid().ToString()) // Unique ID per instance
                    .WithTcpServer("broker.hivemq.com", 1883) // Use your broker
                    .WithCleanSession()
                    .WithCommunicationTimeout(TimeSpan.FromSeconds(10)) // Increased timeout
                    .Build();

                _mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(MessageReceivedHandler);

                // Attempt connection when initializing
                await ConnectMqttClient();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"MQTT Initialization Failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task ConnectMqttClient()
        {
            if (!_mqttClient.IsConnected)
            {
                try
                {
                    await _mqttClient.ConnectAsync(_options);
                    lblStatus.Text = "Connected to MQTT Broker";
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Failed to connect";
                    MessageBox.Show($"Connection Failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async void Subscriber_Load(object sender, EventArgs e)
        {
            try
            {
                if (!_mqttClient.IsConnected)
                {
                    await _mqttClient.ConnectAsync(_options);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect to MQTT Broker: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
       private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                btnSubscribe.Enabled = false;
                string topic = txtTopic.Text;

                if (string.IsNullOrWhiteSpace(topic))
                {
                    MessageBox.Show("Please enter a topic to subscribe to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSubscribe.Enabled = true;
                    return;
                }

                // Ensure MQTT client is connected before subscribing
                if (MQTT.mqttClient == null)
                {
                    MessageBox.Show("MQTT client is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!MQTT.mqttClient.IsConnected)
                {
                    try
                    {
                        await MQTT.mqttClient.ConnectAsync(new MqttClientOptionsBuilder()
                            .WithTcpServer("broker.hivemq.com", 1883) // Use your actual broker
                            .WithClientId(Guid.NewGuid().ToString()) // Ensure unique client ID
                            .WithCleanSession()
                            .WithCommunicationTimeout(TimeSpan.FromSeconds(10))
                            .Build());

                        lblStatus.Text = "Connected to MQTT Broker";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to connect to MQTT Broker: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnSubscribe.Enabled = true;
                        return;
                    }
                }

                // Subscribe to the topic
                await MQTT.mqttClient.SubscribeAsync(new MQTTnet.Client.Subscribing.MqttClientSubscribeOptionsBuilder()
                    .WithTopicFilter(topic, MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                    .Build());

                lblStatus.Text = $"Subscribed to: {topic}";
                MQTT.mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(MessageReceivedHandler);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Subscription Failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
               //btnSubscribe.Enabled = true;
            }
        }

        private void MessageReceivedHandler(MqttApplicationMessageReceivedEventArgs messageEventArgs)
        {
            string receivedPayload = Encoding.UTF8.GetString(messageEventArgs.ApplicationMessage.Payload);
            string receivedTopic = messageEventArgs.ApplicationMessage.Topic;

            Invoke(new Action(() =>
            {
                if (txtPayload != null && !txtPayload.IsDisposed)
                {
                    txtPayload.AppendText($"[{receivedTopic}] {receivedPayload}" + Environment.NewLine);
                    txtPayload.SelectionStart = txtPayload.Text.Length;
                    txtPayload.ScrollToCaret();
                }
            }));
        }

        private void btnClipboard_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPayload.Text))
            {
                Clipboard.SetText(txtPayload.Text);
                MessageBox.Show("Copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No text to copy!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void panelTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void panelTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
    }
}
