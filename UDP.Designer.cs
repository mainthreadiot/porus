
namespace Porus
{
    partial class UDP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UDP));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkIsSecure = new System.Windows.Forms.CheckBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkIsSecure);
            this.groupBox1.Controls.Add(this.txtSend);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtServerIP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtServerPort);
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtReceive);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(613, 444);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System.Net.Sockets.UDPClient ( Act as Client )";
            // 
            // chkIsSecure
            // 
            this.chkIsSecure.AutoSize = true;
            this.chkIsSecure.Location = new System.Drawing.Point(285, 40);
            this.chkIsSecure.Name = "chkIsSecure";
            this.chkIsSecure.Size = new System.Drawing.Size(145, 17);
            this.chkIsSecure.TabIndex = 2;
            this.chkIsSecure.Text = "Tick to enhance Secutity";
            this.chkIsSecure.UseVisualStyleBackColor = true;
            // 
            // txtSend
            // 
            this.txtSend.BackColor = System.Drawing.SystemColors.Window;
            this.txtSend.Location = new System.Drawing.Point(6, 71);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(597, 208);
            this.txtSend.TabIndex = 5;
            this.txtSend.Text = "Send";
            this.txtSend.TextChanged += new System.EventHandler(this.txtSend_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Enter IP Address";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(13, 37);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(124, 20);
            this.txtServerIP.TabIndex = 0;
            this.txtServerIP.Text = "127.0.0.1";
            this.txtServerIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServerIP_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Enter Port Number";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(147, 37);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(124, 20);
            this.txtServerPort.TabIndex = 1;
            this.txtServerPort.Text = "23";
            this.txtServerPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServerPort_KeyPress);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(515, 36);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(434, 37);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtReceive
            // 
            this.txtReceive.BackColor = System.Drawing.SystemColors.Control;
            this.txtReceive.Location = new System.Drawing.Point(6, 285);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ReadOnly = true;
            this.txtReceive.Size = new System.Drawing.Size(599, 127);
            this.txtReceive.TabIndex = 6;
            this.txtReceive.Text = "Receive";
            // 
            // UDP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 432);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UDP";
            this.Text = "System.Net.Sockets.UDPClient( Act as Client )";
            this.Load += new System.EventHandler(this.UDP_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.CheckBox chkIsSecure;
    }
}