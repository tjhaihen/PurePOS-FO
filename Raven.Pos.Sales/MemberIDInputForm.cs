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
    public partial class MemberIDInputForm : Form
    {
        private bool _IsValid = false;
        private string _STxnNo = "";
        private string _EntitiesSeqNo = "";
        private string _MemberID = "";
        private string _MemberName = "";
        private string _MemberSince = "";
        private string _MemberValidThru = "";
        public MemberIDInputForm()
        {
            InitializeComponent();
        }

        public string[] MemberIDInput(string memberID, string STxnNo)
        {
            txtMemberID.Text = memberID.Trim();
            _STxnNo = STxnNo.Trim();
            ShowDialog();
            if (_IsValid)
            {
                //var _member = new DataTable();
                //_member.Columns.Add("MemberID", typeof(string));
                //_member.Columns.Add("MemberName", typeof(string));
                //_member.Columns.Add("MemberSince", typeof(string));
                //_member.Columns.Add("MemberValidThru", typeof(string));
                //_MemberSince = (_MemberSince == "01-01-1900" ? "-" : _MemberSince);
                //_MemberValidThru = (_MemberValidThru == "01-01-1900" ? "-" : _MemberValidThru);
                //_member.Rows.Add(_MemberID.Trim(), _MemberName.Trim(), _MemberSince.Trim(), _MemberValidThru.Trim());
                //return _member;

                string[] _Arraymember = new string[5];
                _Arraymember[0] = _EntitiesSeqNo.Trim();
                _Arraymember[1] = _MemberID.Trim();
                _Arraymember[2] = _MemberName.Trim();
                _Arraymember[3] = (_MemberSince == "01-01-1900" ? "-" : _MemberSince);
                _Arraymember[4] = (_MemberValidThru == "01-01-1900" ? "-" : _MemberValidThru);
                return _Arraymember;
            }
            else
                return null;
        }


        private bool InputMemberID()
        {
            bool _retval = false;
            _MemberID = txtMemberID.Text.Trim();

            var oEntities = new Entities();
            oEntities.MemberNo = _MemberID;
            if (_MemberID.Trim() == "")
            {
                if (ProsesNonMemberOrMember())
                    _retval = true;
            }
            else if (oEntities.SelectOneByMemberNo().Rows.Count > 0)
            {
                _EntitiesSeqNo = oEntities.EntitiesSeqNo.Trim();
                var oMemberBenefit = new MemberBenefit();
                oMemberBenefit.MBTypeID = oEntities.MemberTypeID.Trim();
                if (oMemberBenefit.SelectOne().Rows.Count > 0)
                {
                    _MemberName = oMemberBenefit.MBTypeName;
                    _MemberSince = string.Format(Program.FormatDate, oEntities.MemberSinceDate);
                    _MemberValidThru = string.Format(Program.FormatDate, oEntities.MemberValidThruDate);
                    if (ProsesNonMemberOrMember())
                        _retval = true;
                }
                else
                {
                    _MemberName = string.Empty;
                    Program.MsgBox_Show("Member ID is not found");
                }
                oMemberBenefit.Dispose();
                oMemberBenefit = null;
            }
            else
            {
                _EntitiesSeqNo = "";
                _MemberName = "-";
                _MemberSince = "-";
                _MemberValidThru = "-";
                Program.MsgBox_Show("Entities is not found");
            }
            oEntities.Dispose();
            oEntities = null;
            if (_retval)
                _IsValid = true;
            
            return _retval;
        }

        private bool ProsesNonMemberOrMember()
        {
            var conn = new SqlConnection(HisConfiguration.ConnectionString);
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                using (var oMemberBenefit = new MemberBenefit())
                {
                    oMemberBenefit.ProsesNonMemberOrMemberPromotionByMemberNo(_MemberID, _STxnNo, conn, trans);
                }
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
                return false;
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
            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(InputMemberID())
                Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtMemberID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (InputMemberID())
                {
                    Close();
                }
            }
        }

        private void MemberIDInputForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
