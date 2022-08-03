namespace Fakher.UI.Store
{
    partial class frmSupplyEdit
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
            this.rTxtCount = new rComponents.rTextBox(this.components);
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.rTxtBuyPrice = new rComponents.rTextBox(this.components);
            this.rLabel4 = new rComponents.rLabel(this.components);
            this.rTxtSellPrice = new rComponents.rTextBox(this.components);
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.rTxtAllCount = new rComponents.rTextBox(this.components);
            this.rLabel5 = new rComponents.rLabel(this.components);
            this.rGridComboBox1 = new rComponents.rGridComboBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBuyPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtSellPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtAllCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 156);
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
            this.btnCancel.Location = new System.Drawing.Point(12, 156);
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
            this.rLabel1.Location = new System.Drawing.Point(428, 12);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(49, 17);
            this.rLabel1.TabIndex = 7;
            this.rLabel1.Text = "نام کتاب:";
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(157, 27);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(49, 17);
            this.rLabel2.TabIndex = 9;
            this.rLabel2.Text = "موجودی:";
            // 
            // rTxtCount
            // 
            this.rTxtCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtCount.BackColor = System.Drawing.Color.White;
            this.rTxtCount.Culture = null;
            this.rTxtCount.FieldName = "تعداد";
            this.rTxtCount.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTxtCount.Language = rComponents.TextboxLanguage.DontCare;
            this.rTxtCount.Location = new System.Drawing.Point(4, 27);
            this.rTxtCount.Mask = "D";
            this.rTxtCount.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.rTxtCount.MaximumValue = null;
            this.rTxtCount.MinimumValue = "1";
            this.rTxtCount.Name = "rTxtCount";
            this.rTxtCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTxtCount.Size = new System.Drawing.Size(147, 19);
            this.rTxtCount.TabIndex = 1;
            this.rTxtCount.TabStop = false;
            this.rTxtCount.Type = rComponents.rTextBoxType.Numeric;
            this.rTxtCount.ValidatingProperty = null;
            this.rTxtCount.ValidationType = rComponents.ValidationType.InRange;
            // 
            // rLabel3
            // 
            this.rLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel3.BackColor = System.Drawing.Color.Transparent;
            this.rLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel3.Location = new System.Drawing.Point(400, 56);
            this.rLabel3.Name = "rLabel3";
            this.rLabel3.Size = new System.Drawing.Size(61, 17);
            this.rLabel3.TabIndex = 9;
            this.rLabel3.Text = "قیمت خرید:";
            // 
            // rTxtBuyPrice
            // 
            this.rTxtBuyPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtBuyPrice.BackColor = System.Drawing.Color.White;
            this.rTxtBuyPrice.Culture = null;
            this.rTxtBuyPrice.FieldName = "قیمت خرید";
            this.rTxtBuyPrice.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTxtBuyPrice.Language = rComponents.TextboxLanguage.DontCare;
            this.rTxtBuyPrice.Location = new System.Drawing.Point(247, 54);
            this.rTxtBuyPrice.Mask = "c0";
            this.rTxtBuyPrice.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.rTxtBuyPrice.MaximumValue = null;
            this.rTxtBuyPrice.MinimumValue = "0";
            this.rTxtBuyPrice.Name = "rTxtBuyPrice";
            this.rTxtBuyPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTxtBuyPrice.Size = new System.Drawing.Size(147, 19);
            this.rTxtBuyPrice.TabIndex = 2;
            this.rTxtBuyPrice.TabStop = false;
            this.rTxtBuyPrice.Type = rComponents.rTextBoxType.Money;
            this.rTxtBuyPrice.ValidatingProperty = null;
            this.rTxtBuyPrice.ValidationType = rComponents.ValidationType.InRange;
            // 
            // rLabel4
            // 
            this.rLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel4.BackColor = System.Drawing.Color.Transparent;
            this.rLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel4.Location = new System.Drawing.Point(157, 56);
            this.rLabel4.Name = "rLabel4";
            this.rLabel4.Size = new System.Drawing.Size(68, 17);
            this.rLabel4.TabIndex = 9;
            this.rLabel4.Text = "قیمت فروش:";
            // 
            // rTxtSellPrice
            // 
            this.rTxtSellPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtSellPrice.BackColor = System.Drawing.Color.White;
            this.rTxtSellPrice.Culture = null;
            this.rTxtSellPrice.FieldName = "قیمت فروش";
            this.rTxtSellPrice.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTxtSellPrice.Language = rComponents.TextboxLanguage.DontCare;
            this.rTxtSellPrice.Location = new System.Drawing.Point(4, 54);
            this.rTxtSellPrice.Mask = "c0";
            this.rTxtSellPrice.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.rTxtSellPrice.MaximumValue = null;
            this.rTxtSellPrice.MinimumValue = "0";
            this.rTxtSellPrice.Name = "rTxtSellPrice";
            this.rTxtSellPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTxtSellPrice.Size = new System.Drawing.Size(147, 19);
            this.rTxtSellPrice.TabIndex = 3;
            this.rTxtSellPrice.TabStop = false;
            this.rTxtSellPrice.Type = rComponents.rTextBoxType.Money;
            this.rTxtSellPrice.ValidatingProperty = null;
            this.rTxtSellPrice.ValidationType = rComponents.ValidationType.InRange;
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox1.Controls.Add(this.rTxtAllCount);
            this.rGroupBox1.Controls.Add(this.rTxtCount);
            this.rGroupBox1.Controls.Add(this.rLabel5);
            this.rGroupBox1.Controls.Add(this.rTxtSellPrice);
            this.rGroupBox1.Controls.Add(this.rLabel2);
            this.rGroupBox1.Controls.Add(this.rLabel4);
            this.rGroupBox1.Controls.Add(this.rLabel3);
            this.rGroupBox1.Controls.Add(this.rTxtBuyPrice);
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "بروزرسانی موجودی کالا";
            this.rGroupBox1.Location = new System.Drawing.Point(12, 37);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(465, 107);
            this.rGroupBox1.TabIndex = 1;
            this.rGroupBox1.Text = "بروزرسانی موجودی کالا";
            // 
            // rTxtAllCount
            // 
            this.rTxtAllCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtAllCount.BackColor = System.Drawing.Color.White;
            this.rTxtAllCount.Culture = null;
            this.rTxtAllCount.FieldName = "تعداد کل";
            this.rTxtAllCount.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTxtAllCount.Language = rComponents.TextboxLanguage.DontCare;
            this.rTxtAllCount.Location = new System.Drawing.Point(247, 27);
            this.rTxtAllCount.Mask = "D";
            this.rTxtAllCount.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.rTxtAllCount.MaximumValue = null;
            this.rTxtAllCount.MinimumValue = "1";
            this.rTxtAllCount.Name = "rTxtAllCount";
            this.rTxtAllCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTxtAllCount.Size = new System.Drawing.Size(147, 19);
            this.rTxtAllCount.TabIndex = 0;
            this.rTxtAllCount.TabStop = false;
            this.rTxtAllCount.Type = rComponents.rTextBoxType.Numeric;
            this.rTxtAllCount.ValidatingProperty = null;
            this.rTxtAllCount.ValidationType = rComponents.ValidationType.InRange;
            // 
            // rLabel5
            // 
            this.rLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel5.BackColor = System.Drawing.Color.Transparent;
            this.rLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel5.Location = new System.Drawing.Point(400, 27);
            this.rLabel5.Name = "rLabel5";
            this.rLabel5.Size = new System.Drawing.Size(50, 17);
            this.rLabel5.TabIndex = 9;
            this.rLabel5.Text = "تعداد کل:";
            // 
            // rGridComboBox1
            // 
            this.rGridComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridComboBox1.CompareMember = null;
            this.rGridComboBox1.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridComboBox1.NestedRadGridView
            // 
            this.rGridComboBox1.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridComboBox1.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBox1.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridComboBox1.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rGridComboBox1.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridComboBox1.EditorControl.MasterTemplate.EnableFiltering = true;
            this.rGridComboBox1.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBox1.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBox1.EditorControl.Name = "NestedRadGridView";
            this.rGridComboBox1.EditorControl.ReadOnly = true;
            this.rGridComboBox1.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridComboBox1.EditorControl.ShowGroupPanel = false;
            this.rGridComboBox1.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridComboBox1.EditorControl.TabIndex = 0;
            this.rGridComboBox1.FieldName = null;
            this.rGridComboBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBox1.Location = new System.Drawing.Point(12, 11);
            this.rGridComboBox1.MaximumValue = null;
            this.rGridComboBox1.MinimumValue = null;
            this.rGridComboBox1.Name = "rGridComboBox1";
            // 
            // 
            // 
            this.rGridComboBox1.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridComboBox1.ShowFilteringRow = true;
            this.rGridComboBox1.ShowNullButton = false;
            this.rGridComboBox1.Size = new System.Drawing.Size(410, 19);
            this.rGridComboBox1.TabIndex = 0;
            this.rGridComboBox1.TabStop = false;
            this.rGridComboBox1.ValidatingProperty = null;
            this.rGridComboBox1.ValidationType = rComponents.ValidationType.None;
            this.rGridComboBox1.Value = null;
            this.rGridComboBox1.SelectedIndexChanged += new System.EventHandler(this.rGridComboBox1_SelectedIndexChanged);
            // 
            // frmSupplyEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 192);
            this.Controls.Add(this.rGridComboBox1);
            this.Controls.Add(this.rGroupBox1);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Name = "frmSupplyEdit";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "تصحیح موجودی کتاب";
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBuyPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtSellPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            this.rGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtAllCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private rComponents.rLabel rLabel1;
        private rComponents.rLabel rLabel2;
        private rComponents.rTextBox rTxtCount;
        private rComponents.rLabel rLabel3;
        private rComponents.rTextBox rTxtBuyPrice;
        private rComponents.rLabel rLabel4;
        private rComponents.rTextBox rTxtSellPrice;
        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rTextBox rTxtAllCount;
        private rComponents.rLabel rLabel5;
        private rComponents.rGridComboBox rGridComboBox1;
    }
}