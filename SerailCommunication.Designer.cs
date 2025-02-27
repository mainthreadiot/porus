
namespace Porus
{
    partial class SerailCommunication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerailCommunication));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cmbDataSize = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.cmbSerialCommunication = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClipboard = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.btnListenCOM1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtFirmwarePath = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnClipboard);
            this.groupBox1.Controls.Add(this.txtSend);
            this.groupBox1.Controls.Add(this.txtReceive);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 425);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Communication";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.cmbParity);
            this.groupBox2.Controls.Add(this.btnSend);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.cmbDataSize);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbBaudRate);
            this.groupBox2.Controls.Add(this.cmbSerialCommunication);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(6, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(584, 66);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(400, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbParity
            // 
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.cmbParity.Location = new System.Drawing.Point(238, 28);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(59, 21);
            this.cmbParity.TabIndex = 3;
            this.cmbParity.Text = "None";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(489, 28);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Baud";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(311, 28);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Open";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cmbDataSize
            // 
            this.cmbDataSize.FormattingEnabled = true;
            this.cmbDataSize.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cmbDataSize.Location = new System.Drawing.Point(165, 28);
            this.cmbDataSize.Name = "cmbDataSize";
            this.cmbDataSize.Size = new System.Drawing.Size(59, 21);
            this.cmbDataSize.TabIndex = 2;
            this.cmbDataSize.Text = "7";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Com Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Data Size";
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200"});
            this.cmbBaudRate.Location = new System.Drawing.Point(92, 28);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(59, 21);
            this.cmbBaudRate.TabIndex = 1;
            this.cmbBaudRate.Text = "9600";
            // 
            // cmbSerialCommunication
            // 
            this.cmbSerialCommunication.FormattingEnabled = true;
            this.cmbSerialCommunication.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.cmbSerialCommunication.Location = new System.Drawing.Point(19, 28);
            this.cmbSerialCommunication.Name = "cmbSerialCommunication";
            this.cmbSerialCommunication.Size = new System.Drawing.Size(59, 21);
            this.cmbSerialCommunication.TabIndex = 0;
            this.cmbSerialCommunication.Text = "COM1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Parity";
            // 
            // btnClipboard
            // 
            this.btnClipboard.Location = new System.Drawing.Point(473, 387);
            this.btnClipboard.Name = "btnClipboard";
            this.btnClipboard.Size = new System.Drawing.Size(108, 23);
            this.btnClipboard.TabIndex = 9;
            this.btnClipboard.Text = "Copy to clipboard";
            this.btnClipboard.UseVisualStyleBackColor = true;
            this.btnClipboard.Click += new System.EventHandler(this.btnClipboard_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(6, 99);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(584, 180);
            this.txtSend.TabIndex = 7;
            this.txtSend.Text = "Send";
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(6, 285);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ReadOnly = true;
            this.txtReceive.Size = new System.Drawing.Size(584, 134);
            this.txtReceive.TabIndex = 8;
            this.txtReceive.Text = "Receive";
            // 
            // btnListenCOM1
            // 
            this.btnListenCOM1.Location = new System.Drawing.Point(1010, 549);
            this.btnListenCOM1.Name = "btnListenCOM1";
            this.btnListenCOM1.Size = new System.Drawing.Size(121, 23);
            this.btnListenCOM1.TabIndex = 17;
            this.btnListenCOM1.Text = "LISTEN ON PORT 1";
            this.btnListenCOM1.UseVisualStyleBackColor = true;
            this.btnListenCOM1.Click += new System.EventHandler(this.btnListenCOM1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Select Firmware";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtFirmwarePath
            // 
            this.txtFirmwarePath.Enabled = false;
            this.txtFirmwarePath.Location = new System.Drawing.Point(120, 22);
            this.txtFirmwarePath.Name = "txtFirmwarePath";
            this.txtFirmwarePath.Size = new System.Drawing.Size(346, 20);
            this.txtFirmwarePath.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(472, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Upload Firmware";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.txtFirmwarePath);
            this.groupBox3.Location = new System.Drawing.Point(13, 445);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(595, 98);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Upload Firmware";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 25);
            this.label5.TabIndex = 22;
            this.label5.Text = "Progress";
            // 
            // SerailCommunication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 550);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnListenCOM1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SerailCommunication";
            this.Text = "Serial Communication";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SerailCommunication_FormClosing);
            this.Load += new System.EventHandler(this.SerailCommunication_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.ComboBox cmbSerialCommunication;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.ComboBox cmbDataSize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnListenCOM1;
        private System.Windows.Forms.Button btnClipboard;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtFirmwarePath;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
    }
}