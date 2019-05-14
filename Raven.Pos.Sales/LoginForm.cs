using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Contexts;
using Raven.BussinessRules;
using Raven.Common;

// untuk textpad
//using System.IO;
//using System.Diagnostics;


namespace Raven.Pos.Sales
{
    public partial class LoginForm : Form
    {
        #region "Private Variables"
            private LoginInfo _loginInfo;       
        #endregion

        public LoginForm()
        {
            InitializeComponent();
            PopulateBranch();
            PopulateCompany();

            lblSystemInfo.Text = ProductName + " v." + ProductVersion;
        }

        public LoginInfo GetLoginInfo()
        {
            this.WindowState = FormWindowState.Maximized;
            Program.PoleDisplay_Show(("Welcome to " + Program.POSIFLEX_SpaceCharPerLine).Substring(0, 20) + cboCompany.Text.Trim());
            ShowDialog();
            return _loginInfo;
        }

        private void LoginForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
                ShowItemPriceInquiry();
            if (e.KeyCode == Keys.F3)
                ShowMySendToPrinter();
            else if (e.KeyCode == Keys.F12)
                ShutDown();
            else if (e.KeyCode == Keys.F5)
                Clear();            
        }

        private void txtUserID_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                txtPassword.Focus();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Login();
        }        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //TODO:Functions
            //buat tulis k file
            //string a = "abell";
            //a = a + "\r\n";
            //a = a + "ganteng";
            //a = a + "\r\n";
            //a = a + "sekali";
            //File.WriteAllText(@"C:\Users\Abell Kwok\Desktop\New Text Document.txt", a);
            //Process.Start("notepad.exe", @"C:\Users\Abell Kwok\Desktop\New Text Document.txt");

            //buat chek file
            //string curFile = @"c:\temp\test.txt";
            //Console.WriteLine(File.Exists(curFile) ? "File exists." : "File does not exist.");

            //buat baca k file
            //StreamReader objstream = new StreamReader("C:\\Users\\Abell Kwok\\Desktop\\New Text Document.txt");
            //MessageBox.Show(objstream.ReadToEnd());

            //string[] lines = File.ReadAllLines("file.txt");
            //foreach (string line in lines)
            //{
            //    // Do something with line
            //    if (line.Length > 80)
            //    {
            //        // Example code
            //    }
            //}

            //untuk create baru text
            //            using System;
            //using System.IO;

            //class MainClass
            //{
            //  static void Main(string[] args)
            //  {
            //    StreamWriter MyStream = null;
            //    string MyString = "Hello World";

            //    try
            //    {
            //      MyStream = File.CreateText("MyFile.txt");
            //      MyStream.Write(MyString);
            //    }
            //    catch (IOException e)
            //    {
            //      Console.WriteLine(e);
            //    }
            //    catch (Exception e)
            //    {
            //      Console.WriteLine(e);
            //    }
            //    finally
            //    {
            //      if (MyStream != null)
            //        MyStream.Close();
            //    }
            //  }
            //}

            Login();
        }        

        private void PopulateBranch()
        {
            var branch = new Branch();
            var dtb = branch.SelectAll();
            cboBranch.DisplayMember = "BranchName";
            cboBranch.ValueMember = "BranchID";
            cboBranch.DataSource = dtb;
        }

        private void PopulateCompany()
        {
            var Company = new Company();
            var dtb = Company.SelectOne();
            cboCompany.DisplayMember = "CompanyName";
            cboCompany.ValueMember = "ID";
            cboCompany.DataSource = dtb;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnShutDown_Click(object sender, EventArgs e)
        {
            ShutDown();
        }

        private void Login()
        {
            var user = new User();
            if (!user.LoadByPrimaryKey(txtUserID.Text))
            {
                Program.MsgBox_Show("Unknown Username", "Log In Error");
                //MessageBox.Show("Unknown Username", "Log In Error");
                txtUserID.Focus();
                return;
            }

            if (!user.isActive)
            {
                Program.MsgBox_Show("Username is not active", "User Name");
                //MessageBox.Show("Username is not active", "User Name");
                txtUserID.Focus();
                return;
            }

            if (BussinessRules.ID.GetHashStringSQL(txtPassword.Text.Trim()) != user.Password.Trim())
            {
                Program.MsgBox_Show("Password is not valid ", "Password");
                //MessageBox.Show("Password is not valid", "Password");
                txtPassword.Focus();
                return;
            }

            Program.PoleDisplay_Show((("Hi I'm " + user.UserID.Trim()) + Program.POSIFLEX_SpaceCharPerLine).Substring(0, 20)
                                    + Program.SelectOneByCommonSettingByDetailID("PDText", "01")
                                    );

            _loginInfo = new LoginInfo(user.UserID.Trim(), user.UserName.Trim(), user.UserGroupID.Trim(), cboBranch.SelectedValue.ToString(), cboBranch.Text, cboCompany.SelectedValue.ToString(), cboCompany.Text);
            
            user.Dispose();
            user = null;
            
            Close();
        }

        private void ShutDown()
        {
            if (Program.SelectOneByCommonSettingByDetailID("ButtonClick", "ShutDown") == "1")
            {
                if (Program.MsgBox_Show("Are you sure you want to shut down the computer?", "Shut Down Confirmation", "YesNo") == false)
                {
                    return;
                }
            }
            else
            {
                if (Program.MsgBox_Show("Are you sure you want to close the program?", "Close Program Confirmation", "YesNo") == false)
                {
                    return;
                }
            }            
            
            Program.PoleDisplay_Show(string.Empty);

            if (Program.SelectOneByCommonSettingByDetailID("ButtonClick", "ShutDown") == "1")
            {
                Program.Shutdown(1);                
            }
            else
            {
                Close();
            }            
        }

        private void Clear()
        {
            txtUserID.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUserID.Focus();
        }

        private void ShowItemPriceInquiry()
        {
            using (var frm = new ItemPriceInquiry())
            {
                frm.ShowItemPriceInquiry();
            }
        }

        private void ShowMySendToPrinter()
        {
            using (var frm = new MySendToPrinter())
            {
                frm.ShowMySendToPrinter();
            }
        }

        private void lblSystemInfo_Click(object sender, EventArgs e)
        {

        }
        
    }
}
