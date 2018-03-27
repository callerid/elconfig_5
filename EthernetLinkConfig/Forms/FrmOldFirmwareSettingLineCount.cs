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
    public partial class FrmOldFirmwareSettingLineCount : Form
    {
        public FrmOldFirmwareSettingLineCount()
        {
            InitializeComponent();
            Common.DrawColors(this);
            Common.SetTitle(this, "Line Count");
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            lbLineCount.Text = "Line Count = " + Program.FMain.LineCount.ToString();

            if (Program.FMain.LineCount == 49)
            {
                lbPress.Text = "Press One More Time";
                lbPress.ForeColor = Color.DarkRed;
            }
            else if (Program.FMain.LineCount == 1)
            {
                lbPress.Text = "Reset Properly";
                lbPress.ForeColor = Color.Green;
            }
            else
            {
                lbPress.Text = "Press Again";
                lbPress.ForeColor = Color.DarkRed;
            }

        }


    }
}
