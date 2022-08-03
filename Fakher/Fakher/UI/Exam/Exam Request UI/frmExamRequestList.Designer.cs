namespace Fakher.UI.Exam
{
    partial class frmExamRequestList
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
            this.rGridView1 = new rComponents.rGridView();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView2 = new rComponents.rGridView();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView3 = new rComponents.rGridView();
            this.radPageViewPage5 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView5 = new rComponents.rGridView();
            this.radPageViewPage3 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView4 = new rComponents.rGridView();
            this.radPageViewPage4 = new Telerik.WinControls.UI.RadPageViewPage();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            this.radPageViewPage2.SuspendLayout();
            this.radPageViewPage5.SuspendLayout();
            this.radPageViewPage3.SuspendLayout();
            this.radPageViewPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rGridView1
            // 
            this.rGridView1.CanAdd = false;
            this.rGridView1.CanDelete = true;
            this.rGridView1.CanEdit = true;
            this.rGridView1.CanExport = true;
            this.rGridView1.CanFilter = true;
            this.rGridView1.CanGroup = true;
            this.rGridView1.CanNavigate = true;
            this.rGridView1.CheckBoxes = false;
            this.rGridView1.ColumnAutoSize = true;
            this.rGridView1.ConfirmOnDelete = true;
            this.rGridView1.CustomAddText = null;
            this.rGridView1.CustomDeleteText = "رد";
            this.rGridView1.CustomEditText = "تایید";
            this.rGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView1.EditOnDoubleClick = false;
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
            this.rGridView1.Size = new System.Drawing.Size(869, 382);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Delete += new System.EventHandler(this.rGridView1_Delete);
            this.rGridView1.Edit += new System.EventHandler(this.rGridView1_Edit);
            this.rGridView1.CustomButtonClick += new System.EventHandler<rComponents.CustomButtonClickEventArgs>(this.rGridView1_CustomButtonClick);
            // 
            // radPageView1
            // 
            this.radPageView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Controls.Add(this.radPageViewPage2);
            this.radPageView1.Controls.Add(this.radPageViewPage5);
            this.radPageView1.Controls.Add(this.radPageViewPage3);
            this.radPageView1.Controls.Add(this.radPageViewPage4);
            this.radPageView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radPageView1.Location = new System.Drawing.Point(12, 12);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage4;
            this.radPageView1.Size = new System.Drawing.Size(890, 429);
            this.radPageView1.TabIndex = 1;
            this.radPageView1.Text = "radPageView1";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.rGridView2);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(869, 382);
            this.radPageViewPage1.Text = "درخواست های درحال بررسی";
            // 
            // rGridView2
            // 
            this.rGridView2.CanAdd = false;
            this.rGridView2.CanDelete = true;
            this.rGridView2.CanEdit = true;
            this.rGridView2.CanExport = true;
            this.rGridView2.CanFilter = true;
            this.rGridView2.CanGroup = true;
            this.rGridView2.CanNavigate = true;
            this.rGridView2.CheckBoxes = false;
            this.rGridView2.ColumnAutoSize = true;
            this.rGridView2.ConfirmOnDelete = true;
            this.rGridView2.CustomAddText = null;
            this.rGridView2.CustomDeleteText = "رد";
            this.rGridView2.CustomEditText = "تایید";
            this.rGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView2.EditOnDoubleClick = false;
            this.rGridView2.FieldName = null;
            this.rGridView2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView2.ItemImage = null;
            this.rGridView2.Location = new System.Drawing.Point(0, 0);
            this.rGridView2.MultiSelect = false;
            this.rGridView2.Name = "rGridView2";
            this.rGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView2.RowHeight = 25;
            this.rGridView2.ShowBottomToolbar = false;
            this.rGridView2.ShowGroupPanel = true;
            this.rGridView2.ShowTopToolbar = true;
            this.rGridView2.Size = new System.Drawing.Size(869, 382);
            this.rGridView2.TabIndex = 1;
            this.rGridView2.ValidationType = rComponents.ValidationType.None;
            this.rGridView2.Delete += new System.EventHandler(this.rGridView1_Delete);
            this.rGridView2.Edit += new System.EventHandler(this.rGridView1_Edit);
            this.rGridView2.CustomButtonClick += new System.EventHandler<rComponents.CustomButtonClickEventArgs>(this.rGridView1_CustomButtonClick);
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.rGridView3);
            this.radPageViewPage2.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(869, 382);
            this.radPageViewPage2.Text = "درخواست های تایید شده";
            // 
            // rGridView3
            // 
            this.rGridView3.CanAdd = true;
            this.rGridView3.CanDelete = true;
            this.rGridView3.CanEdit = true;
            this.rGridView3.CanExport = true;
            this.rGridView3.CanFilter = true;
            this.rGridView3.CanGroup = true;
            this.rGridView3.CanNavigate = true;
            this.rGridView3.CheckBoxes = false;
            this.rGridView3.ColumnAutoSize = true;
            this.rGridView3.ConfirmOnDelete = true;
            this.rGridView3.CustomAddText = "اقدام شد";
            this.rGridView3.CustomDeleteText = "رد";
            this.rGridView3.CustomEditText = "تایید";
            this.rGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView3.EditOnDoubleClick = false;
            this.rGridView3.FieldName = null;
            this.rGridView3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView3.ItemImage = null;
            this.rGridView3.Location = new System.Drawing.Point(0, 0);
            this.rGridView3.MultiSelect = false;
            this.rGridView3.Name = "rGridView3";
            this.rGridView3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView3.RowHeight = 25;
            this.rGridView3.ShowBottomToolbar = false;
            this.rGridView3.ShowGroupPanel = true;
            this.rGridView3.ShowTopToolbar = true;
            this.rGridView3.Size = new System.Drawing.Size(869, 382);
            this.rGridView3.TabIndex = 1;
            this.rGridView3.ValidationType = rComponents.ValidationType.None;
            this.rGridView3.Delete += new System.EventHandler(this.rGridView1_Delete);
            this.rGridView3.Edit += new System.EventHandler(this.rGridView1_Edit);
            this.rGridView3.CustomButtonClick += new System.EventHandler<rComponents.CustomButtonClickEventArgs>(this.rGridView1_CustomButtonClick);
            this.rGridView3.Add += new System.EventHandler(this.rGridView3_Add);
            // 
            // radPageViewPage5
            // 
            this.radPageViewPage5.Controls.Add(this.rGridView5);
            this.radPageViewPage5.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage5.Name = "radPageViewPage5";
            this.radPageViewPage5.Size = new System.Drawing.Size(869, 382);
            this.radPageViewPage5.Text = "درخواست های اقدام شده";
            // 
            // rGridView5
            // 
            this.rGridView5.CanAdd = false;
            this.rGridView5.CanDelete = true;
            this.rGridView5.CanEdit = true;
            this.rGridView5.CanExport = true;
            this.rGridView5.CanFilter = true;
            this.rGridView5.CanGroup = true;
            this.rGridView5.CanNavigate = true;
            this.rGridView5.CheckBoxes = false;
            this.rGridView5.ColumnAutoSize = true;
            this.rGridView5.ConfirmOnDelete = true;
            this.rGridView5.CustomAddText = null;
            this.rGridView5.CustomDeleteText = "رد";
            this.rGridView5.CustomEditText = "تایید";
            this.rGridView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView5.EditOnDoubleClick = false;
            this.rGridView5.FieldName = null;
            this.rGridView5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView5.ItemImage = null;
            this.rGridView5.Location = new System.Drawing.Point(0, 0);
            this.rGridView5.MultiSelect = false;
            this.rGridView5.Name = "rGridView5";
            this.rGridView5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView5.RowHeight = 25;
            this.rGridView5.ShowBottomToolbar = false;
            this.rGridView5.ShowGroupPanel = true;
            this.rGridView5.ShowTopToolbar = true;
            this.rGridView5.Size = new System.Drawing.Size(869, 382);
            this.rGridView5.TabIndex = 2;
            this.rGridView5.ValidationType = rComponents.ValidationType.None;
            this.rGridView5.CustomButtonClick += new System.EventHandler<rComponents.CustomButtonClickEventArgs>(this.rGridView1_CustomButtonClick);
            // 
            // radPageViewPage3
            // 
            this.radPageViewPage3.Controls.Add(this.rGridView4);
            this.radPageViewPage3.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage3.Name = "radPageViewPage3";
            this.radPageViewPage3.Size = new System.Drawing.Size(869, 382);
            this.radPageViewPage3.Text = "درخواست های رد شده";
            // 
            // rGridView4
            // 
            this.rGridView4.CanAdd = false;
            this.rGridView4.CanDelete = true;
            this.rGridView4.CanEdit = true;
            this.rGridView4.CanExport = true;
            this.rGridView4.CanFilter = true;
            this.rGridView4.CanGroup = true;
            this.rGridView4.CanNavigate = true;
            this.rGridView4.CheckBoxes = false;
            this.rGridView4.ColumnAutoSize = true;
            this.rGridView4.ConfirmOnDelete = true;
            this.rGridView4.CustomAddText = null;
            this.rGridView4.CustomDeleteText = "رد";
            this.rGridView4.CustomEditText = "تایید";
            this.rGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView4.EditOnDoubleClick = false;
            this.rGridView4.FieldName = null;
            this.rGridView4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView4.ItemImage = null;
            this.rGridView4.Location = new System.Drawing.Point(0, 0);
            this.rGridView4.MultiSelect = false;
            this.rGridView4.Name = "rGridView4";
            this.rGridView4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView4.RowHeight = 25;
            this.rGridView4.ShowBottomToolbar = false;
            this.rGridView4.ShowGroupPanel = true;
            this.rGridView4.ShowTopToolbar = true;
            this.rGridView4.Size = new System.Drawing.Size(869, 382);
            this.rGridView4.TabIndex = 1;
            this.rGridView4.ValidationType = rComponents.ValidationType.None;
            this.rGridView4.Delete += new System.EventHandler(this.rGridView1_Delete);
            this.rGridView4.Edit += new System.EventHandler(this.rGridView1_Edit);
            this.rGridView4.CustomButtonClick += new System.EventHandler<rComponents.CustomButtonClickEventArgs>(this.rGridView1_CustomButtonClick);
            // 
            // radPageViewPage4
            // 
            this.radPageViewPage4.Controls.Add(this.rGridView1);
            this.radPageViewPage4.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage4.Name = "radPageViewPage4";
            this.radPageViewPage4.Size = new System.Drawing.Size(869, 382);
            this.radPageViewPage4.Text = "کل درخواست ها";
            // 
            // frmExamRequestList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 453);
            this.Controls.Add(this.radPageView1);
            this.Name = "frmExamRequestList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "لیست درخواست های آزمون";
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage2.ResumeLayout(false);
            this.radPageViewPage5.ResumeLayout(false);
            this.radPageViewPage3.ResumeLayout(false);
            this.radPageViewPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private rComponents.rGridView rGridView1;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage4;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage3;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private rComponents.rGridView rGridView4;
        private rComponents.rGridView rGridView3;
        private rComponents.rGridView rGridView2;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage5;
        private rComponents.rGridView rGridView5;
    }
}