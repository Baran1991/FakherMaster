namespace Fakher.UI.Reception
{
    partial class frmStudentConfigurations
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
            this.rGridCmbPeriod = new rComponents.rGridComboBox(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.rGridCmbMajor = new rComponents.rGridComboBox(this.components);
            this.lnkGenerate = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbPeriod.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbPeriod.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbMajor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbMajor.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbMajor.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView1
            // 
            this.radPageView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radPageView1.Location = new System.Drawing.Point(12, 79);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage1;
            this.radPageView1.Size = new System.Drawing.Size(767, 374);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.Text = "radPageView1";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.rGridView1);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(746, 327);
            this.radPageViewPage1.Text = "درس/سطح قابل ثبت نـام";
            // 
            // rGridView1
            // 
            this.rGridView1.CanAdd = true;
            this.rGridView1.CanDelete = true;
            this.rGridView1.CanEdit = false;
            this.rGridView1.CanExport = true;
            this.rGridView1.CanFilter = true;
            this.rGridView1.CanGroup = false;
            this.rGridView1.CanNavigate = true;
            this.rGridView1.CheckBoxes = false;
            this.rGridView1.ColumnAutoSize = true;
            this.rGridView1.ConfirmOnDelete = true;
            this.rGridView1.CustomAddText = "اضافـه";
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
            this.rGridView1.Size = new System.Drawing.Size(746, 327);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Delete += new System.EventHandler(this.rGridView1_Delete);
            this.rGridView1.CustomButtonClick += new System.EventHandler<rComponents.CustomButtonClickEventArgs>(this.rGridView1_CustomButtonClick);
            this.rGridView1.Add += new System.EventHandler(this.rGridView1_Add);
            // 
            // rGridCmbPeriod
            // 
            this.rGridCmbPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridCmbPeriod.CompareMember = null;
            this.rGridCmbPeriod.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridCmbPeriod.NestedRadGridView
            // 
            this.rGridCmbPeriod.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridCmbPeriod.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridCmbPeriod.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridCmbPeriod.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // rGridCmbPeriod.NestedRadGridView
            // 
            this.rGridCmbPeriod.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridCmbPeriod.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridCmbPeriod.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridCmbPeriod.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridCmbPeriod.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridCmbPeriod.EditorControl.MasterTemplate.EnableFiltering = true;
            this.rGridCmbPeriod.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridCmbPeriod.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridCmbPeriod.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridCmbPeriod.EditorControl.Name = "NestedRadGridView";
            this.rGridCmbPeriod.EditorControl.ReadOnly = true;
            this.rGridCmbPeriod.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridCmbPeriod.EditorControl.ShowGroupPanel = false;
            this.rGridCmbPeriod.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridCmbPeriod.EditorControl.TabIndex = 0;
            this.rGridCmbPeriod.FieldName = null;
            this.rGridCmbPeriod.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridCmbPeriod.Location = new System.Drawing.Point(12, 37);
            this.rGridCmbPeriod.MaximumValue = null;
            this.rGridCmbPeriod.MinimumValue = null;
            this.rGridCmbPeriod.Name = "rGridCmbPeriod";
            // 
            // 
            // 
            this.rGridCmbPeriod.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridCmbPeriod.ShowFilteringRow = true;
            this.rGridCmbPeriod.ShowNullButton = false;
            this.rGridCmbPeriod.Size = new System.Drawing.Size(722, 19);
            this.rGridCmbPeriod.TabIndex = 1;
            this.rGridCmbPeriod.TabStop = false;
            this.rGridCmbPeriod.ValidatingProperty = null;
            this.rGridCmbPeriod.ValidationType = rComponents.ValidationType.None;
            this.rGridCmbPeriod.Value = null;
            this.rGridCmbPeriod.SelectedIndexChanged += new System.EventHandler(this.rGridCmbPeriod_SelectedIndexChanged);
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(739, 37);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(39, 17);
            this.rLabel1.TabIndex = 2;
            this.rLabel1.Text = "تـــــرم:";
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(740, 14);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(42, 17);
            this.rLabel2.TabIndex = 3;
            this.rLabel2.Text = "رشتــه:";
            // 
            // rGridCmbMajor
            // 
            this.rGridCmbMajor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridCmbMajor.CompareMember = null;
            this.rGridCmbMajor.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridCmbMajor.NestedRadGridView
            // 
            this.rGridCmbMajor.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridCmbMajor.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridCmbMajor.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridCmbMajor.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // rGridCmbMajor.NestedRadGridView
            // 
            this.rGridCmbMajor.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridCmbMajor.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridCmbMajor.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridCmbMajor.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridCmbMajor.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridCmbMajor.EditorControl.MasterTemplate.EnableFiltering = true;
            this.rGridCmbMajor.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridCmbMajor.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridCmbMajor.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridCmbMajor.EditorControl.Name = "NestedRadGridView";
            this.rGridCmbMajor.EditorControl.ReadOnly = true;
            this.rGridCmbMajor.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridCmbMajor.EditorControl.ShowGroupPanel = false;
            this.rGridCmbMajor.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridCmbMajor.EditorControl.TabIndex = 0;
            this.rGridCmbMajor.FieldName = null;
            this.rGridCmbMajor.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridCmbMajor.Location = new System.Drawing.Point(12, 12);
            this.rGridCmbMajor.MaximumValue = null;
            this.rGridCmbMajor.MinimumValue = null;
            this.rGridCmbMajor.Name = "rGridCmbMajor";
            // 
            // 
            // 
            this.rGridCmbMajor.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridCmbMajor.ShowFilteringRow = true;
            this.rGridCmbMajor.ShowNullButton = false;
            this.rGridCmbMajor.Size = new System.Drawing.Size(722, 19);
            this.rGridCmbMajor.TabIndex = 4;
            this.rGridCmbMajor.TabStop = false;
            this.rGridCmbMajor.ValidatingProperty = null;
            this.rGridCmbMajor.ValidationType = rComponents.ValidationType.None;
            this.rGridCmbMajor.Value = null;
            this.rGridCmbMajor.SelectedIndexChanged += new System.EventHandler(this.rGridCmbMajor_SelectedIndexChanged);
            // 
            // lnkGenerate
            // 
            this.lnkGenerate.AutoSize = true;
            this.lnkGenerate.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkGenerate.Location = new System.Drawing.Point(12, 64);
            this.lnkGenerate.Name = "lnkGenerate";
            this.lnkGenerate.Size = new System.Drawing.Size(143, 13);
            this.lnkGenerate.TabIndex = 5;
            this.lnkGenerate.TabStop = true;
            this.lnkGenerate.Text = "ساخت تنظیمات آمـــوزشــــی";
            this.lnkGenerate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGenerate_LinkClicked);
            // 
            // frmStudentConfigurations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 457);
            this.Controls.Add(this.lnkGenerate);
            this.Controls.Add(this.rGridCmbMajor);
            this.Controls.Add(this.rLabel2);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.rGridCmbPeriod);
            this.Controls.Add(this.radPageView1);
            this.Name = "frmStudentConfigurations";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "تنظیمات آموزشی دانشجو";
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbPeriod.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbPeriod.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbMajor.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbMajor.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbMajor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private rComponents.rGridComboBox rGridCmbPeriod;
        private rComponents.rLabel rLabel1;
        private rComponents.rLabel rLabel2;
        private rComponents.rGridComboBox rGridCmbMajor;
        private rComponents.rGridView rGridView1;
        private System.Windows.Forms.LinkLabel lnkGenerate;
    }
}