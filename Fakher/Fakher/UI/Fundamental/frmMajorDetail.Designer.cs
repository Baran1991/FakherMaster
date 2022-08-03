namespace Fakher.UI.Struture
{
    partial class frmMajorDetail
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
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radTextBox1 = new rComponents.rTextBox(this.components);
            this.radTextBox2 = new rComponents.rTextBox(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rCheckBox1 = new rComponents.rCheckBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCheckBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(12, 99);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "انصــراف";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 99);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "تــایــیــد";
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.Location = new System.Drawing.Point(284, 41);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(53, 17);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "نام رشته:";
            // 
            // radTextBox1
            // 
            this.radTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.radTextBox1.Culture = null;
            this.radTextBox1.FieldName = "نام رشته";
            this.radTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radTextBox1.Language = rComponents.TextboxLanguage.Farsi;
            this.radTextBox1.Location = new System.Drawing.Point(13, 39);
            this.radTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.radTextBox1.MaximumValue = null;
            this.radTextBox1.MinimumValue = null;
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radTextBox1.Size = new System.Drawing.Size(265, 19);
            this.radTextBox1.TabIndex = 1;
            this.radTextBox1.TabStop = false;
            this.radTextBox1.Type = rComponents.rTextBoxType.Text;
            this.radTextBox1.ValidatingProperty = null;
            this.radTextBox1.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // radTextBox2
            // 
            this.radTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.radTextBox2.Culture = null;
            this.radTextBox2.FieldName = "کد";
            this.radTextBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radTextBox2.Language = rComponents.TextboxLanguage.English;
            this.radTextBox2.Location = new System.Drawing.Point(148, 12);
            this.radTextBox2.Mask = "D";
            this.radTextBox2.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.radTextBox2.MaximumValue = null;
            this.radTextBox2.MinimumValue = null;
            this.radTextBox2.Name = "radTextBox2";
            this.radTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radTextBox2.Size = new System.Drawing.Size(130, 19);
            this.radTextBox2.TabIndex = 0;
            this.radTextBox2.TabStop = false;
            this.radTextBox2.Type = rComponents.rTextBoxType.Numeric;
            this.radTextBox2.ValidatingProperty = null;
            this.radTextBox2.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(284, 14);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(51, 17);
            this.rLabel1.TabIndex = 8;
            this.rLabel1.Text = "کد رشته:";
            // 
            // rCheckBox1
            // 
            this.rCheckBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.rCheckBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rCheckBox1.Location = new System.Drawing.Point(136, 66);
            this.rCheckBox1.Name = "rCheckBox1";
            this.rCheckBox1.Size = new System.Drawing.Size(142, 17);
            this.rCheckBox1.TabIndex = 2;
            this.rCheckBox1.Text = "امکـان ثبـت نــام اینتـرنتـی";
            // 
            // frmMajorDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 135);
            this.Controls.Add(this.rCheckBox1);
            this.Controls.Add(this.radTextBox2);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Name = "frmMajorDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات رشته";
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCheckBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private rComponents.rTextBox radTextBox1;
        private rComponents.rTextBox radTextBox2;
        private rComponents.rLabel rLabel1;
        private rComponents.rCheckBox rCheckBox1;
    }
}