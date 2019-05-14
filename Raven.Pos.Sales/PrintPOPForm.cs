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
    public partial class PrintPOPForm : Form
    {
        public PrintPOPForm()
        {
            InitializeComponent();
        }

        public void Search()
        {
            ShowDialog();
        }

        private void PrintPOPForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnPreview_Click(null , null);
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private string SearchItem()
        {
            string _itemid = string.Empty;
            Item item;
            using (var frm = new SearchItemForm())
            {
                item = frm.Search();
            }
            if (item != null)
            {
                _itemid = item.ItemID;
            }
            else
            {
                _itemid = string.Empty;
            }
            return _itemid;
        }

        private void txtFromItem_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2 :
                    txtFromItemID.Text = SearchItem().Trim();
                    break;
            }
        }

        private void txtThruItem_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    txtThruItemID.Text = SearchItem().Trim();
                    break;
            }
        }

        private string OpenItem(string ItemID)
        {
            string _itemName = string.Empty;
            var oitem = new Item();
            if (oitem.LoadByItemID(ItemID))
                _itemName = oitem.ItemName.Trim();
            oitem.Dispose();
            oitem = null;
            return _itemName;
        }

        private void txtFromItemID_Leave(object sender, EventArgs e)
        {
            txtFromItemName.Text = OpenItem(txtFromItemID.Text);
        }

        private void txtThruItemID_Leave(object sender, EventArgs e)
        {
            txtThruItemName.Text = OpenItem(txtThruItemID.Text);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Program.PrintReport("@FromItemID=" + txtFromItemID.Text.Trim() + Program.SeparatorPReport +
                                    "@ThruItemID=" + txtThruItemID.Text.Trim()
                                    , "LabelBarcode", false);
        }

    }
}
