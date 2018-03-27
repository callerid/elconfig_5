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
    public partial class FrmChangeListeningPort : Form
    {
        public FrmChangeListeningPort()
        {
            InitializeComponent();
            Common.DrawColors(this);
            Common.SetTitle(this, "Listen On?");
        }

        private void btnChangePort_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDestPort.Text)) return;

            if (!(string.IsNullOrEmpty(Program.FMain.tbDestPort.Text)))
            {
                string message = "The Network Port number set on the unit is " + Program.FMain.tbDestPort.Text + ". Change the port number on the unit before changing the listening port of the application.";

                MessageBox.Show(new Form() { TopMost = true }, message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            Program.FMain.StartCustomReceiver(int.Parse(tbDestPort.Text));
            FrmMain.LinkPorts.MainPort = int.Parse(tbDestPort.Text);
            Close();
        }

        private void PreventAlphaCharacters(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
