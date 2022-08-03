namespace Fakher.UI.SystemFeatures
{
    partial class frmMessageDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessageDetail));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.rTextBox2 = new rComponents.rTextBox(this.components);
            this.rTextBox3 = new rComponents.rTextBox(this.components);
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.rTextBox4 = new rComponents.rTextBox(this.components);
            this.receiverSelector1 = new Fakher.Controls.ReceiverSelector();
            this.rPageView1 = new rComponents.rPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridViewAttachments = new rComponents.rGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPageView1)).BeginInit();
            this.rPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            this.radPageViewPage2.SuspendLayout();
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
            this.rLabel2.Location = new System.Drawing.Point(439, 93);
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
            this.rTextBox2.Location = new System.Drawing.Point(15, 92);
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
            // rTextBox3
            // 
            this.rTextBox3.AcceptsReturn = true;
            this.rTextBox3.AutoScroll = true;
            this.rTextBox3.Culture = null;
            this.rTextBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTextBox3.FieldName = "متن پیام";
            this.rTextBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox3.Language = rComponents.TextboxLanguage.Farsi;
            this.rTextBox3.Location = new System.Drawing.Point(0, 0);
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
            this.rTextBox3.Size = new System.Drawing.Size(576, 288);
            this.rTextBox3.TabIndex = 0;
            this.rTextBox3.TabStop = false;
            this.rTextBox3.Type = rComponents.rTextBoxType.Text;
            this.rTextBox3.ValidatingProperty = null;
            this.rTextBox3.ValidationType = rComponents.ValidationType.NotEmpty;
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
            this.btnOk.Text = "ارســـال پـــیـــام";
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
            this.rLabel3.Location = new System.Drawing.Point(439, 17);
            this.rLabel3.Name = "rLabel3";
            this.rLabel3.Size = new System.Drawing.Size(62, 17);
            this.rLabel3.TabIndex = 0;
            this.rLabel3.Text = "فـرسـتـنـده:";
            // 
            // rTextBox4
            // 
            this.rTextBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox4.Culture = null;
            this.rTextBox4.FieldName = null;
            this.rTextBox4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox4.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox4.Location = new System.Drawing.Point(15, 16);
            this.rTextBox4.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox4.MaximumValue = null;
            this.rTextBox4.MinimumValue = null;
            this.rTextBox4.Name = "rTextBox4";
            this.rTextBox4.ReadOnly = true;
            this.rTextBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rTextBox4.Size = new System.Drawing.Size(416, 19);
            this.rTextBox4.TabIndex = 0;
            this.rTextBox4.TabStop = false;
            this.rTextBox4.Type = rComponents.rTextBoxType.Text;
            this.rTextBox4.ValidatingProperty = null;
            this.rTextBox4.ValidationType = rComponents.ValidationType.None;
            // 
            // receiverSelector1
            // 
            this.receiverSelector1.BackColor = System.Drawing.Color.Transparent;
            this.receiverSelector1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.receiverSelector1.Location = new System.Drawing.Point(12, 41);
            this.receiverSelector1.Name = "receiverSelector1";
            this.receiverSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.receiverSelector1.SelectDepartment = true;
            this.receiverSelector1.SelectEmployee = true;
            this.receiverSelector1.SelectTeacher = true;
            this.receiverSelector1.Size = new System.Drawing.Size(489, 45);
            this.receiverSelector1.TabIndex = 1;
            // 
            // rPageView1
            // 
            this.rPageView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rPageView1.Controls.Add(this.radPageViewPage1);
            this.rPageView1.Controls.Add(this.radPageViewPage2);
            this.rPageView1.Location = new System.Drawing.Point(12, 117);
            this.rPageView1.Name = "rPageView1";
            this.rPageView1.SelectedPage = this.radPageViewPage2;
            this.rPageView1.Size = new System.Drawing.Size(597, 335);
            this.rPageView1.TabIndex = 6;
            this.rPageView1.Text = "rPageView1";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.rPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.rTextBox3);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(576, 288);
            this.radPageViewPage1.Text = "مـــتــــن پـــیـــــام";
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.rGridViewAttachments);
            this.radPageViewPage2.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(576, 288);
            this.radPageViewPage2.Text = "پیوست هــا";
            // 
            // rGridViewAttachments
            // 
            this.rGridViewAttachments.CanAdd = false;
            this.rGridViewAttachments.CanDelete = false;
            this.rGridViewAttachments.CanEdit = false;
            this.rGridViewAttachments.CanExport = true;
            this.rGridViewAttachments.CanFilter = true;
            this.rGridViewAttachments.CanGroup = false;
            this.rGridViewAttachments.CanNavigate = true;
            this.rGridViewAttachments.CheckBoxes = false;
            this.rGridViewAttachments.ColumnAutoSize = true;
            this.rGridViewAttachments.ConfirmOnDelete = true;
            this.rGridViewAttachments.CustomAddText = null;
            this.rGridViewAttachments.CustomDeleteText = null;
            this.rGridViewAttachments.CustomEditText = "";
            this.rGridViewAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewAttachments.EditOnDoubleClick = true;
            this.rGridViewAttachments.FieldName = null;
            this.rGridViewAttachments.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewAttachments.ItemImage = null;
            this.rGridViewAttachments.Location = new System.Drawing.Point(0, 0);
            this.rGridViewAttachments.MultiSelect = false;
            this.rGridViewAttachments.Name = "rGridViewAttachments";
            this.rGridViewAttachments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewAttachments.RowHeight = 25;
            this.rGridViewAttachments.ShowBottomToolbar = false;
            this.rGridViewAttachments.ShowGroupPanel = true;
            this.rGridViewAttachments.ShowTopToolbar = true;
            this.rGridViewAttachments.Size = new System.Drawing.Size(576, 288);
            this.rGridViewAttachments.TabIndex = 0;
            this.rGridViewAttachments.ValidationType = rComponents.ValidationType.None;
            this.rGridViewAttachments.Add += new System.EventHandler(this.rGridViewAttachments_Add);
            this.rGridViewAttachments.Delete += new System.EventHandler(this.rGridViewAttachments_Delete);
            this.rGridViewAttachments.CustomButtonClick += new System.EventHandler<rComponents.CustomButtonClickEventArgs>(this.rGridViewAttachments_CustomButtonClick);
            // 
            // frmMessageDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 494);
            this.Controls.Add(this.rPageView1);
            this.Controls.Add(this.receiverSelector1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rTextBox2);
            this.Controls.Add(this.rTextBox4);
            this.Controls.Add(this.rLabel2);
            this.Controls.Add(this.rLabel3);
            this.Name = "frmMessageDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات پیام";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPageView1)).EndInit();
            this.rPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage1.PerformLayout();
            this.radPageViewPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private rComponents.rLabel rLabel2;
        private rComponents.rTextBox rTextBox2;
        private rComponents.rTextBox rTextBox3;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private rComponents.rLabel rLabel3;
        private rComponents.rTextBox rTextBox4;
        private Fakher.Controls.ReceiverSelector receiverSelector1;
        private rComponents.rPageView rPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private rComponents.rGridView rGridViewAttachments;
    }
}