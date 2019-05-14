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
    public partial class InformationPromotionForm : Form
    {
        public InformationPromotionForm()
        {
            InitializeComponent();
        }

        public void Search()
        {
            dtpPromotionDateFrom.Focus();
            ShowDialog();
        }

        private void PopulateGridInfoPromotion()
        {
            grdInfoPromotion.SuspendLayout();
            grdInfoPromotion.AutoGenerateColumns = false;

            var oPromotionHd = new PromotionHd();
            var tmpDVEntities = new DataView(oPromotionHd.SelectInformationPromotion(dtpPromotionDateFrom.Value.Date, dtpPromotionDateTo.Value.Date));
            grdInfoPromotion.DataSource = tmpDVEntities;
            grdInfoPromotion.ResumeLayout();
            oPromotionHd.Dispose();
            oPromotionHd = null;   
        }

        private void InformationPromotionForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private void dtpPromotionDateFrom_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    dtpPromotionDateTo.Focus();
                    break;
            }
        }

        private void dtpPromotionDateTo_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnView.Focus(); 
                    break;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            PopulateGridInfoPromotion();
            if (grdInfoPromotion.RowCount > 0)  
                grdInfoPromotion.Focus();
        }
       
    }
}
