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
    public partial class SearchItemFactorForm : Form
    {
        private ItemFactorTemplate _ItemFactorTemplated;
        public SearchItemFactorForm()
        {
            InitializeComponent();
        }
        public ItemFactorTemplate Search(string ItemSeqNo, string ItemUnitID)
        {
            PopulateGrid(ItemSeqNo, ItemUnitID);
            ShowDialog();
            return _ItemFactorTemplated;
        }

        private void SelectItemFactor()
        {
            if (grdItemFactor.RowCount > 0)
            {
                _ItemFactorTemplated = new ItemFactorTemplate { ItemFactor = Convert.ToDecimal(grdItemFactor.SelectedRows[0].Cells["ItemFactor"].Value) };
                Close();
            }
        }

        private void PopulateGrid(string ItemSeqNo, string ItemUnitID)
        {
            grdItemFactor.SuspendLayout();
            grdItemFactor.AutoGenerateColumns = false;

            var ItemFactor = new ItemFactorTemplate();
            ItemFactor.ItemSeqNo = ItemSeqNo;
            ItemFactor.ItemUnitID = ItemUnitID;
            var dtb = ItemFactor.SelectAllByItemSeqNoItemUnitID();
            grdItemFactor.DataSource = dtb;
            grdItemFactor.ResumeLayout();
        }
        
        private void grdItemFactor_DoubleClick(object sender, EventArgs e)
        {
            SelectItemFactor();
        }

        private void grdItemFactor_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SelectItemFactor();
                    break;
            }
        }

        private void grdItemFactor_KeyDown(object sender, KeyEventArgs e)
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
