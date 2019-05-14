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
    public partial class DataCustomerForm : Form
    {
        public DataCustomerForm()
        {
            InitializeComponent();
        }

        public void Search()
        {
            preparescreen();
            ShowDialog();
        }

        private void PopulateGridEntities()
        {
            grdEntities.SuspendLayout();
            grdEntities.AutoGenerateColumns = false;

            var oEntities = new Entities();
            var tmpDVEntities = new DataView(oEntities.SelectByFilterEntitiesIDNameMemberNo(txtSearch.Text.Trim()));
            grdEntities.DataSource = tmpDVEntities;
            grdEntities.ResumeLayout();
            oEntities.Dispose();
            oEntities = null;   
        }

        private void PopulateGridLastTransaction(string EntitiesSeqNo)
        {
            grdLastTransaction.SuspendLayout();
            grdLastTransaction.AutoGenerateColumns = false;

            var oSalesUnitHd = new SalesUnitHd();
            var tmpDVSalesUnitHd = new DataView(oSalesUnitHd.SelectByEntitiesSeqNoLastSTXnNo(EntitiesSeqNo));
            grdLastTransaction.DataSource = tmpDVSalesUnitHd;
            grdLastTransaction.ResumeLayout();
            oSalesUnitHd.Dispose();
            oSalesUnitHd = null;
        }

        private void grdEntities_DoubleClick(object sender, EventArgs e)
        {
            SelectEntities();
        }

        private void grdEntities_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SelectEntities();
                    break;
            }
        }

        private void grdEntities_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    e.Handled = true;
                    break;
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (grdEntities.RowCount > 0)
                    {
                        grdEntities.Focus();
                    }
                    break;
                case Keys.Enter:
                    preparescreen();
                    PopulateGridEntities();
                    break;
                //default:
                    
                //    break;
            }
        }

        private void DataCustomerForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private void SelectEntities()
        {
            if (grdEntities.RowCount > 0)
            {
                txtEntitiesName.Text = grdEntities.SelectedRows[0].Cells["EntitiesName"].Value.ToString();
                txtAddress.Text = grdEntities.SelectedRows[0].Cells["PrimaryAddress"].Value.ToString();
                txtPhoneNo.Text = grdEntities.SelectedRows[0].Cells["PrimaryPhoneNo"].Value.ToString();
                PopulateGridLastTransaction(grdEntities.SelectedRows[0].Cells["EntitiesSeqNo"].Value.ToString());
            }
            else
                preparescreen();
        }


        private void preparescreen()
        {
            txtEntitiesName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            grdLastTransaction.DataSource = null;
            grdEntities.DataSource = null;
        }
       
    }
}
