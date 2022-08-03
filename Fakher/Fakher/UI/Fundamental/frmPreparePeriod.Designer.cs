namespace Fakher.UI.Fundamental
{
    partial class frmPreparePeriod
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
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rGridComboBoxDepartment = new rComponents.rGridComboBox(this.components);
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.rGridComboBoxPeriod = new rComponents.rGridComboBox(this.components);
            this.rLblMessage = new rComponents.rLabel(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.rLabel3 = new rComponents.rLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxDepartment.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxDepartment.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxPeriod.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxPeriod.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 178);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "تــایــیــد";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(12, 178);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "انصــراف";
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.White;
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radPanel1.ForeColor = System.Drawing.Color.Black;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            // 
            // 
            // 
            this.radPanel1.RootElement.ForeColor = System.Drawing.Color.Black;
            this.radPanel1.Size = new System.Drawing.Size(574, 63);
            this.radPanel1.TabIndex = 7;
            this.radPanel1.Text = "این بخش برای آماده سازی ترم جاری از روی یکی از ترم های پیش است";
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(519, 102);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(47, 17);
            this.rLabel1.TabIndex = 8;
            this.rLabel1.Text = "دپارتمان:";
            // 
            // rGridComboBoxDepartment
            // 
            this.rGridComboBoxDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridComboBoxDepartment.CompareMember = null;
            this.rGridComboBoxDepartment.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridComboBoxDepartment.NestedRadGridView
            // 
            this.rGridComboBoxDepartment.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridComboBoxDepartment.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBoxDepartment.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridComboBoxDepartment.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // rGridComboBoxDepartment.NestedRadGridView
            // 
            this.rGridComboBoxDepartment.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridComboBoxDepartment.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridComboBoxDepartment.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridComboBoxDepartment.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridComboBoxDepartment.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridComboBoxDepartment.EditorControl.MasterTemplate.EnableFiltering = true;
            this.rGridComboBoxDepartment.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridComboBoxDepartment.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBoxDepartment.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBoxDepartment.EditorControl.Name = "NestedRadGridView";
            this.rGridComboBoxDepartment.EditorControl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.rGridComboBoxDepartment.EditorControl.ReadOnly = true;
            this.rGridComboBoxDepartment.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.rGridComboBoxDepartment.EditorControl.RootElement.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.rGridComboBoxDepartment.EditorControl.ShowGroupPanel = false;
            this.rGridComboBoxDepartment.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridComboBoxDepartment.EditorControl.TabIndex = 0;
            this.rGridComboBoxDepartment.FieldName = null;
            this.rGridComboBoxDepartment.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBoxDepartment.Location = new System.Drawing.Point(12, 100);
            this.rGridComboBoxDepartment.MaximumValue = null;
            this.rGridComboBoxDepartment.MinimumValue = null;
            this.rGridComboBoxDepartment.Name = "rGridComboBoxDepartment";
            // 
            // 
            // 
            this.rGridComboBoxDepartment.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridComboBoxDepartment.ShowFilteringRow = true;
            this.rGridComboBoxDepartment.ShowNullButton = false;
            this.rGridComboBoxDepartment.Size = new System.Drawing.Size(501, 19);
            this.rGridComboBoxDepartment.TabIndex = 0;
            this.rGridComboBoxDepartment.TabStop = false;
            this.rGridComboBoxDepartment.ValidatingProperty = null;
            this.rGridComboBoxDepartment.ValidationType = rComponents.ValidationType.None;
            this.rGridComboBoxDepartment.Value = null;
            this.rGridComboBoxDepartment.SelectedIndexChanged += new System.EventHandler(this.rGridComboBoxDepartment_SelectedIndexChanged);
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(519, 125);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(25, 17);
            this.rLabel2.TabIndex = 8;
            this.rLabel2.Text = "ترم:";
            // 
            // rGridComboBoxPeriod
            // 
            this.rGridComboBoxPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridComboBoxPeriod.CompareMember = null;
            this.rGridComboBoxPeriod.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridComboBoxPeriod.NestedRadGridView
            // 
            this.rGridComboBoxPeriod.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridComboBoxPeriod.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBoxPeriod.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridComboBoxPeriod.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // rGridComboBoxPeriod.NestedRadGridView
            // 
            this.rGridComboBoxPeriod.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridComboBoxPeriod.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridComboBoxPeriod.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridComboBoxPeriod.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridComboBoxPeriod.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridComboBoxPeriod.EditorControl.MasterTemplate.EnableFiltering = true;
            this.rGridComboBoxPeriod.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridComboBoxPeriod.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBoxPeriod.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBoxPeriod.EditorControl.Name = "NestedRadGridView";
            this.rGridComboBoxPeriod.EditorControl.ReadOnly = true;
            this.rGridComboBoxPeriod.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridComboBoxPeriod.EditorControl.ShowGroupPanel = false;
            this.rGridComboBoxPeriod.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridComboBoxPeriod.EditorControl.TabIndex = 0;
            this.rGridComboBoxPeriod.FieldName = null;
            this.rGridComboBoxPeriod.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBoxPeriod.Location = new System.Drawing.Point(12, 125);
            this.rGridComboBoxPeriod.MaximumValue = null;
            this.rGridComboBoxPeriod.MinimumValue = null;
            this.rGridComboBoxPeriod.Name = "rGridComboBoxPeriod";
            // 
            // 
            // 
            this.rGridComboBoxPeriod.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridComboBoxPeriod.ShowFilteringRow = true;
            this.rGridComboBoxPeriod.ShowNullButton = false;
            this.rGridComboBoxPeriod.Size = new System.Drawing.Size(501, 19);
            this.rGridComboBoxPeriod.TabIndex = 1;
            this.rGridComboBoxPeriod.TabStop = false;
            this.rGridComboBoxPeriod.ValidatingProperty = null;
            this.rGridComboBoxPeriod.ValidationType = rComponents.ValidationType.None;
            this.rGridComboBoxPeriod.Value = null;
            // 
            // rLblMessage
            // 
            this.rLblMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rLblMessage.AutoSize = false;
            this.rLblMessage.BackColor = System.Drawing.Color.Transparent;
            this.rLblMessage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLblMessage.Location = new System.Drawing.Point(284, 156);
            this.rLblMessage.Name = "rLblMessage";
            this.rLblMessage.Size = new System.Drawing.Size(278, 17);
            this.rLblMessage.TabIndex = 9;
            this.rLblMessage.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(284, 179);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(278, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // rLabel3
            // 
            this.rLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel3.BackColor = System.Drawing.Color.Transparent;
            this.rLabel3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLabel3.ForeColor = System.Drawing.Color.Red;
            this.rLabel3.Location = new System.Drawing.Point(90, 71);
            this.rLabel3.Name = "rLabel3";
            // 
            // 
            // 
            this.rLabel3.RootElement.ForeColor = System.Drawing.Color.Red;
            this.rLabel3.Size = new System.Drawing.Size(395, 19);
            this.rLabel3.TabIndex = 11;
            this.rLabel3.Text = "توجه: هر ترم را فقط از روی یک ترم قبل از آن آماده سازی کنید.";
            // 
            // frmPreparePeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 214);
            this.Controls.Add(this.rLabel3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.rLblMessage);
            this.Controls.Add(this.rGridComboBoxPeriod);
            this.Controls.Add(this.rGridComboBoxDepartment);
            this.Controls.Add(this.rLabel2);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPreparePeriod";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "آماده سازی ترم جاری از روی ترم های قبل";
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxDepartment.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxDepartment.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxPeriod.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxPeriod.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private rComponents.rLabel rLabel1;
        private rComponents.rGridComboBox rGridComboBoxDepartment;
        private rComponents.rLabel rLabel2;
        private rComponents.rGridComboBox rGridComboBoxPeriod;
        private rComponents.rLabel rLblMessage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private rComponents.rLabel rLabel3;
    }
}