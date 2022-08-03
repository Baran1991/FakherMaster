using rComponents;

namespace Fakher.UI.Financial
{
    partial class frmPayoff
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
            this.rLabel9 = new rComponents.rLabel(this.components);
            this.linkDayNotPaid = new System.Windows.Forms.LinkLabel();
            this.lnkFinancialReport = new System.Windows.Forms.LinkLabel();
            this.rLabel5 = new rComponents.rLabel(this.components);
            this.rGridComboBox1 = new rComponents.rGridComboBox(this.components);
            this.rGroupBox3 = new rComponents.rGroupBox(this.components);
            this.rLblCheque = new rComponents.rLabel(this.components);
            this.rLabel6 = new rComponents.rLabel(this.components);
            this.rLblPayoffAmount = new rComponents.rLabel(this.components);
            this.rLblEPay = new rComponents.rLabel(this.components);
            this.rLabel7 = new rComponents.rLabel(this.components);
            this.rLabel10 = new rComponents.rLabel(this.components);
            this.rLblCash = new rComponents.rLabel(this.components);
            this.rLabel8 = new rComponents.rLabel(this.components);
            this.rGroupBox2 = new rComponents.rGroupBox(this.components);
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.rTextBox1 = new rComponents.rTextBox(this.components);
            this.rBtnPayoff = new Telerik.WinControls.UI.RadButton();
            this.rLblBalance = new rComponents.rLabel(this.components);
            this.rLabel4 = new rComponents.rLabel(this.components);
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.rGridView1 = new rComponents.rGridView();
            this.rDatePicker1 = new rComponents.rDatePicker(this.components);
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.rLabel11 = new rComponents.rLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox3)).BeginInit();
            this.rGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLblCheque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblPayoffAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblEPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblCash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).BeginInit();
            this.rGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnPayoff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rLabel9
            // 
            this.rLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel9.BackColor = System.Drawing.Color.Transparent;
            this.rLabel9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel9.Location = new System.Drawing.Point(384, 84);
            this.rLabel9.Name = "rLabel9";
            this.rLabel9.Size = new System.Drawing.Size(14, 24);
            this.rLabel9.TabIndex = 34;
            this.rLabel9.Text = "|";
            // 
            // linkDayNotPaid
            // 
            this.linkDayNotPaid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkDayNotPaid.AutoSize = true;
            this.linkDayNotPaid.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkDayNotPaid.Location = new System.Drawing.Point(210, 82);
            this.linkDayNotPaid.Name = "linkDayNotPaid";
            this.linkDayNotPaid.Size = new System.Drawing.Size(175, 21);
            this.linkDayNotPaid.TabIndex = 33;
            this.linkDayNotPaid.TabStop = true;
            this.linkDayNotPaid.Text = "تاریخ های تسویه نشده";
            this.linkDayNotPaid.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDayNotPaid_LinkClicked);
            // 
            // lnkFinancialReport
            // 
            this.lnkFinancialReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkFinancialReport.AutoSize = true;
            this.lnkFinancialReport.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkFinancialReport.Location = new System.Drawing.Point(401, 82);
            this.lnkFinancialReport.Name = "lnkFinancialReport";
            this.lnkFinancialReport.Size = new System.Drawing.Size(189, 21);
            this.lnkFinancialReport.TabIndex = 32;
            this.lnkFinancialReport.TabStop = true;
            this.lnkFinancialReport.Text = "گزارش دریافت های مالـی";
            this.lnkFinancialReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFinancialReport_LinkClicked);
            // 
            // rLabel5
            // 
            this.rLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel5.BackColor = System.Drawing.Color.Transparent;
            this.rLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel5.Location = new System.Drawing.Point(593, 82);
            this.rLabel5.Name = "rLabel5";
            this.rLabel5.Size = new System.Drawing.Size(14, 24);
            this.rLabel5.TabIndex = 31;
            this.rLabel5.Text = "|";
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
            this.rGridComboBox1.EditorControl.Location = new System.Drawing.Point(-373, 23);
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
            this.rGridComboBox1.EditorControl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.rGridComboBox1.EditorControl.ReadOnly = true;
            this.rGridComboBox1.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.rGridComboBox1.EditorControl.RootElement.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.rGridComboBox1.EditorControl.ShowGroupPanel = false;
            this.rGridComboBox1.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridComboBox1.EditorControl.TabIndex = 11;
            this.rGridComboBox1.FieldName = null;
            this.rGridComboBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBox1.Location = new System.Drawing.Point(30, 35);
            this.rGridComboBox1.MaximumValue = null;
            this.rGridComboBox1.MinimumValue = null;
            this.rGridComboBox1.Name = "rGridComboBox1";
            // 
            // 
            // 
            this.rGridComboBox1.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridComboBox1.ShowFilteringRow = true;
            this.rGridComboBox1.ShowNullButton = false;
            this.rGridComboBox1.Size = new System.Drawing.Size(846, 25);
            this.rGridComboBox1.TabIndex = 23;
            this.rGridComboBox1.TabStop = false;
            this.rGridComboBox1.ValidatingProperty = null;
            this.rGridComboBox1.ValidationType = rComponents.ValidationType.None;
            this.rGridComboBox1.Value = null;
            // 
            // rGroupBox3
            // 
            this.rGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox3.Controls.Add(this.rLblCheque);
            this.rGroupBox3.Controls.Add(this.rLabel6);
            this.rGroupBox3.Controls.Add(this.rLblPayoffAmount);
            this.rGroupBox3.Controls.Add(this.rLblEPay);
            this.rGroupBox3.Controls.Add(this.rLabel7);
            this.rGroupBox3.Controls.Add(this.rLabel10);
            this.rGroupBox3.Controls.Add(this.rLblCash);
            this.rGroupBox3.Controls.Add(this.rLabel8);
            this.rGroupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox3.FooterImageIndex = -1;
            this.rGroupBox3.FooterImageKey = "";
            this.rGroupBox3.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox3.HeaderImageIndex = -1;
            this.rGroupBox3.HeaderImageKey = "";
            this.rGroupBox3.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox3.HeaderText = "خلاصه وضعیت";
            this.rGroupBox3.Location = new System.Drawing.Point(22, 341);
            this.rGroupBox3.Name = "rGroupBox3";
            this.rGroupBox3.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox3.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox3.Size = new System.Drawing.Size(923, 121);
            this.rGroupBox3.TabIndex = 30;
            this.rGroupBox3.Text = "خلاصه وضعیت";
            // 
            // rLblCheque
            // 
            this.rLblCheque.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLblCheque.AutoSize = false;
            this.rLblCheque.BackColor = System.Drawing.Color.Transparent;
            this.rLblCheque.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLblCheque.Location = new System.Drawing.Point(461, 54);
            this.rLblCheque.Name = "rLblCheque";
            this.rLblCheque.Size = new System.Drawing.Size(277, 17);
            this.rLblCheque.TabIndex = 0;
            // 
            // rLabel6
            // 
            this.rLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel6.BackColor = System.Drawing.Color.Transparent;
            this.rLabel6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel6.Location = new System.Drawing.Point(744, 54);
            this.rLabel6.Name = "rLabel6";
            this.rLabel6.Size = new System.Drawing.Size(81, 24);
            this.rLabel6.TabIndex = 0;
            this.rLabel6.Text = "چـــــــــک:";
            // 
            // rLblPayoffAmount
            // 
            this.rLblPayoffAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLblPayoffAmount.AutoSize = false;
            this.rLblPayoffAmount.BackColor = System.Drawing.Color.Transparent;
            this.rLblPayoffAmount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLblPayoffAmount.Location = new System.Drawing.Point(-14, 54);
            this.rLblPayoffAmount.Name = "rLblPayoffAmount";
            this.rLblPayoffAmount.Size = new System.Drawing.Size(277, 17);
            this.rLblPayoffAmount.TabIndex = 0;
            // 
            // rLblEPay
            // 
            this.rLblEPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLblEPay.AutoSize = false;
            this.rLblEPay.BackColor = System.Drawing.Color.Transparent;
            this.rLblEPay.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLblEPay.Location = new System.Drawing.Point(-14, 29);
            this.rLblEPay.Name = "rLblEPay";
            this.rLblEPay.Size = new System.Drawing.Size(277, 17);
            this.rLblEPay.TabIndex = 0;
            // 
            // rLabel7
            // 
            this.rLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel7.BackColor = System.Drawing.Color.Transparent;
            this.rLabel7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLabel7.Location = new System.Drawing.Point(269, 54);
            this.rLabel7.Name = "rLabel7";
            this.rLabel7.Size = new System.Drawing.Size(148, 24);
            this.rLabel7.TabIndex = 0;
            this.rLabel7.Text = "مبلغ تسویه شده:";
            // 
            // rLabel10
            // 
            this.rLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel10.BackColor = System.Drawing.Color.Transparent;
            this.rLabel10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel10.Location = new System.Drawing.Point(269, 29);
            this.rLabel10.Name = "rLabel10";
            this.rLabel10.Size = new System.Drawing.Size(145, 24);
            this.rLabel10.TabIndex = 0;
            this.rLabel10.Text = "پرداخت الکترونیکی:";
            // 
            // rLblCash
            // 
            this.rLblCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLblCash.AutoSize = false;
            this.rLblCash.BackColor = System.Drawing.Color.Transparent;
            this.rLblCash.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLblCash.Location = new System.Drawing.Point(461, 29);
            this.rLblCash.Name = "rLblCash";
            this.rLblCash.Size = new System.Drawing.Size(277, 17);
            this.rLblCash.TabIndex = 0;
            // 
            // rLabel8
            // 
            this.rLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel8.BackColor = System.Drawing.Color.Transparent;
            this.rLabel8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel8.Location = new System.Drawing.Point(744, 29);
            this.rLabel8.Name = "rLabel8";
            this.rLabel8.Size = new System.Drawing.Size(169, 24);
            this.rLabel8.TabIndex = 0;
            this.rLabel8.Text = "پــــرداخـــت نـــقــــدی:";
            // 
            // rGroupBox2
            // 
            this.rGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox2.Controls.Add(this.radButton1);
            this.rGroupBox2.Controls.Add(this.rTextBox1);
            this.rGroupBox2.Controls.Add(this.rBtnPayoff);
            this.rGroupBox2.Controls.Add(this.rLblBalance);
            this.rGroupBox2.Controls.Add(this.rLabel4);
            this.rGroupBox2.Controls.Add(this.rLabel2);
            this.rGroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox2.FooterImageIndex = -1;
            this.rGroupBox2.FooterImageKey = "";
            this.rGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox2.HeaderImageIndex = -1;
            this.rGroupBox2.HeaderImageKey = "";
            this.rGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox2.HeaderText = "تسویه حساب";
            this.rGroupBox2.Location = new System.Drawing.Point(22, 489);
            this.rGroupBox2.Name = "rGroupBox2";
            this.rGroupBox2.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox2.Size = new System.Drawing.Size(923, 126);
            this.rGroupBox2.TabIndex = 29;
            this.rGroupBox2.Text = "تسویه حساب";
            // 
            // radButton1
            // 
            this.radButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radButton1.Location = new System.Drawing.Point(92, 70);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(171, 26);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "رسید تسویه حساب";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // rTextBox1
            // 
            this.rTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox1.Culture = null;
            this.rTextBox1.FieldName = null;
            this.rTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox1.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox1.Location = new System.Drawing.Point(445, 71);
            this.rTextBox1.Mask = "c0";
            this.rTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.rTextBox1.MaximumValue = null;
            this.rTextBox1.MinimumValue = null;
            this.rTextBox1.Name = "rTextBox1";
            this.rTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox1.Size = new System.Drawing.Size(276, 25);
            this.rTextBox1.TabIndex = 0;
            this.rTextBox1.TabStop = false;
            this.rTextBox1.Type = rComponents.rTextBoxType.Money;
            this.rTextBox1.ValidatingProperty = null;
            this.rTextBox1.ValidationType = rComponents.ValidationType.None;
            // 
            // rBtnPayoff
            // 
            this.rBtnPayoff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtnPayoff.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rBtnPayoff.Location = new System.Drawing.Point(309, 70);
            this.rBtnPayoff.Name = "rBtnPayoff";
            this.rBtnPayoff.Size = new System.Drawing.Size(130, 26);
            this.rBtnPayoff.TabIndex = 1;
            this.rBtnPayoff.Text = "تسویه حساب";
            this.rBtnPayoff.Click += new System.EventHandler(this.rBtnPayoff_Click);
            // 
            // rLblBalance
            // 
            this.rLblBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLblBalance.AutoSize = false;
            this.rLblBalance.BackColor = System.Drawing.Color.Transparent;
            this.rLblBalance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLblBalance.Location = new System.Drawing.Point(445, 49);
            this.rLblBalance.Name = "rLblBalance";
            this.rLblBalance.Size = new System.Drawing.Size(276, 17);
            this.rLblBalance.TabIndex = 0;
            // 
            // rLabel4
            // 
            this.rLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel4.BackColor = System.Drawing.Color.Transparent;
            this.rLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel4.Location = new System.Drawing.Point(728, 49);
            this.rLabel4.Name = "rLabel4";
            this.rLabel4.Size = new System.Drawing.Size(167, 24);
            this.rLabel4.TabIndex = 0;
            this.rLabel4.Text = "مــــــانــــده فـــعــــلی:";
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(727, 72);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(148, 24);
            this.rLabel2.TabIndex = 0;
            this.rLabel2.Text = "مبلغ تسویه حساب:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(612, 82);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(135, 21);
            this.linkLabel1.TabIndex = 27;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "نمایش تراکنش ها";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox1.Controls.Add(this.rGridView1);
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "لیست تراکنش ها";
            this.rGroupBox1.Location = new System.Drawing.Point(22, 116);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(923, 207);
            this.rGroupBox1.TabIndex = 28;
            this.rGroupBox1.Text = "لیست تراکنش ها";
            // 
            // rGridView1
            // 
            this.rGridView1.CanAdd = false;
            this.rGridView1.CanDelete = false;
            this.rGridView1.CanEdit = false;
            this.rGridView1.CanExport = true;
            this.rGridView1.CanFilter = true;
            this.rGridView1.CanGroup = false;
            this.rGridView1.CanNavigate = true;
            this.rGridView1.CheckBoxes = false;
            this.rGridView1.ColumnAutoSize = true;
            this.rGridView1.ConfirmOnDelete = true;
            this.rGridView1.CustomAddText = null;
            this.rGridView1.CustomDeleteText = null;
            this.rGridView1.CustomEditText = null;
            this.rGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView1.EditOnDoubleClick = true;
            this.rGridView1.FieldName = null;
            this.rGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView1.ItemImage = null;
            this.rGridView1.Location = new System.Drawing.Point(2, 20);
            this.rGridView1.MultiSelect = false;
            this.rGridView1.Name = "rGridView1";
            this.rGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView1.RowHeight = 25;
            this.rGridView1.ShowBottomToolbar = false;
            this.rGridView1.ShowGroupPanel = true;
            this.rGridView1.ShowTopToolbar = false;
            this.rGridView1.Size = new System.Drawing.Size(919, 185);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            // 
            // rDatePicker1
            // 
            this.rDatePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePicker1.Culture = null;
            this.rDatePicker1.FieldName = null;
            this.rDatePicker1.Location = new System.Drawing.Point(776, 78);
            this.rDatePicker1.Mask = "1###/##/##";
            this.rDatePicker1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePicker1.Name = "rDatePicker1";
            this.rDatePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePicker1.SelectionStart = 10;
            this.rDatePicker1.Size = new System.Drawing.Size(100, 25);
            this.rDatePicker1.TabIndex = 26;
            this.rDatePicker1.TabStop = false;
            this.rDatePicker1.Text = "1___/__/__";
            this.rDatePicker1.ValidationType = rComponents.ValidationType.None;
            this.rDatePicker1.Value = "";
            // 
            // rLabel3
            // 
            this.rLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel3.BackColor = System.Drawing.Color.Transparent;
            this.rLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel3.Location = new System.Drawing.Point(898, 82);
            this.rLabel3.Name = "rLabel3";
            this.rLabel3.Size = new System.Drawing.Size(47, 24);
            this.rLabel3.TabIndex = 24;
            this.rLabel3.Text = "تاریخ:";
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(882, 36);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(61, 24);
            this.rLabel1.TabIndex = 25;
            this.rLabel1.Text = "پرسنل:";
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel2.Location = new System.Drawing.Point(23, 84);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(170, 21);
            this.linkLabel2.TabIndex = 35;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "جمع دریافت های مالی";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // rLabel11
            // 
            this.rLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel11.BackColor = System.Drawing.Color.Transparent;
            this.rLabel11.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel11.Location = new System.Drawing.Point(192, 86);
            this.rLabel11.Name = "rLabel11";
            this.rLabel11.Size = new System.Drawing.Size(14, 24);
            this.rLabel11.TabIndex = 36;
            this.rLabel11.Text = "|";
            // 
            // frmPayoff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(966, 650);
            this.Controls.Add(this.rLabel11);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.rLabel9);
            this.Controls.Add(this.linkDayNotPaid);
            this.Controls.Add(this.lnkFinancialReport);
            this.Controls.Add(this.rLabel5);
            this.Controls.Add(this.rGridComboBox1);
            this.Controls.Add(this.rGroupBox3);
            this.Controls.Add(this.rGroupBox2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.rGroupBox1);
            this.Controls.Add(this.rDatePicker1);
            this.Controls.Add(this.rLabel3);
            this.Controls.Add(this.rLabel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = true;
            this.Name = "frmPayoff";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "تسویه حساب روزانه";
            ((System.ComponentModel.ISupportInitialize)(this.rLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox3)).EndInit();
            this.rGroupBox3.ResumeLayout(false);
            this.rGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLblCheque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblPayoffAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblEPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblCash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).EndInit();
            this.rGroupBox2.ResumeLayout(false);
            this.rGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnPayoff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rLabel rLabel9;
        private System.Windows.Forms.LinkLabel linkDayNotPaid;
        private System.Windows.Forms.LinkLabel lnkFinancialReport;
        private rLabel rLabel5;
        private rGridComboBox rGridComboBox1;
        private rGroupBox rGroupBox3;
        private rLabel rLblCheque;
        private rLabel rLabel6;
        private rLabel rLblPayoffAmount;
        private rLabel rLblEPay;
        private rLabel rLabel7;
        private rLabel rLabel10;
        private rLabel rLblCash;
        private rLabel rLabel8;
        private rGroupBox rGroupBox2;
        private rTextBox rTextBox1;
        private Telerik.WinControls.UI.RadButton rBtnPayoff;
        private rLabel rLblBalance;
        private rLabel rLabel4;
        private rLabel rLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private rGroupBox rGroupBox1;
        private rGridView rGridView1;
        private rDatePicker rDatePicker1;
        private rLabel rLabel3;
        private rLabel rLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private rLabel rLabel11;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}