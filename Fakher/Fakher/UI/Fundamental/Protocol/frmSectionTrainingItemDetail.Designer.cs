namespace Fakher.UI.Educational
{
    partial class frmSectionTrainingItemDetail
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
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.rTextBox1 = new rComponents.rTextBox(this.components);
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.rTextBox2 = new rComponents.rTextBox(this.components);
            this.rGridComboBox1 = new rComponents.rGridComboBox(this.components);
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView1 = new rComponents.rGridView();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            this.radPageViewPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 225);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "تــایــیــد";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(12, 225);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "انصــراف";
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(465, 3);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(33, 17);
            this.rLabel1.TabIndex = 5;
            this.rLabel1.Text = "درس:";
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(465, 30);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(51, 17);
            this.rLabel2.TabIndex = 7;
            this.rLabel2.Text = "از جلسه:";
            // 
            // rTextBox1
            // 
            this.rTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox1.Culture = null;
            this.rTextBox1.FieldName = "جلسه شروع";
            this.rTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox1.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox1.Location = new System.Drawing.Point(273, 28);
            this.rTextBox1.Mask = "D";
            this.rTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.rTextBox1.MaximumValue = null;
            this.rTextBox1.MinimumValue = "1";
            this.rTextBox1.Name = "rTextBox1";
            this.rTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox1.Size = new System.Drawing.Size(186, 19);
            this.rTextBox1.TabIndex = 1;
            this.rTextBox1.TabStop = false;
            this.rTextBox1.Type = rComponents.rTextBoxType.Numeric;
            this.rTextBox1.ValidatingProperty = null;
            this.rTextBox1.ValidationType = rComponents.ValidationType.InRange;
            // 
            // rLabel3
            // 
            this.rLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel3.BackColor = System.Drawing.Color.Transparent;
            this.rLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel3.Location = new System.Drawing.Point(193, 30);
            this.rLabel3.Name = "rLabel3";
            this.rLabel3.Size = new System.Drawing.Size(50, 17);
            this.rLabel3.TabIndex = 7;
            this.rLabel3.Text = "تا جلسه:";
            // 
            // rTextBox2
            // 
            this.rTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox2.Culture = null;
            this.rTextBox2.FieldName = "جلسه پایان";
            this.rTextBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox2.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox2.Location = new System.Drawing.Point(8, 28);
            this.rTextBox2.Mask = "D";
            this.rTextBox2.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.rTextBox2.MaximumValue = null;
            this.rTextBox2.MinimumValue = "1";
            this.rTextBox2.Name = "rTextBox2";
            this.rTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox2.Size = new System.Drawing.Size(179, 19);
            this.rTextBox2.TabIndex = 2;
            this.rTextBox2.TabStop = false;
            this.rTextBox2.Type = rComponents.rTextBoxType.Numeric;
            this.rTextBox2.ValidatingProperty = null;
            this.rTextBox2.ValidationType = rComponents.ValidationType.InRange;
            // 
            // rGridComboBox1
            // 
            this.rGridComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridComboBox1.CompareMember = null;
            this.rGridComboBox1.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridComboBox1.NestedRadGridView
            // 
            this.rGridComboBox1.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridComboBox1.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBox1.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridComboBox1.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rGridComboBox1.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridComboBox1.EditorControl.MasterTemplate.EnableFiltering = true;
            this.rGridComboBox1.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBox1.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBox1.EditorControl.Name = "NestedRadGridView";
            this.rGridComboBox1.EditorControl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.rGridComboBox1.EditorControl.ReadOnly = true;
            this.rGridComboBox1.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.rGridComboBox1.EditorControl.RootElement.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.rGridComboBox1.EditorControl.ShowGroupPanel = false;
            this.rGridComboBox1.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridComboBox1.EditorControl.TabIndex = 0;
            this.rGridComboBox1.FieldName = null;
            this.rGridComboBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBox1.Location = new System.Drawing.Point(8, 3);
            this.rGridComboBox1.MaximumValue = null;
            this.rGridComboBox1.MinimumValue = null;
            this.rGridComboBox1.Name = "rGridComboBox1";
            // 
            // 
            // 
            this.rGridComboBox1.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridComboBox1.ShowFilteringRow = true;
            this.rGridComboBox1.ShowNullButton = false;
            this.rGridComboBox1.Size = new System.Drawing.Size(451, 19);
            this.rGridComboBox1.TabIndex = 0;
            this.rGridComboBox1.TabStop = false;
            this.rGridComboBox1.ValidatingProperty = null;
            this.rGridComboBox1.ValidationType = rComponents.ValidationType.None;
            this.rGridComboBox1.Value = null;
            // 
            // radPageView1
            // 
            this.radPageView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Controls.Add(this.radPageViewPage2);
            this.radPageView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radPageView1.Location = new System.Drawing.Point(12, 12);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage1;
            this.radPageView1.Size = new System.Drawing.Size(662, 207);
            this.radPageView1.TabIndex = 11;
            this.radPageView1.Text = "radPageView1";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Right;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.rGridComboBox1);
            this.radPageViewPage1.Controls.Add(this.rLabel1);
            this.radPageViewPage1.Controls.Add(this.rLabel2);
            this.radPageViewPage1.Controls.Add(this.rTextBox2);
            this.radPageViewPage1.Controls.Add(this.rLabel3);
            this.radPageViewPage1.Controls.Add(this.rTextBox1);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 10);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(519, 186);
            this.radPageViewPage1.Text = "مشخصات آیتم کلاسی";
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.rGridView1);
            this.radPageViewPage2.Location = new System.Drawing.Point(10, 10);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(519, 186);
            this.radPageViewPage2.Text = "شـــهـــریـــه";
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
            this.rGridView1.Size = new System.Drawing.Size(519, 186);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Add += new System.EventHandler(this.rGridView1_Add);
            this.rGridView1.Edit += new System.EventHandler(this.rGridView1_Edit);
            this.rGridView1.Delete += new System.EventHandler(this.rGridView1_Delete);
            // 
            // frmSectionTrainingItemDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 261);
            this.Controls.Add(this.radPageView1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Name = "frmSectionTrainingItemDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات آیتم کلاسی";
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage1.PerformLayout();
            this.radPageViewPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private rComponents.rLabel rLabel1;
        private rComponents.rLabel rLabel2;
        private rComponents.rTextBox rTextBox1;
        private rComponents.rLabel rLabel3;
        private rComponents.rTextBox rTextBox2;
        private rComponents.rGridComboBox rGridComboBox1;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private rComponents.rGridView rGridView1;
    }
}