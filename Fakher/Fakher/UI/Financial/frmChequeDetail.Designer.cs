using Fakher.Core.DomainModel;
using Fakher.Core.rComponents;
using rComponents;

namespace Fakher.UI
{
    partial class frmChequeDetail
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
            this.rLabel4 = new rComponents.rLabel(this.components);
            this.rTextBox1 = new rComponents.rTextBox(this.components);
            this.rTextBox2 = new rComponents.rTextBox(this.components);
            this.rTextBox3 = new rComponents.rTextBox(this.components);
            this.rLabel5 = new rComponents.rLabel(this.components);
            this.rComboBoxStatus = new rComponents.rComboBox(this.components);
            this.rLabel6 = new rComponents.rLabel(this.components);
            this.rTextBox4 = new rComponents.rTextBox(this.components);
            this.rDatePicker2 = new rComponents.rDatePicker(this.components);
            this.rLabel7 = new rComponents.rLabel(this.components);
            this.rLabel8 = new rComponents.rLabel(this.components);
            this.rComboBoxRecipientColleague = new rComponents.rComboBox(this.components);
            this.rLabel9 = new rComponents.rLabel(this.components);
            this.rComboBoxSendingToBankName = new rComponents.rComboBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rComboBoxStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rComboBoxRecipientColleague)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rComboBoxSendingToBankName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(144, 122);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "تــایــیــد";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(8, 122);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "انصــراف";
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(653, 37);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(95, 20);
            this.rLabel1.TabIndex = 10;
            this.rLabel1.Text = "تاریخ سررسید:";
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(288, 64);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(65, 20);
            this.rLabel2.TabIndex = 10;
            this.rLabel2.Text = "مبلغ چک:";
            // 
            // rLabel3
            // 
            this.rLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel3.BackColor = System.Drawing.Color.Transparent;
            this.rLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel3.Location = new System.Drawing.Point(288, 12);
            this.rLabel3.Name = "rLabel3";
            this.rLabel3.Size = new System.Drawing.Size(78, 20);
            this.rLabel3.TabIndex = 10;
            this.rLabel3.Text = "شماره چک:";
            // 
            // rDatePicker1
            // 
            this.rDatePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePicker1.BackColor = System.Drawing.Color.Transparent;
            this.rDatePicker1.Culture = null;
            this.rDatePicker1.FieldName = "تاریخ سررسید";
            this.rDatePicker1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rDatePicker1.Location = new System.Drawing.Point(423, 35);
            this.rDatePicker1.Mask = "1###/##/##";
            this.rDatePicker1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePicker1.Name = "rDatePicker1";
            this.rDatePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePicker1.SelectedText = "_";
            this.rDatePicker1.SelectionLength = 1;
            this.rDatePicker1.SelectionStart = 9;
            this.rDatePicker1.Size = new System.Drawing.Size(224, 22);
            this.rDatePicker1.TabIndex = 0;
            this.rDatePicker1.TabStop = false;
            this.rDatePicker1.Text = "1890/61/9_";
            this.rDatePicker1.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rDatePicker1.Value = "890619";
            // 
            // rLabel4
            // 
            this.rLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel4.BackColor = System.Drawing.Color.Transparent;
            this.rLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel4.Location = new System.Drawing.Point(653, 62);
            this.rLabel4.Name = "rLabel4";
            this.rLabel4.Size = new System.Drawing.Size(38, 20);
            this.rLabel4.TabIndex = 10;
            this.rLabel4.Text = "بانک:";
            // 
            // rTextBox1
            // 
            this.rTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox1.Culture = null;
            this.rTextBox1.FieldName = "مبلغ چک";
            this.rTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox1.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox1.Location = new System.Drawing.Point(43, 62);
            this.rTextBox1.Mask = "c0";
            this.rTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.rTextBox1.MaximumValue = null;
            this.rTextBox1.MinimumValue = "1";
            this.rTextBox1.Name = "rTextBox1";
            this.rTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox1.Size = new System.Drawing.Size(239, 22);
            this.rTextBox1.TabIndex = 4;
            this.rTextBox1.TabStop = false;
            this.rTextBox1.Type = rComponents.rTextBoxType.Money;
            this.rTextBox1.ValidatingProperty = null;
            this.rTextBox1.ValidationType = rComponents.ValidationType.InRange;
            // 
            // rTextBox2
            // 
            this.rTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox2.Culture = null;
            this.rTextBox2.FieldName = "شماره چک";
            this.rTextBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox2.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox2.Location = new System.Drawing.Point(43, 10);
            this.rTextBox2.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox2.MaximumValue = null;
            this.rTextBox2.MinimumValue = null;
            this.rTextBox2.Name = "rTextBox2";
            this.rTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox2.Size = new System.Drawing.Size(239, 22);
            this.rTextBox2.TabIndex = 1;
            this.rTextBox2.TabStop = false;
            this.rTextBox2.Type = rComponents.rTextBoxType.Text;
            this.rTextBox2.ValidatingProperty = null;
            this.rTextBox2.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // rTextBox3
            // 
            this.rTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox3.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox3.Culture = null;
            this.rTextBox3.FieldName = "نام بانک";
            this.rTextBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox3.Language = rComponents.TextboxLanguage.Farsi;
            this.rTextBox3.Location = new System.Drawing.Point(423, 60);
            this.rTextBox3.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox3.MaximumValue = null;
            this.rTextBox3.MinimumValue = null;
            this.rTextBox3.Name = "rTextBox3";
            this.rTextBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rTextBox3.Size = new System.Drawing.Size(224, 22);
            this.rTextBox3.TabIndex = 2;
            this.rTextBox3.TabStop = false;
            this.rTextBox3.Type = rComponents.rTextBoxType.Text;
            this.rTextBox3.ValidatingProperty = null;
            this.rTextBox3.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // rLabel5
            // 
            this.rLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel5.BackColor = System.Drawing.Color.Transparent;
            this.rLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel5.Location = new System.Drawing.Point(653, 86);
            this.rLabel5.Name = "rLabel5";
            this.rLabel5.Size = new System.Drawing.Size(54, 20);
            this.rLabel5.TabIndex = 10;
            this.rLabel5.Text = "وضعیت:";
            // 
            // rComboBoxStatus
            // 
            this.rComboBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rComboBoxStatus.DropDownAnimationEnabled = true;
            this.rComboBoxStatus.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rComboBoxStatus.FieldName = "وضعیت چک";
            this.rComboBoxStatus.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rComboBoxStatus.Location = new System.Drawing.Point(423, 84);
            this.rComboBoxStatus.MaximumValue = null;
            this.rComboBoxStatus.MinimumValue = null;
            this.rComboBoxStatus.Name = "rComboBoxStatus";
            this.rComboBoxStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rComboBoxStatus.ShowImageInEditorArea = true;
            this.rComboBoxStatus.Size = new System.Drawing.Size(224, 22);
            this.rComboBoxStatus.TabIndex = 5;
            this.rComboBoxStatus.ValidatingProperty = null;
            this.rComboBoxStatus.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rComboBoxStatus.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.rComboBoxStatus_SelectedIndexChanged);
            // 
            // rLabel6
            // 
            this.rLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel6.BackColor = System.Drawing.Color.Transparent;
            this.rLabel6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel6.Location = new System.Drawing.Point(288, 37);
            this.rLabel6.Name = "rLabel6";
            this.rLabel6.Size = new System.Drawing.Size(53, 20);
            this.rLabel6.TabIndex = 10;
            this.rLabel6.Text = "شعبــه:";
            // 
            // rTextBox4
            // 
            this.rTextBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox4.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox4.Culture = null;
            this.rTextBox4.FieldName = "شعبه بانک";
            this.rTextBox4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox4.Language = rComponents.TextboxLanguage.Farsi;
            this.rTextBox4.Location = new System.Drawing.Point(43, 35);
            this.rTextBox4.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox4.MaximumValue = null;
            this.rTextBox4.MinimumValue = null;
            this.rTextBox4.Name = "rTextBox4";
            this.rTextBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rTextBox4.Size = new System.Drawing.Size(239, 22);
            this.rTextBox4.TabIndex = 3;
            this.rTextBox4.TabStop = false;
            this.rTextBox4.Type = rComponents.rTextBoxType.Text;
            this.rTextBox4.ValidatingProperty = null;
            this.rTextBox4.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // rDatePicker2
            // 
            this.rDatePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePicker2.BackColor = System.Drawing.Color.Transparent;
            this.rDatePicker2.Culture = null;
            this.rDatePicker2.Enabled = false;
            this.rDatePicker2.FieldName = "تاریخ سررسید";
            this.rDatePicker2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rDatePicker2.Location = new System.Drawing.Point(423, 8);
            this.rDatePicker2.Mask = "1###/##/##";
            this.rDatePicker2.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePicker2.Name = "rDatePicker2";
            this.rDatePicker2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePicker2.SelectedText = "_";
            this.rDatePicker2.SelectionLength = 1;
            this.rDatePicker2.SelectionStart = 9;
            this.rDatePicker2.Size = new System.Drawing.Size(224, 22);
            this.rDatePicker2.TabIndex = 11;
            this.rDatePicker2.TabStop = false;
            this.rDatePicker2.Text = "1890/61/9_";
            this.rDatePicker2.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rDatePicker2.Value = "890619";
            // 
            // rLabel7
            // 
            this.rLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel7.BackColor = System.Drawing.Color.Transparent;
            this.rLabel7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel7.Location = new System.Drawing.Point(653, 10);
            this.rLabel7.Name = "rLabel7";
            this.rLabel7.Size = new System.Drawing.Size(66, 20);
            this.rLabel7.TabIndex = 12;
            this.rLabel7.Text = "تاریخ ثبت:";
            // 
            // rLabel8
            // 
            this.rLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel8.BackColor = System.Drawing.Color.Transparent;
            this.rLabel8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel8.Location = new System.Drawing.Point(653, 112);
            this.rLabel8.Name = "rLabel8";
            this.rLabel8.Size = new System.Drawing.Size(126, 20);
            this.rLabel8.TabIndex = 11;
            this.rLabel8.Text = "همکار دریافت کننده:";
            this.rLabel8.Visible = true;
            // 
            // rComboBoxRecipientColleague
            // 
            this.rComboBoxRecipientColleague.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rComboBoxRecipientColleague.DropDownAnimationEnabled = true;
            this.rComboBoxRecipientColleague.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rComboBoxRecipientColleague.FieldName = "همکار دریافت کننده";
            this.rComboBoxRecipientColleague.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rComboBoxRecipientColleague.Location = new System.Drawing.Point(423, 110);
            this.rComboBoxRecipientColleague.MaximumValue = null;
            this.rComboBoxRecipientColleague.MinimumValue = null;
            this.rComboBoxRecipientColleague.Name = "rComboBoxRecipientColleague";
            this.rComboBoxRecipientColleague.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rComboBoxRecipientColleague.ShowImageInEditorArea = true;
            this.rComboBoxRecipientColleague.Size = new System.Drawing.Size(224, 22);
            this.rComboBoxRecipientColleague.TabIndex = 5;
            this.rComboBoxRecipientColleague.ValidatingProperty = null;
            this.rComboBoxRecipientColleague.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rComboBoxRecipientColleague.Visible = true;
            // 
            // rLabel9
            // 
            this.rLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel9.BackColor = System.Drawing.Color.Transparent;
            this.rLabel9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel9.Location = new System.Drawing.Point(288, 92);
            this.rLabel9.Name = "rLabel9";
            this.rLabel9.Size = new System.Drawing.Size(87, 20);
            this.rLabel9.TabIndex = 13;
            this.rLabel9.Text = "بانک ارسالی:";
            this.rLabel9.Visible = false;
            // 
            // rComboBoxSendingToBankName
            // 
            this.rComboBoxSendingToBankName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rComboBoxSendingToBankName.DropDownAnimationEnabled = true;
            this.rComboBoxSendingToBankName.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rComboBoxSendingToBankName.FieldName = "بانک ارسالی";
            this.rComboBoxSendingToBankName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rComboBoxSendingToBankName.Location = new System.Drawing.Point(43, 90);
            this.rComboBoxSendingToBankName.MaximumValue = null;
            this.rComboBoxSendingToBankName.MinimumValue = null;
            this.rComboBoxSendingToBankName.Name = "rComboBoxSendingToBankName";
            this.rComboBoxSendingToBankName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rComboBoxSendingToBankName.ShowImageInEditorArea = true;
            this.rComboBoxSendingToBankName.Size = new System.Drawing.Size(239, 22);
            this.rComboBoxSendingToBankName.TabIndex = 12;
            this.rComboBoxSendingToBankName.ValidatingProperty = null;
            this.rComboBoxSendingToBankName.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rComboBoxSendingToBankName.Visible = false;
            // 
            // frmChequeDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(806, 158);
            this.Controls.Add(this.rLabel9);
            this.Controls.Add(this.rLabel8);
            this.Controls.Add(this.rComboBoxSendingToBankName);
            this.Controls.Add(this.rDatePicker2);
            this.Controls.Add(this.rLabel7);
            this.Controls.Add(this.rComboBoxRecipientColleague);
            this.Controls.Add(this.rComboBoxStatus);
            this.Controls.Add(this.rTextBox4);
            this.Controls.Add(this.rTextBox3);
            this.Controls.Add(this.rTextBox2);
            this.Controls.Add(this.rLabel6);
            this.Controls.Add(this.rTextBox1);
            this.Controls.Add(this.rLabel4);
            this.Controls.Add(this.rDatePicker1);
            this.Controls.Add(this.rLabel3);
            this.Controls.Add(this.rLabel5);
            this.Controls.Add(this.rLabel2);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmChequeDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات چک";
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rComboBoxStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rComboBoxRecipientColleague)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel9)).EndInit();
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
        private rComponents.rLabel rLabel4;
        private rComponents.rTextBox rTextBox1;
        private rComponents.rTextBox rTextBox2;
        private rComponents.rTextBox rTextBox3;
        private rComponents.rLabel rLabel5;
        private rComponents.rComboBox rComboBoxStatus;
        private rLabel rLabel6;
        private rTextBox rTextBox4;
        private rDatePicker rDatePicker2;
        private rLabel rLabel7;
        private rLabel rLabel8;
        private rComboBox rComboBoxRecipientColleague;
        private rLabel rLabel9;
        private rComboBox rComboBoxSendingToBankName;
    }
}