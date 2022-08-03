namespace Fakher.Controls
{
    partial class StudentSearchBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentSearchBox));
            this.rGroupBox2 = new rComponents.rGroupBox(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lnkNewStudent = new System.Windows.Forms.LinkLabel();
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.rGridView1 = new rComponents.rGridView();
            this.radBtnSearch = new Telerik.WinControls.UI.RadButton();
            this.radTxtLastname = new rComponents.rTextBox(this.components);
            this.radTxtFirstname = new rComponents.rTextBox(this.components);
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView2 = new rComponents.rGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).BeginInit();
            this.rGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTxtLastname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTxtFirstname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            this.radPageViewPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rGroupBox2
            // 
            this.rGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox2.Controls.Add(this.radPageView1);
            this.rGroupBox2.Controls.Add(this.pictureBox2);
            this.rGroupBox2.Controls.Add(this.lnkNewStudent);
            this.rGroupBox2.Controls.Add(this.rLabel2);
            this.rGroupBox2.Controls.Add(this.radBtnSearch);
            this.rGroupBox2.Controls.Add(this.radTxtLastname);
            this.rGroupBox2.Controls.Add(this.radTxtFirstname);
            this.rGroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox2.FooterImageIndex = -1;
            this.rGroupBox2.FooterImageKey = "";
            this.rGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox2.HeaderImageIndex = -1;
            this.rGroupBox2.HeaderImageKey = "";
            this.rGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox2.HeaderText = "جستجوی پرونده آموزشی دانشجو";
            this.rGroupBox2.Location = new System.Drawing.Point(0, 1);
            this.rGroupBox2.Name = "rGroupBox2";
            this.rGroupBox2.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox2.Size = new System.Drawing.Size(901, 294);
            this.rGroupBox2.TabIndex = 5;
            this.rGroupBox2.Text = "جستجوی پرونده آموزشی دانشجو";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(844, 244);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // lnkNewStudent
            // 
            this.lnkNewStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkNewStudent.AutoSize = true;
            this.lnkNewStudent.BackColor = System.Drawing.Color.Transparent;
            this.lnkNewStudent.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkNewStudent.Location = new System.Drawing.Point(695, 270);
            this.lnkNewStudent.Name = "lnkNewStudent";
            this.lnkNewStudent.Size = new System.Drawing.Size(146, 13);
            this.lnkNewStudent.TabIndex = 9;
            this.lnkNewStudent.TabStop = true;
            this.lnkNewStudent.Text = "تــشــکــیــل پــرونــده جــدیـــد";
            this.lnkNewStudent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNewStudent_LinkClicked);
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(468, 252);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(383, 17);
            this.rLabel2.TabIndex = 8;
            this.rLabel2.Text = "اگر شخص در موسسه سابقه قبلی ندارد، برای او یک پرونده جدید تشکیل بدهید؛";
            // 
            // rGridView1
            // 
            this.rGridView1.CanAdd = true;
            this.rGridView1.CanDelete = false;
            this.rGridView1.CanEdit = false;
            this.rGridView1.CanExport = true;
            this.rGridView1.CanFilter = false;
            this.rGridView1.CanGroup = false;
            this.rGridView1.CanNavigate = true;
            this.rGridView1.CheckBoxes = false;
            this.rGridView1.ColumnAutoSize = true;
            this.rGridView1.ConfirmOnDelete = true;
            this.rGridView1.CustomAddText = "پرونده جدید";
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
            this.rGridView1.ShowTopToolbar = false;
            this.rGridView1.Size = new System.Drawing.Size(870, 142);
            this.rGridView1.TabIndex = 4;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.SelectedItemChanged += new System.EventHandler(this.rGridView1_SelectedItemChanged);
            // 
            // radBtnSearch
            // 
            this.radBtnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radBtnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radBtnSearch.Location = new System.Drawing.Point(192, 23);
            this.radBtnSearch.Name = "radBtnSearch";
            this.radBtnSearch.Size = new System.Drawing.Size(128, 20);
            this.radBtnSearch.TabIndex = 3;
            this.radBtnSearch.Text = "جستـــجــــو";
            this.radBtnSearch.Click += new System.EventHandler(this.radBtnSearch_Click);
            // 
            // radTxtLastname
            // 
            this.radTxtLastname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radTxtLastname.Culture = null;
            this.radTxtLastname.FieldName = null;
            this.radTxtLastname.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radTxtLastname.Language = rComponents.TextboxLanguage.Farsi;
            this.radTxtLastname.Location = new System.Drawing.Point(326, 24);
            this.radTxtLastname.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.radTxtLastname.MaximumValue = null;
            this.radTxtLastname.MinimumValue = null;
            this.radTxtLastname.Name = "radTxtLastname";
            this.radTxtLastname.NullText = "نــــام خــــانـــوادگـــی";
            this.radTxtLastname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radTxtLastname.Size = new System.Drawing.Size(188, 19);
            this.radTxtLastname.TabIndex = 2;
            this.radTxtLastname.TabStop = false;
            this.radTxtLastname.Type = rComponents.rTextBoxType.Text;
            this.radTxtLastname.ValidatingProperty = null;
            this.radTxtLastname.ValidationType = rComponents.ValidationType.None;
            this.radTxtLastname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radTxtLastname_KeyDown);
            // 
            // radTxtFirstname
            // 
            this.radTxtFirstname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radTxtFirstname.Culture = null;
            this.radTxtFirstname.FieldName = null;
            this.radTxtFirstname.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radTxtFirstname.Language = rComponents.TextboxLanguage.Farsi;
            this.radTxtFirstname.Location = new System.Drawing.Point(520, 24);
            this.radTxtFirstname.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.radTxtFirstname.MaximumValue = null;
            this.radTxtFirstname.MinimumValue = null;
            this.radTxtFirstname.Name = "radTxtFirstname";
            this.radTxtFirstname.NullText = "نــــام";
            this.radTxtFirstname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radTxtFirstname.Size = new System.Drawing.Size(188, 19);
            this.radTxtFirstname.TabIndex = 1;
            this.radTxtFirstname.TabStop = false;
            this.radTxtFirstname.Type = rComponents.rTextBoxType.Text;
            this.radTxtFirstname.ValidatingProperty = null;
            this.radTxtFirstname.ValidationType = rComponents.ValidationType.None;
            this.radTxtFirstname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radTxtFirstname_KeyDown);
            // 
            // radPageView1
            // 
            this.radPageView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Controls.Add(this.radPageViewPage2);
            this.radPageView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radPageView1.Location = new System.Drawing.Point(5, 49);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage1;
            this.radPageView1.Size = new System.Drawing.Size(891, 189);
            this.radPageView1.TabIndex = 10;
            this.radPageView1.Text = "radPageView1";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.Fill;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Bottom;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.rGridView1);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 10);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(870, 142);
            this.radPageViewPage1.Text = "دانـــشــجـــــویــــان";
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.rGridView2);
            this.radPageViewPage2.Location = new System.Drawing.Point(10, 10);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(870, 142);
            this.radPageViewPage2.Text = "اســــاتــیـــد";
            // 
            // rGridView2
            // 
            this.rGridView2.CanAdd = true;
            this.rGridView2.CanDelete = false;
            this.rGridView2.CanEdit = false;
            this.rGridView2.CanExport = true;
            this.rGridView2.CanFilter = false;
            this.rGridView2.CanGroup = false;
            this.rGridView2.CanNavigate = true;
            this.rGridView2.CheckBoxes = false;
            this.rGridView2.ColumnAutoSize = true;
            this.rGridView2.ConfirmOnDelete = true;
            this.rGridView2.CustomAddText = "پرونده جدید";
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
            this.rGridView2.ShowTopToolbar = false;
            this.rGridView2.Size = new System.Drawing.Size(870, 142);
            this.rGridView2.TabIndex = 5;
            this.rGridView2.ValidationType = rComponents.ValidationType.None;
            // 
            // StudentSearchBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rGroupBox2);
            this.Name = "StudentSearchBox";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(903, 298);
            this.Load += new System.EventHandler(this.StudentSearchBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).EndInit();
            this.rGroupBox2.ResumeLayout(false);
            this.rGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTxtLastname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTxtFirstname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private rComponents.rGroupBox rGroupBox2;
        private rComponents.rGridView rGridView1;
        private Telerik.WinControls.UI.RadButton radBtnSearch;
        private System.Windows.Forms.LinkLabel lnkNewStudent;
        private rComponents.rLabel rLabel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private rComponents.rTextBox radTxtLastname;
        private rComponents.rTextBox radTxtFirstname;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private rComponents.rGridView rGridView2;
    }
}
