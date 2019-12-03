using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomIPControl
{
    public partial class ipControl: UserControl
    {
        public new bool Enabled
        {
            get
            {
                return base.Enabled;
            }

            set
            {
                base.Enabled = value;

                panBackground.Enabled = value;
                panBackground.BackColor = value ? SystemColors.ControlLightLight : SystemColors.Control;
                tb1.Enabled = value;
                tb2.Enabled = value;
                tb3.Enabled = value;
                tb4.Enabled = value;
            }
        }
        public override string Text
        {
            get
            {
                return tb1.Text + "." + tb2.Text + "." + tb3.Text + "." + tb4.Text;
            }

            set
            {
                if (!value.Contains(".")) return;

                string[] parts = value.Split('.');

                if (parts.Length != 4) return;

                tb1.Text = parts[0];
                tb2.Text = parts[1];
                tb3.Text = parts[2];
                tb4.Text = parts[3];

            }
        }
        
        public void ipControl_FocusChange(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox tb = (TextBox)sender;

                if (string.IsNullOrEmpty(tb.Text)) return;

                int val = int.Parse(tb.Text);
                if (!tb.Focused)
                {
                    if (val > 255) tb.Text = "255";
                }

                if (tb.Focused)
                {
                    tb.SelectAll();
                }
            }
        }

        public void ipControl_DigitsOnly(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)8)
            {
                if(sender is TextBox)
                {
                    TextBox tb = (TextBox)sender;

                    if (string.IsNullOrEmpty(tb.Text))
                    {
                        if (tb2.Focused)
                        {
                            tb1.Focus();
                            return;
                        }

                        if (tb3.Focused)
                        {
                            tb2.Focus();
                            return;
                        }

                        if (tb4.Focused)
                        {
                            tb3.Focus();
                            return;
                        }
                    }

                }
            }

            if ((e.KeyChar == '.'))
            {
                e.Handled = true;

                if (tb1.Focused)
                {
                    tb2.Focus();
                    return;
                }

                if (tb2.Focused)
                {
                    tb3.Focus();
                    return;
                }

                if (tb3.Focused)
                {
                    tb4.Focus();
                    return;
                }
            }

        }


        public ipControl()
        {
            InitializeComponent();
            
        }
    }
}
