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
    public partial class FrmUniCast : Form
    {
        public FrmUniCast()
        {
            InitializeComponent();
            Common.DrawColors(this);
            Common.SetTitle(this, "Setup Uni-cast");

            ipSendIPAddress.Text = FrmMain.SendToIP;
        }

        private void btnUseBroadcast_Click(object sender, EventArgs e)
        {
            ipSendIPAddress.Text = "255.255.255.255";
        }

        private void btnUseFound_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FrmMain.FoundIP))
            {
                ipSendIPAddress.Text = FrmMain.FoundIP;
            }
            else
            {
                Common.MessageBox("Unit IP Address has not been discovered.", "Unknown IP");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FrmMain.SendToIP = ipSendIPAddress.Text;
            Close();
        }
    }
}
