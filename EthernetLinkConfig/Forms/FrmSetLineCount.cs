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
    public partial class FrmSetLineCount : Form
    {
        public static bool Loading = true;

        public FrmSetLineCount(int lineCnt, bool askingToChange = false)
        {
            Loading = true;
            InitializeComponent();
            cbLineCount.SelectedIndex = 0;
            
            lbLineCount.Text = lineCnt.ToString().PadLeft(2, '0');
            cbLineCount.Text = lineCnt.ToString();

            lbAskingChange.Visible = askingToChange;

            if (askingToChange) btnCancel.Text = "Ignore";

            lbAskingChange.Text = lbAskingChange.Text.Replace("[X]", lineCnt.ToString().PadLeft(2, '0'));

            Loading = false;

        }

        public void DisplayNewLineCount(int newLineCnt)
        {
            lbAskingChange.Text = "Starting line number on the unit is [X].\nIf only one Caller ID device is installed, the\nline number needs to be changed to 1.";
            lbAskingChange.Text = lbAskingChange.Text.Replace("[X]", newLineCnt.ToString().PadLeft(2, '0'));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbLineCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Loading) return;
            int previous_lineCnt = Program.FMain.LineCount;
            SetLineCount(int.Parse(cbLineCount.Text.ToString()));
            Common.AddToLogFile("Line Count", previous_lineCnt.ToString(), cbLineCount.Text.ToString());
            Common.WaitFor(250);
            FrmMain.AskedToChangeLineCount = true;
            RetrieveToggles();

            lbAskingChange.Visible = int.Parse(cbLineCount.Text.ToString()) > 8;

            btnCancel.Visible = int.Parse(cbLineCount.Text.ToString()) > 8;
            btnOK.Text = "Close";
        }

        private void RetrieveToggles()
        {
            FrmMain.SendUdp("^^Id-V", FrmMain.LinkPorts.MainPort);
            Common.WaitFor(250);
            FrmMain.SendUdp("^^Id-V", FrmMain.LinkPorts.MainPort);
            Common.WaitFor(250);
            FrmMain.SendUdp("^^Id-V", FrmMain.LinkPorts.MainPort);
            Common.WaitFor(250);
            FrmMain.SendUdp("^^Id-V", FrmMain.LinkPorts.MainPort);
            Common.WaitFor(250);
        }

        private void SetLineCount(int line)
        {
            string sendString = "";
            switch (line)
            {

                case 1:
                    sendString = "^^Id-N0000007701\r\n";
                    break;

                case 5:
                    sendString = "^^Id-N0000007705\r\n";
                    break;

                case 9:
                    sendString = "^^Id-N0000007709\r\n";
                    break;

                case 17:
                    sendString = "^^Id-N0000007711\r\n";
                    break;

                case 21:
                    sendString = "^^Id-N0000007715\r\n";
                    break;

                case 25:
                    sendString = "^^Id-N0000007719\r\n";
                    break;

                case 33:
                    sendString = "^^Id-N0000007721\r\n";
                    break;
            }

            FrmMain.SendUdp(sendString, FrmMain.LinkPorts.MainPort);

            Common.MessageBox("Command Sent.", "Finished");

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
