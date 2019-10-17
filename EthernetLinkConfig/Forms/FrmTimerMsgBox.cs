using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EthernetLinkConfig.Forms
{
    public partial class FrmTimerMsgBox : Form
    {
        public FrmTimerMsgBox(string message, string title, bool btn_enabled, bool auto_close = true, int close_in_ms = 1500)
        {
            InitializeComponent();

            Text = title;

            tbDisplay.Text = Environment.NewLine + Environment.NewLine + message;

            tbDisplay.SelectionStart = tbDisplay.Text.Length;

            btnOk.Enabled = btn_enabled;

            if (auto_close)
            {
                timerAutoClose.Interval = close_in_ms;
            }
            else
            {
                timerAutoClose.Interval = 50000;
            }

            timerAutoClose.Enabled = true;
            timerAutoClose.Start();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
