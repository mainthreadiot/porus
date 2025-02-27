using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Porus
{
    public partial class Base64Conversion : Form
    {
        public Base64Conversion()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            string base64 = ConvertToBase64(input);
            txtResult.Text = base64;
        }
        private string ConvertToBase64(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;
                    label3.Text = imagePath; // Show selected file path in txtInput
                    txtResult.Text = ConvertImageToBase64(imagePath); // Convert and show Base64
                }
            }
        }
        private string ConvertImageToBase64(string imagePath)
        {
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageBytes);
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a File";
                openFileDialog.Filter = "All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    label4.Text = filePath; // Show file path
                    txtResult.Text = ConvertFileToBase64(filePath); // Convert file to Base64
                }
            }
        }
        private string ConvertFileToBase64(string filePath)
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);
            return Convert.ToBase64String(fileBytes);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string base64String = txtResult.Text;
            if (!string.IsNullOrEmpty(base64String))
            {
                pictureBox4.SizeMode = PictureBoxSizeMode.Zoom; // Ensures image fits within the PictureBox
                pictureBox4.Image = ConvertBase64ToImage(base64String);                
            }
            else
            {
                MessageBox.Show("Please enter a valid Base64 string.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private Image ConvertBase64ToImage(string base64String)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                MessageBox.Show("Error while converting Image.");
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtResult.Text))
                {
                    Clipboard.SetText(txtResult.Text);
                    MessageBox.Show("Copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No text to copy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Error while converting File.");
            }
        }

        private void Base64Conversion_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog instance to prompt the user for a file location
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set filter for the types of images you want to save (for example, PNG, JPG)
            saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp|All Files|*.*";
            saveFileDialog.Title = "Save Image As";

            // If the user selects a file and presses "Save"
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Check if the PictureBox contains an image
                if (pictureBox4.Image != null)
                {
                    try
                    {
                        // Save the image to the selected path
                        pictureBox4.Image.Save(saveFileDialog.FileName);
                        MessageBox.Show("Image saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that occur during the saving process
                        MessageBox.Show($"An error occurred while saving the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No image to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
