namespace Porus
{
    partial class Checksum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Checksum));
            this.txtInputChecksum = new System.Windows.Forms.TextBox();
            this.txtSimpleChecksum = new System.Windows.Forms.TextBox();
            this.txtCRC = new System.Windows.Forms.TextBox();
            this.txtmdHecksum = new System.Windows.Forms.TextBox();
            this.txtSHA = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.bgrChecksum = new System.Windows.Forms.GroupBox();
            this.bgrChecksum.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInputChecksum
            // 
            this.txtInputChecksum.Location = new System.Drawing.Point(99, 22);
            this.txtInputChecksum.Multiline = true;
            this.txtInputChecksum.Name = "txtInputChecksum";
            this.txtInputChecksum.Size = new System.Drawing.Size(268, 104);
            this.txtInputChecksum.TabIndex = 0;
            this.txtInputChecksum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInputChecksum_KeyDown);
            // 
            // txtSimpleChecksum
            // 
            this.txtSimpleChecksum.Location = new System.Drawing.Point(201, 182);
            this.txtSimpleChecksum.Multiline = true;
            this.txtSimpleChecksum.Name = "txtSimpleChecksum";
            this.txtSimpleChecksum.ReadOnly = true;
            this.txtSimpleChecksum.Size = new System.Drawing.Size(166, 61);
            this.txtSimpleChecksum.TabIndex = 1;
            // 
            // txtCRC
            // 
            this.txtCRC.Location = new System.Drawing.Point(201, 248);
            this.txtCRC.Multiline = true;
            this.txtCRC.Name = "txtCRC";
            this.txtCRC.ReadOnly = true;
            this.txtCRC.Size = new System.Drawing.Size(166, 61);
            this.txtCRC.TabIndex = 2;
            // 
            // txtmdHecksum
            // 
            this.txtmdHecksum.Location = new System.Drawing.Point(201, 314);
            this.txtmdHecksum.Multiline = true;
            this.txtmdHecksum.Name = "txtmdHecksum";
            this.txtmdHecksum.ReadOnly = true;
            this.txtmdHecksum.Size = new System.Drawing.Size(166, 61);
            this.txtmdHecksum.TabIndex = 3;
            // 
            // txtSHA
            // 
            this.txtSHA.Location = new System.Drawing.Point(201, 380);
            this.txtSHA.Multiline = true;
            this.txtSHA.Name = "txtSHA";
            this.txtSHA.ReadOnly = true;
            this.txtSHA.Size = new System.Drawing.Size(166, 61);
            this.txtSHA.TabIndex = 4;
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(7, 71);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(89, 13);
            this.lblInput.TabIndex = 5;
            this.lblInput.Text = "Input / Plain Text";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "1. Simple Checksum (Sum of Bytes)\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "2. CRC32 (Cyclic Redundancy Check)\n Decimal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "3. MD5 (Message Digest Algorithm 5)\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "4. SHA-256 (Secure Hash Algorithm)\n";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(201, 140);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(166, 28);
            this.btnCalculate.TabIndex = 10;
            this.btnCalculate.Text = "Calculate Checksum";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // bgrChecksum
            // 
            this.bgrChecksum.BackColor = System.Drawing.Color.White;
            this.bgrChecksum.Controls.Add(this.txtInputChecksum);
            this.bgrChecksum.Controls.Add(this.btnCalculate);
            this.bgrChecksum.Controls.Add(this.txtSimpleChecksum);
            this.bgrChecksum.Controls.Add(this.label4);
            this.bgrChecksum.Controls.Add(this.txtCRC);
            this.bgrChecksum.Controls.Add(this.label3);
            this.bgrChecksum.Controls.Add(this.txtmdHecksum);
            this.bgrChecksum.Controls.Add(this.label2);
            this.bgrChecksum.Controls.Add(this.txtSHA);
            this.bgrChecksum.Controls.Add(this.label1);
            this.bgrChecksum.Controls.Add(this.lblInput);
            this.bgrChecksum.Location = new System.Drawing.Point(13, 13);
            this.bgrChecksum.Name = "bgrChecksum";
            this.bgrChecksum.Size = new System.Drawing.Size(378, 445);
            this.bgrChecksum.TabIndex = 11;
            this.bgrChecksum.TabStop = false;
            this.bgrChecksum.Text = "Checksum - All in one";
            // 
            // Checksum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 469);
            this.Controls.Add(this.bgrChecksum);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Checksum";
            this.Text = "Checksum";
            this.Load += new System.EventHandler(this.Checksum_Load);
            this.bgrChecksum.ResumeLayout(false);
            this.bgrChecksum.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtInputChecksum;
        private System.Windows.Forms.TextBox txtSimpleChecksum;
        private System.Windows.Forms.TextBox txtCRC;
        private System.Windows.Forms.TextBox txtmdHecksum;
        private System.Windows.Forms.TextBox txtSHA;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.GroupBox bgrChecksum;
    }
}