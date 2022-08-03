namespace Fakher.UI.Financial
{
    partial class frmBankTransactionList
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
            this.rGridView1 = new rComponents.rGridView();
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.rDatePicker2 = new rComponents.rDatePicker(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rDatePicker1 = new rComponents.rDatePicker(this.components);
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.rBtnPayoff = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnPayoff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
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
            this.rGridView1.ShowTopToolbar = true;
            this.rGridView1.Size = new System.Drawing.Size(1077, 461);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox1.Controls.Add(this.rGridView1);
            this.rGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "لیست تراکنش ها";
            this.rGroupBox1.Location = new System.Drawing.Point(0, 76);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(1081, 483);
            this.rGroupBox1.TabIndex = 0;
            this.rGroupBox1.Text = "لیست تراکنش ها";
            // 
            // rDatePicker2
            // 
            this.rDatePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePicker2.Culture = null;
            this.rDatePicker2.FieldName = null;
            this.rDatePicker2.Location = new System.Drawing.Point(521, 23);
            this.rDatePicker2.Mask = "1###/##/##";
            this.rDatePicker2.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePicker2.Name = "rDatePicker2";
            this.rDatePicker2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePicker2.SelectionStart = 10; 
            this.rDatePicker2.Size = new System.Drawing.Size(100, 25);
            this.rDatePicker2.TabIndex = 9;
            this.rDatePicker2.TabStop = false;
            this.rDatePicker2.Text = "1___/__/__";
            this.rDatePicker2.ValidationType = rComponents.ValidationType.None;
            this.rDatePicker2.Value = "";
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(627, 25);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(62, 24);
            this.rLabel1.TabIndex = 8;
            this.rLabel1.Text = "تا تاریخ:";
            // 
            // rDatePicker1
            // 
            this.rDatePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePicker1.Culture = null;
            this.rDatePicker1.FieldName = null;
            this.rDatePicker1.Location = new System.Drawing.Point(714, 23);
            this.rDatePicker1.Mask = "1###/##/##";
            this.rDatePicker1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePicker1.Name = "rDatePicker1";
            this.rDatePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePicker1.SelectionStart = 10;
            this.rDatePicker1.Size = new System.Drawing.Size(100, 25);
            this.rDatePicker1.TabIndex = 7;
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
            this.rLabel3.Location = new System.Drawing.Point(820, 25);
            this.rLabel3.Name = "rLabel3";
            this.rLabel3.Size = new System.Drawing.Size(62, 24);
            this.rLabel3.TabIndex = 6;
            this.rLabel3.Text = "از تاریخ:";
            // 
            // rBtnPayoff
            // 
            this.rBtnPayoff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtnPayoff.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rBtnPayoff.Location = new System.Drawing.Point(229, 22);
            this.rBtnPayoff.Name = "rBtnPayoff";
            this.rBtnPayoff.Size = new System.Drawing.Size(260, 26);
            this.rBtnPayoff.TabIndex = 10;
            this.rBtnPayoff.Text = "لیست تراکنش ها";
            this.rBtnPayoff.Click += new System.EventHandler(this.rBtnPayoff_Click);
            // 
            // radButton1
            // 
            this.radButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radButton1.Location = new System.Drawing.Point(43, 22);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(170, 26);
            this.radButton1.TabIndex = 11;
            this.radButton1.Text = "ویرایش تراکنش ";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // frmBankTransactionList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1081, 559);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.rBtnPayoff);
            this.Controls.Add(this.rDatePicker2);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.rDatePicker1);
            this.Controls.Add(this.rLabel3);
            this.Controls.Add(this.rGroupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBankTransactionList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "لیست تراکنش ها";
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnPayoff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rGridView rGridView1;
        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rDatePicker rDatePicker2;
        private rComponents.rLabel rLabel1;
        private rComponents.rDatePicker rDatePicker1;
        private rComponents.rLabel rLabel3;
        private Telerik.WinControls.UI.RadButton rBtnPayoff;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}