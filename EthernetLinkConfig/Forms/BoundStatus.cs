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
    public partial class BoundStatus : Form
    {
        public BoundStatus()
        {
            InitializeComponent();

            lb3520.Text = "Port 3520: " + UdpReceiverClass3520.StatusString;
            lb6699.Text = "Port 6699: " + UdpReceiverClass6699.StatusString;

            if(UdpReceiverClassCustom.ListenOn == 0)
            {
                lbCustom.Text = "Custom Port Not in Use";
            }
            else
            {
                lbCustom.Text = "Port " + UdpReceiverClassCustom.ListenOn + ": " + UdpReceiverClassCustom.StatusString;
            }

        }
    }
}
