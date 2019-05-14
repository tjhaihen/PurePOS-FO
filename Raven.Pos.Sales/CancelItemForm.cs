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
    public partial class CancelItemForm : Form
    {
        private bool _retval = false;
        private string _STxnNo;
        private string _UserID;
        public CancelItemForm()
        {
            InitializeComponent();
        }

        public bool Search(string STxnNo, string ItemIDOrItemName, string UserID)
        {
            _STxnNo = STxnNo.Trim();
            _UserID = UserID.Trim();
            PopulateGrid(ItemIDOrItemName.Trim());
            ShowDialog();
            return _retval;
        }

        private void PopulateGrid(string FilterValue)
        {
            grdItem.SuspendLayout();
            grdItem.AutoGenerateColumns = false;

            var oSalesUnitDt = new SalesUnitDt();
            var tmpDVSalesdt = new DataView(oSalesUnitDt.SelectByNoForCancelItem(_STxnNo.Trim()));
            tmpDVSalesdt.Sort = "ItemID, ItemFactor, Qty";
            tmpDVSalesdt.RowFilter = "ItemID Like '%" + FilterValue.Trim() + "%' Or ItemName Like '%" + FilterValue.Trim() + "%' ";
            grdItem.DataSource = tmpDVSalesdt;
            grdItem.ResumeLayout();

            oSalesUnitDt.Dispose();
            oSalesUnitDt = null;

            
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (grdItem.RowCount > 0)
                    {
                        grdItem.Focus();
                    }
                    break;
                case Keys.Enter:
                    SelectItem();
                    break;
                default:
                    PopulateGrid(txtSearch.Text.Trim());
                    break;
            }
        }

        private void CancelItemForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private void SelectItem()
        {
            if (grdItem.RowCount > 0)
            {
                if (Program.MsgBox_Show("Are you sure want to cancel this Item ? ", "Confirmation", "YesNo"))
                {
                    var oSalesUnitDt = new SalesUnitDt();
                    oSalesUnitDt.ID = grdItem.SelectedRows[0].Cells["SalesDtID"].Value.ToString();
                    if (oSalesUnitDt.SelectOne().Rows.Count > 0)
                    {
                        var conn = new SqlConnection(HisConfiguration.ConnectionString);
                        SqlTransaction trans = null;
                        try
                        {
                            conn.Open();
                            trans = conn.BeginTransaction();
                            oSalesUnitDt.ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("SalesUnitDt", "ID", conn, trans, "SU");
                            oSalesUnitDt.ItemSeqNo = grdItem.SelectedRows[0].Cells["ItemID"].Value.ToString();
                            oSalesUnitDt.Qty = -(oSalesUnitDt.Qty);
                            oSalesUnitDt.UserInsert = _UserID;
                            oSalesUnitDt.UserUpdate = _UserID;
                            oSalesUnitDt.Insert(conn, trans);
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

                        _retval = true;
                        Close();

                        //oSalesUnitDt.ID = BussinessRules.ID.GenerateIDNumber("SalesUnitDt", "ID", "SU");
                        //oSalesUnitDt.ItemSeqNo = grdItem.SelectedRows[0].Cells["ItemID"].Value.ToString();
                        //oSalesUnitDt.Qty = -(oSalesUnitDt.Qty);
                        //oSalesUnitDt.UserInsert = _UserID;
                        //oSalesUnitDt.UserUpdate = _UserID;
                        //oSalesUnitDt.Insert();
                        //_retval = true;
                        //Close();
                    }
                    else
                    {
                        Program.MsgBox_Show("Item is not found, please select another item");
                        PopulateGrid(txtSearch.Text.Trim());
                    }
                    oSalesUnitDt.Dispose();
                    oSalesUnitDt = null;
                }
            }
        }
    }
}
