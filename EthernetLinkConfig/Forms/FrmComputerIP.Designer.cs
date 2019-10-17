namespace EthernetLinkConfig.Forms
{
    partial class FrmComputerIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmComputerIP));
            this.lbIP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSetBroadcast = new System.Windows.Forms.Button();
            this.btnSetUnicast = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbMac = new System.Windows.Forms.Label();
            this.lbCIDUnitMAC = new System.Windows.Forms.Label();
            this.lbCIDUnitIP = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timerRefresher = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbIP
            // 
            this.lbIP.AutoSize = true;
            this.lbIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIP.Location = new System.Drawing.Point(26, 35);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(104, 18);
            this.lbIP.TabIndex = 0;
            this.lbIP.Text = "192.168.0.90";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Computer IP";
            // 
            // btnSetBroadcast
            // 
            this.btnSetBroadcast.Location = new System.Drawing.Point(183, 80);
            this.btnSetBroadcast.Name = "btnSetBroadcast";
            this.btnSetBroadcast.Size = new System.Drawing.Size(127, 23);
            this.btnSetBroadcast.TabIndex = 2;
            this.btnSetBroadcast.Text = "Set to Broadcast";
            this.btnSetBroadcast.UseVisualStyleBackColor = true;
            this.btnSetBroadcast.Click += new System.EventHandler(this.btnSetBroadcast_Click);
            // 
            // btnSetUnicast
            // 
            this.btnSetUnicast.Location = new System.Drawing.Point(183, 48);
            this.btnSetUnicast.Name = "btnSetUnicast";
            this.btnSetUnicast.Size = new System.Drawing.Size(128, 23);
            this.btnSetUnicast.TabIndex = 3;
            this.btnSetUnicast.Text = "Set to this Computer";
            this.btnSetUnicast.UseVisualStyleBackColor = true;
            this.btnSetUnicast.Click += new System.EventHandler(this.btnSetUnicast_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(198, 141);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Computer MAC";
            // 
            // lbMac
            // 
            this.lbMac.AutoSize = true;
            this.lbMac.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMac.Location = new System.Drawing.Point(12, 98);
            this.lbMac.Name = "lbMac";
            this.lbMac.Size = new System.Drawing.Size(146, 18);
            this.lbMac.TabIndex = 5;
            this.lbMac.Text = "00-00-00-00-00-00";
            // 
            // lbCIDUnitMAC
            // 
            this.lbCIDUnitMAC.AutoSize = true;
            this.lbCIDUnitMAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCIDUnitMAC.Location = new System.Drawing.Point(329, 98);
            this.lbCIDUnitMAC.Name = "lbCIDUnitMAC";
            this.lbCIDUnitMAC.Size = new System.Drawing.Size(146, 18);
            this.lbCIDUnitMAC.TabIndex = 8;
            this.lbCIDUnitMAC.Text = "00-00-00-00-00-00";
            // 
            // lbCIDUnitIP
            // 
            this.lbCIDUnitIP.AutoSize = true;
            this.lbCIDUnitIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCIDUnitIP.Location = new System.Drawing.Point(355, 35);
            this.lbCIDUnitIP.Name = "lbCIDUnitIP";
            this.lbCIDUnitIP.Size = new System.Drawing.Size(104, 18);
            this.lbCIDUnitIP.TabIndex = 11;
            this.lbCIDUnitIP.Text = "192.168.0.90";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(371, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Destination IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Destination MAC";
            // 
            // timerRefresher
            // 
            this.timerRefresher.Enabled = true;
            this.timerRefresher.Interval = 1500;
            this.timerRefresher.Tick += new System.EventHandler(this.timerRefresher_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(187, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Set Destination";
            // 
            // FrmComputerIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 176);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbCIDUnitIP);
            this.Controls.Add(this.lbCIDUnitMAC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbMac);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSetUnicast);
            this.Controls.Add(this.btnSetBroadcast);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbIP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmComputerIP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Computer IP / MAC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSetBroadcast;
        private System.Windows.Forms.Button btnSetUnicast;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbMac;
        private System.Windows.Forms.Label lbCIDUnitMAC;
        private System.Windows.Forms.Label lbCIDUnitIP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timerRefresher;
        private System.Windows.Forms.Label label1;
    }
}