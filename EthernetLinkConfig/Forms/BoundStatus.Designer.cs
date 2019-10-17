namespace EthernetLinkConfig.Forms
{
    partial class BoundStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoundStatus));
            this.lb3520 = new System.Windows.Forms.Label();
            this.lb6699 = new System.Windows.Forms.Label();
            this.lbCustom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb3520
            // 
            this.lb3520.AutoSize = true;
            this.lb3520.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb3520.Location = new System.Drawing.Point(12, 25);
            this.lb3520.Name = "lb3520";
            this.lb3520.Size = new System.Drawing.Size(35, 13);
            this.lb3520.TabIndex = 0;
            this.lb3520.Text = "3520";
            // 
            // lb6699
            // 
            this.lb6699.AutoSize = true;
            this.lb6699.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb6699.Location = new System.Drawing.Point(12, 54);
            this.lb6699.Name = "lb6699";
            this.lb6699.Size = new System.Drawing.Size(35, 13);
            this.lb6699.TabIndex = 1;
            this.lb6699.Text = "6699";
            // 
            // lbCustom
            // 
            this.lbCustom.AutoSize = true;
            this.lbCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCustom.Location = new System.Drawing.Point(12, 81);
            this.lbCustom.Name = "lbCustom";
            this.lbCustom.Size = new System.Drawing.Size(35, 13);
            this.lbCustom.TabIndex = 2;
            this.lbCustom.Text = "0000";
            // 
            // BoundStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 110);
            this.Controls.Add(this.lbCustom);
            this.Controls.Add(this.lb6699);
            this.Controls.Add(this.lb3520);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BoundStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BoundStatus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb3520;
        private System.Windows.Forms.Label lb6699;
        private System.Windows.Forms.Label lbCustom;
    }
}