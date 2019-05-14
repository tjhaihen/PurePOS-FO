namespace Raven.Pos.Sales
{
    partial class InformationPromotionForm
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
            this.grdInfoPromotion = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpPromotionDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblSettlementDateCaption = new System.Windows.Forms.Label();
            this.dtpPromotionDateFrom = new System.Windows.Forms.DateTimePicker();
            this.btnView = new System.Windows.Forms.Button();
            this.ItemSeqNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromotionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpecialPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disc1Pct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disc2Pct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetVoucherAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsMultipleApplied = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPurchase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdInfoPromotion)).BeginInit();
            this.SuspendLayout();
            // 
            // grdInfoPromotion
            // 
            this.grdInfoPromotion.AllowUserToAddRows = false;
            this.grdInfoPromotion.AllowUserToDeleteRows = false;
            this.grdInfoPromotion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdInfoPromotion.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grdInfoPromotion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInfoPromotion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemSeqNo,
            this.ItemID,
            this.ItemName,
            this.PromotionName,
            this.StartDate,
            this.EndDate,
            this.SpecialPrice,
            this.BuyQty,
            this.GetQty,
            this.Disc1Pct,
            this.Disc2Pct,
            this.GetVoucherAmt,
            this.BuyAmt,
            this.IsMultipleApplied,
            this.nPurchase});
            this.grdInfoPromotion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdInfoPromotion.Location = new System.Drawing.Point(12, 38);
            this.grdInfoPromotion.MultiSelect = false;
            this.grdInfoPromotion.Name = "grdInfoPromotion";
            this.grdInfoPromotion.ReadOnly = true;
            this.grdInfoPromotion.RowHeadersWidth = 25;
            this.grdInfoPromotion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdInfoPromotion.Size = new System.Drawing.Size(904, 248);
            this.grdInfoPromotion.StandardTab = true;
            this.grdInfoPromotion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(286, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "to";
            // 
            // dtpPromotionDateTo
            // 
            this.dtpPromotionDateTo.Checked = false;
            this.dtpPromotionDateTo.CustomFormat = "dd-MM-yyyy";
            this.dtpPromotionDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPromotionDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPromotionDateTo.Location = new System.Drawing.Point(313, 6);
            this.dtpPromotionDateTo.Name = "dtpPromotionDateTo";
            this.dtpPromotionDateTo.Size = new System.Drawing.Size(144, 23);
            this.dtpPromotionDateTo.TabIndex = 20;
            this.dtpPromotionDateTo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtpPromotionDateTo_KeyUp);
            // 
            // lblSettlementDateCaption
            // 
            this.lblSettlementDateCaption.AutoSize = true;
            this.lblSettlementDateCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettlementDateCaption.Location = new System.Drawing.Point(12, 9);
            this.lblSettlementDateCaption.Name = "lblSettlementDateCaption";
            this.lblSettlementDateCaption.Size = new System.Drawing.Size(106, 17);
            this.lblSettlementDateCaption.TabIndex = 19;
            this.lblSettlementDateCaption.Text = "Promotion Date";
            this.lblSettlementDateCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpPromotionDateFrom
            // 
            this.dtpPromotionDateFrom.Checked = false;
            this.dtpPromotionDateFrom.CustomFormat = "dd-MM-yyyy";
            this.dtpPromotionDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPromotionDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPromotionDateFrom.Location = new System.Drawing.Point(135, 6);
            this.dtpPromotionDateFrom.Name = "dtpPromotionDateFrom";
            this.dtpPromotionDateFrom.Size = new System.Drawing.Size(145, 23);
            this.dtpPromotionDateFrom.TabIndex = 18;
            this.dtpPromotionDateFrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtpPromotionDateFrom_KeyUp);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(463, 6);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(73, 26);
            this.btnView.TabIndex = 22;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // ItemSeqNo
            // 
            this.ItemSeqNo.DataPropertyName = "ItemSeqNo";
            this.ItemSeqNo.HeaderText = "Item Seq No";
            this.ItemSeqNo.Name = "ItemSeqNo";
            this.ItemSeqNo.ReadOnly = true;
            this.ItemSeqNo.Visible = false;
            // 
            // ItemID
            // 
            this.ItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ItemID.DataPropertyName = "ItemID";
            this.ItemID.FillWeight = 106.599F;
            this.ItemID.HeaderText = "Item ID";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            this.ItemID.Width = 66;
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.FillWeight = 126.5054F;
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // PromotionName
            // 
            this.PromotionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PromotionName.DataPropertyName = "PromotionName";
            this.PromotionName.HeaderText = "Promotion Name";
            this.PromotionName.Name = "PromotionName";
            this.PromotionName.ReadOnly = true;
            // 
            // StartDate
            // 
            this.StartDate.DataPropertyName = "StartDate";
            this.StartDate.HeaderText = "Start Date";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            // 
            // EndDate
            // 
            this.EndDate.DataPropertyName = "EndDate";
            this.EndDate.HeaderText = "End Date";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            // 
            // SpecialPrice
            // 
            this.SpecialPrice.DataPropertyName = "SpecialPrice";
            this.SpecialPrice.HeaderText = "Special Price";
            this.SpecialPrice.Name = "SpecialPrice";
            this.SpecialPrice.ReadOnly = true;
            this.SpecialPrice.Visible = false;
            // 
            // BuyQty
            // 
            this.BuyQty.DataPropertyName = "BuyQty";
            this.BuyQty.HeaderText = "Buy Qty";
            this.BuyQty.Name = "BuyQty";
            this.BuyQty.ReadOnly = true;
            this.BuyQty.Visible = false;
            // 
            // GetQty
            // 
            this.GetQty.HeaderText = "Get Qty";
            this.GetQty.Name = "GetQty";
            this.GetQty.ReadOnly = true;
            this.GetQty.Visible = false;
            // 
            // Disc1Pct
            // 
            this.Disc1Pct.DataPropertyName = "Disc1Pct";
            this.Disc1Pct.HeaderText = "Disc 1";
            this.Disc1Pct.Name = "Disc1Pct";
            this.Disc1Pct.ReadOnly = true;
            this.Disc1Pct.Visible = false;
            // 
            // Disc2Pct
            // 
            this.Disc2Pct.DataPropertyName = "Disc2Pct";
            this.Disc2Pct.HeaderText = "Disc 2";
            this.Disc2Pct.Name = "Disc2Pct";
            this.Disc2Pct.ReadOnly = true;
            this.Disc2Pct.Visible = false;
            // 
            // GetVoucherAmt
            // 
            this.GetVoucherAmt.DataPropertyName = "GetVoucherAmt";
            this.GetVoucherAmt.HeaderText = "Get Voucher Amt";
            this.GetVoucherAmt.Name = "GetVoucherAmt";
            this.GetVoucherAmt.ReadOnly = true;
            this.GetVoucherAmt.Visible = false;
            // 
            // BuyAmt
            // 
            this.BuyAmt.DataPropertyName = "BuyAmt";
            this.BuyAmt.HeaderText = "Buy Amt";
            this.BuyAmt.Name = "BuyAmt";
            this.BuyAmt.ReadOnly = true;
            this.BuyAmt.Visible = false;
            // 
            // IsMultipleApplied
            // 
            this.IsMultipleApplied.DataPropertyName = "IsMultipleApplied";
            this.IsMultipleApplied.HeaderText = "Multiple Applied";
            this.IsMultipleApplied.Name = "IsMultipleApplied";
            this.IsMultipleApplied.ReadOnly = true;
            this.IsMultipleApplied.Visible = false;
            // 
            // nPurchase
            // 
            this.nPurchase.DataPropertyName = "nPurchase";
            this.nPurchase.HeaderText = "n Purchase";
            this.nPurchase.Name = "nPurchase";
            this.nPurchase.ReadOnly = true;
            this.nPurchase.Visible = false;
            // 
            // InformationPromotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 298);
            this.ControlBox = false;
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpPromotionDateTo);
            this.Controls.Add(this.lblSettlementDateCaption);
            this.Controls.Add(this.dtpPromotionDateFrom);
            this.Controls.Add(this.grdInfoPromotion);
            this.KeyPreview = true;
            this.Name = "InformationPromotionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Promotion Info";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.InformationPromotionForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.grdInfoPromotion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdInfoPromotion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpPromotionDateTo;
        private System.Windows.Forms.Label lblSettlementDateCaption;
        private System.Windows.Forms.DateTimePicker dtpPromotionDateFrom;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSeqNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromotionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpecialPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn GetQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disc1Pct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disc2Pct;
        private System.Windows.Forms.DataGridViewTextBoxColumn GetVoucherAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsMultipleApplied;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPurchase;
    }
}