namespace Raven.Pos.Sales
{
    partial class SearchItemFactorForm
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
            this.pnlSearchItemFactor = new System.Windows.Forms.Panel();
            this.grdItemFactor = new System.Windows.Forms.DataGridView();
            this.ItemFactor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSearchItemFactor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemFactor)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearchItemFactor
            // 
            this.pnlSearchItemFactor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearchItemFactor.Controls.Add(this.grdItemFactor);
            this.pnlSearchItemFactor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearchItemFactor.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchItemFactor.Name = "pnlSearchItemFactor";
            this.pnlSearchItemFactor.Size = new System.Drawing.Size(264, 191);
            this.pnlSearchItemFactor.TabIndex = 6;
            // 
            // grdItemFactor
            // 
            this.grdItemFactor.AllowUserToAddRows = false;
            this.grdItemFactor.AllowUserToDeleteRows = false;
            this.grdItemFactor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdItemFactor.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grdItemFactor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItemFactor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemFactor});
            this.grdItemFactor.Location = new System.Drawing.Point(11, 11);
            this.grdItemFactor.Name = "grdItemFactor";
            this.grdItemFactor.ReadOnly = true;
            this.grdItemFactor.RowHeadersWidth = 25;
            this.grdItemFactor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdItemFactor.Size = new System.Drawing.Size(237, 166);
            this.grdItemFactor.StandardTab = true;
            this.grdItemFactor.TabIndex = 9;
            this.grdItemFactor.DoubleClick += new System.EventHandler(this.grdItemFactor_DoubleClick);
            this.grdItemFactor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdItemFactor_KeyDown);
            this.grdItemFactor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdItemFactor_KeyUp);
            // 
            // ItemFactor
            // 
            this.ItemFactor.DataPropertyName = "ItemFactor";
            dataGridViewCellStyle1.Format = "#,##0.00";
            dataGridViewCellStyle1.NullValue = null;
            this.ItemFactor.DefaultCellStyle = dataGridViewCellStyle1;
            this.ItemFactor.HeaderText = "Item Factor";
            this.ItemFactor.Name = "ItemFactor";
            this.ItemFactor.ReadOnly = true;
            // 
            // SearchItemFactorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 191);
            this.ControlBox = false;
            this.Controls.Add(this.pnlSearchItemFactor);
            this.KeyPreview = true;
            this.Name = "SearchItemFactorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Factor";
            this.pnlSearchItemFactor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdItemFactor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearchItemFactor;
        private System.Windows.Forms.DataGridView grdItemFactor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemFactor;


    }
}