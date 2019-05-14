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
    public partial class SearchItemForm : Form
    {
        private Item _item;
        public SearchItemForm()
        {
            InitializeComponent();            
        }
        public Item Search()
        {
            //if (strItemName.Length > 0)
            //{
            //    txtSearch.Text = strItemName;
            //    PopulateGrid();
            //}
            ShowDialog();
            return _item;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectItem();
        }
        
        private void SelectItem()
        {
            if (grdItem.RowCount > 0)
            {
                _item = new Item();
                _item.LoadByItemID(grdItem.SelectedRows[0].Cells["colItemID"].Value.ToString());
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
                default :
                    PopulateGrid();
                    break;
            }
        }

        private void PopulateGrid()
        {
            grdItem.SuspendLayout();
            grdItem.AutoGenerateColumns = false;
            if (txtSearch.Text.Length>2)
            {
                var item = new Item();
                var dtb = item.SelectByIdOrName(txtSearch.Text,Program.SelectOneByCommonSetting("MaxRecord"));
                grdItem.DataSource = dtb;
            }
            else
            {
                grdItem.DataSource = null;
            }

            grdItem.ResumeLayout();
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

        private void SearchItemForm_Load(object sender, EventArgs e)
        {
        }

        private void SearchItemForm_KeyUp(object sender, KeyEventArgs e)
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
