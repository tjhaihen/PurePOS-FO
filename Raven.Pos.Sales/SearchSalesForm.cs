using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Raven.BussinessRules;

namespace Raven.Pos.Sales
{
    public partial class SearchSalesForm : Form
    {
        private SalesUnitHd _salesUnitHd;
        private LoginInfo _loginInfo;
        string strUserGroupID = "administrator";
        public SearchSalesForm()
        {
            InitializeComponent();
        }
        public SalesUnitHd Search(LoginInfo loginInfo)
        {
            _loginInfo = loginInfo;

            if (_loginInfo.UserGroupID.Trim().ToUpper() == strUserGroupID.ToUpper())
            {
                dtpTransactionDateFrom.Enabled = true;
                dtpTransactionDateTo.Enabled = true;
            }
            else
            {
                dtpTransactionDateFrom.Enabled = false;
                dtpTransactionDateTo.Enabled = false;
            }                

            ShowDialog();
            return _salesUnitHd;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectSales();
        }
     
        private void SelectSales()
        {
            if (grdSales.RowCount > 0)
            {
                _salesUnitHd = new SalesUnitHd { STxnNo = grdSales.SelectedRows[0].Cells["colSTxnNo"].Value.ToString() };
                _salesUnitHd.SelectOne();
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void PopulateGrid()
        {
            grdSales.SuspendLayout();
            grdSales.AutoGenerateColumns = false;

            var sales = new SalesUnitHd();
            var dtb = new DataTable();
            if (_loginInfo.UserGroupID.Trim().ToUpper() == strUserGroupID.ToUpper())
                dtb = sales.SelectBySTXnNo(string.Format(Program.FormatDateISO, dtpTransactionDateFrom.Value.Date), string.Format(Program.FormatDateISO, dtpTransactionDateTo.Value.Date), txtSTXnNoFrom.Text, txtSTXnNoTo.Text, Program.SelectOneByCommonSetting("MaxRecord"));
            else
                dtb = sales.SelectBySTXnNo(string.Format(Program.FormatDateISO, dtpTransactionDateFrom.Value.Date), string.Format(Program.FormatDateISO, dtpTransactionDateTo.Value.Date), txtSTXnNoFrom.Text, txtSTXnNoTo.Text, Program.SelectOneByCommonSetting("MaxRecord"), _loginInfo.UserID);
            
            grdSales.DataSource = dtb;

            grdSales.ResumeLayout();
            sales.Dispose();
            sales = null;
        }
        
        private void grdSales_DoubleClick(object sender, EventArgs e)
        {
            SelectSales();
        }

        private void grdSales_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SelectSales();
                    break;
            }
        }

        private void grdSales_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    e.Handled = true;
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void txtSTXnNoFrom_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    PopulateGrid();
                    if (grdSales.RowCount > 0)
                    {
                        grdSales.Focus();
                    }
                    break;
                case Keys.Down:
                    if (grdSales.RowCount > 0)
                    {
                        grdSales.Focus();
                    }
                    break;
            }
        }

        private void txtSTXnNoTo_KeyUp(object sender, KeyEventArgs e)
        {
            txtSTXnNoFrom_KeyUp(sender, e);
        }

        private void SearchSalesForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private void SearchSalesForm_Load(object sender, EventArgs e)
        {
            dtpTransactionDateFrom.Value = BussinessRules.ID.GetDateDBServer();
            dtpTransactionDateTo.Value = BussinessRules.ID.GetDateDBServer();
        }

        private void dtpTransactionDate_KeyUp(object sender, KeyEventArgs e)
        {
            txtSTXnNoFrom_KeyUp(sender, e);
        }

    }
}
