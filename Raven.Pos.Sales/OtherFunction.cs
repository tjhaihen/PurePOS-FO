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

namespace Raven.Pos.Sales
{
    public partial class OtherFunction : Form
    {
        private LoginInfo _loginInfo;

        public OtherFunction(LoginInfo loginInfo)
        {
            _loginInfo = loginInfo;
            InitializeComponent();
        }

        public void ShowOtherFunction()
        {
            ShowDialog();
        }

        private void OtherFunction_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                    SettlementInput();                    
                    break;
                case Keys.D2:
                    Adjustment();                    
                    break;
                case Keys.D3:
                    DataCustomer();
                    break;
                case Keys.D4:
                    InfoPromotion();
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private void btnSettelment_Click(object sender, EventArgs e)
        {
            SettlementInput();
        }

        private void btnDataCustomer_Click(object sender, EventArgs e)
        {
            DataCustomer();
        }

        private void btnInfoPromotion_Click(object sender, EventArgs e)
        {
            InfoPromotion();
        }

        private void btnPrintPOP_Click(object sender, EventArgs e)
        {
            PrintPOP();
        }

        private void btnInputBS_Click(object sender, EventArgs e)
        {
            Adjustment();
        }
        
        private void SettlementInput()
        {
            var salesHd = new SalesUnitHd();
            var dv = new DataView(salesHd.SelectSTXnNoByUserID(_loginInfo.UserID.Trim()));
            dv.RowFilter = "STxnStatusID in ('O','S')";
            if (dv.Count > 0)
            {
                Program.MsgBox_Show("You still have open/suspended transaction(s). Please complete all your open/suspended transaction(s) first.");
            }
            else
            {
                using (var frm = new SettlementInputForm(_loginInfo))
                {
                    frm.SettlementInput();
                }
            }
            dv.Dispose();
            dv = null;
            salesHd.Dispose();
            salesHd = null;
        }

        private void DataCustomer()
        {
            var oDataCustomer = new DataCustomerForm();
            oDataCustomer.Search();
            oDataCustomer.Dispose();
            oDataCustomer = null;
        }

        private void InfoPromotion()
        {
            var oInformationPromotion = new InformationPromotionForm();
            oInformationPromotion.Search();
            oInformationPromotion.Dispose();
            oInformationPromotion = null;
        }

        private void Adjustment()
        {
            var oAdjustmentForm = new AdjustmentForm();
            oAdjustmentForm.ShowDialogAdjustment(_loginInfo);
            oAdjustmentForm.Dispose();
            oAdjustmentForm = null;
        }

        private void PrintPOP()
        {
            var oPrintPOPForm = new PrintPOPForm();
            oPrintPOPForm.Search();
            oPrintPOPForm.Dispose();
            oPrintPOPForm = null;
        }        
        
    }
}
