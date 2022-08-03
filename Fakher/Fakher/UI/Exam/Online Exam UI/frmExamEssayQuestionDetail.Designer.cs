namespace Fakher.UI.Exam.Online_Exam_UI
{
    partial class frmExamEssayQuestionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExamEssayQuestionDetail));
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.rHtmlEditorToolbar1 = new rComponents.rHtmlEditorToolbar();
            this.rHtmlEditorText = new rComponents.rHtmlEditor();
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rGridComboBox1 = new rComponents.rGridComboBox(this.components);
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 368);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "تــایــیــد";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(12, 368);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "انصــراف";
            // 
            // rHtmlEditorToolbar1
            // 
            this.rHtmlEditorToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rHtmlEditorToolbar1.FontSize = rComponents.FontSize.Three;
            this.rHtmlEditorToolbar1.HtmlEditor = this.rHtmlEditorText;
            this.rHtmlEditorToolbar1.Location = new System.Drawing.Point(0, 0);
            this.rHtmlEditorToolbar1.Name = "rHtmlEditorToolbar1";
            this.rHtmlEditorToolbar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rHtmlEditorToolbar1.Size = new System.Drawing.Size(658, 50);
            this.rHtmlEditorToolbar1.TabIndex = 5;
            // 
            // rHtmlEditorText
            // 
            this.rHtmlEditorText.BodyHtml = null;
            this.rHtmlEditorText.BodyText = null;
            this.rHtmlEditorText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rHtmlEditorText.DocumentText = resources.GetString("rHtmlEditorText.DocumentText");
            this.rHtmlEditorText.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rHtmlEditorText.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rHtmlEditorText.Location = new System.Drawing.Point(2, 20);
            this.rHtmlEditorText.Name = "rHtmlEditorText";
            this.rHtmlEditorText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rHtmlEditorText.Size = new System.Drawing.Size(630, 247);
            this.rHtmlEditorText.TabIndex = 0;
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(563, 69);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(83, 17);
            this.rLabel1.TabIndex = 7;
            this.rLabel1.Text = "آیـتـــم آزمـــــون:";
            // 
            // rGridComboBox1
            // 
            this.rGridComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridComboBox1.CompareMember = null;
            this.rGridComboBox1.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridComboBox1.NestedRadGridView
            // 
            this.rGridComboBox1.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridComboBox1.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBox1.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridComboBox1.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rGridComboBox1.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridComboBox1.EditorControl.MasterTemplate.EnableFiltering = true;
            this.rGridComboBox1.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBox1.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBox1.EditorControl.Name = "NestedRadGridView";
            this.rGridComboBox1.EditorControl.ReadOnly = true;
            this.rGridComboBox1.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridComboBox1.EditorControl.ShowGroupPanel = false;
            this.rGridComboBox1.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridComboBox1.EditorControl.TabIndex = 0;
            this.rGridComboBox1.FieldName = "آیتم آزمون";
            this.rGridComboBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBox1.Location = new System.Drawing.Point(12, 68);
            this.rGridComboBox1.MaximumValue = null;
            this.rGridComboBox1.MinimumValue = null;
            this.rGridComboBox1.Name = "rGridComboBox1";
            // 
            // 
            // 
            this.rGridComboBox1.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridComboBox1.ShowFilteringRow = true;
            this.rGridComboBox1.ShowNullButton = false;
            this.rGridComboBox1.Size = new System.Drawing.Size(545, 19);
            this.rGridComboBox1.TabIndex = 0;
            this.rGridComboBox1.TabStop = false;
            this.rGridComboBox1.ValidatingProperty = null;
            this.rGridComboBox1.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rGridComboBox1.Value = null;
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox1.Controls.Add(this.rHtmlEditorText);
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "مــتـــن";
            this.rGroupBox1.Location = new System.Drawing.Point(12, 93);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(634, 269);
            this.rGroupBox1.TabIndex = 1;
            this.rGroupBox1.Text = "مــتـــن";
            // 
            // frmExamEssayQuestionDetail
            // 
            this.AutoDialogButtons = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 404);
            this.Controls.Add(this.rGroupBox1);
            this.Controls.Add(this.rGridComboBox1);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.rHtmlEditorToolbar1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "frmExamEssayQuestionDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات سئوال تشریحی";
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private rComponents.rHtmlEditorToolbar rHtmlEditorToolbar1;
        private rComponents.rLabel rLabel1;
        private rComponents.rGridComboBox rGridComboBox1;
        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rHtmlEditor rHtmlEditorText;
    }
}