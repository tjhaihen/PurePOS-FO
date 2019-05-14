using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Raven.BussinessRules;
using Raven.Common;


namespace Raven.Pos.Sales
{
    public partial class SettlementInputForm : Form
    {
        private LoginInfo _loginInfo;
        
        public SettlementInputForm()
        {
            InitializeComponent();
        }

        public SettlementInputForm(LoginInfo loginInfo)
        {
            _loginInfo = loginInfo;
            InitializeComponent();
        }

        public void SettlementInput()
        {
            ShowDialog();
        }

        private void PopulateGrid()
        {
            gridSettlement.SuspendLayout();
            gridSettlement.AutoGenerateColumns = false;

            var PaymentDt = new PaymentDt();
            var dtb = PaymentDt.SelectAllPaymentMethod(dtpSettlementDate.Value.Date, txtCashierID.Text.Trim());
            gridSettlement.DataSource = dtb;
            gridSettlement.ResumeLayout();

            txtGrandTotal.Text = string.Format( Program.FormatCurrency,
                                                (from DataRow row in dtb.Rows
                                                //where row["IsDeleted"].Equals(false)
                                                select Convert.ToDecimal(row["Amount"])).Sum()
                                              );

            PaymentDt.Dispose();
            PaymentDt = null;

            dtb.Dispose();
            dtb = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveToDatabase())
            {
                PopulateGrid();
            }
        }

        private bool SaveToDatabase()
        {
            bool retval = false;
            var conn = new SqlConnection(HisConfiguration.ConnectionString);
            SqlTransaction trans = null;

            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SaveSettlement(conn, trans);
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

        private void SaveSettlement(SqlConnection conn, SqlTransaction trans)
        {
            var oSettlement = new Settlement();
            oSettlement.UserID = txtCashierID.Text.Trim();
            oSettlement.Date = dtpSettlementDate.Value.Date;
            oSettlement.IsDeleted = false;
            for (int i = 0; i < gridSettlement.Rows.Count; ++i)
            {
                oSettlement.PaymentMethodID = Convert.ToString(gridSettlement.Rows[i].Cells[gridSettlement.Columns["PaymentMethodID"].Index].Value);
                oSettlement.Amount = Convert.ToDecimal(gridSettlement.Rows[i].Cells[gridSettlement.Columns["Amount"].Index].Value);

                var dv = new DataView(oSettlement.SelectOneByUserIDDatePaymentmethodAmount(conn, trans));
                if (dv.Count > 0)
                {
                    dv.RowFilter = "Amount = '" + Convert.ToString(Convert.ToDecimal(gridSettlement.Rows[i].Cells[gridSettlement.Columns["Amount"].Index].Value)) + "' ";
                    if (!(dv.Count > 0))
                    {
                        oSettlement.Delete(conn, trans);
                        oSettlement.ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("Settlement", "ID", conn, trans, "S");
                        oSettlement.Insert(conn, trans);
                    }
                }
                else
                {
                    oSettlement.ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("Settlement", "ID", conn, trans, "S");
                    oSettlement.Insert(conn, trans);
                }
                dv.Dispose();
                dv = null;
            }
            oSettlement.Dispose();
            oSettlement = null;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            //Program.PrintReport("@UserID=" + txtCashierID.Text.Trim() + Program.SeparatorPReport +
            //              "@Date=" + Convert.ToString(dtpSettlementDate.Value.Date)
            //              , "Settlement");

            printSettlement.Print();
        }

        private void SettlementInputForm_Load(object sender, EventArgs e)
        {
            dtpSettlementDate.Value = BussinessRules.ID.GetDateDBServer();
            txtCashierID.Text = _loginInfo.UserID.Trim();
            txtCashierName.Text = _loginInfo.UserName.Trim();

            PopulateGrid();
        }

        private void gridSettlement_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                decimal sum = 0;
                for (int i = 0; i < gridSettlement.Rows.Count; ++i)
                {
                    sum += Convert.ToDecimal(gridSettlement.Rows[i].Cells[e.ColumnIndex].Value);
                }
                txtGrandTotal.Text = string.Format(Program.FormatCurrency, sum);
            }
        }

        private void SettlementInputForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void gridSettlement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                e.Handled = true;
        }

        private void gridSettlement_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gridSettlement.CurrentCell.ColumnIndex == gridSettlement.Columns["Amount"].Index)
                {
                    gridSettlement.BeginEdit(true);
                }
            }
        }

        private void gridSettlement_EdittingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {  
            if (gridSettlement.CurrentCell.ColumnIndex == gridSettlement.Columns["Amount"].Index && !(e.Control == null))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(tb_KeyPress);
                    tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(tb_KeyPress);
                }
            }
        }
        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gridSettlement.CurrentCell.ColumnIndex == gridSettlement.Columns["Amount"].Index)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    e.Handled = true;
                
                if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    e.Handled = true;
            }
        }

        private void gridSettlement_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)         
        {            
            e.Cancel = false;
            if (e.ColumnIndex == gridSettlement.Columns["Amount"].Index)             
            {
                if (e.FormattedValue.ToString() == string.Empty || e.FormattedValue.ToString() == null)
                    e.Cancel = true;
            }         
        }

        private void printSettlement_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font printFont;
            printFont = new Font("Courier New", 10);

            e.Graphics.DrawString(DirectPrintSettlement(), printFont, Brushes.Black, 10, 10);
        }

        private string DirectPrintSettlement()
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
            string _UserID;
            string _SettlementDate;
            string _PaymentTypeName, _Amount;
            decimal _SumOfAmount = 0;

            //_lineBreak
            for (int lb = 0; lb < MaxStringPerLine; lb++)
            {
                _lineBreak += "-";
            }
            _lineBreak += "\n";

            _UserID = _loginInfo.UserID.Trim();

            var settlementFO = new Settlement();
            settlementFO.UserID  = _UserID.Trim();
            settlementFO.Date = dtpSettlementDate.Value.Date;
            DataTable dtbSettlementFO = settlementFO.GetSettlementData();
            _SettlementDate = string.Format(Program.FormatDate, Convert.ToDateTime(dtbSettlementFO.Rows[0]["Date"]));

            // Set printer name
            // Just use Default Printer on client;
            //String strPrinterName = Program.SelectOneByCommonSettingByDetailID("PrinterName", "Cashier");

            // Set text to be printed out
            // Header
            string txtprn;
            txtprn = Program.TextToCenter("", _CompanyName.Trim(), MaxStringPerLine) + "\n";
            txtprn += Program.TextToCenter("", "Settlement", MaxStringPerLine) + "\n";
            txtprn += Program.TextToCenter("", "Date: " + _SettlementDate, MaxStringPerLine) + "\n";
            txtprn += "\n";
            txtprn += _lineBreak;
            txtprn += Program.TextToCenter("", _UserID.Trim() + " " + string.Format(Program.FormatDate, DateTime.Now) + " " + string.Format(Program.FormatTime, DateTime.Now), MaxStringPerLine) + "\n";
            txtprn += _lineBreak;            

            // Start Detail Item Transactions
            foreach (DataRow row in dtbSettlementFO.Rows)
            {
                _SumOfAmount += Convert.ToDecimal(row["Amount"]);
                
                _PaymentTypeName = Convert.ToString(row["PaymentTypeName"]);
                _Amount = string.Format(Program.FormatCurrencyForBillReceipt, Convert.ToDecimal(row["Amount"]));
                
                txtprn += _PaymentTypeName.Trim() + Program.TextToRight(_PaymentTypeName.Trim(), _Amount.Trim(), MaxStringPerLine) + "\n";
            }

            txtprn += _lineBreak;
            // Start Sub Total Section
            txtprn += "GRAND TOTAL " + Program.TextToRight("GRAND TOTAL ", string.Format(Program.FormatCurrencyForBillReceipt, _SumOfAmount), MaxStringPerLine) + "\n";
            txtprn += _lineBreak;
            txtprn += "Please sign here:" + "\n" + "\n" + "\n";
            txtprn += _UserID + "\n";
            txtprn += _lineBreak;

            // Send string to printer
            //RawPrinterHelper.SendStringToPrinter(strPrinterName, txtprn);

            return txtprn;
        }
    }
}
