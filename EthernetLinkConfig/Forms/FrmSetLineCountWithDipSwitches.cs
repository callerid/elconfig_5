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
    public partial class FrmSetLineCountWithDipSwitches : Form
    {
        public FrmSetLineCountWithDipSwitches()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            FrmMain.AskedToChangeLineCount = true;
            Close();
        }
    }
}
