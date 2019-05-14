using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Raven.Pos.Sales
{
    public partial class QtyInputForm : Form
    {
        private decimal _qty;

        public QtyInputForm()
        {
            InitializeComponent();
        }

        public decimal QtyInput(decimal CurrentQty)
        {
            _qty = CurrentQty;
            txtQty.Text = string.Format(Program.FormatCurrency,CurrentQty);
            ShowDialog();
            return _qty;
        }

        private void InputQty()
        {
            try
            {
                decimal.Parse(txtQty.Text);
            }
            catch
            {
                Program.MsgBox_Show("Qty must be numeric.");
                txtQty.Text = "1";
                return;
            }

            if (txtQty.Text.Trim() == "")
                txtQty.Text = "1";

            if (Convert.ToDecimal(txtQty.Text) <= 0)
                txtQty.Text = "1";
            
            _qty = Convert.ToDecimal(txtQty.Text);
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            InputQty();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                InputQty();
        }

        private void QtyInputForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') 
            {
                e.Handled = true; 
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
