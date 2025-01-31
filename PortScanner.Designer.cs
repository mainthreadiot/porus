namespace Porus
{
    partial class PortScanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortScanner));
            this.dgvPortScannerGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbMISC = new System.Windows.Forms.GroupBox();
            this.rdoExcludeNonIP = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoSortByPID = new System.Windows.Forms.RadioButton();
            this.rdoSortByPort = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoListening = new System.Windows.Forms.RadioButton();
            this.rdoTimeWait = new System.Windows.Forms.RadioButton();
            this.rdoCloseWait = new System.Windows.Forms.RadioButton();
            this.rdoListen = new System.Windows.Forms.RadioButton();
            this.rdoAllStatus = new System.Windows.Forms.RadioButton();
            this.rdoEstablished = new System.Windows.Forms.RadioButton();
            this.grbProtocol = new System.Windows.Forms.GroupBox();
            this.rdoUDPOnly = new System.Windows.Forms.RadioButton();
            this.rdoTCPOnly = new System.Windows.Forms.RadioButton();
            this.rdoAllProtocol = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnReload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPortScannerGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.grbMISC.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grbProtocol.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPortScannerGrid
            // 
            this.dgvPortScannerGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPortScannerGrid.Location = new System.Drawing.Point(0, 0);
            this.dgvPortScannerGrid.Name = "dgvPortScannerGrid";
            this.dgvPortScannerGrid.ReadOnly = true;
            this.dgvPortScannerGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPortScannerGrid.Size = new System.Drawing.Size(1133, 350);
            this.dgvPortScannerGrid.TabIndex = 0;
            this.dgvPortScannerGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPortScannerGrid_CellClick);
            this.dgvPortScannerGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPortScannerGrid_CellFormatting);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grbMISC);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.grbProtocol);
            this.panel1.Controls.Add(this.btnReload);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1133, 100);
            this.panel1.TabIndex = 1;
            // 
            // grbMISC
            // 
            this.grbMISC.Controls.Add(this.rdoExcludeNonIP);
            this.grbMISC.Location = new System.Drawing.Point(726, 4);
            this.grbMISC.Name = "grbMISC";
            this.grbMISC.Size = new System.Drawing.Size(45, 91);
            this.grbMISC.TabIndex = 11;
            this.grbMISC.TabStop = false;
            this.grbMISC.Text = "MISC";
            this.grbMISC.Visible = false;
            // 
            // rdoExcludeNonIP
            // 
            this.rdoExcludeNonIP.AutoSize = true;
            this.rdoExcludeNonIP.Location = new System.Drawing.Point(11, 19);
            this.rdoExcludeNonIP.Name = "rdoExcludeNonIP";
            this.rdoExcludeNonIP.Size = new System.Drawing.Size(99, 17);
            this.rdoExcludeNonIP.TabIndex = 9;
            this.rdoExcludeNonIP.Text = "Exclude Non IP";
            this.rdoExcludeNonIP.UseVisualStyleBackColor = true;
            this.rdoExcludeNonIP.CheckedChanged += new System.EventHandler(this.rdoExcludeNonIP_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoSortByPID);
            this.groupBox3.Controls.Add(this.rdoSortByPort);
            this.groupBox3.Location = new System.Drawing.Point(525, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(195, 91);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sort";
            // 
            // rdoSortByPID
            // 
            this.rdoSortByPID.AutoSize = true;
            this.rdoSortByPID.Checked = true;
            this.rdoSortByPID.Location = new System.Drawing.Point(11, 19);
            this.rdoSortByPID.Name = "rdoSortByPID";
            this.rdoSortByPID.Size = new System.Drawing.Size(79, 17);
            this.rdoSortByPID.TabIndex = 9;
            this.rdoSortByPID.TabStop = true;
            this.rdoSortByPID.Text = "Sort by PID";
            this.rdoSortByPID.UseVisualStyleBackColor = true;
            this.rdoSortByPID.CheckedChanged += new System.EventHandler(this.rdoSortByPID_CheckedChanged);
            // 
            // rdoSortByPort
            // 
            this.rdoSortByPort.AutoSize = true;
            this.rdoSortByPort.Location = new System.Drawing.Point(11, 42);
            this.rdoSortByPort.Name = "rdoSortByPort";
            this.rdoSortByPort.Size = new System.Drawing.Size(80, 17);
            this.rdoSortByPort.TabIndex = 10;
            this.rdoSortByPort.Text = "Sort by Port";
            this.rdoSortByPort.UseVisualStyleBackColor = true;
            this.rdoSortByPort.CheckedChanged += new System.EventHandler(this.rdoSortByPort_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoListening);
            this.groupBox2.Controls.Add(this.rdoTimeWait);
            this.groupBox2.Controls.Add(this.rdoCloseWait);
            this.groupBox2.Controls.Add(this.rdoListen);
            this.groupBox2.Controls.Add(this.rdoAllStatus);
            this.groupBox2.Controls.Add(this.rdoEstablished);
            this.groupBox2.Location = new System.Drawing.Point(256, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 91);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // rdoListening
            // 
            this.rdoListening.AutoSize = true;
            this.rdoListening.Location = new System.Drawing.Point(150, 65);
            this.rdoListening.Name = "rdoListening";
            this.rdoListening.Size = new System.Drawing.Size(67, 17);
            this.rdoListening.TabIndex = 8;
            this.rdoListening.Text = "Listening";
            this.rdoListening.UseVisualStyleBackColor = true;
            this.rdoListening.CheckedChanged += new System.EventHandler(this.rdoListening_CheckedChanged);
            // 
            // rdoTimeWait
            // 
            this.rdoTimeWait.AutoSize = true;
            this.rdoTimeWait.Location = new System.Drawing.Point(150, 19);
            this.rdoTimeWait.Name = "rdoTimeWait";
            this.rdoTimeWait.Size = new System.Drawing.Size(70, 17);
            this.rdoTimeWait.TabIndex = 6;
            this.rdoTimeWait.Text = "TimeWait";
            this.rdoTimeWait.UseVisualStyleBackColor = true;
            this.rdoTimeWait.CheckedChanged += new System.EventHandler(this.rdoTimeWait_CheckedChanged);
            // 
            // rdoCloseWait
            // 
            this.rdoCloseWait.AutoSize = true;
            this.rdoCloseWait.Location = new System.Drawing.Point(150, 42);
            this.rdoCloseWait.Name = "rdoCloseWait";
            this.rdoCloseWait.Size = new System.Drawing.Size(73, 17);
            this.rdoCloseWait.TabIndex = 7;
            this.rdoCloseWait.Text = "CloseWait";
            this.rdoCloseWait.UseVisualStyleBackColor = true;
            this.rdoCloseWait.CheckedChanged += new System.EventHandler(this.rdoCloseWait_CheckedChanged);
            // 
            // rdoListen
            // 
            this.rdoListen.AutoSize = true;
            this.rdoListen.Location = new System.Drawing.Point(17, 65);
            this.rdoListen.Name = "rdoListen";
            this.rdoListen.Size = new System.Drawing.Size(53, 17);
            this.rdoListen.TabIndex = 5;
            this.rdoListen.Text = "Listen";
            this.rdoListen.UseVisualStyleBackColor = true;
            this.rdoListen.CheckedChanged += new System.EventHandler(this.rdoListen_CheckedChanged);
            // 
            // rdoAllStatus
            // 
            this.rdoAllStatus.AutoSize = true;
            this.rdoAllStatus.Checked = true;
            this.rdoAllStatus.Location = new System.Drawing.Point(17, 19);
            this.rdoAllStatus.Name = "rdoAllStatus";
            this.rdoAllStatus.Size = new System.Drawing.Size(36, 17);
            this.rdoAllStatus.TabIndex = 3;
            this.rdoAllStatus.TabStop = true;
            this.rdoAllStatus.Text = "All";
            this.rdoAllStatus.UseVisualStyleBackColor = true;
            this.rdoAllStatus.CheckedChanged += new System.EventHandler(this.rdoAllStatus_CheckedChanged);
            // 
            // rdoEstablished
            // 
            this.rdoEstablished.AutoSize = true;
            this.rdoEstablished.Location = new System.Drawing.Point(17, 42);
            this.rdoEstablished.Name = "rdoEstablished";
            this.rdoEstablished.Size = new System.Drawing.Size(79, 17);
            this.rdoEstablished.TabIndex = 4;
            this.rdoEstablished.Text = "Established";
            this.rdoEstablished.UseVisualStyleBackColor = true;
            this.rdoEstablished.CheckedChanged += new System.EventHandler(this.rdoEstablished_CheckedChanged);
            // 
            // grbProtocol
            // 
            this.grbProtocol.Controls.Add(this.rdoUDPOnly);
            this.grbProtocol.Controls.Add(this.rdoTCPOnly);
            this.grbProtocol.Controls.Add(this.rdoAllProtocol);
            this.grbProtocol.Location = new System.Drawing.Point(12, 3);
            this.grbProtocol.Name = "grbProtocol";
            this.grbProtocol.Size = new System.Drawing.Size(238, 91);
            this.grbProtocol.TabIndex = 2;
            this.grbProtocol.TabStop = false;
            this.grbProtocol.Text = "Protocol";
            // 
            // rdoUDPOnly
            // 
            this.rdoUDPOnly.AutoSize = true;
            this.rdoUDPOnly.Location = new System.Drawing.Point(12, 66);
            this.rdoUDPOnly.Name = "rdoUDPOnly";
            this.rdoUDPOnly.Size = new System.Drawing.Size(69, 17);
            this.rdoUDPOnly.TabIndex = 2;
            this.rdoUDPOnly.Text = "Udp Only";
            this.rdoUDPOnly.UseVisualStyleBackColor = true;
            this.rdoUDPOnly.CheckedChanged += new System.EventHandler(this.rdoUDPOnly_CheckedChanged);
            // 
            // rdoTCPOnly
            // 
            this.rdoTCPOnly.AutoSize = true;
            this.rdoTCPOnly.Location = new System.Drawing.Point(12, 43);
            this.rdoTCPOnly.Name = "rdoTCPOnly";
            this.rdoTCPOnly.Size = new System.Drawing.Size(68, 17);
            this.rdoTCPOnly.TabIndex = 1;
            this.rdoTCPOnly.Text = "Tcp Only";
            this.rdoTCPOnly.UseVisualStyleBackColor = true;
            this.rdoTCPOnly.CheckedChanged += new System.EventHandler(this.rdoTCPOnly_CheckedChanged);
            // 
            // rdoAllProtocol
            // 
            this.rdoAllProtocol.AutoSize = true;
            this.rdoAllProtocol.Checked = true;
            this.rdoAllProtocol.Location = new System.Drawing.Point(12, 20);
            this.rdoAllProtocol.Name = "rdoAllProtocol";
            this.rdoAllProtocol.Size = new System.Drawing.Size(36, 17);
            this.rdoAllProtocol.TabIndex = 0;
            this.rdoAllProtocol.TabStop = true;
            this.rdoAllProtocol.Text = "All";
            this.rdoAllProtocol.UseVisualStyleBackColor = true;
            this.rdoAllProtocol.CheckedChanged += new System.EventHandler(this.rdoAllProtocol_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvPortScannerGrid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1133, 350);
            this.panel2.TabIndex = 2;
            // 
            // btnReload
            // 
            this.btnReload.BackgroundImage = global::Porus.Properties.Resources.refresh;
            this.btnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReload.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReload.Location = new System.Drawing.Point(1033, 0);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(100, 100);
            this.btnReload.TabIndex = 1;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // PortScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PortScanner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PortScanner";
            this.Load += new System.EventHandler(this.PortScanner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPortScannerGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.grbMISC.ResumeLayout(false);
            this.grbMISC.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grbProtocol.ResumeLayout(false);
            this.grbProtocol.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPortScannerGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grbProtocol;
        private System.Windows.Forms.RadioButton rdoUDPOnly;
        private System.Windows.Forms.RadioButton rdoTCPOnly;
        private System.Windows.Forms.RadioButton rdoAllProtocol;
        private System.Windows.Forms.RadioButton rdoListen;
        private System.Windows.Forms.RadioButton rdoAllStatus;
        private System.Windows.Forms.RadioButton rdoEstablished;
        private System.Windows.Forms.RadioButton rdoListening;
        private System.Windows.Forms.RadioButton rdoTimeWait;
        private System.Windows.Forms.RadioButton rdoCloseWait;
        private System.Windows.Forms.RadioButton rdoSortByPID;
        private System.Windows.Forms.RadioButton rdoSortByPort;
        private System.Windows.Forms.GroupBox grbMISC;
        private System.Windows.Forms.RadioButton rdoExcludeNonIP;
    }
}