﻿namespace Fakher.Controls
{
    partial class RegisterSearchBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rGroupBox2 = new rComponents.rGroupBox(this.components);
            this.rGridView1 = new rComponents.rGridView();
            this.radBtnSearch = new Telerik.WinControls.UI.RadButton();
            this.radTxtLastname = new rComponents.rTextBox(this.components);
            this.radTxtFirstname = new rComponents.rTextBox(this.components);
            this.rTxtCode = new rComponents.rTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).BeginInit();
            this.rGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTxtLastname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTxtFirstname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtCode)).BeginInit();
            this.SuspendLayout();
            // 
            // rGroupBox2
            // 
            this.rGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox2.Controls.Add(this.rGridView1);
            this.rGroupBox2.Controls.Add(this.radBtnSearch);
            this.rGroupBox2.Controls.Add(this.radTxtLastname);
            this.rGroupBox2.Controls.Add(this.radTxtFirstname);
            this.rGroupBox2.Controls.Add(this.rTxtCode);
            this.rGroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox2.FooterImageIndex = -1;
            this.rGroupBox2.FooterImageKey = "";
            this.rGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox2.HeaderImageIndex = -1;
            this.rGroupBox2.HeaderImageKey = "";
            this.rGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox2.HeaderText = "جستجوی دانشجو";
            this.rGroupBox2.Location = new System.Drawing.Point(3, 3);
            this.rGroupBox2.Name = "rGroupBox2";
            this.rGroupBox2.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox2.Size = new System.Drawing.Size(901, 171);
            this.rGroupBox2.TabIndex = 6;
            this.rGroupBox2.Text = "جستجوی دانشجو";
            // 
            // rGridView1
            // 
            this.rGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridView1.CanAdd = true;
            this.rGridView1.CanDelete = false;
            this.rGridView1.CanEdit = false;
            this.rGridView1.CanExport = true;
            this.rGridView1.CanFilter = false;
            this.rGridView1.CanGroup = false;
            this.rGridView1.CanNavigate = true;
            this.rGridView1.CheckBoxes = false;
            this.rGridView1.ColumnAutoSize = true;
            this.rGridView1.ConfirmOnDelete = true;
            this.rGridView1.CustomAddText = "پرونده جدید";
            this.rGridView1.CustomDeleteText = null;
            this.rGridView1.CustomEditText = null;
            this.rGridView1.FieldName = null;
            this.rGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView1.ItemImage = null;
            this.rGridView1.Location = new System.Drawing.Point(5, 49);
            this.rGridView1.MultiSelect = false;
            this.rGridView1.Name = "rGridView1";
            this.rGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView1.RowHeight = 25;
            this.rGridView1.ShowBottomToolbar = false;
            this.rGridView1.ShowTopToolbar = false;
            this.rGridView1.Size = new System.Drawing.Size(891, 117);
            this.rGridView1.TabIndex = 4;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.SelectedItemChanged += new System.EventHandler(this.rGridView1_SelectedItemChanged);
            // 
            // radBtnSearch
            // 
            this.radBtnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radBtnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radBtnSearch.Location = new System.Drawing.Point(122, 23);
            this.radBtnSearch.Name = "radBtnSearch";
            this.radBtnSearch.Size = new System.Drawing.Size(128, 20);
            this.radBtnSearch.TabIndex = 3;
            this.radBtnSearch.Text = "جستـــجــــو";
            this.radBtnSearch.Click += new System.EventHandler(this.radBtnSearch_Click);
            // 
            // radTxtLastname
            // 
            this.radTxtLastname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radTxtLastname.Culture = null;
            this.radTxtLastname.FieldName = null;
            this.radTxtLastname.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radTxtLastname.Language = rComponents.TextboxLanguage.Farsi;
            this.radTxtLastname.Location = new System.Drawing.Point(256, 24);
            this.radTxtLastname.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.radTxtLastname.MaximumValue = null;
            this.radTxtLastname.MinimumValue = null;
            this.radTxtLastname.Name = "radTxtLastname";
            this.radTxtLastname.NullText = "نــــام خــــانـــوادگـــی";
            this.radTxtLastname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radTxtLastname.Size = new System.Drawing.Size(170, 19);
            this.radTxtLastname.TabIndex = 2;
            this.radTxtLastname.TabStop = false;
            this.radTxtLastname.Type = rComponents.rTextBoxType.Text;
            this.radTxtLastname.ValidatingProperty = null;
            this.radTxtLastname.ValidationType = rComponents.ValidationType.None;
            this.radTxtLastname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radTxtLastname_KeyDown);
            // 
            // radTxtFirstname
            // 
            this.radTxtFirstname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radTxtFirstname.Culture = null;
            this.radTxtFirstname.FieldName = null;
            this.radTxtFirstname.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radTxtFirstname.Language = rComponents.TextboxLanguage.Farsi;
            this.radTxtFirstname.Location = new System.Drawing.Point(432, 24);
            this.radTxtFirstname.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.radTxtFirstname.MaximumValue = null;
            this.radTxtFirstname.MinimumValue = null;
            this.radTxtFirstname.Name = "radTxtFirstname";
            this.radTxtFirstname.NullText = "نــــام";
            this.radTxtFirstname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radTxtFirstname.Size = new System.Drawing.Size(170, 19);
            this.radTxtFirstname.TabIndex = 1;
            this.radTxtFirstname.TabStop = false;
            this.radTxtFirstname.Type = rComponents.rTextBoxType.Text;
            this.radTxtFirstname.ValidatingProperty = null;
            this.radTxtFirstname.ValidationType = rComponents.ValidationType.None;
            this.radTxtFirstname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radTxtFirstname_KeyDown);
            // 
            // rTxtCode
            // 
            this.rTxtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtCode.Culture = null;
            this.rTxtCode.FieldName = null;
            this.rTxtCode.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTxtCode.Language = rComponents.TextboxLanguage.DontCare;
            this.rTxtCode.Location = new System.Drawing.Point(608, 24);
            this.rTxtCode.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTxtCode.MaximumValue = null;
            this.rTxtCode.MinimumValue = null;
            this.rTxtCode.Name = "rTxtCode";
            this.rTxtCode.NullText = "شماره دانشجویی";
            this.rTxtCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rTxtCode.Size = new System.Drawing.Size(170, 19);
            this.rTxtCode.TabIndex = 0;
            this.rTxtCode.TabStop = false;
            this.rTxtCode.Type = rComponents.rTextBoxType.Text;
            this.rTxtCode.ValidatingProperty = null;
            this.rTxtCode.ValidationType = rComponents.ValidationType.None;
            this.rTxtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rTxtCode_KeyDown);
            // 
            // RegisterSearchBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rGroupBox2);
            this.Name = "RegisterSearchBox";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(906, 175);
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).EndInit();
            this.rGroupBox2.ResumeLayout(false);
            this.rGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTxtLastname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTxtFirstname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private rComponents.rGroupBox rGroupBox2;
        private rComponents.rGridView rGridView1;
        private Telerik.WinControls.UI.RadButton radBtnSearch;
        private rComponents.rTextBox radTxtLastname;
        private rComponents.rTextBox radTxtFirstname;
        private rComponents.rTextBox rTxtCode;
    }
}
