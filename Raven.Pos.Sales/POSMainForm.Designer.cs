namespace Raven.Pos.Sales
{
    partial class POSMainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POSMainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdItem = new System.Windows.Forms.DataGridView();
            this.colItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemFactor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscountAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlApplicationHeader = new System.Windows.Forms.Panel();
            this.lblSystemCurrentTime = new System.Windows.Forms.Label();
            this.lblCashierName = new System.Windows.Forms.Label();
            this.lblSystemCurrentDate = new System.Windows.Forms.Label();
            this.lblCashierID = new System.Windows.Forms.Label();
            this.lblBranch = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.pnlSTxn = new System.Windows.Forms.Panel();
            this.txtCurrencyRate = new System.Windows.Forms.TextBox();
            this.lblSTxnCurrencyCaption = new System.Windows.Forms.Label();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.lblSTxnDateCaption = new System.Windows.Forms.Label();
            this.txtSTxnNo = new System.Windows.Forms.TextBox();
            this.lblSTxnNoCaption = new System.Windows.Forms.Label();
            this.txtSTxnDate = new System.Windows.Forms.TextBox();
            this.pnlInputData = new System.Windows.Forms.Panel();
            this.lblUnitDisc2 = new System.Windows.Forms.Label();
            this.lblUnitDisc1 = new System.Windows.Forms.Label();
            this.lblUnitDisc = new System.Windows.Forms.Label();
            this.lblUnitDiscCaption = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.lblUnitPriceCaption = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemUnitID = new System.Windows.Forms.TextBox();
            this.lblItemFactorCaption = new System.Windows.Forms.Label();
            this.txtItemFactor = new System.Windows.Forms.TextBox();
            this.txtToggleOperator = new System.Windows.Forms.TextBox();
            this.lblItems = new System.Windows.Forms.Label();
            this.lblQtyCaption = new System.Windows.Forms.Label();
            this.lblLinesCaption = new System.Windows.Forms.Label();
            this.lblItemsCaption = new System.Windows.Forms.Label();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.lblLines = new System.Windows.Forms.Label();
            this.lblItemUnitCaption = new System.Windows.Forms.Label();
            this.cboItemUnit = new System.Windows.Forms.ComboBox();
            this.lblGrandTotalCaption = new System.Windows.Forms.Label();
            this.lblItemIDCaption = new System.Windows.Forms.Label();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.lblDiscountTotalCaption = new System.Windows.Forms.Label();
            this.lblGrossTotalCaption = new System.Windows.Forms.Label();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.txtDiscountTotal = new System.Windows.Forms.TextBox();
            this.txtGrossTotal = new System.Windows.Forms.TextBox();
            this.pnlFunctionKeys = new System.Windows.Forms.Panel();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.txtF11 = new System.Windows.Forms.TextBox();
            this.txtF7 = new System.Windows.Forms.TextBox();
            this.btnItemCancel = new System.Windows.Forms.Button();
            this.txtF6 = new System.Windows.Forms.TextBox();
            this.btnMemberIDInput = new System.Windows.Forms.Button();
            this.txtF12 = new System.Windows.Forms.TextBox();
            this.btnOtherFunction = new System.Windows.Forms.Button();
            this.btnLowerQty = new System.Windows.Forms.Button();
            this.txtRaiseLowerQtyCaption = new System.Windows.Forms.TextBox();
            this.btnRaiseQty = new System.Windows.Forms.Button();
            this.txtF9 = new System.Windows.Forms.TextBox();
            this.btnQtyInput = new System.Windows.Forms.Button();
            this.txtF8 = new System.Windows.Forms.TextBox();
            this.btnToggleItemUnit = new System.Windows.Forms.Button();
            this.txtF10 = new System.Windows.Forms.TextBox();
            this.txtF5 = new System.Windows.Forms.TextBox();
            this.txtF4 = new System.Windows.Forms.TextBox();
            this.txtF3 = new System.Windows.Forms.TextBox();
            this.txtF2 = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnNewSTxn = new System.Windows.Forms.Button();
            this.btnSearchSTxn = new System.Windows.Forms.Button();
            this.btnSearchItem = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.pnlStatusInfo = new System.Windows.Forms.Panel();
            this.lblSystemInfo = new System.Windows.Forms.Label();
            this.lblSelectedFunction = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pnlItemName = new System.Windows.Forms.Panel();
            this.lblItemName = new System.Windows.Forms.Label();
            this.pnlLastSTxnInfo = new System.Windows.Forms.Panel();
            this.lblLastChange = new System.Windows.Forms.Label();
            this.lblLastChangeCaption = new System.Windows.Forms.Label();
            this.lblLastPayment = new System.Windows.Forms.Label();
            this.lblLastPaymentCaption = new System.Windows.Forms.Label();
            this.lblLastRounding = new System.Windows.Forms.Label();
            this.lblLastRoundingCaption = new System.Windows.Forms.Label();
            this.lblLastGrandTotal = new System.Windows.Forms.Label();
            this.lblLastGrandTotalCaption = new System.Windows.Forms.Label();
            this.lblLastSTxnNo = new System.Windows.Forms.Label();
            this.lblLastSTxnNoCaption = new System.Windows.Forms.Label();
            this.pnlMember = new System.Windows.Forms.Panel();
            this.lblEntitiesSeqNo = new System.Windows.Forms.Label();
            this.lblSTxnStatus = new System.Windows.Forms.Label();
            this.cboSTxnStatusID = new System.Windows.Forms.ComboBox();
            this.lbltranstype = new System.Windows.Forms.Label();
            this.cbotranstype = new System.Windows.Forms.ComboBox();
            this.lblUnitID = new System.Windows.Forms.Label();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.lblWhID = new System.Windows.Forms.Label();
            this.cboWh = new System.Windows.Forms.ComboBox();
            this.lblValidThruDate = new System.Windows.Forms.Label();
            this.lblValidThruCaption = new System.Windows.Forms.Label();
            this.lblMemberSinceDate = new System.Windows.Forms.Label();
            this.lblMemberSinceCaption = new System.Windows.Forms.Label();
            this.lblMemberName = new System.Windows.Forms.Label();
            this.txtMemberID = new System.Windows.Forms.TextBox();
            this.lblMemberIDCaption = new System.Windows.Forms.Label();
            this.pnlItemUnitPrice = new System.Windows.Forms.Panel();
            this.lblItemUnitPrice = new System.Windows.Forms.Label();
            this.timerSystemCurrentTime = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).BeginInit();
            this.pnlApplicationHeader.SuspendLayout();
            this.pnlSTxn.SuspendLayout();
            this.pnlInputData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
            this.pnlFunctionKeys.SuspendLayout();
            this.pnlStatusInfo.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlItemName.SuspendLayout();
            this.pnlLastSTxnInfo.SuspendLayout();
            this.pnlMember.SuspendLayout();
            this.pnlItemUnitPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.63636F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tableLayoutPanel1.Controls.Add(this.grdItem, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.pnlApplicationHeader, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlSTxn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlInputData, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.pnlFunctionKeys, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.pnlStatusInfo, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.pnlLogo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlItemName, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.pnlLastSTxnInfo, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.pnlMember, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pnlItemUnitPrice, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 752);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grdItem
            // 
            this.grdItem.AllowUserToAddRows = false;
            this.grdItem.AllowUserToDeleteRows = false;
            this.grdItem.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grdItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdItem.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grdItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemID,
            this.colItemName,
            this.colQty,
            this.colItemUnit,
            this.colItemFactor,
            this.colItemUnitPrice,
            this.colDiscountAmt,
            this.colTotal});
            this.tableLayoutPanel1.SetColumnSpan(this.grdItem, 4);
            this.grdItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItem.Location = new System.Drawing.Point(3, 248);
            this.grdItem.Name = "grdItem";
            this.grdItem.ReadOnly = true;
            this.grdItem.RowHeadersWidth = 25;
            this.grdItem.Size = new System.Drawing.Size(1002, 246);
            this.grdItem.TabIndex = 100;
            this.grdItem.TabStop = false;
            // 
            // colItemID
            // 
            this.colItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colItemID.DataPropertyName = "ItemID";
            this.colItemID.HeaderText = "Item ID";
            this.colItemID.Name = "colItemID";
            this.colItemID.ReadOnly = true;
            this.colItemID.Width = 76;
            // 
            // colItemName
            // 
            this.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItemName.DataPropertyName = "ItemName";
            this.colItemName.HeaderText = "Item Name";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            // 
            // colQty
            // 
            this.colQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colQty.DataPropertyName = "Qty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.colQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQty.HeaderText = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            this.colQty.Width = 55;
            // 
            // colItemUnit
            // 
            this.colItemUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colItemUnit.DataPropertyName = "ItemUnitID";
            this.colItemUnit.HeaderText = "Item Unit";
            this.colItemUnit.Name = "colItemUnit";
            this.colItemUnit.ReadOnly = true;
            this.colItemUnit.Width = 88;
            // 
            // colItemFactor
            // 
            this.colItemFactor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colItemFactor.DataPropertyName = "ItemFactor";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle3.Format = "N2";
            this.colItemFactor.DefaultCellStyle = dataGridViewCellStyle3;
            this.colItemFactor.HeaderText = "Factor";
            this.colItemFactor.Name = "colItemFactor";
            this.colItemFactor.ReadOnly = true;
            this.colItemFactor.Width = 73;
            // 
            // colItemUnitPrice
            // 
            this.colItemUnitPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colItemUnitPrice.DataPropertyName = "Price";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.colItemUnitPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.colItemUnitPrice.HeaderText = "Unit Price";
            this.colItemUnitPrice.Name = "colItemUnitPrice";
            this.colItemUnitPrice.ReadOnly = true;
            this.colItemUnitPrice.Width = 94;
            // 
            // colDiscountAmt
            // 
            this.colDiscountAmt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDiscountAmt.DataPropertyName = "DiscountTotal";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.colDiscountAmt.DefaultCellStyle = dataGridViewCellStyle5;
            this.colDiscountAmt.FillWeight = 110F;
            this.colDiscountAmt.HeaderText = "Discount Amt";
            this.colDiscountAmt.Name = "colDiscountAmt";
            this.colDiscountAmt.ReadOnly = true;
            this.colDiscountAmt.Width = 116;
            // 
            // colTotal
            // 
            this.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTotal.DataPropertyName = "GrossTotal";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 65;
            // 
            // pnlApplicationHeader
            // 
            this.pnlApplicationHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlApplicationHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.pnlApplicationHeader, 3);
            this.pnlApplicationHeader.Controls.Add(this.lblSystemCurrentTime);
            this.pnlApplicationHeader.Controls.Add(this.lblCashierName);
            this.pnlApplicationHeader.Controls.Add(this.lblSystemCurrentDate);
            this.pnlApplicationHeader.Controls.Add(this.lblCashierID);
            this.pnlApplicationHeader.Controls.Add(this.lblBranch);
            this.pnlApplicationHeader.Controls.Add(this.lblCompanyName);
            this.pnlApplicationHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlApplicationHeader.Location = new System.Drawing.Point(200, 0);
            this.pnlApplicationHeader.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlApplicationHeader.Name = "pnlApplicationHeader";
            this.pnlApplicationHeader.Size = new System.Drawing.Size(808, 62);
            this.pnlApplicationHeader.TabIndex = 2;
            // 
            // lblSystemCurrentTime
            // 
            this.lblSystemCurrentTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSystemCurrentTime.AutoSize = true;
            this.lblSystemCurrentTime.ForeColor = System.Drawing.Color.White;
            this.lblSystemCurrentTime.Location = new System.Drawing.Point(654, 33);
            this.lblSystemCurrentTime.Name = "lblSystemCurrentTime";
            this.lblSystemCurrentTime.Size = new System.Drawing.Size(140, 17);
            this.lblSystemCurrentTime.TabIndex = 1;
            this.lblSystemCurrentTime.Text = "System Current Time";
            this.lblSystemCurrentTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCashierName
            // 
            this.lblCashierName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCashierName.AutoSize = true;
            this.lblCashierName.ForeColor = System.Drawing.Color.White;
            this.lblCashierName.Location = new System.Drawing.Point(373, 33);
            this.lblCashierName.MaximumSize = new System.Drawing.Size(150, 0);
            this.lblCashierName.Name = "lblCashierName";
            this.lblCashierName.Size = new System.Drawing.Size(97, 17);
            this.lblCashierName.TabIndex = 3;
            this.lblCashierName.Text = "Cashier Name";
            // 
            // lblSystemCurrentDate
            // 
            this.lblSystemCurrentDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSystemCurrentDate.AutoSize = true;
            this.lblSystemCurrentDate.ForeColor = System.Drawing.Color.White;
            this.lblSystemCurrentDate.Location = new System.Drawing.Point(655, 14);
            this.lblSystemCurrentDate.Name = "lblSystemCurrentDate";
            this.lblSystemCurrentDate.Size = new System.Drawing.Size(139, 17);
            this.lblSystemCurrentDate.TabIndex = 0;
            this.lblSystemCurrentDate.Text = "System Current Date";
            this.lblSystemCurrentDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCashierID
            // 
            this.lblCashierID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCashierID.AutoSize = true;
            this.lblCashierID.ForeColor = System.Drawing.Color.White;
            this.lblCashierID.Location = new System.Drawing.Point(373, 14);
            this.lblCashierID.MaximumSize = new System.Drawing.Size(100, 0);
            this.lblCashierID.Name = "lblCashierID";
            this.lblCashierID.Size = new System.Drawing.Size(73, 17);
            this.lblCashierID.TabIndex = 2;
            this.lblCashierID.Text = "Cashier ID";
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.ForeColor = System.Drawing.Color.White;
            this.lblBranch.Location = new System.Drawing.Point(20, 33);
            this.lblBranch.MaximumSize = new System.Drawing.Size(200, 0);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(53, 17);
            this.lblBranch.TabIndex = 1;
            this.lblBranch.Text = "Branch";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.White;
            this.lblCompanyName.Location = new System.Drawing.Point(20, 14);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(120, 17);
            this.lblCompanyName.TabIndex = 0;
            this.lblCompanyName.Text = "Company Name";
            // 
            // pnlSTxn
            // 
            this.pnlSTxn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.pnlSTxn, 4);
            this.pnlSTxn.Controls.Add(this.txtCurrencyRate);
            this.pnlSTxn.Controls.Add(this.lblSTxnCurrencyCaption);
            this.pnlSTxn.Controls.Add(this.cboCurrency);
            this.pnlSTxn.Controls.Add(this.lblSTxnDateCaption);
            this.pnlSTxn.Controls.Add(this.txtSTxnNo);
            this.pnlSTxn.Controls.Add(this.lblSTxnNoCaption);
            this.pnlSTxn.Controls.Add(this.txtSTxnDate);
            this.pnlSTxn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSTxn.Location = new System.Drawing.Point(3, 68);
            this.pnlSTxn.Name = "pnlSTxn";
            this.pnlSTxn.Size = new System.Drawing.Size(1002, 34);
            this.pnlSTxn.TabIndex = 4;
            // 
            // txtCurrencyRate
            // 
            this.txtCurrencyRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrencyRate.Enabled = false;
            this.txtCurrencyRate.Location = new System.Drawing.Point(937, 5);
            this.txtCurrencyRate.Name = "txtCurrencyRate";
            this.txtCurrencyRate.Size = new System.Drawing.Size(51, 23);
            this.txtCurrencyRate.TabIndex = 34;
            this.txtCurrencyRate.TabStop = false;
            this.txtCurrencyRate.Visible = false;
            // 
            // lblSTxnCurrencyCaption
            // 
            this.lblSTxnCurrencyCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSTxnCurrencyCaption.AutoSize = true;
            this.lblSTxnCurrencyCaption.Location = new System.Drawing.Point(694, 8);
            this.lblSTxnCurrencyCaption.Name = "lblSTxnCurrencyCaption";
            this.lblSTxnCurrencyCaption.Size = new System.Drawing.Size(65, 17);
            this.lblSTxnCurrencyCaption.TabIndex = 33;
            this.lblSTxnCurrencyCaption.Text = "Currency";
            this.lblSTxnCurrencyCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblSTxnCurrencyCaption.Visible = false;
            // 
            // cboCurrency
            // 
            this.cboCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCurrency.BackColor = System.Drawing.SystemColors.Window;
            this.cboCurrency.Enabled = false;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Location = new System.Drawing.Point(763, 4);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(168, 24);
            this.cboCurrency.TabIndex = 32;
            this.cboCurrency.TabStop = false;
            this.cboCurrency.Visible = false;
            // 
            // lblSTxnDateCaption
            // 
            this.lblSTxnDateCaption.AutoSize = true;
            this.lblSTxnDateCaption.Location = new System.Drawing.Point(400, 9);
            this.lblSTxnDateCaption.Name = "lblSTxnDateCaption";
            this.lblSTxnDateCaption.Size = new System.Drawing.Size(117, 17);
            this.lblSTxnDateCaption.TabIndex = 12;
            this.lblSTxnDateCaption.Text = "Transaction Date";
            this.lblSTxnDateCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtSTxnNo
            // 
            this.txtSTxnNo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtSTxnNo.Location = new System.Drawing.Point(123, 6);
            this.txtSTxnNo.Name = "txtSTxnNo";
            this.txtSTxnNo.ReadOnly = true;
            this.txtSTxnNo.Size = new System.Drawing.Size(188, 23);
            this.txtSTxnNo.TabIndex = 30;
            this.txtSTxnNo.TabStop = false;
            // 
            // lblSTxnNoCaption
            // 
            this.lblSTxnNoCaption.AutoSize = true;
            this.lblSTxnNoCaption.Location = new System.Drawing.Point(8, 9);
            this.lblSTxnNoCaption.Name = "lblSTxnNoCaption";
            this.lblSTxnNoCaption.Size = new System.Drawing.Size(109, 17);
            this.lblSTxnNoCaption.TabIndex = 1;
            this.lblSTxnNoCaption.Text = "Transaction No.";
            this.lblSTxnNoCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtSTxnDate
            // 
            this.txtSTxnDate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtSTxnDate.Location = new System.Drawing.Point(523, 6);
            this.txtSTxnDate.Name = "txtSTxnDate";
            this.txtSTxnDate.ReadOnly = true;
            this.txtSTxnDate.Size = new System.Drawing.Size(154, 23);
            this.txtSTxnDate.TabIndex = 31;
            this.txtSTxnDate.TabStop = false;
            // 
            // pnlInputData
            // 
            this.pnlInputData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.pnlInputData, 4);
            this.pnlInputData.Controls.Add(this.lblUnitDisc2);
            this.pnlInputData.Controls.Add(this.lblUnitDisc1);
            this.pnlInputData.Controls.Add(this.lblUnitDisc);
            this.pnlInputData.Controls.Add(this.lblUnitDiscCaption);
            this.pnlInputData.Controls.Add(this.lblUnitPrice);
            this.pnlInputData.Controls.Add(this.lblUnitPriceCaption);
            this.pnlInputData.Controls.Add(this.label1);
            this.pnlInputData.Controls.Add(this.txtItemUnitID);
            this.pnlInputData.Controls.Add(this.lblItemFactorCaption);
            this.pnlInputData.Controls.Add(this.txtItemFactor);
            this.pnlInputData.Controls.Add(this.txtToggleOperator);
            this.pnlInputData.Controls.Add(this.lblItems);
            this.pnlInputData.Controls.Add(this.lblQtyCaption);
            this.pnlInputData.Controls.Add(this.lblLinesCaption);
            this.pnlInputData.Controls.Add(this.lblItemsCaption);
            this.pnlInputData.Controls.Add(this.numQty);
            this.pnlInputData.Controls.Add(this.lblLines);
            this.pnlInputData.Controls.Add(this.lblItemUnitCaption);
            this.pnlInputData.Controls.Add(this.cboItemUnit);
            this.pnlInputData.Controls.Add(this.lblGrandTotalCaption);
            this.pnlInputData.Controls.Add(this.lblItemIDCaption);
            this.pnlInputData.Controls.Add(this.txtItemID);
            this.pnlInputData.Controls.Add(this.lblDiscountTotalCaption);
            this.pnlInputData.Controls.Add(this.lblGrossTotalCaption);
            this.pnlInputData.Controls.Add(this.txtGrandTotal);
            this.pnlInputData.Controls.Add(this.txtDiscountTotal);
            this.pnlInputData.Controls.Add(this.txtGrossTotal);
            this.pnlInputData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInputData.Location = new System.Drawing.Point(3, 500);
            this.pnlInputData.Name = "pnlInputData";
            this.pnlInputData.Size = new System.Drawing.Size(1002, 94);
            this.pnlInputData.TabIndex = 5;
            // 
            // lblUnitDisc2
            // 
            this.lblUnitDisc2.AutoSize = true;
            this.lblUnitDisc2.ForeColor = System.Drawing.Color.Silver;
            this.lblUnitDisc2.Location = new System.Drawing.Point(626, 71);
            this.lblUnitDisc2.Name = "lblUnitDisc2";
            this.lblUnitDisc2.Size = new System.Drawing.Size(43, 17);
            this.lblUnitDisc2.TabIndex = 26;
            this.lblUnitDisc2.Text = "Disc2";
            this.lblUnitDisc2.Visible = false;
            // 
            // lblUnitDisc1
            // 
            this.lblUnitDisc1.AutoSize = true;
            this.lblUnitDisc1.ForeColor = System.Drawing.Color.Silver;
            this.lblUnitDisc1.Location = new System.Drawing.Point(626, 54);
            this.lblUnitDisc1.Name = "lblUnitDisc1";
            this.lblUnitDisc1.Size = new System.Drawing.Size(43, 17);
            this.lblUnitDisc1.TabIndex = 25;
            this.lblUnitDisc1.Text = "Disc1";
            this.lblUnitDisc1.Visible = false;
            // 
            // lblUnitDisc
            // 
            this.lblUnitDisc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnitDisc.AutoSize = true;
            this.lblUnitDisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitDisc.ForeColor = System.Drawing.Color.Silver;
            this.lblUnitDisc.Location = new System.Drawing.Point(641, 39);
            this.lblUnitDisc.Name = "lblUnitDisc";
            this.lblUnitDisc.Size = new System.Drawing.Size(31, 15);
            this.lblUnitDisc.TabIndex = 24;
            this.lblUnitDisc.Text = "0.00";
            this.lblUnitDisc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUnitDiscCaption
            // 
            this.lblUnitDiscCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnitDiscCaption.AutoSize = true;
            this.lblUnitDiscCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitDiscCaption.ForeColor = System.Drawing.Color.Silver;
            this.lblUnitDiscCaption.Location = new System.Drawing.Point(512, 38);
            this.lblUnitDiscCaption.Name = "lblUnitDiscCaption";
            this.lblUnitDiscCaption.Size = new System.Drawing.Size(80, 15);
            this.lblUnitDiscCaption.TabIndex = 23;
            this.lblUnitDiscCaption.Text = "Unit Discount";
            this.lblUnitDiscCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitPrice.ForeColor = System.Drawing.Color.Silver;
            this.lblUnitPrice.Location = new System.Drawing.Point(641, 12);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(31, 15);
            this.lblUnitPrice.TabIndex = 22;
            this.lblUnitPrice.Text = "0.00";
            this.lblUnitPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUnitPriceCaption
            // 
            this.lblUnitPriceCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnitPriceCaption.AutoSize = true;
            this.lblUnitPriceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitPriceCaption.ForeColor = System.Drawing.Color.Silver;
            this.lblUnitPriceCaption.Location = new System.Drawing.Point(532, 12);
            this.lblUnitPriceCaption.Name = "lblUnitPriceCaption";
            this.lblUnitPriceCaption.Size = new System.Drawing.Size(60, 15);
            this.lblUnitPriceCaption.TabIndex = 21;
            this.lblUnitPriceCaption.Text = "Unit Price";
            this.lblUnitPriceCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(351, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Item Unit ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtItemUnitID
            // 
            this.txtItemUnitID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemUnitID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtItemUnitID.Enabled = false;
            this.txtItemUnitID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemUnitID.ForeColor = System.Drawing.Color.Silver;
            this.txtItemUnitID.Location = new System.Drawing.Point(425, 12);
            this.txtItemUnitID.Margin = new System.Windows.Forms.Padding(0);
            this.txtItemUnitID.Name = "txtItemUnitID";
            this.txtItemUnitID.ReadOnly = true;
            this.txtItemUnitID.Size = new System.Drawing.Size(58, 14);
            this.txtItemUnitID.TabIndex = 19;
            this.txtItemUnitID.TabStop = false;
            this.txtItemUnitID.Text = "-";
            // 
            // lblItemFactorCaption
            // 
            this.lblItemFactorCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemFactorCaption.AutoSize = true;
            this.lblItemFactorCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemFactorCaption.ForeColor = System.Drawing.Color.Silver;
            this.lblItemFactorCaption.Location = new System.Drawing.Point(354, 37);
            this.lblItemFactorCaption.Name = "lblItemFactorCaption";
            this.lblItemFactorCaption.Size = new System.Drawing.Size(68, 15);
            this.lblItemFactorCaption.TabIndex = 18;
            this.lblItemFactorCaption.Text = "Item Factor";
            this.lblItemFactorCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtItemFactor
            // 
            this.txtItemFactor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemFactor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtItemFactor.Enabled = false;
            this.txtItemFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemFactor.ForeColor = System.Drawing.Color.Silver;
            this.txtItemFactor.Location = new System.Drawing.Point(425, 38);
            this.txtItemFactor.Margin = new System.Windows.Forms.Padding(0);
            this.txtItemFactor.Name = "txtItemFactor";
            this.txtItemFactor.ReadOnly = true;
            this.txtItemFactor.Size = new System.Drawing.Size(58, 14);
            this.txtItemFactor.TabIndex = 17;
            this.txtItemFactor.TabStop = false;
            this.txtItemFactor.Text = "1.00";
            // 
            // txtToggleOperator
            // 
            this.txtToggleOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToggleOperator.Location = new System.Drawing.Point(317, 65);
            this.txtToggleOperator.Name = "txtToggleOperator";
            this.txtToggleOperator.ReadOnly = true;
            this.txtToggleOperator.Size = new System.Drawing.Size(26, 23);
            this.txtToggleOperator.TabIndex = 16;
            this.txtToggleOperator.TabStop = false;
            this.txtToggleOperator.Text = "+";
            this.txtToggleOperator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblItems
            // 
            this.lblItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItems.AutoSize = true;
            this.lblItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItems.Location = new System.Drawing.Point(574, 67);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(38, 15);
            this.lblItems.TabIndex = 15;
            this.lblItems.Text = "0.000";
            this.lblItems.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblQtyCaption
            // 
            this.lblQtyCaption.AutoSize = true;
            this.lblQtyCaption.Location = new System.Drawing.Point(87, 67);
            this.lblQtyCaption.Name = "lblQtyCaption";
            this.lblQtyCaption.Size = new System.Drawing.Size(30, 17);
            this.lblQtyCaption.TabIndex = 11;
            this.lblQtyCaption.Text = "Qty";
            this.lblQtyCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblLinesCaption
            // 
            this.lblLinesCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLinesCaption.AutoSize = true;
            this.lblLinesCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinesCaption.Location = new System.Drawing.Point(413, 67);
            this.lblLinesCaption.Name = "lblLinesCaption";
            this.lblLinesCaption.Size = new System.Drawing.Size(41, 15);
            this.lblLinesCaption.TabIndex = 12;
            this.lblLinesCaption.Text = "Line#:";
            this.lblLinesCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblItemsCaption
            // 
            this.lblItemsCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemsCaption.AutoSize = true;
            this.lblItemsCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemsCaption.Location = new System.Drawing.Point(528, 67);
            this.lblItemsCaption.Name = "lblItemsCaption";
            this.lblItemsCaption.Size = new System.Drawing.Size(41, 15);
            this.lblItemsCaption.TabIndex = 14;
            this.lblItemsCaption.Text = "Item#:";
            this.lblItemsCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numQty
            // 
            this.numQty.DecimalPlaces = 3;
            this.numQty.Location = new System.Drawing.Point(123, 65);
            this.numQty.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.numQty.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.numQty.Name = "numQty";
            this.numQty.Size = new System.Drawing.Size(188, 23);
            this.numQty.TabIndex = 2;
            this.numQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblLines
            // 
            this.lblLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLines.AutoSize = true;
            this.lblLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLines.Location = new System.Drawing.Point(459, 67);
            this.lblLines.Name = "lblLines";
            this.lblLines.Size = new System.Drawing.Size(14, 15);
            this.lblLines.TabIndex = 13;
            this.lblLines.Text = "0";
            this.lblLines.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblItemUnitCaption
            // 
            this.lblItemUnitCaption.AutoSize = true;
            this.lblItemUnitCaption.Location = new System.Drawing.Point(54, 38);
            this.lblItemUnitCaption.Name = "lblItemUnitCaption";
            this.lblItemUnitCaption.Size = new System.Drawing.Size(63, 17);
            this.lblItemUnitCaption.TabIndex = 9;
            this.lblItemUnitCaption.Text = "Item Unit";
            this.lblItemUnitCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboItemUnit
            // 
            this.cboItemUnit.FormattingEnabled = true;
            this.cboItemUnit.Location = new System.Drawing.Point(123, 35);
            this.cboItemUnit.Name = "cboItemUnit";
            this.cboItemUnit.Size = new System.Drawing.Size(188, 24);
            this.cboItemUnit.TabIndex = 1;
            // 
            // lblGrandTotalCaption
            // 
            this.lblGrandTotalCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGrandTotalCaption.AutoSize = true;
            this.lblGrandTotalCaption.Location = new System.Drawing.Point(714, 67);
            this.lblGrandTotalCaption.Name = "lblGrandTotalCaption";
            this.lblGrandTotalCaption.Size = new System.Drawing.Size(84, 17);
            this.lblGrandTotalCaption.TabIndex = 7;
            this.lblGrandTotalCaption.Text = "Grand Total";
            this.lblGrandTotalCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblItemIDCaption
            // 
            this.lblItemIDCaption.AutoSize = true;
            this.lblItemIDCaption.Location = new System.Drawing.Point(66, 9);
            this.lblItemIDCaption.Name = "lblItemIDCaption";
            this.lblItemIDCaption.Size = new System.Drawing.Size(51, 17);
            this.lblItemIDCaption.TabIndex = 6;
            this.lblItemIDCaption.Text = "Item ID";
            this.lblItemIDCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtItemID
            // 
            this.txtItemID.Location = new System.Drawing.Point(123, 6);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(188, 23);
            this.txtItemID.TabIndex = 0;
            this.txtItemID.Leave += new System.EventHandler(this.txtItemID_Leave);
            // 
            // lblDiscountTotalCaption
            // 
            this.lblDiscountTotalCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscountTotalCaption.AutoSize = true;
            this.lblDiscountTotalCaption.Location = new System.Drawing.Point(699, 38);
            this.lblDiscountTotalCaption.Name = "lblDiscountTotalCaption";
            this.lblDiscountTotalCaption.Size = new System.Drawing.Size(99, 17);
            this.lblDiscountTotalCaption.TabIndex = 4;
            this.lblDiscountTotalCaption.Text = "Discount Total";
            this.lblDiscountTotalCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblGrossTotalCaption
            // 
            this.lblGrossTotalCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGrossTotalCaption.AutoSize = true;
            this.lblGrossTotalCaption.Location = new System.Drawing.Point(716, 9);
            this.lblGrossTotalCaption.Name = "lblGrossTotalCaption";
            this.lblGrossTotalCaption.Size = new System.Drawing.Size(82, 17);
            this.lblGrossTotalCaption.TabIndex = 3;
            this.lblGrossTotalCaption.Text = "Gross Total";
            this.lblGrossTotalCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGrandTotal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtGrandTotal.Location = new System.Drawing.Point(804, 64);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(188, 23);
            this.txtGrandTotal.TabIndex = 2;
            this.txtGrandTotal.TabStop = false;
            this.txtGrandTotal.Text = "0.00";
            this.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDiscountTotal
            // 
            this.txtDiscountTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscountTotal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDiscountTotal.Location = new System.Drawing.Point(804, 35);
            this.txtDiscountTotal.Name = "txtDiscountTotal";
            this.txtDiscountTotal.ReadOnly = true;
            this.txtDiscountTotal.Size = new System.Drawing.Size(188, 23);
            this.txtDiscountTotal.TabIndex = 1;
            this.txtDiscountTotal.TabStop = false;
            this.txtDiscountTotal.Text = "0.00";
            this.txtDiscountTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtGrossTotal
            // 
            this.txtGrossTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGrossTotal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtGrossTotal.Location = new System.Drawing.Point(804, 6);
            this.txtGrossTotal.Name = "txtGrossTotal";
            this.txtGrossTotal.ReadOnly = true;
            this.txtGrossTotal.Size = new System.Drawing.Size(188, 23);
            this.txtGrossTotal.TabIndex = 0;
            this.txtGrossTotal.TabStop = false;
            this.txtGrossTotal.Text = "0.00";
            this.txtGrossTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlFunctionKeys
            // 
            this.pnlFunctionKeys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.pnlFunctionKeys, 4);
            this.pnlFunctionKeys.Controls.Add(this.btnChangePassword);
            this.pnlFunctionKeys.Controls.Add(this.txtF11);
            this.pnlFunctionKeys.Controls.Add(this.txtF7);
            this.pnlFunctionKeys.Controls.Add(this.btnItemCancel);
            this.pnlFunctionKeys.Controls.Add(this.txtF6);
            this.pnlFunctionKeys.Controls.Add(this.btnMemberIDInput);
            this.pnlFunctionKeys.Controls.Add(this.txtF12);
            this.pnlFunctionKeys.Controls.Add(this.btnOtherFunction);
            this.pnlFunctionKeys.Controls.Add(this.btnLowerQty);
            this.pnlFunctionKeys.Controls.Add(this.txtRaiseLowerQtyCaption);
            this.pnlFunctionKeys.Controls.Add(this.btnRaiseQty);
            this.pnlFunctionKeys.Controls.Add(this.txtF9);
            this.pnlFunctionKeys.Controls.Add(this.btnQtyInput);
            this.pnlFunctionKeys.Controls.Add(this.txtF8);
            this.pnlFunctionKeys.Controls.Add(this.btnToggleItemUnit);
            this.pnlFunctionKeys.Controls.Add(this.txtF10);
            this.pnlFunctionKeys.Controls.Add(this.txtF5);
            this.pnlFunctionKeys.Controls.Add(this.txtF4);
            this.pnlFunctionKeys.Controls.Add(this.txtF3);
            this.pnlFunctionKeys.Controls.Add(this.txtF2);
            this.pnlFunctionKeys.Controls.Add(this.btnLogout);
            this.pnlFunctionKeys.Controls.Add(this.btnNewSTxn);
            this.pnlFunctionKeys.Controls.Add(this.btnSearchSTxn);
            this.pnlFunctionKeys.Controls.Add(this.btnSearchItem);
            this.pnlFunctionKeys.Controls.Add(this.btnPayment);
            this.pnlFunctionKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFunctionKeys.Location = new System.Drawing.Point(3, 640);
            this.pnlFunctionKeys.Name = "pnlFunctionKeys";
            this.pnlFunctionKeys.Size = new System.Drawing.Size(1002, 79);
            this.pnlFunctionKeys.TabIndex = 6;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.Location = new System.Drawing.Point(835, 27);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(75, 48);
            this.btnChangePassword.TabIndex = 31;
            this.btnChangePassword.TabStop = false;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // txtF11
            // 
            this.txtF11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtF11.BackColor = System.Drawing.Color.SteelBlue;
            this.txtF11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF11.ForeColor = System.Drawing.Color.White;
            this.txtF11.Location = new System.Drawing.Point(835, 3);
            this.txtF11.Name = "txtF11";
            this.txtF11.ReadOnly = true;
            this.txtF11.Size = new System.Drawing.Size(75, 23);
            this.txtF11.TabIndex = 26;
            this.txtF11.TabStop = false;
            this.txtF11.Text = "F11";
            this.txtF11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtF7
            // 
            this.txtF7.BackColor = System.Drawing.Color.SteelBlue;
            this.txtF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF7.ForeColor = System.Drawing.Color.White;
            this.txtF7.Location = new System.Drawing.Point(410, 3);
            this.txtF7.Name = "txtF7";
            this.txtF7.ReadOnly = true;
            this.txtF7.Size = new System.Drawing.Size(75, 23);
            this.txtF7.TabIndex = 25;
            this.txtF7.TabStop = false;
            this.txtF7.Text = "F7";
            this.txtF7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnItemCancel
            // 
            this.btnItemCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemCancel.Location = new System.Drawing.Point(410, 27);
            this.btnItemCancel.Name = "btnItemCancel";
            this.btnItemCancel.Size = new System.Drawing.Size(75, 48);
            this.btnItemCancel.TabIndex = 25;
            this.btnItemCancel.TabStop = false;
            this.btnItemCancel.Text = "Item Cancel";
            this.btnItemCancel.UseVisualStyleBackColor = true;
            this.btnItemCancel.Click += new System.EventHandler(this.btnCancelItem_Click);
            // 
            // txtF6
            // 
            this.txtF6.BackColor = System.Drawing.Color.SteelBlue;
            this.txtF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF6.ForeColor = System.Drawing.Color.White;
            this.txtF6.Location = new System.Drawing.Point(329, 3);
            this.txtF6.Name = "txtF6";
            this.txtF6.ReadOnly = true;
            this.txtF6.Size = new System.Drawing.Size(75, 23);
            this.txtF6.TabIndex = 23;
            this.txtF6.TabStop = false;
            this.txtF6.Text = "F6";
            this.txtF6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMemberIDInput
            // 
            this.btnMemberIDInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberIDInput.Location = new System.Drawing.Point(329, 27);
            this.btnMemberIDInput.Name = "btnMemberIDInput";
            this.btnMemberIDInput.Size = new System.Drawing.Size(75, 48);
            this.btnMemberIDInput.TabIndex = 24;
            this.btnMemberIDInput.TabStop = false;
            this.btnMemberIDInput.Text = "Member ID Input";
            this.btnMemberIDInput.UseVisualStyleBackColor = true;
            this.btnMemberIDInput.Click += new System.EventHandler(this.btnMemberIDInput_Click);
            // 
            // txtF12
            // 
            this.txtF12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtF12.BackColor = System.Drawing.Color.SteelBlue;
            this.txtF12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF12.ForeColor = System.Drawing.Color.White;
            this.txtF12.Location = new System.Drawing.Point(916, 3);
            this.txtF12.Name = "txtF12";
            this.txtF12.ReadOnly = true;
            this.txtF12.Size = new System.Drawing.Size(75, 23);
            this.txtF12.TabIndex = 21;
            this.txtF12.TabStop = false;
            this.txtF12.Text = "F12";
            this.txtF12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnOtherFunction
            // 
            this.btnOtherFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOtherFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtherFunction.Location = new System.Drawing.Point(755, 27);
            this.btnOtherFunction.Name = "btnOtherFunction";
            this.btnOtherFunction.Size = new System.Drawing.Size(75, 48);
            this.btnOtherFunction.TabIndex = 30;
            this.btnOtherFunction.TabStop = false;
            this.btnOtherFunction.Text = "Other Function";
            this.btnOtherFunction.UseVisualStyleBackColor = true;
            this.btnOtherFunction.Click += new System.EventHandler(this.btnOthersFunction_Click);
            // 
            // btnLowerQty
            // 
            this.btnLowerQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLowerQty.Location = new System.Drawing.Point(653, 52);
            this.btnLowerQty.Name = "btnLowerQty";
            this.btnLowerQty.Size = new System.Drawing.Size(96, 23);
            this.btnLowerQty.TabIndex = 29;
            this.btnLowerQty.TabStop = false;
            this.btnLowerQty.Text = "Lower Qty [Dn]";
            this.btnLowerQty.UseVisualStyleBackColor = true;
            this.btnLowerQty.Click += new System.EventHandler(this.btnLowerQty_Click);
            // 
            // txtRaiseLowerQtyCaption
            // 
            this.txtRaiseLowerQtyCaption.BackColor = System.Drawing.Color.SteelBlue;
            this.txtRaiseLowerQtyCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRaiseLowerQtyCaption.ForeColor = System.Drawing.Color.White;
            this.txtRaiseLowerQtyCaption.Location = new System.Drawing.Point(653, 3);
            this.txtRaiseLowerQtyCaption.Name = "txtRaiseLowerQtyCaption";
            this.txtRaiseLowerQtyCaption.ReadOnly = true;
            this.txtRaiseLowerQtyCaption.Size = new System.Drawing.Size(96, 23);
            this.txtRaiseLowerQtyCaption.TabIndex = 17;
            this.txtRaiseLowerQtyCaption.TabStop = false;
            this.txtRaiseLowerQtyCaption.Text = "Up | Dn";
            this.txtRaiseLowerQtyCaption.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnRaiseQty
            // 
            this.btnRaiseQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRaiseQty.Location = new System.Drawing.Point(653, 27);
            this.btnRaiseQty.Name = "btnRaiseQty";
            this.btnRaiseQty.Size = new System.Drawing.Size(96, 23);
            this.btnRaiseQty.TabIndex = 28;
            this.btnRaiseQty.TabStop = false;
            this.btnRaiseQty.Text = "Raise Qty [Up]";
            this.btnRaiseQty.UseVisualStyleBackColor = true;
            this.btnRaiseQty.Click += new System.EventHandler(this.btnRaiseQty_Click);
            // 
            // txtF9
            // 
            this.txtF9.BackColor = System.Drawing.Color.SteelBlue;
            this.txtF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF9.ForeColor = System.Drawing.Color.White;
            this.txtF9.Location = new System.Drawing.Point(572, 3);
            this.txtF9.Name = "txtF9";
            this.txtF9.ReadOnly = true;
            this.txtF9.Size = new System.Drawing.Size(75, 23);
            this.txtF9.TabIndex = 15;
            this.txtF9.TabStop = false;
            this.txtF9.Text = "F9";
            this.txtF9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnQtyInput
            // 
            this.btnQtyInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQtyInput.Location = new System.Drawing.Point(572, 27);
            this.btnQtyInput.Name = "btnQtyInput";
            this.btnQtyInput.Size = new System.Drawing.Size(75, 48);
            this.btnQtyInput.TabIndex = 27;
            this.btnQtyInput.TabStop = false;
            this.btnQtyInput.Text = "Qty Input";
            this.btnQtyInput.UseVisualStyleBackColor = true;
            this.btnQtyInput.Click += new System.EventHandler(this.btnQtyInput_Click);
            // 
            // txtF8
            // 
            this.txtF8.BackColor = System.Drawing.Color.SteelBlue;
            this.txtF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF8.ForeColor = System.Drawing.Color.White;
            this.txtF8.Location = new System.Drawing.Point(491, 3);
            this.txtF8.Name = "txtF8";
            this.txtF8.ReadOnly = true;
            this.txtF8.Size = new System.Drawing.Size(75, 23);
            this.txtF8.TabIndex = 13;
            this.txtF8.TabStop = false;
            this.txtF8.Text = "F8";
            this.txtF8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnToggleItemUnit
            // 
            this.btnToggleItemUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleItemUnit.Location = new System.Drawing.Point(491, 27);
            this.btnToggleItemUnit.Name = "btnToggleItemUnit";
            this.btnToggleItemUnit.Size = new System.Drawing.Size(75, 48);
            this.btnToggleItemUnit.TabIndex = 26;
            this.btnToggleItemUnit.TabStop = false;
            this.btnToggleItemUnit.Text = "Toggle Item Unit";
            this.btnToggleItemUnit.UseVisualStyleBackColor = true;
            this.btnToggleItemUnit.Click += new System.EventHandler(this.btnToggleItemUnit_Click);
            // 
            // txtF10
            // 
            this.txtF10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtF10.BackColor = System.Drawing.Color.SteelBlue;
            this.txtF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF10.ForeColor = System.Drawing.Color.White;
            this.txtF10.Location = new System.Drawing.Point(755, 3);
            this.txtF10.Name = "txtF10";
            this.txtF10.ReadOnly = true;
            this.txtF10.Size = new System.Drawing.Size(75, 23);
            this.txtF10.TabIndex = 10;
            this.txtF10.TabStop = false;
            this.txtF10.Text = "F10";
            this.txtF10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtF5
            // 
            this.txtF5.BackColor = System.Drawing.Color.SteelBlue;
            this.txtF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF5.ForeColor = System.Drawing.Color.White;
            this.txtF5.Location = new System.Drawing.Point(248, 3);
            this.txtF5.Name = "txtF5";
            this.txtF5.ReadOnly = true;
            this.txtF5.Size = new System.Drawing.Size(75, 23);
            this.txtF5.TabIndex = 9;
            this.txtF5.TabStop = false;
            this.txtF5.Text = "F5";
            this.txtF5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtF4
            // 
            this.txtF4.BackColor = System.Drawing.Color.SteelBlue;
            this.txtF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF4.ForeColor = System.Drawing.Color.White;
            this.txtF4.Location = new System.Drawing.Point(168, 3);
            this.txtF4.Name = "txtF4";
            this.txtF4.ReadOnly = true;
            this.txtF4.Size = new System.Drawing.Size(75, 23);
            this.txtF4.TabIndex = 8;
            this.txtF4.TabStop = false;
            this.txtF4.Text = "F4";
            this.txtF4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtF3
            // 
            this.txtF3.BackColor = System.Drawing.Color.SteelBlue;
            this.txtF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF3.ForeColor = System.Drawing.Color.White;
            this.txtF3.Location = new System.Drawing.Point(87, 3);
            this.txtF3.Name = "txtF3";
            this.txtF3.ReadOnly = true;
            this.txtF3.Size = new System.Drawing.Size(75, 23);
            this.txtF3.TabIndex = 7;
            this.txtF3.TabStop = false;
            this.txtF3.Text = "F3";
            this.txtF3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtF2
            // 
            this.txtF2.BackColor = System.Drawing.Color.SteelBlue;
            this.txtF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF2.ForeColor = System.Drawing.Color.White;
            this.txtF2.Location = new System.Drawing.Point(6, 3);
            this.txtF2.Name = "txtF2";
            this.txtF2.ReadOnly = true;
            this.txtF2.Size = new System.Drawing.Size(75, 23);
            this.txtF2.TabIndex = 6;
            this.txtF2.TabStop = false;
            this.txtF2.Text = "F2";
            this.txtF2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(916, 27);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 48);
            this.btnLogout.TabIndex = 32;
            this.btnLogout.TabStop = false;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnNewSTxn
            // 
            this.btnNewSTxn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewSTxn.Location = new System.Drawing.Point(248, 27);
            this.btnNewSTxn.Name = "btnNewSTxn";
            this.btnNewSTxn.Size = new System.Drawing.Size(75, 48);
            this.btnNewSTxn.TabIndex = 23;
            this.btnNewSTxn.TabStop = false;
            this.btnNewSTxn.Text = "New Transaction";
            this.btnNewSTxn.UseVisualStyleBackColor = true;
            this.btnNewSTxn.Click += new System.EventHandler(this.btnNewSTxn_Click);
            // 
            // btnSearchSTxn
            // 
            this.btnSearchSTxn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSTxn.Location = new System.Drawing.Point(168, 27);
            this.btnSearchSTxn.Name = "btnSearchSTxn";
            this.btnSearchSTxn.Size = new System.Drawing.Size(75, 48);
            this.btnSearchSTxn.TabIndex = 22;
            this.btnSearchSTxn.TabStop = false;
            this.btnSearchSTxn.Text = "Search Transaction";
            this.btnSearchSTxn.UseVisualStyleBackColor = true;
            this.btnSearchSTxn.Click += new System.EventHandler(this.btnSearchSTxn_Click);
            // 
            // btnSearchItem
            // 
            this.btnSearchItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchItem.Location = new System.Drawing.Point(87, 27);
            this.btnSearchItem.Name = "btnSearchItem";
            this.btnSearchItem.Size = new System.Drawing.Size(75, 48);
            this.btnSearchItem.TabIndex = 21;
            this.btnSearchItem.TabStop = false;
            this.btnSearchItem.Text = "Search Item";
            this.btnSearchItem.UseVisualStyleBackColor = true;
            this.btnSearchItem.Click += new System.EventHandler(this.btnSearchItem_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.Location = new System.Drawing.Point(6, 27);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(75, 48);
            this.btnPayment.TabIndex = 20;
            this.btnPayment.TabStop = false;
            this.btnPayment.Text = "Payment";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // pnlStatusInfo
            // 
            this.pnlStatusInfo.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlStatusInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.pnlStatusInfo, 4);
            this.pnlStatusInfo.Controls.Add(this.lblSystemInfo);
            this.pnlStatusInfo.Controls.Add(this.lblSelectedFunction);
            this.pnlStatusInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatusInfo.Location = new System.Drawing.Point(0, 725);
            this.pnlStatusInfo.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlStatusInfo.Name = "pnlStatusInfo";
            this.pnlStatusInfo.Size = new System.Drawing.Size(1008, 27);
            this.pnlStatusInfo.TabIndex = 7;
            // 
            // lblSystemInfo
            // 
            this.lblSystemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSystemInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemInfo.ForeColor = System.Drawing.Color.White;
            this.lblSystemInfo.Location = new System.Drawing.Point(845, 4);
            this.lblSystemInfo.Name = "lblSystemInfo";
            this.lblSystemInfo.Size = new System.Drawing.Size(150, 17);
            this.lblSystemInfo.TabIndex = 0;
            this.lblSystemInfo.Text = "PurePOS";
            this.lblSystemInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSelectedFunction
            // 
            this.lblSelectedFunction.AutoSize = true;
            this.lblSelectedFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedFunction.ForeColor = System.Drawing.Color.White;
            this.lblSelectedFunction.Location = new System.Drawing.Point(11, 4);
            this.lblSelectedFunction.Name = "lblSelectedFunction";
            this.lblSelectedFunction.Size = new System.Drawing.Size(276, 17);
            this.lblSelectedFunction.TabIndex = 0;
            this.lblSelectedFunction.Text = "Selected Function For Current Transaction";
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLogo.Controls.Add(this.pictureBox2);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(197, 62);
            this.pnlLogo.TabIndex = 9;
            // 
            // pnlItemName
            // 
            this.pnlItemName.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.pnlItemName, 2);
            this.pnlItemName.Controls.Add(this.lblItemName);
            this.pnlItemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItemName.Location = new System.Drawing.Point(3, 173);
            this.pnlItemName.Name = "pnlItemName";
            this.pnlItemName.Size = new System.Drawing.Size(708, 69);
            this.pnlItemName.TabIndex = 10;
            // 
            // lblItemName
            // 
            this.lblItemName.BackColor = System.Drawing.Color.LightBlue;
            this.lblItemName.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblItemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.Black;
            this.lblItemName.Location = new System.Drawing.Point(0, 0);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(706, 67);
            this.lblItemName.TabIndex = 1;
            this.lblItemName.Text = "Item Name";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLastSTxnInfo
            // 
            this.pnlLastSTxnInfo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlLastSTxnInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.pnlLastSTxnInfo, 4);
            this.pnlLastSTxnInfo.Controls.Add(this.lblLastChange);
            this.pnlLastSTxnInfo.Controls.Add(this.lblLastChangeCaption);
            this.pnlLastSTxnInfo.Controls.Add(this.lblLastPayment);
            this.pnlLastSTxnInfo.Controls.Add(this.lblLastPaymentCaption);
            this.pnlLastSTxnInfo.Controls.Add(this.lblLastRounding);
            this.pnlLastSTxnInfo.Controls.Add(this.lblLastRoundingCaption);
            this.pnlLastSTxnInfo.Controls.Add(this.lblLastGrandTotal);
            this.pnlLastSTxnInfo.Controls.Add(this.lblLastGrandTotalCaption);
            this.pnlLastSTxnInfo.Controls.Add(this.lblLastSTxnNo);
            this.pnlLastSTxnInfo.Controls.Add(this.lblLastSTxnNoCaption);
            this.pnlLastSTxnInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLastSTxnInfo.Location = new System.Drawing.Point(3, 600);
            this.pnlLastSTxnInfo.Name = "pnlLastSTxnInfo";
            this.pnlLastSTxnInfo.Size = new System.Drawing.Size(1002, 34);
            this.pnlLastSTxnInfo.TabIndex = 11;
            // 
            // lblLastChange
            // 
            this.lblLastChange.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLastChange.AutoSize = true;
            this.lblLastChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastChange.ForeColor = System.Drawing.Color.Black;
            this.lblLastChange.Location = new System.Drawing.Point(896, 8);
            this.lblLastChange.Name = "lblLastChange";
            this.lblLastChange.Size = new System.Drawing.Size(35, 15);
            this.lblLastChange.TabIndex = 15;
            this.lblLastChange.Text = "0.00";
            // 
            // lblLastChangeCaption
            // 
            this.lblLastChangeCaption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLastChangeCaption.AutoSize = true;
            this.lblLastChangeCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastChangeCaption.ForeColor = System.Drawing.Color.Black;
            this.lblLastChangeCaption.Location = new System.Drawing.Point(837, 8);
            this.lblLastChangeCaption.Name = "lblLastChangeCaption";
            this.lblLastChangeCaption.Size = new System.Drawing.Size(60, 15);
            this.lblLastChangeCaption.TabIndex = 14;
            this.lblLastChangeCaption.Text = "Change:";
            // 
            // lblLastPayment
            // 
            this.lblLastPayment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLastPayment.AutoSize = true;
            this.lblLastPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastPayment.ForeColor = System.Drawing.Color.Black;
            this.lblLastPayment.Location = new System.Drawing.Point(734, 8);
            this.lblLastPayment.Name = "lblLastPayment";
            this.lblLastPayment.Size = new System.Drawing.Size(31, 15);
            this.lblLastPayment.TabIndex = 13;
            this.lblLastPayment.Text = "0.00";
            // 
            // lblLastPaymentCaption
            // 
            this.lblLastPaymentCaption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLastPaymentCaption.AutoSize = true;
            this.lblLastPaymentCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastPaymentCaption.ForeColor = System.Drawing.Color.Black;
            this.lblLastPaymentCaption.Location = new System.Drawing.Point(640, 8);
            this.lblLastPaymentCaption.Name = "lblLastPaymentCaption";
            this.lblLastPaymentCaption.Size = new System.Drawing.Size(88, 15);
            this.lblLastPaymentCaption.TabIndex = 12;
            this.lblLastPaymentCaption.Text = "Payment Total:";
            // 
            // lblLastRounding
            // 
            this.lblLastRounding.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLastRounding.AutoSize = true;
            this.lblLastRounding.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastRounding.ForeColor = System.Drawing.Color.Black;
            this.lblLastRounding.Location = new System.Drawing.Point(528, 8);
            this.lblLastRounding.Name = "lblLastRounding";
            this.lblLastRounding.Size = new System.Drawing.Size(31, 15);
            this.lblLastRounding.TabIndex = 11;
            this.lblLastRounding.Text = "0.00";
            // 
            // lblLastRoundingCaption
            // 
            this.lblLastRoundingCaption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLastRoundingCaption.AutoSize = true;
            this.lblLastRoundingCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastRoundingCaption.ForeColor = System.Drawing.Color.Black;
            this.lblLastRoundingCaption.Location = new System.Drawing.Point(458, 8);
            this.lblLastRoundingCaption.Name = "lblLastRoundingCaption";
            this.lblLastRoundingCaption.Size = new System.Drawing.Size(64, 15);
            this.lblLastRoundingCaption.TabIndex = 10;
            this.lblLastRoundingCaption.Text = "Rounding:";
            // 
            // lblLastGrandTotal
            // 
            this.lblLastGrandTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLastGrandTotal.AutoSize = true;
            this.lblLastGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastGrandTotal.ForeColor = System.Drawing.Color.Black;
            this.lblLastGrandTotal.Location = new System.Drawing.Point(354, 8);
            this.lblLastGrandTotal.Name = "lblLastGrandTotal";
            this.lblLastGrandTotal.Size = new System.Drawing.Size(31, 15);
            this.lblLastGrandTotal.TabIndex = 9;
            this.lblLastGrandTotal.Text = "0.00";
            // 
            // lblLastGrandTotalCaption
            // 
            this.lblLastGrandTotalCaption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLastGrandTotalCaption.AutoSize = true;
            this.lblLastGrandTotalCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastGrandTotalCaption.ForeColor = System.Drawing.Color.Black;
            this.lblLastGrandTotalCaption.Location = new System.Drawing.Point(274, 8);
            this.lblLastGrandTotalCaption.Name = "lblLastGrandTotalCaption";
            this.lblLastGrandTotalCaption.Size = new System.Drawing.Size(74, 15);
            this.lblLastGrandTotalCaption.TabIndex = 8;
            this.lblLastGrandTotalCaption.Text = "Grand Total:";
            // 
            // lblLastSTxnNo
            // 
            this.lblLastSTxnNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLastSTxnNo.AutoSize = true;
            this.lblLastSTxnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastSTxnNo.ForeColor = System.Drawing.Color.Black;
            this.lblLastSTxnNo.Location = new System.Drawing.Point(128, 8);
            this.lblLastSTxnNo.Name = "lblLastSTxnNo";
            this.lblLastSTxnNo.Size = new System.Drawing.Size(11, 15);
            this.lblLastSTxnNo.TabIndex = 7;
            this.lblLastSTxnNo.Text = "-";
            // 
            // lblLastSTxnNoCaption
            // 
            this.lblLastSTxnNoCaption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLastSTxnNoCaption.AutoSize = true;
            this.lblLastSTxnNoCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastSTxnNoCaption.ForeColor = System.Drawing.Color.Black;
            this.lblLastSTxnNoCaption.Location = new System.Drawing.Point(3, 8);
            this.lblLastSTxnNoCaption.Name = "lblLastSTxnNoCaption";
            this.lblLastSTxnNoCaption.Size = new System.Drawing.Size(119, 15);
            this.lblLastSTxnNoCaption.TabIndex = 6;
            this.lblLastSTxnNoCaption.Text = "Last Transaction No.";
            // 
            // pnlMember
            // 
            this.pnlMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.pnlMember, 4);
            this.pnlMember.Controls.Add(this.lblEntitiesSeqNo);
            this.pnlMember.Controls.Add(this.lblSTxnStatus);
            this.pnlMember.Controls.Add(this.cboSTxnStatusID);
            this.pnlMember.Controls.Add(this.lbltranstype);
            this.pnlMember.Controls.Add(this.cbotranstype);
            this.pnlMember.Controls.Add(this.lblUnitID);
            this.pnlMember.Controls.Add(this.cboUnit);
            this.pnlMember.Controls.Add(this.lblWhID);
            this.pnlMember.Controls.Add(this.cboWh);
            this.pnlMember.Controls.Add(this.lblValidThruDate);
            this.pnlMember.Controls.Add(this.lblValidThruCaption);
            this.pnlMember.Controls.Add(this.lblMemberSinceDate);
            this.pnlMember.Controls.Add(this.lblMemberSinceCaption);
            this.pnlMember.Controls.Add(this.lblMemberName);
            this.pnlMember.Controls.Add(this.txtMemberID);
            this.pnlMember.Controls.Add(this.lblMemberIDCaption);
            this.pnlMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMember.Location = new System.Drawing.Point(3, 108);
            this.pnlMember.Name = "pnlMember";
            this.pnlMember.Size = new System.Drawing.Size(1002, 59);
            this.pnlMember.TabIndex = 12;
            // 
            // lblEntitiesSeqNo
            // 
            this.lblEntitiesSeqNo.AutoSize = true;
            this.lblEntitiesSeqNo.Location = new System.Drawing.Point(8, 31);
            this.lblEntitiesSeqNo.Name = "lblEntitiesSeqNo";
            this.lblEntitiesSeqNo.Size = new System.Drawing.Size(105, 17);
            this.lblEntitiesSeqNo.TabIndex = 42;
            this.lblEntitiesSeqNo.Text = "Entities Seq No";
            this.lblEntitiesSeqNo.Visible = false;
            // 
            // lblSTxnStatus
            // 
            this.lblSTxnStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSTxnStatus.AutoSize = true;
            this.lblSTxnStatus.Location = new System.Drawing.Point(320, 6);
            this.lblSTxnStatus.Name = "lblSTxnStatus";
            this.lblSTxnStatus.Size = new System.Drawing.Size(48, 17);
            this.lblSTxnStatus.TabIndex = 41;
            this.lblSTxnStatus.Text = "Status";
            this.lblSTxnStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblSTxnStatus.Visible = false;
            // 
            // cboSTxnStatusID
            // 
            this.cboSTxnStatusID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSTxnStatusID.BackColor = System.Drawing.SystemColors.Window;
            this.cboSTxnStatusID.Enabled = false;
            this.cboSTxnStatusID.FormattingEnabled = true;
            this.cboSTxnStatusID.Location = new System.Drawing.Point(323, 25);
            this.cboSTxnStatusID.Name = "cboSTxnStatusID";
            this.cboSTxnStatusID.Size = new System.Drawing.Size(90, 24);
            this.cboSTxnStatusID.TabIndex = 40;
            this.cboSTxnStatusID.TabStop = false;
            this.cboSTxnStatusID.Visible = false;
            this.cboSTxnStatusID.SelectedIndexChanged += new System.EventHandler(this.cboSTxnStatusID_SelectedIndexChanged);
            // 
            // lbltranstype
            // 
            this.lbltranstype.AutoSize = true;
            this.lbltranstype.Location = new System.Drawing.Point(620, 6);
            this.lbltranstype.Name = "lbltranstype";
            this.lbltranstype.Size = new System.Drawing.Size(81, 17);
            this.lbltranstype.TabIndex = 39;
            this.lbltranstype.Text = "Trans Type";
            this.lbltranstype.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbltranstype.Visible = false;
            // 
            // cbotranstype
            // 
            this.cbotranstype.BackColor = System.Drawing.SystemColors.Window;
            this.cbotranstype.Enabled = false;
            this.cbotranstype.FormattingEnabled = true;
            this.cbotranstype.Location = new System.Drawing.Point(623, 31);
            this.cbotranstype.Name = "cbotranstype";
            this.cbotranstype.Size = new System.Drawing.Size(87, 24);
            this.cbotranstype.TabIndex = 38;
            this.cbotranstype.TabStop = false;
            this.cbotranstype.Visible = false;
            // 
            // lblUnitID
            // 
            this.lblUnitID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnitID.AutoSize = true;
            this.lblUnitID.Location = new System.Drawing.Point(734, 34);
            this.lblUnitID.Name = "lblUnitID";
            this.lblUnitID.Size = new System.Drawing.Size(33, 17);
            this.lblUnitID.TabIndex = 37;
            this.lblUnitID.Text = "Unit";
            this.lblUnitID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblUnitID.Visible = false;
            // 
            // cboUnit
            // 
            this.cboUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUnit.BackColor = System.Drawing.SystemColors.Window;
            this.cboUnit.Enabled = false;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(819, 31);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(168, 24);
            this.cboUnit.TabIndex = 36;
            this.cboUnit.TabStop = false;
            this.cboUnit.Visible = false;
            // 
            // lblWhID
            // 
            this.lblWhID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWhID.AutoSize = true;
            this.lblWhID.Location = new System.Drawing.Point(734, 6);
            this.lblWhID.Name = "lblWhID";
            this.lblWhID.Size = new System.Drawing.Size(81, 17);
            this.lblWhID.TabIndex = 35;
            this.lblWhID.Text = "Warehouse";
            this.lblWhID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblWhID.Visible = false;
            // 
            // cboWh
            // 
            this.cboWh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboWh.BackColor = System.Drawing.SystemColors.Window;
            this.cboWh.Enabled = false;
            this.cboWh.FormattingEnabled = true;
            this.cboWh.Location = new System.Drawing.Point(819, 3);
            this.cboWh.Name = "cboWh";
            this.cboWh.Size = new System.Drawing.Size(168, 24);
            this.cboWh.TabIndex = 34;
            this.cboWh.TabStop = false;
            this.cboWh.Visible = false;
            // 
            // lblValidThruDate
            // 
            this.lblValidThruDate.AutoSize = true;
            this.lblValidThruDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidThruDate.Location = new System.Drawing.Point(523, 32);
            this.lblValidThruDate.Name = "lblValidThruDate";
            this.lblValidThruDate.Size = new System.Drawing.Size(80, 17);
            this.lblValidThruDate.TabIndex = 9;
            this.lblValidThruDate.Text = "01/01/2011";
            // 
            // lblValidThruCaption
            // 
            this.lblValidThruCaption.AutoSize = true;
            this.lblValidThruCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidThruCaption.Location = new System.Drawing.Point(444, 32);
            this.lblValidThruCaption.Name = "lblValidThruCaption";
            this.lblValidThruCaption.Size = new System.Drawing.Size(73, 17);
            this.lblValidThruCaption.TabIndex = 8;
            this.lblValidThruCaption.Text = "Valid Thru";
            this.lblValidThruCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMemberSinceDate
            // 
            this.lblMemberSinceDate.AutoSize = true;
            this.lblMemberSinceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberSinceDate.Location = new System.Drawing.Point(523, 9);
            this.lblMemberSinceDate.Name = "lblMemberSinceDate";
            this.lblMemberSinceDate.Size = new System.Drawing.Size(80, 17);
            this.lblMemberSinceDate.TabIndex = 7;
            this.lblMemberSinceDate.Text = "01/01/2011";
            // 
            // lblMemberSinceCaption
            // 
            this.lblMemberSinceCaption.AutoSize = true;
            this.lblMemberSinceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberSinceCaption.Location = new System.Drawing.Point(419, 9);
            this.lblMemberSinceCaption.Name = "lblMemberSinceCaption";
            this.lblMemberSinceCaption.Size = new System.Drawing.Size(98, 17);
            this.lblMemberSinceCaption.TabIndex = 6;
            this.lblMemberSinceCaption.Text = "Member Since";
            this.lblMemberSinceCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMemberName
            // 
            this.lblMemberName.AutoSize = true;
            this.lblMemberName.Location = new System.Drawing.Point(120, 32);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(100, 17);
            this.lblMemberName.TabIndex = 5;
            this.lblMemberName.Text = "Member Name";
            // 
            // txtMemberID
            // 
            this.txtMemberID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMemberID.Location = new System.Drawing.Point(123, 6);
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.ReadOnly = true;
            this.txtMemberID.Size = new System.Drawing.Size(188, 23);
            this.txtMemberID.TabIndex = 32;
            this.txtMemberID.TabStop = false;
            // 
            // lblMemberIDCaption
            // 
            this.lblMemberIDCaption.AutoSize = true;
            this.lblMemberIDCaption.Location = new System.Drawing.Point(41, 9);
            this.lblMemberIDCaption.Name = "lblMemberIDCaption";
            this.lblMemberIDCaption.Size = new System.Drawing.Size(76, 17);
            this.lblMemberIDCaption.TabIndex = 3;
            this.lblMemberIDCaption.Text = "Member ID";
            this.lblMemberIDCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlItemUnitPrice
            // 
            this.pnlItemUnitPrice.BackColor = System.Drawing.Color.LightBlue;
            this.pnlItemUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.pnlItemUnitPrice, 2);
            this.pnlItemUnitPrice.Controls.Add(this.lblItemUnitPrice);
            this.pnlItemUnitPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItemUnitPrice.Location = new System.Drawing.Point(717, 173);
            this.pnlItemUnitPrice.Name = "pnlItemUnitPrice";
            this.pnlItemUnitPrice.Size = new System.Drawing.Size(288, 69);
            this.pnlItemUnitPrice.TabIndex = 13;
            // 
            // lblItemUnitPrice
            // 
            this.lblItemUnitPrice.BackColor = System.Drawing.Color.LightBlue;
            this.lblItemUnitPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItemUnitPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemUnitPrice.ForeColor = System.Drawing.Color.Black;
            this.lblItemUnitPrice.Location = new System.Drawing.Point(0, 0);
            this.lblItemUnitPrice.Name = "lblItemUnitPrice";
            this.lblItemUnitPrice.Size = new System.Drawing.Size(286, 67);
            this.lblItemUnitPrice.TabIndex = 3;
            this.lblItemUnitPrice.Text = "0.00";
            this.lblItemUnitPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerSystemCurrentTime
            // 
            this.timerSystemCurrentTime.Enabled = true;
            this.timerSystemCurrentTime.Interval = 1000;
            this.timerSystemCurrentTime.Tick += new System.EventHandler(this.timerSystemCurrentTime_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Raven.Pos.Sales.Properties.Resources.Ravensoft_Logo_Original;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.InitialImage = global::Raven.Pos.Sales.Properties.Resources.Ravensoft_Logo_Original;
            this.pictureBox2.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(197, 62);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // POSMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 752);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "POSMainForm";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.POSMainForm_KeyUp);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).EndInit();
            this.pnlApplicationHeader.ResumeLayout(false);
            this.pnlApplicationHeader.PerformLayout();
            this.pnlSTxn.ResumeLayout(false);
            this.pnlSTxn.PerformLayout();
            this.pnlInputData.ResumeLayout(false);
            this.pnlInputData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
            this.pnlFunctionKeys.ResumeLayout(false);
            this.pnlFunctionKeys.PerformLayout();
            this.pnlStatusInfo.ResumeLayout(false);
            this.pnlStatusInfo.PerformLayout();
            this.pnlLogo.ResumeLayout(false);
            this.pnlItemName.ResumeLayout(false);
            this.pnlLastSTxnInfo.ResumeLayout(false);
            this.pnlLastSTxnInfo.PerformLayout();
            this.pnlMember.ResumeLayout(false);
            this.pnlMember.PerformLayout();
            this.pnlItemUnitPrice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlApplicationHeader;
        private System.Windows.Forms.Panel pnlSTxn;
        private System.Windows.Forms.Panel pnlInputData;
        private System.Windows.Forms.Panel pnlFunctionKeys;
        private System.Windows.Forms.Panel pnlStatusInfo;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnSearchItem;
        private System.Windows.Forms.Button btnSearchSTxn;
        private System.Windows.Forms.Button btnNewSTxn;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblSystemInfo;
        private System.Windows.Forms.Label lblSelectedFunction;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Label lblCashierID;
        private System.Windows.Forms.TextBox txtF2;
        private System.Windows.Forms.TextBox txtF3;
        private System.Windows.Forms.TextBox txtF4;
        private System.Windows.Forms.TextBox txtF5;
        private System.Windows.Forms.TextBox txtF10;
        private System.Windows.Forms.Label lblCashierName;
        private System.Windows.Forms.Label lblSystemCurrentDate;
        private System.Windows.Forms.Label lblSystemCurrentTime;
        private System.Windows.Forms.Label lblSTxnNoCaption;
        private System.Windows.Forms.TextBox txtSTxnNo;
        private System.Windows.Forms.Panel pnlItemName;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtGrossTotal;
        private System.Windows.Forms.TextBox txtDiscountTotal;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Label lblGrossTotalCaption;
        private System.Windows.Forms.Label lblDiscountTotalCaption;
        private System.Windows.Forms.Label lblItemIDCaption;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.Label lblGrandTotalCaption;
        private System.Windows.Forms.ComboBox cboItemUnit;
        private System.Windows.Forms.Label lblItemUnitCaption;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.Label lblQtyCaption;
        private System.Windows.Forms.TextBox txtF8;
        private System.Windows.Forms.Button btnToggleItemUnit;
        private System.Windows.Forms.TextBox txtF9;
        private System.Windows.Forms.Button btnQtyInput;
        private System.Windows.Forms.Label lblLinesCaption;
        private System.Windows.Forms.Label lblLines;
        private System.Windows.Forms.Label lblItemsCaption;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Button btnRaiseQty;
        private System.Windows.Forms.TextBox txtRaiseLowerQtyCaption;
        private System.Windows.Forms.Button btnLowerQty;
        private System.Windows.Forms.Panel pnlLastSTxnInfo;
        private System.Windows.Forms.Label lblLastSTxnNo;
        private System.Windows.Forms.Label lblLastSTxnNoCaption;
        private System.Windows.Forms.Label lblLastGrandTotalCaption;
        private System.Windows.Forms.Label lblLastGrandTotal;
        private System.Windows.Forms.Label lblLastRoundingCaption;
        private System.Windows.Forms.Label lblLastRounding;
        private System.Windows.Forms.Label lblLastPaymentCaption;
        private System.Windows.Forms.Label lblLastPayment;
        private System.Windows.Forms.Label lblLastChangeCaption;
        private System.Windows.Forms.Label lblLastChange;
        private System.Windows.Forms.TextBox txtF12;
        private System.Windows.Forms.Button btnOtherFunction;
        private System.Windows.Forms.TextBox txtF6;
        private System.Windows.Forms.Button btnMemberIDInput;
        private System.Windows.Forms.Label lblSTxnDateCaption;
        private System.Windows.Forms.TextBox txtSTxnDate;
        private System.Windows.Forms.Panel pnlMember;
        private System.Windows.Forms.TextBox txtMemberID;
        private System.Windows.Forms.Label lblMemberIDCaption;
        private System.Windows.Forms.TextBox txtF7;
        private System.Windows.Forms.Button btnItemCancel;
        private System.Windows.Forms.Label lblMemberName;
        private System.Windows.Forms.Label lblMemberSinceCaption;
        private System.Windows.Forms.Label lblMemberSinceDate;
        private System.Windows.Forms.Label lblValidThruDate;
        private System.Windows.Forms.Label lblValidThruCaption;
        private System.Windows.Forms.DataGridView grdItem;
        private System.Windows.Forms.Panel pnlItemUnitPrice;
        private System.Windows.Forms.Label lblItemUnitPrice;
        private System.Windows.Forms.Timer timerSystemCurrentTime;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.TextBox txtF11;
        private System.Windows.Forms.TextBox txtToggleOperator;
        private System.Windows.Forms.Label lblItemFactorCaption;
        private System.Windows.Forms.TextBox txtItemFactor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemUnitID;
        private System.Windows.Forms.Label lblUnitID;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Label lblWhID;
        private System.Windows.Forms.ComboBox cboWh;
        private System.Windows.Forms.TextBox txtCurrencyRate;
        private System.Windows.Forms.Label lblSTxnCurrencyCaption;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.Label lbltranstype;
        private System.Windows.Forms.ComboBox cbotranstype;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemFactor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscountAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label lblUnitPriceCaption;
        private System.Windows.Forms.Label lblUnitDisc;
        private System.Windows.Forms.Label lblUnitDiscCaption;
        private System.Windows.Forms.Label lblUnitDisc2;
        private System.Windows.Forms.Label lblUnitDisc1;
        private System.Windows.Forms.Label lblSTxnStatus;
        private System.Windows.Forms.ComboBox cboSTxnStatusID;
        private System.Windows.Forms.Label lblEntitiesSeqNo;
        private System.Windows.Forms.PictureBox pictureBox2;        

    }
}