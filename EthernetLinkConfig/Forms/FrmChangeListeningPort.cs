﻿using System;
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
            Program.FMain.StartCustomReceiver(int.Parse(tbDestPort.Text));
            FrmMain.LinkPort = int.Parse(tbDestPort.Text);
        }
    }
}
