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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUseBroadcast = new System.Windows.Forms.Button();
            this.tvFoundIPs = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.ipSendIPAddress = new CustomIPControl.ipControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Send commands to:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(136, 186);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save && Close";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUseBroadcast
            // 
            this.btnUseBroadcast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUseBroadcast.Location = new System.Drawing.Point(204, 157);
            this.btnUseBroadcast.Name = "btnUseBroadcast";
            this.btnUseBroadcast.Size = new System.Drawing.Size(97, 23);
            this.btnUseBroadcast.TabIndex = 4;
            this.btnUseBroadcast.Text = "Use Broadcast";
            this.btnUseBroadcast.UseVisualStyleBackColor = true;
            this.btnUseBroadcast.Click += new System.EventHandler(this.btnUseBroadcast_Click);
            // 
            // tvFoundIPs
            // 
            this.tvFoundIPs.Location = new System.Drawing.Point(12, 33);
            this.tvFoundIPs.Name = "tvFoundIPs";
            this.tvFoundIPs.Size = new System.Drawing.Size(286, 65);
            this.tvFoundIPs.TabIndex = 5;
            this.tvFoundIPs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFoundIPs_AfterSelect);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Units Found, Select IP";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(238, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(60, 23);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ipSendIPAddress
            // 
            this.ipSendIPAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ipSendIPAddress.Location = new System.Drawing.Point(151, 124);
            this.ipSendIPAddress.Name = "ipSendIPAddress";
            this.ipSendIPAddress.Size = new System.Drawing.Size(150, 27);
            this.ipSendIPAddress.TabIndex = 8;
            // 
            // FrmUniCast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(310, 221);
            this.Controls.Add(this.ipSendIPAddress);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tvFoundIPs);
            this.Controls.Add(this.btnUseBroadcast);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
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
        
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUseBroadcast;
        private System.Windows.Forms.TreeView tvFoundIPs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private CustomIPControl.ipControl ipSendIPAddress;
    }
}