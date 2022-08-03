namespace Fakher.UI.Store
{
    partial class frmStorePanel
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
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView1 = new rComponents.rGridView();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView2 = new rComponents.rGridView();
            this.radPageViewPage3 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView3 = new rComponents.rGridView();
            this.rTextBox1 = new rComponents.rTextBox(this.components);
            this.rTextBox2 = new rComponents.rTextBox(this.components);
            this.radBtnSearch = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            this.radPageViewPage2.SuspendLayout();
            this.radPageViewPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView1
            // 
            this.radPageView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Controls.Add(this.radPageViewPage2);
            this.radPageView1.Controls.Add(this.radPageViewPage3);
            this.radPageView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radPageView1.Location = new System.Drawing.Point(12, 37);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage1;
            this.radPageView1.Size = new System.Drawing.Size(812, 447);
            this.radPageView1.TabIndex = 3;
            this.radPageView1.Text = "radPageView1";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.Fill;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Top;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.rGridView1);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(791, 400);
            this.radPageViewPage1.Text = "دانـــشــجـــــویــــان";
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
            this.rGridView1.ConfirmOnDelete = false;
            this.rGridView1.CustomAddText = "";
            this.rGridView1.CustomDeleteText = "امــــانــــت";
            this.rGridView1.CustomEditText = "فـــــروش";
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
            this.rGridView1.Size = new System.Drawing.Size(791, 400);
            this.rGridView1.TabIndex = 3;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Edit += new System.EventHandler(this.rGridView1_Edit);
            this.rGridView1.Delete += new System.EventHandler(this.rGridView1_Delete);
            this.rGridView1.CustomButtonClick += new System.EventHandler<rComponents.CustomButtonClickEventArgs>(this.rGridView1_CustomButtonClick);
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.rGridView2);
            this.radPageViewPage2.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(791, 400);
            this.radPageViewPage2.Text = "اســــاتــیـــد";
            // 
            // rGridView2
            // 
            this.rGridView2.CanAdd = false;
            this.rGridView2.CanDelete = true;
            this.rGridView2.CanEdit = true;
            this.rGridView2.CanExport = true;
            this.rGridView2.CanFilter = true;
            this.rGridView2.CanGroup = false;
            this.rGridView2.CanNavigate = true;
            this.rGridView2.CheckBoxes = false;
            this.rGridView2.ColumnAutoSize = true;
            this.rGridView2.ConfirmOnDelete = false;
            this.rGridView2.CustomAddText = null;
            this.rGridView2.CustomDeleteText = "امــــانــــت";
            this.rGridView2.CustomEditText = "فـــــروش";
            this.rGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView2.EditOnDoubleClick = true;
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
            this.rGridView2.Size = new System.Drawing.Size(791, 400);
            this.rGridView2.TabIndex = 4;
            this.rGridView2.ValidationType = rComponents.ValidationType.None;
            this.rGridView2.Edit += new System.EventHandler(this.rGridView2_Edit);
            this.rGridView2.Delete += new System.EventHandler(this.rGridView2_Delete);
            this.rGridView2.CustomButtonClick += new System.EventHandler<rComponents.CustomButtonClickEventArgs>(this.rGridView2_CustomButtonClick);
            // 
            // radPageViewPage3
            // 
            this.radPageViewPage3.Controls.Add(this.rGridView3);
            this.radPageViewPage3.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage3.Name = "radPageViewPage3";
            this.radPageViewPage3.Size = new System.Drawing.Size(791, 400);
            this.radPageViewPage3.Text = "پــــــرســـنل";
            // 
            // rGridView3
            // 
            this.rGridView3.CanAdd = false;
            this.rGridView3.CanDelete = true;
            this.rGridView3.CanEdit = true;
            this.rGridView3.CanExport = true;
            this.rGridView3.CanFilter = true;
            this.rGridView3.CanGroup = false;
            this.rGridView3.CanNavigate = true;
            this.rGridView3.CheckBoxes = false;
            this.rGridView3.ColumnAutoSize = true;
            this.rGridView3.ConfirmOnDelete = false;
            this.rGridView3.CustomAddText = null;
            this.rGridView3.CustomDeleteText = "امــــانــــت";
            this.rGridView3.CustomEditText = "فـــــروش";
            this.rGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView3.EditOnDoubleClick = true;
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
            this.rGridView3.Size = new System.Drawing.Size(791, 400);
            this.rGridView3.TabIndex = 4;
            this.rGridView3.ValidationType = rComponents.ValidationType.None;
            this.rGridView3.Edit += new System.EventHandler(this.rGridView3_Edit);
            this.rGridView3.Delete += new System.EventHandler(this.rGridView3_Delete);
            this.rGridView3.CustomButtonClick += new System.EventHandler<rComponents.CustomButtonClickEventArgs>(this.rGridView3_CustomButtonClick);
            // 
            // rTextBox1
            // 
            this.rTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rTextBox1.Culture = null;
            this.rTextBox1.FieldName = null;
            this.rTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox1.Language = rComponents.TextboxLanguage.Farsi;
            this.rTextBox1.Location = new System.Drawing.Point(489, 12);
            this.rTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox1.MaximumValue = null;
            this.rTextBox1.MinimumValue = null;
            this.rTextBox1.Name = "rTextBox1";
            this.rTextBox1.NullText = "نــــام";
            this.rTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rTextBox1.Size = new System.Drawing.Size(160, 19);
            this.rTextBox1.TabIndex = 0;
            this.rTextBox1.TabStop = false;
            this.rTextBox1.Type = rComponents.rTextBoxType.Text;
            this.rTextBox1.ValidatingProperty = null;
            this.rTextBox1.ValidationType = rComponents.ValidationType.None;
            this.rTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rTextBox1_KeyDown);
            // 
            // rTextBox2
            // 
            this.rTextBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rTextBox2.Culture = null;
            this.rTextBox2.FieldName = null;
            this.rTextBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox2.Language = rComponents.TextboxLanguage.Farsi;
            this.rTextBox2.Location = new System.Drawing.Point(323, 12);
            this.rTextBox2.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox2.MaximumValue = null;
            this.rTextBox2.MinimumValue = null;
            this.rTextBox2.Name = "rTextBox2";
            this.rTextBox2.NullText = "نـــــام خـــانوادگــــی";
            this.rTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rTextBox2.Size = new System.Drawing.Size(160, 19);
            this.rTextBox2.TabIndex = 1;
            this.rTextBox2.TabStop = false;
            this.rTextBox2.Type = rComponents.rTextBoxType.Text;
            this.rTextBox2.ValidatingProperty = null;
            this.rTextBox2.ValidationType = rComponents.ValidationType.None;
            this.rTextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rTextBox2_KeyDown);
            // 
            // radBtnSearch
            // 
            this.radBtnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radBtnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radBtnSearch.Location = new System.Drawing.Point(187, 9);
            this.radBtnSearch.Name = "radBtnSearch";
            this.radBtnSearch.Size = new System.Drawing.Size(130, 24);
            this.radBtnSearch.TabIndex = 2;
            this.radBtnSearch.Text = "جستجو";
            this.radBtnSearch.Click += new System.EventHandler(this.radBtnSearch_Click);
            // 
            // frmStorePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 496);
            this.Controls.Add(this.radBtnSearch);
            this.Controls.Add(this.rTextBox2);
            this.Controls.Add(this.rTextBox1);
            this.Controls.Add(this.radPageView1);
            this.Name = "frmStorePanel";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "پـــنـــل انـتـشـــارات";
            this.Load += new System.EventHandler(this.frmStorePanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage2.ResumeLayout(false);
            this.radPageViewPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage3;
        private rComponents.rTextBox rTextBox1;
        private rComponents.rTextBox rTextBox2;
        private Telerik.WinControls.UI.RadButton radBtnSearch;
        private rComponents.rGridView rGridView1;
        private rComponents.rGridView rGridView3;
        private rComponents.rGridView rGridView2;
    }
}