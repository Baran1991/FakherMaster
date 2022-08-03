namespace Fakher.UI.SystemFeatures
{
    partial class frmEmailDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmailDetail));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.rTextBox2 = new rComponents.rTextBox(this.components);
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.rTextBox4 = new rComponents.rTextBox(this.components);
            this.rPageView1 = new rComponents.rPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rHtmlEditorToolbar1 = new rComponents.rHtmlEditorToolbar();
            this.rHtmlEditor1 = new rComponents.rHtmlEditor();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPageView1)).BeginInit();
            this.rPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(507, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(441, 87);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(56, 17);
            this.rLabel2.TabIndex = 0;
            this.rLabel2.Text = "عـــنــــوان:";
            // 
            // rTextBox2
            // 
            this.rTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox2.Culture = null;
            this.rTextBox2.FieldName = "عنوان پیام";
            this.rTextBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox2.Language = rComponents.TextboxLanguage.Farsi;
            this.rTextBox2.Location = new System.Drawing.Point(17, 86);
            this.rTextBox2.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox2.MaximumValue = null;
            this.rTextBox2.MinimumValue = null;
            this.rTextBox2.Name = "rTextBox2";
            this.rTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rTextBox2.Size = new System.Drawing.Size(414, 19);
            this.rTextBox2.TabIndex = 2;
            this.rTextBox2.TabStop = false;
            this.rTextBox2.Type = rComponents.rTextBoxType.Text;
            this.rTextBox2.ValidatingProperty = null;
            this.rTextBox2.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 458);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "ارســـال ایمیل";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(12, 458);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "خــروج";
            // 
            // rLabel3
            // 
            this.rLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel3.BackColor = System.Drawing.Color.Transparent;
            this.rLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel3.Location = new System.Drawing.Point(439, 46);
            this.rLabel3.Name = "rLabel3";
            this.rLabel3.Size = new System.Drawing.Size(42, 17);
            this.rLabel3.TabIndex = 0;
            this.rLabel3.Text = "گیـرنده:";
            // 
            // rTextBox4
            // 
            this.rTextBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox4.Culture = null;
            this.rTextBox4.FieldName = null;
            this.rTextBox4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox4.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox4.Location = new System.Drawing.Point(17, 45);
            this.rTextBox4.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox4.MaximumValue = null;
            this.rTextBox4.MinimumValue = null;
            this.rTextBox4.Name = "rTextBox4";
            this.rTextBox4.ReadOnly = true;
            this.rTextBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox4.Size = new System.Drawing.Size(414, 19);
            this.rTextBox4.TabIndex = 0;
            this.rTextBox4.TabStop = false;
            this.rTextBox4.Type = rComponents.rTextBoxType.Text;
            this.rTextBox4.ValidatingProperty = null;
            this.rTextBox4.ValidationType = rComponents.ValidationType.None;
            // 
            // rPageView1
            // 
            this.rPageView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rPageView1.Controls.Add(this.radPageViewPage1);
            this.rPageView1.Location = new System.Drawing.Point(12, 117);
            this.rPageView1.Name = "rPageView1";
            this.rPageView1.SelectedPage = this.radPageViewPage1;
            this.rPageView1.Size = new System.Drawing.Size(597, 335);
            this.rPageView1.TabIndex = 6;
            this.rPageView1.Text = "rPageView1";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.rPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.rHtmlEditorToolbar1);
            this.radPageViewPage1.Controls.Add(this.rHtmlEditor1);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(576, 288);
            this.radPageViewPage1.Text = "مـــتــــن پـــیـــــام";
            // 
            // rHtmlEditorToolbar1
            // 
            this.rHtmlEditorToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rHtmlEditorToolbar1.FontName = null;
            this.rHtmlEditorToolbar1.FontSize = rComponents.FontSize.NA;
            this.rHtmlEditorToolbar1.HtmlEditor = this.rHtmlEditor1;
            this.rHtmlEditorToolbar1.Location = new System.Drawing.Point(0, 0);
            this.rHtmlEditorToolbar1.Name = "rHtmlEditorToolbar1";
            this.rHtmlEditorToolbar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rHtmlEditorToolbar1.Size = new System.Drawing.Size(576, 50);
            this.rHtmlEditorToolbar1.TabIndex = 1;
            // 
            // rHtmlEditor1
            // 
            this.rHtmlEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rHtmlEditor1.BodyHtml = null;
            this.rHtmlEditor1.BodyText = null;
            this.rHtmlEditor1.DocumentText = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">\r\n<HTML><HEAD></HEA" +
    "D>\r\n<BODY></BODY></HTML>\r\n";
            this.rHtmlEditor1.EditorBackColor = System.Drawing.Color.White;
            this.rHtmlEditor1.EditorForeColor = System.Drawing.Color.Black;
            this.rHtmlEditor1.Location = new System.Drawing.Point(3, 56);
            this.rHtmlEditor1.Name = "rHtmlEditor1";
            this.rHtmlEditor1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rHtmlEditor1.Size = new System.Drawing.Size(573, 229);
            this.rHtmlEditor1.TabIndex = 0;
            // 
            // frmEmailDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 494);
            this.Controls.Add(this.rPageView1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rTextBox2);
            this.Controls.Add(this.rTextBox4);
            this.Controls.Add(this.rLabel2);
            this.Controls.Add(this.rLabel3);
            this.Name = "frmEmailDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات ایمیل";
            this.Shown += new System.EventHandler(this.frmEmailDetail_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPageView1)).EndInit();
            this.rPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private rComponents.rLabel rLabel2;
        private rComponents.rTextBox rTextBox2;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private rComponents.rLabel rLabel3;
        private rComponents.rTextBox rTextBox4;
        private rComponents.rPageView rPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private rComponents.rHtmlEditorToolbar rHtmlEditorToolbar1;
        private rComponents.rHtmlEditor rHtmlEditor1;
    }
}