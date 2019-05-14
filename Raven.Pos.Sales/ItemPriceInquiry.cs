using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Raven.BussinessRules;
using Raven.Common;
using System.IO;

namespace Raven.Pos.Sales
{
    public partial class ItemPriceInquiry : Form
    {        
        public ItemPriceInquiry()
        {
            InitializeComponent();
            
            lblSystemInfo.Text = ProductName + " v." + ProductVersion;

            this.WindowState = FormWindowState.Maximized;
        }

        public void ShowItemPriceInquiry()
        {
            ShowDialog();
        }        

        private void ItemPriceInquiryForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    PopulateItemEntry();
                    break;
                case Keys.Escape: //Close
                    Close();
                    break;
            }            
        }

        private void ClearItemEntry()
        {
            txtItemID.Focus();
            txtItemID.Text = string.Empty;
            lblItemName.Text = string.Empty;                 
        }

        private bool PopulateItemEntry()
        {
            bool retval = false;
            string strItemSeqNo = string.Empty;
            string strItemID = string.Empty;
            lblItemName.Text = string.Empty;
            using (var item = new Item())
            {
                string strBarcodeBuah = txtItemID.Text.Trim();
                if (strBarcodeBuah.Length > 1)
                {
                    if (Program.Left(strBarcodeBuah, 2) == "22" && strBarcodeBuah.Trim().Length == 13)
                        txtItemID.Text = Program.Left(strBarcodeBuah, 6);
                    else
                        strBarcodeBuah = string.Empty;
                }                

                if (item.LoadByItemID(txtItemID.Text))
                {
                    strItemSeqNo = item.ItemSeqNo.Trim();
                    lblItemName.Text = item.ItemName;
                    strItemID = item.ItemID.Trim();
                    retval = true;
                }
                else
                {
                    ClearItemEntry();
                    strItemSeqNo = string.Empty;
                    strItemID = string.Empty;
                    lblItemName.Text = "Item not found. Please try again.";
                    retval = false;
                }
            }

            using (var salesDt = new SalesUnitDt())
            {
                DataTable dtbPriceSalesItem = salesDt.SelectGetPriceItemSalesFOAllByItemSeqNo(strItemSeqNo);

                dtbPriceSalesItem.PrimaryKey = new[] { dtbPriceSalesItem.Columns["ItemUnitID"] };

                grdItemPrice.AutoGenerateColumns = false;
                grdItemPrice.DataSource = dtbPriceSalesItem;
                grdItemPrice.ResumeLayout();

                dtbPriceSalesItem.Dispose();
                dtbPriceSalesItem = null;
            }

            var oPromotion = new PromotionHd();
            var dv = new DataView(oPromotion.SelectInformationPromotion(Convert.ToDateTime("2011-01-01"), DateTime.Today.Date));
            dv.RowFilter = "ItemID = '" + strItemID.Trim() + "'";
            dtgPromotion.AutoGenerateColumns = false;
            dtgPromotion.DataSource = dv;
            dtgPromotion.ResumeLayout();
            dv = null;
            oPromotion.Dispose();
            oPromotion = null;

            var oitemphoto = new ItemPhoto();
            oitemphoto.ItemSeqNo = strItemSeqNo.Trim();
            if (oitemphoto.SelectByItemSeqNo().Rows.Count > 0)
            {
                Byte[] byteBLOBData = new Byte[0];
                byteBLOBData = (Byte[])(oitemphoto.ItemPhoto);
                MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                picBoxItem.Image = Image.FromStream(stmBLOBData);

                //Byte[] msdt = (Byte[])(oitemphoto.ItemPhoto);
                //MemoryStream ms = new MemoryStream(msdt);
                //ms.Write(msdt, 0, msdt.Length);
                //ms.Position = 0;
                //ms.Seek(0, SeekOrigin.Begin);
                //picBoxItem.Image = Image.FromStream(ms);

                //Byte[] msdt = (Byte[])(oitemphoto.ItemPhoto);
                //MemoryStream ms = new MemoryStream(msdt);
                //Image img = new System.Drawing.Bitmap(ms);
                //picBoxItem.Image = img;
            }
            else
            {
                picBoxItem.Image = null;
            }
            oitemphoto.Dispose();
            oitemphoto = null;


            txtItemID.Text = string.Empty;
            txtItemID.Focus();
            return retval;
        }
    }
}
