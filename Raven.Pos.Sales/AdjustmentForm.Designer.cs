namespace Raven.Pos.Sales
{
    partial class AdjustmentForm
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
            this.lblSearchIDNameCaption = new System.Windows.Forms.Label();
            this.txtTxnNo = new System.Windows.Forms.TextBox();
            this.lblDonationType = new System.Windows.Forms.Label();
            this.cboTxnType = new System.Windows.Forms.ComboBox();
            this.lblSettlementDateCaption = new System.Windows.Forms.Label();
            this.dtpTxnDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboWarehouse = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboReason = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtItemSeqNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtItemFactor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboItemUnit = new System.Windows.Forms.ComboBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.grdItem = new System.Windows.Forms.DataGridView();
            this.btnApprove = new System.Windows.Forms.Button();
            this.lblApproved = new System.Windows.Forms.Label();
            this.pnlFunctionKeys = new System.Windows.Forms.Panel();
            this.txtF4 = new System.Windows.Forms.TextBox();
            this.txtF3 = new System.Windows.Forms.TextBox();
            this.btnSearchItem = new System.Windows.Forms.Button();
            this.txtF5 = new System.Windows.Forms.TextBox();
            this.txtF2 = new System.Windows.Forms.TextBox();
            this.pnlRecordStatus = new System.Windows.Forms.Panel();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemFactor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemUnitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSeqNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtF6 = new System.Windows.Forms.TextBox();
            this.btnSearchSTxn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).BeginInit();
            this.pnlFunctionKeys.SuspendLayout();
            this.pnlRecordStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSearchIDNameCaption
            // 
            this.lblSearchIDNameCaption.AutoSize = true;
            this.lblSearchIDNameCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchIDNameCaption.Location = new System.Drawing.Point(12, 73);
            this.lblSearchIDNameCaption.Name = "lblSearchIDNameCaption";
            this.lblSearchIDNameCaption.Size = new System.Drawing.Size(109, 17);
            this.lblSearchIDNameCaption.TabIndex = 0;
            this.lblSearchIDNameCaption.Text = "Transaction No.";
            // 
            // txtTxnNo
            // 
            this.txtTxnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTxnNo.Location = new System.Drawing.Point(137, 70);
            this.txtTxnNo.MaxLength = 15;
            this.txtTxnNo.Name = "txtTxnNo";
            this.txtTxnNo.Size = new System.Drawing.Size(200, 23);
            this.txtTxnNo.TabIndex = 4;
            this.txtTxnNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTxnNo_KeyUp);
            this.txtTxnNo.Leave += new System.EventHandler(this.txtTxnNo_Leave);
            // 
            // lblDonationType
            // 
            this.lblDonationType.AutoSize = true;
            this.lblDonationType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonationType.Location = new System.Drawing.Point(12, 43);
            this.lblDonationType.Name = "lblDonationType";
            this.lblDonationType.Size = new System.Drawing.Size(119, 17);
            this.lblDonationType.TabIndex = 14;
            this.lblDonationType.Text = "Transaction Type";
            // 
            // cboTxnType
            // 
            this.cboTxnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTxnType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTxnType.FormattingEnabled = true;
            this.cboTxnType.Location = new System.Drawing.Point(137, 40);
            this.cboTxnType.Name = "cboTxnType";
            this.cboTxnType.Size = new System.Drawing.Size(200, 24);
            this.cboTxnType.TabIndex = 2;
            // 
            // lblSettlementDateCaption
            // 
            this.lblSettlementDateCaption.AutoSize = true;
            this.lblSettlementDateCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettlementDateCaption.Location = new System.Drawing.Point(12, 102);
            this.lblSettlementDateCaption.Name = "lblSettlementDateCaption";
            this.lblSettlementDateCaption.Size = new System.Drawing.Size(38, 17);
            this.lblSettlementDateCaption.TabIndex = 16;
            this.lblSettlementDateCaption.Text = "Date";
            this.lblSettlementDateCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpTxnDate
            // 
            this.dtpTxnDate.Checked = false;
            this.dtpTxnDate.CustomFormat = "dd-MM-yyyy";
            this.dtpTxnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTxnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTxnDate.Location = new System.Drawing.Point(137, 98);
            this.dtpTxnDate.Name = "dtpTxnDate";
            this.dtpTxnDate.Size = new System.Drawing.Size(200, 23);
            this.dtpTxnDate.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(343, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Unit";
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.Enabled = false;
            this.cboUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(456, 70);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(213, 24);
            this.cboUnit.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(343, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Warehouse";
            // 
            // cboWarehouse
            // 
            this.cboWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWarehouse.Enabled = false;
            this.cboWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWarehouse.FormattingEnabled = true;
            this.cboWarehouse.Location = new System.Drawing.Point(456, 40);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Size = new System.Drawing.Size(213, 24);
            this.cboWarehouse.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Reason";
            // 
            // cboReason
            // 
            this.cboReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReason.FormattingEnabled = true;
            this.cboReason.Location = new System.Drawing.Point(137, 127);
            this.cboReason.Name = "cboReason";
            this.cboReason.Size = new System.Drawing.Size(200, 24);
            this.cboReason.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtItemSeqNo);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtQty);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtItemFactor);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboItemUnit);
            this.panel1.Controls.Add(this.txtItemName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtItemID);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(15, 157);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 129);
            this.panel1.TabIndex = 9;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(172, 96);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(73, 26);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 96);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 26);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(92, 96);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(73, 26);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(443, 93);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(197, 23);
            this.txtID.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(333, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 17);
            this.label11.TabIndex = 31;
            this.label11.Text = "ID";
            // 
            // txtItemSeqNo
            // 
            this.txtItemSeqNo.Enabled = false;
            this.txtItemSeqNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSeqNo.Location = new System.Drawing.Point(443, 64);
            this.txtItemSeqNo.Name = "txtItemSeqNo";
            this.txtItemSeqNo.ReadOnly = true;
            this.txtItemSeqNo.Size = new System.Drawing.Size(197, 23);
            this.txtItemSeqNo.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(333, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 17);
            this.label9.TabIndex = 29;
            this.label9.Text = "Item Seq No";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(443, 35);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(197, 23);
            this.txtQty.TabIndex = 14;
            this.txtQty.Text = "1.00";
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(333, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 17);
            this.label8.TabIndex = 27;
            this.label8.Text = "Qty";
            // 
            // txtItemFactor
            // 
            this.txtItemFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemFactor.Location = new System.Drawing.Point(443, 6);
            this.txtItemFactor.Name = "txtItemFactor";
            this.txtItemFactor.Size = new System.Drawing.Size(197, 23);
            this.txtItemFactor.TabIndex = 13;
            this.txtItemFactor.Text = "1.00";
            this.txtItemFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemFactor_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(333, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "Item Factor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "Item Unit";
            // 
            // cboItemUnit
            // 
            this.cboItemUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItemUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItemUnit.FormattingEnabled = true;
            this.cboItemUnit.Location = new System.Drawing.Point(124, 64);
            this.cboItemUnit.Name = "cboItemUnit";
            this.cboItemUnit.Size = new System.Drawing.Size(200, 24);
            this.cboItemUnit.TabIndex = 12;
            this.cboItemUnit.SelectedIndexChanged += new System.EventHandler(this.cboItemUnit_SelectedIndexChanged);
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(124, 35);
            this.txtItemName.MaxLength = 500;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(200, 23);
            this.txtItemName.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Item Name";
            // 
            // txtItemID
            // 
            this.txtItemID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemID.Location = new System.Drawing.Point(124, 6);
            this.txtItemID.MaxLength = 15;
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(200, 23);
            this.txtItemID.TabIndex = 10;
            this.txtItemID.Leave += new System.EventHandler(this.txtItemID_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Item ID";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(456, 100);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(213, 51);
            this.txtDescription.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(343, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "Description";
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(257, 26);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 48);
            this.btnClearAll.TabIndex = 21;
            this.btnClearAll.Text = "New Transaction";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(338, 26);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(75, 48);
            this.btnDeleteAll.TabIndex = 22;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // grdItem
            // 
            this.grdItem.AllowUserToAddRows = false;
            this.grdItem.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grdItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grdItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdItem.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grdItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ItemSeqNo,
            this.ItemID,
            this.ItemName,
            this.ItemUnitID,
            this.ItemFactor,
            this.Qty});
            this.grdItem.Location = new System.Drawing.Point(15, 292);
            this.grdItem.Name = "grdItem";
            this.grdItem.RowHeadersWidth = 25;
            this.grdItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdItem.Size = new System.Drawing.Size(654, 152);
            this.grdItem.TabIndex = 20;
            this.grdItem.DoubleClick += new System.EventHandler(this.grdItem_DoubleClick);
            this.grdItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdItem_KeyDown);
            this.grdItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdItem_KeyUp);
            // 
            // btnApprove
            // 
            this.btnApprove.Enabled = false;
            this.btnApprove.Location = new System.Drawing.Point(14, 26);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(75, 48);
            this.btnApprove.TabIndex = 25;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // lblApproved
            // 
            this.lblApproved.AutoSize = true;
            this.lblApproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApproved.ForeColor = System.Drawing.Color.White;
            this.lblApproved.Location = new System.Drawing.Point(302, 3);
            this.lblApproved.Name = "lblApproved";
            this.lblApproved.Size = new System.Drawing.Size(77, 20);
            this.lblApproved.TabIndex = 27;
            this.lblApproved.Text = "Approved";
            this.lblApproved.Visible = false;
            // 
            // pnlFunctionKeys
            // 
            this.pnlFunctionKeys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFunctionKeys.Controls.Add(this.btnSearchSTxn);
            this.pnlFunctionKeys.Controls.Add(this.txtF6);
            this.pnlFunctionKeys.Controls.Add(this.txtF4);
            this.pnlFunctionKeys.Controls.Add(this.txtF3);
            this.pnlFunctionKeys.Controls.Add(this.btnSearchItem);
            this.pnlFunctionKeys.Controls.Add(this.txtF5);
            this.pnlFunctionKeys.Controls.Add(this.txtF2);
            this.pnlFunctionKeys.Controls.Add(this.btnClearAll);
            this.pnlFunctionKeys.Controls.Add(this.btnDeleteAll);
            this.pnlFunctionKeys.Controls.Add(this.btnApprove);
            this.pnlFunctionKeys.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFunctionKeys.Location = new System.Drawing.Point(0, 457);
            this.pnlFunctionKeys.Margin = new System.Windows.Forms.Padding(5);
            this.pnlFunctionKeys.Name = "pnlFunctionKeys";
            this.pnlFunctionKeys.Size = new System.Drawing.Size(681, 79);
            this.pnlFunctionKeys.TabIndex = 28;
            // 
            // txtF4
            // 
            this.txtF4.BackColor = System.Drawing.Color.SteelBlue;
            this.txtF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF4.ForeColor = System.Drawing.Color.White;
            this.txtF4.Location = new System.Drawing.Point(176, 3);
            this.txtF4.Name = "txtF4";
            this.txtF4.ReadOnly = true;
            this.txtF4.Size = new System.Drawing.Size(75, 23);
            this.txtF4.TabIndex = 31;
            this.txtF4.TabStop = false;
            this.txtF4.Text = "F4";
            this.txtF4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtF3
            // 
            this.txtF3.BackColor = System.Drawing.Color.SteelBlue;
            this.txtF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF3.ForeColor = System.Drawing.Color.White;
            this.txtF3.Location = new System.Drawing.Point(95, 3);
            this.txtF3.Name = "txtF3";
            this.txtF3.ReadOnly = true;
            this.txtF3.Size = new System.Drawing.Size(75, 23);
            this.txtF3.TabIndex = 29;
            this.txtF3.TabStop = false;
            this.txtF3.Text = "F3";
            this.txtF3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSearchItem
            // 
            this.btnSearchItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchItem.Location = new System.Drawing.Point(95, 26);
            this.btnSearchItem.Name = "btnSearchItem";
            this.btnSearchItem.Size = new System.Drawing.Size(75, 48);
            this.btnSearchItem.TabIndex = 30;
            this.btnSearchItem.TabStop = false;
            this.btnSearchItem.Text = "Search Item";
            this.btnSearchItem.UseVisualStyleBackColor = true;
            // 
            // txtF5
            // 
            this.txtF5.BackColor = System.Drawing.Color.SteelBlue;
            this.txtF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF5.ForeColor = System.Drawing.Color.White;
            this.txtF5.Location = new System.Drawing.Point(257, 3);
            this.txtF5.Name = "txtF5";
            this.txtF5.ReadOnly = true;
            this.txtF5.Size = new System.Drawing.Size(75, 23);
            this.txtF5.TabIndex = 27;
            this.txtF5.TabStop = false;
            this.txtF5.Text = "F5";
            this.txtF5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtF2
            // 
            this.txtF2.BackColor = System.Drawing.Color.SteelBlue;
            this.txtF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF2.ForeColor = System.Drawing.Color.White;
            this.txtF2.Location = new System.Drawing.Point(14, 3);
            this.txtF2.Name = "txtF2";
            this.txtF2.ReadOnly = true;
            this.txtF2.Size = new System.Drawing.Size(75, 23);
            this.txtF2.TabIndex = 26;
            this.txtF2.TabStop = false;
            this.txtF2.Text = "F2";
            this.txtF2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlRecordStatus
            // 
            this.pnlRecordStatus.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlRecordStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRecordStatus.Controls.Add(this.lblApproved);
            this.pnlRecordStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRecordStatus.Location = new System.Drawing.Point(0, 0);
            this.pnlRecordStatus.Name = "pnlRecordStatus";
            this.pnlRecordStatus.Size = new System.Drawing.Size(681, 27);
            this.pnlRecordStatus.TabIndex = 29;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // ItemFactor
            // 
            this.ItemFactor.DataPropertyName = "ItemFactor";
            this.ItemFactor.HeaderText = "Item Factor";
            this.ItemFactor.Name = "ItemFactor";
            this.ItemFactor.ReadOnly = true;
            // 
            // ItemUnitID
            // 
            this.ItemUnitID.DataPropertyName = "ItemUnitID";
            this.ItemUnitID.HeaderText = "Item Unit ID";
            this.ItemUnitID.Name = "ItemUnitID";
            this.ItemUnitID.ReadOnly = true;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // ItemID
            // 
            this.ItemID.DataPropertyName = "ItemID";
            this.ItemID.HeaderText = "Item ID";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            // 
            // ItemSeqNo
            // 
            this.ItemSeqNo.DataPropertyName = "ItemSeqNo";
            this.ItemSeqNo.HeaderText = "Item Seq No";
            this.ItemSeqNo.Name = "ItemSeqNo";
            this.ItemSeqNo.ReadOnly = true;
            this.ItemSeqNo.Visible = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // txtF6
            // 
            this.txtF6.BackColor = System.Drawing.Color.SteelBlue;
            this.txtF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF6.ForeColor = System.Drawing.Color.White;
            this.txtF6.Location = new System.Drawing.Point(338, 3);
            this.txtF6.Name = "txtF6";
            this.txtF6.ReadOnly = true;
            this.txtF6.Size = new System.Drawing.Size(75, 23);
            this.txtF6.TabIndex = 32;
            this.txtF6.TabStop = false;
            this.txtF6.Text = "F6";
            this.txtF6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSearchSTxn
            // 
            this.btnSearchSTxn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSTxn.Location = new System.Drawing.Point(176, 26);
            this.btnSearchSTxn.Name = "btnSearchSTxn";
            this.btnSearchSTxn.Size = new System.Drawing.Size(75, 48);
            this.btnSearchSTxn.TabIndex = 33;
            this.btnSearchSTxn.TabStop = false;
            this.btnSearchSTxn.Text = "Search Transaction";
            this.btnSearchSTxn.UseVisualStyleBackColor = true;
            // 
            // AdjustmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 536);
            this.ControlBox = false;
            this.Controls.Add(this.pnlRecordStatus);
            this.Controls.Add(this.pnlFunctionKeys);
            this.Controls.Add(this.grdItem);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboReason);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboWarehouse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboUnit);
            this.Controls.Add(this.lblSettlementDateCaption);
            this.Controls.Add(this.dtpTxnDate);
            this.Controls.Add(this.lblDonationType);
            this.Controls.Add(this.cboTxnType);
            this.Controls.Add(this.txtTxnNo);
            this.Controls.Add(this.lblSearchIDNameCaption);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdjustmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adjustment Item";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AdjustmentForm_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).EndInit();
            this.pnlFunctionKeys.ResumeLayout(false);
            this.pnlFunctionKeys.PerformLayout();
            this.pnlRecordStatus.ResumeLayout(false);
            this.pnlRecordStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearchIDNameCaption;
        private System.Windows.Forms.TextBox txtTxnNo;
        private System.Windows.Forms.Label lblDonationType;
        private System.Windows.Forms.ComboBox cboTxnType;
        private System.Windows.Forms.Label lblSettlementDateCaption;
        private System.Windows.Forms.DateTimePicker dtpTxnDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboWarehouse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboReason;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtItemSeqNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtItemFactor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboItemUnit;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView grdItem;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Label lblApproved;
        private System.Windows.Forms.Panel pnlFunctionKeys;
        private System.Windows.Forms.Panel pnlRecordStatus;
        private System.Windows.Forms.TextBox txtF2;
        private System.Windows.Forms.TextBox txtF3;
        private System.Windows.Forms.Button btnSearchItem;
        private System.Windows.Forms.TextBox txtF5;
        private System.Windows.Forms.TextBox txtF4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSeqNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemUnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemFactor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.TextBox txtF6;
        private System.Windows.Forms.Button btnSearchSTxn;
    }
}