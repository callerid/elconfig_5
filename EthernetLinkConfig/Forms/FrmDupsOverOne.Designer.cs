namespace EthernetLinkConfig.Forms
{
    partial class FrmDupsOverOne
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDupsOverOne));
            this.lbMessage = new System.Windows.Forms.Label();
            this.btnResetDupsToOne = new System.Windows.Forms.Button();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.ForeColor = System.Drawing.Color.DarkRed;
            this.lbMessage.Location = new System.Drawing.Point(26, 16);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(342, 52);
            this.lbMessage.TabIndex = 0;
            this.lbMessage.Text = resources.GetString("lbMessage.Text");
            // 
            // btnResetDupsToOne
            // 
            this.btnResetDupsToOne.Location = new System.Drawing.Point(232, 87);
            this.btnResetDupsToOne.Name = "btnResetDupsToOne";
            this.btnResetDupsToOne.Size = new System.Drawing.Size(138, 23);
            this.btnResetDupsToOne.TabIndex = 1;
            this.btnResetDupsToOne.Text = "Reset To Single Records";
            this.btnResetDupsToOne.UseVisualStyleBackColor = true;
            this.btnResetDupsToOne.Click += new System.EventHandler(this.btnResetDupsToOne_Click);
            // 
            // btnIgnore
            // 
            this.btnIgnore.Location = new System.Drawing.Point(15, 87);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(78, 23);
            this.btnIgnore.TabIndex = 2;
            this.btnIgnore.Text = "Ignore";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
            // 
            // FrmDupsOverOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(386, 122);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.btnResetDupsToOne);
            this.Controls.Add(this.lbMessage);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmDupsOverOne";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Use Duplicates?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Button btnResetDupsToOne;
        private System.Windows.Forms.Button btnIgnore;
    }
}