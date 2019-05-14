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
    public partial class ChangePasswordForm : Form
    {
        private LoginInfo _loginInfo;

        public ChangePasswordForm(LoginInfo loginInfo)
        {
            _loginInfo = loginInfo;
            InitializeComponent();
        }

        public void ChangePassword()
        {
            ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            var user = new User();
            if (!user.LoadByPrimaryKey(_loginInfo.UserID.Trim()))
            {
                Program.MsgBox_Show("User Name is not found", "User Name");
                //MessageBox.Show("User Name is not found", "User Name");
                return;
            }

            if (BussinessRules.ID.GetHashStringSQL(txtCurrentPassword.Text.Trim()) != user.Password.Trim())
            {
                Program.MsgBox_Show("Current Password is not valid", "Password");
                //MessageBox.Show("Current Password is not valid", "Password");
                txtCurrentPassword.Focus();
                return;
            }

            if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                Program.MsgBox_Show("New Password must be the same with Confirm Password", "Password");
                //MessageBox.Show("New Password must be the same with Confirm Password", "Password");
                txtNewPassword.Focus();
                return;
            }

            user.NewPassword = BussinessRules.ID.GetHashStringSQL(txtNewPassword.Text.Trim());
            if (user.UpdatePassword())
            {
                Program.MsgBox_Show("Password changed successfully", "Password");
                //MessageBox.Show("Password changed successfully", "Password");
                txtNewPassword.Focus();
            }

            user.Dispose();
            user = null;

            Close();
        }

        private void ChangePasswordForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void txtConfirmPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                save();
        }
    }
}
