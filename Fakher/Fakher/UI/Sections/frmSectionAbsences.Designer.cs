namespace Fakher.UI.Educational.Sections
{
    partial class frmSectionAbsences
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
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.rGridViewStudents = new rComponents.rGridView();
            this.majorSelector1 = new Fakher.Controls.MajorSelector();
            this.lessonSelector1 = new Fakher.Controls.LessonSelector();
            this.sectionItemSelector1 = new Fakher.Controls.SectionItemSelector();
            this.rDatePicker1 = new rComponents.rDatePicker(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.lnkShowAbsences = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox1.Controls.Add(this.rGridViewStudents);
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "کل دانشجویان کلاس";
            this.rGroupBox1.Location = new System.Drawing.Point(12, 128);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(914, 343);
            this.rGroupBox1.TabIndex = 3;
            this.rGroupBox1.Text = "کل دانشجویان کلاس";
            // 
            // rGridViewStudents
            // 
            this.rGridViewStudents.CanAdd = true;
            this.rGridViewStudents.CanDelete = true;
            this.rGridViewStudents.CanEdit = true;
            this.rGridViewStudents.CanExport = true;
            this.rGridViewStudents.CanFilter = true;
            this.rGridViewStudents.CanGroup = false;
            this.rGridViewStudents.CanNavigate = true;
            this.rGridViewStudents.CheckBoxes = true;
            this.rGridViewStudents.ColumnAutoSize = true;
            this.rGridViewStudents.ConfirmOnDelete = false;
            this.rGridViewStudents.CustomAddText = "ثبت غیبت";
            this.rGridViewStudents.CustomDeleteText = "پرونده آموزشی";
            this.rGridViewStudents.CustomEditText = "ویرایش غیبت ها";
            this.rGridViewStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewStudents.EditOnDoubleClick = true;
            this.rGridViewStudents.FieldName = null;
            this.rGridViewStudents.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewStudents.ItemImage = null;
            this.rGridViewStudents.Location = new System.Drawing.Point(2, 20);
            this.rGridViewStudents.MultiSelect = false;
            this.rGridViewStudents.Name = "rGridViewStudents";
            this.rGridViewStudents.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewStudents.RowHeight = 25;
            this.rGridViewStudents.ShowBottomToolbar = false;
            this.rGridViewStudents.ShowGroupPanel = true;
            this.rGridViewStudents.ShowTopToolbar = true;
            this.rGridViewStudents.Size = new System.Drawing.Size(910, 321);
            this.rGridViewStudents.TabIndex = 0;
            this.rGridViewStudents.ValidationType = rComponents.ValidationType.None;
            this.rGridViewStudents.Add += new System.EventHandler(this.rGridViewStudents_Add);
            this.rGridViewStudents.Edit += new System.EventHandler(this.rGridViewStudents_Edit);
            this.rGridViewStudents.Delete += new System.EventHandler(this.rGridViewStudents_Delete);
            this.rGridViewStudents.CustomButtonClick += new System.EventHandler<rComponents.CustomButtonClickEventArgs>(this.rGridViewStudents_CustomButtonClick);
            // 
            // majorSelector1
            // 
            this.majorSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.majorSelector1.BackColor = System.Drawing.Color.Transparent;
            this.majorSelector1.DepartmentSelector = null;
            this.majorSelector1.Location = new System.Drawing.Point(12, 12);
            this.majorSelector1.Name = "majorSelector1";
            this.majorSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.majorSelector1.ShowNullButton = false;
            this.majorSelector1.Size = new System.Drawing.Size(914, 25);
            this.majorSelector1.TabIndex = 6;
            // 
            // lessonSelector1
            // 
            this.lessonSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lessonSelector1.BackColor = System.Drawing.Color.Transparent;
            this.lessonSelector1.Location = new System.Drawing.Point(12, 43);
            this.lessonSelector1.MajorSelector = this.majorSelector1;
            this.lessonSelector1.Name = "lessonSelector1";
            this.lessonSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lessonSelector1.ShowAllLessons = false;
            this.lessonSelector1.ShowExamHoldingLessons = false;
            this.lessonSelector1.ShowNullButton = false;
            this.lessonSelector1.Size = new System.Drawing.Size(914, 24);
            this.lessonSelector1.TabIndex = 7;
            // 
            // sectionItemSelector1
            // 
            this.sectionItemSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sectionItemSelector1.BackColor = System.Drawing.Color.Transparent;
            this.sectionItemSelector1.LessonSelector = this.lessonSelector1;
            this.sectionItemSelector1.Location = new System.Drawing.Point(12, 73);
            this.sectionItemSelector1.Name = "sectionItemSelector1";
            this.sectionItemSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sectionItemSelector1.ShowCapacity = false;
            this.sectionItemSelector1.ShowFormation = false;
            this.sectionItemSelector1.ShowNullButton = false;
            this.sectionItemSelector1.ShowTeacher = false;
            this.sectionItemSelector1.Size = new System.Drawing.Size(914, 24);
            this.sectionItemSelector1.TabIndex = 8;
            this.sectionItemSelector1.SelectedChanged += new System.EventHandler(this.sectionItemSelector1_SelectedChanged);
            // 
            // rDatePicker1
            // 
            this.rDatePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePicker1.Culture = null;
            this.rDatePicker1.FieldName = null;
            this.rDatePicker1.Location = new System.Drawing.Point(741, 103);
            this.rDatePicker1.Mask = "1###/##/##";
            this.rDatePicker1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePicker1.Name = "rDatePicker1";
            this.rDatePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePicker1.Size = new System.Drawing.Size(100, 19);
            this.rDatePicker1.TabIndex = 9;
            this.rDatePicker1.TabStop = false;
            this.rDatePicker1.Text = "1___/__/__";
            this.rDatePicker1.ValidationType = rComponents.ValidationType.None;
            this.rDatePicker1.Value = "";
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(848, 105);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(32, 17);
            this.rLabel1.TabIndex = 10;
            this.rLabel1.Text = "تاریخ:";
            // 
            // lnkShowAbsences
            // 
            this.lnkShowAbsences.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkShowAbsences.AutoSize = true;
            this.lnkShowAbsences.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkShowAbsences.Location = new System.Drawing.Point(656, 105);
            this.lnkShowAbsences.Name = "lnkShowAbsences";
            this.lnkShowAbsences.Size = new System.Drawing.Size(79, 13);
            this.lnkShowAbsences.TabIndex = 11;
            this.lnkShowAbsences.TabStop = true;
            this.lnkShowAbsences.Text = "نمایش غیبت ها";
            this.lnkShowAbsences.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowAbsences_LinkClicked);
            // 
            // frmSectionAbsences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 483);
            this.Controls.Add(this.rGroupBox1);
            this.Controls.Add(this.lnkShowAbsences);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.rDatePicker1);
            this.Controls.Add(this.sectionItemSelector1);
            this.Controls.Add(this.lessonSelector1);
            this.Controls.Add(this.majorSelector1);
            this.Name = "frmSectionAbsences";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ثبت غیبت به صورت کلاسی";
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rGridView rGridViewStudents;
        private Fakher.Controls.MajorSelector majorSelector1;
        private Fakher.Controls.LessonSelector lessonSelector1;
        private Fakher.Controls.SectionItemSelector sectionItemSelector1;
        private rComponents.rDatePicker rDatePicker1;
        private rComponents.rLabel rLabel1;
        private System.Windows.Forms.LinkLabel lnkShowAbsences;
    }
}