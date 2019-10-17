namespace EthernetLinkConfig.Forms
{
    partial class FrmTimerMsgBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTimerMsgBox));
            this.tbDisplay = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.timerAutoClose = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tbDisplay
            // 
            this.tbDisplay.Location = new System.Drawing.Point(12, 12);
            this.tbDisplay.Multiline = true;
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.Size = new System.Drawing.Size(369, 141);
            this.tbDisplay.TabIndex = 0;
            this.tbDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(156, 166);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Okay";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmTimerMsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 201);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tbDisplay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTimerMsgBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDisplay;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Timer timerAutoClose;
    }
}