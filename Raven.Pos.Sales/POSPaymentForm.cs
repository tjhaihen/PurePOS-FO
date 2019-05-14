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
    public partial class POSPaymentForm : Form
    {
        #region "Private Variables"
            private DataTable _dtbPaymentDt;
            private LoginInfo _loginInfo;
            private bool _IsDonationOnly;
            private string _STxnStatusID;
            private string _TxnTypeID;
            private string _WhID;
            private string _UnitID;
            private string _CurrencyID;
            private decimal _CurrencyDate;

            private StatusPaymentForm _StatusPaymentForm;
            private enum StatusPaymentForm
            {
                Back, Complete
            }

            private TypePayment _TypePayment;
            private enum TypePayment
            {
                SinglePayment, CustomPayment
            }

            private enum myPaperOrientation
            {    
                Portrait = 0,
                Landscape = 1
            }

            string ldp_Bye = string.Empty;
        #endregion
        
        public POSPaymentForm(LoginInfo loginInfo)
        {
            _loginInfo = loginInfo;
            InitializeComponent();

            lblSystemInfo.Text = ProductName + " v." + ProductVersion;

            lblCompanyName.Text = _loginInfo.CompanyName;
            lblBranch.Text = _loginInfo.BranchName;

            lblCashierID.Text = _loginInfo.UserID;
            lblCashierName.Text = _loginInfo.UserName;

            ldp_Bye = Program.SelectOneByCommonSettingByDetailID("PDText", "05");

            this.WindowState = FormWindowState.Maximized;            
        }

        public string[] Payment(string SystemCurrentDate, string SystemCurrentTime, string p_STxnNo, string p_STxnDate, 
                            string p_receiptNo, string p_MemberID, string p_MemberName, string p_MemberSinceDate, 
                            string p_ValidThruDate, decimal p_GrandTotal, string STxnStatusID, bool IsDonationOnly, 
                            string TxnTypeID, string WhID, string UnitID, string CurrencyID, decimal CurrencyDate,
                            decimal DonationAmt, decimal GetVoucherAmount)
        {
            lblSystemCurrentDate.Text = SystemCurrentDate.Trim();
            lblSystemCurrentTime.Text = SystemCurrentTime.Trim();
            txtSTxnNo.Text = p_STxnNo;
            txtSTxnDate.Text = p_STxnDate;
            txtReceiptNo.Text = p_receiptNo;
            txtMemberID.Text = p_MemberID;
            lblMemberName.Text = p_MemberName;
            lblMemberSinceDate.Text = p_MemberSinceDate;
            lblValidThruDate.Text = p_ValidThruDate;
            txtPurchaseTotal.Text = string.Format(Program.FormatCurrency,p_GrandTotal);
            //txtRounding.Text = string.Format(Program.FormatCurrency, BussinessRules.RoundingFactor.GetRoundingAmount(p_GrandTotal).Rows[0]["RoundingAmt"]);
            txtDonationTotal.Text = string.Format(Program.FormatCurrency, DonationAmt);
            lblGetVoucherAmount.Text = string.Format(Program.FormatCurrency, GetVoucherAmount);
            _STxnStatusID = STxnStatusID.ToUpper().Trim();
            _TypePayment = TypePayment.SinglePayment;
            ToggleCustomPayment();
            _IsDonationOnly = IsDonationOnly;
            _TxnTypeID = TxnTypeID;
            _WhID = WhID;
            _UnitID = UnitID;
            _CurrencyID = CurrencyID;
            _CurrencyDate = CurrencyDate;
            ShowDialog();

            string[] _ArrayPayment;
            if (_StatusPaymentForm == StatusPaymentForm.Complete)
            {
                _ArrayPayment = new string[7];
                _ArrayPayment[0] = txtSTxnNo.Text.Trim();
                _ArrayPayment[1] = txtPurchaseTotal.Text.Trim();
                _ArrayPayment[2] = txtRounding.Text.Trim();
                _ArrayPayment[3] = txtPaidAmount.Text.Trim();
                _ArrayPayment[4] = lblChangeAmount.Text.Trim();
                _ArrayPayment[5] = txtSTxnNo.Text.Trim();
                _ArrayPayment[6] = Convert.ToString(_IsDonationOnly);
            }
            else
            {
                _ArrayPayment = new string[2];
                _ArrayPayment[0] = txtSTxnNo.Text.Trim();
                _ArrayPayment[1] = Convert.ToString(_IsDonationOnly);
            }
            return _ArrayPayment;
        }

        private DataTable LoadPayment()
        {
            var PaymentDt = new PaymentDt();
            var dtbPaymentDt = PaymentDt.SelectByReceiptNo(txtReceiptNo.Text);
            dtbPaymentDt.PrimaryKey = new[] { dtbPaymentDt.Columns["ID"] };
            return dtbPaymentDt;
        }

        #region "Control Events (KeyUp, KeyPress, Load)"
            private void POSPaymentForm_Load(object sender, EventArgs e)
            {
                if (_IsDonationOnly)
                {
                    if (!InputDonationAmt(true))
                        return;
                }
                else
                {
                    Program.PoleDisplay_Show(("Payment " + Program.POSIFLEX_SpaceCharPerLine).Substring(0, 20) +
                                        (string.Format(Program.FormatCurrency, Convert.ToDecimal(txtPurchaseTotal.Text.Trim()) + Convert.ToDecimal(txtRounding.Text.Trim())).Length > 13 ? "" : "Total ") +
                                        string.Format(Program.FormatCurrency, Convert.ToDecimal(txtPurchaseTotal.Text.Trim()) + Convert.ToDecimal(txtRounding.Text.Trim())));
                }

                PrepareNewPayment();

                if ((_STxnStatusID.Trim() == "S" || _STxnStatusID.Trim() == "O") && (Convert.ToDecimal(lblAmountDue.Text.Trim()) > 0) || _IsDonationOnly == true)
                    SearchPayment();
            }  

            private void POSPaymentForm_KeyUp(object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.F2: // Back 
                        if (btnBack.Enabled)
                        {
                            Back();
                        }
                        break;
                    case Keys.F3: // Search Payment Method
                        if (btnSearchPayment.Enabled)
                            SearchPayment();
                        break;
                    case Keys.F4: // Toggle Single/Custom Payment
                        if (btnToggleCustomPayment.Enabled)
                        {
                            ToggleCustomPayment();                            
                        }
                        break;
                    case Keys.F5: // Complete
                        if (btnComplete.Enabled)
                        {                            
                            Complete();
                        }
                        break;
                    case Keys.F6: // re - print
                        if (btnRePrint.Enabled)
                        {
                            //PrintWithUpdatePrintCounts();
                            //DirectPrintWithUpdatePrintCounts();
                            printBill.Print();
                        } 
                        break;
                    case Keys.F7: // TogglePaymentCancel
                        if (btnTogglePaymentCancel.Enabled)
                            TogglePaymentCancel();
                        break;
                    case Keys.F8: // VoidPayment
                        if (btnVoidPayment.Enabled)
                        {
                            DoVoidPayment();
                        }
                        break;
                    case Keys.F9: // Open Cash Drawer
                        if (btnOpenCashDrawer.Enabled)
                        {
                            OpenCashDrawer();
                        }
                        break;
                    case Keys.F10:
                        if (btnDonation.Enabled)
                        {
                            ShowInputDonationAmt();
                        }
                        break;
                }
            }

            private void txtPayment_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SelectPayment();
                }
            }            

            private void txtCardNo_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCardReader.Text = string.Empty;
                    string[] ArrayIDCard;
                    txtCardReader.Text = txtCardNo.Text.Trim();

                    if (txtCardReader.Text.Length > 0)
                    {
                        switch (txtCardReader.Text.Substring(0, 1))
                        {
                            case "%":
                                txtCardNo.Text = string.Empty;
                                txtCardOwner.Text = string.Empty;

                                if (txtCardReader.Text.Replace(" ", "").Substring(1, 1) == "?")
                                {
                                    // Flazz
                                    ArrayIDCard = txtCardReader.Text.Trim().Split('=');
                                    if (ArrayIDCard.Length >= 1)
                                    {
                                        txtCardNo.Text = ArrayIDCard[0].Trim().Substring(ArrayIDCard[0].Trim().IndexOf(';') + 1);
                                    }
                                    else
                                        txtCardOwner.Text = string.Empty;
                                }
                                else
                                {
                                    // Credit Cards
                                    ArrayIDCard = txtCardReader.Text.Trim().Split(Convert.ToChar(Program.SelectOneByCommonSettingByDetailID("SplitChar", "%").Substring(0, 1)));
                                    if (ArrayIDCard.Length >= 1)
                                    {
                                        txtCardNo.Text = ArrayIDCard[0].Trim().Substring(2);
                                        txtCardOwner.Text = ArrayIDCard[1].Trim();
                                    }
                                    else
                                        txtCardOwner.Text = string.Empty;
                                }
                                break;

                            case ";":
                                // Debit Cards
                                txtCardNo.Text = string.Empty;
                                txtCardOwner.Text = string.Empty;

                                ArrayIDCard = txtCardReader.Text.Trim().Split(Convert.ToChar(Program.SelectOneByCommonSettingByDetailID("SplitChar", ";").Substring(0, 1)));
                                if (ArrayIDCard.Length >= 1)
                                {
                                    txtCardNo.Text = ArrayIDCard[0].Trim().Substring(1);
                                }
                                else
                                    txtCardOwner.Text = string.Empty;
                                break;

                            default:
                                break;
                        }

                        if (txtCardOwner.Text.Trim() != string.Empty)
                            txtCardOwner.Enabled = false;
                        else
                            txtCardOwner.Enabled = true;
                    }

                    txtCardOwner.Focus();
                    //txtPaymentAmount.Focus();
                    //Program.MsgBox_Show(txtCardReader.Text.Trim());
                }
            }

            private void txtCardOwner_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPaymentAmount.Focus();
                }
            }

            private void txtPaymentAmount_KeyUp(object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter: //Save
                        if (SaveToDatabase())
                        {
                            //_dtbPaymentDt = LoadPayment();
                            //PopulateGridAndTotal();
                            PrepareNewPayment();
                        }
                        break;
                }
            }

            private void txtPaymentAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        #endregion

        #region "Control Events (ButtonClick)"
            private void btnBack_Click(object sender, EventArgs e)
            {
                Back();
            }

            private void btnToggleCustomPayment_Click(object sender, EventArgs e)
            {
                ToggleCustomPayment();
            }

            private void btnRePrint_Click(object sender, EventArgs e)
            {
                //PrintWithUpdatePrintCounts();
                //DirectPrintWithUpdatePrintCounts();
                printBill.Print();
            }

            private void btnTogglePaymentCancel_Click(object sender, EventArgs e)
            {
                TogglePaymentCancel();
            }

            private void btnVoidPayment_Click(object sender, EventArgs e)
            {
                DoVoidPayment();
            }

            private void btnSearchPayment_Click(object sender, EventArgs e)
            {
                SearchPayment();
            }

            private void btnComplete_Click(object sender, EventArgs e)
            {
                Complete();
            }

            private void btnOpenCashDrawer_Click(object sender, EventArgs e)
            {
                OpenCashDrawer();
            }

            private void btnDonation_Click(object sender, EventArgs e)
            {
                ShowInputDonationAmt();
            }  
        #endregion

        #region "Control Events (ComboBoxSelectedIndexChanged)"
            private void cboPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (Convert.ToString(cboPaymentMethod.SelectedValue) == "00") //|| Convert.ToString(cboPaymentMethod.SelectedValue) == "05"
                {
                    txtCardNo.Enabled = false;
                    txtCardOwner.Enabled = false;
                }
                else
                {
                    txtCardNo.Enabled = true;
                    txtCardOwner.Enabled = true;
                }
                PopulateCardType();
            }
        #endregion

        #region "Private Functions"
            private void OpenCashDrawer()
            {
                //Program.CashDrawer_Open("OpenCashDrawerSystem");

                String strPrinterName = Program.SelectOneByCommonSettingByDetailID("PrinterName", "Cashier");
                String txtprn = Convert.ToString((char)27) + 'p' + Convert.ToString((char)0) + Convert.ToString((char)20) + Convert.ToString((char)20);
                RawPrinterHelper.SendStringToPrinter(strPrinterName, txtprn);
            }            

            private void DoVoidPayment()
            {
                if (VoidPayment())
                {
                    txtReceiptNo.Text = string.Empty;
                    //txtDonationTotal.Text = "0.00";
                    PrepareNewPayment();
                }
            }

            private void ShowInputDonationAmt()
            {
                if (InputDonationAmt(false))
                    PrepareNewPayment();
            }

            private void SetAmount_txtPaymentAmount()
            {
                if ( //_TypePayment == TypePayment.CustomPayment &&
                    Convert.ToString(cboPaymentMethod.SelectedValue) != "00" &&
                    Convert.ToString(cboPaymentMethod.SelectedValue) != string.Empty)
                {
                    txtPaymentAmount.Text = lblAmountDue.Text;                    
                }
                else
                {
                    txtPaymentAmount.Text = string.Format(Program.FormatCurrency, 0);
                    txtPayment.Focus();
                    txtPaymentAmount.Focus();
                }
            }

            private void SetEnabled_txtPaymentAmount()
            {
                if ((_TypePayment == TypePayment.CustomPayment &&
                    Convert.ToString(cboPaymentMethod.SelectedValue) != "00" &&
                    Convert.ToString(cboPaymentMethod.SelectedValue) != "04" &&
                    Convert.ToString(cboPaymentMethod.SelectedValue) != string.Empty) || 
                    _STxnStatusID.Trim() == "V" || _STxnStatusID.Trim() == "C")
                {
                    txtPaymentAmount.ReadOnly = true;
                }
                else
                {
                    txtPaymentAmount.ReadOnly = false;
                }
                SetAmount_txtPaymentAmount();
            }

            private void SetEnabled_btnDonation()
            {
                if (Convert.ToDecimal(txtDonationTotal.Text.Trim()) == 0)
                {
                    btnDonation.Enabled = true;
                }
                else
                {
                    btnDonation.Enabled = false;
                }
            }

            private void PopulatePaymentMethod()
            {
                Program.PopulateByCommonSetting(cboPaymentMethod, "PaymentMethod");
                PopulateCardType();
            }

            private void PopulateCardType()
            {
                if (Convert.ToString(cboPaymentMethod.SelectedValue) == "01")
                    Program.PopulateByCommonSetting(cboCardType, "DebitCardType");
                else if (Convert.ToString(cboPaymentMethod.SelectedValue) == "02")
                    Program.PopulateByCommonSetting(cboCardType, "CreditCardType");
                else
                    cboCardType.DataSource = null;
            }

            private void PopulateGridAndTotal()
            {
                PopulateTotal();

                grdPayment.AutoGenerateColumns = false;
                grdPayment.DataSource = _dtbPaymentDt;
                grdPayment.ResumeLayout();
            }

            private void PopulateTotal()
            {
                var PaidTotal = (from DataRow row in _dtbPaymentDt.Rows
                                 where row["IsVoid"].Equals(false)
                                 select Convert.ToDecimal(row["Amount"])).Sum();

                txtPaidAmount.Text = String.Format(Program.FormatCurrency, PaidTotal);

                var GrandTotal = Convert.ToDecimal(txtPurchaseTotal.Text) + Convert.ToDecimal(txtDonationTotal.Text) + Convert.ToDecimal(txtRounding.Text);

                txtGrandTotal.Text = String.Format(Program.FormatCurrency, GrandTotal);

                decimal AmountDue = (GrandTotal - PaidTotal);

                if (AmountDue >= 0)
                {
                    lblAmountDue.Text = String.Format(Program.FormatCurrency, AmountDue);
                    lblChangeAmount.Text = String.Format(Program.FormatCurrency, 0);
                }
                else
                {
                    lblAmountDue.Text = String.Format(Program.FormatCurrency, 0);

                    var VouhcerAmount = (from DataRow row in _dtbPaymentDt.Rows
                                         where row["IsVoid"].Equals(false) && row["PaymentTypeID"].Equals("04")
                                         select Convert.ToDecimal(row["Amount"])).Sum();

                    if (((PaidTotal - VouhcerAmount) - GrandTotal > 0))
                        lblChangeAmount.Text = String.Format(Program.FormatCurrency, Math.Abs(AmountDue));
                    else
                        lblChangeAmount.Text = String.Format(Program.FormatCurrency, 0);
                }
            }

            private void PrepareNewPayment()
            {
                _dtbPaymentDt = LoadPayment();
                PopulateGridAndTotal();
                btnRePrint.Enabled = false;
                btnDonation.Enabled = true;
                cboPaymentMethod.DataSource = null;
                txtCardNo.Text = string.Empty;
                txtCardOwner.Text = string.Empty;
                txtCardReader.Text = string.Empty;
                txtCardNo.Enabled = false;
                txtCardOwner.Enabled = false;
                txtPaymentAmount.Text = string.Format(Program.FormatCurrency, 0);
                txtPayment.Text = string.Empty;
                SetEnabled_btnDonation();

                if ((_STxnStatusID.Trim() == "C" || _STxnStatusID.Trim() == "V" || Convert.ToDecimal(lblAmountDue.Text.Trim()) <= 0)) //&& Convert.ToDecimal(txtPaidAmount.Text.Trim()) > 0
                {
                    btnSearchPayment.Enabled = false;
                    btnTogglePaymentCancel.Enabled = false;
                    txtPayment.Enabled = false;
                    txtPaymentAmount.Enabled = false;
                    btnToggleCustomPayment.Enabled = false;
                    btnBack.Enabled = (_STxnStatusID.Trim() == "C" || _STxnStatusID.Trim() == "V");

                    if (_STxnStatusID.Trim() != "C" && _STxnStatusID.Trim() != "V")
                    {
                        btnComplete.Enabled = true;
                        btnOpenCashDrawer.Enabled = true;
                        btnVoidPayment.Enabled = true;
                    }
                    else
                    {
                        btnComplete.Enabled = false;
                        btnOpenCashDrawer.Enabled = false;
                        btnVoidPayment.Enabled = false;

                        
                        if (_STxnStatusID.Trim() == "C")
                        {
                            btnRePrint.Enabled = true;
                            btnDonation.Enabled = false;
                        }
                        else if (_STxnStatusID.Trim() == "V")
                            btnDonation.Enabled = false;

                    }
                }
                else
                {
                    btnSearchPayment.Enabled = true;
                    btnTogglePaymentCancel.Enabled = true;
                    btnVoidPayment.Enabled = true;
                    btnComplete.Enabled = (Convert.ToDecimal(lblAmountDue.Text.Trim()) <= 0 ); //&& Convert.ToDecimal(txtPaidAmount.Text.Trim()) > 0
                    btnToggleCustomPayment.Enabled = (Convert.ToDecimal(txtPaidAmount.Text.Trim()) <= 0);
                    txtPayment.Enabled = true;
                    txtPaymentAmount.Enabled = true;
                    btnOpenCashDrawer.Enabled = true;
                    btnBack.Enabled = (Convert.ToDecimal(txtPaidAmount.Text.Trim()) <= 0);
                }
                
                txtPayment.Focus();
            }

            private void SearchPayment()
            {
                PaymentDt _Payment;
                using (var frm = new SearchQuickPaymentForm())
                {
                    _Payment = frm.Search();
                }

                if (_Payment != null)
                {
                    txtPayment.Text = _Payment.ID;
                    SelectPayment();
                }
            }

            private void ToggleCustomPayment()
            {
                if (_TypePayment == TypePayment.SinglePayment)
                {
                    btnToggleCustomPayment.Text = "Custom Payment";
                    lblSelectedFunction.Text = "Single Payment";
                    _TypePayment = TypePayment.CustomPayment;
                }
                else
                {
                    btnToggleCustomPayment.Text = "Single Payment";
                    lblSelectedFunction.Text = "Custom Payment";
                    _TypePayment = TypePayment.SinglePayment;
                }
                SetEnabled_txtPaymentAmount();
                txtPayment.Focus();
            }

            private void TogglePaymentCancel()
            {
                //if (txtToggleOperator.Text == "+")
                //{
                //    txtToggleOperator.Text = "-";
                //}
                //else
                //{
                //    txtToggleOperator.Text = "+";
                //}

                if (txtReceiptNo.Text.Trim() == string.Empty)
                    Program.MsgBox_Show("Nothing to cancel.");
                else
                {
                    using (var frm = new CancelPaymentForm())
                    {
                        if (frm.Search(txtReceiptNo.Text.Trim(), _loginInfo.UserID.Trim()))
                        {
                            _dtbPaymentDt = LoadPayment();
                            PopulateGridAndTotal();
                        }
                    }
                }
            
            }

            private void Back()
            {
                if (_IsDonationOnly && txtSTxnNo.Text.Trim() != string.Empty)
                {
                    if (Program.MsgBox_Show("Are you sure want to void this Donation?", "Attention", "YesNo") == false)
                        return;

                    if (!AuthorizeForm())
                        return;
                }

                _StatusPaymentForm = StatusPaymentForm.Back;
                Close();
            }
           
            private bool InputDonationAmt(bool IsOnly)
            {
                var retval = false;
                using (var frm = new DonationInputForm())
                {
                    var _ArrayDonation = frm.DonationInput(_IsDonationOnly,
                        (Convert.ToDecimal(txtDonationTotal.Text.Trim()) == 0 ? Convert.ToDecimal(lblChangeAmount.Text.Trim()) : Convert.ToDecimal(txtDonationTotal.Text.Trim())),
                                                           Convert.ToDecimal(txtPurchaseTotal.Text.Trim()) +
                                                           Convert.ToDecimal(txtRounding.Text.Trim()));
                    if (Convert.ToDecimal(_ArrayDonation[1].Trim()) < 0)
                    {
                        if (IsOnly)
                            Back();
                    }
                    else
                    {
                        if (SaveDonationToDatabase(_ArrayDonation[0], Convert.ToDecimal(_ArrayDonation[1].Trim())))
                        {
                            txtDonationTotal.Text = string.Format(Program.FormatCurrency, Convert.ToDecimal(_ArrayDonation[1].Trim()));                            
                            retval = true;
                        }
                    }
                }
                SetEnabled_btnDonation();
                return retval;
            }

            private void Complete()
            {
                if (Convert.ToDecimal(lblAmountDue.Text.Trim()) > 0)
                {
                    Program.MsgBox_Show("Amount Due for this transaction still remains. Transaction can not be completed.");
                    return;
                }

                //if (!PrintWithUpdatePrintCounts())
                //if (!DirectPrintWithUpdatePrintCounts())
                    //return;    

                Approval();
                printBill.Print();

                _StatusPaymentForm = StatusPaymentForm.Complete;
                Close();
            }

            private bool PrintWithUpdatePrintCounts()
            {
                if (txtReceiptNo.Text.Trim() == "")
                {
                    Program.MsgBox_Show("Nothing to print.");
                    //MessageBox.Show("Nothing to print.");
                    return false;
                }
                Program.PrintReport("@STxnNo=" + txtSTxnNo.Text.Trim() + Program.SeparatorPReport +
                                    "UserID=" + _loginInfo.UserID, "prnBillReceipt", false );
                var PaymentHd = new PaymentHd();
                PaymentHd.ReceiptNo = txtReceiptNo.Text.Trim();
                PaymentHd.UserUpdate = _loginInfo.UserID.Trim();
                PaymentHd.UpdatePrintCounts();
                PaymentHd.Dispose();
                PaymentHd = null;
                Program.PoleDisplay_Show((("Change " + lblChangeAmount.Text.Trim()) + Program.POSIFLEX_SpaceCharPerLine).Substring(0, 20) + ldp_Bye);
                return true;
            }

            private string DirectPrintWithUpdatePrintCounts()
            {
                int MaxStringPerLine = Convert.ToInt16(Program.SelectOneByCommonSettingByDetailID("DirectPrint", "MaxLenPerLine"));
                
                // Get Company Data
                string _CompanyName, _PrimaryAddress;
                string _PrimaryPhoneNo, _SecondaryPhoneNo1, _SecondaryPhoneNo2;
                string _TIN, _Email, _Website;
                string _CustomFooterText;

                var Company = new Company();
                var dtbCompany = Company.SelectOne();
                _CompanyName = Company.CompanyName;
                _PrimaryAddress = Company.PrimaryAddress;
                _PrimaryPhoneNo = Company.PrimaryPhoneNo;
                _SecondaryPhoneNo1 = Company.SecondaryPhoneNo1;
                _SecondaryPhoneNo2 = Company.SecondaryPhoneNo2;
                _TIN = Company.TIN;
                _Email = Company.Email;
                _Website = Company.Website;
                _CustomFooterText = Company.CustomFooterText;
                                
                // Get Sales Transaction Data
                string _lineBreak = string.Empty;
                string _STxnNo;
                string _UserID;
                string _ReceiptNo, _ReceiptDate;
                string _ItemID, _ItemName, _Qty, _UnitPrice, _TotalPricePerLine;
                decimal _CountOfItem = 0;
                decimal _SumOfQty = 0; 
                decimal _SubTotal = 0;
                decimal _SumOfPayment = 0;

                //_lineBreak
                for (int lb = 0; lb < MaxStringPerLine; lb++)
                {
                    _lineBreak += "-";
                }
                _lineBreak += "\n";

                _UserID = _loginInfo.UserID.Trim();
                
                decimal _printCounts;
                var invoiceFO = new InvoiceFO();
                invoiceFO.STxnNo = txtSTxnNo.Text.Trim();
                DataTable dtbInvoiceFO = invoiceFO.GetBillReceiptWithPaymentData(_UserID.Trim());
                _STxnNo = invoiceFO.STxnNo;
                _printCounts = Convert.ToDecimal(dtbInvoiceFO.Rows[0]["printCounts"]);
                _ReceiptNo = Convert.ToString(dtbInvoiceFO.Rows[0]["ReceiptNo"]);
                _ReceiptDate = string.Format(Program.FormatDate, Convert.ToDateTime(dtbInvoiceFO.Rows[0]["ReceiptDate"]));
                
                // Update print counts
                var PaymentHd = new PaymentHd();
                PaymentHd.ReceiptNo = txtReceiptNo.Text.Trim();
                PaymentHd.UserUpdate = _UserID.Trim();
                PaymentHd.UpdatePrintCounts();                
                PaymentHd.Dispose();
                PaymentHd = null;

                // Set printer name
                // Just use Default Printer on client;
                //String strPrinterName = Program.SelectOneByCommonSettingByDetailID("PrinterName", "Cashier");
                
                // Set text to be printed out
                // Header
                string txtprn;
                txtprn = Program.TextToCenter("", _CompanyName.Trim(), MaxStringPerLine) + "\n";
                txtprn += Program.TextToCenter("", _PrimaryAddress.Trim(), MaxStringPerLine) + "\n";
                if (_PrimaryPhoneNo.Length > 0)
                {
                    txtprn += Program.TextToCenter("", "Phone: " + _PrimaryPhoneNo.Trim(), MaxStringPerLine) + "\n";
                }
                if (_TIN.Length > 0)
                {
                    txtprn += Program.TextToCenter("", "NPWP: " + _TIN.Trim(), MaxStringPerLine) + "\n";
                }
                if (_printCounts > 0)
                {
                    txtprn += Program.TextToCenter("", "COPY", MaxStringPerLine) + "\n";
                }
                txtprn += "\n";
                txtprn += "Txn No." + Program.TextToDesiredStartPosition("Txn No.", ": ", 15) + _STxnNo.Trim() + "\n";
                txtprn += "Receipt No." + Program.TextToDesiredStartPosition("Receipt No.", ": ", 15) + _ReceiptNo.Trim() + "\n";
                txtprn += "Receipt Date" + Program.TextToDesiredStartPosition("Receipt Date", ": ", 15) + _ReceiptDate.Trim() + "\n";
                txtprn += _lineBreak;
                txtprn += Program.TextToCenter("", _UserID.Trim() + " " + string.Format(Program.FormatDate, DateTime.Now) + " " + string.Format(Program.FormatTime, DateTime.Now), MaxStringPerLine) + "\n";
                txtprn += _lineBreak;

                // Start Detail Item Transactions
                foreach (DataRow row in dtbInvoiceFO.Rows)
                {
                    if (Convert.ToString(row["Urutan"]) == "01")
                    {
                        _CountOfItem += 1;
                        _SumOfQty += Convert.ToDecimal(row["Qty"]);
                        _SubTotal += Convert.ToDecimal(row["Qty"]) * Convert.ToDecimal(row["Price"]);

                        _ItemID = Convert.ToString(row["ItemID"]);
                        _ItemName = Convert.ToString(row["ItemName"]);
                        _Qty = string.Format(Program.FormatQty, Convert.ToDecimal(row["Qty"]));
                        _UnitPrice = string.Format(Program.FormatCurrencyForBillReceipt, Convert.ToDecimal(row["Price"]));
                        _TotalPricePerLine = string.Format(Program.FormatCurrencyForBillReceipt, Convert.ToDecimal(row["Qty"]) * Convert.ToDecimal(row["Price"]));

                        txtprn += Program.TextPerLineDueToMaxLenPerLine(_ItemName.Trim() + "-" + _ItemID.Trim(), MaxStringPerLine);
                        txtprn += _Qty.Trim() + Program.TextToDesiredStartPosition(_Qty.Trim(), "@" + _UnitPrice.Trim(), 9) + Program.TextToRight(_Qty.Trim() + Program.TextToDesiredStartPosition(_Qty.Trim(), "@" + _UnitPrice.Trim(), 9), _TotalPricePerLine.Trim(), MaxStringPerLine) + "\n";   
                    }
                }

                txtprn += _lineBreak;
                // Start Sub Total Section
                txtprn += "SUB TOTAL " + Program.TextToRight("SUB TOTAL ", string.Format(Program.FormatCurrencyForBillReceipt, _SubTotal), MaxStringPerLine) + "\n";
                txtprn += "Rounding " + Program.TextToRight("Rounding ", string.Format(Program.FormatCurrencyForBillReceipt, Convert.ToDecimal(dtbInvoiceFO.Rows[0]["Rounding"])), MaxStringPerLine) + "\n";
                if (Convert.ToDecimal(dtbInvoiceFO.Rows[0]["DonationAmt"]) > 0)
                {
                    txtprn += _lineBreak;
                    txtprn += "TOTAL SALES " + Program.TextToRight("TOTAL SALES ", string.Format(Program.FormatCurrencyForBillReceipt, _SubTotal + Convert.ToDecimal(dtbInvoiceFO.Rows[0]["Rounding"])), MaxStringPerLine) + "\n";
                    txtprn += "Donation Amount " + Program.TextToRight("Donation Amount ", string.Format(Program.FormatCurrencyForBillReceipt, Convert.ToDecimal(dtbInvoiceFO.Rows[0]["DonationAmt"])), MaxStringPerLine) + "\n";                
                }
                txtprn += _lineBreak;
                txtprn += "GRAND TOTAL " + Program.TextToRight("GRAND TOTAL ", string.Format(Program.FormatCurrencyForBillReceipt, _SubTotal + Convert.ToDecimal(dtbInvoiceFO.Rows[0]["Rounding"]) + Convert.ToDecimal(dtbInvoiceFO.Rows[0]["DonationAmt"])), MaxStringPerLine) + "\n";
                txtprn += "\n";
                txtprn += "#Line: " + Program.TextToDesiredStartPosition("#Line: ", Convert.ToString(_CountOfItem), 8) + Program.TextToRight(("#Line: " + Program.TextToDesiredStartPosition("#Line: ", Convert.ToString(_CountOfItem), 8)), ("#Item: " + Convert.ToString(_SumOfQty)), MaxStringPerLine) + "\n";
                txtprn += _lineBreak;

                // Start Detail Payment
                foreach (DataRow row in dtbInvoiceFO.Rows)
                {
                    if (Convert.ToString(row["Urutan"]) == "02")
                    {
                        _SumOfPayment += Convert.ToDecimal(row["Price"]);

                        txtprn += Convert.ToString(row["ItemName"]) + Program.TextToRight(Convert.ToString(row["ItemName"]), string.Format(Program.FormatCurrencyForBillReceipt, Convert.ToDecimal(row["Price"])), MaxStringPerLine) + "\n";
                        if ((Convert.ToString(row["PaymentTypeNo"]) != "") && (Convert.ToString(row["CardHolderName"]) != ""))
                        {
                            txtprn += Program.TextPerLineDueToMaxLenPerLine(Convert.ToString(row["CardHolderName"]).Trim() + " " + Program.Left(Convert.ToString(row["PaymentTypeNo"]).Trim(), Convert.ToString(row["PaymentTypeNo"]).Trim().Length - 4) + "xxxx", MaxStringPerLine);
                        }
                    }
                }

                txtprn += _lineBreak;
                txtprn += "PAYMENT TOTAL " + Program.TextToRight("PAYMENT TOTAL ", string.Format(Program.FormatCurrencyForBillReceipt, _SumOfPayment), MaxStringPerLine) + "\n";

                if (_SubTotal + Convert.ToDecimal(dtbInvoiceFO.Rows[0]["Rounding"]) + Convert.ToDecimal(dtbInvoiceFO.Rows[0]["DonationAmt"]) - _SumOfPayment >= 0)
                {
                    txtprn += "CHANGE " + Program.TextToRight("CHANGE ", "0", MaxStringPerLine) + "\n";
                }
                else
                {
                    txtprn += "CHANGE " + Program.TextToRight("CHANGE ", string.Format(Program.FormatCurrencyForBillReceipt, _SumOfPayment - (_SubTotal + Convert.ToDecimal(dtbInvoiceFO.Rows[0]["Rounding"]) + Convert.ToDecimal(dtbInvoiceFO.Rows[0]["DonationAmt"]))), MaxStringPerLine) + "\n";
                }

                if (Convert.ToDecimal(dtbInvoiceFO.Rows[0]["GetVoucherAmount"]) > 0)
                {
                    txtprn += "Voucher Aquired " + Program.TextToRight("Voucher Aquired ", string.Format(Program.FormatCurrencyForBillReceipt, Convert.ToDecimal(dtbInvoiceFO.Rows[0]["GetVoucherAmount"])), MaxStringPerLine) + "\n";
                }

                txtprn += "\n" + "\n";
                if (_Email.Length > 0)
                {
                    txtprn += Program.TextToCenter("", "Email: " + _Email, MaxStringPerLine) + "\n";
                }

                if (_Website.Length > 0)
                {
                    txtprn += Program.TextToCenter("", _Website, MaxStringPerLine) + "\n";
                }                
                txtprn += Program.TextToCenter("", _CustomFooterText, MaxStringPerLine) + "\n";
                
                // Send string to printer
                //RawPrinterHelper.SendStringToPrinter(strPrinterName, txtprn);

                return txtprn;
            }

            private void printBill_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
            {
                if (txtReceiptNo.Text.Trim() == "")
                {
                    Program.MsgBox_Show("Nothing to print.");
                    //return false;
                }

                Font printFont;
                printFont = new Font("BatangChe", 8);

                e.Graphics.DrawString(DirectPrintWithUpdatePrintCounts(), printFont, Brushes.Black, 0, 0);

                // Set pole display text
                Program.PoleDisplay_Show((("Change " + lblChangeAmount.Text.Trim()) + Program.POSIFLEX_SpaceCharPerLine).Substring(0, 20) + ldp_Bye);
            }

            private bool AuthorizeForm()
            {
                var retval = false;
                using (var frm = new AuthorizeForm())
                {
                    if (frm.GetAuthorize())
                        retval = true;
                }
                return retval;
            }

            //private bool DirectPrintCR(DataSet ds, String ReportPath, String mPaperSize, Int16 NumberOFCopies = 1, Boolean Collated = false,
            //    Int16 StartPage  = 0, Int16 EndPage = 0, myPaperOrientation mPaperOrientation = myPaperOrientation.Portrait)            
            //    {
            //    Try
            //    Dim oRpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            //    Dim repOptions As CrystalDecisions.CrystalReports.Engine.PrintOptions
            //    With oRpt
            //        repOptions = .PrintOptions
            //        With repOptions
            //            .PrinterName = PrinterName
            //            Select Case mPaperOrientation
            //                Case myPaperOrientation.Landscape
            //                    .PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
            //                Case myPaperOrientation.Portrait
            //                    .PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
            //            End Select
            //            .PaperSize = GetPapersizeID(Me.PrinterName, mPaperSize)
            //        End With
            //        .Load(ReportPath, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
            //        .SetDataSource(ds.Tables(0))
            //        .PrintToPrinter(NumberOFCopies, Collated, StartPage, EndPage)
            //    End With

            //    Return True
            //Catch ex As Exception
            //    ' Just do nothing here
            //    Return False
            //End Try
            //}

        #endregion 

        #region "CRUD Functions"
            private bool SaveToDatabase()
            {
                //if ((txtPaymentAmount.Text))
                //{
                //    //MessageBox.Show("Payment amount must be greater than 0.");
                //    return false;
                //}
                try
                {
                    decimal.Parse(txtPaymentAmount.Text);
                }
                catch
                {
                    Program.MsgBox_Show("Payment Amount must be numeric.");
                    if (_TypePayment == TypePayment.CustomPayment)
                        txtPaymentAmount.Text = lblAmountDue.Text.Trim();
                    else if (_TypePayment == TypePayment.SinglePayment)
                        txtPaymentAmount.Text = string.Format(Program.FormatCurrency, 0);

                    return false;
                }

                if (Convert.ToString(cboPaymentMethod.SelectedValue) == "" || Convert.ToString(cboPaymentMethod.SelectedValue) == "none")
                {
                    Program.MsgBox_Show("Payment Method cannot empty.");
                    //MessageBox.Show("Payment method cannot empty.");
                    return false;
                }

                if ((Convert.ToString(cboPaymentMethod.SelectedValue) == "02" || Convert.ToString(cboPaymentMethod.SelectedValue) == "03") && txtCardNo.Text.Trim() == "")
                {
                    Program.MsgBox_Show("Card no. cannot empty.");
                    //MessageBox.Show("Card no. cannot empty.");
                    return false;
                }

                if (txtPaymentAmount.Text.Trim() == "")
                {
                    Program.MsgBox_Show("Payment amount cannot empty.");
                    //MessageBox.Show("Payment amount cannot empty.");
                    return false;
                }

                if (Convert.ToDecimal(txtPaymentAmount.Text) <= 0)
                {
                    //MessageBox.Show("Payment amount must be greater than 0.");
                    return false;
                }

                if (txtToggleOperator.Text == "-")
                {
                    if (
                        !((from DataRow row in LoadPayment().Rows
                           where row["PaymentTypeID"].Equals(Convert.ToString(cboPaymentMethod.SelectedValue)) && row["CardTypeID"].Equals(Convert.ToString(cboCardType.SelectedValue))
                           select Convert.ToDecimal(row["Amount"])
                            ).Sum() >= Convert.ToDecimal(txtPaymentAmount.Text.Trim()))
                        )
                    {
                        Program.MsgBox_Show("Payment does not exist in this transaction. Cancelation failed.");
                        //MessageBox.Show("Payment does not exist in this transaction. Cancelation failed.");
                        return false;
                    }
                }
                else
                {
                    if (_TypePayment == TypePayment.CustomPayment &&
                    Convert.ToString(cboPaymentMethod.SelectedValue) == "00" &&
                    Convert.ToDecimal(txtPaymentAmount.Text.Trim()) < Convert.ToDecimal(lblAmountDue.Text.Trim())
                    )
                    {
                        Program.MsgBox_Show("Payment must be equal or greater than Amount Due.");
                        //MessageBox.Show("Payment must be equal or greater than Amount Due.");
                        return false;
                    }

                    if (Convert.ToString(cboPaymentMethod.SelectedValue) != "00" &&  Convert.ToString(cboPaymentMethod.SelectedValue) != "04" && //Convert.ToString(cboPaymentMethod.SelectedValue) != "05" &&
                        Convert.ToDecimal(txtPaymentAmount.Text.Trim()) > Convert.ToDecimal(lblAmountDue.Text.Trim())
                        )
                    {
                        Program.MsgBox_Show("Payment must be equal or less than Amount Due.");
                        //MessageBox.Show("Payment must be equal or less than Amount Due.");
                        return false;
                    }
                }

                bool retval = false;
                var conn = new SqlConnection(HisConfiguration.ConnectionString);
                SqlTransaction trans = null;

                try
                {
                    conn.Open();
                    trans = conn.BeginTransaction();
                    SavePaymentHd(conn, trans);
                    SavePaymentDt(conn, trans);
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

                //if (
                //     (
                //        (from DataRow row in LoadPayment().Rows
                //        select Convert.ToDecimal(row["Amount"])
                //        ).Sum() >= (Convert.ToDecimal(txtPurchaseTotal.Text.Trim()) + Convert.ToDecimal(txtRounding.Text.Trim()))
                //     )
                //   )
                //{
                    //_StatusPaymentForm = StatusPaymentForm.Complete;
                    //PrintWithUpdatePrintCounts();
                    //if (_TypePayment == TypePayment.CustomPayment)
                    //    Close();
                //}

                return retval;
            }

            private void SavePaymentHd(SqlConnection conn, SqlTransaction trans)
            {
                using (var PaymentHd = new PaymentHd())
                {
                    PaymentHd.STxnNo = txtSTxnNo.Text.Trim();
                    //PaymentHd.ReceiptDate = Program.ConvertToDate(txtSTxnDate.Text.Trim());
                    PaymentHd.ReceiptDate = Program.ConvertToDate(lblSystemCurrentDate.Text.Trim());
                    PaymentHd.Rounding = Convert.ToDecimal(txtRounding.Text.Trim());
                    PaymentHd.UserInsert = _loginInfo.UserID;
                    PaymentHd.UserUpdate = _loginInfo.UserID;
                    PaymentHd.Description = "";

                    PaymentHd.ReceiptNo = txtReceiptNo.Text.Trim();
                    if (PaymentHd.SelectOne().Rows.Count == 0)
                    {
                        txtReceiptNo.Text = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("PaymentHD", "ReceiptNo", conn, trans, "FP");
                        PaymentHd.ReceiptNo = txtReceiptNo.Text.Trim();
                        PaymentHd.Insert(conn, trans);
                    }
                    else
                    {
                        PaymentHd.Update(conn, trans);
                    }
                }
            }

            private void SavePaymentDt(SqlConnection conn, SqlTransaction trans)
            {
                using (var PaymentDt = new PaymentDt())
                {
                    PaymentDt.ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("PaymentDt", "ID", conn, trans, "FP");
                    PaymentDt.ReceiptNo = txtReceiptNo.Text.Trim();
                    PaymentDt.PaymentTypeID = Convert.ToString(cboPaymentMethod.SelectedValue);
                    PaymentDt.EDCID = "";
                    PaymentDt.CardTypeID = Convert.ToString(cboCardType.SelectedValue);
                    PaymentDt.CardFee = 0;
                    PaymentDt.PaymentTypeNo = txtCardNo.Text.Trim();
                    PaymentDt.CardHolderName = txtCardOwner.Text.Trim();
                    PaymentDt.CardReaderText = txtCardReader.Text.Trim();
                    PaymentDt.Amount = (txtToggleOperator.Text == "-") ? -1 * Convert.ToDecimal(txtPaymentAmount.Text.Trim()) : Convert.ToDecimal(txtPaymentAmount.Text.Trim());
                    PaymentDt.UserInsert = _loginInfo.UserID;
                    PaymentDt.UserUpdate = _loginInfo.UserID;
                    PaymentDt.Description = "";
                    PaymentDt.Insert(conn, trans);
                }
            }

            private bool SaveDonationToDatabase(string DonationType, decimal DonationAmt)
            {
                bool retval = false;
                var conn = new SqlConnection(HisConfiguration.ConnectionString);
                SqlTransaction trans = null;

                try
                {
                    conn.Open();
                    trans = conn.BeginTransaction();
                    SaveDonation(conn, trans, DonationType, DonationAmt);
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
            private void SaveDonation(SqlConnection conn, SqlTransaction trans, string DonationType, decimal DonationAmt)
            {
                using (var salesHd = new SalesUnitHd())
                {
                    bool fNew = false;
                    salesHd.STxnNo = txtSTxnNo.Text.Trim();
                    if (!(salesHd.SelectOne().Rows.Count > 0))
                        fNew = true;
                    
                    salesHd.BranchID = _loginInfo.BranchID;
                    salesHd.STxnDate = Program.ConvertToDate(txtSTxnDate.Text.Trim());
                    salesHd.StxnTypeID = _TxnTypeID;
                    salesHd.WhID = _WhID;
                    salesHd.UnitID = _UnitID;
                    salesHd.Currency = _CurrencyID;
                    salesHd.CurrencyRate = _CurrencyDate;
                    salesHd.DonationType = DonationType;
                    salesHd.DonationAmt = DonationAmt;
                    salesHd.UserInsert = _loginInfo.UserID;
                    salesHd.UserUpdate = _loginInfo.UserID;
                    salesHd.STxnStatusID = _STxnStatusID.Trim();

                    if (fNew)
                    {
                        txtSTxnNo.Text = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("SalesUnitHD", "STxnNo", conn, trans, "DU", " Where STxnNo like 'DU%' ");
                        salesHd.STxnNo = txtSTxnNo.Text.Trim();
                        salesHd.InsertDonation(conn, trans);
                    }
                    else
                    {
                        salesHd.UpdateDonation(conn, trans);
                    }
                }
            }

            private bool VoidPayment()
            {
                if (txtReceiptNo.Text.Trim() == "")
                {
                    Program.MsgBox_Show("Nothing to void.");
                    //MessageBox.Show("Nothing to void.");
                    return false;
                }

                if (Program.MsgBox_Show("Are you sure want to void this payment?", "Attention", "YesNo") == false)
                    return false;

                if (!AuthorizeForm())
                    return false;

                bool retval = false;
                var conn = new SqlConnection(HisConfiguration.ConnectionString);
                SqlTransaction trans = null;

                try
                {
                    conn.Open();
                    trans = conn.BeginTransaction();
                    VoidPaymentHd(conn, trans);
                    VoidPaymentDt(conn, trans);
                    //ResetDonationAmount(conn, trans);
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

            private void VoidPaymentHd(SqlConnection conn, SqlTransaction trans)
            {
                using (var PaymentHd = new PaymentHd())
                {
                    PaymentHd.ReceiptNo = txtReceiptNo.Text.Trim();
                    PaymentHd.UserVoid = _loginInfo.UserID;
                    PaymentHd.Delete(conn, trans);
                }
            }

            private void VoidPaymentDt(SqlConnection conn, SqlTransaction trans)
            {
                using (var PaymentDt = new PaymentDt())
                {
                    PaymentDt.ReceiptNo = txtReceiptNo.Text.Trim();
                    PaymentDt.UserVoid = _loginInfo.UserID;
                    PaymentDt.Delete(conn, trans);
                }
            }

            private void ResetDonationAmount(SqlConnection conn, SqlTransaction trans)
            {
                using (var SalesUnitHd = new SalesUnitHd())
                {
                    SalesUnitHd.STxnNo = txtSTxnNo.Text.Trim();
                    SalesUnitHd.UserUpdate = _loginInfo.UserID;
                    SalesUnitHd.ResetDonationAmount(conn, trans);
                }
            }
      
            private void SelectPayment()
            {
                var paymentdt = new PaymentDt();
                paymentdt.ID = txtPayment.Text.Trim();
                var dtbPaymentDt = paymentdt.SelectAllSearchQuickPayment();
                if (dtbPaymentDt.Rows.Count > 0)
                {
                    PopulatePaymentMethod();
                    cboPaymentMethod.SelectedValue = dtbPaymentDt.Rows[0]["PaymentTypeID"];
                    cboCardType.SelectedValue = dtbPaymentDt.Rows[0]["CardTypeID"];
                    if (txtCardNo.Enabled == true)
                    {
                        txtCardNo.Focus();
                        txtCardOwner.Enabled = true;
                        txtRounding.Text = string.Format(Program.FormatCurrency, 0);
                        
                    }
                    else
                    {
                        txtPaymentAmount.Focus();
                        txtCardOwner.Enabled = false;
                        txtRounding.Text = string.Format(Program.FormatCurrency, BussinessRules.RoundingFactor.GetRoundingAmount(Convert.ToDecimal(txtPurchaseTotal.Text.Trim())).Rows[0]["RoundingAmt"]);
                        
                    }
                    PopulateTotal();
                    //SetAmount_txtPaymentAmount();
                }
                else
                {
                    cboPaymentMethod.DataSource = null;
                    cboCardType.DataSource = null;
                    txtCardNo.Enabled = false;
                    txtCardOwner.Enabled = false;
                    txtPayment.Text = string.Empty;
                    txtPayment.Focus();
                    txtPaymentAmount.Text = string.Format(Program.FormatCurrency, 0);
                }
                txtCardNo.Text = string.Empty;
                txtCardOwner.Text = string.Empty;
                txtCardReader.Text = string.Empty;

                SetEnabled_txtPaymentAmount();                
            }

            private void Approval()
            {
                using (var ItemHistory = new ItemHistory())
                {
                    //Dim th As New BussinessRules.ItemHistory
                    //th.TxnNo = RadComboBoxSalesUnitID.Text.Trim
                    //th.UserInsert = Trim(MyBase.LoggedOnUserID)
                    //th.DoApproval(BussinessRules.TxnType.SalesCashier)
                    //th.Dispose()
                    //th = Nothing

                    ItemHistory.TxnNo = txtSTxnNo.Text.Trim();
                    ItemHistory.UserInsert = _loginInfo.UserID;
                    ItemHistory.DoApproval(TxnType.SalesCashier);

                    ItemHistory.Dispose();                    
                }                
            }
        #endregion

        private void timerSystemCurrentTime_Tick(object sender, EventArgs e)
        {
            //lblSystemCurrentDate.Text = string.Format(Program.FormatDate, BussinessRules.ID.GetDateDBServer());
            //lblSystemCurrentTime.Text = string.Format(Program.FormatTime, BussinessRules.ID.GetDateDBServer());
            lblSystemCurrentTime.Text = string.Format(Program.FormatTime, Program.ConvertToDatetime(lblSystemCurrentDate.Text.Trim(), lblSystemCurrentTime.Text.Trim()).AddSeconds(1));
        }        
                              
    }
}
