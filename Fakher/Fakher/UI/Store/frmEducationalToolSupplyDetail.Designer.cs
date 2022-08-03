namespace Fakher.UI.Store
{
    partial class frmEducationalToolSupplyDetail
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
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.rTxtCount = new rComponents.rTextBox(this.components);
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.rTxtBuyPrice = new rComponents.rTextBox(this.components);
            this.rLabel4 = new rComponents.rLabel(this.components);
            this.rTxtSellPrice = new rComponents.rTextBox(this.components);
            this.rTxtBillNo = new rComponents.rTextBox(this.components);
            this.rLabel5 = new rComponents.rLabel(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rTxtRemainder = new rComponents.rTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBuyPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtSellPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBillNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtRemainder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 90);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "تــایــیــد";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(12, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "انصــراف";
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(410, 58);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(56, 17);
            this.rLabel2.TabIndex = 9;
            this.rLabel2.Text = "تعداد کــل:";
            // 
            // rTxtCount
            // 
            this.rTxtCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtCount.BackColor = System.Drawing.Color.White;
            this.rTxtCount.Culture = null;
            this.rTxtCount.FieldName = "تعداد";
            this.rTxtCount.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTxtCount.Language = rComponents.TextboxLanguage.DontCare;
            this.rTxtCount.Location = new System.Drawing.Point(257, 58);
            this.rTxtCount.Mask = "D";
            this.rTxtCount.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.rTxtCount.MaximumValue = null;
            this.rTxtCount.MinimumValue = "1";
            this.rTxtCount.Name = "rTxtCount";
            this.rTxtCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTxtCount.Size = new System.Drawing.Size(147, 19);
            this.rTxtCount.TabIndex = 3;
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
            this.rLabel3.Location = new System.Drawing.Point(410, 35);
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
            this.rTxtBuyPrice.Location = new System.Drawing.Point(257, 33);
            this.rTxtBuyPrice.Mask = "c0";
            this.rTxtBuyPrice.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.rTxtBuyPrice.MaximumValue = null;
            this.rTxtBuyPrice.MinimumValue = "1";
            this.rTxtBuyPrice.Name = "rTxtBuyPrice";
            this.rTxtBuyPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTxtBuyPrice.Size = new System.Drawing.Size(147, 19);
            this.rTxtBuyPrice.TabIndex = 1;
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
            this.rLabel4.Location = new System.Drawing.Point(167, 35);
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
            this.rTxtSellPrice.Location = new System.Drawing.Point(14, 33);
            this.rTxtSellPrice.Mask = "c0";
            this.rTxtSellPrice.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.rTxtSellPrice.MaximumValue = null;
            this.rTxtSellPrice.MinimumValue = "1";
            this.rTxtSellPrice.Name = "rTxtSellPrice";
            this.rTxtSellPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTxtSellPrice.Size = new System.Drawing.Size(147, 19);
            this.rTxtSellPrice.TabIndex = 2;
            this.rTxtSellPrice.TabStop = false;
            this.rTxtSellPrice.Type = rComponents.rTextBoxType.Money;
            this.rTxtSellPrice.ValidatingProperty = null;
            this.rTxtSellPrice.ValidationType = rComponents.ValidationType.InRange;
            // 
            // rTxtBillNo
            // 
            this.rTxtBillNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtBillNo.BackColor = System.Drawing.Color.White;
            this.rTxtBillNo.Culture = null;
            this.rTxtBillNo.FieldName = "تعداد";
            this.rTxtBillNo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTxtBillNo.Language = rComponents.TextboxLanguage.DontCare;
            this.rTxtBillNo.Location = new System.Drawing.Point(257, 8);
            this.rTxtBillNo.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTxtBillNo.MaximumValue = null;
            this.rTxtBillNo.MinimumValue = "";
            this.rTxtBillNo.Name = "rTxtBillNo";
            this.rTxtBillNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTxtBillNo.Size = new System.Drawing.Size(147, 19);
            this.rTxtBillNo.TabIndex = 0;
            this.rTxtBillNo.TabStop = false;
            this.rTxtBillNo.Type = rComponents.rTextBoxType.Text;
            this.rTxtBillNo.ValidatingProperty = null;
            this.rTxtBillNo.ValidationType = rComponents.ValidationType.None;
            // 
            // rLabel5
            // 
            this.rLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel5.BackColor = System.Drawing.Color.Transparent;
            this.rLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel5.Location = new System.Drawing.Point(410, 8);
            this.rLabel5.Name = "rLabel5";
            this.rLabel5.Size = new System.Drawing.Size(75, 17);
            this.rLabel5.TabIndex = 11;
            this.rLabel5.Text = "شماره فاکتور :";
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(167, 58);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(50, 17);
            this.rLabel1.TabIndex = 9;
            this.rLabel1.Text = "باقیمانده:";
            // 
            // rTxtRemainder
            // 
            this.rTxtRemainder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtRemainder.BackColor = System.Drawing.Color.White;
            this.rTxtRemainder.Culture = null;
            this.rTxtRemainder.FieldName = "باقیمانده";
            this.rTxtRemainder.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTxtRemainder.Language = rComponents.TextboxLanguage.DontCare;
            this.rTxtRemainder.Location = new System.Drawing.Point(14, 58);
            this.rTxtRemainder.Mask = "D";
            this.rTxtRemainder.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.rTxtRemainder.MaximumValue = null;
            this.rTxtRemainder.MinimumValue = "0";
            this.rTxtRemainder.Name = "rTxtRemainder";
            this.rTxtRemainder.ReadOnly = true;
            this.rTxtRemainder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTxtRemainder.Size = new System.Drawing.Size(147, 19);
            this.rTxtRemainder.TabIndex = 4;
            this.rTxtRemainder.TabStop = false;
            this.rTxtRemainder.Type = rComponents.rTextBoxType.Numeric;
            this.rTxtRemainder.ValidatingProperty = null;
            this.rTxtRemainder.ValidationType = rComponents.ValidationType.None;
            // 
            // frmEducationalToolSupplyDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 124);
            this.Controls.Add(this.rTxtBillNo);
            this.Controls.Add(this.rLabel5);
            this.Controls.Add(this.rTxtRemainder);
            this.Controls.Add(this.rTxtCount);
            this.Controls.Add(this.rTxtSellPrice);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.rLabel2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rLabel4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rLabel3);
            this.Controls.Add(this.rTxtBuyPrice);
            this.Name = "frmEducationalToolSupplyDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات موجودی";
            this.Load += new System.EventHandler(this.frmEducationalToolSupplyDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBuyPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtSellPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBillNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtRemainder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private rComponents.rLabel rLabel2;
        private rComponents.rTextBox rTxtCount;
        private rComponents.rLabel rLabel3;
        private rComponents.rTextBox rTxtBuyPrice;
        private rComponents.rLabel rLabel4;
        private rComponents.rTextBox rTxtSellPrice;
        private rComponents.rTextBox rTxtBillNo;
        private rComponents.rLabel rLabel5;
        private rComponents.rLabel rLabel1;
        private rComponents.rTextBox rTxtRemainder;
    }
}