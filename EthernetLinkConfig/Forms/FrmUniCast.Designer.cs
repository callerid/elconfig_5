namespace EthernetLinkConfig.Forms
{
    partial class FrmUniCast
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUniCast));
            this.ipSendIPAddress = new IPAddressControlLib.IPAddressControl();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUseBroadcast = new System.Windows.Forms.Button();
            this.tvFoundIPs = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ipSendIPAddress
            // 
            this.ipSendIPAddress.AllowInternalTab = false;
            this.ipSendIPAddress.AutoHeight = true;
            this.ipSendIPAddress.BackColor = System.Drawing.SystemColors.Window;
            this.ipSendIPAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipSendIPAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipSendIPAddress.Location = new System.Drawing.Point(141, 24);
            this.ipSendIPAddress.MinimumSize = new System.Drawing.Size(84, 22);
            this.ipSendIPAddress.Name = "ipSendIPAddress";
            this.ipSendIPAddress.ReadOnly = false;
            this.ipSendIPAddress.Size = new System.Drawing.Size(87, 22);
            this.ipSendIPAddress.TabIndex = 0;
            this.ipSendIPAddress.Text = "255.255.255.255";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Send all commands to:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(241, 52);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save && Close";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUseBroadcast
            // 
            this.btnUseBroadcast.Location = new System.Drawing.Point(140, 52);
            this.btnUseBroadcast.Name = "btnUseBroadcast";
            this.btnUseBroadcast.Size = new System.Drawing.Size(95, 23);
            this.btnUseBroadcast.TabIndex = 4;
            this.btnUseBroadcast.Text = "Use Broadcast";
            this.btnUseBroadcast.UseVisualStyleBackColor = true;
            this.btnUseBroadcast.Click += new System.EventHandler(this.btnUseBroadcast_Click);
            // 
            // tvFoundIPs
            // 
            this.tvFoundIPs.Location = new System.Drawing.Point(12, 94);
            this.tvFoundIPs.Name = "tvFoundIPs";
            this.tvFoundIPs.Size = new System.Drawing.Size(313, 64);
            this.tvFoundIPs.TabIndex = 5;
            this.tvFoundIPs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFoundIPs_AfterSelect);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Or Use A Found IP Below:";
            // 
            // FrmUniCast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 171);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tvFoundIPs);
            this.Controls.Add(this.btnUseBroadcast);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipSendIPAddress);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmUniCast";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup Unicast";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IPAddressControlLib.IPAddressControl ipSendIPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUseBroadcast;
        private System.Windows.Forms.TreeView tvFoundIPs;
        private System.Windows.Forms.Label label2;
    }
}