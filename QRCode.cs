using System;
using System.Drawing;
using System.Windows.Forms;

namespace Porus
{
    public partial class QRCode : Form
    {
        public QRCode()
        {
            InitializeComponent();
        }

        private void btnGenerateBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the text from the input field (txtInputBarcode)
                string inputText = txtInputBarcode.Text;

                if (!string.IsNullOrEmpty(inputText))
                {
                    // Generate the QR code from the text
                    Image qrCodeImage = GenerateQRCode(inputText);

                    // Display the QR code image in the PictureBox (pbImage)
                    pbImage.Image = qrCodeImage;

                    // Set the PictureBox SizeMode to stretch the image
                    pbImage.SizeMode = PictureBoxSizeMode.StretchImage;

                    // Alternatively, use the following to maintain the aspect ratio:
                    // pbImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    MessageBox.Show("Please enter text to generate a QR code.", "No Text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating QR code: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Image GenerateQRCode(string inputText)
        {
            try
            {
                // Initialize the QR code writer
                var qrCodeWriter = new ZXing.BarcodeWriter();
                qrCodeWriter.Format = ZXing.BarcodeFormat.QR_CODE;

                // Generate the QR code as an image
                return qrCodeWriter.Write(inputText);
            }
            catch (Exception ex)
            {
                // Handle any errors during QR code generation
                MessageBox.Show($"Error generating QR code: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void btnDecodeBarcode_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDownloadImage_Click(object sender, EventArgs e)
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
                if (pbImage.Image != null)
                {
                    try
                    {
                        // Save the image to the selected path
                        pbImage.Image.Save(saveFileDialog.FileName);
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

        private void btnBrowseBarcode_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to allow the user to browse and select an image
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter for allowed image types (e.g., PNG, JPG, BMP)
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
            openFileDialog.Title = "Select Barcode Image";

            // Show the file dialog and check if the user selects a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the selected image into the PictureBox
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);

                    // Optionally set the PictureBox to stretch the image to fit
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    // If you want to maintain the aspect ratio, you can use Zoom instead:
                    // pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                    // If you want the image to be centered without resizing, use:
                    // pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                catch (Exception ex)
                {
                    // Handle any errors (e.g., invalid file format or file not found)
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPasteImage_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the clipboard contains an image
                if (Clipboard.ContainsImage())
                {
                    // Get the image from the clipboard and set it to the PictureBox
                    pbImage.Image = Clipboard.GetImage();
                    pbImage.BackgroundImageLayout = ImageLayout.Stretch;
                    // Try to decode the QR code from the image
                    string decodedText = DecodeQRCode(pbImage.Image);

                    if (!string.IsNullOrEmpty(decodedText))
                    {
                        // Display the decoded text (QR code content) in a textbox or label
                        txtInputBarcode.Text = decodedText;
                    }
                    else
                    {
                        MessageBox.Show("No QR code detected in the image.", "Invalid QR Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No image found in clipboard. Please copy an image first.", "No Image", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error pasting image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string DecodeQRCode(Image qrCodeImage)
        {
            try
            {
                // Initialize the QR code reader
                var reader = new ZXing.BarcodeReader();

                // Decode the image to a string (QR code text)
                var result = reader.Decode((Bitmap)qrCodeImage);

                // Return the decoded text if available, else return an empty string
                return result?.Text ?? string.Empty;
            }
            catch (Exception ex)
            {
                // Handle any errors during decoding
                MessageBox.Show($"Error decoding QR code: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
        private void btnBarcodeToString_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if there is an image in the PictureBox
                if (pictureBox1.Image != null)
                {
                    // Decode the barcode from the image
                    string barcodeText = DecodeBarcode(pictureBox1.Image);

                    if (!string.IsNullOrEmpty(barcodeText))
                    {
                        // Display the decoded barcode text in the TextBox or Label (txtInputBarcode)
                        txtNumber.Text = barcodeText;
                    }
                    else
                    {
                        MessageBox.Show("No barcode detected in the image.", "Invalid Barcode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please load an image first.", "No Image", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading barcode: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string DecodeBarcode(Image barcodeImage)
        {
            try
            {
                // Initialize the barcode reader
                var reader = new ZXing.BarcodeReader();

                // Decode the barcode and return the result
                var result = reader.Decode((Bitmap)barcodeImage);

                // Return the decoded barcode text, or an empty string if not found
                return result?.Text ?? string.Empty;
            }
            catch (Exception ex)
            {
                // Handle errors in barcode decoding
                MessageBox.Show($"Error decoding barcode: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void QRCode_Load(object sender, EventArgs e)
        {
          
        }      
       
    }
}
