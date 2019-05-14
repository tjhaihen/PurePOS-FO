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
    public partial class MessageBoxForm : Form
    {
        private string _TypeMsgBox = "";
        private int DefaultMaxText = 500;
        private int DefaultSizeSpaceForm = 5;
        private int DefaultSizeSpaceText = 70;
        private int DefaultSizeSpaceBtn = 5;
        private int DefaultSizeChar = 5;
        private int btnYesWidth = 0;
        private int btnNoWidth = 0;
        private int SizebtnText = 0;
        private bool IsClose = false;
        private bool _retval = false;

        public MessageBoxForm()
        {
            InitializeComponent();
            btnYesWidth = btnYes.Width;
            btnNoWidth = btnNo.Width;
        }
        public bool Preview(string Text, string Caption, string TypeMsgBox, int intervalTimer)
        {
            _TypeMsgBox = TypeMsgBox.Trim().ToUpper();
            this.Text = Caption.Trim();

            SizebtnText = ((Text.Trim().Length * DefaultSizeChar) + DefaultSizeSpaceText);

            if (SizebtnText > DefaultMaxText)
                SizebtnText = DefaultMaxText;

            // btnText
            //this.btnText.Location = new System.Drawing.Point(2, -1);
            //this.btnText.Size = new System.Drawing.Size(SizebtnText, 81);
            btnText.Width = SizebtnText;

            //this.ClientSize = new System.Drawing.Size(SizebtnText + DefaultSizeSpaceForm, 120);
            this.ClientSize = new System.Drawing.Size(SizebtnText + DefaultSizeSpaceForm, this.ClientSize.Height);
            
            btnText.Text = Text.Trim();

            switch (_TypeMsgBox)
            {
                case "YESNO":
                    SetMsgBoxYesNoForm();
                    break;
                default:
                    SetMsgBoxOkForm();
                    break;
            }

            timerSystemCurrentTime.Interval = intervalTimer;
            ShowDialog();
            return _retval;
        }
      
        public void SetMsgBoxOkForm()
        {
            // btnYes
            //this.btnYes.Location = new System.Drawing.Point(SizebtnText - btnYesWidth, 89);
            this.btnYes.Location = new System.Drawing.Point(SizebtnText - btnYesWidth, btnYes.Location.Y);
            btnYes.Text = "&OK";
            btnYes.Focus();
            
            // btnNo
            this.btnNo.Location = new System.Drawing.Point(btnText.Location.X, btnNo.Location.Y);
            btnNo.Visible = false;
        }

        public void SetMsgBoxYesNoForm()
        {
            // btnYes
            this.btnYes.Location = new System.Drawing.Point((SizebtnText - btnYesWidth - btnNoWidth - DefaultSizeSpaceBtn), btnYes.Location.Y);
            btnYes.Focus();
            btnYes.Text = "&Yes";

            // btnNo
            this.btnNo.Location = new System.Drawing.Point(SizebtnText - btnNoWidth, btnNo.Location.Y);
            btnNo.Text = "&No";
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            fbtnYes();
        }
        private void fbtnYes()
        {
            _retval = true;
            IsClose = true;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            fbtnNo();
        }

        private void fbtnNo()
        {
            _retval = false;
            IsClose = true;
        }

        private void MessageBoxForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (_TypeMsgBox == "YESNO")
            {
                if (e.KeyCode == Keys.Y)
                    fbtnYes();
                else if (e.KeyCode == Keys.N || e.KeyCode == Keys.Escape)
                    fbtnNo();
            }
            else if (e.KeyCode == Keys.O || e.KeyCode == Keys.Escape)
                fbtnYes();
        }

        private void timerSystemCurrentTime_Tick(object sender, EventArgs e)
        {
            if (IsClose)
                Close();
        }
    }
}
