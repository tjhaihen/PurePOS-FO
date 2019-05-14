using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;
using Raven.BussinessRules;
using Raven.Common;


namespace Raven.Pos.Sales
{

    public partial class POSMainForm : Form
    {
        #region "Private Variables"
            private DataTable _dtbSalesItem;
            private LoginInfo _loginInfo;  
      
            string ldp_Hello = string.Empty;
            string ldp_DefaultText = string.Empty;
        #endregion

        public POSMainForm(LoginInfo loginInfo)
        {
            _loginInfo = loginInfo;
            InitializeComponent();

            lblSystemInfo.Text = ProductName + " v." + ProductVersion;

            lblCompanyName.Text = _loginInfo.CompanyName;
            lblBranch.Text = _loginInfo.BranchName;

            lblCashierID.Text = _loginInfo.UserID;
            lblCashierName.Text = _loginInfo.UserName;

            ldp_Hello = ("Hi I'm " + lblCashierID.Text.Trim() + Program.POSIFLEX_SpaceCharPerLine).Substring(0, 20) + Program.SelectOneByCommonSettingByDetailID("PDText", "01");
            ldp_DefaultText = Program.SelectOneByCommonSettingByDetailID("PDText", "99");
            
            this.WindowState = FormWindowState.Maximized;
            PopulateItemUnit();
            PopulateCurrency();
            PopulateWarehouse();
            PopulateTransType();
            PopulateUnit();
            PopulateSTxnStatus();
            PrepareNewSales();
            txtItemID.Focus();
        }

        private DataTable LoadSalesItem()
        {
            var salesItem = new SalesUnitDt();
            var dtbSalesItem = salesItem.SelectByNo(txtSTxnNo.Text);
            dtbSalesItem.PrimaryKey = new[] { dtbSalesItem.Columns["ID"] };
            return dtbSalesItem;
        }

        #region "Control Events (KeyUp, KeyPress, Leave)"
            private void POSMainForm_KeyUp(object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.F2: //Payment
                        Payment();
                        break;
                    case Keys.F3: //Search Item
                        if (btnSearchItem.Enabled)
                            SearchItem();
                        break;
                    case Keys.F4: //Search Transaction                    
                        SearchSales();
                        break;
                    case Keys.F5: //New Transaction
                        PrepareNewSales("ConfirmationN");
                        break;
                    case Keys.F6: //Member ID Input
                        if (btnMemberIDInput.Enabled)
                            MemberIDInput();
                        break;
                    case Keys.F7: //Cancel Item
                        if (btnItemCancel.Enabled)
                            ItemCancel();
                        break;
                    case Keys.F8: //Toggle Item Unit
                        if (btnToggleItemUnit.Enabled)
                            ToggleItemUnit();
                        break;
                    case Keys.F9: //Qty Input
                        if (btnQtyInput.Enabled)
                            QtyInput(numQty.Value);
                        break;
                    case Keys.F10: //Others Function
                        OtherFunction();
                        break;
                    case Keys.F11: //Change Password
                        ChangePassword();
                        break;
                    case Keys.F12: //Log Out
                        LogOut();
                        break;
                    case Keys.Up:
                        if (btnRaiseQty.Enabled)
                            RaiseQty();
                        break;
                    case Keys.Down:
                        if (btnLowerQty.Enabled)
                            LowerQty();
                        break;
                    case Keys.Enter:
                        if (PopulateItemEntry()) //PopulateItemEntry(false, true)
                        {
                            if (SaveToDatabase())
                            {
                                _dtbSalesItem = LoadSalesItem();
                                PopulateGridAndTotal();
                                Program.PoleDisplay_Show((lblItemName.Text.Trim() + Program.POSIFLEX_SpaceCharPerLine).Substring(0, 20 - lblItemUnitPrice.Text.Trim().Length - 1) + " " +
                                                          lblItemUnitPrice.Text.Trim() + "{" + txtGrandTotal.Text.Trim() + "}");
                                ClearItemEntry();                                
                            }
                        }
                        break;
                }
            }

            private void txtItemID_Leave(object sender, EventArgs e)
            {
                PopulateItemEntry();
            }
        #endregion

        #region "Control Events (ButtonClick)"
            private void btnPayment_Click(object sender, EventArgs e)
            {
                Payment();
            }

            private void btnSearchItem_Click(object sender, EventArgs e)
            {
                SearchItem();
            }

            private void btnSearchSTxn_Click(object sender, EventArgs e)
            {
                SearchSales();
            }

            private void btnNewSTxn_Click(object sender, EventArgs e)
            {
                PrepareNewSales("ConfirmationN");
            }

            private void btnMemberIDInput_Click(object sender, EventArgs e)
            {
                MemberIDInput();
            }

            private void btnCancelItem_Click(object sender, EventArgs e)
            {
                ItemCancel();
            }

            private void btnToggleItemUnit_Click(object sender, EventArgs e)
            {
                ToggleItemUnit();
            }

            private void btnQtyInput_Click(object sender, EventArgs e)
            {
                QtyInput(numQty.Value);
            }

            private void btnRaiseQty_Click(object sender, EventArgs e)
            {
                RaiseQty();
            }

            private void btnLowerQty_Click(object sender, EventArgs e)
            {
                LowerQty();
            }

            private void btnOthersFunction_Click(object sender, EventArgs e)
            {
                OtherFunction();
            }

            private void btnChangePassword_Click(object sender, EventArgs e)
            {
                ChangePassword();

            }

            private void btnLogout_Click(object sender, EventArgs e)
            {
                LogOut();
            }
        #endregion

        #region "Control Events (ComboBoxSelectedIndexChanged)"
            private void cboSTxnStatusID_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (Convert.ToString(cboSTxnStatusID.SelectedValue) == "V" || Convert.ToString(cboSTxnStatusID.SelectedValue) == "C")
                {
                    btnLowerQty.Enabled = false;
                    btnRaiseQty.Enabled = false;
                    btnQtyInput.Enabled = false;
                    btnToggleItemUnit.Enabled = false;
                    btnItemCancel.Enabled = false;
                    btnMemberIDInput.Enabled = false;
                    btnSearchItem.Enabled = false;

                    txtItemID.Enabled = false;
                    cboItemUnit.Enabled = false;
                    numQty.Enabled = false;
                }
                else
                {
                    btnLowerQty.Enabled = true;
                    btnRaiseQty.Enabled = true;
                    btnQtyInput.Enabled = true;
                    btnToggleItemUnit.Enabled = true;
                    btnItemCancel.Enabled = true;
                    btnMemberIDInput.Enabled = true;
                    btnSearchItem.Enabled = true;

                    txtItemID.Enabled = true;
                    cboItemUnit.Enabled = true;
                    numQty.Enabled = true;
                }
            }
        #endregion

        #region "Control Events (Private Functions)"
            private void Payment()
            {
                var IsDonationOnly = false;
                if (txtSTxnNo.Text.Trim() == "")
                {
                    if (Program.MsgBox_Show("Do you wish to perform a Donation Only transaction ?", "Confirmation", "YesNo"))
                    {
                        IsDonationOnly = true;
                    }
                    else
                    {
                        IsDonationOnly = false;
                        return;
                    }
                    //MessageBox.Show("No transaction to be paid.");
                }

                string receiptNo = string.Empty;
                var paymentHd = new PaymentHd();
                if (paymentHd.LoadBySTxnNo(txtSTxnNo.Text))
                {
                    receiptNo = paymentHd.ReceiptNo;    
                }
                paymentHd.Dispose();
                paymentHd = null;

                if (Convert.ToString(cboSTxnStatusID.SelectedValue) == "O" ||
                    Convert.ToString(cboSTxnStatusID.SelectedValue) == "S")
                    UpdateTransaction(Convert.ToString(cboSTxnStatusID.SelectedValue), false, true);

                decimal DonationAmt = 0;
                decimal GetVoucherAmount = 0;
                var oSalesUnitHd = new SalesUnitHd();
                oSalesUnitHd.STxnNo = txtSTxnNo.Text.Trim();
                if (oSalesUnitHd.SelectOne().Rows.Count > 0)
                {
                    DonationAmt = oSalesUnitHd.DonationAmt;
                    GetVoucherAmount = oSalesUnitHd.GetVoucherAmount;
                }
                oSalesUnitHd.Dispose();
                oSalesUnitHd = null;
            
                using (var frm = new POSPaymentForm(_loginInfo))
                {
                    var _LastTransaction = frm.Payment(lblSystemCurrentDate.Text.Trim(), lblSystemCurrentTime.Text.Trim(), txtSTxnNo.Text.Trim(), 
                                           txtSTxnDate.Text.Trim(), receiptNo.Trim(), txtMemberID.Text.Trim(), lblMemberName.Text.Trim(), 
                                           lblMemberSinceDate.Text.Trim(), lblValidThruDate.Text.Trim(), Convert.ToDecimal(txtGrandTotal.Text), 
                                           Convert.ToString(cboSTxnStatusID.SelectedValue), IsDonationOnly, Convert.ToString(cbotranstype.SelectedValue),
                                           Convert.ToString(cboWh.SelectedValue), Convert.ToString(cboUnit.SelectedValue), Convert.ToString(cboCurrency.SelectedValue),
                                           Convert.ToDecimal(txtCurrencyRate.Text.Trim()), DonationAmt, GetVoucherAmount);

                    if (_LastTransaction.Length == 7)
                    {
                        

                        lblLastSTxnNo.Text = _LastTransaction[0]; //"TransactionNo"
                        lblLastGrandTotal.Text = _LastTransaction[1]; //"GrandTotal"
                        lblLastRounding.Text = _LastTransaction[2]; //"Rounding"
                        lblLastPayment.Text = _LastTransaction[3]; //"Payment"
                        lblLastChange.Text = _LastTransaction[4]; //"Change"
                        
                        if (Convert.ToBoolean(_LastTransaction[6]))
                            txtSTxnNo.Text = _LastTransaction[5];

                        PrepareNewSales("Complete");
                    }
                    else if (_LastTransaction.Length == 2)
                    { 
                        if (Convert.ToBoolean(_LastTransaction[1]))
                        {
                            txtSTxnNo.Text = _LastTransaction[0];
                            UpdateTransaction("V", true, false);
                            PrepareNewSales();
                        }
                    }

                    if (txtSTxnNo.Text.Trim() != string.Empty)
                        Program.PoleDisplay_Show(ldp_DefaultText);
                }
            }

            private void SearchItem()
            {
                Item item;
                using (var frm = new SearchItemForm())
                {
                    item = frm.Search();
                }
                if (item != null)
                {
                    txtItemID.Text = item.ItemID;
                    PopulateItemEntry();
                }
            }

            private void SearchSales()
            {
                if (PrepareNewSales("ConfirmationS") != true)
                    return;

                SalesUnitHd salesHd;
                using (var frm = new SearchSalesForm())
                {
                    salesHd = frm.Search(_loginInfo);
                }
                if (salesHd != null)
                {
                    txtSTxnNo.Text = salesHd.STxnNo;
                    txtSTxnDate.Text = string.Format(Program.FormatDate, salesHd.STxnDate);
                    cboCurrency.SelectedValue = salesHd.Currency;
                    txtCurrencyRate.Text = string.Format(Program.FormatCurrency, salesHd.CurrencyRate);
                    cboWh.SelectedValue = salesHd.WhID;
                    cboUnit.SelectedValue = salesHd.UnitID;
                    cbotranstype.SelectedValue = salesHd.StxnTypeID;
                    cboSTxnStatusID.SelectedValue = salesHd.STxnStatusID;
                    lblEntitiesSeqNo.Text = salesHd.EntitiesSeqNo;
                    
                    var oEntities = new Entities();
                    oEntities.EntitiesSeqNo = lblEntitiesSeqNo.Text;

                    if (oEntities.SelectOne().Rows.Count > 0)
                    {
                        txtMemberID.Text = oEntities.MemberNo.Trim();
                        lblMemberSinceDate.Text = (string.Format(Program.FormatDate, oEntities.MemberSinceDate) == "01-01-1900" ? "-" : string.Format(Program.FormatDate, oEntities.MemberSinceDate));
                        lblValidThruDate.Text = (string.Format(Program.FormatDate, oEntities.MemberValidThruDate) == "01-01-1900" ? "-" : string.Format(Program.FormatDate, oEntities.MemberValidThruDate));


                        var oMemberBenefit = new MemberBenefit();
                        oMemberBenefit.MBTypeID = oEntities.MemberTypeID.Trim();
                        
                        if (oMemberBenefit.SelectOne().Rows.Count > 0)
                        {
                            lblMemberName.Text = oMemberBenefit.MBTypeName;
                        }
                        oMemberBenefit.Dispose();
                        oMemberBenefit = null;
                    }
                    oEntities.Dispose();
                    oEntities = null;

                    //Detil
                    _dtbSalesItem = LoadSalesItem();
                    PopulateGridAndTotal();
                    if (Convert.ToString(cboSTxnStatusID.SelectedValue) == "C" || Convert.ToString(cboSTxnStatusID.SelectedValue) == "V")
                    {
                        Program.PoleDisplay_Show(ldp_Hello);
                    }
                    else
                        Program.PoleDisplay_Show(ldp_DefaultText);
                }

            }

            private void SearchItemFactor(string ItemSeqNo, string ItemUnitID)
            {
                using (var oitemfactor = new ItemFactorTemplate())
                {
                    oitemfactor.ItemSeqNo = ItemSeqNo;
                    oitemfactor.ItemUnitID = ItemUnitID;
                    var dtbItemFactor = oitemfactor.SelectAllByItemSeqNoItemUnitID();
                    if (dtbItemFactor.Rows.Count > 1)
                    {

                        ItemFactorTemplate _ItemFactorTemplate;
                        using (var frm = new SearchItemFactorForm())
                        {
                            _ItemFactorTemplate = frm.Search(ItemSeqNo, ItemUnitID);
                        }

                        if (_ItemFactorTemplate != null)
                        {
                            txtItemFactor.Text = string.Format(Program.FormatCurrency, _ItemFactorTemplate.ItemFactor);
                        }
                    }
                    else if (dtbItemFactor.Rows.Count == 1)
                    {
                        txtItemFactor.Text = string.Format(Program.FormatCurrency, dtbItemFactor.Rows[0]["ItemFactor"]);
                    }
                    else
                    {
                        txtItemFactor.Text = string.Format(Program.FormatCurrency, 1);
                    }
                }
            }

            private void ItemCancel()
            {
                if (txtSTxnNo.Text.Trim() == string.Empty)
                    Program.MsgBox_Show("Nothing to cancel.");
                else
                {
                    using (var frm = new CancelItemForm())
                    {
                        if (frm.Search(txtSTxnNo.Text.Trim(), txtItemID.Text.Trim(), _loginInfo.UserID.Trim()))
                        {
                            _dtbSalesItem = LoadSalesItem();
                            PopulateGridAndTotal();
                        }
                    }
                }
            }

            private void ToggleItemUnit()
            {
                if (cboItemUnit.Items.Count > 0)
                {
                    if (cboItemUnit.SelectedIndex < (cboItemUnit.Items.Count - 1))
                    {
                        cboItemUnit.SelectedIndex += 1;
                    }
                    else if (cboItemUnit.SelectedIndex == (cboItemUnit.Items.Count - 1))
                    {
                        cboItemUnit.SelectedIndex = 0;
                    }
                }
                PopulateItemEntry(); //true
            }

            private void MemberIDInput()
            {
                string[] _ArrayMember;
                using (var frm = new MemberIDInputForm())
                {
                    _ArrayMember = frm.MemberIDInput(txtMemberID.Text.Trim(), txtSTxnNo.Text.Trim());
                }
                if (_ArrayMember != null)
                {
                    lblEntitiesSeqNo.Text = _ArrayMember[0];
                    txtMemberID.Text = _ArrayMember[1];
                    lblMemberName.Text = _ArrayMember[2];
                    lblMemberSinceDate.Text = _ArrayMember[3];
                    lblValidThruDate.Text = _ArrayMember[4];
                    _dtbSalesItem = LoadSalesItem();
                    PopulateGridAndTotal();
                    ClearItemEntry();
                }
            }

            private void QtyInput(decimal CurrentQty)
            {
                decimal qty;
                using (var frm = new QtyInputForm())
                {
                    qty = frm.QtyInput(CurrentQty);
                }
                //if (qty != null)
                //{
                numQty.Value = qty;
                //}
            }

            private void RaiseQty()
            {
                numQty.Value += 1;
            }

            private void LowerQty()
            {
                if (numQty.Value > 1)
                {
                    numQty.Value -= 1;
                }
                else
                {
                    numQty.Value = 1;
                }
            }

            private void OtherFunction()
            {
                var oOtherFunction = new OtherFunction(_loginInfo);
                oOtherFunction.ShowOtherFunction();
                oOtherFunction.Dispose();
                oOtherFunction = null;
            }

            private void ChangePassword()
            {
                using (var frm = new ChangePasswordForm(_loginInfo))
                {
                    frm.ChangePassword();
                }
            }

            private void LogOut()
            {
                if (PrepareNewSales("ConfirmationL") != true)
                    return;
                LoginInfo loginInfo;
                using (var frm = new LoginForm())
                {

                    loginInfo = frm.GetLoginInfo();
                }
                if (loginInfo != null)
                {
                    _loginInfo = loginInfo;
                }
                else
                {
                    Close();
                    //Program.Shutdown(Program.ShutDownFlag.Shutdown);
                }
            }

            private bool PrepareNewSales(string strStatus = "")
            {

                if (txtSTxnNo.Text.Trim() != string.Empty && strStatus.Trim() != "" && Convert.ToString(cboSTxnStatusID.SelectedValue) != "V" && Convert.ToString(cboSTxnStatusID.SelectedValue) != "C")
                {
                    string STxnStatusID = "";
                    if (strStatus.Trim() == "ConfirmationN" ||
                        strStatus.Trim() == "ConfirmationS" ||
                        strStatus.Trim() == "ConfirmationL")
                    {
                        if (strStatus.Trim() == "ConfirmationN")
                        {
                            if (Program.MsgBox_Show("You have choosen to create a new transaction. This action will suspend/void curret entry. Continue?", "Confirmation", "YesNo") == false)
                                return false;                            
                            Program.PoleDisplay_Show(ldp_Hello);
                        }
                        else if (strStatus.Trim() == "ConfirmationS")
                        {
                            if (txtSTxnNo.Text.Trim() != string.Empty)
                            {
                                if (Program.MsgBox_Show("You have choosen to search transaction. This action will suspend/void current entry. Continue?", "Confirmation", "YesNo") == false)
                                    return false;                                
                            }
                            else
                                return false;
                        }
                        else if (strStatus.Trim() == "ConfirmationL")
                        {
                            if (Program.MsgBox_Show("Are you sure you want to log out?", "Log Out Confirmation", "YesNo") == false)
                                return false;                            
                        }


                        using (var frm = new ChooseTransactionStatusForm())
                        {
                            STxnStatusID = frm.Search(txtSTxnNo.Text.Trim());
                        }

                        if (STxnStatusID == null)
                            return false;

                        if (STxnStatusID.Trim() == "V")
                        {
                            var oPaymentHd = new PaymentHd();
                            if (oPaymentHd.LoadBySTxnNo(txtSTxnNo.Text.Trim()))
                            {
                                Program.MsgBox_Show("This transaction already have payment. Please complete/void it's payment first.");
                                return false;
                            }
                            oPaymentHd.Dispose();
                            oPaymentHd = null;
                            

                            using (var frm = new AuthorizeForm())
                            {
                                if (!frm.GetAuthorize())
                                    return false;
                            }
                        }

                    }
                    else if (strStatus.Trim() == "Complete")
                    {
                        STxnStatusID = "C";
                        Program.PoleDisplay_Show(ldp_Hello);
                    }
                    else
                        return false;

                    UpdateTransaction(STxnStatusID, true , (STxnStatusID != "C"));
                }
                cboSTxnStatusID.SelectedValue = "O";

                txtSTxnNo.Text = string.Empty;

                txtSTxnDate.Text = string.Format(Program.FormatDate, BussinessRules.ID.GetDateDBServer());
                lblSystemCurrentDate.Text = string.Format(Program.FormatDate, BussinessRules.ID.GetDateDBServer());
                lblSystemCurrentTime.Text = string.Format(Program.FormatTime, BussinessRules.ID.GetDateDBServer());

                //Member Entry
                ClearMemberEntry();

                //Item Entry
                ClearItemEntry();
                lblItemName.Text = "-";
                lblItemUnitPrice.Text = String.Format(Program.FormatCurrency, 0);

                //Detil
                lblLines.Text = "0";
                lblItems.Text = "0";
                _dtbSalesItem = LoadSalesItem();
                PopulateGridAndTotal();
                return true;
            }

            private void UpdateTransaction(string STxnStatusID, bool IsUpdateSalesHD, bool IsUpdateGetVouvherAmt)
            {
                var conn = new SqlConnection(HisConfiguration.ConnectionString);
                SqlTransaction trans = null;

                try
                {
                    conn.Open();
                    trans = conn.BeginTransaction();
                    using (var salesHd = new SalesUnitHd())
                    {
                        salesHd.STxnNo = txtSTxnNo.Text.Trim();
                        salesHd.UserUpdate = _loginInfo.UserID;

                        if (IsUpdateSalesHD)
                        {
                            
                            salesHd.BranchID = _loginInfo.BranchID;
                            salesHd.StxnTypeID = Convert.ToString(cbotranstype.SelectedValue);
                            salesHd.EntitiesSeqNo = lblEntitiesSeqNo.Text.Trim();
                            salesHd.STxnDate = Program.ConvertToDate(txtSTxnDate.Text.Trim());
                            salesHd.WhID = Convert.ToString(cboWh.SelectedValue);
                            salesHd.UnitID = Convert.ToString(cboUnit.SelectedValue);
                            salesHd.Currency = Convert.ToString(cboCurrency.SelectedValue);
                            salesHd.CurrencyRate = Convert.ToDecimal(txtCurrencyRate.Text.Trim());
                            salesHd.Description = "";
                            salesHd.STxnStatusID = STxnStatusID.Trim();
                            salesHd.Update(conn, trans);
                        }

                        if (IsUpdateGetVouvherAmt)
                        {
                            salesHd.FGetVoucherAmount(conn, trans, txtMemberID.Text.Trim());
                            salesHd.UpdateGetVoucherAmount(conn, trans);
                        }
                    }
                    trans.Commit();

                }
                catch (Exception ex)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                        trans.Dispose();
                    }
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (trans != null)
                    {
                        trans.Dispose();
                    }
                    conn.Close();
                    conn.Dispose();
                }
            }

            private void ClearMemberEntry()
            {
                lblEntitiesSeqNo.Text = string.Empty;
                txtMemberID.Text = string.Empty;
                lblMemberName.Text = "-";
                lblMemberSinceDate.Text = "-";
                lblValidThruDate.Text = "-";
            }

            private void ClearItemEntry()
            {
                txtItemID.Focus();
                txtItemID.Text = string.Empty;
                txtItemFactor.Text = string.Format(Program.FormatCurrency, 1);

                lblUnitPrice.Text = string.Format(Program.FormatCurrency, 0);
                lblUnitDisc1.Text = string.Format(Program.FormatCurrency, 0);
                lblUnitDisc2.Text = string.Format(Program.FormatCurrency, 0);
                lblUnitDisc.Text = string.Format(Program.FormatCurrency, 0);

                txtItemUnitID.Text = string.Empty;
                cboItemUnit.SelectedIndex = 0;

                numQty.Value = 1;
                txtToggleOperator.Text = "+";
            }
            
            private void PopulateItemUnit()
            {
                var itemUnit = new CommonSetting();
                var dtb = itemUnit.SelectAllByGroupID("StdItemUnit");
                cboItemUnit.DisplayMember = "DetailDesc";
                cboItemUnit.ValueMember = "DetailID";
                cboItemUnit.DataSource = dtb;
            }

            private void PopulateCurrency()
            {
                Program.PopulateByCommonSetting(cboCurrency, "Currency");
                SetCurrency();
            }

            private void SetCurrency()
            {
                cboCurrency.SelectedValue = Program.SelectOneByCommonSetting("Currency");
                txtCurrencyRate.Text = string.Format(Program.FormatCurrency, 1);
            }

            private void PopulateWarehouse()
            {
                Program.PopulateByWarehouse(cboWh);
                SetWarehouse();
            }

            private void SetWarehouse()
            {
                cboWh.SelectedValue = Program.SelectOneByCommonSetting("WhIDPos");
            }

            private void PopulateUnit()
            {
                Program.PopulateByUnitID(cboWh.SelectedValue + "", cboUnit);
                SetUnit();
            }

            private void SetUnit()
            {
                cboUnit.SelectedValue = Program.SelectOneByCommonSetting("UnitIDPos");
            }

            private void PopulateTransType()
            {
                Program.PopulateByCommonSetting(cbotranstype, "StxntypeID");
                SetTransType();
            }

            private void SetTransType()
            {
                cbotranstype.SelectedValue = Program.SelectOneByCommonSetting("StxntypeIDPos");
            }

            private void PopulateSTxnStatus()
            {
                Program.PopulateByCommonSetting(cboSTxnStatusID, "STxnStatus");
                cboSTxnStatusID.SelectedValue = "O";
            }

            private void PopulateGridAndTotal()
            {
                PopulateTotal();

                grdItem.AutoGenerateColumns = false;
                grdItem.DataSource = _dtbSalesItem;
                grdItem.ResumeLayout();
            }

            private void PopulateTotal()
            {
                var grossTotalAmt = (from DataRow row in _dtbSalesItem.Rows
                                     where row["IsDeleted"].Equals(false)
                                     select Convert.ToDecimal(row["GrossTotal"])).Sum();

                var discountTotalAmt = (from DataRow row in _dtbSalesItem.Rows
                                        where row["IsDeleted"].Equals(false)
                                        select Convert.ToDecimal(row["DiscountTotal"])).Sum();

                var items = (from DataRow row in _dtbSalesItem.Rows
                             where row["IsDeleted"].Equals(false)
                             select Convert.ToDecimal(row["Qty"])).Sum();

                var lines = (from DataRow row in _dtbSalesItem.Rows
                             where row["IsDeleted"].Equals(false)
                             select (row["ID"])).Count();

                decimal grandTotalAmt = 0;

                txtGrossTotal.Text = String.Format(Program.FormatCurrency, grossTotalAmt);
                txtDiscountTotal.Text = String.Format(Program.FormatCurrency, discountTotalAmt);
                grandTotalAmt = grossTotalAmt - discountTotalAmt;
                txtGrandTotal.Text = String.Format(Program.FormatCurrency, grandTotalAmt);

                lblLines.Text = Convert.ToString(lines);
                lblItems.Text = String.Format(Program.FormatCurrency, items);
            }

            private bool PopulateItemEntry() //bool isToggleItemUnit = false //, bool isSave = false
            {
                bool retval = false;
                lblItemName.Text = string.Empty;
                lblItemUnitPrice.Text = String.Format(Program.FormatCurrency, 0);
                using (var item = new Item())
                {
                    string strBarcodeBuah = txtItemID.Text.Trim();
                    if (Program.Left(strBarcodeBuah, 2) == "22" && strBarcodeBuah.Trim().Length == 13)
                        txtItemID.Text = Program.Left(strBarcodeBuah, 6);
                    else
                        strBarcodeBuah = string.Empty;
                    
                    if (item.LoadByItemID(txtItemID.Text))
                    {
                        lblItemName.Text = item.ItemName;

                        txtItemUnitID.Text = (Convert.ToString(cboItemUnit.SelectedValue) == "01" ?
                                              item.ItemSUnitID :
                                              (Convert.ToString(cboItemUnit.SelectedValue) == "02" ?
                                                  item.ItemMUnitID :
                                                  (Convert.ToString(cboItemUnit.SelectedValue) == "03" ?
                                                      item.ItemLUnitID : "")));


                        if (strBarcodeBuah.Trim().Length > 0)
                        {
                            cboItemUnit.SelectedValue = "01";
                            try
                            {
                                if (txtItemUnitID.Text.Trim() == "KG")
                                    numQty.Value = decimal.Parse(strBarcodeBuah.Substring(7, 2) + "." + strBarcodeBuah.Substring(9, 3));
                                else
                                    numQty.Value = decimal.Parse(strBarcodeBuah.Substring(7, 5));
                            }
                            catch
                            {
                                Program.MsgBox_Show("qty is not valid ");
                                return false;
                            }

                            //if (item.ItemCategoryID.Trim() != "001" && item.ItemCategoryID.Trim() != "005")
                            //{
                            //    Program.MsgBox_Show("Item Category is not valid ");
                            //    return false;
                            //}
                        }

                        //txtItemUnitID.Text = (Convert.ToString(cboItemUnit.SelectedValue) == "01" ?
                        //                  item.ItemSUnitID :
                        //                  (Convert.ToString(cboItemUnit.SelectedValue) == "02" ?
                        //                      item.ItemMUnitID :
                        //                      (Convert.ToString(cboItemUnit.SelectedValue) == "03" ?
                        //                          item.ItemLUnitID : "")));

                        //if (txtItemUnitID.Text.Trim() == item.ItemMUnitID) //isToggleItemUnit == false
                        //{
                            SearchItemFactor(item.ItemSeqNo, txtItemUnitID.Text.Trim());
                        //}

                        using (var salesDt = new SalesUnitDt())
                        {
                            DataTable dtbPriceDOorSalesItem = salesDt.SelectGetPriceItemDOorSales("FO", item.ItemSeqNo.Trim(),
                                                              txtItemUnitID.Text.Trim(), Convert.ToDecimal(txtItemFactor.Text.Trim()), Convert.ToDecimal(txtCurrencyRate.Text.Trim()),
                                                              txtMemberID.Text.Trim(), txtSTxnNo.Text.Trim(), numQty.Value);

                            dtbPriceDOorSalesItem.PrimaryKey = new[] { dtbPriceDOorSalesItem.Columns["ItemSeqNo"] };

                            lblUnitPrice.Text = string.Format(Program.FormatCurrency, dtbPriceDOorSalesItem.Rows[0]["UnitPrice"]);
                            lblUnitDisc1.Text = string.Format(Program.FormatCurrency, Convert.ToDecimal(dtbPriceDOorSalesItem.Rows[0]["Disc1Amt"]));
                            lblUnitDisc2.Text = string.Format(Program.FormatCurrency, Convert.ToDecimal(dtbPriceDOorSalesItem.Rows[0]["Disc2Amt"]));
                            lblUnitDisc.Text = string.Format(Program.FormatCurrency, Convert.ToDecimal(dtbPriceDOorSalesItem.Rows[0]["Disc1Amt"]) +
                                                            Convert.ToDecimal(dtbPriceDOorSalesItem.Rows[0]["Disc2Amt"]));

                            lblItemUnitPrice.Text = string.Format(Program.FormatCurrency,
                                                                    numQty.Value *
                                                                    (
                                                                        Convert.ToDecimal(dtbPriceDOorSalesItem.Rows[0]["UnitPrice"]) -
                                                                        Convert.ToDecimal(dtbPriceDOorSalesItem.Rows[0]["Disc1Amt"]) -
                                                                        Convert.ToDecimal(dtbPriceDOorSalesItem.Rows[0]["Disc2Amt"])
                                                                    )
                                                                );

                            dtbPriceDOorSalesItem.Dispose();
                            dtbPriceDOorSalesItem = null;
                        }
                        //var strprintname = item.PrintName.Substring(0, 19);
                        retval = true;
                    }
                    else
                    {
                        //if (txtItemID.Text != string.Empty)
                        //{
                        txtItemID.Text = string.Empty;
                        numQty.Value = 1;
                        lblItemUnitPrice.Text = String.Format(Program.FormatCurrency, 0);
                        //}
                        txtItemUnitID.Text = string.Empty;
                        txtItemFactor.Text = string.Format(Program.FormatCurrency, 1);
                        lblUnitPrice.Text = string.Format(Program.FormatCurrency, 0);
                        lblUnitDisc1.Text = string.Format(Program.FormatCurrency, 0);
                        lblUnitDisc2.Text = string.Format(Program.FormatCurrency, 0);
                        lblUnitDisc.Text = string.Format(Program.FormatCurrency, 0);
                        retval = false;
                    }
                }
                txtItemID.Focus();
                return retval;
            }                
        #endregion

        #region "Control Events (CRUD Functions)"
            private bool SaveToDatabase()
            {
                if ((cboCurrency.SelectedValue + "").Trim() == "")
                {
                    Program.MsgBox_Show("Store Currency cannot empty.");
                    //MessageBox.Show("Store Currency cannot empty.");
                    return false;
                }
                if ((cboWh.SelectedValue + "").Trim() == "")
                {
                    Program.MsgBox_Show("Store Warehouse cannot empty.");
                    //MessageBox.Show("Store Warehouse cannot empty.");
                    return false;
                }
                if ((cboUnit.SelectedValue + "").Trim() == "")
                {
                    Program.MsgBox_Show("Store Unit cannot empty.");
                    //MessageBox.Show("Store Unit cannot empty.");
                    return false;
                }
                if ((cbotranstype.SelectedValue + "").Trim() == "")
                {
                    Program.MsgBox_Show("Store Transaction Type cannot empty.");
                    //MessageBox.Show("Store Transaction Type cannot empty.");
                    return false;
                }
                if (txtItemID.Text.Trim().Length == 0)
                {
                    return false;
                }

                if (Convert.ToDecimal(lblUnitPrice.Text.Trim()) == 0)
                {
                    Program.MsgBox_Show("Unit Price must be greater than 0.");
                    return false;
                }
                

                if (txtItemUnitID.Text.Trim().Length == 0 || txtItemUnitID.Text.Trim() == "none")
                {
                    Program.MsgBox_Show("Item Unit does not exist.");
                    //MessageBox.Show("Item Unit does not exist.");
                    return false;
                }

                if (numQty.Value % 1 != 0)
                {
                    var oItemUnit = new BussinessRules.ItemUnit();
                    oItemUnit.ItemUnitID = txtItemUnitID.Text.Trim();
                    if (oItemUnit.SelectOne().Rows.Count > 0)
                    {
                        if (oItemUnit.IsAllowDecimal == false)
                        {
                            Program.MsgBox_Show("Item Unit does not allow decimal. Qty value must be integer.");
                            //MessageBox.Show("Item Unit does not allow decimal. Qty value must be integer.");
                            return false;
                        }
                    }
                    else
                    {
                        Program.MsgBox_Show("Item Unit ID does not exist in Master - Item Data Setting - Item Unit.");
                        //MessageBox.Show("Item Unit ID does not exist in Master - Item Data Setting - Item Unit.");
                        return false;
                    }
                }

                if (txtItemFactor.Text.Trim().Length == 0)
                {
                    Program.MsgBox_Show("Item Factor cannot empty.");
                    //MessageBox.Show("Item Factor cannot empty.");
                    return false;
                }

                if (Convert.ToDecimal(txtItemFactor.Text.Trim()) < 1)
                {
                    Program.MsgBox_Show("Item Factor must be equal or greater than 1 (one).");
                    //MessageBox.Show("Item Factor must be equal or greater than 1 (one).");
                    return false;
                }

                if (txtToggleOperator.Text.Trim() == "-")
                {
                    using (var item = new Item())
                    {
                        item.LoadByItemID(txtItemID.Text);
                        if (
                            !((from DataRow row in LoadSalesItem().Rows
                               where row["ItemSeqNo"].Equals(item.ItemSeqNo.Trim())
                               select (row["qty"] == null ? 0 : Convert.ToDecimal(row["qty"]) * Convert.ToDecimal(row["ItemFactor"]))
                             ).Sum() >= (numQty.Value * Convert.ToDecimal(txtItemFactor.Text.Trim())))
                            )
                        {
                            Program.MsgBox_Show("Item does not exist in this transaction. Cancelation failed.");
                            //MessageBox.Show("Item does not exist in this transaction. Cancelation failed.");
                            return false;
                        }
                    }
                }

                bool retval = false;
                var conn = new SqlConnection(HisConfiguration.ConnectionString);
                SqlTransaction trans = null;

                try
                {
                    conn.Open();
                    trans = conn.BeginTransaction();
                    SaveSalesUnitHd(conn, trans);
                    SaveSalesUnitDt(conn, trans);

                    trans.Commit();
                    retval = true;

                }
                catch (Exception ex)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                        trans.Dispose();
                    }
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (trans != null)
                    {
                        trans.Dispose();
                    }
                    conn.Close();
                    conn.Dispose();
                }
                return retval;
            }

            private void SaveSalesUnitHd(SqlConnection conn, SqlTransaction trans)
            {

                using (var salesHd = new SalesUnitHd())
                {
                    salesHd.BranchID = _loginInfo.BranchID;
                    salesHd.StxnTypeID = Convert.ToString(cbotranstype.SelectedValue);
                    salesHd.EntitiesSeqNo = lblEntitiesSeqNo.Text.Trim();
                    salesHd.STxnDate = Program.ConvertToDate(txtSTxnDate.Text.Trim());
                    salesHd.WhID = Convert.ToString(cboWh.SelectedValue);
                    salesHd.UnitID = Convert.ToString(cboUnit.SelectedValue);
                    salesHd.Currency = Convert.ToString(cboCurrency.SelectedValue);
                    salesHd.CurrencyRate = Convert.ToDecimal(txtCurrencyRate.Text.Trim());
                    salesHd.UserInsert = _loginInfo.UserID;
                    salesHd.UserUpdate = _loginInfo.UserID;
                    salesHd.Description = "";
                    salesHd.STxnStatusID = Convert.ToString(cboSTxnStatusID.SelectedValue);

                    salesHd.STxnNo = txtSTxnNo.Text.Trim();
                    if (salesHd.SelectOne().Rows.Count == 0)
                    {
                        txtSTxnNo.Text = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("SalesUnitHD", "STxnNo", conn, trans, "SU", " Where STxnNo like 'SU%' ");
                        salesHd.STxnNo = txtSTxnNo.Text.Trim();
                        salesHd.Insert(conn, trans);
                    }
                    else
                    {
                        salesHd.Update(conn, trans);
                    }
                }
            }

            private void SaveSalesUnitDt(SqlConnection conn, SqlTransaction trans)
            {
                using (var salesDt = new SalesUnitDt())
                {
                    salesDt.ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("SalesUnitDt", "ID", conn, trans, "SU", " Where ID like 'SU%' ");
                    salesDt.STxnNo = txtSTxnNo.Text.Trim();
                    salesDt.ItemSeqNo = txtItemID.Text.Trim();
                    salesDt.UserInsert = _loginInfo.UserID;
                    salesDt.UserUpdate = _loginInfo.UserID;
                    salesDt.ItemUnitID = txtItemUnitID.Text.Trim();
                    salesDt.ItemFactor = Convert.ToDecimal(txtItemFactor.Text.Trim());
                    salesDt.Qty = (txtToggleOperator.Text == "-" ? (-1 * Convert.ToDecimal(numQty.Value)) : Convert.ToDecimal(numQty.Value));
                    salesDt.Price = Convert.ToDecimal(lblUnitPrice.Text.Trim());
                    salesDt.Disc1Pct = Convert.ToDecimal(1 == 0 ? 0 : 0);
                    salesDt.Disc1Amt = Convert.ToDecimal(lblUnitDisc1.Text.Trim());
                    salesDt.Disc2Pct = Convert.ToDecimal(0 == 0 ? 0 : 0);
                    salesDt.Disc2Amt = Convert.ToDecimal(lblUnitDisc2.Text.Trim());

                    salesDt.Disc3Pct = Convert.ToDecimal(0 == 0 ? 0 : 0);
                    salesDt.Disc3Amt = Convert.ToDecimal(0 == 0 ? 0 : 0);
                    salesDt.Description = "";
                    salesDt.Insert(conn, trans);
                }
            }
        #endregion
                        
        private void timerSystemCurrentTime_Tick(object sender, EventArgs e)
        {
            //lblSystemCurrentDate.Text = string.Format(Program.FormatDate, BussinessRules.ID.GetDateDBServer());
            //lblSystemCurrentTime.Text = string.Format(Program.FormatTime,BussinessRules.ID.GetDateDBServer());
            lblSystemCurrentTime.Text = string.Format(Program.FormatTime, Program.ConvertToDatetime(lblSystemCurrentDate.Text.Trim(), lblSystemCurrentTime.Text.Trim()).AddSeconds(1));
        }

        private void picLogo_Click(object sender, EventArgs e)
        {

        }

    }
}
