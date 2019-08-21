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
    public partial class FrmBlockingConfig : Form
    {
        public FrmBlockingConfig(bool blocking_enabled)
        {
            InitializeComponent();

            SetEnabledDisabled(blocking_enabled);

        }

        public void SetEnabledDisabled(bool enabled)
        {
            if (enabled)
            {
                btnEnableDisableCallBlocking.Text = "Disable";
            }
            else
            {
                btnEnableDisableCallBlocking.Text = "Enable";
            }
        }

        private void tbNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char key_pressed = e.KeyChar;
            if (!(Char.IsDigit(key_pressed)) && key_pressed != 8)
            {
                e.Handled = true;
            }
        }

        private bool AlreadyOnList(string text)
        {
            bool found = false;
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                if (row.Cells[1].Value.ToString() == text)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {

            if (dgvList.Rows.Count >= 40)
            {
                Common.MessageBox("At max amout of numbers.", "Max Reached");
                return;
            }

            if (AlreadyOnList(tbNumber.Text))
            {

                Common.MessageBox("Number already in list.", "Duplicate");
                return;
            }

            string toSend = "^^Id-N" + tbNumber.Text + "\r\n";

            FrmMain.SendUdp(toSend, FrmMain.LinkPorts.MainPort);
            Common.WaitFor(250);
            Common.AddToLogFile("Command: " + toSend.ToUpper(), "", "");
            RefreshList();
        }

        private void ClearList(object sender, EventArgs e)
        {
            FrmMain.SendUdp("^^Id-Q", FrmMain.LinkPorts.MainPort);
            Common.WaitFor(250);
            Common.AddToLogFile("Command: Cleared block list", "", "");
            RefreshList();

        }

        private void btnBlockPrivate_Click(object sender, EventArgs e)
        {

            if (AlreadyOnList("Private Calls"))
            {

                Common.MessageBox("Number already in list.", "Duplicate");
                return;
            }

            if (dgvList.Rows.Count >= 40)
            {
                Common.MessageBox("At max amout of numbers.", "Max Reached");
                return;
            }

            FrmMain.SendUdp("^^Id-N77" + "\r\n", FrmMain.LinkPorts.MainPort);
            Common.WaitFor(250);
            Common.AddToLogFile("Command: Block Private", "", "");
            RefreshList();
        }

        private void btnBlockOutOfArea_Click(object sender, EventArgs e)
        {

            if (AlreadyOnList("Out-Of-Area Calls"))
            {

                Common.MessageBox("Number already in list.", "Duplicate");
                return;
            }

            if (dgvList.Rows.Count >= 40)
            {
                Common.MessageBox("At max amout of numbers.", "Max Reached");
                return;
            }

            FrmMain.SendUdp("^^Id-N66" + "\r\n", FrmMain.LinkPorts.MainPort);
            Common.WaitFor(250);
            Common.AddToLogFile("Command: Block Out-Of-Area", "", "");
            RefreshList();
        }

        private void RefreshList()
        {
            dgvList.Rows.Clear();
            FrmMain.SendUdp("^^Id-J", FrmMain.LinkPorts.MainPort);
            Common.WaitFor(250);
        }

        public void AddRowToList(string number)
        {
            dgvList.Rows.Add();
            dgvList.Rows[dgvList.Rows.Count - 1].Cells[0].Value = dgvList.Rows.Count;
            dgvList.Rows[dgvList.Rows.Count - 1].Cells[1].Value = number;
        }

        private void rbBlock_Click(object sender, EventArgs e)
        {
            FrmMain.SendUdp("^^Id-K" + "\r\n", FrmMain.LinkPorts.MainPort);
            Common.WaitFor(250);
            Common.AddToLogFile("Command: Blocking numbers on list", "", "");
            Program.FMain.btnRetrieveToggles_Click(new object(), new EventArgs());

        }

        private void rbAllow_Click(object sender, EventArgs e)
        {
            FrmMain.SendUdp("^^Id-k" + "\r\n", FrmMain.LinkPorts.MainPort);
            Common.WaitFor(250);
            Common.AddToLogFile("Command: Allowing ONLY numbers on list", "", "");
            Program.FMain.btnRetrieveToggles_Click(new object(), new EventArgs());
        }

        private void btnEnableDisableCallBlocking_Click(object sender, EventArgs e)
        {
            if(btnEnableDisableCallBlocking.Text == "Disable")
            {
                FrmMain.SendUdp("^^Id-U", FrmMain.LinkPorts.MainPort);
                Common.WaitFor(250);
            }
            else
            {
                FrmMain.SendUdp("^^Id-u", FrmMain.LinkPorts.MainPort);
                Common.WaitFor(250);
            }

            Program.FMain.btnRetrieveToggles_Click(new object(), new EventArgs());
        }

        private void timerAutoLoad_Tick(object sender, EventArgs e)
        {
            timerAutoLoad.Enabled = false;
            timerAutoLoad.Stop();
            RefreshList();
        }
    }
}
