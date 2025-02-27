
namespace Porus
{
    partial class UDPServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UDPServer));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExportText = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblActiveConnections = new System.Windows.Forms.Label();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnReceive = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExportText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblActiveConnections);
            this.groupBox1.Controls.Add(this.txtReceive);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnReceive);
            this.groupBox1.Location = new System.Drawing.Point(6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 437);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System.Net.Sockets.UDPClient ( Act as Server )";
            // 
            // btnExportText
            // 
            this.btnExportText.Location = new System.Drawing.Point(7, 408);
            this.btnExportText.Name = "btnExportText";
            this.btnExportText.Size = new System.Drawing.Size(112, 23);
            this.btnExportText.TabIndex = 4;
            this.btnExportText.Text = "Export in Text";
            this.btnExportText.UseVisualStyleBackColor = true;
            this.btnExportText.Click += new System.EventHandler(this.btnExportText_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter Port Number";
            // 
            // lblActiveConnections
            // 
            this.lblActiveConnections.AutoSize = true;
            this.lblActiveConnections.Location = new System.Drawing.Point(482, 40);
            this.lblActiveConnections.Name = "lblActiveConnections";
            this.lblActiveConnections.Size = new System.Drawing.Size(99, 13);
            this.lblActiveConnections.TabIndex = 4;
            this.lblActiveConnections.Text = "Active Connections";
            this.lblActiveConnections.Visible = false;
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(6, 76);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(598, 320);
            this.txtReceive.TabIndex = 3;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(7, 40);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 0;
            this.txtPort.Text = "23";
            this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPort_KeyPress);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(194, 40);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnReceive
            // 
            this.btnReceive.Location = new System.Drawing.Point(113, 40);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(75, 23);
            this.btnReceive.TabIndex = 1;
            this.btnReceive.Text = "Receive";
            this.btnReceive.UseVisualStyleBackColor = true;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // UDPServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 455);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UDPServer";
            this.Text = "System.Net.Sockets.UDPClient ( Act as Server )";
            this.Load += new System.EventHandler(this.UDPServer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblActiveConnections;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.Button btnExportText;
    }
}