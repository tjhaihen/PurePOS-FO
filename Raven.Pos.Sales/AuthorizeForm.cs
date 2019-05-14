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
    public partial class AuthorizeForm : Form
    {
        private bool _retval;
        public bool GetAuthorize()
        {
            ShowDialog();
            return _retval;
        }

        public AuthorizeForm()
        {
            InitializeComponent();
        }

        private void GetAuthorized()
        {
            //lblMessage.Visible = true;
            var user = new User();
            //if (!user.LoadByPrimaryKey("sa"))
            //{
            //    Program.MsgBox_Show("User Authorize is not found");
            //    //lblMessage.Text = "User Authorize is not found";
            //    _retval = false;
            //    return;
            //}

            //if (!user.isActive)
            //{
            //    Program.MsgBox_Show("User Authorize is not active");
            //    //lblMessage.Text = "User Authorize is not active";
            //    return;
            //}

            //if (BussinessRules.ID.GetHashStringSQL(txtPassword.Text.Trim()) != user.Password.Trim())
            //{
            //    Program.MsgBox_Show("Password is not valid");
            //    //lblMessage.Text = "Password is not valid";
            //    _retval = false;
            //    return;
            //}
            user.AuthorizePassword = BussinessRules.ID.GetHashStringSQL(txtPassword.Text.Trim());

            if (user.CheckAuthorizePassword().Rows.Count <= 0)
            {
                Program.MsgBox_Show("Password is not valid");
                //lblMessage.Text = "Password is not valid";
                _retval = false;
                return;
            }

            _retval = true;

            //lblMessage.Visible = false;

            user.Dispose();
            user = null;
            Close();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                GetAuthorized();
        }

        private void AuthorizeForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _retval = false;
                Close();
            }
        }
    }
}
