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
    public partial class FrmLog : Form
    {
        public FrmLog()
        {
            InitializeComponent();
            Common.SetTitle(this, "Change Log");
            rtbLog.Text = Common.ReadLog();
        }
    }
}
