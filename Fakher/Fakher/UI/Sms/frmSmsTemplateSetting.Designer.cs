namespace Fakher.UI.Reception
{
    partial class frmSmsTemplateSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSmsTemplateSetting));
            this.rTxtRequestTemplate = new rComponents.rTextBox(this.components);
            this.radBtnSave = new Telerik.WinControls.UI.RadButton();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.rLabel1 = new rComponents.rLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rTxtRequestTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rTxtRequestTemplate
            // 
            this.rTxtRequestTemplate.AcceptsReturn = true;
            this.rTxtRequestTemplate.AcceptsTab = true;
            this.rTxtRequestTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtRequestTemplate.AutoScroll = true;
            this.rTxtRequestTemplate.Culture = null;
            this.rTxtRequestTemplate.FieldName = null;
            this.rTxtRequestTemplate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTxtRequestTemplate.Language = rComponents.TextboxLanguage.Farsi;
            this.rTxtRequestTemplate.Location = new System.Drawing.Point(1, 5);
            this.rTxtRequestTemplate.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTxtRequestTemplate.MaximumValue = null;
            this.rTxtRequestTemplate.MinimumValue = null;
            this.rTxtRequestTemplate.Multiline = true;
            this.rTxtRequestTemplate.Name = "rTxtRequestTemplate";
            this.rTxtRequestTemplate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.rTxtRequestTemplate.RootElement.StretchVertically = true;
            this.rTxtRequestTemplate.Size = new System.Drawing.Size(692, 99);
            this.rTxtRequestTemplate.TabIndex = 0;
            this.rTxtRequestTemplate.TabStop = false;
            this.rTxtRequestTemplate.Type = rComponents.rTextBoxType.Text;
            this.rTxtRequestTemplate.ValidatingProperty = null;
            this.rTxtRequestTemplate.ValidationType = rComponents.ValidationType.None;
            // 
            // radBtnSave
            // 
            this.radBtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radBtnSave.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("radBtnSave.Image")));
            this.radBtnSave.Location = new System.Drawing.Point(17, 248);
            this.radBtnSave.Name = "radBtnSave";
            this.radBtnSave.Size = new System.Drawing.Size(130, 34);
            this.radBtnSave.TabIndex = 8;
            this.radBtnSave.Text = "ذخیــــره";
            this.radBtnSave.Click += new System.EventHandler(this.radBtnSave_Click);
            // 
            // radPageView1
            // 
            this.radPageView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radPageView1.Location = new System.Drawing.Point(12, 12);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage1;
            this.radPageView1.Size = new System.Drawing.Size(716, 230);
            this.radPageView1.TabIndex = 9;
            this.radPageView1.Text = "radPageView1";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.linkLabel4);
            this.radPageViewPage1.Controls.Add(this.linkLabel5);
            this.radPageViewPage1.Controls.Add(this.linkLabel3);
            this.radPageViewPage1.Controls.Add(this.linkLabel1);
            this.radPageViewPage1.Controls.Add(this.linkLabel2);
            this.radPageViewPage1.Controls.Add(this.rLabel1);
            this.radPageViewPage1.Controls.Add(this.rTxtRequestTemplate);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(695, 183);
            this.radPageViewPage1.Text = "پاسخ به درخواست";
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(252, 160);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(194, 13);
            this.linkLabel4.TabIndex = 13;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Tag = "[ساعت پاسخگویی]";
            this.linkLabel4.Text = "ساعت پاسخگویی : [ساعت پاسخگویی] ";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSmartWords_LinkClicked);
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(126, 141);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(93, 13);
            this.linkLabel5.TabIndex = 14;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Tag = "[وضعیت]";
            this.linkLabel5.Text = "وضعیت : [وضعیت]";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSmartWords_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(272, 141);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(174, 13);
            this.linkLabel3.TabIndex = 12;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Tag = "[تاریخ پاسخگویی]";
            this.linkLabel3.Text = "تاریخ پاسخگویی : [تاریخ پاسخگویی] ";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSmartWords_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(565, 141);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(127, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Tag = "[نام دانشجو]";
            this.linkLabel1.Text = "نام دانشجو : [نام دانشجو]";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSmartWords_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(475, 160);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(217, 13);
            this.linkLabel2.TabIndex = 11;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Tag = "[نام خانوادگی دانشجو]";
            this.linkLabel2.Text = "نام خانوادگی دانشجو : [نام خانوادگی دانشجو]";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSmartWords_LinkClicked);
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.rLabel1.Location = new System.Drawing.Point(603, 114);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(95, 17);
            this.rLabel1.TabIndex = 1;
            this.rLabel1.Text = "کلمات هوشمند :";
            // 
            // frmSmsTemplateSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 294);
            this.Controls.Add(this.radPageView1);
            this.Controls.Add(this.radBtnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSmsTemplateSetting";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "متون پیش فرض پیامک";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmRequestSmsSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rTxtRequestTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private rComponents.rTextBox rTxtRequestTemplate;
        private Telerik.WinControls.UI.RadButton radBtnSave;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private rComponents.rLabel rLabel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel5;
    }
}
