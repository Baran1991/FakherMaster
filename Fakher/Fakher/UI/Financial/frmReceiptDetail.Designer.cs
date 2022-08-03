using Fakher.Core.DomainModel;
using Fakher.Core.rComponents;
using rComponents;

namespace Fakher.UI
{
    partial class frmReceiptDetail
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
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.rDatePicker1 = new rComponents.rDatePicker(this.components);
            this.radTextBox1 = new rComponents.rTextBox(this.components);
            this.radTextBox2 = new rComponents.rTextBox(this.components);
            this.rLabel4 = new rComponents.rLabel(this.components);
            this.rComboBoxStatus = new rComponents.rComboBox(this.components);
            this.rLabel5 = new rComponents.rLabel(this.components);
            this.rGridCmbBankAccounts = new rComponents.rGridComboBox(this.components);
            this.rComboBoxReceiptColleague = new rComponents.rComboBox(this.components);
            this.rLabel6 = new rComponents.rLabel(this.components);
            this.rLabel7 = new rComponents.rLabel(this.components);
            this.rComboBoxSendingToBankName = new rComponents.rComboBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rComboBoxStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbBankAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbBankAccounts.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbBankAccounts.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rComboBoxReceiptColleague)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rComboBoxSendingToBankName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 106);
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
            this.btnCancel.Location = new System.Drawing.Point(12, 106);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "انصــراف";
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(510, 24);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(73, 20);
            this.rLabel1.TabIndex = 10;
            this.rLabel1.Text = "تاریخ فیش:";
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(194, 23);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(71, 20);
            this.rLabel2.TabIndex = 10;
            this.rLabel2.Text = "مبلغ فیش:";
            // 
            // rLabel3
            // 
            this.rLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel3.BackColor = System.Drawing.Color.Transparent;
            this.rLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel3.Location = new System.Drawing.Point(510, 49);
            this.rLabel3.Name = "rLabel3";
            this.rLabel3.Size = new System.Drawing.Size(84, 20);
            this.rLabel3.TabIndex = 10;
            this.rLabel3.Text = "شماره فیش:";
            // 
            // rDatePicker1
            // 
            this.rDatePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePicker1.BackColor = System.Drawing.Color.Transparent;
            this.rDatePicker1.Culture = null;
            this.rDatePicker1.FieldName = "تاریخ";
            this.rDatePicker1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rDatePicker1.Location = new System.Drawing.Point(328, 23);
            this.rDatePicker1.Mask = "1###/##/##";
            this.rDatePicker1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePicker1.Name = "rDatePicker1";
            this.rDatePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePicker1.SelectedText = "_";
            this.rDatePicker1.SelectionLength = 1;
            this.rDatePicker1.SelectionStart = 9;
            this.rDatePicker1.Size = new System.Drawing.Size(176, 22);
            this.rDatePicker1.TabIndex = 0;
            this.rDatePicker1.TabStop = false;
            this.rDatePicker1.Text = "1890/61/9_";
            this.rDatePicker1.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rDatePicker1.Value = "890619";
            // 
            // radTextBox1
            // 
            this.radTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox1.BackColor = System.Drawing.Color.White;
            this.radTextBox1.Culture = null;
            this.radTextBox1.FieldName = "مبلغ فیش واریزی";
            this.radTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radTextBox1.Language = rComponents.TextboxLanguage.DontCare;
            this.radTextBox1.Location = new System.Drawing.Point(12, 21);
            this.radTextBox1.Mask = "c0";
            this.radTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.radTextBox1.MaximumValue = null;
            this.radTextBox1.MinimumValue = "1";
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radTextBox1.Size = new System.Drawing.Size(176, 22);
            this.radTextBox1.TabIndex = 2;
            this.radTextBox1.TabStop = false;
            this.radTextBox1.Type = rComponents.rTextBoxType.Money;
            this.radTextBox1.ValidatingProperty = null;
            this.radTextBox1.ValidationType = rComponents.ValidationType.InRange;
            // 
            // radTextBox2
            // 
            this.radTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox2.BackColor = System.Drawing.Color.White;
            this.radTextBox2.Culture = null;
            this.radTextBox2.FieldName = "شماره فیش";
            this.radTextBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radTextBox2.Language = rComponents.TextboxLanguage.English;
            this.radTextBox2.Location = new System.Drawing.Point(328, 48);
            this.radTextBox2.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.radTextBox2.MaximumValue = null;
            this.radTextBox2.MinimumValue = null;
            this.radTextBox2.Name = "radTextBox2";
            this.radTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radTextBox2.Size = new System.Drawing.Size(176, 22);
            this.radTextBox2.TabIndex = 1;
            this.radTextBox2.TabStop = false;
            this.radTextBox2.Type = rComponents.rTextBoxType.Text;
            this.radTextBox2.ValidatingProperty = null;
            this.radTextBox2.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // rLabel4
            // 
            this.rLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel4.BackColor = System.Drawing.Color.Transparent;
            this.rLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel4.Location = new System.Drawing.Point(510, 74);
            this.rLabel4.Name = "rLabel4";
            this.rLabel4.Size = new System.Drawing.Size(38, 20);
            this.rLabel4.TabIndex = 10;
            this.rLabel4.Text = "بانک:";
            // 
            // rComboBoxStatus
            // 
            this.rComboBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rComboBoxStatus.DropDownAnimationEnabled = true;
            this.rComboBoxStatus.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rComboBoxStatus.FieldName = "وضعیت چک";
            this.rComboBoxStatus.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rComboBoxStatus.Location = new System.Drawing.Point(12, 47);
            this.rComboBoxStatus.MaximumValue = null;
            this.rComboBoxStatus.MinimumValue = null;
            this.rComboBoxStatus.Name = "rComboBoxStatus";
            this.rComboBoxStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rComboBoxStatus.ShowImageInEditorArea = true;
            this.rComboBoxStatus.Size = new System.Drawing.Size(176, 22);
            this.rComboBoxStatus.TabIndex = 4;
            this.rComboBoxStatus.ValidatingProperty = null;
            this.rComboBoxStatus.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rComboBoxStatus.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.rComboBoxStatus_SelectedIndexChanged);
            // 
            // rLabel5
            // 
            this.rLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel5.BackColor = System.Drawing.Color.Transparent;
            this.rLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel5.Location = new System.Drawing.Point(194, 49);
            this.rLabel5.Name = "rLabel5";
            this.rLabel5.Size = new System.Drawing.Size(54, 20);
            this.rLabel5.TabIndex = 12;
            this.rLabel5.Text = "وضعیت:";
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
            this.rGridCmbBankAccounts.Location = new System.Drawing.Point(328, 73);
            this.rGridCmbBankAccounts.MaximumValue = null;
            this.rGridCmbBankAccounts.MinimumValue = null;
            this.rGridCmbBankAccounts.Name = "rGridCmbBankAccounts";
            // 
            // 
            // 
            this.rGridCmbBankAccounts.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridCmbBankAccounts.ShowFilteringRow = true;
            this.rGridCmbBankAccounts.ShowNullButton = false;
            this.rGridCmbBankAccounts.Size = new System.Drawing.Size(176, 22);
            this.rGridCmbBankAccounts.TabIndex = 3;
            this.rGridCmbBankAccounts.TabStop = false;
            this.rGridCmbBankAccounts.ValidatingProperty = null;
            this.rGridCmbBankAccounts.ValidationType = rComponents.ValidationType.None;
            this.rGridCmbBankAccounts.Value = null;
            // 
            // rComboBoxReceiptColleague
            // 
            this.rComboBoxReceiptColleague.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rComboBoxReceiptColleague.DropDownAnimationEnabled = true;
            this.rComboBoxReceiptColleague.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rComboBoxReceiptColleague.FieldName = "همکار دریافت کننده";
            this.rComboBoxReceiptColleague.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rComboBoxReceiptColleague.Location = new System.Drawing.Point(12, 71);
            this.rComboBoxReceiptColleague.MaximumValue = null;
            this.rComboBoxReceiptColleague.MinimumValue = null;
            this.rComboBoxReceiptColleague.Name = "rComboBoxReceiptColleague";
            this.rComboBoxReceiptColleague.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rComboBoxReceiptColleague.ShowImageInEditorArea = true;
            this.rComboBoxReceiptColleague.Size = new System.Drawing.Size(176, 22);
            this.rComboBoxReceiptColleague.TabIndex = 13;
            this.rComboBoxReceiptColleague.ValidatingProperty = null;
            this.rComboBoxReceiptColleague.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // rLabel6
            // 
            this.rLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel6.BackColor = System.Drawing.Color.Transparent;
            this.rLabel6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel6.Location = new System.Drawing.Point(194, 72);
            this.rLabel6.Name = "rLabel6";
            this.rLabel6.Size = new System.Drawing.Size(126, 20);
            this.rLabel6.TabIndex = 13;
            this.rLabel6.Text = "همکار دریافت کننده:";
            // 
            // rLabel7
            // 
            this.rLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel7.BackColor = System.Drawing.Color.Transparent;
            this.rLabel7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel7.Location = new System.Drawing.Point(510, 102);
            this.rLabel7.Name = "rLabel7";
            this.rLabel7.Size = new System.Drawing.Size(87, 20);
            this.rLabel7.TabIndex = 14;
            this.rLabel7.Text = "بانک ارسالی:";
            this.rLabel7.Visible = false;
            // 
            // rComboBoxSendingToBankName
            // 
            this.rComboBoxSendingToBankName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rComboBoxSendingToBankName.DropDownAnimationEnabled = true;
            this.rComboBoxSendingToBankName.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rComboBoxSendingToBankName.FieldName = "همکار دریافت کننده";
            this.rComboBoxSendingToBankName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rComboBoxSendingToBankName.Location = new System.Drawing.Point(314, 101);
            this.rComboBoxSendingToBankName.MaximumValue = null;
            this.rComboBoxSendingToBankName.MinimumValue = null;
            this.rComboBoxSendingToBankName.Name = "rComboBoxSendingToBankName";
            this.rComboBoxSendingToBankName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rComboBoxSendingToBankName.ShowImageInEditorArea = true;
            this.rComboBoxSendingToBankName.Size = new System.Drawing.Size(190, 22);
            this.rComboBoxSendingToBankName.TabIndex = 15;
            this.rComboBoxSendingToBankName.ValidatingProperty = null;
            this.rComboBoxSendingToBankName.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rComboBoxSendingToBankName.Visible = false;
            // 
            // frmReceiptDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 179);
            this.Controls.Add(this.rLabel7);
            this.Controls.Add(this.rLabel6);
            this.Controls.Add(this.rComboBoxSendingToBankName);
            this.Controls.Add(this.rComboBoxReceiptColleague);
            this.Controls.Add(this.rGridCmbBankAccounts);
            this.Controls.Add(this.rComboBoxStatus);
            this.Controls.Add(this.rLabel5);
            this.Controls.Add(this.radTextBox2);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.rLabel4);
            this.Controls.Add(this.rDatePicker1);
            this.Controls.Add(this.rLabel3);
            this.Controls.Add(this.rLabel2);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReceiptDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات فیش واریز به حساب";
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rComboBoxStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbBankAccounts.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbBankAccounts.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbBankAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rComboBoxReceiptColleague)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rComboBoxSendingToBankName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private rComponents.rLabel rLabel1;
        private rComponents.rLabel rLabel2;
        private rComponents.rLabel rLabel3;
        private rComponents.rDatePicker rDatePicker1;
        private rTextBox radTextBox1;
        private rTextBox radTextBox2;
        private rLabel rLabel4;
        private rComboBox rComboBoxStatus;
        private rLabel rLabel5;
        private rGridComboBox rGridCmbBankAccounts;
        private rComboBox rComboBoxReceiptColleague;
        private rLabel rLabel6;
        private rLabel rLabel7;
        private rComboBox rComboBoxSendingToBankName;
    }
}