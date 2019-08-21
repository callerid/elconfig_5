namespace EthernetLinkConfig.Forms
{
    partial class FrmBlockingConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBlockingConfig));
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.dgvListColCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvListColNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEnableDisableCallBlocking = new System.Windows.Forms.Button();
            this.btnQ = new System.Windows.Forms.Button();
            this.btnBlock = new System.Windows.Forms.Button();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.btnBlockPrivate = new System.Windows.Forms.Button();
            this.btnBlockOutOfArea = new System.Windows.Forms.Button();
            this.rbBlock = new System.Windows.Forms.RadioButton();
            this.rbAllow = new System.Windows.Forms.RadioButton();
            this.timerAutoLoad = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvListColCount,
            this.dgvListColNumber});
            this.dgvList.Location = new System.Drawing.Point(12, 41);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.Size = new System.Drawing.Size(240, 234);
            this.dgvList.TabIndex = 0;
            // 
            // dgvListColCount
            // 
            this.dgvListColCount.HeaderText = "#";
            this.dgvListColCount.Name = "dgvListColCount";
            this.dgvListColCount.ReadOnly = true;
            this.dgvListColCount.Width = 35;
            // 
            // dgvListColNumber
            // 
            this.dgvListColNumber.HeaderText = "Number";
            this.dgvListColNumber.Name = "dgvListColNumber";
            this.dgvListColNumber.ReadOnly = true;
            this.dgvListColNumber.Width = 160;
            // 
            // btnEnableDisableCallBlocking
            // 
            this.btnEnableDisableCallBlocking.Location = new System.Drawing.Point(12, 12);
            this.btnEnableDisableCallBlocking.Name = "btnEnableDisableCallBlocking";
            this.btnEnableDisableCallBlocking.Size = new System.Drawing.Size(119, 23);
            this.btnEnableDisableCallBlocking.TabIndex = 1;
            this.btnEnableDisableCallBlocking.Text = "Enable Call Blocking";
            this.btnEnableDisableCallBlocking.UseVisualStyleBackColor = true;
            this.btnEnableDisableCallBlocking.Click += new System.EventHandler(this.btnEnableDisableCallBlocking_Click);
            // 
            // btnQ
            // 
            this.btnQ.Location = new System.Drawing.Point(176, 12);
            this.btnQ.Name = "btnQ";
            this.btnQ.Size = new System.Drawing.Size(76, 22);
            this.btnQ.TabIndex = 59;
            this.btnQ.Text = "Clear List";
            this.btnQ.UseVisualStyleBackColor = true;
            this.btnQ.Click += new System.EventHandler(this.ClearList);
            // 
            // btnBlock
            // 
            this.btnBlock.Location = new System.Drawing.Point(200, 307);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(52, 23);
            this.btnBlock.TabIndex = 62;
            this.btnBlock.Text = "Add";
            this.btnBlock.UseVisualStyleBackColor = true;
            this.btnBlock.Click += new System.EventHandler(this.btnBlock_Click);
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(12, 310);
            this.tbNumber.MaxLength = 10;
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(182, 20);
            this.tbNumber.TabIndex = 63;
            this.tbNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumber_KeyPress);
            // 
            // btnBlockPrivate
            // 
            this.btnBlockPrivate.Location = new System.Drawing.Point(12, 281);
            this.btnBlockPrivate.Name = "btnBlockPrivate";
            this.btnBlockPrivate.Size = new System.Drawing.Size(88, 23);
            this.btnBlockPrivate.TabIndex = 64;
            this.btnBlockPrivate.Text = "Add Private";
            this.btnBlockPrivate.UseVisualStyleBackColor = true;
            this.btnBlockPrivate.Click += new System.EventHandler(this.btnBlockPrivate_Click);
            // 
            // btnBlockOutOfArea
            // 
            this.btnBlockOutOfArea.Location = new System.Drawing.Point(106, 281);
            this.btnBlockOutOfArea.Name = "btnBlockOutOfArea";
            this.btnBlockOutOfArea.Size = new System.Drawing.Size(146, 23);
            this.btnBlockOutOfArea.TabIndex = 65;
            this.btnBlockOutOfArea.Text = "Add Out-Of-Area";
            this.btnBlockOutOfArea.UseVisualStyleBackColor = true;
            this.btnBlockOutOfArea.Click += new System.EventHandler(this.btnBlockOutOfArea_Click);
            // 
            // rbBlock
            // 
            this.rbBlock.AutoSize = true;
            this.rbBlock.Checked = true;
            this.rbBlock.Location = new System.Drawing.Point(15, 343);
            this.rbBlock.Name = "rbBlock";
            this.rbBlock.Size = new System.Drawing.Size(85, 17);
            this.rbBlock.TabIndex = 66;
            this.rbBlock.TabStop = true;
            this.rbBlock.Text = "Block These";
            this.rbBlock.UseVisualStyleBackColor = true;
            this.rbBlock.Click += new System.EventHandler(this.rbBlock_Click);
            // 
            // rbAllow
            // 
            this.rbAllow.AutoSize = true;
            this.rbAllow.Location = new System.Drawing.Point(106, 343);
            this.rbAllow.Name = "rbAllow";
            this.rbAllow.Size = new System.Drawing.Size(115, 17);
            this.rbAllow.TabIndex = 67;
            this.rbAllow.Text = "Allow ONLY These";
            this.rbAllow.UseVisualStyleBackColor = true;
            this.rbAllow.Click += new System.EventHandler(this.rbAllow_Click);
            // 
            // timerAutoLoad
            // 
            this.timerAutoLoad.Enabled = true;
            this.timerAutoLoad.Tick += new System.EventHandler(this.timerAutoLoad_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "*Max limit = 40 Numbers";
            // 
            // FrmBlockingConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 387);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbAllow);
            this.Controls.Add(this.rbBlock);
            this.Controls.Add(this.btnBlockOutOfArea);
            this.Controls.Add(this.btnBlockPrivate);
            this.Controls.Add(this.tbNumber);
            this.Controls.Add(this.btnBlock);
            this.Controls.Add(this.btnQ);
            this.Controls.Add(this.btnEnableDisableCallBlocking);
            this.Controls.Add(this.dgvList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmBlockingConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blocking Config.";
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnEnableDisableCallBlocking;
        private System.Windows.Forms.Button btnQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvListColCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvListColNumber;
        private System.Windows.Forms.Button btnBlock;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.Button btnBlockPrivate;
        private System.Windows.Forms.Button btnBlockOutOfArea;
        private System.Windows.Forms.RadioButton rbBlock;
        private System.Windows.Forms.RadioButton rbAllow;
        private System.Windows.Forms.Timer timerAutoLoad;
        private System.Windows.Forms.Label label1;
    }
}