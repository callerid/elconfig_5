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
    public partial class FrmMultipleUnits : Form
    {
        public FrmMultipleUnits()
        {
            InitializeComponent();
            Common.DrawColors(this);
            Common.SetTitle(this, "2+ Units");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
