using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Receiving;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Porus
{
    public partial class Subscriber : Form
    {
        public Subscriber()
        {
            InitializeComponent();
        }

        private void Subscriber_Load(object sender, EventArgs e)
        {
         
        }    
        
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

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

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                btnSubscribe.Enabled = false;
                // Get the topic from the input field
                string topic = txtTopic.Text;

                if (string.IsNullOrWhiteSpace(topic))
                {
                    MessageBox.Show("Please enter a topic to subscribe to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Subscribe to the topic
                await MQTT.mqttClient.SubscribeAsync(new MQTTnet.Client.Subscribing.MqttClientSubscribeOptionsBuilder()
                    .WithTopicFilter(topic, MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                    .Build());

                lblStatus.Text = $"Subscribed to topic: {topic}";
                MQTT.mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(MessageReceivedHandler);

                // Handle incoming messages
                //MQTT.mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(messageEventArgs =>
                //{
                //    if (messageEventArgs.ApplicationMessage.Topic == topic)
                //    {
                //        // Decode the received payload
                //        string receivedPayload = Encoding.UTF8.GetString(messageEventArgs.ApplicationMessage.Payload);

                //        // Ensure UI update runs on the main thread
                //        Invoke(new Action(() =>
                //        {
                //            if (txtPayload != null && !txtPayload.IsDisposed)
                //            {
                //                // Append new data to the textbox with a newline
                //                txtPayload.Text=receivedPayload + Environment.NewLine;

                //                // Scroll to the bottom
                //                txtPayload.SelectionStart = txtPayload.Text.Length;
                //                txtPayload.ScrollToCaret();
                //            }
                //        }));
                //    }
                //});
            }
            catch (Exception ex)
            {
                btnSubscribe.Enabled = true;
                MessageBox.Show($"Failed to subscribe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MessageReceivedHandler(MqttApplicationMessageReceivedEventArgs messageEventArgs)
        {
            string receivedPayload = Encoding.UTF8.GetString(messageEventArgs.ApplicationMessage.Payload);

            // Ensure UI update runs on the main thread
            Invoke(new Action(() =>
            {
                if (txtPayload != null && !txtPayload.IsDisposed)
                {
                    // Append new data instead of replacing text
                    txtPayload.AppendText(receivedPayload + Environment.NewLine);

                    // Scroll to the bottom
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
    }
}
