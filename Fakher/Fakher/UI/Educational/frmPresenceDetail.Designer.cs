namespace Fakher.UI.Educational.Common
{
    partial class frmPresenceDetail
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
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.rDatePicker1 = new rComponents.rDatePicker(this.components);
            this.rTextBox1 = new rComponents.rTextBox(this.components);
            this.rLabel4 = new rComponents.rLabel(this.components);
            this.rTextBox2 = new rComponents.rTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 83);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "تــایــیــد";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(12, 83);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "انصــراف";
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(324, 12);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(32, 17);
            this.rLabel1.TabIndex = 8;
            this.rLabel1.Text = "تاریخ:";
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(324, 40);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(52, 17);
            this.rLabel2.TabIndex = 8;
            this.rLabel2.Text = "از ساعت:";
            // 
            // rDatePicker1
            // 
            this.rDatePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePicker1.Culture = null;
            this.rDatePicker1.FieldName = "تاریخ غیبت";
            this.rDatePicker1.Location = new System.Drawing.Point(218, 12);
            this.rDatePicker1.Mask = "1###/##/##";
            this.rDatePicker1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePicker1.Name = "rDatePicker1";
            this.rDatePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePicker1.SelectionLength = 10;
            this.rDatePicker1.SelectionStart = 10;
            this.rDatePicker1.Size = new System.Drawing.Size(100, 19);
            this.rDatePicker1.TabIndex = 0;
            this.rDatePicker1.TabStop = false;
            this.rDatePicker1.Text = "1___/__/__";
            this.rDatePicker1.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rDatePicker1.Value = "";
            // 
            // rTextBox1
            // 
            this.rTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox1.Culture = null;
            this.rTextBox1.FieldName = null;
            this.rTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox1.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox1.Location = new System.Drawing.Point(218, 37);
            this.rTextBox1.Mask = "HH:mm";
            this.rTextBox1.MaskType = Telerik.WinControls.UI.MaskType.DateTime;
            this.rTextBox1.MaximumValue = null;
            this.rTextBox1.MinimumValue = null;
            this.rTextBox1.Name = "rTextBox1";
            this.rTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox1.Size = new System.Drawing.Size(100, 19);
            this.rTextBox1.TabIndex = 1;
            this.rTextBox1.TabStop = false;
            this.rTextBox1.Type = rComponents.rTextBoxType.Time;
            this.rTextBox1.ValidatingProperty = null;
            this.rTextBox1.ValidationType = rComponents.ValidationType.None;
            // 
            // rLabel4
            // 
            this.rLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel4.BackColor = System.Drawing.Color.Transparent;
            this.rLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel4.Location = new System.Drawing.Point(118, 40);
            this.rLabel4.Name = "rLabel4";
            this.rLabel4.Size = new System.Drawing.Size(52, 17);
            this.rLabel4.TabIndex = 8;
            this.rLabel4.Text = "تا ساعت:";
            // 
            // rTextBox2
            // 
            this.rTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox2.Culture = null;
            this.rTextBox2.FieldName = null;
            this.rTextBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox2.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox2.Location = new System.Drawing.Point(12, 37);
            this.rTextBox2.Mask = "HH:mm";
            this.rTextBox2.MaskType = Telerik.WinControls.UI.MaskType.DateTime;
            this.rTextBox2.MaximumValue = null;
            this.rTextBox2.MinimumValue = null;
            this.rTextBox2.Name = "rTextBox2";
            this.rTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox2.Size = new System.Drawing.Size(100, 19);
            this.rTextBox2.TabIndex = 2;
            this.rTextBox2.TabStop = false;
            this.rTextBox2.Type = rComponents.rTextBoxType.Time;
            this.rTextBox2.ValidatingProperty = null;
            this.rTextBox2.ValidationType = rComponents.ValidationType.None;
            // 
            // frmPresenceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 119);
            this.Controls.Add(this.rTextBox2);
            this.Controls.Add(this.rTextBox1);
            this.Controls.Add(this.rDatePicker1);
            this.Controls.Add(this.rLabel4);
            this.Controls.Add(this.rLabel2);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Name = "frmPresenceDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات حضور";
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private rComponents.rLabel rLabel1;
        private rComponents.rLabel rLabel2;
        private rComponents.rDatePicker rDatePicker1;
        private rComponents.rTextBox rTextBox1;
        private rComponents.rLabel rLabel4;
        private rComponents.rTextBox rTextBox2;
    }
}