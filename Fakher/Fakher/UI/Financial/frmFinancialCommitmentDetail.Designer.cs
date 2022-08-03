namespace Fakher.UI.Financial
{
    partial class frmFinancialCommitmentDetail
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
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.rCmbType = new rComponents.rComboBox(this.components);
            this.rDatePicker1 = new rComponents.rDatePicker(this.components);
            this.rLabel4 = new rComponents.rLabel(this.components);
            this.rCmbStatus = new rComponents.rComboBox(this.components);
            this.rLabel5 = new rComponents.rLabel(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rDatePicker2 = new rComponents.rDatePicker(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCmbType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCmbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radTextBox1
            // 
            this.radTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.radTextBox1.Culture = null;
            this.radTextBox1.FieldName = "مبلغ";
            this.radTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radTextBox1.Language = rComponents.TextboxLanguage.DontCare;
            this.radTextBox1.Location = new System.Drawing.Point(12, 38);
            this.radTextBox1.Mask = "c0";
            this.radTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.radTextBox1.MaximumValue = null;
            this.radTextBox1.MinimumValue = "1";
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radTextBox1.Size = new System.Drawing.Size(176, 19);
            this.radTextBox1.TabIndex = 2;
            this.radTextBox1.TabStop = false;
            this.radTextBox1.Type = rComponents.rTextBoxType.Money;
            this.radTextBox1.ValidatingProperty = null;
            this.radTextBox1.ValidationType = rComponents.ValidationType.InRange;
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(194, 38);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(31, 17);
            this.rLabel2.TabIndex = 16;
            this.rLabel2.Text = "مبلغ:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 137);
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
            this.btnCancel.Location = new System.Drawing.Point(12, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "انصــراف";
            // 
            // rLabel3
            // 
            this.rLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel3.BackColor = System.Drawing.Color.Transparent;
            this.rLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel3.Location = new System.Drawing.Point(470, 38);
            this.rLabel3.Name = "rLabel3";
            this.rLabel3.Size = new System.Drawing.Size(50, 17);
            this.rLabel3.TabIndex = 19;
            this.rLabel3.Text = "نوع تعهد:";
            // 
            // rCmbType
            // 
            this.rCmbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rCmbType.DropDownAnimationEnabled = true;
            this.rCmbType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rCmbType.FieldName = null;
            this.rCmbType.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rCmbType.Location = new System.Drawing.Point(288, 38);
            this.rCmbType.MaximumValue = null;
            this.rCmbType.MinimumValue = null;
            this.rCmbType.Name = "rCmbType";
            this.rCmbType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rCmbType.ShowImageInEditorArea = true;
            this.rCmbType.Size = new System.Drawing.Size(176, 19);
            this.rCmbType.TabIndex = 1;
            this.rCmbType.ValidatingProperty = null;
            this.rCmbType.ValidationType = rComponents.ValidationType.None;
            // 
            // rDatePicker1
            // 
            this.rDatePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePicker1.BackColor = System.Drawing.Color.Transparent;
            this.rDatePicker1.Culture = null;
            this.rDatePicker1.FieldName = "تاریخ";
            this.rDatePicker1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rDatePicker1.Location = new System.Drawing.Point(288, 13);
            this.rDatePicker1.Mask = "1###/##/##";
            this.rDatePicker1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePicker1.Name = "rDatePicker1";
            this.rDatePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePicker1.SelectionStart = 10;
            this.rDatePicker1.Size = new System.Drawing.Size(176, 19);
            this.rDatePicker1.TabIndex = 0;
            this.rDatePicker1.TabStop = false;
            this.rDatePicker1.Text = "1389/07/26";
            this.rDatePicker1.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rDatePicker1.Value = "890726";
            // 
            // rLabel4
            // 
            this.rLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel4.BackColor = System.Drawing.Color.Transparent;
            this.rLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel4.Location = new System.Drawing.Point(470, 14);
            this.rLabel4.Name = "rLabel4";
            this.rLabel4.Size = new System.Drawing.Size(76, 17);
            this.rLabel4.TabIndex = 22;
            this.rLabel4.Text = "سررسید تعهد:";
            // 
            // rCmbStatus
            // 
            this.rCmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rCmbStatus.DropDownAnimationEnabled = true;
            this.rCmbStatus.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rCmbStatus.FieldName = null;
            this.rCmbStatus.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rCmbStatus.Location = new System.Drawing.Point(288, 87);
            this.rCmbStatus.MaximumValue = null;
            this.rCmbStatus.MinimumValue = null;
            this.rCmbStatus.Name = "rCmbStatus";
            this.rCmbStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rCmbStatus.ShowImageInEditorArea = true;
            this.rCmbStatus.Size = new System.Drawing.Size(176, 19);
            this.rCmbStatus.TabIndex = 3;
            this.rCmbStatus.ValidatingProperty = null;
            this.rCmbStatus.ValidationType = rComponents.ValidationType.None;
            // 
            // rLabel5
            // 
            this.rLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel5.BackColor = System.Drawing.Color.Transparent;
            this.rLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel5.Location = new System.Drawing.Point(470, 87);
            this.rLabel5.Name = "rLabel5";
            this.rLabel5.Size = new System.Drawing.Size(44, 17);
            this.rLabel5.TabIndex = 23;
            this.rLabel5.Text = "وضعیت:";
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(194, 88);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(84, 17);
            this.rLabel1.TabIndex = 22;
            this.rLabel1.Text = "تاریخ انجام تعهد:";
            // 
            // rDatePicker2
            // 
            this.rDatePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePicker2.BackColor = System.Drawing.Color.Transparent;
            this.rDatePicker2.Culture = null;
            this.rDatePicker2.FieldName = "تاریخ";
            this.rDatePicker2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rDatePicker2.Location = new System.Drawing.Point(12, 87);
            this.rDatePicker2.Mask = "1###/##/##";
            this.rDatePicker2.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePicker2.Name = "rDatePicker2";
            this.rDatePicker2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePicker2.SelectionStart = 10;
            this.rDatePicker2.Size = new System.Drawing.Size(176, 19);
            this.rDatePicker2.TabIndex = 0;
            this.rDatePicker2.TabStop = false;
            this.rDatePicker2.Text = "1389/07/26";
            this.rDatePicker2.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rDatePicker2.Value = "890726";
            // 
            // frmFinancialCommitmentDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 173);
            this.Controls.Add(this.rCmbStatus);
            this.Controls.Add(this.rLabel5);
            this.Controls.Add(this.rDatePicker2);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.rDatePicker1);
            this.Controls.Add(this.rLabel4);
            this.Controls.Add(this.rCmbType);
            this.Controls.Add(this.rLabel3);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.rLabel2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Name = "frmFinancialCommitmentDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات تعهد مالی";
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCmbType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCmbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rTextBox radTextBox1;
        private rComponents.rLabel rLabel2;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private rComponents.rLabel rLabel3;
        private rComponents.rComboBox rCmbType;
        private rComponents.rDatePicker rDatePicker1;
        private rComponents.rLabel rLabel4;
        private rComponents.rComboBox rCmbStatus;
        private rComponents.rLabel rLabel5;
        private rComponents.rLabel rLabel1;
        private rComponents.rDatePicker rDatePicker2;
    }
}