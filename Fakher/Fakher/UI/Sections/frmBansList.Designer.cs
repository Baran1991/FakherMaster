namespace Fakher.UI.Educational.Sections
{
    partial class frmBansList
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rGridView1 = new rComponents.rGridView();
            this.rGridView2 = new rComponents.rGridView();
            this.majorSelector1 = new Fakher.Controls.MajorSelector();
            this.lessonSelector1 = new Fakher.Controls.LessonSelector();
            this.sectionItemSelector1 = new Fakher.Controls.SectionItemSelector();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rGridView2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 103);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(889, 367);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rGridView1
            // 
            this.rGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridView1.CanAdd = false;
            this.rGridView1.CanDelete = false;
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
            this.rGridView1.CustomEditText = "تـعـلـیــــق";
            this.rGridView1.FieldName = null;
            this.rGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView1.ItemImage = null;
            this.rGridView1.Location = new System.Drawing.Point(3, 3);
            this.rGridView1.MultiSelect = false;
            this.rGridView1.Name = "rGridView1";
            this.rGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView1.RowHeight = 25;
            this.rGridView1.ShowBottomToolbar = false;
            this.rGridView1.ShowTopToolbar = true;
            this.rGridView1.Size = new System.Drawing.Size(883, 177);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Edit += new System.EventHandler(this.rGridView1_Edit);
            // 
            // rGridView2
            // 
            this.rGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridView2.CanAdd = false;
            this.rGridView2.CanDelete = true;
            this.rGridView2.CanEdit = true;
            this.rGridView2.CanExport = true;
            this.rGridView2.CanFilter = true;
            this.rGridView2.CanGroup = false;
            this.rGridView2.CanNavigate = true;
            this.rGridView2.CheckBoxes = false;
            this.rGridView2.ColumnAutoSize = true;
            this.rGridView2.ConfirmOnDelete = false;
            this.rGridView2.CustomAddText = null;
            this.rGridView2.CustomDeleteText = "پایان تعلیق";
            this.rGridView2.CustomEditText = null;
            this.rGridView2.FieldName = null;
            this.rGridView2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView2.ItemImage = null;
            this.rGridView2.Location = new System.Drawing.Point(3, 186);
            this.rGridView2.MultiSelect = false;
            this.rGridView2.Name = "rGridView2";
            this.rGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView2.RowHeight = 25;
            this.rGridView2.ShowBottomToolbar = false;
            this.rGridView2.ShowTopToolbar = true;
            this.rGridView2.Size = new System.Drawing.Size(883, 178);
            this.rGridView2.TabIndex = 1;
            this.rGridView2.ValidationType = rComponents.ValidationType.None;
            this.rGridView2.Delete += new System.EventHandler(this.rGridView2_Delete);
            this.rGridView2.Edit += new System.EventHandler(this.rGridView2_Edit);
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
            this.majorSelector1.Size = new System.Drawing.Size(889, 25);
            this.majorSelector1.TabIndex = 1;
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
            this.lessonSelector1.Size = new System.Drawing.Size(889, 24);
            this.lessonSelector1.TabIndex = 2;
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
            this.sectionItemSelector1.Size = new System.Drawing.Size(889, 24);
            this.sectionItemSelector1.TabIndex = 3;
            this.sectionItemSelector1.SelectedChanged += new System.EventHandler(this.sectionItemSelector1_SelectedChanged);
            // 
            // frmBansList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 482);
            this.Controls.Add(this.sectionItemSelector1);
            this.Controls.Add(this.lessonSelector1);
            this.Controls.Add(this.majorSelector1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmBansList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "تعلیق از کلاس";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private rComponents.rGridView rGridView1;
        private rComponents.rGridView rGridView2;
        private Fakher.Controls.MajorSelector majorSelector1;
        private Fakher.Controls.LessonSelector lessonSelector1;
        private Fakher.Controls.SectionItemSelector sectionItemSelector1;
    }
}