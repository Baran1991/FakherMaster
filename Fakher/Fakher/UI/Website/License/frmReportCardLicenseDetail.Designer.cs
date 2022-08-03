namespace Fakher.UI.Website
{
    partial class frmReportCardLicenseDetail
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.majorSelector1 = new Fakher.Controls.MajorSelector();
            this.rGridComboBox1 = new rComponents.rGridComboBox(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rDatePicker1 = new rComponents.rDatePicker(this.components);
            this.rTxtStartTime = new rComponents.rTextBox(this.components);
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.rChkInternetReportCard = new rComponents.rCheckBox(this.components);
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.rGridView1 = new rComponents.rGridView();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            this.majorSelector1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rChkInternetReportCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 337);
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
            this.btnCancel.Location = new System.Drawing.Point(12, 337);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "انصــراف";
            // 
            // majorSelector1
            // 
            this.majorSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.majorSelector1.BackColor = System.Drawing.Color.Transparent;
            this.majorSelector1.Controls.Add(this.rGridComboBox1);
            this.majorSelector1.Controls.Add(this.rLabel1);
            this.majorSelector1.DepartmentSelector = null;
            this.majorSelector1.Location = new System.Drawing.Point(12, 12);
            this.majorSelector1.Name = "majorSelector1";
            this.majorSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.majorSelector1.ShowNullButton = false;
            this.majorSelector1.Size = new System.Drawing.Size(701, 25);
            this.majorSelector1.TabIndex = 0;
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
            gridViewTextBoxColumn3.FieldName = "Code";
            gridViewTextBoxColumn3.FormatString = "";
            gridViewTextBoxColumn3.HeaderText = "کد";
            gridViewTextBoxColumn3.Name = "کد";
            gridViewTextBoxColumn3.Width = 102;
            gridViewTextBoxColumn4.FieldName = "Name";
            gridViewTextBoxColumn4.FormatString = "";
            gridViewTextBoxColumn4.HeaderText = "نام رشته";
            gridViewTextBoxColumn4.Name = "نام رشته";
            gridViewTextBoxColumn4.Width = 102;
            this.rGridComboBox1.EditorControl.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
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
            this.rGridComboBox1.Location = new System.Drawing.Point(3, 3);
            this.rGridComboBox1.MaximumValue = null;
            this.rGridComboBox1.MinimumValue = null;
            this.rGridComboBox1.Name = "rGridComboBox1";
            // 
            // 
            // 
            this.rGridComboBox1.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridComboBox1.ShowFilteringRow = true;
            this.rGridComboBox1.ShowNullButton = false;
            this.rGridComboBox1.Size = new System.Drawing.Size(519, 19);
            this.rGridComboBox1.TabIndex = 1;
            this.rGridComboBox1.TabStop = false;
            this.rGridComboBox1.ValidatingProperty = null;
            this.rGridComboBox1.ValidationType = rComponents.ValidationType.None;
            this.rGridComboBox1.Value = null;
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.AutoSize = false;
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(528, 5);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(76, 17);
            this.rLabel1.TabIndex = 0;
            this.rLabel1.Text = "رشـــتـــه:";
            this.rLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // rDatePicker1
            // 
            this.rDatePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePicker1.Culture = null;
            this.rDatePicker1.FieldName = null;
            this.rDatePicker1.Location = new System.Drawing.Point(412, 43);
            this.rDatePicker1.Mask = "1###/##/##";
            this.rDatePicker1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePicker1.Name = "rDatePicker1";
            this.rDatePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePicker1.Size = new System.Drawing.Size(224, 19);
            this.rDatePicker1.TabIndex = 1;
            this.rDatePicker1.TabStop = false;
            this.rDatePicker1.Text = "1___/__/__";
            this.rDatePicker1.ValidationType = rComponents.ValidationType.None;
            this.rDatePicker1.Value = "";
            // 
            // rTxtStartTime
            // 
            this.rTxtStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtStartTime.Culture = null;
            this.rTxtStartTime.FieldName = null;
            this.rTxtStartTime.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTxtStartTime.Language = rComponents.TextboxLanguage.DontCare;
            this.rTxtStartTime.Location = new System.Drawing.Point(15, 43);
            this.rTxtStartTime.Mask = "HH:mm";
            this.rTxtStartTime.MaskType = Telerik.WinControls.UI.MaskType.DateTime;
            this.rTxtStartTime.MaximumValue = null;
            this.rTxtStartTime.MinimumValue = null;
            this.rTxtStartTime.Name = "rTxtStartTime";
            this.rTxtStartTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTxtStartTime.Size = new System.Drawing.Size(224, 19);
            this.rTxtStartTime.TabIndex = 2;
            this.rTxtStartTime.TabStop = false;
            this.rTxtStartTime.Type = rComponents.rTextBoxType.Time;
            this.rTxtStartTime.ValidatingProperty = null;
            this.rTxtStartTime.ValidationType = rComponents.ValidationType.None;
            // 
            // rLabel3
            // 
            this.rLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel3.BackColor = System.Drawing.Color.Transparent;
            this.rLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel3.Location = new System.Drawing.Point(245, 44);
            this.rLabel3.Name = "rLabel3";
            this.rLabel3.Size = new System.Drawing.Size(62, 17);
            this.rLabel3.TabIndex = 6;
            this.rLabel3.Text = "زمان شروع:";
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(642, 43);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(63, 17);
            this.rLabel2.TabIndex = 6;
            this.rLabel2.Text = "تاریخ شروع:";
            // 
            // rChkInternetReportCard
            // 
            this.rChkInternetReportCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rChkInternetReportCard.AutoSize = false;
            this.rChkInternetReportCard.BackColor = System.Drawing.Color.Transparent;
            this.rChkInternetReportCard.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rChkInternetReportCard.Location = new System.Drawing.Point(499, 72);
            this.rChkInternetReportCard.Name = "rChkInternetReportCard";
            this.rChkInternetReportCard.Size = new System.Drawing.Size(200, 17);
            this.rChkInternetReportCard.TabIndex = 3;
            this.rChkInternetReportCard.Text = "امکان مشاهده کارنامه کـــل";
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox1.Controls.Add(this.rGridView1);
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "+امکان مشاهده کارنامه آزمـــونهای زیر";
            this.rGroupBox1.Location = new System.Drawing.Point(12, 95);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(701, 236);
            this.rGroupBox1.TabIndex = 4;
            this.rGroupBox1.Text = "+امکان مشاهده کارنامه آزمـــونهای زیر";
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
            this.rGridView1.CustomAddText = null;
            this.rGridView1.CustomDeleteText = null;
            this.rGridView1.CustomEditText = null;
            this.rGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView1.EditOnDoubleClick = true;
            this.rGridView1.FieldName = null;
            this.rGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView1.ItemImage = null;
            this.rGridView1.Location = new System.Drawing.Point(2, 20);
            this.rGridView1.MultiSelect = false;
            this.rGridView1.Name = "rGridView1";
            this.rGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView1.RowHeight = 25;
            this.rGridView1.ShowBottomToolbar = false;
            this.rGridView1.ShowGroupPanel = true;
            this.rGridView1.ShowTopToolbar = true;
            this.rGridView1.Size = new System.Drawing.Size(697, 214);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Delete += new System.EventHandler(this.rGridView1_Delete);
            this.rGridView1.Add += new System.EventHandler(this.rGridView1_Add);
            // 
            // frmReportCardLicenseDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 373);
            this.Controls.Add(this.rGroupBox1);
            this.Controls.Add(this.rDatePicker1);
            this.Controls.Add(this.rChkInternetReportCard);
            this.Controls.Add(this.rTxtStartTime);
            this.Controls.Add(this.rLabel3);
            this.Controls.Add(this.rLabel2);
            this.Controls.Add(this.majorSelector1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Name = "frmReportCardLicenseDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات مجوز کارنامه اینترنتی";
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            this.majorSelector1.ResumeLayout(false);
            this.majorSelector1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rChkInternetReportCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Fakher.Controls.MajorSelector majorSelector1;
        private rComponents.rGridComboBox rGridComboBox1;
        private rComponents.rLabel rLabel1;
        private rComponents.rDatePicker rDatePicker1;
        private rComponents.rTextBox rTxtStartTime;
        private rComponents.rLabel rLabel3;
        private rComponents.rLabel rLabel2;
        private rComponents.rCheckBox rChkInternetReportCard;
        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rGridView rGridView1;
    }
}