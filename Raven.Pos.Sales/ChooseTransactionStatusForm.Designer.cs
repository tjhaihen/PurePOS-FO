namespace Raven.Pos.Sales
{
    partial class ChooseTransactionStatusForm
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
            this.pnlChooseTransactionStatus = new System.Windows.Forms.Panel();
            this.grdChooseTransactionStatus = new System.Windows.Forms.DataGridView();
            this.StatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlChooseTransactionStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChooseTransactionStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlChooseTransactionStatus
            // 
            this.pnlChooseTransactionStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChooseTransactionStatus.Controls.Add(this.grdChooseTransactionStatus);
            this.pnlChooseTransactionStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChooseTransactionStatus.Location = new System.Drawing.Point(0, 0);
            this.pnlChooseTransactionStatus.Name = "pnlChooseTransactionStatus";
            this.pnlChooseTransactionStatus.Size = new System.Drawing.Size(264, 133);
            this.pnlChooseTransactionStatus.TabIndex = 6;
            // 
            // grdChooseTransactionStatus
            // 
            this.grdChooseTransactionStatus.AllowUserToAddRows = false;
            this.grdChooseTransactionStatus.AllowUserToDeleteRows = false;
            this.grdChooseTransactionStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdChooseTransactionStatus.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grdChooseTransactionStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdChooseTransactionStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StatusID,
            this.StatusName});
            this.grdChooseTransactionStatus.Location = new System.Drawing.Point(11, 11);
            this.grdChooseTransactionStatus.Name = "grdChooseTransactionStatus";
            this.grdChooseTransactionStatus.ReadOnly = true;
            this.grdChooseTransactionStatus.RowHeadersWidth = 25;
            this.grdChooseTransactionStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdChooseTransactionStatus.Size = new System.Drawing.Size(237, 110);
            this.grdChooseTransactionStatus.StandardTab = true;
            this.grdChooseTransactionStatus.TabIndex = 9;
            this.grdChooseTransactionStatus.DoubleClick += new System.EventHandler(this.grdChooseTransactionStatus_DoubleClick);
            this.grdChooseTransactionStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdChooseTransactionStatus_KeyDown);
            this.grdChooseTransactionStatus.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdChooseTransactionStatus_KeyUp);
            // 
            // StatusID
            // 
            this.StatusID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StatusID.DataPropertyName = "DetailID";
            dataGridViewCellStyle2.Format = "#,##0.00";
            dataGridViewCellStyle2.NullValue = null;
            this.StatusID.DefaultCellStyle = dataGridViewCellStyle2;
            this.StatusID.HeaderText = "Status ID";
            this.StatusID.Name = "StatusID";
            this.StatusID.ReadOnly = true;
            this.StatusID.Width = 76;
            // 
            // StatusName
            // 
            this.StatusName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StatusName.DataPropertyName = "DetailDesc";
            this.StatusName.HeaderText = "Status Name";
            this.StatusName.Name = "StatusName";
            this.StatusName.ReadOnly = true;
            // 
            // ChooseTransactionStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 133);
            this.ControlBox = false;
            this.Controls.Add(this.pnlChooseTransactionStatus);
            this.KeyPreview = true;
            this.Name = "ChooseTransactionStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose Transaction Status";
            this.pnlChooseTransactionStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdChooseTransactionStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChooseTransactionStatus;
        private System.Windows.Forms.DataGridView grdChooseTransactionStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusName;


    }
}