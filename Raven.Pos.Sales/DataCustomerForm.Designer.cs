namespace Raven.Pos.Sales
{
    partial class DataCustomerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdLastTransaction = new System.Windows.Forms.DataGridView();
            this.TransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalTransactionAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSeacrh = new System.Windows.Forms.Label();
            this.grdEntities = new System.Windows.Forms.DataGridView();
            this.txtEntitiesName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EntitiesSeqNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntitiesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntitiesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberSinceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrimaryAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrimaryPhoneNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLabelTop10 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdLastTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntities)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLastTransaction
            // 
            this.grdLastTransaction.AllowUserToAddRows = false;
            this.grdLastTransaction.AllowUserToDeleteRows = false;
            this.grdLastTransaction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdLastTransaction.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grdLastTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLastTransaction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransactionDate,
            this.TotalTransactionAmount});
            this.grdLastTransaction.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdLastTransaction.Location = new System.Drawing.Point(306, 237);
            this.grdLastTransaction.MultiSelect = false;
            this.grdLastTransaction.Name = "grdLastTransaction";
            this.grdLastTransaction.ReadOnly = true;
            this.grdLastTransaction.RowHeadersWidth = 25;
            this.grdLastTransaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLastTransaction.Size = new System.Drawing.Size(258, 204);
            this.grdLastTransaction.StandardTab = true;
            this.grdLastTransaction.TabIndex = 5;
            // 
            // TransactionDate
            // 
            this.TransactionDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TransactionDate.DataPropertyName = "TransactionDate";
            dataGridViewCellStyle7.Format = "dd-MM-yyyy";
            this.TransactionDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.TransactionDate.HeaderText = "Date";
            this.TransactionDate.Name = "TransactionDate";
            this.TransactionDate.ReadOnly = true;
            this.TransactionDate.Width = 55;
            // 
            // TotalTransactionAmount
            // 
            this.TotalTransactionAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalTransactionAmount.DataPropertyName = "TotalTransactionAmount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.TotalTransactionAmount.DefaultCellStyle = dataGridViewCellStyle8;
            this.TotalTransactionAmount.HeaderText = "Amount";
            this.TotalTransactionAmount.Name = "TotalTransactionAmount";
            this.TotalTransactionAmount.ReadOnly = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(159, 9);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(405, 23);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // lblSeacrh
            // 
            this.lblSeacrh.AutoSize = true;
            this.lblSeacrh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeacrh.Location = new System.Drawing.Point(12, 12);
            this.lblSeacrh.Name = "lblSeacrh";
            this.lblSeacrh.Size = new System.Drawing.Size(141, 17);
            this.lblSeacrh.TabIndex = 6;
            this.lblSeacrh.Text = "Member# / ID / Name";
            // 
            // grdEntities
            // 
            this.grdEntities.AllowUserToAddRows = false;
            this.grdEntities.AllowUserToDeleteRows = false;
            this.grdEntities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdEntities.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grdEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEntities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EntitiesSeqNo,
            this.EntitiesID,
            this.EntitiesName,
            this.MemberNo,
            this.MemberSinceDate,
            this.PrimaryAddress,
            this.PrimaryPhoneNo});
            this.grdEntities.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdEntities.Location = new System.Drawing.Point(15, 38);
            this.grdEntities.MultiSelect = false;
            this.grdEntities.Name = "grdEntities";
            this.grdEntities.ReadOnly = true;
            this.grdEntities.RowHeadersWidth = 25;
            this.grdEntities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEntities.Size = new System.Drawing.Size(549, 164);
            this.grdEntities.StandardTab = true;
            this.grdEntities.TabIndex = 1;
            this.grdEntities.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdEntities_KeyDown);
            this.grdEntities.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdEntities_KeyUp);
            // 
            // txtEntitiesName
            // 
            this.txtEntitiesName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntitiesName.Location = new System.Drawing.Point(15, 257);
            this.txtEntitiesName.Name = "txtEntitiesName";
            this.txtEntitiesName.ReadOnly = true;
            this.txtEntitiesName.Size = new System.Drawing.Size(284, 23);
            this.txtEntitiesName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Name :";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(15, 312);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(284, 23);
            this.txtAddress.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Address :";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNo.Location = new System.Drawing.Point(15, 368);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.ReadOnly = true;
            this.txtPhoneNo.Size = new System.Drawing.Size(284, 23);
            this.txtPhoneNo.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Phone# : ";
            // 
            // EntitiesSeqNo
            // 
            this.EntitiesSeqNo.DataPropertyName = "EntitiesSeqNo";
            this.EntitiesSeqNo.HeaderText = "Entities Seq No";
            this.EntitiesSeqNo.Name = "EntitiesSeqNo";
            this.EntitiesSeqNo.ReadOnly = true;
            this.EntitiesSeqNo.Visible = false;
            // 
            // EntitiesID
            // 
            this.EntitiesID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EntitiesID.DataPropertyName = "EntitiesID";
            this.EntitiesID.FillWeight = 106.599F;
            this.EntitiesID.HeaderText = "ID";
            this.EntitiesID.Name = "EntitiesID";
            this.EntitiesID.ReadOnly = true;
            this.EntitiesID.Width = 43;
            // 
            // EntitiesName
            // 
            this.EntitiesName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EntitiesName.DataPropertyName = "EntitiesName";
            this.EntitiesName.FillWeight = 126.5054F;
            this.EntitiesName.HeaderText = "Name";
            this.EntitiesName.Name = "EntitiesName";
            this.EntitiesName.ReadOnly = true;
            // 
            // MemberNo
            // 
            this.MemberNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MemberNo.DataPropertyName = "MemberNo";
            this.MemberNo.FillWeight = 105.0416F;
            this.MemberNo.HeaderText = "Member#";
            this.MemberNo.Name = "MemberNo";
            this.MemberNo.ReadOnly = true;
            this.MemberNo.Width = 77;
            // 
            // MemberSinceDate
            // 
            this.MemberSinceDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MemberSinceDate.DataPropertyName = "MemberSinceDate";
            dataGridViewCellStyle9.Format = "dd-MM-yyyy";
            this.MemberSinceDate.DefaultCellStyle = dataGridViewCellStyle9;
            this.MemberSinceDate.FillWeight = 70.82032F;
            this.MemberSinceDate.HeaderText = "Member Since";
            this.MemberSinceDate.Name = "MemberSinceDate";
            this.MemberSinceDate.ReadOnly = true;
            // 
            // PrimaryAddress
            // 
            this.PrimaryAddress.DataPropertyName = "PrimaryAddress";
            this.PrimaryAddress.HeaderText = "Address";
            this.PrimaryAddress.Name = "PrimaryAddress";
            this.PrimaryAddress.ReadOnly = true;
            this.PrimaryAddress.Visible = false;
            // 
            // PrimaryPhoneNo
            // 
            this.PrimaryPhoneNo.DataPropertyName = "PrimaryPhoneNo";
            this.PrimaryPhoneNo.HeaderText = "Phone No";
            this.PrimaryPhoneNo.Name = "PrimaryPhoneNo";
            this.PrimaryPhoneNo.ReadOnly = true;
            this.PrimaryPhoneNo.Visible = false;
            // 
            // txtLabelTop10
            // 
            this.txtLabelTop10.BackColor = System.Drawing.Color.SteelBlue;
            this.txtLabelTop10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLabelTop10.Enabled = false;
            this.txtLabelTop10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabelTop10.ForeColor = System.Drawing.Color.White;
            this.txtLabelTop10.Location = new System.Drawing.Point(306, 211);
            this.txtLabelTop10.Margin = new System.Windows.Forms.Padding(0);
            this.txtLabelTop10.Name = "txtLabelTop10";
            this.txtLabelTop10.Size = new System.Drawing.Size(258, 20);
            this.txtLabelTop10.TabIndex = 17;
            this.txtLabelTop10.TabStop = false;
            this.txtLabelTop10.Text = "Top 10 Last Transaction(s)";
            this.txtLabelTop10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DataCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 453);
            this.ControlBox = false;
            this.Controls.Add(this.txtLabelTop10);
            this.Controls.Add(this.txtPhoneNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEntitiesName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grdEntities);
            this.Controls.Add(this.grdLastTransaction);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSeacrh);
            this.KeyPreview = true;
            this.Name = "DataCustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer Data";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DataCustomerForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.grdLastTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdLastTransaction;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSeacrh;
        private System.Windows.Forms.DataGridView grdEntities;
        private System.Windows.Forms.TextBox txtEntitiesName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalTransactionAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntitiesSeqNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntitiesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntitiesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberSinceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrimaryAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrimaryPhoneNo;
        private System.Windows.Forms.TextBox txtLabelTop10;
    }
}