using EthernetLinkConfig.Classes;
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
    public partial class FrmComputerIP : Form
    {
        public FrmTimerMsgBox FApplying = null;

        public FrmComputerIP(string ip, string mac, string cid_ip, string cid_mac)
        {
            InitializeComponent();
            lbIP.Text = ip;
            lbMac.Text = mac;
            lbCIDUnitIP.Text = cid_ip;
            lbCIDUnitMAC.Text = cid_mac.Replace(":", "-");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSetBroadcast_Click(object sender, EventArgs e)
        {

            FApplying = new FrmTimerMsgBox("Applying Changes", "Set To Broadcast", false, false);
            FApplying.Show();

            string ip = "255.255.255.255";
            string mac = "FF-FF-FF-FF-FF-FF";

            FrmMain.SendUdp("^^IdD" + Common.HexFromIP(ip), FrmMain.LinkPorts.MainPort);
            Common.AddToLogFile("Destination IP", lbCIDUnitIP.Text, ip);

            Common.WaitFor(250);

            FrmMain.SendUdp("^^IdC" + mac.Replace(":", "").Replace("-", ""), FrmMain.LinkPorts.MainPort);
            Common.AddToLogFile("Destination MAC", lbCIDUnitMAC.Text.Replace(":", "-"), mac.Replace(":", "-"));

            Program.FMain.timerRefresher.Interval = 10;
            Program.FMain.timerRefresher_Tick(null, null);
            
        }

        private enum PossibleConfigs
        {
            MyComputer,
            Broadcast
        }

        private PossibleConfigs PreviousConfig = PossibleConfigs.MyComputer;

        public void timerRefresher_Tick(object sender, EventArgs e)
        {
            lbCIDUnitIP.Text = Program.FMain.tbDestIP.Text;
            lbCIDUnitMAC.Text = Program.FMain.tbDestMAC.Text.Replace(":", "-");

            if(lbIP.Text == lbCIDUnitIP.Text && lbMac.Text == lbCIDUnitMAC.Text)
            {
                btnSetUnicast.Enabled = false;
                btnSetBroadcast.Enabled = true;
                
                if(PreviousConfig == PossibleConfigs.Broadcast)
                {
                    CloseApplying();
                    PreviousConfig = PossibleConfigs.MyComputer;
                }

            }

            if ("255.255.255.255" == lbCIDUnitIP.Text && "FF-FF-FF-FF-FF-FF" == lbCIDUnitMAC.Text)
            {
                btnSetUnicast.Enabled = true;
                btnSetBroadcast.Enabled = false;

                if(PreviousConfig == PossibleConfigs.MyComputer)
                {
                    CloseApplying();
                    PreviousConfig = PossibleConfigs.Broadcast;
                }

            }
        }

        private void btnSetUnicast_Click(object sender, EventArgs e)
        {
            string ip = lbIP.Text;
            string mac = lbMac.Text;

            if (!Common.IsValidIP(ip))
            {
                MessageBox.Show("Invalid IP.", "Invalid IP");
                return;
            }

            if (MessageBox.Show("Set this computer as the destination IP and MAC address.", "Set Destination to this Computer?", MessageBoxButtons.YesNo) == DialogResult.No) return;

            FApplying = new FrmTimerMsgBox("Applying Changes", "Set To Computer IP/MAC", false, false);
            FApplying.Show();

            FrmMain.SendUdp("^^IdD" + Common.HexFromIP(ip), FrmMain.LinkPorts.MainPort);
            Common.AddToLogFile("Destination IP", lbCIDUnitIP.Text, ip);

            Common.WaitFor(250);

            FrmMain.SendUdp("^^IdC" + mac.Replace(":", "").Replace("-",""), FrmMain.LinkPorts.MainPort);
            Common.AddToLogFile("Destination MAC", lbCIDUnitMAC.Text.Replace(":", "-"), mac.Replace(":", "-"));

            Program.FMain.timerRefresher.Interval = 10;
            Program.FMain.timerRefresher_Tick(null, null);
        }

        public void CloseApplying()
        {
            if(FApplying != null)
            {
                if (FApplying.Visible)
                {
                    FApplying.Close();
                }
            }
        }
    }
}
