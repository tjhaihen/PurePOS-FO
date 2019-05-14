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
using Raven.BussinessRules;
using Raven.Common;

namespace Raven.Pos.Sales
{
    public partial class MySendToPrinter : Form
    {
        public MySendToPrinter()
        {
            InitializeComponent();
        }

        public void ShowMySendToPrinter()
        {
            ShowDialog();
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            //Start Clock
            timer1.Start();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font printFont;
            printFont = new Font("Draft", 8);

            e.Graphics.DrawString(DirectPrint(), printFont, Brushes.Black, 0, 0);
        }

        private string DirectPrint()
        {
            int MaxStringPerLine = Convert.ToInt16(Program.SelectOneByCommonSettingByDetailID("DirectPrint", "MaxLenPerLine"));
            string _lineBreak = string.Empty;

            //_lineBreak
            for (int lb = 0; lb < MaxStringPerLine; lb++)
            {
                _lineBreak += "-";
            }
            _lineBreak += "\n";

            string txtprn;
            txtprn = "R/ arcapec tab no. X / 3 dd 2\n-------\nR/ oralit szt no X / ad lib\n-------\nR/ Antasida Syr no. I / 3 dd cI\n-------\nR/ scopamin tab no. X / 3 dd 1" + "\n";
            //txtprn = "11111 11111 11111 11111 11111 11111 11111 11111" + "\n";
            //txtprn.Replace("  ", "\n");

            return txtprn;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            printDocument1.Print();
            timer1.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void MySendToPrinter_Load(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
