namespace CustomIPControl
{
    partial class macControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panBackground = new System.Windows.Forms.Panel();
            this.tb6 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb5 = new System.Windows.Forms.TextBox();
            this.panBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb1.Location = new System.Drawing.Point(3, 3);
            this.tb1.MaxLength = 2;
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(12, 13);
            this.tb1.TabIndex = 0;
            this.tb1.Text = "FF";
            this.tb1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb1.Enter += new System.EventHandler(this.ipControl_FocusChange);
            this.tb1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ipControl_HexOnly);
            this.tb1.Leave += new System.EventHandler(this.ipControl_FocusChange);
            // 
            // tb4
            // 
            this.tb4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb4.Location = new System.Drawing.Point(86, 3);
            this.tb4.MaxLength = 2;
            this.tb4.Name = "tb4";
            this.tb4.Size = new System.Drawing.Size(12, 13);
            this.tb4.TabIndex = 3;
            this.tb4.Text = "FF";
            this.tb4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb4.Enter += new System.EventHandler(this.ipControl_FocusChange);
            this.tb4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ipControl_HexOnly);
            this.tb4.Leave += new System.EventHandler(this.ipControl_FocusChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "-";
            // 
            // tb2
            // 
            this.tb2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb2.Location = new System.Drawing.Point(29, 3);
            this.tb2.MaxLength = 2;
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(12, 13);
            this.tb2.TabIndex = 1;
            this.tb2.Text = "FF";
            this.tb2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb2.Enter += new System.EventHandler(this.ipControl_FocusChange);
            this.tb2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ipControl_HexOnly);
            this.tb2.Leave += new System.EventHandler(this.ipControl_FocusChange);
            // 
            // tb3
            // 
            this.tb3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb3.Location = new System.Drawing.Point(57, 3);
            this.tb3.MaxLength = 2;
            this.tb3.Name = "tb3";
            this.tb3.Size = new System.Drawing.Size(12, 13);
            this.tb3.TabIndex = 2;
            this.tb3.Text = "FF";
            this.tb3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb3.Enter += new System.EventHandler(this.ipControl_FocusChange);
            this.tb3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ipControl_HexOnly);
            this.tb3.Leave += new System.EventHandler(this.ipControl_FocusChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "-";
            // 
            // panBackground
            // 
            this.panBackground.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panBackground.Controls.Add(this.tb6);
            this.panBackground.Controls.Add(this.label1);
            this.panBackground.Controls.Add(this.tb1);
            this.panBackground.Controls.Add(this.label4);
            this.panBackground.Controls.Add(this.label3);
            this.panBackground.Controls.Add(this.tb3);
            this.panBackground.Controls.Add(this.tb5);
            this.panBackground.Controls.Add(this.tb2);
            this.panBackground.Controls.Add(this.label2);
            this.panBackground.Controls.Add(this.tb4);
            this.panBackground.Controls.Add(this.label5);
            this.panBackground.Location = new System.Drawing.Point(3, 3);
            this.panBackground.Name = "panBackground";
            this.panBackground.Size = new System.Drawing.Size(159, 20);
            this.panBackground.TabIndex = 8;
            // 
            // tb6
            // 
            this.tb6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb6.Location = new System.Drawing.Point(142, 3);
            this.tb6.MaxLength = 2;
            this.tb6.Name = "tb6";
            this.tb6.Size = new System.Drawing.Size(12, 13);
            this.tb6.TabIndex = 5;
            this.tb6.Text = "FF";
            this.tb6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb6.Enter += new System.EventHandler(this.ipControl_FocusChange);
            this.tb6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ipControl_HexOnly);
            this.tb6.Leave += new System.EventHandler(this.ipControl_FocusChange);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(127, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "-";
            // 
            // tb5
            // 
            this.tb5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb5.Location = new System.Drawing.Point(113, 3);
            this.tb5.MaxLength = 2;
            this.tb5.Name = "tb5";
            this.tb5.Size = new System.Drawing.Size(12, 13);
            this.tb5.TabIndex = 4;
            this.tb5.Text = "FF";
            this.tb5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb5.Enter += new System.EventHandler(this.ipControl_FocusChange);
            this.tb5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ipControl_HexOnly);
            this.tb5.Leave += new System.EventHandler(this.ipControl_FocusChange);
            // 
            // macControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panBackground);
            this.Name = "macControl";
            this.Size = new System.Drawing.Size(165, 26);
            this.panBackground.ResumeLayout(false);
            this.panBackground.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.TextBox tb4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.TextBox tb3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panBackground;
        private System.Windows.Forms.TextBox tb6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb5;
    }
}
