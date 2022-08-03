namespace Fakher.UI.Financial
{
    partial class frmFinancialCommitmentList
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
            this.rGridViewCommitments = new rComponents.rGridView();
            this.rPageView1 = new rComponents.rPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView1 = new rComponents.rGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rPageView1)).BeginInit();
            this.rPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            this.radPageViewPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rGridViewCommitments
            // 
            this.rGridViewCommitments.CanAdd = false;
            this.rGridViewCommitments.CanDelete = true;
            this.rGridViewCommitments.CanEdit = true;
            this.rGridViewCommitments.CanExport = true;
            this.rGridViewCommitments.CanFilter = true;
            this.rGridViewCommitments.CanGroup = false;
            this.rGridViewCommitments.CanNavigate = true;
            this.rGridViewCommitments.CheckBoxes = false;
            this.rGridViewCommitments.ColumnAutoSize = true;
            this.rGridViewCommitments.ConfirmOnDelete = true;
            this.rGridViewCommitments.CustomAddText = null;
            this.rGridViewCommitments.CustomDeleteText = null;
            this.rGridViewCommitments.CustomEditText = null;
            this.rGridViewCommitments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewCommitments.EditOnDoubleClick = true;
            this.rGridViewCommitments.FieldName = null;
            this.rGridViewCommitments.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewCommitments.ItemImage = null;
            this.rGridViewCommitments.Location = new System.Drawing.Point(0, 0);
            this.rGridViewCommitments.MultiSelect = false;
            this.rGridViewCommitments.Name = "rGridViewCommitments";
            this.rGridViewCommitments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewCommitments.RowHeight = 25;
            this.rGridViewCommitments.ShowBottomToolbar = false;
            this.rGridViewCommitments.ShowGroupPanel = true;
            this.rGridViewCommitments.ShowTopToolbar = true;
            this.rGridViewCommitments.Size = new System.Drawing.Size(888, 463);
            this.rGridViewCommitments.TabIndex = 0;
            this.rGridViewCommitments.ValidationType = rComponents.ValidationType.None;
            this.rGridViewCommitments.Edit += new System.EventHandler(this.rGridViewCommitments_Edit);
            this.rGridViewCommitments.Delete += new System.EventHandler(this.rGridViewCommitments_Delete);
            // 
            // rPageView1
            // 
            this.rPageView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rPageView1.Controls.Add(this.radPageViewPage1);
            this.rPageView1.Controls.Add(this.radPageViewPage2);
            this.rPageView1.Location = new System.Drawing.Point(12, 12);
            this.rPageView1.Name = "rPageView1";
            this.rPageView1.SelectedPage = this.radPageViewPage1;
            this.rPageView1.Size = new System.Drawing.Size(909, 510);
            this.rPageView1.TabIndex = 0;
            this.rPageView1.Text = "rPageView1";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.rPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.rGridViewCommitments);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(888, 463);
            this.radPageViewPage1.Text = "تعهدات جــاری";
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.rGridView1);
            this.radPageViewPage2.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(888, 463);
            this.radPageViewPage2.Text = "همه تعهدات ";
            // 
            // rGridView1
            // 
            this.rGridView1.CanAdd = false;
            this.rGridView1.CanDelete = true;
            this.rGridView1.CanEdit = true;
            this.rGridView1.CanExport = true;
            this.rGridView1.CanFilter = true;
            this.rGridView1.CanGroup = false;
            this.rGridView1.CanNavigate = true;
            this.rGridView1.CheckBoxes = false;
            this.rGridView1.ColumnAutoSize = true;
            this.rGridView1.ConfirmOnDelete = true;
            this.rGridView1.CustomAddText = null;
            this.rGridView1.CustomDeleteText = null;
            this.rGridView1.CustomEditText = null;
            this.rGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView1.EditOnDoubleClick = true;
            this.rGridView1.FieldName = null;
            this.rGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView1.ItemImage = null;
            this.rGridView1.Location = new System.Drawing.Point(0, 0);
            this.rGridView1.MultiSelect = false;
            this.rGridView1.Name = "rGridView1";
            this.rGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView1.RowHeight = 25;
            this.rGridView1.ShowBottomToolbar = false;
            this.rGridView1.ShowGroupPanel = true;
            this.rGridView1.ShowTopToolbar = true;
            this.rGridView1.Size = new System.Drawing.Size(888, 463);
            this.rGridView1.TabIndex = 1;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Edit += new System.EventHandler(this.rGridView1_Edit);
            this.rGridView1.Delete += new System.EventHandler(this.rGridView1_Delete);
            // 
            // frmFinancialCommitmentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 534);
            this.Controls.Add(this.rPageView1);
            this.Name = "frmFinancialCommitmentList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "لیست تعهدات مالی";
            ((System.ComponentModel.ISupportInitialize)(this.rPageView1)).EndInit();
            this.rPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private rComponents.rGridView rGridViewCommitments;
        private rComponents.rPageView rPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private rComponents.rGridView rGridView1;
    }
}