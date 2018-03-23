namespace EthernetLinkConfig.Forms
{
    partial class FrmDuplicateTracking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDuplicateTracking));
            this.dgvCommData = new System.Windows.Forms.DataGridView();
            this.dgvCommDataColDisplay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCommDataColSecs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommData)).BeginInit();
            this.SuspendLayout();
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
            this.dgvCommDataColDisplay,
            this.dgvCommDataColSecs});
            this.dgvCommData.Location = new System.Drawing.Point(12, 12);
            this.dgvCommData.MultiSelect = false;
            this.dgvCommData.Name = "dgvCommData";
            this.dgvCommData.ReadOnly = true;
            this.dgvCommData.RowHeadersVisible = false;
            this.dgvCommData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCommData.Size = new System.Drawing.Size(816, 268);
            this.dgvCommData.TabIndex = 21;
            // 
            // dgvCommDataColDisplay
            // 
            this.dgvCommDataColDisplay.HeaderText = "Dups";
            this.dgvCommDataColDisplay.Name = "dgvCommDataColDisplay";
            this.dgvCommDataColDisplay.ReadOnly = true;
            this.dgvCommDataColDisplay.Width = 745;
            // 
            // dgvCommDataColSecs
            // 
            this.dgvCommDataColSecs.HeaderText = "Secs";
            this.dgvCommDataColSecs.Name = "dgvCommDataColSecs";
            this.dgvCommDataColSecs.ReadOnly = true;
            this.dgvCommDataColSecs.Width = 50;
            // 
            // FrmDuplicateTracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 292);
            this.Controls.Add(this.dgvCommData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDuplicateTracking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dups";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCommData;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCommDataColDisplay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCommDataColSecs;

    }
}