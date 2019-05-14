namespace Raven.Pos.Sales
{
    partial class SearchQuickPaymentForm
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
            this.pnlSearchQuickPayment = new System.Windows.Forms.Panel();
            this.grdQuickPayment = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSearchQuickPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuickPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearchQuickPayment
            // 
            this.pnlSearchQuickPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearchQuickPayment.Controls.Add(this.grdQuickPayment);
            this.pnlSearchQuickPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearchQuickPayment.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchQuickPayment.Name = "pnlSearchQuickPayment";
            this.pnlSearchQuickPayment.Size = new System.Drawing.Size(386, 281);
            this.pnlSearchQuickPayment.TabIndex = 6;
            // 
            // grdQuickPayment
            // 
            this.grdQuickPayment.AllowUserToAddRows = false;
            this.grdQuickPayment.AllowUserToDeleteRows = false;
            this.grdQuickPayment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdQuickPayment.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grdQuickPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdQuickPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PaymentTypeName,
            this.CardTypeName});
            this.grdQuickPayment.Location = new System.Drawing.Point(11, 11);
            this.grdQuickPayment.Name = "grdQuickPayment";
            this.grdQuickPayment.ReadOnly = true;
            this.grdQuickPayment.RowHeadersWidth = 25;
            this.grdQuickPayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdQuickPayment.Size = new System.Drawing.Size(362, 257);
            this.grdQuickPayment.StandardTab = true;
            this.grdQuickPayment.TabIndex = 9;
            this.grdQuickPayment.DoubleClick += new System.EventHandler(this.grdQuickPayment_DoubleClick);
            this.grdQuickPayment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdQuickPayment_KeyDown);
            this.grdQuickPayment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdQuickPayment_KeyUp);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.DataPropertyName = "ID";
            dataGridViewCellStyle1.Format = "#,##0.00";
            dataGridViewCellStyle1.NullValue = null;
            this.ID.DefaultCellStyle = dataGridViewCellStyle1;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 43;
            // 
            // PaymentTypeName
            // 
            this.PaymentTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PaymentTypeName.DataPropertyName = "PaymentTypeName";
            this.PaymentTypeName.HeaderText = "Payment Type Name";
            this.PaymentTypeName.Name = "PaymentTypeName";
            this.PaymentTypeName.ReadOnly = true;
            // 
            // CardTypeName
            // 
            this.CardTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CardTypeName.DataPropertyName = "CardTypeName";
            this.CardTypeName.HeaderText = "Card Type Name";
            this.CardTypeName.Name = "CardTypeName";
            this.CardTypeName.ReadOnly = true;
            // 
            // SearchQuickPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 281);
            this.ControlBox = false;
            this.Controls.Add(this.pnlSearchQuickPayment);
            this.KeyPreview = true;
            this.Name = "SearchQuickPaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Payment Method";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchQuickPaymentForm_KeyUp);
            this.pnlSearchQuickPayment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdQuickPayment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearchQuickPayment;
        private System.Windows.Forms.DataGridView grdQuickPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardTypeName;


    }
}