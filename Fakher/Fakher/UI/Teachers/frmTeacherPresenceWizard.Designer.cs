namespace Fakher.UI.Teachers
{
    partial class frmTeacherPresenceWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTeacherPresenceWizard));
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGroupBox2 = new rComponents.rGroupBox(this.components);
            this.rGridView1 = new rComponents.rGridView();
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.radBtnCalculate = new Telerik.WinControls.UI.RadButton();
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rTextBox1 = new rComponents.rTextBox(this.components);
            this.lnkSelectFile = new System.Windows.Forms.LinkLabel();
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.rGridComboBoxTeacher = new rComponents.rGridComboBox(this.components);
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).BeginInit();
            this.rGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnCalculate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxTeacher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxTeacher.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxTeacher.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
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
            this.radPageView1.Location = new System.Drawing.Point(12, 12);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage1;
            this.radPageView1.Size = new System.Drawing.Size(928, 508);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.Text = "radPageView1";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.rGroupBox2);
            this.radPageViewPage1.Controls.Add(this.rGroupBox1);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(907, 461);
            this.radPageViewPage1.Text = "ثبت حضور مدرس از دستگاه حضور و غیاب";
            // 
            // rGroupBox2
            // 
            this.rGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox2.Controls.Add(this.rGridView1);
            this.rGroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox2.FooterImageIndex = -1;
            this.rGroupBox2.FooterImageKey = "";
            this.rGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox2.HeaderImageIndex = -1;
            this.rGroupBox2.HeaderImageKey = "";
            this.rGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox2.HeaderText = "ساعات حضور";
            this.rGroupBox2.Location = new System.Drawing.Point(3, 131);
            this.rGroupBox2.Name = "rGroupBox2";
            this.rGroupBox2.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox2.Size = new System.Drawing.Size(901, 327);
            this.rGroupBox2.TabIndex = 1;
            this.rGroupBox2.Text = "ساعات حضور";
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
            this.rGridView1.Location = new System.Drawing.Point(2, 20);
            this.rGridView1.MultiSelect = false;
            this.rGridView1.Name = "rGridView1";
            this.rGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView1.RowHeight = 25;
            this.rGridView1.ShowBottomToolbar = false;
            this.rGridView1.ShowGroupPanel = true;
            this.rGridView1.ShowTopToolbar = true;
            this.rGridView1.Size = new System.Drawing.Size(897, 305);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Delete += new System.EventHandler(this.rGridView1_Delete);
            this.rGridView1.Edit += new System.EventHandler(this.rGridView1_Edit);
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox1.Controls.Add(this.rGridComboBoxTeacher);
            this.rGroupBox1.Controls.Add(this.rLabel2);
            this.rGroupBox1.Controls.Add(this.radBtnCalculate);
            this.rGroupBox1.Controls.Add(this.rLabel3);
            this.rGroupBox1.Controls.Add(this.rLabel1);
            this.rGroupBox1.Controls.Add(this.rTextBox1);
            this.rGroupBox1.Controls.Add(this.lnkSelectFile);
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "تنظیمات";
            this.rGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(901, 122);
            this.rGroupBox1.TabIndex = 0;
            this.rGroupBox1.Text = "تنظیمات";
            // 
            // radBtnCalculate
            // 
            this.radBtnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radBtnCalculate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radBtnCalculate.Image = ((System.Drawing.Image)(resources.GetObject("radBtnCalculate.Image")));
            this.radBtnCalculate.Location = new System.Drawing.Point(5, 93);
            this.radBtnCalculate.Name = "radBtnCalculate";
            this.radBtnCalculate.Size = new System.Drawing.Size(130, 24);
            this.radBtnCalculate.TabIndex = 2;
            this.radBtnCalculate.Text = "محــــاسبـــــه";
            this.radBtnCalculate.Click += new System.EventHandler(this.radBtnCalculate_Click);
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(833, 56);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(53, 17);
            this.rLabel1.TabIndex = 3;
            this.rLabel1.Text = "فایل CSV:";
            // 
            // rTextBox1
            // 
            this.rTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox1.Culture = null;
            this.rTextBox1.FieldName = null;
            this.rTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox1.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox1.Location = new System.Drawing.Point(116, 55);
            this.rTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox1.MaximumValue = null;
            this.rTextBox1.MinimumValue = null;
            this.rTextBox1.Name = "rTextBox1";
            this.rTextBox1.ReadOnly = true;
            this.rTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox1.Size = new System.Drawing.Size(711, 19);
            this.rTextBox1.TabIndex = 2;
            this.rTextBox1.TabStop = false;
            this.rTextBox1.Type = rComponents.rTextBoxType.Text;
            this.rTextBox1.ValidatingProperty = null;
            this.rTextBox1.ValidationType = rComponents.ValidationType.None;
            // 
            // lnkSelectFile
            // 
            this.lnkSelectFile.AutoSize = true;
            this.lnkSelectFile.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkSelectFile.Location = new System.Drawing.Point(13, 58);
            this.lnkSelectFile.Name = "lnkSelectFile";
            this.lnkSelectFile.Size = new System.Drawing.Size(97, 13);
            this.lnkSelectFile.TabIndex = 1;
            this.lnkSelectFile.TabStop = true;
            this.lnkSelectFile.Text = "انتخــــاب فــــایـــــل";
            this.lnkSelectFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSelectFile_LinkClicked);
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLabel2.ForeColor = System.Drawing.Color.Red;
            this.rLabel2.Location = new System.Drawing.Point(207, 80);
            this.rLabel2.Name = "rLabel2";
            // 
            // 
            // 
            this.rLabel2.RootElement.ForeColor = System.Drawing.Color.Red;
            this.rLabel2.Size = new System.Drawing.Size(620, 19);
            this.rLabel2.TabIndex = 5;
            this.rLabel2.Text = "ستونهای فایل CSV باید به ترتیب تاریخ، زمان ورود و زمان خروج باشد. ستونها باید بدو" +
                "ن عنوان باشند";
            // 
            // rLabel3
            // 
            this.rLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel3.BackColor = System.Drawing.Color.Transparent;
            this.rLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel3.Location = new System.Drawing.Point(833, 23);
            this.rLabel3.Name = "rLabel3";
            this.rLabel3.Size = new System.Drawing.Size(52, 17);
            this.rLabel3.TabIndex = 3;
            this.rLabel3.Text = "مــــدرس:";
            // 
            // rGridComboBoxTeacher
            // 
            this.rGridComboBoxTeacher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridComboBoxTeacher.CompareMember = null;
            this.rGridComboBoxTeacher.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridComboBoxTeacher.NestedRadGridView
            // 
            this.rGridComboBoxTeacher.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridComboBoxTeacher.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBoxTeacher.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridComboBoxTeacher.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // rGridComboBoxTeacher.NestedRadGridView
            // 
            this.rGridComboBoxTeacher.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridComboBoxTeacher.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridComboBoxTeacher.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridComboBoxTeacher.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridComboBoxTeacher.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridComboBoxTeacher.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridComboBoxTeacher.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBoxTeacher.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBoxTeacher.EditorControl.Name = "NestedRadGridView";
            this.rGridComboBoxTeacher.EditorControl.ReadOnly = true;
            this.rGridComboBoxTeacher.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridComboBoxTeacher.EditorControl.ShowGroupPanel = false;
            this.rGridComboBoxTeacher.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridComboBoxTeacher.EditorControl.TabIndex = 0;
            this.rGridComboBoxTeacher.FieldName = null;
            this.rGridComboBoxTeacher.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBoxTeacher.Location = new System.Drawing.Point(116, 23);
            this.rGridComboBoxTeacher.MaximumValue = null;
            this.rGridComboBoxTeacher.MinimumValue = null;
            this.rGridComboBoxTeacher.Name = "rGridComboBoxTeacher";
            // 
            // 
            // 
            this.rGridComboBoxTeacher.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridComboBoxTeacher.ShowFilteringRow = true;
            this.rGridComboBoxTeacher.ShowNullButton = false;
            this.rGridComboBoxTeacher.Size = new System.Drawing.Size(711, 19);
            this.rGridComboBoxTeacher.TabIndex = 0;
            this.rGridComboBoxTeacher.TabStop = false;
            this.rGridComboBoxTeacher.ValidatingProperty = null;
            this.rGridComboBoxTeacher.ValidationType = rComponents.ValidationType.None;
            this.rGridComboBoxTeacher.Value = null;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 526);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "تــایــیــد";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // radButton1
            // 
            this.radButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.radButton1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radButton1.Location = new System.Drawing.Point(12, 526);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(130, 24);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "انصــراف";
            // 
            // frmTeacherPresenceWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 562);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.radPageView1);
            this.Name = "frmTeacherPresenceWizard";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "جادوگر ثبت حضور مدرس";
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).EndInit();
            this.rGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            this.rGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnCalculate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxTeacher.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxTeacher.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxTeacher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rLabel rLabel1;
        private rComponents.rTextBox rTextBox1;
        private System.Windows.Forms.LinkLabel lnkSelectFile;
        private rComponents.rGroupBox rGroupBox2;
        private rComponents.rGridView rGridView1;
        private Telerik.WinControls.UI.RadButton radBtnCalculate;
        private rComponents.rGridComboBox rGridComboBoxTeacher;
        private rComponents.rLabel rLabel2;
        private rComponents.rLabel rLabel3;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}