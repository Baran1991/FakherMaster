namespace Fakher.UI
{
    partial class frmEvalItemDetail
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
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.rTxtValue = new rComponents.rTextBox(this.components);
            this.rTxtName = new rComponents.rTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Location = new System.Drawing.Point(310, 14);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(45, 17);
            this.radLabel2.TabIndex = 14;
            this.radLabel2.Text = "نام آیتم:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 79);
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
            this.btnCancel.Location = new System.Drawing.Point(12, 79);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "انصــراف";
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Location = new System.Drawing.Point(310, 42);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(35, 17);
            this.radLabel1.TabIndex = 14;
            this.radLabel1.Text = "مقدار:";
            // 
            // rTxtValue
            // 
            this.rTxtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtValue.BackColor = System.Drawing.Color.Transparent;
            this.rTxtValue.FieldName = "مقدار آیتم";
            this.rTxtValue.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTxtValue.Language = rComponents.TextboxLanguage.DontCare;
            this.rTxtValue.Location = new System.Drawing.Point(12, 40);
            this.rTxtValue.MaximumValue = null;
            this.rTxtValue.MinimumValue = "1";
            this.rTxtValue.Name = "rTxtValue";
            this.rTxtValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTxtValue.Size = new System.Drawing.Size(292, 21);
            this.rTxtValue.TabIndex = 1;
            this.rTxtValue.TabStop = false;
            this.rTxtValue.Text = "0";
            this.rTxtValue.Type = rComponents.rTextBoxType.Numeric;
            this.rTxtValue.ValidatingProperty = null;
            this.rTxtValue.ValidationType = rComponents.ValidationType.InRange;
            this.rTxtValue.Value = 0;
            // 
            // rTxtName
            // 
            this.rTxtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtName.BackColor = System.Drawing.Color.Transparent;
            this.rTxtName.FieldName = "نام آیتم";
            this.rTxtName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTxtName.Language = rComponents.TextboxLanguage.Farsi;
            this.rTxtName.Location = new System.Drawing.Point(12, 12);
            this.rTxtName.MaximumValue = null;
            this.rTxtName.MinimumValue = null;
            this.rTxtName.Name = "rTxtName";
            this.rTxtName.NullText = "<اجباری>";
            this.rTxtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rTxtName.Size = new System.Drawing.Size(292, 21);
            this.rTxtName.TabIndex = 0;
            this.rTxtName.TabStop = false;
            this.rTxtName.Type = rComponents.rTextBoxType.Text;
            this.rTxtName.ValidatingProperty = null;
            this.rTxtName.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rTxtName.Value = "";
            // 
            // frmEvalItemDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 115);
            this.Controls.Add(this.rTxtName);
            this.Controls.Add(this.rTxtValue);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel2);
            this.Name = "frmEvalItemDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مقدار آیتم ارزشیابی";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private rComponents.rTextBox rTxtValue;
        private rComponents.rTextBox rTxtName;
    }
}