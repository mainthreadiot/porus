
namespace Porus
{
    partial class QRCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QRCode));
            this.txtInputBarcode = new System.Windows.Forms.TextBox();
            this.btnGenerateBarcode = new System.Windows.Forms.Button();
            this.btnDecodeBarcode = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDownloadImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPasteImage = new System.Windows.Forms.Button();
            this.btnBrowseBarcode = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnBarcodeToString = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInputBarcode
            // 
            this.txtInputBarcode.Location = new System.Drawing.Point(8, 40);
            this.txtInputBarcode.Multiline = true;
            this.txtInputBarcode.Name = "txtInputBarcode";
            this.txtInputBarcode.Size = new System.Drawing.Size(141, 153);
            this.txtInputBarcode.TabIndex = 0;
            // 
            // btnGenerateBarcode
            // 
            this.btnGenerateBarcode.Location = new System.Drawing.Point(168, 99);
            this.btnGenerateBarcode.Name = "btnGenerateBarcode";
            this.btnGenerateBarcode.Size = new System.Drawing.Size(75, 36);
            this.btnGenerateBarcode.TabIndex = 2;
            this.btnGenerateBarcode.Text = "Generate";
            this.btnGenerateBarcode.UseVisualStyleBackColor = true;
            this.btnGenerateBarcode.Click += new System.EventHandler(this.btnGenerateBarcode_Click);
            // 
            // btnDecodeBarcode
            // 
            this.btnDecodeBarcode.Location = new System.Drawing.Point(694, 138);
            this.btnDecodeBarcode.Name = "btnDecodeBarcode";
            this.btnDecodeBarcode.Size = new System.Drawing.Size(75, 30);
            this.btnDecodeBarcode.TabIndex = 3;
            this.btnDecodeBarcode.Text = "Decode";
            this.btnDecodeBarcode.UseVisualStyleBackColor = true;
            this.btnDecodeBarcode.Click += new System.EventHandler(this.btnDecodeBarcode_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnDownloadImage);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtInputBarcode);
            this.groupBox1.Controls.Add(this.pbImage);
            this.groupBox1.Controls.Add(this.btnGenerateBarcode);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(7, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 246);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "String to QRCode generator";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(376, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "Copy QR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDownloadImage
            // 
            this.btnDownloadImage.Location = new System.Drawing.Point(267, 201);
            this.btnDownloadImage.Name = "btnDownloadImage";
            this.btnDownloadImage.Size = new System.Drawing.Size(96, 36);
            this.btnDownloadImage.TabIndex = 5;
            this.btnDownloadImage.Text = "Download QR";
            this.btnDownloadImage.UseVisualStyleBackColor = true;
            this.btnDownloadImage.Click += new System.EventHandler(this.btnDownloadImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter QRCode";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox2.Controls.Add(this.btnPasteImage);
            this.groupBox2.Controls.Add(this.btnBrowseBarcode);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtNumber);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.btnBarcodeToString);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(7, 261);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(497, 246);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "QR to string generator";
            // 
            // btnPasteImage
            // 
            this.btnPasteImage.Location = new System.Drawing.Point(113, 26);
            this.btnPasteImage.Name = "btnPasteImage";
            this.btnPasteImage.Size = new System.Drawing.Size(96, 36);
            this.btnPasteImage.TabIndex = 6;
            this.btnPasteImage.Text = "Paste Image";
            this.btnPasteImage.UseVisualStyleBackColor = true;
            this.btnPasteImage.Click += new System.EventHandler(this.btnPasteImage_Click);
            // 
            // btnBrowseBarcode
            // 
            this.btnBrowseBarcode.Location = new System.Drawing.Point(11, 26);
            this.btnBrowseBarcode.Name = "btnBrowseBarcode";
            this.btnBrowseBarcode.Size = new System.Drawing.Size(96, 36);
            this.btnBrowseBarcode.TabIndex = 5;
            this.btnBrowseBarcode.Text = "Browse QR";
            this.btnBrowseBarcode.UseVisualStyleBackColor = true;
            this.btnBrowseBarcode.Click += new System.EventHandler(this.btnBrowseBarcode_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(330, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "QRCode";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(333, 68);
            this.txtNumber.Multiline = true;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(139, 153);
            this.txtNumber.TabIndex = 0;
            // 
            // btnBarcodeToString
            // 
            this.btnBarcodeToString.Location = new System.Drawing.Point(227, 121);
            this.btnBarcodeToString.Name = "btnBarcodeToString";
            this.btnBarcodeToString.Size = new System.Drawing.Size(75, 36);
            this.btnBarcodeToString.TabIndex = 2;
            this.btnBarcodeToString.Text = "Generate";
            this.btnBarcodeToString.UseVisualStyleBackColor = true;
            this.btnBarcodeToString.Click += new System.EventHandler(this.btnBarcodeToString_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Porus.Properties.Resources.QRCode;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(6, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 153);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pbImage
            // 
            this.pbImage.BackgroundImage = global::Porus.Properties.Resources.QRCode;
            this.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImage.Location = new System.Drawing.Point(267, 40);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(205, 153);
            this.pbImage.TabIndex = 1;
            this.pbImage.TabStop = false;
            // 
            // QRCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 515);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDecodeBarcode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QRCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Barcode";
            this.Load += new System.EventHandler(this.QRCode_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtInputBarcode;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnGenerateBarcode;
        private System.Windows.Forms.Button btnDecodeBarcode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDownloadImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBrowseBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBarcodeToString;
        private System.Windows.Forms.Button btnPasteImage;
        private System.Windows.Forms.Button button1;
    }
}