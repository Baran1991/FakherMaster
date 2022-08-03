namespace Fakher.UI.Exam
{
    partial class frmExamHoldingDetail
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
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rLabel7 = new rComponents.rLabel(this.components);
            this.rDatePicker1 = new rComponents.rDatePicker(this.components);
            this.rGroupBox4 = new rComponents.rGroupBox(this.components);
            this.rTextBox2 = new rComponents.rTextBox(this.components);
            this.rLabel4 = new rComponents.rLabel(this.components);
            this.rTextBox1 = new rComponents.rTextBox(this.components);
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGroupBox7 = new rComponents.rGroupBox(this.components);
            this.rGridViewFormations = new rComponents.rGridView();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox4)).BeginInit();
            this.rGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            this.radPageViewPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox7)).BeginInit();
            this.rGroupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
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
            this.radPageView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radPageView1.Location = new System.Drawing.Point(12, 12);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage1;
            this.radPageView1.Size = new System.Drawing.Size(673, 246);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.Text = "radPageView1";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Right;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.rLabel7);
            this.radPageViewPage1.Controls.Add(this.rDatePicker1);
            this.radPageViewPage1.Controls.Add(this.rGroupBox4);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 10);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(551, 225);
            this.radPageViewPage1.Text = "مشخصات عمومی";
            // 
            // rLabel7
            // 
            this.rLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel7.BackColor = System.Drawing.Color.Transparent;
            this.rLabel7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel7.Location = new System.Drawing.Point(439, 25);
            this.rLabel7.Name = "rLabel7";
            this.rLabel7.Size = new System.Drawing.Size(61, 17);
            this.rLabel7.TabIndex = 14;
            this.rLabel7.Text = "تاریخ آزمون:";
            // 
            // rDatePicker1
            // 
            this.rDatePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePicker1.Culture = null;
            this.rDatePicker1.FieldName = null;
            this.rDatePicker1.Location = new System.Drawing.Point(294, 24);
            this.rDatePicker1.Mask = "1###/##/##";
            this.rDatePicker1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePicker1.Name = "rDatePicker1";
            this.rDatePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePicker1.Size = new System.Drawing.Size(139, 19);
            this.rDatePicker1.TabIndex = 0;
            this.rDatePicker1.TabStop = false;
            this.rDatePicker1.Text = "1___/__/__";
            this.rDatePicker1.ValidationType = rComponents.ValidationType.None;
            this.rDatePicker1.Value = "";
            // 
            // rGroupBox4
            // 
            this.rGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox4.Controls.Add(this.rTextBox2);
            this.rGroupBox4.Controls.Add(this.rLabel4);
            this.rGroupBox4.Controls.Add(this.rTextBox1);
            this.rGroupBox4.Controls.Add(this.rLabel2);
            this.rGroupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox4.FooterImageIndex = -1;
            this.rGroupBox4.FooterImageKey = "";
            this.rGroupBox4.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox4.HeaderImageIndex = -1;
            this.rGroupBox4.HeaderImageKey = "";
            this.rGroupBox4.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox4.HeaderText = "محدوده شماره صندلی";
            this.rGroupBox4.Location = new System.Drawing.Point(3, 49);
            this.rGroupBox4.Name = "rGroupBox4";
            this.rGroupBox4.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox4.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox4.Size = new System.Drawing.Size(545, 73);
            this.rGroupBox4.TabIndex = 1;
            this.rGroupBox4.Text = "محدوده شماره صندلی";
            // 
            // rTextBox2
            // 
            this.rTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox2.Culture = null;
            this.rTextBox2.FieldName = "آخرین شماره صندلی";
            this.rTextBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox2.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox2.Location = new System.Drawing.Point(5, 33);
            this.rTextBox2.Mask = "D";
            this.rTextBox2.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.rTextBox2.MaximumValue = null;
            this.rTextBox2.MinimumValue = "1";
            this.rTextBox2.Name = "rTextBox2";
            this.rTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox2.Size = new System.Drawing.Size(139, 19);
            this.rTextBox2.TabIndex = 1;
            this.rTextBox2.TabStop = false;
            this.rTextBox2.Type = rComponents.rTextBoxType.Numeric;
            this.rTextBox2.ValidatingProperty = null;
            this.rTextBox2.ValidationType = rComponents.ValidationType.InRange;
            // 
            // rLabel4
            // 
            this.rLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel4.BackColor = System.Drawing.Color.Transparent;
            this.rLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel4.Location = new System.Drawing.Point(150, 34);
            this.rLabel4.Name = "rLabel4";
            this.rLabel4.Size = new System.Drawing.Size(108, 17);
            this.rLabel4.TabIndex = 0;
            this.rLabel4.Text = "آخرین شماره صندلی:";
            // 
            // rTextBox1
            // 
            this.rTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox1.Culture = null;
            this.rTextBox1.FieldName = "اولین شماره صندلی";
            this.rTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox1.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox1.Location = new System.Drawing.Point(291, 33);
            this.rTextBox1.Mask = "D";
            this.rTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.rTextBox1.MaximumValue = null;
            this.rTextBox1.MinimumValue = "1";
            this.rTextBox1.Name = "rTextBox1";
            this.rTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox1.Size = new System.Drawing.Size(139, 19);
            this.rTextBox1.TabIndex = 0;
            this.rTextBox1.TabStop = false;
            this.rTextBox1.Type = rComponents.rTextBoxType.Numeric;
            this.rTextBox1.ValidatingProperty = null;
            this.rTextBox1.ValidationType = rComponents.ValidationType.InRange;
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(436, 34);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(104, 17);
            this.rLabel2.TabIndex = 0;
            this.rLabel2.Text = "اولین شماره صندلی:";
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.rGroupBox7);
            this.radPageViewPage2.Location = new System.Drawing.Point(10, 10);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(551, 225);
            this.radPageViewPage2.Text = "زمان/مکان ها";
            // 
            // rGroupBox7
            // 
            this.rGroupBox7.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox7.Controls.Add(this.rGridViewFormations);
            this.rGroupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGroupBox7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox7.FooterImageIndex = -1;
            this.rGroupBox7.FooterImageKey = "";
            this.rGroupBox7.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox7.HeaderImageIndex = -1;
            this.rGroupBox7.HeaderImageKey = "";
            this.rGroupBox7.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox7.HeaderText = "شیفت های برگزاری آزمون";
            this.rGroupBox7.Location = new System.Drawing.Point(0, 0);
            this.rGroupBox7.Name = "rGroupBox7";
            this.rGroupBox7.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox7.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox7.Size = new System.Drawing.Size(551, 225);
            this.rGroupBox7.TabIndex = 14;
            this.rGroupBox7.Text = "شیفت های برگزاری آزمون";
            // 
            // rGridViewFormations
            // 
            this.rGridViewFormations.CanAdd = true;
            this.rGridViewFormations.CanDelete = true;
            this.rGridViewFormations.CanEdit = true;
            this.rGridViewFormations.CanExport = true;
            this.rGridViewFormations.CanFilter = true;
            this.rGridViewFormations.CanGroup = false;
            this.rGridViewFormations.CanNavigate = true;
            this.rGridViewFormations.CheckBoxes = false;
            this.rGridViewFormations.ColumnAutoSize = true;
            this.rGridViewFormations.ConfirmOnDelete = true;
            this.rGridViewFormations.CustomAddText = null;
            this.rGridViewFormations.CustomDeleteText = null;
            this.rGridViewFormations.CustomEditText = null;
            this.rGridViewFormations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewFormations.EditOnDoubleClick = true;
            this.rGridViewFormations.FieldName = "شیفت های برگزاری";
            this.rGridViewFormations.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewFormations.ItemImage = null;
            this.rGridViewFormations.Location = new System.Drawing.Point(2, 20);
            this.rGridViewFormations.MultiSelect = false;
            this.rGridViewFormations.Name = "rGridViewFormations";
            this.rGridViewFormations.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewFormations.RowHeight = 25;
            this.rGridViewFormations.ShowBottomToolbar = true;
            this.rGridViewFormations.ShowGroupPanel = true;
            this.rGridViewFormations.ShowTopToolbar = true;
            this.rGridViewFormations.Size = new System.Drawing.Size(547, 203);
            this.rGridViewFormations.TabIndex = 1;
            this.rGridViewFormations.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rGridViewFormations.Delete += new System.EventHandler(this.rGridViewFormations_Delete);
            this.rGridViewFormations.Edit += new System.EventHandler(this.rGridViewFormations_Edit);
            this.rGridViewFormations.Add += new System.EventHandler(this.rGridViewFormations_Add);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 264);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "تــایــیــد";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(12, 264);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "انصــراف";
            // 
            // frmExamHoldingDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 300);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.radPageView1);
            this.Name = "frmExamHoldingDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات برگزاری آزمون";
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox4)).EndInit();
            this.rGroupBox4.ResumeLayout(false);
            this.rGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            this.radPageViewPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox7)).EndInit();
            this.rGroupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private rComponents.rGroupBox rGroupBox4;
        private rComponents.rTextBox rTextBox2;
        private rComponents.rLabel rLabel4;
        private rComponents.rTextBox rTextBox1;
        private rComponents.rLabel rLabel2;
        private rComponents.rLabel rLabel7;
        private rComponents.rDatePicker rDatePicker1;
        private rComponents.rGroupBox rGroupBox7;
        private rComponents.rGridView rGridViewFormations;
    }
}