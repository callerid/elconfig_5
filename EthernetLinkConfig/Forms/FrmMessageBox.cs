using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EthernetLinkConfig.Classes;

namespace EthernetLinkConfig.Forms
{
    public partial class FrmMessageBox : Form
    {
        public FrmMessageBox(string message, string title, bool ok_only = true, int auto_close_ms = -1)
        {
            InitializeComponent();
            Common.DrawColors(this);
            Common.SetTitle(this, title);
            tbText.Text = Environment.NewLine + Environment.NewLine + message;

            if (ok_only) btnCancel.Visible = false;

            if (auto_close_ms > -1)
            {
                timerAutoClose.Interval = auto_close_ms;
                timerAutoClose.Enabled = true;
                timerAutoClose.Start();
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void FrmMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void timerAutoClose_Tick(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.None;
            Close();
        }
    }
}
