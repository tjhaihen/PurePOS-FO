namespace Raven.Pos.Sales
{
    partial class DonationInputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDonationAmountCaption = new System.Windows.Forms.Label();
            this.lblDonationType = new System.Windows.Forms.Label();
            this.cboDonationType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(132, 37);
            this.txtAmount.MaxLength = 17;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(237, 23);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyUp);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(217, 68);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 38);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(296, 68);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 38);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDonationAmountCaption
            // 
            this.lblDonationAmountCaption.AutoSize = true;
            this.lblDonationAmountCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonationAmountCaption.Location = new System.Drawing.Point(9, 40);
            this.lblDonationAmountCaption.Name = "lblDonationAmountCaption";
            this.lblDonationAmountCaption.Size = new System.Drawing.Size(117, 17);
            this.lblDonationAmountCaption.TabIndex = 4;
            this.lblDonationAmountCaption.Text = "Donation Amount";
            // 
            // lblDonationType
            // 
            this.lblDonationType.AutoSize = true;
            this.lblDonationType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonationType.Location = new System.Drawing.Point(25, 10);
            this.lblDonationType.Name = "lblDonationType";
            this.lblDonationType.Size = new System.Drawing.Size(101, 17);
            this.lblDonationType.TabIndex = 12;
            this.lblDonationType.Text = "Donation Type";
            // 
            // cboDonationType
            // 
            this.cboDonationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDonationType.Enabled = false;
            this.cboDonationType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDonationType.FormattingEnabled = true;
            this.cboDonationType.Location = new System.Drawing.Point(132, 7);
            this.cboDonationType.Name = "cboDonationType";
            this.cboDonationType.Size = new System.Drawing.Size(237, 24);
            this.cboDonationType.TabIndex = 2;
            this.cboDonationType.SelectedIndexChanged += new System.EventHandler(this.cboDonationType_SelectedIndexChanged);
            // 
            // DonationInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 113);
            this.ControlBox = false;
            this.Controls.Add(this.lblDonationType);
            this.Controls.Add(this.cboDonationType);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblDonationAmountCaption);
            this.KeyPreview = true;
            this.Name = "DonationInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Donation Input";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DonationInputForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDonationAmountCaption;
        private System.Windows.Forms.Label lblDonationType;
        private System.Windows.Forms.ComboBox cboDonationType;
    }
}