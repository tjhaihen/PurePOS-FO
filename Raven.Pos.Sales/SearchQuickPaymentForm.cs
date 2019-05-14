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
    public partial class SearchQuickPaymentForm : Form
    {
        private PaymentDt _QuickPayment;
        public SearchQuickPaymentForm()
        {
            InitializeComponent();
        }
        public PaymentDt Search()
        {
            PopulateGrid();
            ShowDialog();
            return _QuickPayment;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectQuickPayment();
        }
     
        private void SelectQuickPayment()
        {
            if (grdQuickPayment.RowCount > 0)
            {
                _QuickPayment = new PaymentDt 
                {
                    ID = Convert.ToString(grdQuickPayment.SelectedRows[0].Cells["ID"].Value)
                };
                Close();
            }
        }

        private void PopulateGrid()
        {
            grdQuickPayment.SuspendLayout();
            grdQuickPayment.AutoGenerateColumns = false;

            var PaymentDt = new PaymentDt();
            PaymentDt.ID = null;
            var dtb = PaymentDt.SelectAllSearchQuickPayment();
            grdQuickPayment.DataSource = dtb;
            grdQuickPayment.ResumeLayout();
        }
        
        private void grdQuickPayment_DoubleClick(object sender, EventArgs e)
        {
            SelectQuickPayment();
        }

        private void grdQuickPayment_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SelectQuickPayment();
                    break;
                //default:
                //    grdQuickPayment.SelectedRows[5].Cells["ID"].Selected = true;
                //    break;
            }
        }

        private void grdQuickPayment_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    e.Handled = true;
                    break;
            }
        }

        private void SearchQuickPaymentForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
