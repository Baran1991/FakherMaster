namespace Fakher.UI.Website.License
{
    partial class frmMarkEntryLicenseDetail
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
            this.rGroupBox2 = new rComponents.rGroupBox(this.components);
            this.lessonSelector1 = new Fakher.Controls.LessonSelector();
            this.majorSelector1 = new Fakher.Controls.MajorSelector();
            this.rGridComboBoxItem = new rComponents.rGridComboBox(this.components);
            this.rLabel4 = new rComponents.rLabel(this.components);
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.rDatePicker2 = new rComponents.rDatePicker(this.components);
            this.rDatePicker1 = new rComponents.rDatePicker(this.components);
            this.rTxtEndTime = new rComponents.rTextBox(this.components);
            this.rLabel5 = new rComponents.rLabel(this.components);
            this.rTxtStartTime = new rComponents.rTextBox(this.components);
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.rLabel6 = new rComponents.rLabel(this.components);
            this.rTextBox1 = new rComponents.rTextBox(this.components);
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.rLabel7 = new rComponents.rLabel(this.components);
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.rLabel8 = new rComponents.rLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).BeginInit();
            this.rGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxItem.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxItem.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtEndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rGroupBox2
            // 
            this.rGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox2.Controls.Add(this.lessonSelector1);
            this.rGroupBox2.Controls.Add(this.majorSelector1);
            this.rGroupBox2.Controls.Add(this.rGridComboBoxItem);
            this.rGroupBox2.Controls.Add(this.rLabel4);
            this.rGroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox2.FooterImageIndex = -1;
            this.rGroupBox2.FooterImageKey = "";
            this.rGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox2.HeaderImageIndex = -1;
            this.rGroupBox2.HeaderImageKey = "";
            this.rGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox2.HeaderText = "تنظیمات";
            this.rGroupBox2.Location = new System.Drawing.Point(12, 37);
            this.rGroupBox2.Name = "rGroupBox2";
            this.rGroupBox2.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox2.Size = new System.Drawing.Size(625, 117);
            this.rGroupBox2.TabIndex = 0;
            this.rGroupBox2.Text = "تنظیمات";
            // 
            // lessonSelector1
            // 
            this.lessonSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lessonSelector1.BackColor = System.Drawing.Color.Transparent;
            this.lessonSelector1.Location = new System.Drawing.Point(5, 54);
            this.lessonSelector1.MajorSelector = this.majorSelector1;
            this.lessonSelector1.Name = "lessonSelector1";
            this.lessonSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lessonSelector1.ShowAllLessons = false;
            this.lessonSelector1.ShowExamHoldingLessons = false;
            this.lessonSelector1.ShowNullButton = false;
            this.lessonSelector1.Size = new System.Drawing.Size(615, 24);
            this.lessonSelector1.TabIndex = 7;
            this.lessonSelector1.SelectedChanged += new System.EventHandler(this.lessonSelector1_SelectedChanged);
            // 
            // majorSelector1
            // 
            this.majorSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.majorSelector1.BackColor = System.Drawing.Color.Transparent;
            this.majorSelector1.DepartmentSelector = null;
            this.majorSelector1.Location = new System.Drawing.Point(5, 23);
            this.majorSelector1.Name = "majorSelector1";
            this.majorSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.majorSelector1.ShowNullButton = false;
            this.majorSelector1.Size = new System.Drawing.Size(615, 25);
            this.majorSelector1.TabIndex = 6;
            // 
            // rGridComboBoxItem
            // 
            this.rGridComboBoxItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridComboBoxItem.CompareMember = null;
            this.rGridComboBoxItem.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridComboBoxItem.NestedRadGridView
            // 
            this.rGridComboBoxItem.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridComboBoxItem.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBoxItem.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridComboBoxItem.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rGridComboBoxItem.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridComboBoxItem.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridComboBoxItem.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridComboBoxItem.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridComboBoxItem.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridComboBoxItem.EditorControl.MasterTemplate.EnableFiltering = true;
            this.rGridComboBoxItem.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridComboBoxItem.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBoxItem.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBoxItem.EditorControl.Name = "NestedRadGridView";
            this.rGridComboBoxItem.EditorControl.ReadOnly = true;
            this.rGridComboBoxItem.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridComboBoxItem.EditorControl.ShowGroupPanel = false;
            this.rGridComboBoxItem.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridComboBoxItem.EditorControl.TabIndex = 0;
            this.rGridComboBoxItem.FieldName = "آیتم ارزشیابی";
            this.rGridComboBoxItem.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBoxItem.Location = new System.Drawing.Point(8, 87);
            this.rGridComboBoxItem.MaximumValue = null;
            this.rGridComboBoxItem.MinimumValue = null;
            this.rGridComboBoxItem.Name = "rGridComboBoxItem";
            // 
            // 
            // 
            this.rGridComboBoxItem.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridComboBoxItem.ShowFilteringRow = true;
            this.rGridComboBoxItem.ShowNullButton = false;
            this.rGridComboBoxItem.Size = new System.Drawing.Size(527, 19);
            this.rGridComboBoxItem.TabIndex = 2;
            this.rGridComboBoxItem.TabStop = false;
            this.rGridComboBoxItem.ValidatingProperty = null;
            this.rGridComboBoxItem.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rGridComboBoxItem.Value = null;
            // 
            // rLabel4
            // 
            this.rLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel4.BackColor = System.Drawing.Color.Transparent;
            this.rLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel4.Location = new System.Drawing.Point(543, 89);
            this.rLabel4.Name = "rLabel4";
            this.rLabel4.Size = new System.Drawing.Size(75, 17);
            this.rLabel4.TabIndex = 5;
            this.rLabel4.Text = "آیتم ارزشیابی:";
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox1.Controls.Add(this.rDatePicker2);
            this.rGroupBox1.Controls.Add(this.rDatePicker1);
            this.rGroupBox1.Controls.Add(this.rTxtEndTime);
            this.rGroupBox1.Controls.Add(this.rLabel5);
            this.rGroupBox1.Controls.Add(this.rTxtStartTime);
            this.rGroupBox1.Controls.Add(this.rLabel3);
            this.rGroupBox1.Controls.Add(this.rLabel2);
            this.rGroupBox1.Controls.Add(this.rLabel6);
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "تاریخ شـروع و پـایـان";
            this.rGroupBox1.Location = new System.Drawing.Point(12, 160);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(625, 90);
            this.rGroupBox1.TabIndex = 1;
            this.rGroupBox1.Text = "تاریخ شـروع و پـایـان";
            // 
            // rDatePicker2
            // 
            this.rDatePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePicker2.Culture = null;
            this.rDatePicker2.FieldName = "تاریخ پایان";
            this.rDatePicker2.Location = new System.Drawing.Point(321, 53);
            this.rDatePicker2.Mask = "1###/##/##";
            this.rDatePicker2.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePicker2.Name = "rDatePicker2";
            this.rDatePicker2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePicker2.Size = new System.Drawing.Size(214, 19);
            this.rDatePicker2.TabIndex = 2;
            this.rDatePicker2.TabStop = false;
            this.rDatePicker2.Text = "1___/__/__";
            this.rDatePicker2.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rDatePicker2.Value = "";
            // 
            // rDatePicker1
            // 
            this.rDatePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePicker1.Culture = null;
            this.rDatePicker1.FieldName = "تاریخ شروع";
            this.rDatePicker1.Location = new System.Drawing.Point(321, 28);
            this.rDatePicker1.Mask = "1###/##/##";
            this.rDatePicker1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePicker1.Name = "rDatePicker1";
            this.rDatePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePicker1.Size = new System.Drawing.Size(214, 19);
            this.rDatePicker1.TabIndex = 0;
            this.rDatePicker1.TabStop = false;
            this.rDatePicker1.Text = "1___/__/__";
            this.rDatePicker1.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rDatePicker1.Value = "";
            // 
            // rTxtEndTime
            // 
            this.rTxtEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtEndTime.Culture = null;
            this.rTxtEndTime.FieldName = "زمان پایان";
            this.rTxtEndTime.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTxtEndTime.Language = rComponents.TextboxLanguage.DontCare;
            this.rTxtEndTime.Location = new System.Drawing.Point(9, 53);
            this.rTxtEndTime.Mask = "HH:mm";
            this.rTxtEndTime.MaskType = Telerik.WinControls.UI.MaskType.DateTime;
            this.rTxtEndTime.MaximumValue = null;
            this.rTxtEndTime.MinimumValue = null;
            this.rTxtEndTime.Name = "rTxtEndTime";
            this.rTxtEndTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTxtEndTime.Size = new System.Drawing.Size(220, 19);
            this.rTxtEndTime.TabIndex = 3;
            this.rTxtEndTime.TabStop = false;
            this.rTxtEndTime.Type = rComponents.rTextBoxType.Time;
            this.rTxtEndTime.ValidatingProperty = null;
            this.rTxtEndTime.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // rLabel5
            // 
            this.rLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel5.BackColor = System.Drawing.Color.Transparent;
            this.rLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel5.Location = new System.Drawing.Point(235, 54);
            this.rLabel5.Name = "rLabel5";
            this.rLabel5.Size = new System.Drawing.Size(55, 17);
            this.rLabel5.TabIndex = 6;
            this.rLabel5.Text = "زمان پایان:";
            // 
            // rTxtStartTime
            // 
            this.rTxtStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtStartTime.Culture = null;
            this.rTxtStartTime.FieldName = "زمان شروع";
            this.rTxtStartTime.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTxtStartTime.Language = rComponents.TextboxLanguage.DontCare;
            this.rTxtStartTime.Location = new System.Drawing.Point(9, 28);
            this.rTxtStartTime.Mask = "HH:mm";
            this.rTxtStartTime.MaskType = Telerik.WinControls.UI.MaskType.DateTime;
            this.rTxtStartTime.MaximumValue = null;
            this.rTxtStartTime.MinimumValue = null;
            this.rTxtStartTime.Name = "rTxtStartTime";
            this.rTxtStartTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTxtStartTime.Size = new System.Drawing.Size(220, 19);
            this.rTxtStartTime.TabIndex = 1;
            this.rTxtStartTime.TabStop = false;
            this.rTxtStartTime.Type = rComponents.rTextBoxType.Time;
            this.rTxtStartTime.ValidatingProperty = null;
            this.rTxtStartTime.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // rLabel3
            // 
            this.rLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel3.BackColor = System.Drawing.Color.Transparent;
            this.rLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel3.Location = new System.Drawing.Point(235, 29);
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
            this.rLabel2.Location = new System.Drawing.Point(542, 53);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(56, 17);
            this.rLabel2.TabIndex = 6;
            this.rLabel2.Text = "تاریخ پایان:";
            // 
            // rLabel6
            // 
            this.rLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel6.BackColor = System.Drawing.Color.Transparent;
            this.rLabel6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel6.Location = new System.Drawing.Point(542, 28);
            this.rLabel6.Name = "rLabel6";
            this.rLabel6.Size = new System.Drawing.Size(63, 17);
            this.rLabel6.TabIndex = 6;
            this.rLabel6.Text = "تاریخ شروع:";
            // 
            // rTextBox1
            // 
            this.rTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox1.Culture = null;
            this.rTextBox1.FieldName = "کد نمره";
            this.rTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox1.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox1.Location = new System.Drawing.Point(333, 12);
            this.rTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox1.MaximumValue = null;
            this.rTextBox1.MinimumValue = null;
            this.rTextBox1.Name = "rTextBox1";
            this.rTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rTextBox1.Size = new System.Drawing.Size(205, 19);
            this.rTextBox1.TabIndex = 19;
            this.rTextBox1.TabStop = false;
            this.rTextBox1.Type = rComponents.rTextBoxType.Text;
            this.rTextBox1.ValidatingProperty = null;
            this.rTextBox1.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 289);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "تــایــیــد";
            // 
            // rLabel7
            // 
            this.rLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel7.BackColor = System.Drawing.Color.Transparent;
            this.rLabel7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel7.Location = new System.Drawing.Point(545, 13);
            this.rLabel7.Name = "rLabel7";
            this.rLabel7.Size = new System.Drawing.Size(91, 17);
            this.rLabel7.TabIndex = 10;
            this.rLabel7.Text = "کـــــد ورود نمـــره:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(12, 289);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "انصــراف";
            // 
            // rLabel8
            // 
            this.rLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel8.AutoSize = false;
            this.rLabel8.BackColor = System.Drawing.Color.Black;
            this.rLabel8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel8.Location = new System.Drawing.Point(-2, 280);
            this.rLabel8.Name = "rLabel8";
            this.rLabel8.Size = new System.Drawing.Size(652, 3);
            this.rLabel8.TabIndex = 11;
            // 
            // frmMarkEntryLicenseDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 325);
            this.Controls.Add(this.rLabel8);
            this.Controls.Add(this.rTextBox1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rLabel7);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rGroupBox1);
            this.Controls.Add(this.rGroupBox2);
            this.Name = "frmMarkEntryLicenseDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات مجوز ورود نمره";
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).EndInit();
            this.rGroupBox2.ResumeLayout(false);
            this.rGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxItem.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxItem.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            this.rGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtEndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rGroupBox rGroupBox2;
        private rComponents.rLabel rLabel4;
        private rComponents.rGridComboBox rGridComboBoxItem;
        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rDatePicker rDatePicker2;
        private rComponents.rDatePicker rDatePicker1;
        private rComponents.rTextBox rTxtEndTime;
        private rComponents.rLabel rLabel5;
        private rComponents.rTextBox rTxtStartTime;
        private rComponents.rLabel rLabel3;
        private rComponents.rLabel rLabel2;
        private rComponents.rLabel rLabel6;
        private rComponents.rTextBox rTextBox1;
        private Telerik.WinControls.UI.RadButton btnOk;
        private rComponents.rLabel rLabel7;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private rComponents.rLabel rLabel8;
        private Fakher.Controls.LessonSelector lessonSelector1;
        private Fakher.Controls.MajorSelector majorSelector1;
    }
}