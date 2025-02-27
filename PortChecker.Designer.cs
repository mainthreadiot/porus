namespace Porus
{
    partial class PortChecker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortChecker));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblResult = new System.Windows.Forms.TextBox();
            this.BtnCheckLatency = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnGetCurrentIP = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPortCheckerPort = new System.Windows.Forms.TextBox();
            this.txtPortCheckerIP = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblResult);
            this.panel1.Controls.Add(this.BtnCheckLatency);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.btnCheck);
            this.panel1.Controls.Add(this.btnGetCurrentIP);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPortCheckerPort);
            this.panel1.Controls.Add(this.txtPortCheckerIP);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 247);
            this.panel1.TabIndex = 0;
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.Color.Black;
            this.lblResult.ForeColor = System.Drawing.Color.White;
            this.lblResult.Location = new System.Drawing.Point(312, 81);
            this.lblResult.Multiline = true;
            this.lblResult.Name = "lblResult";
            this.lblResult.ReadOnly = true;
            this.lblResult.Size = new System.Drawing.Size(227, 72);
            this.lblResult.TabIndex = 5;
            // 
            // BtnCheckLatency
            // 
            this.BtnCheckLatency.Location = new System.Drawing.Point(436, 36);
            this.BtnCheckLatency.Name = "BtnCheckLatency";
            this.BtnCheckLatency.Size = new System.Drawing.Size(103, 25);
            this.BtnCheckLatency.TabIndex = 4;
            this.BtnCheckLatency.Text = "Check Latancy";
            this.BtnCheckLatency.UseVisualStyleBackColor = true;
            this.BtnCheckLatency.Click += new System.EventHandler(this.BtnCheckLatency_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(35, 181);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(378, 25);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status : XXXXXXXXXXXXXXXXXXX";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(129, 127);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(154, 26);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnGetCurrentIP
            // 
            this.btnGetCurrentIP.Location = new System.Drawing.Point(312, 36);
            this.btnGetCurrentIP.Name = "btnGetCurrentIP";
            this.btnGetCurrentIP.Size = new System.Drawing.Size(103, 25);
            this.btnGetCurrentIP.TabIndex = 3;
            this.btnGetCurrentIP.Text = "Get Current IP";
            this.btnGetCurrentIP.UseVisualStyleBackColor = true;
            this.btnGetCurrentIP.Click += new System.EventHandler(this.btnGetCurrentIP_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address";
            // 
            // txtPortCheckerPort
            // 
            this.txtPortCheckerPort.Location = new System.Drawing.Point(129, 81);
            this.txtPortCheckerPort.Multiline = true;
            this.txtPortCheckerPort.Name = "txtPortCheckerPort";
            this.txtPortCheckerPort.Size = new System.Drawing.Size(154, 23);
            this.txtPortCheckerPort.TabIndex = 1;
            this.txtPortCheckerPort.Text = "80";
            this.txtPortCheckerPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPortCheckerPort_KeyPress);
            // 
            // txtPortCheckerIP
            // 
            this.txtPortCheckerIP.Location = new System.Drawing.Point(129, 36);
            this.txtPortCheckerIP.Multiline = true;
            this.txtPortCheckerIP.Name = "txtPortCheckerIP";
            this.txtPortCheckerIP.Size = new System.Drawing.Size(154, 25);
            this.txtPortCheckerIP.TabIndex = 0;
            this.txtPortCheckerIP.Text = "127.0.0.1";
            this.txtPortCheckerIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPortCheckerIP_KeyPress);
            // 
            // PortChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 272);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PortChecker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PortChecker";
            this.Load += new System.EventHandler(this.PortChecker_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPortCheckerIP;
        private System.Windows.Forms.TextBox txtPortCheckerPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetCurrentIP;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button BtnCheckLatency;
        private System.Windows.Forms.TextBox lblResult;
    }
}