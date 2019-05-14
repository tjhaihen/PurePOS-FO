namespace Raven.Pos.Sales
{
    partial class CancelPaymentForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.grdPayment = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(477, 317);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 38);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(398, 317);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(73, 38);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // grdPayment
            // 
            this.grdPayment.AllowUserToAddRows = false;
            this.grdPayment.AllowUserToDeleteRows = false;
            this.grdPayment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPayment.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grdPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PaymentTypeID,
            this.PaymentTypeName,
            this.CardTypeID,
            this.CardTypeName,
            this.Amount});
            this.grdPayment.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdPayment.Location = new System.Drawing.Point(12, 12);
            this.grdPayment.MultiSelect = false;
            this.grdPayment.Name = "grdPayment";
            this.grdPayment.ReadOnly = true;
            this.grdPayment.RowHeadersWidth = 25;
            this.grdPayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPayment.Size = new System.Drawing.Size(538, 299);
            this.grdPayment.StandardTab = true;
            this.grdPayment.TabIndex = 7;
            this.grdPayment.DoubleClick += new System.EventHandler(this.grdPayment_DoubleClick);
            this.grdPayment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdPayment_KeyDown);
            this.grdPayment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdPayment_KeyUp);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 43;
            // 
            // PaymentTypeID
            // 
            this.PaymentTypeID.DataPropertyName = "PaymentTypeID";
            this.PaymentTypeID.FillWeight = 70.12987F;
            this.PaymentTypeID.HeaderText = "Payment Type ID";
            this.PaymentTypeID.Name = "PaymentTypeID";
            this.PaymentTypeID.ReadOnly = true;
            this.PaymentTypeID.Visible = false;
            // 
            // PaymentTypeName
            // 
            this.PaymentTypeName.DataPropertyName = "PaymentTypeName";
            this.PaymentTypeName.HeaderText = "Payment Type Name";
            this.PaymentTypeName.Name = "PaymentTypeName";
            this.PaymentTypeName.ReadOnly = true;
            // 
            // CardTypeID
            // 
            this.CardTypeID.DataPropertyName = "CardTypeID";
            this.CardTypeID.HeaderText = "Card Type ID";
            this.CardTypeID.Name = "CardTypeID";
            this.CardTypeID.ReadOnly = true;
            this.CardTypeID.Visible = false;
            // 
            // CardTypeName
            // 
            this.CardTypeName.DataPropertyName = "CardTypeName";
            this.CardTypeName.HeaderText = "Card Type Name";
            this.CardTypeName.Name = "CardTypeName";
            this.CardTypeName.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.Amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.Amount.FillWeight = 129.8701F;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 68;
            // 
            // CancelPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 367);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grdPayment);
            this.KeyPreview = true;
            this.Name = "CancelPaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cancel Payment";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CancelPaymentForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.grdPayment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridView grdPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}