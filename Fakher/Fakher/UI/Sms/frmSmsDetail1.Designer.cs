namespace Fakher.UI
{
    partial class frmSmsDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSmsDetail));
            this.rTextBox4 = new rComponents.rTextBox(this.components);
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.rLblSms = new rComponents.rLabel(this.components);
            this.rTxtSms = new rComponents.rTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblSms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtSms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rTextBox4
            // 
            this.rTextBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox4.Culture = null;
            this.rTextBox4.FieldName = null;
            this.rTextBox4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox4.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox4.Location = new System.Drawing.Point(38, 25);
            this.rTextBox4.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox4.MaximumValue = null;
            this.rTextBox4.MinimumValue = null;
            this.rTextBox4.Name = "rTextBox4";
            this.rTextBox4.ReadOnly = true;
            this.rTextBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox4.Size = new System.Drawing.Size(301, 25);
            this.rTextBox4.TabIndex = 1;
            this.rTextBox4.TabStop = false;
            this.rTextBox4.Type = rComponents.rTextBoxType.Text;
            this.rTextBox4.ValidatingProperty = null;
            this.rTextBox4.ValidationType = rComponents.ValidationType.None;
            // 
            // rLabel3
            // 
            this.rLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel3.BackColor = System.Drawing.Color.Transparent;
            this.rLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel3.Location = new System.Drawing.Point(345, 25);
            this.rLabel3.Name = "rLabel3";
            this.rLabel3.Size = new System.Drawing.Size(62, 24);
            this.rLabel3.TabIndex = 2;
            this.rLabel3.Text = "گیـرنده:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(33, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(403, 471);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(228, 558);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "ارســـال پیامک";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(92, 558);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "خــروج";
            // 
            // rLblSms
            // 
            this.rLblSms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rLblSms.AutoSize = false;
            this.rLblSms.BackColor = System.Drawing.Color.Transparent;
            this.rLblSms.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLblSms.Location = new System.Drawing.Point(38, 59);
            this.rLblSms.Name = "rLblSms";
            this.rLblSms.Size = new System.Drawing.Size(119, 24);
            this.rLblSms.TabIndex = 19;
            this.rLblSms.Text = "0";
            this.rLblSms.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rTxtSms
            // 
            this.rTxtSms.AcceptsReturn = true;
            this.rTxtSms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtSms.AutoScroll = true;
            this.rTxtSms.Culture = null;
            this.rTxtSms.FieldName = null;
            this.rTxtSms.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTxtSms.Language = rComponents.TextboxLanguage.Farsi;
            this.rTxtSms.Location = new System.Drawing.Point(141, 152);
            this.rTxtSms.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTxtSms.MaximumValue = null;
            this.rTxtSms.MinimumValue = null;
            this.rTxtSms.Multiline = true;
            this.rTxtSms.Name = "rTxtSms";
            this.rTxtSms.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.rTxtSms.RootElement.StretchVertically = true;
            this.rTxtSms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rTxtSms.Size = new System.Drawing.Size(189, 279);
            this.rTxtSms.TabIndex = 18;
            this.rTxtSms.TabStop = false;
            this.rTxtSms.Type = rComponents.rTextBoxType.Text;
            this.rTxtSms.ValidatingProperty = null;
            this.rTxtSms.ValidationType = rComponents.ValidationType.None;
            this.rTxtSms.TextChanged += new System.EventHandler(this.rTxtSms_TextChanged);
            // 
            // frmSmsDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(459, 584);
            this.Controls.Add(this.rTxtSms);
            this.Controls.Add(this.rLblSms);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rTextBox4);
            this.Controls.Add(this.rLabel3);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSmsDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ارسال پیامک";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.frmSmsDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblSms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtSms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rTextBox rTextBox4;
        private rComponents.rLabel rLabel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private rComponents.rLabel rLblSms;
        private rComponents.rTextBox rTxtSms;
    }
}