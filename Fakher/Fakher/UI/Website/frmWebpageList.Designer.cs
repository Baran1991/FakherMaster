namespace Fakher.UI.Website
{
    partial class frmWebpageList
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
            this.rGridView1 = new rComponents.rGridView();
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rGridCmbSection = new rComponents.rGridComboBox(this.components);
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView2 = new rComponents.rGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbSection.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbSection.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            this.radPageViewPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rGridView1
            // 
            this.rGridView1.CanAdd = true;
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
            this.rGridView1.Size = new System.Drawing.Size(764, 369);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Delete += new System.EventHandler(this.rGridView1_Delete);
            this.rGridView1.Edit += new System.EventHandler(this.rGridView1_Edit);
            this.rGridView1.Add += new System.EventHandler(this.rGridView1_Add);
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(753, 14);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(44, 17);
            this.rLabel1.TabIndex = 1;
            this.rLabel1.Text = "بخـــش:";
            // 
            // rGridCmbSection
            // 
            this.rGridCmbSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridCmbSection.CompareMember = null;
            this.rGridCmbSection.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridCmbSection.NestedRadGridView
            // 
            this.rGridCmbSection.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridCmbSection.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridCmbSection.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridCmbSection.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rGridCmbSection.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridCmbSection.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridCmbSection.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridCmbSection.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridCmbSection.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridCmbSection.EditorControl.MasterTemplate.EnableFiltering = true;
            this.rGridCmbSection.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridCmbSection.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridCmbSection.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridCmbSection.EditorControl.Name = "NestedRadGridView";
            this.rGridCmbSection.EditorControl.ReadOnly = true;
            this.rGridCmbSection.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridCmbSection.EditorControl.ShowGroupPanel = false;
            this.rGridCmbSection.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridCmbSection.EditorControl.TabIndex = 0;
            this.rGridCmbSection.FieldName = null;
            this.rGridCmbSection.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridCmbSection.Location = new System.Drawing.Point(12, 12);
            this.rGridCmbSection.MaximumValue = null;
            this.rGridCmbSection.MinimumValue = null;
            this.rGridCmbSection.Name = "rGridCmbSection";
            // 
            // 
            // 
            this.rGridCmbSection.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridCmbSection.ShowFilteringRow = true;
            this.rGridCmbSection.ShowNullButton = false;
            this.rGridCmbSection.Size = new System.Drawing.Size(735, 19);
            this.rGridCmbSection.TabIndex = 2;
            this.rGridCmbSection.TabStop = false;
            this.rGridCmbSection.ValidatingProperty = null;
            this.rGridCmbSection.ValidationType = rComponents.ValidationType.None;
            this.rGridCmbSection.Value = null;
            this.rGridCmbSection.SelectedIndexChanged += new System.EventHandler(this.rGridCmbSection_SelectedIndexChanged);
            // 
            // radPageView1
            // 
            this.radPageView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Controls.Add(this.radPageViewPage2);
            this.radPageView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radPageView1.Location = new System.Drawing.Point(12, 37);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage2;
            this.radPageView1.Size = new System.Drawing.Size(785, 416);
            this.radPageView1.TabIndex = 3;
            this.radPageView1.Text = "radPageView1";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.rGridView1);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(764, 369);
            this.radPageViewPage1.Text = "صفـحــات بخـــــش";
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.rGridView2);
            this.radPageViewPage2.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(764, 369);
            this.radPageViewPage2.Text = "مقــالـات بخــــــش";
            // 
            // rGridView2
            // 
            this.rGridView2.CanAdd = true;
            this.rGridView2.CanDelete = true;
            this.rGridView2.CanEdit = true;
            this.rGridView2.CanExport = true;
            this.rGridView2.CanFilter = true;
            this.rGridView2.CanGroup = false;
            this.rGridView2.CanNavigate = true;
            this.rGridView2.CheckBoxes = false;
            this.rGridView2.ColumnAutoSize = true;
            this.rGridView2.ConfirmOnDelete = true;
            this.rGridView2.CustomAddText = null;
            this.rGridView2.CustomDeleteText = null;
            this.rGridView2.CustomEditText = null;
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
            this.rGridView2.Size = new System.Drawing.Size(764, 369);
            this.rGridView2.TabIndex = 1;
            this.rGridView2.ValidationType = rComponents.ValidationType.None;
            this.rGridView2.Delete += new System.EventHandler(this.rGridView2_Delete);
            this.rGridView2.Edit += new System.EventHandler(this.rGridView2_Edit);
            this.rGridView2.Add += new System.EventHandler(this.rGridView2_Add);
            // 
            // frmWebpageList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 465);
            this.Controls.Add(this.radPageView1);
            this.Controls.Add(this.rGridCmbSection);
            this.Controls.Add(this.rLabel1);
            this.Name = "frmWebpageList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "لیست صفحات و مطالب بخش هـــا";
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbSection.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbSection.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rGridView rGridView1;
        private rComponents.rLabel rLabel1;
        private rComponents.rGridComboBox rGridCmbSection;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private rComponents.rGridView rGridView2;
    }
}