namespace Fakher.UI.Persons
{
    partial class frmFinancialNoteDetail
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
            this.rTextBox18 = new rComponents.rTextBox(this.components);
            this.rLabel21 = new rComponents.rLabel(this.components);
            this.rDatePicker1 = new rComponents.rDatePicker(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rTextBox18
            // 
            this.rTextBox18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox18.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox18.Culture = null;
            this.rTextBox18.FieldName = null;
            this.rTextBox18.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox18.Language = rComponents.TextboxLanguage.Farsi;
            this.rTextBox18.Location = new System.Drawing.Point(12, 60);
            this.rTextBox18.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox18.MaximumValue = null;
            this.rTextBox18.MinimumValue = null;
            this.rTextBox18.Multiline = true;
            this.rTextBox18.Name = "rTextBox18";
            this.rTextBox18.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.rTextBox18.RootElement.StretchVertically = true;
            this.rTextBox18.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.rTextBox18.Size = new System.Drawing.Size(564, 200);
            this.rTextBox18.TabIndex = 2;
            this.rTextBox18.TabStop = false;
            this.rTextBox18.Type = rComponents.rTextBoxType.Text;
            this.rTextBox18.ValidatingProperty = null;
            this.rTextBox18.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // rLabel21
            // 
            this.rLabel21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel21.BackColor = System.Drawing.Color.Transparent;
            this.rLabel21.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel21.Location = new System.Drawing.Point(581, 60);
            this.rLabel21.Name = "rLabel21";
            this.rLabel21.Size = new System.Drawing.Size(48, 24);
            this.rLabel21.TabIndex = 3;
            this.rLabel21.Text = "شرح:";
            // 
            // rDatePicker1
            // 
            this.rDatePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePicker1.Culture = null;
            this.rDatePicker1.FieldName = "تاریخ";
            this.rDatePicker1.Location = new System.Drawing.Point(447, 18);
            this.rDatePicker1.Mask = "1###/##/##";
            this.rDatePicker1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePicker1.Name = "rDatePicker1";
            this.rDatePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePicker1.Size = new System.Drawing.Size(129, 25);
            this.rDatePicker1.TabIndex = 1;
            this.rDatePicker1.TabStop = false;
            this.rDatePicker1.Text = "1300/00/__";
            this.rDatePicker1.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rDatePicker1.Value = "";
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(582, 18);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(47, 24);
            this.rLabel1.TabIndex = 4;
            this.rLabel1.Text = "تاریخ:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 284);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "تــایــیــد";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(12, 284);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "انصــراف";
            // 
            // frmFinancialNoteDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(657, 320);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.rDatePicker1);
            this.Controls.Add(this.rLabel21);
            this.Controls.Add(this.rTextBox18);
            this.Name = "frmFinancialNoteDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "توضیح مالی";
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rTextBox rTextBox18;
        private rComponents.rLabel rLabel21;
        private rComponents.rDatePicker rDatePicker1;
        private rComponents.rLabel rLabel1;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}