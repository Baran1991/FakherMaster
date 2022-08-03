namespace Fakher.UI.Exam
{
    partial class frmEnterExamKeyWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnterExamKeyWizard));
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.examSelector1 = new Fakher.Controls.ExamSelector();
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.lnkManualExamKey = new System.Windows.Forms.LinkLabel();
            this.rLblMessage = new rComponents.rLabel(this.components);
            this.lnkScanAll = new System.Windows.Forms.LinkLabel();
            this.lnkScan = new System.Windows.Forms.LinkLabel();
            this.lnkSelectSource = new System.Windows.Forms.LinkLabel();
            this.rGridComboBoxForm = new rComponents.rGridComboBox(this.components);
            this.rLabel5 = new rComponents.rLabel(this.components);
            this.rGroupBox2 = new rComponents.rGroupBox(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.rLabel4 = new rComponents.rLabel(this.components);
            this.radPageViewPage3 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rLblMessage2 = new rComponents.rLabel(this.components);
            this.rGroupBox9 = new rComponents.rGroupBox(this.components);
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.rLabel13 = new rComponents.rLabel(this.components);
            this.btnPrev = new Telerik.WinControls.UI.RadButton();
            this.btnNext = new Telerik.WinControls.UI.RadButton();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.rTwainControl1 = new rTwain.rTwainControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            this.radPageViewPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLblMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxForm.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxForm.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).BeginInit();
            this.rGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).BeginInit();
            this.radPageViewPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLblMessage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox9)).BeginInit();
            this.rGroupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
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
            this.radPageView1.Location = new System.Drawing.Point(12, 12);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage2;
            this.radPageView1.Size = new System.Drawing.Size(742, 402);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.Text = "radPageView1";
            this.radPageView1.SelectedPageChanging += new System.EventHandler<Telerik.WinControls.UI.RadPageViewCancelEventArgs>(this.radPageView1_SelectedPageChanging);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.examSelector1);
            this.radPageViewPage1.Controls.Add(this.rLabel2);
            this.radPageViewPage1.Controls.Add(this.rGroupBox1);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(721, 355);
            this.radPageViewPage1.Text = "انتخاب آزمـــون";
            // 
            // examSelector1
            // 
            this.examSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.examSelector1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.examSelector1.ExamType = Fakher.Core.DomainModel.ExamType.PaperBasedExam;
            this.examSelector1.FilterExamType = true;
            this.examSelector1.Location = new System.Drawing.Point(3, 111);
            this.examSelector1.Name = "examSelector1";
            this.examSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.examSelector1.ShowExamSections = false;
            this.examSelector1.ShowNullButton = false;
            this.examSelector1.Size = new System.Drawing.Size(715, 84);
            this.examSelector1.TabIndex = 6;
            this.examSelector1.SelectedChanged += new System.EventHandler(this.examSelector1_SelectedChanged);
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.AutoSize = false;
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(256, 88);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(421, 17);
            this.rLabel2.TabIndex = 3;
            this.rLabel2.Text = "ابتدا رشته موردنظر، آیتم ارزشیابی و آزمون مناسب را انتخاب کنید";
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox1.Controls.Add(this.pictureBox1);
            this.rGroupBox1.Controls.Add(this.rLabel1);
            this.rGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "";
            this.rGroupBox1.HeaderTextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.rGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(721, 56);
            this.rGroupBox1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(671, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.AutoSize = false;
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(256, 23);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(421, 17);
            this.rLabel1.TabIndex = 3;
            this.rLabel1.Text = "ابتدا رشته موردنظر را بیابید و آزمون مناسب را انتخاب کنید";
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.lnkManualExamKey);
            this.radPageViewPage2.Controls.Add(this.rLblMessage);
            this.radPageViewPage2.Controls.Add(this.lnkScanAll);
            this.radPageViewPage2.Controls.Add(this.lnkScan);
            this.radPageViewPage2.Controls.Add(this.lnkSelectSource);
            this.radPageViewPage2.Controls.Add(this.rGridComboBoxForm);
            this.radPageViewPage2.Controls.Add(this.rLabel5);
            this.radPageViewPage2.Controls.Add(this.rGroupBox2);
            this.radPageViewPage2.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(721, 355);
            this.radPageViewPage2.Text = "خواندن از اسـکـنـــر";
            // 
            // lnkManualExamKey
            // 
            this.lnkManualExamKey.AutoSize = true;
            this.lnkManualExamKey.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkManualExamKey.Location = new System.Drawing.Point(514, 258);
            this.lnkManualExamKey.Name = "lnkManualExamKey";
            this.lnkManualExamKey.Size = new System.Drawing.Size(184, 13);
            this.lnkManualExamKey.TabIndex = 6;
            this.lnkManualExamKey.TabStop = true;
            this.lnkManualExamKey.Text = "ورود کــلــیــد بــــه صــــورت دســـتـــی";
            this.lnkManualExamKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkManualExamKey_LinkClicked);
            // 
            // rLblMessage
            // 
            this.rLblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rLblMessage.AutoSize = false;
            this.rLblMessage.BackColor = System.Drawing.Color.Transparent;
            this.rLblMessage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLblMessage.ForeColor = System.Drawing.Color.Red;
            this.rLblMessage.Location = new System.Drawing.Point(14, 135);
            this.rLblMessage.Name = "rLblMessage";
            // 
            // 
            // 
            this.rLblMessage.RootElement.ForeColor = System.Drawing.Color.Red;
            this.rLblMessage.Size = new System.Drawing.Size(406, 217);
            this.rLblMessage.TabIndex = 7;
            this.rLblMessage.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lnkScanAll
            // 
            this.lnkScanAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkScanAll.AutoSize = true;
            this.lnkScanAll.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkScanAll.Location = new System.Drawing.Point(445, 225);
            this.lnkScanAll.Name = "lnkScanAll";
            this.lnkScanAll.Size = new System.Drawing.Size(253, 13);
            this.lnkScanAll.TabIndex = 6;
            this.lnkScanAll.TabStop = true;
            this.lnkScanAll.Text = "کــلــیــد هــمــه فـــــرم هـا را بـه تـرتـیـــب اسکن کنید";
            this.lnkScanAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkScanAll_LinkClicked);
            // 
            // lnkScan
            // 
            this.lnkScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkScan.AutoSize = true;
            this.lnkScan.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkScan.Location = new System.Drawing.Point(511, 192);
            this.lnkScan.Name = "lnkScan";
            this.lnkScan.Size = new System.Drawing.Size(187, 13);
            this.lnkScan.TabIndex = 6;
            this.lnkScan.TabStop = true;
            this.lnkScan.Text = "کــلــیــد آزمـــــون این فرم را اسکن کنید";
            this.lnkScan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkScan_LinkClicked);
            // 
            // lnkSelectSource
            // 
            this.lnkSelectSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkSelectSource.AutoSize = true;
            this.lnkSelectSource.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkSelectSource.Location = new System.Drawing.Point(593, 161);
            this.lnkSelectSource.Name = "lnkSelectSource";
            this.lnkSelectSource.Size = new System.Drawing.Size(105, 13);
            this.lnkSelectSource.TabIndex = 6;
            this.lnkSelectSource.TabStop = true;
            this.lnkSelectSource.Text = "انتخاب دستگاه اسکنر";
            this.lnkSelectSource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSelectSource_LinkClicked);
            // 
            // rGridComboBoxForm
            // 
            this.rGridComboBoxForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridComboBoxForm.CompareMember = null;
            this.rGridComboBoxForm.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridComboBoxForm.NestedRadGridView
            // 
            this.rGridComboBoxForm.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridComboBoxForm.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBoxForm.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridComboBoxForm.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rGridComboBoxForm.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridComboBoxForm.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridComboBoxForm.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridComboBoxForm.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridComboBoxForm.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridComboBoxForm.EditorControl.MasterTemplate.EnableFiltering = true;
            this.rGridComboBoxForm.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridComboBoxForm.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBoxForm.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBoxForm.EditorControl.Name = "NestedRadGridView";
            this.rGridComboBoxForm.EditorControl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.rGridComboBoxForm.EditorControl.ReadOnly = true;
            this.rGridComboBoxForm.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.rGridComboBoxForm.EditorControl.RootElement.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.rGridComboBoxForm.EditorControl.ShowGroupPanel = false;
            this.rGridComboBoxForm.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridComboBoxForm.EditorControl.TabIndex = 0;
            this.rGridComboBoxForm.FieldName = null;
            this.rGridComboBoxForm.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBoxForm.Location = new System.Drawing.Point(14, 110);
            this.rGridComboBoxForm.MaximumValue = null;
            this.rGridComboBoxForm.MinimumValue = null;
            this.rGridComboBoxForm.Name = "rGridComboBoxForm";
            // 
            // 
            // 
            this.rGridComboBoxForm.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridComboBoxForm.ShowFilteringRow = true;
            this.rGridComboBoxForm.ShowNullButton = false;
            this.rGridComboBoxForm.Size = new System.Drawing.Size(681, 19);
            this.rGridComboBoxForm.TabIndex = 5;
            this.rGridComboBoxForm.TabStop = false;
            this.rGridComboBoxForm.ValidatingProperty = null;
            this.rGridComboBoxForm.ValidationType = rComponents.ValidationType.None;
            this.rGridComboBoxForm.Value = null;
            // 
            // rLabel5
            // 
            this.rLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel5.BackColor = System.Drawing.Color.Transparent;
            this.rLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel5.Location = new System.Drawing.Point(605, 87);
            this.rLabel5.Name = "rLabel5";
            this.rLabel5.Size = new System.Drawing.Size(90, 17);
            this.rLabel5.TabIndex = 4;
            this.rLabel5.Text = "فــــــرم آزمــــــون:";
            // 
            // rGroupBox2
            // 
            this.rGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox2.Controls.Add(this.pictureBox2);
            this.rGroupBox2.Controls.Add(this.rLabel4);
            this.rGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.rGroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox2.FooterImageIndex = -1;
            this.rGroupBox2.FooterImageKey = "";
            this.rGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox2.HeaderImageIndex = -1;
            this.rGroupBox2.HeaderImageKey = "";
            this.rGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox2.HeaderText = "";
            this.rGroupBox2.HeaderTextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.rGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.rGroupBox2.Name = "rGroupBox2";
            this.rGroupBox2.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox2.Size = new System.Drawing.Size(721, 56);
            this.rGroupBox2.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(671, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // rLabel4
            // 
            this.rLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel4.AutoSize = false;
            this.rLabel4.BackColor = System.Drawing.Color.Transparent;
            this.rLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel4.Location = new System.Drawing.Point(256, 23);
            this.rLabel4.Name = "rLabel4";
            this.rLabel4.Size = new System.Drawing.Size(421, 17);
            this.rLabel4.TabIndex = 3;
            this.rLabel4.Text = "فرم آزمون مناسب را انتخاب و کلید این فرم را اسکن کنید یا به صورت دستی وارد کنید";
            // 
            // radPageViewPage3
            // 
            this.radPageViewPage3.Controls.Add(this.rLblMessage2);
            this.radPageViewPage3.Controls.Add(this.rGroupBox9);
            this.radPageViewPage3.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage3.Name = "radPageViewPage3";
            this.radPageViewPage3.Size = new System.Drawing.Size(721, 355);
            this.radPageViewPage3.Text = "پـــــایـــــان";
            // 
            // rLblMessage2
            // 
            this.rLblMessage2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rLblMessage2.AutoSize = false;
            this.rLblMessage2.BackColor = System.Drawing.Color.Transparent;
            this.rLblMessage2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLblMessage2.ForeColor = System.Drawing.Color.Red;
            this.rLblMessage2.Location = new System.Drawing.Point(3, 62);
            this.rLblMessage2.Name = "rLblMessage2";
            // 
            // 
            // 
            this.rLblMessage2.RootElement.ForeColor = System.Drawing.Color.Red;
            this.rLblMessage2.Size = new System.Drawing.Size(715, 290);
            this.rLblMessage2.TabIndex = 10;
            // 
            // rGroupBox9
            // 
            this.rGroupBox9.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox9.Controls.Add(this.pictureBox7);
            this.rGroupBox9.Controls.Add(this.rLabel13);
            this.rGroupBox9.Dock = System.Windows.Forms.DockStyle.Top;
            this.rGroupBox9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox9.FooterImageIndex = -1;
            this.rGroupBox9.FooterImageKey = "";
            this.rGroupBox9.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox9.HeaderImageIndex = -1;
            this.rGroupBox9.HeaderImageKey = "";
            this.rGroupBox9.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox9.HeaderText = "";
            this.rGroupBox9.HeaderTextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.rGroupBox9.Location = new System.Drawing.Point(0, 0);
            this.rGroupBox9.Name = "rGroupBox9";
            this.rGroupBox9.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox9.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox9.Size = new System.Drawing.Size(721, 56);
            this.rGroupBox9.TabIndex = 9;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(671, 5);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(45, 48);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 2;
            this.pictureBox7.TabStop = false;
            // 
            // rLabel13
            // 
            this.rLabel13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel13.AutoSize = false;
            this.rLabel13.BackColor = System.Drawing.Color.Transparent;
            this.rLabel13.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel13.Location = new System.Drawing.Point(199, 23);
            this.rLabel13.Name = "rLabel13";
            this.rLabel13.Size = new System.Drawing.Size(478, 17);
            this.rLabel13.TabIndex = 3;
            this.rLabel13.Text = "مشخصات زیر را بررسی کنید و دکمه تایید را بزنید";
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnPrev.Location = new System.Drawing.Point(312, 420);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(130, 24);
            this.btnPrev.TabIndex = 11;
            this.btnPrev.Text = "گـــــام قــبــلــی";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnNext.Location = new System.Drawing.Point(176, 420);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(130, 24);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "گـــــام بــعــدی";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnExit.Location = new System.Drawing.Point(12, 420);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(130, 24);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "خـــروج";
            // 
            // rTwainControl1
            // 
            this.rTwainControl1.ShowUI = false;
            this.rTwainControl1.DocumentScanned += new System.EventHandler<rTwain.DocumentScannedEventArgs>(this.rTwainControl1_DocumentScanned);
            // 
            // frmEnterExamKeyWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 456);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.radPageView1);
            this.Name = "frmEnterExamKeyWizard";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ورود کلید آزمون کتبی";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEnterExamKey_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            this.radPageViewPage2.ResumeLayout(false);
            this.radPageViewPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLblMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxForm.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxForm.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).EndInit();
            this.rGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).EndInit();
            this.radPageViewPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rLblMessage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox9)).EndInit();
            this.rGroupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadButton btnPrev;
        private Telerik.WinControls.UI.RadButton btnNext;
        private Telerik.WinControls.UI.RadButton btnExit;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage3;
        private rComponents.rGroupBox rGroupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private rComponents.rLabel rLabel1;
        private rComponents.rGroupBox rGroupBox2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private rComponents.rLabel rLabel4;
        private rComponents.rGridComboBox rGridComboBoxForm;
        private rComponents.rLabel rLabel5;
        private System.Windows.Forms.LinkLabel lnkScan;
        private System.Windows.Forms.LinkLabel lnkSelectSource;
        private rComponents.rLabel rLblMessage;
        private rComponents.rGroupBox rGroupBox9;
        private System.Windows.Forms.PictureBox pictureBox7;
        private rComponents.rLabel rLabel13;
        private rComponents.rLabel rLblMessage2;
        private rTwain.rTwainControl rTwainControl1;
        private Fakher.Controls.ExamSelector examSelector1;
        private rComponents.rLabel rLabel2;
        private System.Windows.Forms.LinkLabel lnkScanAll;
        private System.Windows.Forms.LinkLabel lnkManualExamKey;
    }
}