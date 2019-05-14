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
    public partial class ChooseTransactionStatusForm : Form
    {
        private string _StatusID;
        private string _StxnNo;
        
        public ChooseTransactionStatusForm()
        {
            InitializeComponent();
        }
        public string Search(string StxnNo)
        {
            _StxnNo = StxnNo;
            PopulateGrid();
            ShowDialog();
            return _StatusID;
        }

        private void SelectTransactionStatus()
        {
            _StatusID = Convert.ToString(grdChooseTransactionStatus.SelectedRows[0].Cells["StatusID"].Value);
            Close();
        }

        private void PopulateGrid()
        {
            grdChooseTransactionStatus.SuspendLayout();
            grdChooseTransactionStatus.AutoGenerateColumns = false;

            var cs = new CommonSetting();
            var dv = new DataView(cs.SelectAllByGroupID("STxnStatus"));
            dv.RowFilter = "DetailID in ('S','V')";
            grdChooseTransactionStatus.DataSource = dv;
            grdChooseTransactionStatus.ResumeLayout();
        }
        
        private void grdChooseTransactionStatus_DoubleClick(object sender, EventArgs e)
        {
            SelectTransactionStatus();
        }

        private void grdChooseTransactionStatus_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SelectTransactionStatus();
                    break;
            }
        }

        private void grdChooseTransactionStatus_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    e.Handled = true;
                    break;
            }
        }
    }
}
