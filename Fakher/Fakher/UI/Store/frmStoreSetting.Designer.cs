namespace Fakher.UI.Reception
{
    partial class frmStoreSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStoreSetting));
            this.rTxtTemplate = new rComponents.rTextBox(this.components);
            this.radBtnSave = new Telerik.WinControls.UI.RadButton();
            this.rLabel1 = new rComponents.rLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rTxtTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rTxtTemplate
            // 
            this.rTxtTemplate.AcceptsReturn = true;
            this.rTxtTemplate.AcceptsTab = true;
            this.rTxtTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtTemplate.AutoScroll = true;
            this.rTxtTemplate.Culture = null;
            this.rTxtTemplate.FieldName = null;
            this.rTxtTemplate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTxtTemplate.Language = rComponents.TextboxLanguage.Farsi;
            this.rTxtTemplate.Location = new System.Drawing.Point(12, 45);
            this.rTxtTemplate.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTxtTemplate.MaximumValue = null;
            this.rTxtTemplate.MinimumValue = null;
            this.rTxtTemplate.Multiline = true;
            this.rTxtTemplate.Name = "rTxtTemplate";
            this.rTxtTemplate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.rTxtTemplate.RootElement.StretchVertically = true;
            this.rTxtTemplate.Size = new System.Drawing.Size(501, 93);
            this.rTxtTemplate.TabIndex = 0;
            this.rTxtTemplate.TabStop = false;
            this.rTxtTemplate.Type = rComponents.rTextBoxType.Text;
            this.rTxtTemplate.ValidatingProperty = null;
            this.rTxtTemplate.ValidationType = rComponents.ValidationType.None;
            // 
            // radBtnSave
            // 
            this.radBtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radBtnSave.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("radBtnSave.Image")));
            this.radBtnSave.Location = new System.Drawing.Point(17, 154);
            this.radBtnSave.Name = "radBtnSave";
            this.radBtnSave.Size = new System.Drawing.Size(130, 34);
            this.radBtnSave.TabIndex = 8;
            this.radBtnSave.Text = "ذخیــــره";
            this.radBtnSave.Click += new System.EventHandler(this.radBtnSave_Click);
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.rLabel1.Location = new System.Drawing.Point(432, 22);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(81, 17);
            this.rLabel1.TabIndex = 1;
            this.rLabel1.Text = "متن زیر رسید:";
            // 
            // frmStoreSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 200);
            this.Controls.Add(this.radBtnSave);
            this.Controls.Add(this.rTxtTemplate);
            this.Controls.Add(this.rLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStoreSetting";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "تنظیمات انتشارات";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmRequestSmsSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rTxtTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rTextBox rTxtTemplate;
        private Telerik.WinControls.UI.RadButton radBtnSave;
        private rComponents.rLabel rLabel1;
    }
}
