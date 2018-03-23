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
    public partial class FrmDuplicateTracking : Form
    {
        public FrmDuplicateTracking()
        {
            InitializeComponent();
            Common.DrawColors(this);
            Common.SetTitle(this, "Dups Tracking");
        }

        public void AddToCommData(string reception, int secs)
        {
            dgvCommData.Rows.Add();
            dgvCommData.Rows[dgvCommData.Rows.Count - 1].Cells[0].Value = reception;
            dgvCommData.Rows[dgvCommData.Rows.Count - 1].Cells[1].Value = secs.ToString();
            dgvCommData.FirstDisplayedScrollingRowIndex = dgvCommData.Rows.Count - 1;
        }

        public void RefreshDups(Dictionary<string,int> pr)
        {
            dgvCommData.Rows.Clear();

            foreach (string key in pr.Keys)
            {
                AddToCommData(key, pr[key]);
            }
        }
    }
}
