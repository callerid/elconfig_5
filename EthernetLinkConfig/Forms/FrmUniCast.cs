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

            PopulateList();

        }

        private void PopulateList()
        {
            tvFoundIPs.Nodes.Clear();
            foreach (string ip in FrmMain.FoundUnitIPs)
            {
                string entry = ip + (FrmMain.LinkPorts.MultipleIPsExists(ip) ? " (Multiple Units)" : "");
                tvFoundIPs.Nodes.Add(entry);
            }
        }

        private void btnUseBroadcast_Click(object sender, EventArgs e)
        {
            ipSendIPAddress.Text = "255.255.255.255";
        }

        private void btnUseFound_Click(object sender, EventArgs e)
        {
            if (FrmMain.FoundUnitIPs.Count > 0)
            {
                ipSendIPAddress.Text = FrmMain.FoundUnitIPs[0];
            }
            else
            {
                Common.MessageBox("Unit IP Address has not been discovered.", "Unknown IP");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string selected_ip = ipSendIPAddress.Text.Replace(" (Multiple Units)", "");

            if (!(Common.IsValidIP(selected_ip)))
            {
                Common.MessageBox("Invalid IP Address", "Invalid", true);
                return;
            }

            if (FrmMain.LinkPorts.MultipleIPsExists(selected_ip))
            {
                MessageBox.Show("Two or more units on same IP address.  Power one unit at a time to configure. Use 'Refresh' button to update unit list.", "Multiple Units");
                return;
            }

            FrmMain.SendToIP = selected_ip;
            Program.FMain.HaveShownMultipleUnitMessage = false;

            int new_port = FrmMain.LinkPorts.GetPortOfIP(selected_ip);
            if(new_port != -1)
            {
                FrmMain.LinkPorts.SetMainPort(new_port, true);
            }

            Program.FMain.timerRefresher.Interval = 10;

            Close();
        }

        private void tvFoundIPs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string ip = tvFoundIPs.SelectedNode.Text.Replace(" (Multiple Units)", "");;
            ipSendIPAddress.Text = ip;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FrmMain.LinkPorts.ResetPorts();

            FrmMain.SendToIP = "255.255.255.255";

            FrmMain.SendUdp("^^IdX", 6699);
            Common.WaitFor(250);
            FrmMain.SendUdp("^^IdX", 3520);

            FrmMain.SendUdp("^^IdX", 6699);
            Common.WaitFor(250);
            FrmMain.SendUdp("^^IdX", 3520);

            Common.MessageBox("Refreshing...", "Refreshing", true, 3000, true);
            PopulateList();
        }
    }
}
