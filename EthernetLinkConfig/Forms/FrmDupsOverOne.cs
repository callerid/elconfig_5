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
    public partial class FrmDupsOverOne : Form
    {
        public FrmDupsOverOne(int numOfDups)
        {
            InitializeComponent();
            Common.DrawColors(this);
            Common.SetTitle(this, "Use Duplicates?");

            lbMessage.Text = lbMessage.Text.Replace("[X]", numOfDups.ToString());
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnResetDupsToOne_Click(object sender, EventArgs e)
        {
            // Set to single records
            string hexStr = 1.ToString("X").PadLeft(2, '0');
            FrmMain.SendUdp("^^IdO" + hexStr, FrmMain.LinkPorts.MainPort);
            Common.MessageBox("Command sent.", "Finished");
            Close();
        }
    }
}
