namespace Fakher.UI.Sections
{
    partial class frmSectionFundamentalDetail
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
            this.majorSelector1 = new Fakher.Controls.MajorSelector();
            this.sectionSelector1 = new Fakher.Controls.SectionSelector();
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.rTextBox1 = new rComponents.rTextBox(this.components);
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.rDatePickerFinish = new rComponents.rDatePicker(this.components);
            this.rDatePickerStart = new rComponents.rDatePicker(this.components);
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePickerFinish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePickerStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
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
            this.majorSelector1.Size = new System.Drawing.Size(655, 25);
            this.majorSelector1.TabIndex = 0;
            // 
            // sectionSelector1
            // 
            this.sectionSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sectionSelector1.BackColor = System.Drawing.Color.Transparent;
            this.sectionSelector1.Location = new System.Drawing.Point(12, 43);
            this.sectionSelector1.MajorSelector = this.majorSelector1;
            this.sectionSelector1.Name = "sectionSelector1";
            this.sectionSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sectionSelector1.ShowNullButton = false;
            this.sectionSelector1.Size = new System.Drawing.Size(655, 24);
            this.sectionSelector1.TabIndex = 1;
            this.sectionSelector1.SelectedChanged += new System.EventHandler(this.sectionSelector1_SelectedChanged);
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox1.Controls.Add(this.rTextBox1);
            this.rGroupBox1.Controls.Add(this.radLabel6);
            this.rGroupBox1.Controls.Add(this.rDatePickerFinish);
            this.rGroupBox1.Controls.Add(this.rDatePickerStart);
            this.rGroupBox1.Controls.Add(this.radLabel3);
            this.rGroupBox1.Controls.Add(this.radLabel4);
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "مشخصات گــــروه";
            this.rGroupBox1.Location = new System.Drawing.Point(12, 73);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(655, 100);
            this.rGroupBox1.TabIndex = 2;
            this.rGroupBox1.Text = "مشخصات گــــروه";
            // 
            // rTextBox1
            // 
            this.rTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox1.Culture = null;
            this.rTextBox1.FieldName = "ظرفیت کلاس";
            this.rTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox1.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox1.Location = new System.Drawing.Point(395, 54);
            this.rTextBox1.Mask = "D";
            this.rTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.rTextBox1.MaximumValue = null;
            this.rTextBox1.MinimumValue = "1";
            this.rTextBox1.Name = "rTextBox1";
            this.rTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox1.Size = new System.Drawing.Size(186, 19);
            this.rTextBox1.TabIndex = 2;
            this.rTextBox1.TabStop = false;
            this.rTextBox1.Type = rComponents.rTextBoxType.Numeric;
            this.rTextBox1.ValidatingProperty = null;
            this.rTextBox1.ValidationType = rComponents.ValidationType.InRange;
            // 
            // radLabel6
            // 
            this.radLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel6.BackColor = System.Drawing.Color.Transparent;
            this.radLabel6.Location = new System.Drawing.Point(587, 56);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(59, 17);
            this.radLabel6.TabIndex = 49;
            this.radLabel6.Text = "ظرفیت کل:";
            // 
            // rDatePickerFinish
            // 
            this.rDatePickerFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePickerFinish.BackColor = System.Drawing.SystemColors.Control;
            this.rDatePickerFinish.Culture = null;
            this.rDatePickerFinish.FieldName = "تاریخ پایان";
            this.rDatePickerFinish.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rDatePickerFinish.Location = new System.Drawing.Point(5, 29);
            this.rDatePickerFinish.Mask = "1###/##/##";
            this.rDatePickerFinish.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePickerFinish.Name = "rDatePickerFinish";
            this.rDatePickerFinish.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePickerFinish.SelectionStart = 10;
            this.rDatePickerFinish.Size = new System.Drawing.Size(186, 19);
            this.rDatePickerFinish.TabIndex = 1;
            this.rDatePickerFinish.TabStop = false;
            this.rDatePickerFinish.Text = "1___/__/__";
            this.rDatePickerFinish.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rDatePickerFinish.Value = "";
            // 
            // rDatePickerStart
            // 
            this.rDatePickerStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePickerStart.BackColor = System.Drawing.SystemColors.Control;
            this.rDatePickerStart.Culture = null;
            this.rDatePickerStart.FieldName = "تاریخ شروع";
            this.rDatePickerStart.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rDatePickerStart.Location = new System.Drawing.Point(395, 29);
            this.rDatePickerStart.Mask = "1###/##/##";
            this.rDatePickerStart.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePickerStart.Name = "rDatePickerStart";
            this.rDatePickerStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePickerStart.SelectionStart = 10;
            this.rDatePickerStart.Size = new System.Drawing.Size(186, 19);
            this.rDatePickerStart.TabIndex = 0;
            this.rDatePickerStart.TabStop = false;
            this.rDatePickerStart.Text = "1___/__/__";
            this.rDatePickerStart.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rDatePickerStart.Value = "";
            // 
            // radLabel3
            // 
            this.radLabel3.BackColor = System.Drawing.Color.Transparent;
            this.radLabel3.Location = new System.Drawing.Point(197, 31);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(56, 17);
            this.radLabel3.TabIndex = 46;
            this.radLabel3.Text = "تاریخ پایان:";
            // 
            // radLabel4
            // 
            this.radLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel4.BackColor = System.Drawing.Color.Transparent;
            this.radLabel4.Location = new System.Drawing.Point(587, 31);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(63, 17);
            this.radLabel4.TabIndex = 47;
            this.radLabel4.Text = "تاریخ شروع:";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnExit.Location = new System.Drawing.Point(12, 190);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(153, 24);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "خــــروج";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnSave.Location = new System.Drawing.Point(176, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(153, 24);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "ذخیره";
            this.btnSave.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmSectionFundamentalDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 226);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rGroupBox1);
            this.Controls.Add(this.sectionSelector1);
            this.Controls.Add(this.majorSelector1);
            this.Name = "frmSectionFundamentalDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات پایه گروه";
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            this.rGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePickerFinish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePickerStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Fakher.Controls.MajorSelector majorSelector1;
        private Fakher.Controls.SectionSelector sectionSelector1;
        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rDatePicker rDatePickerFinish;
        private rComponents.rDatePicker rDatePickerStart;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private rComponents.rTextBox rTextBox1;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadButton btnExit;
        private Telerik.WinControls.UI.RadButton btnSave;
    }
}