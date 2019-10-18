namespace EthernetLinkConfig.Forms
{
    partial class FrmPing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPing));
            this.label1 = new System.Windows.Forms.Label();
            this.btnPing = new System.Windows.Forms.Button();
            this.lbResponse = new System.Windows.Forms.Label();
            this.panResponse = new System.Windows.Forms.Panel();
            this.ipToPing = new System.Windows.Forms.TextBox();
            this.panResponse.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ping This IP:";
            // 
            // btnPing
            // 
            this.btnPing.Location = new System.Drawing.Point(179, 23);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(60, 23);
            this.btnPing.TabIndex = 2;
            this.btnPing.Text = "PING";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // lbResponse
            // 
            this.lbResponse.AutoSize = true;
            this.lbResponse.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResponse.Location = new System.Drawing.Point(35, 6);
            this.lbResponse.Name = "lbResponse";
            this.lbResponse.Size = new System.Drawing.Size(0, 25);
            this.lbResponse.TabIndex = 4;
            // 
            // panResponse
            // 
            this.panResponse.BackColor = System.Drawing.Color.Gainsboro;
            this.panResponse.Controls.Add(this.lbResponse);
            this.panResponse.Location = new System.Drawing.Point(-1, 63);
            this.panResponse.Name = "panResponse";
            this.panResponse.Size = new System.Drawing.Size(262, 43);
            this.panResponse.TabIndex = 5;
            // 
            // ipToPing
            // 
            this.ipToPing.Location = new System.Drawing.Point(87, 23);
            this.ipToPing.Name = "ipToPing";
            this.ipToPing.Size = new System.Drawing.Size(86, 22);
            this.ipToPing.TabIndex = 6;
            // 
            // FrmPing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(257, 104);
            this.Controls.Add(this.ipToPing);
            this.Controls.Add(this.panResponse);
            this.Controls.Add(this.btnPing);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmPing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ping";
            this.panResponse.ResumeLayout(false);
            this.panResponse.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.Label lbResponse;
        private System.Windows.Forms.Panel panResponse;
        private System.Windows.Forms.TextBox ipToPing;
    }
}