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
    public partial class FrmSendDups : Form
    {
        public FrmSendDups()
        {
            InitializeComponent();
            Common.DrawColors(this);
            Common.SetTitle(this, "Dups");
            ndNumberOfPackets.Value = FrmMain.Dups;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int intVal = int.Parse(ndNumberOfPackets.Value.ToString());
            string hexStr = intVal.ToString("X").PadLeft(2,'0');

            Program.FMain.HaveShownDupResetWindow = true;
            int previous_dups = FrmMain.Dups;
            FrmMain.SendUdp("^^IdO" + hexStr, FrmMain.LinkPorts.MainPort);
            Common.AddToLogFile("Duplicates", previous_dups.ToString(), intVal.ToString());

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
