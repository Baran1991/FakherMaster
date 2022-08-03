namespace Fakher.UI.Website
{
    partial class frmWebsiteSectionDetail
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
            this.rTextBox1 = new rComponents.rTextBox(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.rCheckBox1 = new rComponents.rCheckBox(this.components);
            this.rCmbDepartment = new rComponents.rComboBox(this.components);
            this.rChkDepartmentBinding = new rComponents.rCheckBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCheckBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCmbDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rChkDepartmentBinding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rTextBox1
            // 
            this.rTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox1.Culture = null;
            this.rTextBox1.FieldName = "متن منو";
            this.rTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox1.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox1.Location = new System.Drawing.Point(12, 12);
            this.rTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox1.MaximumValue = null;
            this.rTextBox1.MinimumValue = null;
            this.rTextBox1.Name = "rTextBox1";
            this.rTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rTextBox1.Size = new System.Drawing.Size(346, 19);
            this.rTextBox1.TabIndex = 0;
            this.rTextBox1.TabStop = false;
            this.rTextBox1.Type = rComponents.rTextBoxType.Text;
            this.rTextBox1.ValidatingProperty = null;
            this.rTextBox1.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(364, 13);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(36, 17);
            this.rLabel1.TabIndex = 8;
            this.rLabel1.Text = "عنوان:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 105);
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
            this.btnCancel.Location = new System.Drawing.Point(12, 105);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "انصــراف";
            // 
            // rCheckBox1
            // 
            this.rCheckBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.rCheckBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rCheckBox1.Location = new System.Drawing.Point(236, 66);
            this.rCheckBox1.Name = "rCheckBox1";
            this.rCheckBox1.Size = new System.Drawing.Size(164, 17);
            this.rCheckBox1.TabIndex = 3;
            this.rCheckBox1.Text = "نمایش تقویم آموزشی دپارتمان";
            // 
            // rCmbDepartment
            // 
            this.rCmbDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rCmbDepartment.DropDownAnimationEnabled = true;
            this.rCmbDepartment.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rCmbDepartment.FieldName = "دپارتمان";
            this.rCmbDepartment.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rCmbDepartment.Location = new System.Drawing.Point(12, 37);
            this.rCmbDepartment.MaximumValue = null;
            this.rCmbDepartment.MinimumValue = null;
            this.rCmbDepartment.Name = "rCmbDepartment";
            this.rCmbDepartment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rCmbDepartment.ShowImageInEditorArea = true;
            this.rCmbDepartment.Size = new System.Drawing.Size(283, 19);
            this.rCmbDepartment.TabIndex = 2;
            this.rCmbDepartment.ValidatingProperty = null;
            this.rCmbDepartment.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // rChkDepartmentBinding
            // 
            this.rChkDepartmentBinding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rChkDepartmentBinding.BackColor = System.Drawing.Color.Transparent;
            this.rChkDepartmentBinding.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rChkDepartmentBinding.Location = new System.Drawing.Point(301, 39);
            this.rChkDepartmentBinding.Name = "rChkDepartmentBinding";
            this.rChkDepartmentBinding.Size = new System.Drawing.Size(99, 17);
            this.rChkDepartmentBinding.TabIndex = 1;
            this.rChkDepartmentBinding.Text = "اتصال به دپارتمان";
            this.rChkDepartmentBinding.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.rChkDepartmentBinding_ToggleStateChanged);
            // 
            // frmWebsiteSectionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 141);
            this.Controls.Add(this.rCmbDepartment);
            this.Controls.Add(this.rChkDepartmentBinding);
            this.Controls.Add(this.rCheckBox1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rTextBox1);
            this.Controls.Add(this.rLabel1);
            this.Name = "frmWebsiteSectionDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات بخش";
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCheckBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCmbDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rChkDepartmentBinding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rTextBox rTextBox1;
        private rComponents.rLabel rLabel1;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private rComponents.rCheckBox rCheckBox1;
        private rComponents.rComboBox rCmbDepartment;
        private rComponents.rCheckBox rChkDepartmentBinding;
    }
}