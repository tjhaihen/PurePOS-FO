﻿namespace Raven.Pos.Sales
{
    partial class SearchSalesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSearchSales = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTransactionDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblSettlementDateCaption = new System.Windows.Forms.Label();
            this.dtpTransactionDateFrom = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSTXnNoTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.grdSales = new System.Windows.Forms.DataGridView();
            this.colSTXnNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSTxnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSTXnNoFrom = new System.Windows.Forms.TextBox();
            this.lblTransactionNoCaption = new System.Windows.Forms.Label();
            this.pnlSearchSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSales)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearchSales
            // 
            this.pnlSearchSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearchSales.Controls.Add(this.label1);
            this.pnlSearchSales.Controls.Add(this.dtpTransactionDateTo);
            this.pnlSearchSales.Controls.Add(this.lblSettlementDateCaption);
            this.pnlSearchSales.Controls.Add(this.dtpTransactionDateFrom);
            this.pnlSearchSales.Controls.Add(this.btnSearch);
            this.pnlSearchSales.Controls.Add(this.txtSTXnNoTo);
            this.pnlSearchSales.Controls.Add(this.label2);
            this.pnlSearchSales.Controls.Add(this.btnClose);
            this.pnlSearchSales.Controls.Add(this.btnOk);
            this.pnlSearchSales.Controls.Add(this.grdSales);
            this.pnlSearchSales.Controls.Add(this.txtSTXnNoFrom);
            this.pnlSearchSales.Controls.Add(this.lblTransactionNoCaption);
            this.pnlSearchSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearchSales.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchSales.Name = "pnlSearchSales";
            this.pnlSearchSales.Size = new System.Drawing.Size(566, 402);
            this.pnlSearchSales.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(290, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "to";
            // 
            // dtpTransactionDateTo
            // 
            this.dtpTransactionDateTo.Checked = false;
            this.dtpTransactionDateTo.CustomFormat = "dd-MM-yyyy";
            this.dtpTransactionDateTo.Enabled = false;
            this.dtpTransactionDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTransactionDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransactionDateTo.Location = new System.Drawing.Point(317, 5);
            this.dtpTransactionDateTo.Name = "dtpTransactionDateTo";
            this.dtpTransactionDateTo.Size = new System.Drawing.Size(144, 23);
            this.dtpTransactionDateTo.TabIndex = 16;
            // 
            // lblSettlementDateCaption
            // 
            this.lblSettlementDateCaption.AutoSize = true;
            this.lblSettlementDateCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettlementDateCaption.Location = new System.Drawing.Point(16, 8);
            this.lblSettlementDateCaption.Name = "lblSettlementDateCaption";
            this.lblSettlementDateCaption.Size = new System.Drawing.Size(117, 17);
            this.lblSettlementDateCaption.TabIndex = 15;
            this.lblSettlementDateCaption.Text = "Transaction Date";
            this.lblSettlementDateCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpTransactionDateFrom
            // 
            this.dtpTransactionDateFrom.Checked = false;
            this.dtpTransactionDateFrom.CustomFormat = "dd-MM-yyyy";
            this.dtpTransactionDateFrom.Enabled = false;
            this.dtpTransactionDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTransactionDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransactionDateFrom.Location = new System.Drawing.Point(139, 5);
            this.dtpTransactionDateFrom.Name = "dtpTransactionDateFrom";
            this.dtpTransactionDateFrom.Size = new System.Drawing.Size(145, 23);
            this.dtpTransactionDateFrom.TabIndex = 5;
            this.dtpTransactionDateFrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtpTransactionDate_KeyUp);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(317, 356);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(73, 38);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSTXnNoTo
            // 
            this.txtSTXnNoTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTXnNoTo.Location = new System.Drawing.Point(316, 34);
            this.txtSTXnNoTo.Name = "txtSTXnNoTo";
            this.txtSTXnNoTo.Size = new System.Drawing.Size(144, 23);
            this.txtSTXnNoTo.TabIndex = 8;
            this.txtSTXnNoTo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSTXnNoTo_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(290, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "to";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(475, 356);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 38);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(396, 356);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(73, 38);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // grdSales
            // 
            this.grdSales.AllowUserToAddRows = false;
            this.grdSales.AllowUserToDeleteRows = false;
            this.grdSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdSales.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grdSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTXnNo,
            this.colSTxnDate,
            this.Status});
            this.grdSales.Location = new System.Drawing.Point(11, 63);
            this.grdSales.Name = "grdSales";
            this.grdSales.ReadOnly = true;
            this.grdSales.RowHeadersWidth = 25;
            this.grdSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSales.Size = new System.Drawing.Size(538, 287);
            this.grdSales.StandardTab = true;
            this.grdSales.TabIndex = 9;
            this.grdSales.DoubleClick += new System.EventHandler(this.grdSales_DoubleClick);
            this.grdSales.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdSales_KeyDown);
            this.grdSales.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdSales_KeyUp);
            // 
            // colSTXnNo
            // 
            this.colSTXnNo.DataPropertyName = "STXnNo";
            this.colSTXnNo.HeaderText = "No";
            this.colSTXnNo.Name = "colSTXnNo";
            this.colSTXnNo.ReadOnly = true;
            // 
            // colSTxnDate
            // 
            this.colSTxnDate.DataPropertyName = "STxnDate";
            dataGridViewCellStyle1.Format = "dd-MM-yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.colSTxnDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colSTxnDate.HeaderText = "Date";
            this.colSTxnDate.Name = "colSTxnDate";
            this.colSTxnDate.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // txtSTXnNoFrom
            // 
            this.txtSTXnNoFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTXnNoFrom.Location = new System.Drawing.Point(140, 34);
            this.txtSTXnNoFrom.Name = "txtSTXnNoFrom";
            this.txtSTXnNoFrom.Size = new System.Drawing.Size(144, 23);
            this.txtSTXnNoFrom.TabIndex = 6;
            this.txtSTXnNoFrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSTXnNoFrom_KeyUp);
            // 
            // lblTransactionNoCaption
            // 
            this.lblTransactionNoCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTransactionNoCaption.AutoSize = true;
            this.lblTransactionNoCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionNoCaption.Location = new System.Drawing.Point(25, 37);
            this.lblTransactionNoCaption.Name = "lblTransactionNoCaption";
            this.lblTransactionNoCaption.Size = new System.Drawing.Size(109, 17);
            this.lblTransactionNoCaption.TabIndex = 7;
            this.lblTransactionNoCaption.Text = "Transaction No.";
            this.lblTransactionNoCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SearchSalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 402);
            this.ControlBox = false;
            this.Controls.Add(this.pnlSearchSales);
            this.KeyPreview = true;
            this.Name = "SearchSalesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Transaction";
            this.Load += new System.EventHandler(this.SearchSalesForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchSalesForm_KeyUp);
            this.pnlSearchSales.ResumeLayout(false);
            this.pnlSearchSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearchSales;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSTXnNoTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridView grdSales;
        private System.Windows.Forms.TextBox txtSTXnNoFrom;
        private System.Windows.Forms.Label lblTransactionNoCaption;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTXnNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTxnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Label lblSettlementDateCaption;
        private System.Windows.Forms.DateTimePicker dtpTransactionDateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTransactionDateTo;

    }
}