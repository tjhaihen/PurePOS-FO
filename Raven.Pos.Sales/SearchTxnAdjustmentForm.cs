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
    public partial class SearchTxnAdjustmentForm : Form
    {
        private MutationHd _MutationHd;
        private LoginInfo _loginInfo;
        string strUserGroupID = "administrator";
        string strInventoryTxnID;
        public SearchTxnAdjustmentForm()
        {
            InitializeComponent();
        }
        public MutationHd Search(LoginInfo loginInfo, string InventoryTxnID)
        {
            _loginInfo = loginInfo;
            strInventoryTxnID = InventoryTxnID;
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
            return _MutationHd;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectTxnNoAdjust();
        }
     
        private void SelectTxnNoAdjust()
        {
            if (grdAdjustment.RowCount > 0)
            {
                _MutationHd = new MutationHd { TxnNo = grdAdjustment.SelectedRows[0].Cells["TxnNo"].Value.ToString(),  InventoryTxnID = strInventoryTxnID.Trim() };
                _MutationHd.SelectOne();
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void PopulateGrid()
        {
            grdAdjustment.SuspendLayout();
            grdAdjustment.AutoGenerateColumns = false;

            var adjustment = new MutationHd();
            var dtb = new DataTable();
            if (_loginInfo.UserGroupID.Trim().ToUpper() == strUserGroupID.ToUpper())
                dtb = adjustment.SelectBySTXnNo(strInventoryTxnID, string.Format(Program.FormatDateISO, dtpTransactionDateFrom.Value.Date), string.Format(Program.FormatDateISO, dtpTransactionDateTo.Value.Date), txtSTXnNoFrom.Text, txtSTXnNoTo.Text, Program.SelectOneByCommonSetting("MaxRecord"));
            else
                dtb = adjustment.SelectBySTXnNo(strInventoryTxnID, string.Format(Program.FormatDateISO, dtpTransactionDateFrom.Value.Date), string.Format(Program.FormatDateISO, dtpTransactionDateTo.Value.Date), txtSTXnNoFrom.Text, txtSTXnNoTo.Text, Program.SelectOneByCommonSetting("MaxRecord"), _loginInfo.UserID);
            
            grdAdjustment.DataSource = dtb;

            grdAdjustment.ResumeLayout();
            adjustment.Dispose();
            adjustment = null;
        }

        private void grdAdjustment_DoubleClick(object sender, EventArgs e)
        {
            SelectTxnNoAdjust();
        }

        private void grdAdjustment_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    e.Handled = true;
                    break;
            }
        }

        private void grdAdjustment_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SelectTxnNoAdjust();
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
                    if (grdAdjustment.RowCount > 0)
                    {
                        grdAdjustment.Focus();
                    }
                    break;
                case Keys.Down:
                    if (grdAdjustment.RowCount > 0)
                    {
                        grdAdjustment.Focus();
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
