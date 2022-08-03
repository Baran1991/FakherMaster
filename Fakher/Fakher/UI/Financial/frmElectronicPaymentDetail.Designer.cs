
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Financial
{
    partial class frmElectronicPaymentDetail
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
            this.rTextBox2 = new rComponents.rTextBox(this.components);
            this.rDatePicker1 = new rComponents.rDatePicker(this.components);
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.rTextBox1 = new rComponents.rTextBox(this.components);
            this.rLabel4 = new rComponents.rLabel(this.components);
            this.rTextBox3 = new rComponents.rTextBox(this.components);
            this.rTextBox4 = new rComponents.rTextBox(this.components);
            this.rLabel5 = new rComponents.rLabel(this.components);
            this.rGridCmbBankAccounts = new rComponents.rGridComboBox(this.components);
            this.rLabel6 = new rComponents.rLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbBankAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbBankAccounts.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbBankAccounts.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rTextBox2
            // 
            this.rTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox2.Culture = null;
            this.rTextBox2.FieldName = "شماره کارت";
            this.rTextBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox2.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox2.Location = new System.Drawing.Point(315, 37);
            this.rTextBox2.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox2.MaximumValue = null;
            this.rTextBox2.MinimumValue = null;
            this.rTextBox2.Name = "rTextBox2";
            this.rTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox2.Size = new System.Drawing.Size(176, 25);
            this.rTextBox2.TabIndex = 1;
            this.rTextBox2.TabStop = false;
            this.rTextBox2.Type = rComponents.rTextBoxType.Text;
            this.rTextBox2.ValidatingProperty = null;
            this.rTextBox2.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // rDatePicker1
            // 
            this.rDatePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePicker1.BackColor = System.Drawing.Color.Transparent;
            this.rDatePicker1.Culture = null;
            this.rDatePicker1.FieldName = "تاریخ سررسید";
            this.rDatePicker1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rDatePicker1.Location = new System.Drawing.Point(315, 12);
            this.rDatePicker1.Mask = "1###/##/##";
            this.rDatePicker1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePicker1.Name = "rDatePicker1";
            this.rDatePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePicker1.SelectionStart = 10;
            this.rDatePicker1.Size = new System.Drawing.Size(176, 25);
            this.rDatePicker1.TabIndex = 0;
            this.rDatePicker1.TabStop = false;
            this.rDatePicker1.Text = "1389/06/19";
            this.rDatePicker1.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rDatePicker1.Value = "890619";
            // 
            // rLabel3
            // 
            this.rLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel3.BackColor = System.Drawing.Color.Transparent;
            this.rLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel3.Location = new System.Drawing.Point(497, 39);
            this.rLabel3.Name = "rLabel3";
            this.rLabel3.Size = new System.Drawing.Size(99, 24);
            this.rLabel3.TabIndex = 14;
            this.rLabel3.Text = "شماره کارت:";
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(497, 12);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(47, 24);
            this.rLabel1.TabIndex = 13;
            this.rLabel1.Text = "تاریخ:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 122);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "تــایــیــد";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            this.btnOk.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOk_MouseDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(12, 122);
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
            this.rLabel2.Location = new System.Drawing.Point(497, 64);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(113, 24);
            this.rLabel2.TabIndex = 14;
            this.rLabel2.Text = "شماره پیگیری:";
            // 
            // rTextBox1
            // 
            this.rTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox1.Culture = null;
            this.rTextBox1.FieldName = "شماره پیگیری";
            this.rTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox1.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox1.Location = new System.Drawing.Point(315, 62);
            this.rTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox1.MaximumValue = null;
            this.rTextBox1.MinimumValue = null;
            this.rTextBox1.Name = "rTextBox1";
            this.rTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox1.Size = new System.Drawing.Size(176, 25);
            this.rTextBox1.TabIndex = 3;
            this.rTextBox1.TabStop = false;
            this.rTextBox1.Type = rComponents.rTextBoxType.Text;
            this.rTextBox1.ValidatingProperty = null;
            this.rTextBox1.ValidationType = rComponents.ValidationType.None;
            // 
            // rLabel4
            // 
            this.rLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel4.BackColor = System.Drawing.Color.Transparent;
            this.rLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel4.Location = new System.Drawing.Point(194, 64);
            this.rLabel4.Name = "rLabel4";
            this.rLabel4.Size = new System.Drawing.Size(161, 24);
            this.rLabel4.TabIndex = 14;
            this.rLabel4.Text = "شماره ارجاع/تراکنش:";
            // 
            // rTextBox3
            // 
            this.rTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox3.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox3.Culture = null;
            this.rTextBox3.FieldName = "شماره ارجاع/تراکنش";
            this.rTextBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox3.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox3.Location = new System.Drawing.Point(12, 62);
            this.rTextBox3.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox3.MaximumValue = null;
            this.rTextBox3.MinimumValue = null;
            this.rTextBox3.Name = "rTextBox3";
            this.rTextBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox3.Size = new System.Drawing.Size(176, 25);
            this.rTextBox3.TabIndex = 4;
            this.rTextBox3.TabStop = false;
            this.rTextBox3.Type = rComponents.rTextBoxType.Text;
            this.rTextBox3.ValidatingProperty = null;
            this.rTextBox3.ValidationType = rComponents.ValidationType.None;
            // 
            // rTextBox4
            // 
            this.rTextBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox4.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox4.Culture = null;
            this.rTextBox4.FieldName = "مبلغ";
            this.rTextBox4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox4.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox4.Location = new System.Drawing.Point(12, 37);
            this.rTextBox4.Mask = "c0";
            this.rTextBox4.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.rTextBox4.MaximumValue = null;
            this.rTextBox4.MinimumValue = "1";
            this.rTextBox4.Name = "rTextBox4";
            this.rTextBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox4.Size = new System.Drawing.Size(176, 25);
            this.rTextBox4.TabIndex = 2;
            this.rTextBox4.TabStop = false;
            this.rTextBox4.Type = rComponents.rTextBoxType.Money;
            this.rTextBox4.ValidatingProperty = null;
            this.rTextBox4.ValidationType = rComponents.ValidationType.InRange;
            // 
            // rLabel5
            // 
            this.rLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel5.BackColor = System.Drawing.Color.Transparent;
            this.rLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel5.Location = new System.Drawing.Point(194, 39);
            this.rLabel5.Name = "rLabel5";
            this.rLabel5.Size = new System.Drawing.Size(45, 24);
            this.rLabel5.TabIndex = 16;
            this.rLabel5.Text = "مبلغ:";
            // 
            // rGridCmbBankAccounts
            // 
            this.rGridCmbBankAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridCmbBankAccounts.CompareMember = null;
            this.rGridCmbBankAccounts.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridCmbBankAccounts.NestedRadGridView
            // 
            this.rGridCmbBankAccounts.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridCmbBankAccounts.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridCmbBankAccounts.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridCmbBankAccounts.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rGridCmbBankAccounts.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridCmbBankAccounts.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridCmbBankAccounts.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridCmbBankAccounts.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridCmbBankAccounts.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridCmbBankAccounts.EditorControl.MasterTemplate.EnableFiltering = true;
            this.rGridCmbBankAccounts.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridCmbBankAccounts.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridCmbBankAccounts.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridCmbBankAccounts.EditorControl.Name = "NestedRadGridView";
            this.rGridCmbBankAccounts.EditorControl.ReadOnly = true;
            this.rGridCmbBankAccounts.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridCmbBankAccounts.EditorControl.ShowGroupPanel = false;
            this.rGridCmbBankAccounts.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridCmbBankAccounts.EditorControl.TabIndex = 0;
            this.rGridCmbBankAccounts.FieldName = null;
            this.rGridCmbBankAccounts.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridCmbBankAccounts.Location = new System.Drawing.Point(315, 88);
            this.rGridCmbBankAccounts.MaximumValue = null;
            this.rGridCmbBankAccounts.MinimumValue = null;
            this.rGridCmbBankAccounts.Name = "rGridCmbBankAccounts";
            // 
            // 
            // 
            this.rGridCmbBankAccounts.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridCmbBankAccounts.ShowFilteringRow = true;
            this.rGridCmbBankAccounts.ShowNullButton = false;
            this.rGridCmbBankAccounts.Size = new System.Drawing.Size(176, 25);
            this.rGridCmbBankAccounts.TabIndex = 17;
            this.rGridCmbBankAccounts.TabStop = false;
            this.rGridCmbBankAccounts.ValidatingProperty = null;
            this.rGridCmbBankAccounts.ValidationType = rComponents.ValidationType.None;
            this.rGridCmbBankAccounts.Value = null;
            // 
            // rLabel6
            // 
            this.rLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel6.BackColor = System.Drawing.Color.Transparent;
            this.rLabel6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel6.Location = new System.Drawing.Point(497, 90);
            this.rLabel6.Name = "rLabel6";
            this.rLabel6.Size = new System.Drawing.Size(45, 24);
            this.rLabel6.TabIndex = 14;
            this.rLabel6.Text = "بانک:";
            // 
            // frmElectronicPaymentDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 251);
            this.Controls.Add(this.rGridCmbBankAccounts);
            this.Controls.Add(this.rTextBox4);
            this.Controls.Add(this.rLabel5);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rTextBox3);
            this.Controls.Add(this.rTextBox1);
            this.Controls.Add(this.rLabel4);
            this.Controls.Add(this.rTextBox2);
            this.Controls.Add(this.rLabel6);
            this.Controls.Add(this.rLabel2);
            this.Controls.Add(this.rDatePicker1);
            this.Controls.Add(this.rLabel3);
            this.Controls.Add(this.rLabel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmElectronicPaymentDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات پرداخت الکترونیکی";
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbBankAccounts.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbBankAccounts.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbBankAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rTextBox rTextBox2;
        private rComponents.rDatePicker rDatePicker1;
        private rComponents.rLabel rLabel3;
        private rComponents.rLabel rLabel1;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private rComponents.rLabel rLabel2;
        private rComponents.rTextBox rTextBox1;
        private rComponents.rLabel rLabel4;
        private rComponents.rTextBox rTextBox3;
        private rComponents.rTextBox rTextBox4;
        private rComponents.rLabel rLabel5;
        private rGridComboBox rGridCmbBankAccounts;
        private rLabel rLabel6;
    }
}