using rComponents;

namespace Fakher.UI.Struture
{
    partial class frmLessonDetail
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
            this.radTextBox1 = new rComponents.rTextBox(this.components);
            this.radLabel1 = new rComponents.rLabel(this.components);
            this.radLabel2 = new rComponents.rLabel(this.components);
            this.radTextBox2 = new rComponents.rTextBox(this.components);
            this.radGroupBox1 = new rComponents.rGroupBox(this.components);
            this.rGridView1 = new rComponents.rGridView();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rComboBox1 = new rComponents.rComboBox(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rCheckBox1 = new rComponents.rCheckBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            this.radPageViewPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rCheckBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 381);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "تــایــیــد";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(12, 381);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "انصــراف";
            // 
            // radTextBox1
            // 
            this.radTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.radTextBox1.Culture = null;
            this.radTextBox1.FieldName = "کد درس";
            this.radTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radTextBox1.Language = rComponents.TextboxLanguage.DontCare;
            this.radTextBox1.Location = new System.Drawing.Point(322, 7);
            this.radTextBox1.Mask = "D";
            this.radTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.radTextBox1.MaximumValue = null;
            this.radTextBox1.MinimumValue = null;
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radTextBox1.Size = new System.Drawing.Size(160, 19);
            this.radTextBox1.TabIndex = 0;
            this.radTextBox1.TabStop = false;
            this.radTextBox1.Type = rComponents.rTextBoxType.Numeric;
            this.radTextBox1.ValidatingProperty = null;
            this.radTextBox1.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radLabel1.Location = new System.Drawing.Point(488, 9);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(48, 17);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "کد درس:";
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radLabel2.Location = new System.Drawing.Point(488, 34);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(50, 17);
            this.radLabel2.TabIndex = 6;
            this.radLabel2.Text = "نام درس:";
            // 
            // radTextBox2
            // 
            this.radTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.radTextBox2.Culture = null;
            this.radTextBox2.FieldName = "نام درس";
            this.radTextBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radTextBox2.Language = rComponents.TextboxLanguage.Farsi;
            this.radTextBox2.Location = new System.Drawing.Point(217, 32);
            this.radTextBox2.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.radTextBox2.MaximumValue = null;
            this.radTextBox2.MinimumValue = null;
            this.radTextBox2.Name = "radTextBox2";
            this.radTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radTextBox2.Size = new System.Drawing.Size(265, 19);
            this.radTextBox2.TabIndex = 1;
            this.radTextBox2.TabStop = false;
            this.radTextBox2.Type = rComponents.rTextBoxType.Text;
            this.radTextBox2.ValidatingProperty = null;
            this.radTextBox2.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.rGridView1);
            this.radGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radGroupBox1.FooterImageIndex = -1;
            this.radGroupBox1.FooterImageKey = "";
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderImageIndex = -1;
            this.radGroupBox1.HeaderImageKey = "";
            this.radGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.radGroupBox1.HeaderText = "دروس پیشنیاز این درس";
            this.radGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(3, 20, 3, 3);
            // 
            // 
            // 
            this.radGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.radGroupBox1.Size = new System.Drawing.Size(575, 336);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "دروس پیشنیاز این درس";
            // 
            // rGridView1
            // 
            this.rGridView1.CanAdd = true;
            this.rGridView1.CanDelete = true;
            this.rGridView1.CanEdit = false;
            this.rGridView1.CanExport = true;
            this.rGridView1.CanFilter = true;
            this.rGridView1.CanGroup = true;
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
            this.rGridView1.Location = new System.Drawing.Point(3, 20);
            this.rGridView1.MultiSelect = false;
            this.rGridView1.Name = "rGridView1";
            this.rGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView1.RowHeight = 25;
            this.rGridView1.ShowBottomToolbar = true;
            this.rGridView1.ShowGroupPanel = true;
            this.rGridView1.ShowTopToolbar = true;
            this.rGridView1.Size = new System.Drawing.Size(569, 313);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Delete += new System.EventHandler(this.rGridView1_Delete);
            this.rGridView1.Add += new System.EventHandler(this.rGridView1_Add);
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
            this.radPageView1.Size = new System.Drawing.Size(690, 363);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.Text = "دروس پیشنیاز";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Right;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.rCheckBox1);
            this.radPageViewPage1.Controls.Add(this.rComboBox1);
            this.radPageViewPage1.Controls.Add(this.radTextBox2);
            this.radPageViewPage1.Controls.Add(this.radTextBox1);
            this.radPageViewPage1.Controls.Add(this.rLabel1);
            this.radPageViewPage1.Controls.Add(this.radLabel2);
            this.radPageViewPage1.Controls.Add(this.radLabel1);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 10);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(581, 342);
            this.radPageViewPage1.Text = "مشخصات درس";
            // 
            // rComboBox1
            // 
            this.rComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rComboBox1.DropDownAnimationEnabled = true;
            this.rComboBox1.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rComboBox1.FieldName = "نوع برگزاری درس";
            this.rComboBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rComboBox1.Location = new System.Drawing.Point(217, 57);
            this.rComboBox1.MaximumValue = null;
            this.rComboBox1.MinimumValue = null;
            this.rComboBox1.Name = "rComboBox1";
            this.rComboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rComboBox1.ShowImageInEditorArea = true;
            this.rComboBox1.Size = new System.Drawing.Size(265, 19);
            this.rComboBox1.TabIndex = 7;
            this.rComboBox1.Text = "rComboBox1";
            this.rComboBox1.ValidatingProperty = null;
            this.rComboBox1.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(488, 57);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(90, 17);
            this.rLabel1.TabIndex = 6;
            this.rLabel1.Text = "نوع برگزاری درس:";
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.radGroupBox1);
            this.radPageViewPage2.Location = new System.Drawing.Point(10, 10);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(581, 342);
            this.radPageViewPage2.Text = "پـیـشـنـیـازهـا";
            // 
            // rCheckBox1
            // 
            this.rCheckBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.rCheckBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rCheckBox1.Location = new System.Drawing.Point(340, 84);
            this.rCheckBox1.Name = "rCheckBox1";
            this.rCheckBox1.Size = new System.Drawing.Size(142, 17);
            this.rCheckBox1.TabIndex = 8;
            this.rCheckBox1.Text = "امکـان ثبـت نــام اینتـرنتـی";
            // 
            // frmLessonDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 417);
            this.Controls.Add(this.radPageView1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Name = "frmLessonDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات درس";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            this.radPageViewPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rCheckBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private rComponents.rTextBox radTextBox1;
        private rLabel radLabel1;
        private rLabel radLabel2;
        private rComponents.rTextBox radTextBox2;
        private rGroupBox radGroupBox1;
        private rComponents.rGridView rGridView1;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private rLabel rLabel1;
        private rComboBox rComboBox1;
        private rCheckBox rCheckBox1;
    }
}

