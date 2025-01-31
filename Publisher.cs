using MQTTnet;
using MQTTnet.Client;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Porus
{
    public partial class Publisher : Form
    {
        public Publisher()
        {
            InitializeComponent();
        }

        private void Publisher_Load(object sender, EventArgs e)
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
            if (MQTT.mqttClient == null || !MQTT.mqttClient.IsConnected)
            {
                MessageBox.Show("Please connect to the broker first.", "MQTT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string topic = txtTopic.Text; // Use txtProfileName as the topic
            string payload = txtPayload.Text;  // Use txtClientID as the message

            int qosLevel = int.Parse(MQTT.QoS.ToString().Split('-')[0].Trim()); // Get QoS level (0, 1, or 2)

            try
            {
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithPayload(payload)
                    .WithQualityOfServiceLevel((MQTTnet.Protocol.MqttQualityOfServiceLevel)qosLevel)
                    .Build();

                await MQTT.mqttClient.PublishAsync(message);

                MessageBox.Show("Message published successfully.", "MQTT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Publish failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
