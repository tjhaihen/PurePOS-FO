namespace Raven.Pos.Sales
{
    partial class PrintPOPForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblSettlementDateCaption = new System.Windows.Forms.Label();
            this.txtFromItemID = new System.Windows.Forms.TextBox();
            this.txtThruItemID = new System.Windows.Forms.TextBox();
            this.txtFromItemName = new System.Windows.Forms.TextBox();
            this.txtThruItemName = new System.Windows.Forms.TextBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Thru Item";
            // 
            // lblSettlementDateCaption
            // 
            this.lblSettlementDateCaption.AutoSize = true;
            this.lblSettlementDateCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettlementDateCaption.Location = new System.Drawing.Point(12, 9);
            this.lblSettlementDateCaption.Name = "lblSettlementDateCaption";
            this.lblSettlementDateCaption.Size = new System.Drawing.Size(70, 17);
            this.lblSettlementDateCaption.TabIndex = 19;
            this.lblSettlementDateCaption.Text = "From Item";
            this.lblSettlementDateCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtFromItemID
            // 
            this.txtFromItemID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromItemID.Location = new System.Drawing.Point(116, 6);
            this.txtFromItemID.Name = "txtFromItemID";
            this.txtFromItemID.Size = new System.Drawing.Size(150, 23);
            this.txtFromItemID.TabIndex = 0;
            this.txtFromItemID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFromItem_KeyUp);
            this.txtFromItemID.Leave += new System.EventHandler(this.txtFromItemID_Leave);
            // 
            // txtThruItemID
            // 
            this.txtThruItemID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThruItemID.Location = new System.Drawing.Point(116, 34);
            this.txtThruItemID.Name = "txtThruItemID";
            this.txtThruItemID.Size = new System.Drawing.Size(150, 23);
            this.txtThruItemID.TabIndex = 1;
            this.txtThruItemID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtThruItem_KeyUp);
            this.txtThruItemID.Leave += new System.EventHandler(this.txtThruItemID_Leave);
            // 
            // txtFromItemName
            // 
            this.txtFromItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromItemName.Location = new System.Drawing.Point(272, 6);
            this.txtFromItemName.Name = "txtFromItemName";
            this.txtFromItemName.ReadOnly = true;
            this.txtFromItemName.Size = new System.Drawing.Size(272, 23);
            this.txtFromItemName.TabIndex = 25;
            this.txtFromItemName.TabStop = false;
            // 
            // txtThruItemName
            // 
            this.txtThruItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThruItemName.Location = new System.Drawing.Point(272, 34);
            this.txtThruItemName.Name = "txtThruItemName";
            this.txtThruItemName.ReadOnly = true;
            this.txtThruItemName.Size = new System.Drawing.Size(272, 23);
            this.txtThruItemName.TabIndex = 26;
            this.txtThruItemName.TabStop = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(116, 62);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 38);
            this.btnPreview.TabIndex = 27;
            this.btnPreview.TabStop = false;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // PrintPOPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 106);
            this.ControlBox = false;
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.txtThruItemName);
            this.Controls.Add(this.txtFromItemName);
            this.Controls.Add(this.txtThruItemID);
            this.Controls.Add(this.txtFromItemID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSettlementDateCaption);
            this.KeyPreview = true;
            this.Name = "PrintPOPForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print POP";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PrintPOPForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSettlementDateCaption;
        private System.Windows.Forms.TextBox txtFromItemID;
        private System.Windows.Forms.TextBox txtThruItemID;
        private System.Windows.Forms.TextBox txtFromItemName;
        private System.Windows.Forms.TextBox txtThruItemName;
        private System.Windows.Forms.Button btnPreview;
    }
}