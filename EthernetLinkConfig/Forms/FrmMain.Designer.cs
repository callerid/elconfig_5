namespace EthernetLinkConfig
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panStatus = new System.Windows.Forms.Panel();
            this.lbDeluxeUnitDetected = new System.Windows.Forms.Label();
            this.lbListeningOn = new System.Windows.Forms.Label();
            this.tbIP = new IPAddressControlLib.IPAddressControl();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMAC = new ISEAGE.May610.Diagrammer.matb();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUnitNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbEthernetID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDestMAC = new ISEAGE.May610.Diagrammer.matb();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDestIP = new IPAddressControlLib.IPAddressControl();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDestPort = new System.Windows.Forms.TextBox();
            this.imgConnected = new System.Windows.Forms.PictureBox();
            this.timerRefresher = new System.Windows.Forms.Timer(this.components);
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetEthernetDefaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDeluxeUnitOutputDefaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.setUnitToCurrentTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDeluxeUnitToBasicUnitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sendDuplicateCallRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.listeningPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayComputerIPAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbConnected = new System.Windows.Forms.Label();
            this.dgvCommData = new System.Windows.Forms.DataGridView();
            this.dgvCommDataColDisplay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhoneData = new System.Windows.Forms.DataGridView();
            this.dgvPhoneDataColLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhoneDataColIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhoneDataColSE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhoneDataColDur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhoneDataColCS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhoneDataColRing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhoneDataColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhoneDataColTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhoneDataColNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhoneDataColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnUnlockUnitNumber = new System.Windows.Forms.Button();
            this.btnUnlockIPAddress = new System.Windows.Forms.Button();
            this.btnUnlockMACAddress = new System.Windows.Forms.Button();
            this.btnUnlockDestPort = new System.Windows.Forms.Button();
            this.btnUnlockDestIP = new System.Windows.Forms.Button();
            this.btnUnlockDestMAC = new System.Windows.Forms.Button();
            this.panChangers = new System.Windows.Forms.Panel();
            this.lbDups = new System.Windows.Forms.Label();
            this.ckbIgnoreDups = new System.Windows.Forms.CheckBox();
            this.btnRetrieveToggles = new System.Windows.Forms.Button();
            this.lbNeedsSaving = new System.Windows.Forms.Label();
            this.btnClearCommData = new System.Windows.Forms.Button();
            this.btnClearPhoneData = new System.Windows.Forms.Button();
            this.btnToggleC = new System.Windows.Forms.Button();
            this.btnToggleU = new System.Windows.Forms.Button();
            this.btnToggleA = new System.Windows.Forms.Button();
            this.btnToggleD = new System.Windows.Forms.Button();
            this.btnToggleK = new System.Windows.Forms.Button();
            this.btnToggleB = new System.Windows.Forms.Button();
            this.btnToggleO = new System.Windows.Forms.Button();
            this.btnToggleS = new System.Windows.Forms.Button();
            this.timerGetToggles = new System.Windows.Forms.Timer(this.components);
            this.cbLineCount = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbLineCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgConnected)).BeginInit();
            this.mnuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhoneData)).BeginInit();
            this.panChangers.SuspendLayout();
            this.SuspendLayout();
            // 
            // panStatus
            // 
            this.panStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panStatus.BackColor = System.Drawing.Color.Pink;
            this.panStatus.Location = new System.Drawing.Point(-4, 602);
            this.panStatus.Name = "panStatus";
            this.panStatus.Size = new System.Drawing.Size(798, 40);
            this.panStatus.TabIndex = 0;
            // 
            // lbDeluxeUnitDetected
            // 
            this.lbDeluxeUnitDetected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDeluxeUnitDetected.AutoSize = true;
            this.lbDeluxeUnitDetected.BackColor = System.Drawing.Color.Pink;
            this.lbDeluxeUnitDetected.Location = new System.Drawing.Point(504, 611);
            this.lbDeluxeUnitDetected.Name = "lbDeluxeUnitDetected";
            this.lbDeluxeUnitDetected.Size = new System.Drawing.Size(138, 13);
            this.lbDeluxeUnitDetected.TabIndex = 3;
            this.lbDeluxeUnitDetected.Text = "Deluxe Unit Not Detected";
            // 
            // lbListeningOn
            // 
            this.lbListeningOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbListeningOn.AutoSize = true;
            this.lbListeningOn.BackColor = System.Drawing.Color.Pink;
            this.lbListeningOn.Location = new System.Drawing.Point(674, 611);
            this.lbListeningOn.Name = "lbListeningOn";
            this.lbListeningOn.Size = new System.Drawing.Size(103, 13);
            this.lbListeningOn.TabIndex = 2;
            this.lbListeningOn.Text = "Listening On: 3520";
            // 
            // tbIP
            // 
            this.tbIP.AllowInternalTab = false;
            this.tbIP.AutoHeight = true;
            this.tbIP.BackColor = System.Drawing.SystemColors.Window;
            this.tbIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbIP.Enabled = false;
            this.tbIP.Location = new System.Drawing.Point(162, 66);
            this.tbIP.MinimumSize = new System.Drawing.Size(84, 22);
            this.tbIP.Name = "tbIP";
            this.tbIP.ReadOnly = false;
            this.tbIP.Size = new System.Drawing.Size(111, 22);
            this.tbIP.TabIndex = 1;
            this.tbIP.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Unit IP Address";
            // 
            // tbMAC
            // 
            this.tbMAC.BackColor = System.Drawing.SystemColors.Window;
            this.tbMAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbMAC.Enabled = false;
            this.tbMAC.Location = new System.Drawing.Point(162, 94);
            this.tbMAC.Name = "tbMAC";
            this.tbMAC.Size = new System.Drawing.Size(171, 24);
            this.tbMAC.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Unit MAC Address";
            // 
            // tbUnitNumber
            // 
            this.tbUnitNumber.Enabled = false;
            this.tbUnitNumber.Location = new System.Drawing.Point(162, 38);
            this.tbUnitNumber.Name = "tbUnitNumber";
            this.tbUnitNumber.Size = new System.Drawing.Size(111, 22);
            this.tbUnitNumber.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Unit Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ethernet ID";
            // 
            // lbEthernetID
            // 
            this.lbEthernetID.AutoSize = true;
            this.lbEthernetID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEthernetID.Location = new System.Drawing.Point(159, 9);
            this.lbEthernetID.Name = "lbEthernetID";
            this.lbEthernetID.Size = new System.Drawing.Size(157, 21);
            this.lbEthernetID.TabIndex = 10;
            this.lbEthernetID.Text = "_____________________";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Destination MAC Address";
            // 
            // tbDestMAC
            // 
            this.tbDestMAC.BackColor = System.Drawing.SystemColors.Window;
            this.tbDestMAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbDestMAC.Enabled = false;
            this.tbDestMAC.Location = new System.Drawing.Point(162, 180);
            this.tbDestMAC.Name = "tbDestMAC";
            this.tbDestMAC.Size = new System.Drawing.Size(171, 24);
            this.tbDestMAC.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Destination IP Address";
            // 
            // tbDestIP
            // 
            this.tbDestIP.AllowInternalTab = false;
            this.tbDestIP.AutoHeight = true;
            this.tbDestIP.BackColor = System.Drawing.SystemColors.Window;
            this.tbDestIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbDestIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbDestIP.Enabled = false;
            this.tbDestIP.Location = new System.Drawing.Point(162, 152);
            this.tbDestIP.MinimumSize = new System.Drawing.Size(84, 22);
            this.tbDestIP.Name = "tbDestIP";
            this.tbDestIP.ReadOnly = false;
            this.tbDestIP.Size = new System.Drawing.Size(111, 22);
            this.tbDestIP.TabIndex = 11;
            this.tbDestIP.Text = "...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(65, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Destination Port";
            // 
            // tbDestPort
            // 
            this.tbDestPort.Enabled = false;
            this.tbDestPort.Location = new System.Drawing.Point(162, 124);
            this.tbDestPort.Name = "tbDestPort";
            this.tbDestPort.Size = new System.Drawing.Size(111, 22);
            this.tbDestPort.TabIndex = 15;
            // 
            // imgConnected
            // 
            this.imgConnected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgConnected.BackColor = System.Drawing.Color.Pink;
            this.imgConnected.Image = global::EthernetLinkConfig.Properties.Resources.connected;
            this.imgConnected.Location = new System.Drawing.Point(12, 603);
            this.imgConnected.Name = "imgConnected";
            this.imgConnected.Size = new System.Drawing.Size(17, 26);
            this.imgConnected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgConnected.TabIndex = 17;
            this.imgConnected.TabStop = false;
            // 
            // timerRefresher
            // 
            this.timerRefresher.Enabled = true;
            this.timerRefresher.Tick += new System.EventHandler(this.timerRefresher_Tick);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(789, 24);
            this.mnuMain.TabIndex = 19;
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetEthernetDefaultsToolStripMenuItem,
            this.setDeluxeUnitOutputDefaultsToolStripMenuItem,
            this.toolStripSeparator1,
            this.setUnitToCurrentTimeToolStripMenuItem,
            this.setDeluxeUnitToBasicUnitToolStripMenuItem,
            this.toolStripSeparator2,
            this.sendDuplicateCallRecordsToolStripMenuItem,
            this.toolStripSeparator3,
            this.listeningPortToolStripMenuItem});
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.configureToolStripMenuItem.Text = "&Configure";
            // 
            // resetEthernetDefaultsToolStripMenuItem
            // 
            this.resetEthernetDefaultsToolStripMenuItem.Name = "resetEthernetDefaultsToolStripMenuItem";
            this.resetEthernetDefaultsToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.resetEthernetDefaultsToolStripMenuItem.Text = "Reset &Ethernet Defaults";
            this.resetEthernetDefaultsToolStripMenuItem.Click += new System.EventHandler(this.resetEthernetDefaultsToolStripMenuItem_Click);
            // 
            // setDeluxeUnitOutputDefaultsToolStripMenuItem
            // 
            this.setDeluxeUnitOutputDefaultsToolStripMenuItem.Name = "setDeluxeUnitOutputDefaultsToolStripMenuItem";
            this.setDeluxeUnitOutputDefaultsToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.setDeluxeUnitOutputDefaultsToolStripMenuItem.Text = "Set &Deluxe Unit Output Defaults";
            this.setDeluxeUnitOutputDefaultsToolStripMenuItem.Click += new System.EventHandler(this.setDeluxeUnitOutputDefaultsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(237, 6);
            // 
            // setUnitToCurrentTimeToolStripMenuItem
            // 
            this.setUnitToCurrentTimeToolStripMenuItem.Name = "setUnitToCurrentTimeToolStripMenuItem";
            this.setUnitToCurrentTimeToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.setUnitToCurrentTimeToolStripMenuItem.Text = "Set Unit to &Current Time";
            this.setUnitToCurrentTimeToolStripMenuItem.Click += new System.EventHandler(this.setUnitToCurrentTimeToolStripMenuItem_Click);
            // 
            // setDeluxeUnitToBasicUnitToolStripMenuItem
            // 
            this.setDeluxeUnitToBasicUnitToolStripMenuItem.Name = "setDeluxeUnitToBasicUnitToolStripMenuItem";
            this.setDeluxeUnitToBasicUnitToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.setDeluxeUnitToBasicUnitToolStripMenuItem.Text = "Set Deluxe Unit to &Basic Unit";
            this.setDeluxeUnitToBasicUnitToolStripMenuItem.Click += new System.EventHandler(this.setDeluxeUnitToBasicUnitToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(237, 6);
            // 
            // sendDuplicateCallRecordsToolStripMenuItem
            // 
            this.sendDuplicateCallRecordsToolStripMenuItem.Name = "sendDuplicateCallRecordsToolStripMenuItem";
            this.sendDuplicateCallRecordsToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.sendDuplicateCallRecordsToolStripMenuItem.Text = "Send Duplicate Call &Records";
            this.sendDuplicateCallRecordsToolStripMenuItem.Click += new System.EventHandler(this.sendDuplicateCallRecordsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(237, 6);
            // 
            // listeningPortToolStripMenuItem
            // 
            this.listeningPortToolStripMenuItem.Name = "listeningPortToolStripMenuItem";
            this.listeningPortToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.listeningPortToolStripMenuItem.Text = "Listening Port";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayComputerIPAddressToolStripMenuItem,
            this.pingToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // displayComputerIPAddressToolStripMenuItem
            // 
            this.displayComputerIPAddressToolStripMenuItem.Name = "displayComputerIPAddressToolStripMenuItem";
            this.displayComputerIPAddressToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.displayComputerIPAddressToolStripMenuItem.Text = "Display Computer &IP Address";
            this.displayComputerIPAddressToolStripMenuItem.Click += new System.EventHandler(this.displayComputerIPAddressToolStripMenuItem_Click);
            // 
            // pingToolStripMenuItem
            // 
            this.pingToolStripMenuItem.Name = "pingToolStripMenuItem";
            this.pingToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.pingToolStripMenuItem.Text = "Ping";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManualToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // userManualToolStripMenuItem
            // 
            this.userManualToolStripMenuItem.Name = "userManualToolStripMenuItem";
            this.userManualToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.userManualToolStripMenuItem.Text = "User &Manual";
            // 
            // lbConnected
            // 
            this.lbConnected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbConnected.AutoSize = true;
            this.lbConnected.BackColor = System.Drawing.Color.Pink;
            this.lbConnected.Location = new System.Drawing.Point(35, 611);
            this.lbConnected.Name = "lbConnected";
            this.lbConnected.Size = new System.Drawing.Size(88, 13);
            this.lbConnected.TabIndex = 1;
            this.lbConnected.Text = "NOT Connected";
            // 
            // dgvCommData
            // 
            this.dgvCommData.AllowUserToAddRows = false;
            this.dgvCommData.AllowUserToDeleteRows = false;
            this.dgvCommData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCommData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCommData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvCommDataColDisplay});
            this.dgvCommData.Location = new System.Drawing.Point(12, 257);
            this.dgvCommData.MultiSelect = false;
            this.dgvCommData.Name = "dgvCommData";
            this.dgvCommData.ReadOnly = true;
            this.dgvCommData.RowHeadersVisible = false;
            this.dgvCommData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCommData.Size = new System.Drawing.Size(765, 141);
            this.dgvCommData.TabIndex = 20;
            // 
            // dgvCommDataColDisplay
            // 
            this.dgvCommDataColDisplay.HeaderText = "Unit Output";
            this.dgvCommDataColDisplay.Name = "dgvCommDataColDisplay";
            this.dgvCommDataColDisplay.ReadOnly = true;
            this.dgvCommDataColDisplay.Width = 745;
            // 
            // dgvPhoneData
            // 
            this.dgvPhoneData.AllowUserToAddRows = false;
            this.dgvPhoneData.AllowUserToDeleteRows = false;
            this.dgvPhoneData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhoneData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPhoneData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhoneData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvPhoneDataColLine,
            this.dgvPhoneDataColIO,
            this.dgvPhoneDataColSE,
            this.dgvPhoneDataColDur,
            this.dgvPhoneDataColCS,
            this.dgvPhoneDataColRing,
            this.dgvPhoneDataColDate,
            this.dgvPhoneDataColTime,
            this.dgvPhoneDataColNumber,
            this.dgvPhoneDataColName});
            this.dgvPhoneData.Location = new System.Drawing.Point(12, 417);
            this.dgvPhoneData.Name = "dgvPhoneData";
            this.dgvPhoneData.ReadOnly = true;
            this.dgvPhoneData.RowHeadersVisible = false;
            this.dgvPhoneData.Size = new System.Drawing.Size(765, 179);
            this.dgvPhoneData.TabIndex = 21;
            // 
            // dgvPhoneDataColLine
            // 
            this.dgvPhoneDataColLine.HeaderText = "Ln";
            this.dgvPhoneDataColLine.Name = "dgvPhoneDataColLine";
            this.dgvPhoneDataColLine.ReadOnly = true;
            this.dgvPhoneDataColLine.Width = 40;
            // 
            // dgvPhoneDataColIO
            // 
            this.dgvPhoneDataColIO.HeaderText = "I/O";
            this.dgvPhoneDataColIO.Name = "dgvPhoneDataColIO";
            this.dgvPhoneDataColIO.ReadOnly = true;
            this.dgvPhoneDataColIO.Width = 40;
            // 
            // dgvPhoneDataColSE
            // 
            this.dgvPhoneDataColSE.HeaderText = "S/E";
            this.dgvPhoneDataColSE.Name = "dgvPhoneDataColSE";
            this.dgvPhoneDataColSE.ReadOnly = true;
            this.dgvPhoneDataColSE.Width = 40;
            // 
            // dgvPhoneDataColDur
            // 
            this.dgvPhoneDataColDur.HeaderText = "Dur";
            this.dgvPhoneDataColDur.Name = "dgvPhoneDataColDur";
            this.dgvPhoneDataColDur.ReadOnly = true;
            this.dgvPhoneDataColDur.Width = 60;
            // 
            // dgvPhoneDataColCS
            // 
            this.dgvPhoneDataColCS.HeaderText = "CS";
            this.dgvPhoneDataColCS.Name = "dgvPhoneDataColCS";
            this.dgvPhoneDataColCS.ReadOnly = true;
            this.dgvPhoneDataColCS.Width = 40;
            // 
            // dgvPhoneDataColRing
            // 
            this.dgvPhoneDataColRing.HeaderText = "Ring";
            this.dgvPhoneDataColRing.Name = "dgvPhoneDataColRing";
            this.dgvPhoneDataColRing.ReadOnly = true;
            this.dgvPhoneDataColRing.Width = 60;
            // 
            // dgvPhoneDataColDate
            // 
            this.dgvPhoneDataColDate.HeaderText = "Date";
            this.dgvPhoneDataColDate.Name = "dgvPhoneDataColDate";
            this.dgvPhoneDataColDate.ReadOnly = true;
            this.dgvPhoneDataColDate.Width = 80;
            // 
            // dgvPhoneDataColTime
            // 
            this.dgvPhoneDataColTime.HeaderText = "Time";
            this.dgvPhoneDataColTime.Name = "dgvPhoneDataColTime";
            this.dgvPhoneDataColTime.ReadOnly = true;
            this.dgvPhoneDataColTime.Width = 80;
            // 
            // dgvPhoneDataColNumber
            // 
            this.dgvPhoneDataColNumber.HeaderText = "Number";
            this.dgvPhoneDataColNumber.Name = "dgvPhoneDataColNumber";
            this.dgvPhoneDataColNumber.ReadOnly = true;
            this.dgvPhoneDataColNumber.Width = 150;
            // 
            // dgvPhoneDataColName
            // 
            this.dgvPhoneDataColName.HeaderText = "Name";
            this.dgvPhoneDataColName.Name = "dgvPhoneDataColName";
            this.dgvPhoneDataColName.ReadOnly = true;
            this.dgvPhoneDataColName.Width = 150;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 401);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Phone Data";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Communication Data";
            // 
            // btnUnlockUnitNumber
            // 
            this.btnUnlockUnitNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUnlockUnitNumber.Location = new System.Drawing.Point(339, 38);
            this.btnUnlockUnitNumber.Name = "btnUnlockUnitNumber";
            this.btnUnlockUnitNumber.Size = new System.Drawing.Size(75, 23);
            this.btnUnlockUnitNumber.TabIndex = 24;
            this.btnUnlockUnitNumber.Text = "Unlock";
            this.btnUnlockUnitNumber.UseVisualStyleBackColor = true;
            this.btnUnlockUnitNumber.Click += new System.EventHandler(this.Unlocks);
            this.btnUnlockUnitNumber.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnUnlockUnitNumber.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnUnlockIPAddress
            // 
            this.btnUnlockIPAddress.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUnlockIPAddress.Location = new System.Drawing.Point(339, 67);
            this.btnUnlockIPAddress.Name = "btnUnlockIPAddress";
            this.btnUnlockIPAddress.Size = new System.Drawing.Size(75, 23);
            this.btnUnlockIPAddress.TabIndex = 25;
            this.btnUnlockIPAddress.Text = "Unlock";
            this.btnUnlockIPAddress.UseVisualStyleBackColor = true;
            this.btnUnlockIPAddress.Click += new System.EventHandler(this.Unlocks);
            this.btnUnlockIPAddress.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnUnlockIPAddress.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnUnlockMACAddress
            // 
            this.btnUnlockMACAddress.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUnlockMACAddress.Location = new System.Drawing.Point(339, 94);
            this.btnUnlockMACAddress.Name = "btnUnlockMACAddress";
            this.btnUnlockMACAddress.Size = new System.Drawing.Size(75, 23);
            this.btnUnlockMACAddress.TabIndex = 26;
            this.btnUnlockMACAddress.Text = "Unlock";
            this.btnUnlockMACAddress.UseVisualStyleBackColor = true;
            this.btnUnlockMACAddress.Click += new System.EventHandler(this.Unlocks);
            this.btnUnlockMACAddress.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnUnlockMACAddress.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnUnlockDestPort
            // 
            this.btnUnlockDestPort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUnlockDestPort.Location = new System.Drawing.Point(339, 124);
            this.btnUnlockDestPort.Name = "btnUnlockDestPort";
            this.btnUnlockDestPort.Size = new System.Drawing.Size(75, 23);
            this.btnUnlockDestPort.TabIndex = 27;
            this.btnUnlockDestPort.Text = "Unlock";
            this.btnUnlockDestPort.UseVisualStyleBackColor = true;
            this.btnUnlockDestPort.Click += new System.EventHandler(this.Unlocks);
            this.btnUnlockDestPort.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnUnlockDestPort.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnUnlockDestIP
            // 
            this.btnUnlockDestIP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUnlockDestIP.Location = new System.Drawing.Point(339, 151);
            this.btnUnlockDestIP.Name = "btnUnlockDestIP";
            this.btnUnlockDestIP.Size = new System.Drawing.Size(75, 23);
            this.btnUnlockDestIP.TabIndex = 28;
            this.btnUnlockDestIP.Text = "Unlock";
            this.btnUnlockDestIP.UseVisualStyleBackColor = true;
            this.btnUnlockDestIP.Click += new System.EventHandler(this.Unlocks);
            this.btnUnlockDestIP.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnUnlockDestIP.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnUnlockDestMAC
            // 
            this.btnUnlockDestMAC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUnlockDestMAC.Location = new System.Drawing.Point(339, 180);
            this.btnUnlockDestMAC.Name = "btnUnlockDestMAC";
            this.btnUnlockDestMAC.Size = new System.Drawing.Size(75, 23);
            this.btnUnlockDestMAC.TabIndex = 29;
            this.btnUnlockDestMAC.Text = "Unlock";
            this.btnUnlockDestMAC.UseVisualStyleBackColor = true;
            this.btnUnlockDestMAC.Click += new System.EventHandler(this.Unlocks);
            this.btnUnlockDestMAC.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnUnlockDestMAC.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // panChangers
            // 
            this.panChangers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panChangers.Controls.Add(this.btnUnlockUnitNumber);
            this.panChangers.Controls.Add(this.btnUnlockDestMAC);
            this.panChangers.Controls.Add(this.tbIP);
            this.panChangers.Controls.Add(this.btnUnlockDestIP);
            this.panChangers.Controls.Add(this.label1);
            this.panChangers.Controls.Add(this.btnUnlockDestPort);
            this.panChangers.Controls.Add(this.tbMAC);
            this.panChangers.Controls.Add(this.btnUnlockMACAddress);
            this.panChangers.Controls.Add(this.label2);
            this.panChangers.Controls.Add(this.btnUnlockIPAddress);
            this.panChangers.Controls.Add(this.tbUnitNumber);
            this.panChangers.Controls.Add(this.label3);
            this.panChangers.Controls.Add(this.label4);
            this.panChangers.Controls.Add(this.lbEthernetID);
            this.panChangers.Controls.Add(this.tbDestIP);
            this.panChangers.Controls.Add(this.label6);
            this.panChangers.Controls.Add(this.label7);
            this.panChangers.Controls.Add(this.tbDestMAC);
            this.panChangers.Controls.Add(this.tbDestPort);
            this.panChangers.Controls.Add(this.label5);
            this.panChangers.Location = new System.Drawing.Point(15, 25);
            this.panChangers.Name = "panChangers";
            this.panChangers.Size = new System.Drawing.Size(417, 206);
            this.panChangers.TabIndex = 30;
            // 
            // lbDups
            // 
            this.lbDups.AutoSize = true;
            this.lbDups.Location = new System.Drawing.Point(589, 28);
            this.lbDups.Name = "lbDups";
            this.lbDups.Size = new System.Drawing.Size(83, 13);
            this.lbDups.TabIndex = 32;
            this.lbDups.Text = "# Of Dups: n/a";
            // 
            // ckbIgnoreDups
            // 
            this.ckbIgnoreDups.AutoSize = true;
            this.ckbIgnoreDups.Location = new System.Drawing.Point(687, 27);
            this.ckbIgnoreDups.Name = "ckbIgnoreDups";
            this.ckbIgnoreDups.Size = new System.Drawing.Size(90, 17);
            this.ckbIgnoreDups.TabIndex = 33;
            this.ckbIgnoreDups.Text = "Ignore Dups";
            this.ckbIgnoreDups.UseVisualStyleBackColor = true;
            // 
            // btnRetrieveToggles
            // 
            this.btnRetrieveToggles.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRetrieveToggles.Location = new System.Drawing.Point(677, 171);
            this.btnRetrieveToggles.Name = "btnRetrieveToggles";
            this.btnRetrieveToggles.Size = new System.Drawing.Size(100, 23);
            this.btnRetrieveToggles.TabIndex = 30;
            this.btnRetrieveToggles.Text = "Retrieve Toggles";
            this.btnRetrieveToggles.UseVisualStyleBackColor = true;
            this.btnRetrieveToggles.Visible = false;
            this.btnRetrieveToggles.Click += new System.EventHandler(this.btnRetrieveToggles_Click);
            // 
            // lbNeedsSaving
            // 
            this.lbNeedsSaving.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbNeedsSaving.AutoSize = true;
            this.lbNeedsSaving.BackColor = System.Drawing.Color.Pink;
            this.lbNeedsSaving.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNeedsSaving.Location = new System.Drawing.Point(231, 610);
            this.lbNeedsSaving.Name = "lbNeedsSaving";
            this.lbNeedsSaving.Size = new System.Drawing.Size(144, 17);
            this.lbNeedsSaving.TabIndex = 35;
            this.lbNeedsSaving.Text = "CHANGES NOT SAVED";
            this.lbNeedsSaving.Visible = false;
            // 
            // btnClearCommData
            // 
            this.btnClearCommData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearCommData.Location = new System.Drawing.Point(133, 237);
            this.btnClearCommData.Name = "btnClearCommData";
            this.btnClearCommData.Size = new System.Drawing.Size(75, 20);
            this.btnClearCommData.TabIndex = 30;
            this.btnClearCommData.Text = "Clear";
            this.btnClearCommData.UseVisualStyleBackColor = true;
            this.btnClearCommData.Click += new System.EventHandler(this.btnClearCommData_Click);
            this.btnClearCommData.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnClearCommData.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnClearPhoneData
            // 
            this.btnClearPhoneData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearPhoneData.Location = new System.Drawing.Point(85, 397);
            this.btnClearPhoneData.Name = "btnClearPhoneData";
            this.btnClearPhoneData.Size = new System.Drawing.Size(75, 20);
            this.btnClearPhoneData.TabIndex = 36;
            this.btnClearPhoneData.Text = "Clear";
            this.btnClearPhoneData.UseVisualStyleBackColor = true;
            this.btnClearPhoneData.Click += new System.EventHandler(this.btnClearPhoneData_Click);
            this.btnClearPhoneData.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnClearPhoneData.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnToggleC
            // 
            this.btnToggleC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnToggleC.Location = new System.Drawing.Point(479, 200);
            this.btnToggleC.Name = "btnToggleC";
            this.btnToggleC.Size = new System.Drawing.Size(32, 31);
            this.btnToggleC.TabIndex = 30;
            this.btnToggleC.Text = "C";
            this.btnToggleC.UseVisualStyleBackColor = true;
            this.btnToggleC.Visible = false;
            this.btnToggleC.Click += new System.EventHandler(this.SetToggle);
            // 
            // btnToggleU
            // 
            this.btnToggleU.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnToggleU.Location = new System.Drawing.Point(517, 200);
            this.btnToggleU.Name = "btnToggleU";
            this.btnToggleU.Size = new System.Drawing.Size(32, 31);
            this.btnToggleU.TabIndex = 37;
            this.btnToggleU.Text = "U";
            this.btnToggleU.UseVisualStyleBackColor = true;
            this.btnToggleU.Visible = false;
            this.btnToggleU.Click += new System.EventHandler(this.SetToggle);
            // 
            // btnToggleA
            // 
            this.btnToggleA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnToggleA.Location = new System.Drawing.Point(593, 200);
            this.btnToggleA.Name = "btnToggleA";
            this.btnToggleA.Size = new System.Drawing.Size(32, 31);
            this.btnToggleA.TabIndex = 39;
            this.btnToggleA.Text = "A";
            this.btnToggleA.UseVisualStyleBackColor = true;
            this.btnToggleA.Visible = false;
            this.btnToggleA.Click += new System.EventHandler(this.SetToggle);
            // 
            // btnToggleD
            // 
            this.btnToggleD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnToggleD.Location = new System.Drawing.Point(555, 200);
            this.btnToggleD.Name = "btnToggleD";
            this.btnToggleD.Size = new System.Drawing.Size(32, 31);
            this.btnToggleD.TabIndex = 38;
            this.btnToggleD.Text = "D";
            this.btnToggleD.UseVisualStyleBackColor = true;
            this.btnToggleD.Visible = false;
            this.btnToggleD.Click += new System.EventHandler(this.SetToggle);
            // 
            // btnToggleK
            // 
            this.btnToggleK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnToggleK.Location = new System.Drawing.Point(745, 200);
            this.btnToggleK.Name = "btnToggleK";
            this.btnToggleK.Size = new System.Drawing.Size(32, 31);
            this.btnToggleK.TabIndex = 43;
            this.btnToggleK.Text = "K";
            this.btnToggleK.UseVisualStyleBackColor = true;
            this.btnToggleK.Visible = false;
            this.btnToggleK.Click += new System.EventHandler(this.SetToggle);
            // 
            // btnToggleB
            // 
            this.btnToggleB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnToggleB.Location = new System.Drawing.Point(707, 200);
            this.btnToggleB.Name = "btnToggleB";
            this.btnToggleB.Size = new System.Drawing.Size(32, 31);
            this.btnToggleB.TabIndex = 42;
            this.btnToggleB.Text = "B";
            this.btnToggleB.UseVisualStyleBackColor = true;
            this.btnToggleB.Visible = false;
            this.btnToggleB.Click += new System.EventHandler(this.SetToggle);
            // 
            // btnToggleO
            // 
            this.btnToggleO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnToggleO.Location = new System.Drawing.Point(669, 200);
            this.btnToggleO.Name = "btnToggleO";
            this.btnToggleO.Size = new System.Drawing.Size(32, 31);
            this.btnToggleO.TabIndex = 41;
            this.btnToggleO.Text = "O";
            this.btnToggleO.UseVisualStyleBackColor = true;
            this.btnToggleO.Visible = false;
            this.btnToggleO.Click += new System.EventHandler(this.SetToggle);
            // 
            // btnToggleS
            // 
            this.btnToggleS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnToggleS.Location = new System.Drawing.Point(631, 200);
            this.btnToggleS.Name = "btnToggleS";
            this.btnToggleS.Size = new System.Drawing.Size(32, 31);
            this.btnToggleS.TabIndex = 40;
            this.btnToggleS.Text = "S";
            this.btnToggleS.UseVisualStyleBackColor = true;
            this.btnToggleS.Visible = false;
            this.btnToggleS.Click += new System.EventHandler(this.SetToggle);
            // 
            // timerGetToggles
            // 
            this.timerGetToggles.Enabled = true;
            this.timerGetToggles.Interval = 1000;
            this.timerGetToggles.Tick += new System.EventHandler(this.timerGetToggles_Tick);
            // 
            // cbLineCount
            // 
            this.cbLineCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLineCount.FormattingEnabled = true;
            this.cbLineCount.Items.AddRange(new object[] {
            "1",
            "5",
            "9",
            "17",
            "21",
            "25",
            "33"});
            this.cbLineCount.Location = new System.Drawing.Point(733, 65);
            this.cbLineCount.Name = "cbLineCount";
            this.cbLineCount.Size = new System.Drawing.Size(44, 21);
            this.cbLineCount.TabIndex = 44;
            this.cbLineCount.SelectedIndexChanged += new System.EventHandler(this.cbLineCount_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(476, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Current Line Count:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(616, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Reset Line Count To:";
            // 
            // lbLineCount
            // 
            this.lbLineCount.AutoSize = true;
            this.lbLineCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLineCount.Location = new System.Drawing.Point(590, 68);
            this.lbLineCount.Name = "lbLineCount";
            this.lbLineCount.Size = new System.Drawing.Size(19, 13);
            this.lbLineCount.TabIndex = 46;
            this.lbLineCount.Text = "01";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 635);
            this.Controls.Add(this.lbLineCount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbLineCount);
            this.Controls.Add(this.btnToggleK);
            this.Controls.Add(this.btnToggleB);
            this.Controls.Add(this.btnToggleO);
            this.Controls.Add(this.btnToggleS);
            this.Controls.Add(this.btnToggleA);
            this.Controls.Add(this.btnToggleD);
            this.Controls.Add(this.btnToggleU);
            this.Controls.Add(this.btnToggleC);
            this.Controls.Add(this.btnClearPhoneData);
            this.Controls.Add(this.btnClearCommData);
            this.Controls.Add(this.lbNeedsSaving);
            this.Controls.Add(this.btnRetrieveToggles);
            this.Controls.Add(this.ckbIgnoreDups);
            this.Controls.Add(this.lbDups);
            this.Controls.Add(this.lbDeluxeUnitDetected);
            this.Controls.Add(this.panChangers);
            this.Controls.Add(this.imgConnected);
            this.Controls.Add(this.lbListeningOn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbConnected);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvPhoneData);
            this.Controls.Add(this.dgvCommData);
            this.Controls.Add(this.panStatus);
            this.Controls.Add(this.mnuMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(459, 523);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ethernet Link Config v.0.0.0.1";
            ((System.ComponentModel.ISupportInitialize)(this.imgConnected)).EndInit();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhoneData)).EndInit();
            this.panChangers.ResumeLayout(false);
            this.panChangers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panStatus;
        private System.Windows.Forms.Label lbDeluxeUnitDetected;
        private System.Windows.Forms.Label lbListeningOn;
        private IPAddressControlLib.IPAddressControl tbIP;
        private System.Windows.Forms.Label label1;
        private ISEAGE.May610.Diagrammer.matb tbMAC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUnitNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbEthernetID;
        private System.Windows.Forms.Label label5;
        private ISEAGE.May610.Diagrammer.matb tbDestMAC;
        private System.Windows.Forms.Label label6;
        private IPAddressControlLib.IPAddressControl tbDestIP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbDestPort;
        private System.Windows.Forms.PictureBox imgConnected;
        private System.Windows.Forms.Timer timerRefresher;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label lbConnected;
        private System.Windows.Forms.DataGridView dgvCommData;
        private System.Windows.Forms.DataGridView dgvPhoneData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnUnlockUnitNumber;
        private System.Windows.Forms.Button btnUnlockIPAddress;
        private System.Windows.Forms.Button btnUnlockMACAddress;
        private System.Windows.Forms.Button btnUnlockDestPort;
        private System.Windows.Forms.Button btnUnlockDestIP;
        private System.Windows.Forms.Button btnUnlockDestMAC;
        private System.Windows.Forms.Panel panChangers;
        private System.Windows.Forms.Label lbDups;
        private System.Windows.Forms.CheckBox ckbIgnoreDups;
        private System.Windows.Forms.Button btnRetrieveToggles;
        private System.Windows.Forms.Label lbNeedsSaving;
        private System.Windows.Forms.Button btnClearCommData;
        private System.Windows.Forms.Button btnClearPhoneData;
        private System.Windows.Forms.Button btnToggleC;
        private System.Windows.Forms.Button btnToggleU;
        private System.Windows.Forms.Button btnToggleA;
        private System.Windows.Forms.Button btnToggleD;
        private System.Windows.Forms.Button btnToggleK;
        private System.Windows.Forms.Button btnToggleB;
        private System.Windows.Forms.Button btnToggleO;
        private System.Windows.Forms.Button btnToggleS;
        private System.Windows.Forms.Timer timerGetToggles;
        private System.Windows.Forms.ToolStripMenuItem resetEthernetDefaultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDeluxeUnitOutputDefaultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem setUnitToCurrentTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDeluxeUnitToBasicUnitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem sendDuplicateCallRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem listeningPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayComputerIPAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManualToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPhoneDataColLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPhoneDataColIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPhoneDataColSE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPhoneDataColDur;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPhoneDataColCS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPhoneDataColRing;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPhoneDataColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPhoneDataColTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPhoneDataColNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPhoneDataColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCommDataColDisplay;
        private System.Windows.Forms.ComboBox cbLineCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbLineCount;
    }
}

