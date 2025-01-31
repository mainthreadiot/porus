using System;
using System.Drawing;
using System.Windows.Forms;
using ZXing;

namespace Porus
{
    public partial class Barcode : Form
    {
        public Barcode()
        {
            InitializeComponent();
        }

        private void btnGenerateBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                string input = txtInputBarcode.Text.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Please enter a number to generate a barcode.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BarcodeWriter writer = new BarcodeWriter
                {
                    Format = BarcodeFormat.CODE_128,
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Height = pbImage.Height,
                        Width = pbImage.Width,
                        Margin = 2
                    }
                };

                Bitmap barcodeImage = writer.Write(input);
                pbImage.Image = barcodeImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating barcode: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecodeBarcode_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDownloadImage_Click(object sender, EventArgs e)
        {
            if (pbImage.Image == null)
            {
                MessageBox.Show("No image to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp|All Files|*.*";
                saveFileDialog.Title = "Save Image As";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pbImage.Image.Save(saveFileDialog.FileName);
                        MessageBox.Show("Image saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while saving the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnBrowseBarcode_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to allow the user to browse and select an image
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter for allowed image types (for example, PNG, JPG, BMP)
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
            openFileDialog.Title = "Select Barcode Image";

            // Show the file dialog and check if the user selects a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the selected image into the PictureBox
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    // Handle any errors (for example, invalid file format)
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPasteImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsImage())
                {
                    pictureBox1.Image = Clipboard.GetImage();
                }
                else
                {
                    MessageBox.Show("No image found in clipboard.", "No Image", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error pasting image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBarcodeToString_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("No barcode image available to decode.", "No Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BarcodeReader reader = new BarcodeReader();
                using (Bitmap barcodeBitmap = new Bitmap(pictureBox1.Image))
                {
                    var result = reader.Decode(barcodeBitmap);
                    if (result != null)
                    {
                        txtNumber.Text = result.Text; // More direct assignment
                    }
                    else
                    {
                        MessageBox.Show("Unable to decode the barcode.", "Decode Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error decoding barcode: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (pbImage.Image != null)
            {
                try
                {
                    // Copy the image from PictureBox to the clipboard
                    Clipboard.SetImage(pbImage.Image);
                    MessageBox.Show("Image copied to clipboard.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to copy image to clipboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No image found in PictureBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Barcode_Load(object sender, EventArgs e)
        {
           
        }               
    }
}
