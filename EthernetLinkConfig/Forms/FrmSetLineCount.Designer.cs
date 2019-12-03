namespace EthernetLinkConfig.Forms
{
    partial class FrmSetLineCount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetLineCount));
            this.lbLineCount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbLineCount = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbAskingChange = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbLineCount
            // 
            this.lbLineCount.AutoSize = true;
            this.lbLineCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLineCount.Location = new System.Drawing.Point(136, 24);
            this.lbLineCount.Name = "lbLineCount";
            this.lbLineCount.Size = new System.Drawing.Size(19, 13);
            this.lbLineCount.TabIndex = 50;
            this.lbLineCount.Text = "01";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(181, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "Reset Line Count To:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Starting Line Count =";
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
            this.cbLineCount.Location = new System.Drawing.Point(299, 21);
            this.cbLineCount.Name = "cbLineCount";
            this.cbLineCount.Size = new System.Drawing.Size(75, 21);
            this.cbLineCount.TabIndex = 48;
            this.cbLineCount.SelectedIndexChanged += new System.EventHandler(this.cbLineCount_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(299, 102);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbAskingChange
            // 
            this.lbAskingChange.AutoSize = true;
            this.lbAskingChange.ForeColor = System.Drawing.Color.DarkRed;
            this.lbAskingChange.Location = new System.Drawing.Point(80, 51);
            this.lbAskingChange.Name = "lbAskingChange";
            this.lbAskingChange.Size = new System.Drawing.Size(224, 39);
            this.lbAskingChange.TabIndex = 52;
            this.lbAskingChange.Text = "Starting line number on the unit is [X].\r\nIf only one Caller ID device is install" +
    "ed, the\r\nline number needs to be changed to 1.";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 102);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 53;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmSetLineCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(386, 137);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbAskingChange);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbLineCount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbLineCount);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmSetLineCount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Line Count";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Label lbLineCount;
        private System.Windows.Forms.Label lbAskingChange;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.ComboBox cbLineCount;
    }
}