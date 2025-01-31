
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
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmbDataSize = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSerialCommunication = new System.Windows.Forms.ComboBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtSend);
            this.groupBox1.Controls.Add(this.txtReceive);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 425);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Communication";
            // 
            // cmbParity
            // 
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.cmbParity.Location = new System.Drawing.Point(287, 32);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(59, 21);
            this.cmbParity.TabIndex = 15;
            this.cmbParity.Text = "None";
            // 
            // cmbDataSize
            // 
            this.cmbDataSize.FormattingEnabled = true;
            this.cmbDataSize.Items.AddRange(new object[] {
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
            this.cmbDataSize.Location = new System.Drawing.Point(205, 32);
            this.cmbDataSize.Name = "cmbDataSize";
            this.cmbDataSize.Size = new System.Drawing.Size(59, 21);
            this.cmbDataSize.TabIndex = 14;
            this.cmbDataSize.Text = "5";
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
            this.cmbBaudRate.Location = new System.Drawing.Point(123, 32);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(59, 21);
            this.cmbBaudRate.TabIndex = 13;
            this.cmbBaudRate.Text = "9600";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Parity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Data Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Baud";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Com Port";
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
            this.cmbSerialCommunication.Location = new System.Drawing.Point(41, 32);
            this.cmbSerialCommunication.Name = "cmbSerialCommunication";
            this.cmbSerialCommunication.Size = new System.Drawing.Size(59, 21);
            this.cmbSerialCommunication.TabIndex = 5;
            this.cmbSerialCommunication.Text = "COM1";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(468, 30);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(370, 30);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(6, 99);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(584, 180);
            this.txtSend.TabIndex = 4;
            this.txtSend.Text = "Send";
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(6, 285);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ReadOnly = true;
            this.txtReceive.Size = new System.Drawing.Size(584, 134);
            this.txtReceive.TabIndex = 3;
            this.txtReceive.Text = "Receive";
            // 
            // groupBox2
            // 
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
            // SerailCommunication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 450);
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
    }
}