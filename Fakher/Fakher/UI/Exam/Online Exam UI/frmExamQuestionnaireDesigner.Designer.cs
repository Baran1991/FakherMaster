namespace Fakher.UI.Exam
{
    partial class frmExamQuestionnaireDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExamQuestionnaireDesigner));
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnAddPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnCopyPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.rGroupBox2 = new rComponents.rGroupBox(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnNewQuestion = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnNewEssayQuestion = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnNewTextItem = new System.Windows.Forms.ToolStripButton();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.radBtnSave = new Telerik.WinControls.UI.RadButton();
            this.rLblSave = new rComponents.rLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).BeginInit();
            this.rGroupBox2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox1.Controls.Add(this.listView1);
            this.rGroupBox1.Controls.Add(this.toolStrip1);
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "صــفـحــــات";
            this.rGroupBox1.Location = new System.Drawing.Point(653, 12);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(184, 388);
            this.rGroupBox1.TabIndex = 0;
            this.rGroupBox1.Text = "صــفـحــــات";
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(2, 45);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.RightToLeftLayout = true;
            this.listView1.Size = new System.Drawing.Size(180, 341);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "page_256.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnAddPage,
            this.toolStripBtnCopyPage,
            this.toolStripBtnDelete});
            this.toolStrip1.Location = new System.Drawing.Point(2, 20);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(180, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnAddPage
            // 
            this.toolStripBtnAddPage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnAddPage.Image")));
            this.toolStripBtnAddPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAddPage.Name = "toolStripBtnAddPage";
            this.toolStripBtnAddPage.Size = new System.Drawing.Size(49, 22);
            this.toolStripBtnAddPage.Text = "جدید";
            this.toolStripBtnAddPage.Click += new System.EventHandler(this.toolStripBtnAddPage_Click);
            // 
            // toolStripBtnCopyPage
            // 
            this.toolStripBtnCopyPage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnCopyPage.Image")));
            this.toolStripBtnCopyPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnCopyPage.Name = "toolStripBtnCopyPage";
            this.toolStripBtnCopyPage.Size = new System.Drawing.Size(50, 22);
            this.toolStripBtnCopyPage.Text = "کپـی";
            this.toolStripBtnCopyPage.Click += new System.EventHandler(this.toolStripBtnCopyPage_Click);
            // 
            // toolStripBtnDelete
            // 
            this.toolStripBtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnDelete.Image")));
            this.toolStripBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnDelete.Name = "toolStripBtnDelete";
            this.toolStripBtnDelete.Size = new System.Drawing.Size(50, 22);
            this.toolStripBtnDelete.Text = "حذف";
            this.toolStripBtnDelete.Click += new System.EventHandler(this.toolStripBtnDelete_Click);
            // 
            // rGroupBox2
            // 
            this.rGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox2.Controls.Add(this.panel1);
            this.rGroupBox2.Controls.Add(this.toolStrip2);
            this.rGroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox2.FooterImageIndex = -1;
            this.rGroupBox2.FooterImageKey = "";
            this.rGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox2.HeaderImageIndex = -1;
            this.rGroupBox2.HeaderImageKey = "";
            this.rGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox2.HeaderText = "طــراح صـفـحه";
            this.rGroupBox2.Location = new System.Drawing.Point(12, 12);
            this.rGroupBox2.Name = "rGroupBox2";
            this.rGroupBox2.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox2.Size = new System.Drawing.Size(635, 388);
            this.rGroupBox2.TabIndex = 1;
            this.rGroupBox2.Text = "طــراح صـفـحه";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(5, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 335);
            this.panel1.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnNewQuestion,
            this.toolStripBtnNewEssayQuestion,
            this.toolStripBtnNewTextItem});
            this.toolStrip2.Location = new System.Drawing.Point(2, 20);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(631, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripBtnNewQuestion
            // 
            this.toolStripBtnNewQuestion.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnNewQuestion.Image")));
            this.toolStripBtnNewQuestion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNewQuestion.Name = "toolStripBtnNewQuestion";
            this.toolStripBtnNewQuestion.Size = new System.Drawing.Size(111, 22);
            this.toolStripBtnNewQuestion.Text = "سئــــوال تستـــی";
            this.toolStripBtnNewQuestion.Click += new System.EventHandler(this.toolStripBtnNewQuestion_Click);
            // 
            // toolStripBtnNewEssayQuestion
            // 
            this.toolStripBtnNewEssayQuestion.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnNewEssayQuestion.Image")));
            this.toolStripBtnNewEssayQuestion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNewEssayQuestion.Name = "toolStripBtnNewEssayQuestion";
            this.toolStripBtnNewEssayQuestion.Size = new System.Drawing.Size(119, 22);
            this.toolStripBtnNewEssayQuestion.Text = "سئـــوال تشریحـــی";
            this.toolStripBtnNewEssayQuestion.Click += new System.EventHandler(this.toolStripBtnNewEssayQuestion_Click);
            // 
            // toolStripBtnNewTextItem
            // 
            this.toolStripBtnNewTextItem.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnNewTextItem.Image")));
            this.toolStripBtnNewTextItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNewTextItem.Name = "toolStripBtnNewTextItem";
            this.toolStripBtnNewTextItem.Size = new System.Drawing.Size(54, 22);
            this.toolStripBtnNewTextItem.Text = "مـتــن";
            this.toolStripBtnNewTextItem.Click += new System.EventHandler(this.toolStripBtnNewTextItem_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 406);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "تــایــیــد";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(12, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "انصــراف";
            // 
            // radBtnSave
            // 
            this.radBtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radBtnSave.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("radBtnSave.Image")));
            this.radBtnSave.Location = new System.Drawing.Point(698, 406);
            this.radBtnSave.Name = "radBtnSave";
            this.radBtnSave.Size = new System.Drawing.Size(130, 24);
            this.radBtnSave.TabIndex = 6;
            this.radBtnSave.Text = "ذخیــــره";
            this.radBtnSave.Click += new System.EventHandler(this.radBtnSave_Click);
            // 
            // rLblSave
            // 
            this.rLblSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rLblSave.AutoSize = false;
            this.rLblSave.BackColor = System.Drawing.Color.Transparent;
            this.rLblSave.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLblSave.Location = new System.Drawing.Point(339, 406);
            this.rLblSave.Name = "rLblSave";
            this.rLblSave.Size = new System.Drawing.Size(353, 24);
            this.rLblSave.TabIndex = 7;
            this.rLblSave.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmExamQuestionnaireDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 442);
            this.Controls.Add(this.rLblSave);
            this.Controls.Add(this.radBtnSave);
            this.Controls.Add(this.rGroupBox1);
            this.Controls.Add(this.rGroupBox2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "frmExamQuestionnaireDesigner";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "طراح پرسشنامه آزمون به صورت WYSIWYG";
            this.Load += new System.EventHandler(this.frmExamQuestionnaireDesigner_Load);
            this.Resize += new System.EventHandler(this.frmExamQuestionnaireDesigner_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            this.rGroupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).EndInit();
            this.rGroupBox2.ResumeLayout(false);
            this.rGroupBox2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rGroupBox rGroupBox2;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnAddPage;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton toolStripBtnNewQuestion;
        private System.Windows.Forms.ToolStripButton toolStripBtnNewTextItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton toolStripBtnNewEssayQuestion;
        private System.Windows.Forms.ToolStripButton toolStripBtnCopyPage;
        private System.Windows.Forms.ToolStripButton toolStripBtnDelete;
        private Telerik.WinControls.UI.RadButton radBtnSave;
        private rComponents.rLabel rLblSave;
    }
}