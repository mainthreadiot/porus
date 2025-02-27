using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Porus
{
    public partial class CreateButtonForm : Form
    {
        private const string JsonFile = "buttons.json";
        public CreateButtonForm()
        {
            InitializeComponent();
        }

        private void CreateButtonForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtButtonName.Text.Trim();
            string command = txtCommand.Text.Trim();
            string topic = txtTopicName.Text.Trim();
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(command))
            {
                MessageBox.Show("Please enter both name and command.");
                return;
            }

            List<ButtonInfo> buttons = new List<ButtonInfo>();

            if (File.Exists(JsonFile) && new FileInfo(JsonFile).Length > 0)
            {
                try
                {
                    string json = File.ReadAllText(JsonFile);
                    buttons = JsonConvert.DeserializeObject<List<ButtonInfo>>(json) ?? new List<ButtonInfo>();
                }
                catch (JsonException)
                {
                    MessageBox.Show("Error reading JSON file. Resetting data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    buttons = new List<ButtonInfo>(); // Reset list if JSON is corrupt
                }
            }

            buttons.Add(new ButtonInfo { Name = name, Command = command, TopicName = topic });

            try
            {
                File.WriteAllText(JsonFile, JsonConvert.SerializeObject(buttons, Formatting.Indented));
                MessageBox.Show("Button saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save button: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtCommand_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
