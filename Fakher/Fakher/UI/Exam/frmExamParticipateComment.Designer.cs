namespace Fakher.UI.Exam
{
    partial class frmExamParticipateComment
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
            this.rTextBox3 = new rComponents.rTextBox(this.components);
            this.rLabel6 = new rComponents.rLabel(this.components);
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rTextBox3
            // 
            this.rTextBox3.AcceptsReturn = true;
            this.rTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox3.Culture = null;
            this.rTextBox3.FieldName = null;
            this.rTextBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox3.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox3.Location = new System.Drawing.Point(12, 12);
            this.rTextBox3.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox3.MaximumValue = null;
            this.rTextBox3.MinimumValue = null;
            this.rTextBox3.Multiline = true;
            this.rTextBox3.Name = "rTextBox3";
            this.rTextBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.rTextBox3.RootElement.StretchVertically = true;
            this.rTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.rTextBox3.Size = new System.Drawing.Size(313, 83);
            this.rTextBox3.TabIndex = 0;
            this.rTextBox3.TabStop = false;
            this.rTextBox3.Type = rComponents.rTextBoxType.Text;
            this.rTextBox3.ValidatingProperty = null;
            this.rTextBox3.ValidationType = rComponents.ValidationType.None;
            // 
            // rLabel6
            // 
            this.rLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel6.BackColor = System.Drawing.Color.Transparent;
            this.rLabel6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel6.Location = new System.Drawing.Point(331, 12);
            this.rLabel6.Name = "rLabel6";
            this.rLabel6.Size = new System.Drawing.Size(77, 17);
            this.rLabel6.TabIndex = 14;
            this.rLabel6.Text = "تــوضــیـحــــات:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 101);
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
            this.btnCancel.Location = new System.Drawing.Point(12, 101);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "انصــراف";
            // 
            // frmExamParticipateComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 137);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rTextBox3);
            this.Controls.Add(this.rLabel6);
            this.Name = "frmExamParticipateComment";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "توضیحات داوطلب آزمون";
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rTextBox rTextBox3;
        private rComponents.rLabel rLabel6;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}