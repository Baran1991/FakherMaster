namespace Fakher.UI.Educational.Students
{
    partial class frmEnterStudentPicture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnterStudentPicture));
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.radBtnRotateLeft = new Telerik.WinControls.UI.RadButton();
            this.radBtnRotateRight = new Telerik.WinControls.UI.RadButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lnkOpenFile = new System.Windows.Forms.LinkLabel();
            this.lnkPath = new System.Windows.Forms.LinkLabel();
            this.radBtnSave = new Telerik.WinControls.UI.RadButton();
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.majorSelector1 = new Fakher.Controls.MajorSelector();
            this.lessonSelector1 = new Fakher.Controls.LessonSelector();
            this.rGridView1 = new rComponents.rGridView();
            this.sectionItemSelector1 = new Fakher.Controls.SectionItemSelector();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnRotateLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnRotateRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox1.Controls.Add(this.radBtnRotateLeft);
            this.rGroupBox1.Controls.Add(this.radBtnRotateRight);
            this.rGroupBox1.Controls.Add(this.listBox1);
            this.rGroupBox1.Controls.Add(this.pictureBox1);
            this.rGroupBox1.Controls.Add(this.lnkOpenFile);
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = " انتخاب عکس";
            this.rGroupBox1.Location = new System.Drawing.Point(12, 365);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(914, 179);
            this.rGroupBox1.TabIndex = 1;
            this.rGroupBox1.Text = " انتخاب عکس";
            // 
            // radBtnRotateLeft
            // 
            this.radBtnRotateLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radBtnRotateLeft.Image = ((System.Drawing.Image)(resources.GetObject("radBtnRotateLeft.Image")));
            this.radBtnRotateLeft.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radBtnRotateLeft.Location = new System.Drawing.Point(730, 150);
            this.radBtnRotateLeft.Name = "radBtnRotateLeft";
            this.radBtnRotateLeft.Size = new System.Drawing.Size(23, 24);
            this.radBtnRotateLeft.TabIndex = 3;
            this.radBtnRotateLeft.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radBtnRotateLeft.Click += new System.EventHandler(this.radBtnRotateLeft_Click);
            // 
            // radBtnRotateRight
            // 
            this.radBtnRotateRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radBtnRotateRight.Image = ((System.Drawing.Image)(resources.GetObject("radBtnRotateRight.Image")));
            this.radBtnRotateRight.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radBtnRotateRight.Location = new System.Drawing.Point(759, 150);
            this.radBtnRotateRight.Name = "radBtnRotateRight";
            this.radBtnRotateRight.Size = new System.Drawing.Size(23, 24);
            this.radBtnRotateRight.TabIndex = 3;
            this.radBtnRotateRight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radBtnRotateRight.Click += new System.EventHandler(this.radBtnRotateRight_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(5, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(592, 116);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(603, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(306, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lnkOpenFile
            // 
            this.lnkOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkOpenFile.AutoSize = true;
            this.lnkOpenFile.BackColor = System.Drawing.Color.Transparent;
            this.lnkOpenFile.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkOpenFile.Location = new System.Drawing.Point(759, 2);
            this.lnkOpenFile.Name = "lnkOpenFile";
            this.lnkOpenFile.Size = new System.Drawing.Size(82, 13);
            this.lnkOpenFile.TabIndex = 0;
            this.lnkOpenFile.TabStop = true;
            this.lnkOpenFile.Text = "[ انتخاب از فایل ]";
            this.lnkOpenFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOpenFile_LinkClicked);
            // 
            // lnkPath
            // 
            this.lnkPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkPath.AutoSize = true;
            this.lnkPath.BackColor = System.Drawing.Color.Transparent;
            this.lnkPath.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPath.Location = new System.Drawing.Point(824, 17);
            this.lnkPath.Name = "lnkPath";
            this.lnkPath.Size = new System.Drawing.Size(97, 13);
            this.lnkPath.TabIndex = 0;
            this.lnkPath.TabStop = true;
            this.lnkPath.Text = "انتخاب مسیر تصاویر";
            this.lnkPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPath_LinkClicked);
            // 
            // radBtnSave
            // 
            this.radBtnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radBtnSave.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radBtnSave.Location = new System.Drawing.Point(344, 550);
            this.radBtnSave.Name = "radBtnSave";
            this.radBtnSave.Size = new System.Drawing.Size(251, 24);
            this.radBtnSave.TabIndex = 2;
            this.radBtnSave.Text = "ذخــیـــره";
            this.radBtnSave.Click += new System.EventHandler(this.radBtnSave_Click);
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.AutoSize = false;
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.BorderVisible = true;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(17, 17);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rLabel1.Size = new System.Drawing.Size(801, 17);
            this.rLabel1.TabIndex = 3;
            // 
            // majorSelector1
            // 
            this.majorSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.majorSelector1.BackColor = System.Drawing.Color.Transparent;
            this.majorSelector1.DepartmentSelector = null;
            this.majorSelector1.Location = new System.Drawing.Point(12, 40);
            this.majorSelector1.Name = "majorSelector1";
            this.majorSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.majorSelector1.ShowNullButton = false;
            this.majorSelector1.Size = new System.Drawing.Size(914, 25);
            this.majorSelector1.TabIndex = 4;
            // 
            // lessonSelector1
            // 
            this.lessonSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lessonSelector1.BackColor = System.Drawing.Color.Transparent;
            this.lessonSelector1.Location = new System.Drawing.Point(12, 71);
            this.lessonSelector1.MajorSelector = this.majorSelector1;
            this.lessonSelector1.Name = "lessonSelector1";
            this.lessonSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lessonSelector1.ShowAllLessons = false;
            this.lessonSelector1.ShowExamHoldingLessons = false;
            this.lessonSelector1.ShowNullButton = false;
            this.lessonSelector1.Size = new System.Drawing.Size(914, 24);
            this.lessonSelector1.TabIndex = 5;
            // 
            // rGridView1
            // 
            this.rGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridView1.CanAdd = false;
            this.rGridView1.CanDelete = false;
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
            this.rGridView1.FieldName = null;
            this.rGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView1.ItemImage = null;
            this.rGridView1.Location = new System.Drawing.Point(12, 131);
            this.rGridView1.MultiSelect = false;
            this.rGridView1.Name = "rGridView1";
            this.rGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView1.RowHeight = 25;
            this.rGridView1.ShowBottomToolbar = false;
            this.rGridView1.ShowTopToolbar = true;
            this.rGridView1.Size = new System.Drawing.Size(914, 228);
            this.rGridView1.TabIndex = 7;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.SelectedItemChanged += new System.EventHandler(this.rGridView1_SelectedItemChanged);
            // 
            // sectionItemSelector1
            // 
            this.sectionItemSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sectionItemSelector1.BackColor = System.Drawing.Color.Transparent;
            this.sectionItemSelector1.LessonSelector = this.lessonSelector1;
            this.sectionItemSelector1.Location = new System.Drawing.Point(12, 101);
            this.sectionItemSelector1.Name = "sectionItemSelector1";
            this.sectionItemSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sectionItemSelector1.ShowNullButton = false;
            this.sectionItemSelector1.Size = new System.Drawing.Size(914, 24);
            this.sectionItemSelector1.TabIndex = 8;
            this.sectionItemSelector1.SelectedChanged += new System.EventHandler(this.sectionItemSelector1_SelectedChanged);
            // 
            // frmEnterStudentPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 586);
            this.Controls.Add(this.sectionItemSelector1);
            this.Controls.Add(this.rGridView1);
            this.Controls.Add(this.lessonSelector1);
            this.Controls.Add(this.majorSelector1);
            this.Controls.Add(this.lnkPath);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.radBtnSave);
            this.Controls.Add(this.rGroupBox1);
            this.Name = "frmEnterStudentPicture";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ورود تصاویر دانشجویان";
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            this.rGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnRotateLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnRotateRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rGroupBox rGroupBox1;
        private System.Windows.Forms.LinkLabel lnkPath;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Telerik.WinControls.UI.RadButton radBtnSave;
        private rComponents.rLabel rLabel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.LinkLabel lnkOpenFile;
        private Fakher.Controls.MajorSelector majorSelector1;
        private Fakher.Controls.LessonSelector lessonSelector1;
        private rComponents.rGridView rGridView1;
        private Telerik.WinControls.UI.RadButton radBtnRotateLeft;
        private Telerik.WinControls.UI.RadButton radBtnRotateRight;
        private Fakher.Controls.SectionItemSelector sectionItemSelector1;
    }
}