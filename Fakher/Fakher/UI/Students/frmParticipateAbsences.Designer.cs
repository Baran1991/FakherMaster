namespace Fakher.UI.Educational.Sections
{
    partial class frmParticipateAbsences
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
            this.rGroupBox2 = new rComponents.rGroupBox(this.components);
            this.rGridViewAbsents = new rComponents.rGridView();
            this.majorSelector1 = new Fakher.Controls.MajorSelector();
            this.lessonSelector1 = new Fakher.Controls.LessonSelector();
            this.sectionItemSelector1 = new Fakher.Controls.SectionItemSelector();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).BeginInit();
            this.rGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rGroupBox1
            // 
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
            this.rGroupBox1.Location = new System.Drawing.Point(12, 103);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(888, 199);
            this.rGroupBox1.TabIndex = 3;
            this.rGroupBox1.Text = "کل دانشجویان کلاس";
            // 
            // rGridViewStudents
            // 
            this.rGridViewStudents.CanAdd = false;
            this.rGridViewStudents.CanDelete = false;
            this.rGridViewStudents.CanEdit = false;
            this.rGridViewStudents.CanExport = true;
            this.rGridViewStudents.CanFilter = true;
            this.rGridViewStudents.CanGroup = false;
            this.rGridViewStudents.CanNavigate = true;
            this.rGridViewStudents.CheckBoxes = false;
            this.rGridViewStudents.ColumnAutoSize = true;
            this.rGridViewStudents.ConfirmOnDelete = true;
            this.rGridViewStudents.CustomAddText = "";
            this.rGridViewStudents.CustomDeleteText = null;
            this.rGridViewStudents.CustomEditText = "";
            this.rGridViewStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewStudents.FieldName = null;
            this.rGridViewStudents.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewStudents.ItemImage = null;
            this.rGridViewStudents.Location = new System.Drawing.Point(2, 20);
            this.rGridViewStudents.MultiSelect = false;
            this.rGridViewStudents.Name = "rGridViewStudents";
            this.rGridViewStudents.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewStudents.RowHeight = 25;
            this.rGridViewStudents.ShowBottomToolbar = false;
            this.rGridViewStudents.ShowTopToolbar = true;
            this.rGridViewStudents.Size = new System.Drawing.Size(884, 177);
            this.rGridViewStudents.TabIndex = 0;
            this.rGridViewStudents.ValidationType = rComponents.ValidationType.None;
            this.rGridViewStudents.SelectedItemChanged += new System.EventHandler(this.rGridViewStudents_SelectedItemChanged);
            // 
            // rGroupBox2
            // 
            this.rGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox2.Controls.Add(this.rGridViewAbsents);
            this.rGroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox2.FooterImageIndex = -1;
            this.rGroupBox2.FooterImageKey = "";
            this.rGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox2.HeaderImageIndex = -1;
            this.rGroupBox2.HeaderImageKey = "";
            this.rGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox2.HeaderText = "غیبت های دانشجو";
            this.rGroupBox2.Location = new System.Drawing.Point(12, 308);
            this.rGroupBox2.Name = "rGroupBox2";
            this.rGroupBox2.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox2.Size = new System.Drawing.Size(888, 163);
            this.rGroupBox2.TabIndex = 4;
            this.rGroupBox2.Text = "غیبت های دانشجو";
            // 
            // rGridViewAbsents
            // 
            this.rGridViewAbsents.CanAdd = true;
            this.rGridViewAbsents.CanDelete = true;
            this.rGridViewAbsents.CanEdit = true;
            this.rGridViewAbsents.CanExport = true;
            this.rGridViewAbsents.CanFilter = true;
            this.rGridViewAbsents.CanGroup = false;
            this.rGridViewAbsents.CanNavigate = true;
            this.rGridViewAbsents.CheckBoxes = false;
            this.rGridViewAbsents.ColumnAutoSize = true;
            this.rGridViewAbsents.ConfirmOnDelete = true;
            this.rGridViewAbsents.CustomAddText = null;
            this.rGridViewAbsents.CustomDeleteText = "";
            this.rGridViewAbsents.CustomEditText = null;
            this.rGridViewAbsents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewAbsents.FieldName = null;
            this.rGridViewAbsents.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewAbsents.ItemImage = null;
            this.rGridViewAbsents.Location = new System.Drawing.Point(2, 20);
            this.rGridViewAbsents.MultiSelect = false;
            this.rGridViewAbsents.Name = "rGridViewAbsents";
            this.rGridViewAbsents.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewAbsents.RowHeight = 25;
            this.rGridViewAbsents.ShowBottomToolbar = false;
            this.rGridViewAbsents.ShowTopToolbar = true;
            this.rGridViewAbsents.Size = new System.Drawing.Size(884, 141);
            this.rGridViewAbsents.TabIndex = 0;
            this.rGridViewAbsents.ValidationType = rComponents.ValidationType.None;
            this.rGridViewAbsents.Delete += new System.EventHandler(this.rGridViewAbsents_Delete);
            this.rGridViewAbsents.Edit += new System.EventHandler(this.rGridViewAbsents_Edit);
            this.rGridViewAbsents.Add += new System.EventHandler(this.rGridViewAbsents_Add);
            // 
            // majorSelector1
            // 
            this.majorSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.majorSelector1.BackColor = System.Drawing.Color.Transparent;
            this.majorSelector1.Location = new System.Drawing.Point(12, 12);
            this.majorSelector1.Name = "majorSelector1";
            this.majorSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.majorSelector1.ShowNullButton = false;
            this.majorSelector1.Size = new System.Drawing.Size(888, 25);
            this.majorSelector1.TabIndex = 0;
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
            this.lessonSelector1.ShowNullButton = false;
            this.lessonSelector1.Size = new System.Drawing.Size(888, 24);
            this.lessonSelector1.TabIndex = 1;
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
            this.sectionItemSelector1.ShowNullButton = false;
            this.sectionItemSelector1.Size = new System.Drawing.Size(888, 24);
            this.sectionItemSelector1.TabIndex = 2;
            this.sectionItemSelector1.SelectedChanged += new System.EventHandler(this.sectionItemSelector1_SelectedChanged);
            // 
            // frmParticipateAbsences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 483);
            this.Controls.Add(this.sectionItemSelector1);
            this.Controls.Add(this.lessonSelector1);
            this.Controls.Add(this.majorSelector1);
            this.Controls.Add(this.rGroupBox2);
            this.Controls.Add(this.rGroupBox1);
            this.Name = "frmParticipateAbsences";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "غیبت دانشجویان";
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).EndInit();
            this.rGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rGridView rGridViewStudents;
        private rComponents.rGroupBox rGroupBox2;
        private rComponents.rGridView rGridViewAbsents;
        private Fakher.Controls.MajorSelector majorSelector1;
        private Fakher.Controls.LessonSelector lessonSelector1;
        private Fakher.Controls.SectionItemSelector sectionItemSelector1;
    }
}