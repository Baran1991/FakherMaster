namespace Fakher.UI.Fundamental
{
    partial class frmEducationalToolGroupDetail
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
            this.radTextBox1 = new rComponents.rTextBox(this.components);
            this.radLabel1 = new rComponents.rLabel(this.components);
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.lessonSelector1 = new Fakher.Controls.LessonSelector();
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.rGridView1 = new rComponents.rGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radTextBox1
            // 
            this.radTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.radTextBox1.Culture = null;
            this.radTextBox1.FieldName = "نام";
            this.radTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radTextBox1.Language = rComponents.TextboxLanguage.DontCare;
            this.radTextBox1.Location = new System.Drawing.Point(15, 10);
            this.radTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.radTextBox1.MaximumValue = null;
            this.radTextBox1.MinimumValue = null;
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radTextBox1.Size = new System.Drawing.Size(537, 19);
            this.radTextBox1.TabIndex = 0;
            this.radTextBox1.TabStop = false;
            this.radTextBox1.Type = rComponents.rTextBoxType.Text;
            this.radTextBox1.ValidatingProperty = null;
            this.radTextBox1.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radLabel1.Location = new System.Drawing.Point(558, 11);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(23, 17);
            this.radLabel1.TabIndex = 9;
            this.radLabel1.Text = "نام:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 334);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "تــایــیــد";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(12, 334);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "انصــراف";
            // 
            // lessonSelector1
            // 
            this.lessonSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lessonSelector1.BackColor = System.Drawing.Color.Transparent;
            this.lessonSelector1.Location = new System.Drawing.Point(12, 35);
            this.lessonSelector1.MajorSelector = null;
            this.lessonSelector1.Name = "lessonSelector1";
            this.lessonSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lessonSelector1.ShowAllLessons = false;
            this.lessonSelector1.ShowExamHoldingLessons = false;
            this.lessonSelector1.ShowNullButton = true;
            this.lessonSelector1.Size = new System.Drawing.Size(624, 24);
            this.lessonSelector1.TabIndex = 1;
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox1.Controls.Add(this.rGridView1);
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "کتاب هـا";
            this.rGroupBox1.Location = new System.Drawing.Point(12, 65);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(624, 263);
            this.rGroupBox1.TabIndex = 2;
            this.rGroupBox1.Text = "کتاب هـا";
            // 
            // rGridView1
            // 
            this.rGridView1.CanAdd = true;
            this.rGridView1.CanDelete = true;
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
            this.rGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.rGridView1.Size = new System.Drawing.Size(620, 241);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Delete += new System.EventHandler(this.rGridView1_Delete);
            this.rGridView1.Add += new System.EventHandler(this.rGridView1_Add);
            // 
            // frmEducationalToolGroupDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 370);
            this.Controls.Add(this.rGroupBox1);
            this.Controls.Add(this.lessonSelector1);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Name = "frmEducationalToolGroupDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات گروه";
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rTextBox radTextBox1;
        private rComponents.rLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Fakher.Controls.LessonSelector lessonSelector1;
        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rGridView rGridView1;
    }
}