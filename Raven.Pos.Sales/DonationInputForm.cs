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
    public partial class DonationInputForm : Form
    {
        private string[] _ArrayDonation = new string[3];
        public DonationInputForm()
        {
            InitializeComponent();
        }

        public string[] DonationInput(bool IsDonationOnly, decimal Amount, decimal grandtotal)
        {
            _ArrayDonation[1] = Convert.ToString(Amount);
            _ArrayDonation[2] = Convert.ToString(grandtotal);
            txtAmount.Text = string.Format(Program.FormatCurrency, Amount);

            if (IsDonationOnly)
                cboDonationType.Enabled = false;
            else
                cboDonationType.Enabled = true;

            PopulateDonationType();
            ShowDialog();
            return _ArrayDonation;
        }

        private void SaveDonationInput()
        {
            try
            {
                decimal.Parse(txtAmount.Text);
            }
            catch
            {
                Program.MsgBox_Show("Donation Amount must be numeric.");
                txtAmount.Text = string.Format(Program.FormatCurrency,0);
                return;
            }

            if (txtAmount.Text.Trim() == "")
            {
                Program.MsgBox_Show("Donation Amount connot empty.");
                return;
            }

            if (Convert.ToDecimal(txtAmount.Text) <= 0)
            {
                Program.MsgBox_Show("Donation Amount must be greater than 0.");
                return;
            }

            if (_ArrayDonation[0].Trim() == "01")
            {
                if (Convert.ToDecimal(txtAmount.Text.Trim()) <= Convert.ToDecimal(_ArrayDonation[2].Trim()))
                {
                    Program.MsgBox_Show("Donation Amount must be greater than purchase grand total.");
                    return;
                }

                _ArrayDonation[1] = Convert.ToString(Convert.ToDecimal(txtAmount.Text.Trim()) - Convert.ToDecimal(_ArrayDonation[2].Trim())); // Donation Amount
            }
            else
                _ArrayDonation[1] = txtAmount.Text.Trim(); // Donation Amount

            _ArrayDonation[0] = Convert.ToString(cboDonationType.SelectedValue); // Donation Type
            Close();
        }

        private void CancelDonationInput()
        {
            _ArrayDonation[1] = "-1";
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDonationInput();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelDonationInput();
        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                    SaveDonationInput();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void DonationInputForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CancelDonationInput();
            }
        }

        private void PopulateDonationType()
        {
            Program.PopulateByCommonSetting(cboDonationType, "DonationType");
            cboDonationType.SelectedValue = "00";
        }

        private void cboDonationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ArrayDonation[0] = cboDonationType.SelectedValue.ToString();
        }
    }
}
