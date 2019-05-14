namespace Raven.Pos.Sales
{
    partial class SettlementInputForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridSettlement = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vwSQPID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentMethodID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentMethodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpSettlementDate = new System.Windows.Forms.DateTimePicker();
            this.lblSettlementDateCaption = new System.Windows.Forms.Label();
            this.lblCashierIDCaption = new System.Windows.Forms.Label();
            this.txtCashierID = new System.Windows.Forms.TextBox();
            this.txtCashierName = new System.Windows.Forms.TextBox();
            this.lblCashierNameCaption = new System.Windows.Forms.Label();
            this.lblGrandTotalCaption = new System.Windows.Forms.Label();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printSettlement = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.gridSettlement)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSettlement
            // 
            this.gridSettlement.AllowUserToAddRows = false;
            this.gridSettlement.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridSettlement.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridSettlement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridSettlement.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSettlement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridSettlement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSettlement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.vwSQPID,
            this.Date,
            this.PaymentMethodID,
            this.PaymentMethodName,
            this.Amount});
            this.gridSettlement.Location = new System.Drawing.Point(12, 105);
            this.gridSettlement.Name = "gridSettlement";
            this.gridSettlement.RowHeadersWidth = 25;
            this.gridSettlement.Size = new System.Drawing.Size(538, 284);
            this.gridSettlement.TabIndex = 4;
            this.gridSettlement.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gridSettlement_CellValidating);
            this.gridSettlement.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSettlement_CellValueChanged);
            this.gridSettlement.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridSettlement_EdittingControlShowing);
            this.gridSettlement.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridSettlement_KeyDown);
            this.gridSettlement.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridSettlement_KeyUp);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // vwSQPID
            // 
            this.vwSQPID.DataPropertyName = "vwSQPID";
            this.vwSQPID.HeaderText = "ID";
            this.vwSQPID.Name = "vwSQPID";
            this.vwSQPID.ReadOnly = true;
            this.vwSQPID.Width = 43;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Date.DataPropertyName = "Date";
            dataGridViewCellStyle7.Format = "dd-MM-yyyy";
            dataGridViewCellStyle7.NullValue = null;
            this.Date.DefaultCellStyle = dataGridViewCellStyle7;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Visible = false;
            // 
            // PaymentMethodID
            // 
            this.PaymentMethodID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PaymentMethodID.DataPropertyName = "PaymentMethodID";
            this.PaymentMethodID.HeaderText = "Payment Method ID";
            this.PaymentMethodID.Name = "PaymentMethodID";
            this.PaymentMethodID.ReadOnly = true;
            this.PaymentMethodID.Visible = false;
            // 
            // PaymentMethodName
            // 
            this.PaymentMethodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PaymentMethodName.DataPropertyName = "PaymentMethodName";
            this.PaymentMethodName.HeaderText = "Payment Method";
            this.PaymentMethodName.Name = "PaymentMethodName";
            this.PaymentMethodName.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle8;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(477, 431);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 39);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(319, 431);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 39);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpSettlementDate
            // 
            this.dtpSettlementDate.Checked = false;
            this.dtpSettlementDate.CustomFormat = "dd-MM-yyyy";
            this.dtpSettlementDate.Enabled = false;
            this.dtpSettlementDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSettlementDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSettlementDate.Location = new System.Drawing.Point(127, 14);
            this.dtpSettlementDate.Name = "dtpSettlementDate";
            this.dtpSettlementDate.Size = new System.Drawing.Size(424, 23);
            this.dtpSettlementDate.TabIndex = 1;
            // 
            // lblSettlementDateCaption
            // 
            this.lblSettlementDateCaption.AutoSize = true;
            this.lblSettlementDateCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettlementDateCaption.Location = new System.Drawing.Point(12, 17);
            this.lblSettlementDateCaption.Name = "lblSettlementDateCaption";
            this.lblSettlementDateCaption.Size = new System.Drawing.Size(109, 17);
            this.lblSettlementDateCaption.TabIndex = 8;
            this.lblSettlementDateCaption.Text = "Settlement Date";
            this.lblSettlementDateCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCashierIDCaption
            // 
            this.lblCashierIDCaption.AutoSize = true;
            this.lblCashierIDCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashierIDCaption.Location = new System.Drawing.Point(48, 46);
            this.lblCashierIDCaption.Name = "lblCashierIDCaption";
            this.lblCashierIDCaption.Size = new System.Drawing.Size(73, 17);
            this.lblCashierIDCaption.TabIndex = 9;
            this.lblCashierIDCaption.Text = "Cashier ID";
            this.lblCashierIDCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCashierID
            // 
            this.txtCashierID.Enabled = false;
            this.txtCashierID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashierID.Location = new System.Drawing.Point(127, 43);
            this.txtCashierID.Name = "txtCashierID";
            this.txtCashierID.ReadOnly = true;
            this.txtCashierID.Size = new System.Drawing.Size(423, 23);
            this.txtCashierID.TabIndex = 2;
            this.txtCashierID.TabStop = false;
            // 
            // txtCashierName
            // 
            this.txtCashierName.Enabled = false;
            this.txtCashierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashierName.Location = new System.Drawing.Point(127, 72);
            this.txtCashierName.Name = "txtCashierName";
            this.txtCashierName.ReadOnly = true;
            this.txtCashierName.Size = new System.Drawing.Size(423, 23);
            this.txtCashierName.TabIndex = 3;
            this.txtCashierName.TabStop = false;
            // 
            // lblCashierNameCaption
            // 
            this.lblCashierNameCaption.AutoSize = true;
            this.lblCashierNameCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashierNameCaption.Location = new System.Drawing.Point(24, 72);
            this.lblCashierNameCaption.Name = "lblCashierNameCaption";
            this.lblCashierNameCaption.Size = new System.Drawing.Size(97, 17);
            this.lblCashierNameCaption.TabIndex = 11;
            this.lblCashierNameCaption.Text = "Cashier Name";
            this.lblCashierNameCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblGrandTotalCaption
            // 
            this.lblGrandTotalCaption.AutoSize = true;
            this.lblGrandTotalCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotalCaption.Location = new System.Drawing.Point(229, 398);
            this.lblGrandTotalCaption.Name = "lblGrandTotalCaption";
            this.lblGrandTotalCaption.Size = new System.Drawing.Size(84, 17);
            this.lblGrandTotalCaption.TabIndex = 13;
            this.lblGrandTotalCaption.Text = "Grand Total";
            this.lblGrandTotalCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Enabled = false;
            this.txtGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrandTotal.Location = new System.Drawing.Point(319, 395);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(231, 23);
            this.txtGrandTotal.TabIndex = 5;
            this.txtGrandTotal.TabStop = false;
            this.txtGrandTotal.Text = "0.00";
            this.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(398, 431);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(73, 39);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printSettlement
            // 
            this.printSettlement.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printSettlement_PrintPage);
            // 
            // SettlementInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 484);
            this.ControlBox = false;
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtGrandTotal);
            this.Controls.Add(this.lblGrandTotalCaption);
            this.Controls.Add(this.txtCashierName);
            this.Controls.Add(this.lblCashierNameCaption);
            this.Controls.Add(this.txtCashierID);
            this.Controls.Add(this.lblCashierIDCaption);
            this.Controls.Add(this.lblSettlementDateCaption);
            this.Controls.Add(this.dtpSettlementDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gridSettlement);
            this.KeyPreview = true;
            this.Name = "SettlementInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settlement Input Form";
            this.Load += new System.EventHandler(this.SettlementInputForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SettlementInputForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.gridSettlement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridSettlement;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpSettlementDate;
        private System.Windows.Forms.Label lblSettlementDateCaption;
        private System.Windows.Forms.Label lblCashierIDCaption;
        private System.Windows.Forms.TextBox txtCashierID;
        private System.Windows.Forms.TextBox txtCashierName;
        private System.Windows.Forms.Label lblCashierNameCaption;
        private System.Windows.Forms.Label lblGrandTotalCaption;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn vwSQPID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentMethodID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentMethodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Drawing.Printing.PrintDocument printSettlement;
    }
}