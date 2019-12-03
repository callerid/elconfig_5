using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomIPControl
{
    public partial class macControl : UserControl
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
                tb5.Enabled = value;
                tb6.Enabled = value;
            }
        }
        public override string Text
        {
            get
            {
                return tb1.Text + "-" + tb2.Text + "-" + tb3.Text + "-" + tb4.Text + "-" + tb5.Text + "-" + tb6.Text;
            }

            set
            {
                string[] parts;

                if (value.Contains('.'))
                {
                    parts = value.Split('.');
                }
                else if (value.Contains(':'))
                {
                    parts = value.Split(':');
                }
                else
                {
                    return;
                }

                if (parts.Length != 6) return;

                tb1.Text = parts[0];
                tb2.Text = parts[1];
                tb3.Text = parts[2];
                tb4.Text = parts[3];
                tb5.Text = parts[4];
                tb6.Text = parts[5];

            }
        }

        public void ipControl_FocusChange(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox tb = (TextBox)sender;

                if (string.IsNullOrEmpty(tb.Text)) return;

                if (tb.Focused)
                {
                    tb.SelectAll();
                }
            }
        }

        public void ipControl_HexOnly(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (!((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f')) && (e.KeyChar != '-') && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)8)
            {
                if (sender is TextBox)
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

                        if (tb5.Focused)
                        {
                            tb4.Focus();
                            return;
                        }

                        if (tb6.Focused)
                        {
                            tb5.Focus();
                            return;
                        }
                    }

                }
            }

            if ((e.KeyChar == '-'))
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

                if (tb4.Focused)
                {
                    tb5.Focus();
                    return;
                }

                if (tb5.Focused)
                {
                    tb6.Focus();
                    return;
                }
            }

        }

        public macControl()
        {
            InitializeComponent();
        }
    }
}
