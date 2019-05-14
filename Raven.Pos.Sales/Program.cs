using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using System.Management;
using Raven.BussinessRules;
using Raven.SystemFramework;
using System.Security.Cryptography; 
using System.Text;
using Raven.BussinessRules;
using Raven.Common;

namespace Raven.Pos.Sales
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static string FormatCurrency = "{0:#,##0.00}";
        public static string FormatCurrencyForBillReceipt = "{0:#,##0}";
        public static string FormatQty = "{0:##0.000}";
        public static string FormatDate = "{0:dd-MM-yyyy}";
        public static string FormatDateISO = "{0:yyyyMMdd}";        
        public static string FormatTime = "{0:HH:mm:ss}";
        private static string[] ConStr;
        public static string SeparatorPReport = "[RPT]";
        private static string ConStrReport;
        private static string AppReportPath = Application.StartupPath + "\\Reports\\";
        private static string AppPoleDisplayPath = Application.StartupPath + "\\LineDisplay\\";
        private static string AppCashDrawerPath = Application.StartupPath + "\\CashDrawer\\";                      
        public static string RptExe = "ReportPosFO.exe";
        public static string POSIFLEX_SpaceCharPerLine = new string(' ', 20);
                
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.OnApplicationStart(Application.ExecutablePath);

            ConStr = HisConfiguration.ConnectionString.Split(';');
            ConStrReport = ConStr[0].Substring(ConStr[0].IndexOf('=') + 1) + SeparatorPReport +
                                             ConStr[1].Substring(ConStr[1].IndexOf('=') + 1) + SeparatorPReport +
                                             ConStr[2].Substring(ConStr[2].IndexOf('=') + 1) + SeparatorPReport +
                                             ConStr[3].Substring(ConStr[3].IndexOf('=') + 1);

            LoginInfo loginInfo = null;
            using (var frm = new LoginForm())
            {
                loginInfo = frm.GetLoginInfo();
            }
            if (loginInfo != null)
                //Application.Run(new MainForm(loginInfo));
                Application.Run(new POSMainForm(loginInfo));

        }

        public enum ShutDownFlag
        {
            LogOff = 0, Shutdown = 1, Reboot = 2, ForcedLogOff = 4, ForcedShutdown = 5,
            ForcedReboot = 6, PowerOff = 8, ForcedPowerOff = 12
        }

        static public void Shutdown(int ShutDownFlag)
        {
            ManagementBaseObject mboShutdown = null;
            var mcWin32 = new ManagementClass("Win32_OperatingSystem");
            mcWin32.Get();


            // You can't shutdown without security privileges
            mcWin32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject mboShutdownParams =
                     mcWin32.GetMethodParameters("Win32Shutdown");

            // Flag 1 means we want to shut down the system. Use "2" to reboot.
            mboShutdownParams["Flags"] = ShutDownFlag.ToString();
            mboShutdownParams["Reserved"] = "0";
            foreach (ManagementObject manObj in mcWin32.GetInstances())
            {
                mboShutdown = manObj.InvokeMethod("Win32Shutdown",
                                               mboShutdownParams, null);
            }
        }

        static public void PrintReport(string param, string RptName, bool PrinttoPrinter = false, string RptExeName = "")
        {
            RptExeName = (RptExeName == "" ? RptExe : RptExeName);
            System.Diagnostics.Process.Start(AppReportPath + RptExeName.Trim(), AppReportPath + SeparatorPReport + 
                                                            ConStrReport + SeparatorPReport +
                                                            RptName + SeparatorPReport + 
                                                            Convert.ToString(PrinttoPrinter) + SeparatorPReport +
                                                            param);
        }
        
        static public void PoleDisplay_Show(string txt, string ExeName = "LineDisplay.Exe")
        {
            //System.Diagnostics.Process.Start(AppPoleDisplayPath + ExeName.Trim(), txt);
        }

        static public void CashDrawer_Open(string txt, string ExeName = "CashDrawer.exe")
        {
            System.Diagnostics.Process.Start(AppCashDrawerPath + ExeName.Trim(), txt);
        }

        static public string SelectOneByCommonSetting(string groupID)
        {
            var cs = new CommonSetting();
            return Common.ProcessNull.GetString(cs.SelectAllByGroupID(groupID).Rows[0]["DetailID"]) + "";
        }

        static public string SelectOneByCommonSettingByDetailID(string groupID, string DetailID)
        {
            var cs = new CommonSetting();
            cs.GroupID = groupID.Trim();
            cs.DetailID = DetailID.Trim();
            return Common.ProcessNull.GetString(cs.SelecOneByGroupIDByDetailID().Rows[0]["DetailDesc"]) + "";
        }

        static public void PopulateByCommonSetting(ComboBox cbo, string groupID, bool fblank = false)
        {
            var cs = new CommonSetting();

            var dtb = cs.SelectAllByGroupID(groupID);
            cbo.DataSource = null;
            cbo.ValueMember = "DetailID";
            cbo.DisplayMember = "DetailDesc";

            if (fblank)
                dtb.Rows.Add("", "");

            dtb.DefaultView.Sort = "DetailID Asc";
            cbo.DataSource = dtb;

            //if (fblank)
                //cbo.Items.Add(new ComboBoxItem("", ""));

            //foreach (DataRow row in dtb.Rows)
            //{
            //    cbo.Items.Add(new ComboBoxItem(row["DetailID"] + "", row["DetailDesc"] + ""));
            //}
        }
        
        static public void PopulateByWarehouse(ComboBox cbo, bool fblank = false)
        {
            var Wh = new Warehouse();
            var dtb = Wh.SelectAllWarehouse();
            cbo.Items.Clear();
            cbo.DisplayMember = "WhName";
            cbo.ValueMember = "WhID";

            if (fblank)
                dtb.Rows.Add("", "");

            dtb.DefaultView.Sort = "WhID Asc";
            cbo.DataSource = dtb;
        }
        
        static public void PopulateByUnitID(string WhID, ComboBox cbo, bool fblank = false)
        {
            var Wh = new Warehouse();
            var dtb = Wh.SelectAllUnitByWarehouse(WhID.Trim());
            cbo.Items.Clear();
            cbo.DisplayMember = "UnitName";
            cbo.ValueMember = "UnitID";

            if (fblank)
                dtb.Rows.Add("", "");

            dtb.DefaultView.Sort = "UnitID Asc";
            cbo.DataSource = dtb;
        }
        
        //static public string GetNewID()
        //{
        //    return string.Format("{0:000000000}{1:000000}", (new Random()).Next(999999999), +(new Random()).Next(999999));
        //}

        static public DateTime ConvertToDate(string CurrentDate, string CurrentFormatDate = "dd-MM-yyyyy")
        {
            switch (CurrentFormatDate)
            {
                case "dd-MM-yyyyy":
                    CurrentDate =  CurrentDate.Substring(3, 2) + "/" + CurrentDate.Substring(0, 2) + "/" + CurrentDate.Substring(6, 4);
                    break;
            }
            return Convert.ToDateTime(CurrentDate);
        }

        static public DateTime ConvertToDatetime(string CurrentDate, string CurrentTime, string CurrentFormatDate = "dd-MM-yyyyy")
        {
            string CurrentDateTime = "";
            switch (CurrentFormatDate)
            {
                case "dd-MM-yyyyy":
                    CurrentDateTime = CurrentDate.Substring(3, 2) + "/" + CurrentDate.Substring(0, 2) + "/" + CurrentDate.Substring(6, 4) + " " + CurrentTime.Trim();
                    break;
            }
            return Convert.ToDateTime(CurrentDateTime);
        }

        static public bool MsgBox_Show(string Text, string Caption = "Message Box", string TypeMsgBox = "OK", int IntervalTimer = 1500)
        {             
            bool _retval = false;
            using (var msgbox = new MessageBoxForm())
            {
                _retval = msgbox.Preview(Text.Trim(), Caption.Trim(), TypeMsgBox.Trim(), IntervalTimer);
            }
            return _retval;
        }

        static public string Left(string Text, int n)
        {
            return (Text.Trim().Length == 0 ? "" : Text.Substring(0, n));
        }

        static public string Right(string Text, int n)
        {
            return (Text.Trim().Length == 0 ? "" : Text.Substring(Text.Length - n, n));
        }

        static public string TextToRight(string First_Text, string Text, int MaxStringPerLine)
        {
            string toReturnStr = string.Empty;
            string strSpace = string.Empty;

            int nFirst_Text = First_Text.Length;
            int nText = Text.Length;
            int nSpace = MaxStringPerLine - (nFirst_Text + nText);

            //return String.Concat(Enumerable.Repeat(" ", (int)nSpace), Text);

            for (int i = 0; i < nSpace; i++)
            {
                strSpace += " ";
            }

            return String.Concat(strSpace, Text);
        }

        static public string TextToCenter(string First_Text, string Text, int MaxStringPerLine)
        {
            string toReturnStr = string.Empty;
            string strLeftSpace = string.Empty;
            string strRightSpace = string.Empty;

            int nLeftSpace = 0;
            int nRightSpace = 0;
            int nFirst_Text = First_Text.Length;
            int nText = Text.Length;

            for (int i = 0; i < (MaxStringPerLine - (nFirst_Text + nText)); i+=2)
            {
                nLeftSpace += 1;
                nRightSpace += 1;
            }

            //return String.Concat(Enumerable.Repeat(" ", (int)nLeftSpace), Text, Enumerable.Repeat(" ", (int)nRightSpace));
            for (int li = 0; li < nLeftSpace; li++)
            {
                strLeftSpace += " ";
            }

            for (int ri = 0; ri < nRightSpace; ri++)
            {
                strRightSpace += " ";
            }

            return String.Concat(strLeftSpace, Text, strRightSpace);
        }

        static public string TextToDesiredStartPosition(string First_Text, string Text, int Start_Position)
        {
            string toReturnStr = string.Empty;
            string strSpace = string.Empty;
            
            int nFirst_Text = First_Text.Length;
            int nSpace = Start_Position - nFirst_Text;
            
            //return String.Concat(Enumerable.Repeat(" ", (int)nSpace), Text);
            for (int i = 0; i < nSpace; i++)
            {
                strSpace += " ";
            }

            return String.Concat(strSpace, Text);
        }

        static public string TextPerLineDueToMaxLenPerLine(string Text, int MaxStringPerLine)
        {
            string strToReturn = string.Empty;
            int nText = Text.Trim().Length;

            if (nText > MaxStringPerLine)
            {
                for (int i = 0; i <= Decimal.Round((nText / MaxStringPerLine), 0); i++)
                {
                    if (Text.Length > MaxStringPerLine)
                    {
                        strToReturn += Left(Text, MaxStringPerLine) + "\n";
                        Text = Text.Substring(MaxStringPerLine + i, Text.Length - (strToReturn.Length - (i + 1)));
                    }
                    else
                    {
                        strToReturn += Left(Text, Text.Length) + "\n";
                    }
                }
            }
            else
            {
                strToReturn += Text + "\n";
            }

            return strToReturn;
        }
    }
}

