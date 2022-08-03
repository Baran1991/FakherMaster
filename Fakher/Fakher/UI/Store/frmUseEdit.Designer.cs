namespace Fakher.UI.Store
{
    partial class frmUseEdit
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
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rTxtCount = new rComponents.rTextBox(this.components);
            this.rLabel5 = new rComponents.rLabel(this.components);
            this.lblBookName = new rComponents.rLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBookName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 153);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "تـصحـیــح";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(12, 153);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "خــــــروج";
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(122, 26);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(72, 24);
            this.rLabel1.TabIndex = 7;
            this.rLabel1.Text = "نام کتاب:";
            // 
            // rTxtCount
            // 
            this.rTxtCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtCount.BackColor = System.Drawing.Color.White;
            this.rTxtCount.Culture = null;
            this.rTxtCount.FieldName = "تعداد کل";
            this.rTxtCount.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTxtCount.Language = rComponents.TextboxLanguage.DontCare;
            this.rTxtCount.Location = new System.Drawing.Point(34, 85);
            this.rTxtCount.Mask = "D";
            this.rTxtCount.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.rTxtCount.MaximumValue = null;
            this.rTxtCount.MinimumValue = "1";
            this.rTxtCount.Name = "rTxtCount";
            this.rTxtCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTxtCount.Size = new System.Drawing.Size(92, 25);
            this.rTxtCount.TabIndex = 0;
            this.rTxtCount.TabStop = false;
            this.rTxtCount.Type = rComponents.rTextBoxType.Numeric;
            this.rTxtCount.ValidatingProperty = null;
            this.rTxtCount.ValidationType = rComponents.ValidationType.InRange;
            // 
            // rLabel5
            // 
            this.rLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel5.BackColor = System.Drawing.Color.Transparent;
            this.rLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel5.Location = new System.Drawing.Point(148, 86);
            this.rLabel5.Name = "rLabel5";
            this.rLabel5.Size = new System.Drawing.Size(48, 24);
            this.rLabel5.TabIndex = 9;
            this.rLabel5.Text = "تعداد:";
            // 
            // lblBookName
            // 
            this.lblBookName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBookName.BackColor = System.Drawing.Color.Transparent;
            this.lblBookName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblBookName.Location = new System.Drawing.Point(34, 26);
            this.lblBookName.Name = "lblBookName";
            this.lblBookName.Size = new System.Drawing.Size(66, 24);
            this.lblBookName.TabIndex = 8;
            this.lblBookName.Text = "نام کتاب";
            // 
            // frmUseEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(473, 204);
            this.Controls.Add(this.rTxtCount);
            this.Controls.Add(this.lblBookName);
            this.Controls.Add(this.rLabel5);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmUseEdit";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "تعداد کتاب";
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBookName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private rComponents.rLabel rLabel1;
        private rComponents.rTextBox rTxtCount;
        private rComponents.rLabel rLabel5;
        private rComponents.rLabel lblBookName;
    }
}