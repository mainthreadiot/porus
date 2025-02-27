
namespace Porus
{
    partial class MQTT
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MQTT));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.subscriberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publisherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPublisher = new System.Windows.Forms.Button();
            this.btnSubscriber = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtProfileName = new System.Windows.Forms.TextBox();
            this.btnGenerateID = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbQoS = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProtocol = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUseradmin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtClientID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(190)))), ((int)(((byte)(243)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1361, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.subscriberToolStripMenuItem,
            this.publisherToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileMenu.Image = global::Porus.Properties.Resources.checksum;
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(53, 20);
            this.fileMenu.Text = "&File";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(151, 6);
            // 
            // subscriberToolStripMenuItem
            // 
            this.subscriberToolStripMenuItem.Image = global::Porus.Properties.Resources.subscribe;
            this.subscriberToolStripMenuItem.Name = "subscriberToolStripMenuItem";
            this.subscriberToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.subscriberToolStripMenuItem.Text = "Add Subscriber";
            this.subscriberToolStripMenuItem.Click += new System.EventHandler(this.subscriberToolStripMenuItem_Click);
            // 
            // publisherToolStripMenuItem
            // 
            this.publisherToolStripMenuItem.Image = global::Porus.Properties.Resources.publish;
            this.publisherToolStripMenuItem.Name = "publisherToolStripMenuItem";
            this.publisherToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.publisherToolStripMenuItem.Text = "Add Publisher";
            this.publisherToolStripMenuItem.Click += new System.EventHandler(this.publisherToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 735);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1361, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1361, 114);
            this.panel1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnPublisher);
            this.groupBox1.Controls.Add(this.btnSubscriber);
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtProfileName);
            this.groupBox1.Controls.Add(this.btnGenerateID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbQoS);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbProtocol);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUseradmin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtHost);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtClientID);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1353, 100);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Broker Details";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::Porus.Properties.Resources.subscribe;
            this.button1.Location = new System.Drawing.Point(1127, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 56);
            this.button1.TabIndex = 12;
            this.button1.Text = "Add Dynamic Publish Design";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPublisher
            // 
            this.btnPublisher.BackColor = System.Drawing.Color.White;
            this.btnPublisher.Enabled = false;
            this.btnPublisher.Location = new System.Drawing.Point(1045, 54);
            this.btnPublisher.Name = "btnPublisher";
            this.btnPublisher.Size = new System.Drawing.Size(75, 23);
            this.btnPublisher.TabIndex = 11;
            this.btnPublisher.Text = "Publisher +";
            this.btnPublisher.UseVisualStyleBackColor = false;
            this.btnPublisher.Click += new System.EventHandler(this.btnPublisher_Click);
            // 
            // btnSubscriber
            // 
            this.btnSubscriber.BackColor = System.Drawing.Color.White;
            this.btnSubscriber.BackgroundImage = global::Porus.Properties.Resources.subscribe;
            this.btnSubscriber.Enabled = false;
            this.btnSubscriber.Location = new System.Drawing.Point(1045, 20);
            this.btnSubscriber.Name = "btnSubscriber";
            this.btnSubscriber.Size = new System.Drawing.Size(75, 23);
            this.btnSubscriber.TabIndex = 10;
            this.btnSubscriber.Text = "Subscriber +";
            this.btnSubscriber.UseVisualStyleBackColor = false;
            this.btnSubscriber.Click += new System.EventHandler(this.btnSubscriber_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.White;
            this.btnDisconnect.Location = new System.Drawing.Point(963, 54);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 9;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(963, 20);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtProfileName
            // 
            this.txtProfileName.BackColor = System.Drawing.Color.White;
            this.txtProfileName.Enabled = false;
            this.txtProfileName.Location = new System.Drawing.Point(74, 24);
            this.txtProfileName.Name = "txtProfileName";
            this.txtProfileName.Size = new System.Drawing.Size(182, 20);
            this.txtProfileName.TabIndex = 0;
            this.txtProfileName.Text = "Profile1";
            // 
            // btnGenerateID
            // 
            this.btnGenerateID.BackgroundImage = global::Porus.Properties.Resources.refresh;
            this.btnGenerateID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerateID.Location = new System.Drawing.Point(262, 58);
            this.btnGenerateID.Name = "btnGenerateID";
            this.btnGenerateID.Size = new System.Drawing.Size(30, 21);
            this.btnGenerateID.TabIndex = 16;
            this.btnGenerateID.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profile Name";
            // 
            // cmbQoS
            // 
            this.cmbQoS.BackColor = System.Drawing.Color.White;
            this.cmbQoS.FormattingEnabled = true;
            this.cmbQoS.Items.AddRange(new object[] {
            "0 - Almost Once",
            "1 - Atleast Once",
            "2 - Exactly Once"});
            this.cmbQoS.Location = new System.Drawing.Point(801, 57);
            this.cmbQoS.Name = "cmbQoS";
            this.cmbQoS.Size = new System.Drawing.Size(121, 21);
            this.cmbQoS.TabIndex = 7;
            this.cmbQoS.Text = "0 - Almost Once";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Client Id";
            // 
            // cmbProtocol
            // 
            this.cmbProtocol.BackColor = System.Drawing.Color.White;
            this.cmbProtocol.FormattingEnabled = true;
            this.cmbProtocol.Items.AddRange(new object[] {
            "mqtt/tcp"});
            this.cmbProtocol.Location = new System.Drawing.Point(801, 23);
            this.cmbProtocol.Name = "cmbProtocol";
            this.cmbProtocol.Size = new System.Drawing.Size(121, 21);
            this.cmbProtocol.TabIndex = 6;
            this.cmbProtocol.Text = "mqtt/tcp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(753, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Protocol";
            // 
            // txtUseradmin
            // 
            this.txtUseradmin.BackColor = System.Drawing.Color.White;
            this.txtUseradmin.Location = new System.Drawing.Point(582, 22);
            this.txtUseradmin.Name = "txtUseradmin";
            this.txtUseradmin.Size = new System.Drawing.Size(126, 20);
            this.txtUseradmin.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(319, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Host";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(582, 56);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(126, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(319, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.Color.White;
            this.txtPort.Location = new System.Drawing.Point(348, 57);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(126, 20);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "1883";
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPort_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(525, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Username";
            // 
            // txtHost
            // 
            this.txtHost.BackColor = System.Drawing.Color.White;
            this.txtHost.Location = new System.Drawing.Point(348, 23);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(126, 20);
            this.txtHost.TabIndex = 2;
            this.txtHost.Text = "broker.emqx.io";
            this.txtHost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHost_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(525, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Password";
            // 
            // txtClientID
            // 
            this.txtClientID.BackColor = System.Drawing.Color.White;
            this.txtClientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientID.Location = new System.Drawing.Point(74, 58);
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.Size = new System.Drawing.Size(182, 18);
            this.txtClientID.TabIndex = 1;
            this.txtClientID.Text = "TEST";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(771, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "QoS";
            // 
            // panelButtons
            // 
            this.panelButtons.Location = new System.Drawing.Point(6, 13);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1337, 100);
            this.panelButtons.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelButtons);
            this.groupBox2.Location = new System.Drawing.Point(4, 615);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1353, 114);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dynamic Design";
            // 
            // MQTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 757);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MQTT";
            this.Text = "Porus - MQTT Client ";
            this.Load += new System.EventHandler(this.MQTT_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem subscriberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publisherToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtProfileName;
        private System.Windows.Forms.Button btnGenerateID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbQoS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbProtocol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUseradmin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtClientID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnPublisher;
        private System.Windows.Forms.Button btnSubscriber;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}



