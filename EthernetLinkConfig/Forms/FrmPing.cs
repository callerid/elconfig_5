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
    public partial class FrmPing : Form
    {
        public FrmPing()
        {
            InitializeComponent();
            Common.DrawColors(this);
            Common.SetTitle(this,"Ping");
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            panResponse.BackColor = Color.Gainsboro;
            lbResponse.BackColor = Color.Gainsboro;
            lbResponse.ForeColor = Color.Black;
            lbResponse.Text = "Pinging IP : Attempt[1]";
            ipToPing.Enabled = false;
            btnPing.Enabled = false;
            Common.WaitFor(50);
            
            bool result = Common.PingHost(ipToPing.Text);

            int tries = 2;
            while (!result)
            {
                lbResponse.Text = "Pinging IP : Attempt[" + tries.ToString() + "]";
                Common.WaitFor(50);
                result = Common.PingHost(ipToPing.Text);
                if (tries > 3) break;
                tries += 1;
            }

            if (result)
            {
                lbResponse.Visible = true;
                panResponse.BackColor = Color.LightGreen;
                lbResponse.BackColor = Color.LightGreen;
                lbResponse.ForeColor = Color.DarkGreen;
                lbResponse.Text = "IP Address Responded";
            }
            else
            {
                panResponse.BackColor = Color.Pink;
                lbResponse.BackColor = Color.Pink;
                lbResponse.ForeColor = Color.Red;
                lbResponse.Text = "IP FAILED to Respond";
            }

            ipToPing.Enabled = true;
            btnPing.Enabled = true;
        }
    }
}
