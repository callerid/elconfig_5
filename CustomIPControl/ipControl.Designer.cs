namespace CustomIPControl
{
    partial class ipControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panBackground = new System.Windows.Forms.Panel();
            this.panBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb1.Location = new System.Drawing.Point(3, 6);
            this.tb1.MaxLength = 3;
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(26, 13);
            this.tb1.TabIndex = 0;
            this.tb1.Text = "255";
            this.tb1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb1.Enter += new System.EventHandler(this.ipControl_FocusChange);
            this.tb1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ipControl_DigitsOnly);
            this.tb1.Leave += new System.EventHandler(this.ipControl_FocusChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = ".";
            // 
            // tb2
            // 
            this.tb2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb2.Location = new System.Drawing.Point(41, 6);
            this.tb2.MaxLength = 3;
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(22, 13);
            this.tb2.TabIndex = 1;
            this.tb2.Text = "255";
            this.tb2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb2.Enter += new System.EventHandler(this.ipControl_FocusChange);
            this.tb2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ipControl_DigitsOnly);
            this.tb2.Leave += new System.EventHandler(this.ipControl_FocusChange);
            // 
            // tb3
            // 
            this.tb3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb3.Location = new System.Drawing.Point(79, 6);
            this.tb3.MaxLength = 3;
            this.tb3.Name = "tb3";
            this.tb3.Size = new System.Drawing.Size(21, 13);
            this.tb3.TabIndex = 2;
            this.tb3.Text = "255";
            this.tb3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb3.Enter += new System.EventHandler(this.ipControl_FocusChange);
            this.tb3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ipControl_DigitsOnly);
            this.tb3.Leave += new System.EventHandler(this.ipControl_FocusChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = ".";
            // 
            // tb4
            // 
            this.tb4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb4.Location = new System.Drawing.Point(116, 6);
            this.tb4.MaxLength = 3;
            this.tb4.Name = "tb4";
            this.tb4.Size = new System.Drawing.Size(20, 13);
            this.tb4.TabIndex = 3;
            this.tb4.Text = "255";
            this.tb4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb4.Enter += new System.EventHandler(this.ipControl_FocusChange);
            this.tb4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ipControl_DigitsOnly);
            this.tb4.Leave += new System.EventHandler(this.ipControl_FocusChange);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = ".";
            // 
            // panBackground
            // 
            this.panBackground.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panBackground.Controls.Add(this.tb1);
            this.panBackground.Controls.Add(this.tb4);
            this.panBackground.Controls.Add(this.label1);
            this.panBackground.Controls.Add(this.label3);
            this.panBackground.Controls.Add(this.tb2);
            this.panBackground.Controls.Add(this.tb3);
            this.panBackground.Controls.Add(this.label2);
            this.panBackground.Location = new System.Drawing.Point(1, 0);
            this.panBackground.Name = "panBackground";
            this.panBackground.Size = new System.Drawing.Size(143, 25);
            this.panBackground.TabIndex = 7;
            // 
            // ipControl
            //
            this.Controls.Add(this.panBackground);
            this.Name = "ipControl";
            this.Size = new System.Drawing.Size(145, 27);
            this.panBackground.ResumeLayout(false);
            this.panBackground.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.TextBox tb3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panBackground;
    }
}
