namespace Fakher.UI.Financial
{
    partial class frmAdvanceFinancialDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdvanceFinancialDetail));
            this.financialDocumentView1 = new Fakher.Controls.FinancialDocumentView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnReport = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // financialDocumentView1
            // 
            this.financialDocumentView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.financialDocumentView1.CanAdd = false;
            this.financialDocumentView1.CanDelete = false;
            this.financialDocumentView1.CanEdit = false;
            this.financialDocumentView1.Location = new System.Drawing.Point(2, 28);
            this.financialDocumentView1.Name = "financialDocumentView1";
            this.financialDocumentView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.financialDocumentView1.Size = new System.Drawing.Size(821, 458);
            this.financialDocumentView1.TabIndex = 0;
            this.financialDocumentView1.Delete += new System.EventHandler(this.financialDocumentView1_Delete);
            this.financialDocumentView1.Add += new System.EventHandler(this.financialDocumentView1_Add);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnReport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(829, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnReport
            // 
            this.toolStripBtnReport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnReport.Image")));
            this.toolStripBtnReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnReport.Name = "toolStripBtnReport";
            this.toolStripBtnReport.Size = new System.Drawing.Size(171, 22);
            this.toolStripBtnReport.Text = "چـاپ گــزارش دریافت های مالی";
            this.toolStripBtnReport.Click += new System.EventHandler(this.toolStripBtnReport_Click);
            // 
            // frmAdvanceFinancialDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 488);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.financialDocumentView1);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "frmAdvanceFinancialDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشاهده ریز جزئیات امور مالی";
            this.Load += new System.EventHandler(this.frmAdvanceFinancialDetail_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Fakher.Controls.FinancialDocumentView financialDocumentView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnReport;
    }
}