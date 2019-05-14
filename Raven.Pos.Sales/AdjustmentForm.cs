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
    public partial class AdjustmentForm : Form
    {
        private LoginInfo _loginInfo;  
        public AdjustmentForm()
        {
            InitializeComponent();            
        }
        public void ShowDialogAdjustment(LoginInfo loginInfo)
        {
            _loginInfo = loginInfo;
            PopulateInventoryTxn();
            PopulateWarehouse();
            PopulateUnit();
            Program.PopulateByCommonSetting(cboReason, "AdjustReason");
            ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Focus();
            if (_save())
            {
                _Clear();
                openTxnNo();
                txtItemID.Focus();
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_Deletedt(txtID.Text.Trim()))
            {
                _Clear();
                PopulateGrid();
            }
        }

        private bool _save()
        {
            bool _retval = false;

            //if (txtTxnNo.Text.Trim() == string.Empty)
            //{
            //    Program.MsgBox_Show("Transaction no. cannot empty.");
            //    return _retval;
            //}

            if (txtItemSeqNo.Text.Trim() == string.Empty)
            {
                Program.MsgBox_Show("Item cannot empty.");
                return _retval;
            }

            if (txtItemName.Text.Trim() == string.Empty)
            {
                Program.MsgBox_Show("Item Name cannot empty.");
                return _retval;
            }

            if (Convert.ToString(cboItemUnit.SelectedValue) == string.Empty || Convert.ToString(cboItemUnit.SelectedValue) == null)
            {
                Program.MsgBox_Show("Item Unit cannot empty.");
                return _retval;
            }

            try
            {
                decimal.Parse(txtItemFactor.Text.Trim());
            }
            catch
            {
                Program.MsgBox_Show("Item Factor must be numeric.");
                return _retval;
            }

            if (Convert.ToDecimal(txtItemFactor.Text.Trim()) < 1)
            {
                Program.MsgBox_Show("Item Factor must be equal or greater than 1");
                return _retval;
            }

            try
            {
                decimal.Parse(txtQty.Text.Trim());
            }
            catch
            {
                Program.MsgBox_Show("Qty must be numeric.");
                return _retval;
            }

            if (Convert.ToDecimal(txtQty.Text.Trim()) < 1)
            {
                Program.MsgBox_Show("Qty must be equal or greater than 1");
                return _retval;
            }

            bool isNew = true;
            var omhd = new MutationHd();
            omhd.InventoryTxnID = Convert.ToString(cboTxnType.SelectedValue).Trim();
            omhd.TxnNo = txtTxnNo.Text.Trim();
            if (omhd.SelectOne().Rows.Count > 0)
            {
                isNew = false;
            }
            else
            {
                string prefix;
                if (Convert.ToString(cboTxnType.SelectedValue).Trim() == "111")
                    prefix = "AJM";
                else
                    prefix = "AJP";
                isNew = true;
                omhd.TxnNo = BussinessRules.ID.GenerateIDNumber("MutationHD", "TxnNo", prefix, "Where txnNo like '" + prefix + "%'");
            }
            omhd.TxnDate = dtpTxnDate.Value.Date;
            omhd.AdjustmentReasonID = Convert.ToString(cboReason.SelectedValue).Trim();
            omhd.Description = txtDescription.Text.Trim();
            omhd.SourceWHID = Convert.ToString(cboWarehouse.SelectedValue);
            omhd.SourceUnitID = Convert.ToString(cboUnit.SelectedValue);
            omhd.DestinationWHID = "";
            omhd.DestinationUnitID = "";
            omhd.UserInsert = _loginInfo.UserID;
            omhd.UserUpdate = _loginInfo.UserID;

            if (isNew)
            {
                if (omhd.Insert())
                    txtTxnNo.Text = omhd.TxnNo;
            }
            else
                omhd.Update();

            omhd.Dispose();
            omhd = null;

            var omdt = new MutationDt();
            omdt.InventoryTxnID = Convert.ToString(cboTxnType.SelectedValue).Trim();
            omdt.ID = txtID.Text.Trim();
            if (omdt.SelectOne().Rows.Count > 0)
            {
                isNew = false;
            }
            else
            {
                string prefix;
                if (Convert.ToString(cboTxnType.SelectedValue).Trim() == "111")
                    prefix = "AJM";
                else
                    prefix = "AJP";
                isNew = true;
                omdt.ID = BussinessRules.ID.GenerateIDNumber("MutationDt", "ID", prefix, "Where ID like '" + prefix + "%'");
            }
            omdt.ItemSeqNo = txtItemSeqNo.Text.Trim();
            omdt.TxnNo = txtTxnNo.Text.ToUpper().Trim();
            omdt.ItemUnitID = Convert.ToString(cboItemUnit.SelectedValue).Trim();
            omdt.ItemFactor = Convert.ToDecimal(txtItemFactor.Text.Trim());
            if (Convert.ToString(cboTxnType.SelectedValue) == "111")
                omdt.Qty = Convert.ToDecimal(txtQty.Text.Trim()) * -1;
            else
                omdt.Qty = Convert.ToDecimal(txtQty.Text.Trim());
            omdt.UserInsert = _loginInfo.UserID;
            omdt.UserUpdate = _loginInfo.UserID;

            if (isNew)
            {
                if (omdt.Insert())
                    txtID.Text = omdt.ID;
            }
            else
                omdt.Update();

            omdt.Dispose();
            omdt = null;

            _retval = true;
            return _retval;
        }
        
        private bool _Deletedt(string _ID)
        {
            bool _retval = false;

            if (_ID == string.Empty || _ID == null)
            {
                Program.MsgBox_Show("Nothing to Delete");
                return _retval;
            }

            int countDt = 0;
            var omdt = new MutationDt();
            omdt.ID = _ID;
            omdt.UserDelete = _loginInfo.UserID;
            omdt.Delete();
            
            omdt.TxnNo =  txtTxnNo.Text.Trim();
            countDt = omdt.SelectAllByTxnNo().Rows.Count;
            
            omdt.Dispose();
            omdt = null;

            if (countDt == 0)
            {
                _DeleteHd();
            }
            _retval = true;
            Program.MsgBox_Show("Deleted is Successfully");
            return _retval;
        }

        private bool _DeleteHd()
        {
            bool _retval = false;
            var omhd = new MutationHd();
            omhd.TxnNo = txtTxnNo.Text.Trim();
            omhd.UserDelete = _loginInfo.UserID;
            omhd.Delete();
            omhd.Dispose();
            omhd = null;
            return _retval;
        }
        
        private void SelectItem()
        {
            if (grdItem.RowCount > 0)
            {
                txtID.Text = grdItem.SelectedRows[0].Cells["ID"].Value.ToString();
                txtItemSeqNo.Text = grdItem.SelectedRows[0].Cells["ItemSeqNo"].Value.ToString();
                PopulateItemUnit();
                txtItemID.Text = grdItem.SelectedRows[0].Cells["ItemID"].Value.ToString();
                txtItemName.Text = grdItem.SelectedRows[0].Cells["ItemName"].Value.ToString();
                cboItemUnit.SelectedValue = grdItem.SelectedRows[0].Cells["ItemUnitID"].Value.ToString();
                txtItemFactor.Text = grdItem.SelectedRows[0].Cells["ItemFactor"].Value.ToString();
                txtQty.Text = grdItem.SelectedRows[0].Cells["Qty"].Value.ToString();
            }
        }

        private void PopulateGrid()
        {
            grdItem.SuspendLayout();
            grdItem.AutoGenerateColumns = false;

            var oMutationDt = new MutationDt();
            oMutationDt.TxnNo = txtTxnNo.Text.Trim();
            grdItem.DataSource= oMutationDt.SelectAllByTxnNo().DefaultView;
            oMutationDt.Dispose();
            oMutationDt = null;

            grdItem.ResumeLayout();
        }

        private void grdItem_DoubleClick(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void grdItem_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SelectItem();
                    break;
                
                case Keys.Delete:
                    if (_Deletedt(grdItem.SelectedRows[0].Cells["ID"].Value.ToString()))
                    {
                        _Clear();
                        PopulateGrid();
                    }
                    break;
            }
        }

        private void grdItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    e.Handled = true;
                    break;
            }
        }

        private void AdjustmentForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    if (btnApprove.Enabled)
                    {
                        Approval();
                    }                    
                    break;

                case Keys.F3:
                    if (btnSearchItem.Enabled)
                    {
                        Item item;
                        using (var frm = new SearchItemForm())
                        {
                            item = frm.Search();
                        }
                        if (item != null)
                        {
                            txtItemID.Focus();
                            txtItemID.Text = item.ItemID;
                            txtItemSeqNo.Text = item.ItemSeqNo;
                            cboItemUnit.Focus();
                        }
                        else
                        {
                            txtItemID.Text = string.Empty;
                            txtItemSeqNo.Text = string.Empty;
                            txtItemID.Focus();
                        }
                    }                    
                    break;

                case Keys.F4:
                    txtTxnNo.Focus();
                    SearchAdjustTxno();
                    break;

                case Keys.F5:
                    if (btnClearAll.Enabled)
                    {
                        _ClearAll();
                    }                    
                    break;

                case Keys.F6:
                    if (btnDeleteAll.Enabled)
                    {
                        if (_DeleteAll())
                            _ClearAll();
                    }                    
                    break;

                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private void txtItemID_Leave(object sender, EventArgs e)
        {
            openItem();
        }

        private void openItem()
        {
            var oitem = new Item();
            if (oitem.LoadByItemID(txtItemID.Text.Trim()))
            {
                txtItemName.Text = oitem.ItemName;
                txtItemSeqNo.Text = oitem.ItemSeqNo;
            }
            else
            {
                txtItemSeqNo.Text = string.Empty;
                txtItemID.Text = string.Empty;
                txtItemName.Text = string.Empty;
            }
            oitem.Dispose();
            oitem = null;

            PopulateItemUnit();
        }

        //private void txtItemID_KeyUp(object sender, KeyEventArgs e)
        //{
        //    switch (e.KeyCode)
        //    {
        //        case Keys.F3:
        //            Item item;
        //            using (var frm = new SearchItemForm())
        //            {
        //                item = frm.Search();
        //            }
        //            if (item != null)
        //            {
        //                txtItemID.Text = item.ItemID;
        //                txtItemSeqNo.Text = item.ItemSeqNo;
        //                cboItemUnit.Focus();
        //            }
        //            else
        //            {
        //                txtItemID.Text = string.Empty;
        //                txtItemSeqNo.Text = string.Empty;
        //            }
        //            break;
        //    }
        //}

        private void txtTxnNo_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    dtpTxnDate.Focus();
                    break;
                //case Keys.F2 :
                //    SearchAdjustTxno();
                //    break;
            }
        }

        private void SearchAdjustTxno()
        {
            MutationHd _MutationHd;
            using (var frm = new SearchTxnAdjustmentForm())
            {
                _MutationHd = frm.Search(_loginInfo, Convert.ToString(cboTxnType.SelectedValue));
            }
            if (_MutationHd != null)
            {
                txtTxnNo.Text = _MutationHd.TxnNo;
                dtpTxnDate.Focus();
            }
        }

        private void txtTxnNo_Leave(object sender, EventArgs e)
        {
            openTxnNo();
        }

        private void openTxnNo()
        {
            var oMutationhd = new MutationHd();
            oMutationhd.InventoryTxnID = Convert.ToString(cboTxnType.SelectedValue);
            oMutationhd.TxnNo = txtTxnNo.Text.Trim();
            if (oMutationhd.SelectOne().Rows.Count > 0)
            {
                txtTxnNo.Text = oMutationhd.TxnNo;
                dtpTxnDate.Value = oMutationhd.TxnDate;
                cboReason.SelectedValue = oMutationhd.AdjustmentReasonID.Trim();
                cboWarehouse.SelectedValue = oMutationhd.SourceWHID.Trim();
                cboUnit.SelectedValue = oMutationhd.SourceUnitID.Trim();
                txtDescription.Text = oMutationhd.Description.Trim();
                cboTxnType.Enabled = false;;
                PopulateGrid();

                if (oMutationhd.IsApproval)
                {
                    lblApproved.Visible = true;
                    btnApprove.Enabled = false;
                    btnDeleteAll.Enabled = false;
                    btnDelete.Enabled = false;
                    btnSave.Enabled = false;
                    btnClear.Enabled = false;
                    btnSearchItem.Enabled = false;
                }
                else
                {
                    lblApproved.Visible = false;
                    btnApprove.Enabled = true;
                    
                    btnDeleteAll.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = true;
                    btnClear.Enabled = true;
                    btnSearchItem.Enabled = true;
                }
            }
            else
            {
                _ClearAll();
            }
            oMutationhd.Dispose();
            oMutationhd = null;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            Approval();
        }

        private void Approval()
        {
            if (Program.MsgBox_Show("Are you sure want to approve this transaction ? ", "Confirmation", "YesNo"))
            {
                var oMutationhd = new MutationHd();
                oMutationhd.InventoryTxnID = Convert.ToString(cboTxnType.SelectedValue);
                oMutationhd.TxnNo = txtTxnNo.Text.Trim();
                if (oMutationhd.SelectOne().Rows.Count > 0)
                {
                    if (oMutationhd.IsApproval)
                        Program.MsgBox_Show("Transaction no. is already approved, please refresh your screen.");
                    else
                    {
                        var oItemHistory = new ItemHistory();
                        oItemHistory.TxnNo = txtTxnNo.Text.Trim();
                        oItemHistory.UserInsert = _loginInfo.UserID.Trim();
                        if (Convert.ToString(cboTxnType.SelectedValue).Trim() == "111")
                        {
                            oItemHistory.DoApproval(TxnType.AdjustmentMinus);
                        }
                        else
                        {
                            oItemHistory.DoApproval(TxnType.AdjustmentPlus);
                        }
                        oItemHistory.Dispose();
                        oItemHistory = null;

                        openTxnNo();
                    }
                }
                else
                {
                    Program.MsgBox_Show("Transaction no. not found.");
                }
                oMutationhd.Dispose();
                oMutationhd = null;
            }
        }

        private void PopulateInventoryTxn()
        {
            var oInventoryTxn = new InventoryTxn();
            var dv = new DataView(oInventoryTxn.SelectInventoryTxnAuthorizationByUserGroupID(_loginInfo.UserGroupID));
            dv.RowFilter = "InventoryTxnID in ('111','110')";
            cboTxnType.ValueMember = "InventoryTxnID";
            cboTxnType.DisplayMember = "InventoryTxnName";
            cboTxnType.DataSource = dv;
            dv = null;
            oInventoryTxn.Dispose();
            oInventoryTxn = null;
        }

        private void PopulateWarehouse()
        {
            Program.PopulateByWarehouse(cboWarehouse);
            SetWarehouse();
        }

        private void SetWarehouse()
        {
            cboWarehouse.SelectedValue = Program.SelectOneByCommonSetting("WhIDPos");
        }

        private void PopulateUnit()
        {
            Program.PopulateByUnitID(cboWarehouse.SelectedValue + "", cboUnit);
            SetUnit();
        }

        private void SetUnit()
        {
            cboUnit.SelectedValue = Program.SelectOneByCommonSetting("UnitIDPos");
        }

        private void PopulateItemUnit()
        {
            var oItem = new Item();
            oItem.ItemSeqNo = txtItemSeqNo.Text.Trim();
            cboItemUnit.ValueMember = "ItemUnitID";
            cboItemUnit.DisplayMember = "ItemUnitName";
            cboItemUnit.DataSource = oItem.SelectAllItemUnitByItemSeqNo().DefaultView;
            oItem.Dispose();
            oItem = null;
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

        private void txtItemFactor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            _Clear();
            txtItemID.Focus();
        }

        private void _Clear()
        {
            txtID.Text = string.Empty;
            txtItemSeqNo.Text = string.Empty;
            txtItemID.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtItemFactor.Text = string.Format(Program.FormatCurrency, 1);
            txtQty.Text = string.Format(Program.FormatCurrency, 1);
            cboItemUnit.DataSource = null;
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            _ClearAll();
        }

        private void _ClearAll()
        {
            txtTxnNo.Text = string.Empty;
            cboTxnType.Enabled = true;
            dtpTxnDate.Value = BussinessRules.ID.GetDateDBServer();
            txtDescription.Text = string.Empty;
            lblApproved.Visible = false;
            btnApprove.Enabled = false;

            btnDeleteAll.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = true;
            btnClear.Enabled = true;
            btnSearchItem.Enabled = true;

            _Clear();
            PopulateGrid();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            btnDeleteAll.Focus();
            if (_DeleteAll())
                _ClearAll();
        }

        private bool _DeleteAll()
        {
            bool _retval = false;
            if (txtTxnNo.Text.Trim() == string.Empty)
            {
                Program.MsgBox_Show("Nothing to Delete");
                return _retval;
            }

            var omdt = new MutationDt();
            omdt.TxnNo = txtTxnNo.Text.Trim();
            omdt.UserDelete = _loginInfo.UserID;
            omdt.DeleteAllByTxnNo();
            omdt.Dispose();
            omdt = null;

            _DeleteHd();
            Program.MsgBox_Show("Deleted is Successfully");
            _retval = true;
            return _retval;
        }
        
        private void cboItemUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            var oItemFactorTemplate = new ItemFactorTemplate();
            oItemFactorTemplate.ItemSeqNo = txtItemSeqNo.Text.Trim();
            oItemFactorTemplate.ItemUnitID = Convert.ToString(cboItemUnit.SelectedValue);
            oItemFactorTemplate.SelectOne();
            txtItemFactor.Text = string.Format(Program.FormatCurrency,oItemFactorTemplate.ItemFactor);
            oItemFactorTemplate.Dispose();
            oItemFactorTemplate = null;
        }

        

    }
}
