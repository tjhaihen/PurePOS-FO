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
    public partial class CancelPaymentForm : Form
    {
        private bool _retval = false;
        private string _ReceiptNo;
        private string _UserID;
        public CancelPaymentForm()
        {
            InitializeComponent();
        }

        public bool Search(string ReceiptNo, string UserID)
        {
            _ReceiptNo = ReceiptNo.Trim();
            _UserID = UserID.Trim();
            PopulateGrid();
            ShowDialog();
            return _retval;
        }

        private void PopulateGrid()
        {
            grdPayment.SuspendLayout();
            grdPayment.AutoGenerateColumns = false;

            var oPaymentDt = new PaymentDt();
            var tmpDVPaymentDt = new DataView(oPaymentDt.SelectByReceiptNoForCancelPayment(_ReceiptNo.Trim()));
            grdPayment.DataSource = tmpDVPaymentDt;
            grdPayment.ResumeLayout();

            oPaymentDt.Dispose();
            oPaymentDt = null;
        }

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectPayment();
        }


        private void SelectPayment()
        {
            if (grdPayment.RowCount > 0)
            {
                if (Program.MsgBox_Show("Are you sure want to cancel this payment ? ", "Confirmation", "YesNo"))
                {
                    var oPaymentDt = new PaymentDt();
                    oPaymentDt.ID = grdPayment.SelectedRows[0].Cells["ID"].Value.ToString();
                    if (oPaymentDt.SelectOne().Rows.Count > 0)
                    {
                        var conn = new SqlConnection(HisConfiguration.ConnectionString);
                        SqlTransaction trans = null;
                        try
                        {
                            conn.Open();
                            trans = conn.BeginTransaction();
                            oPaymentDt.ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("PaymentDt", "ID", conn, trans, "FP");
                            oPaymentDt.Amount = -(oPaymentDt.Amount);
                            oPaymentDt.UserInsert = _UserID;
                            oPaymentDt.UserUpdate = _UserID;
                            oPaymentDt.Insert(conn, trans);
                            trans.Commit();
                            _retval = true;
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

                        Close();
                    }
                    else
                    {
                        Program.MsgBox_Show("Payment is not found, please select another payment");
                        PopulateGrid();
                    }
                    oPaymentDt.Dispose();
                    oPaymentDt = null;
                }
            }
        }

        private void grdPayment_DoubleClick(object sender, EventArgs e)
        {
            SelectPayment();
        }

        private void grdPayment_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    e.Handled = true;
                    break;
            }
        }

        private void grdPayment_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SelectPayment();
                    break;
            }
        }

        private void CancelPaymentForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
        }
    }
}
