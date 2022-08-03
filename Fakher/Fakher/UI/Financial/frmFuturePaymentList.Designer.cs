namespace Fakher.UI.Financial
{
    partial class frmFuturePaymentList
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
            this.rGridCmbBankAccounts = new rComponents.rGridComboBox(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rGridView1 = new rComponents.rGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbBankAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbBankAccounts.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbBankAccounts.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
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
            this.rGridCmbBankAccounts.Location = new System.Drawing.Point(12, 11);
            this.rGridCmbBankAccounts.MaximumValue = null;
            this.rGridCmbBankAccounts.MinimumValue = null;
            this.rGridCmbBankAccounts.Name = "rGridCmbBankAccounts";
            // 
            // 
            // 
            this.rGridCmbBankAccounts.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridCmbBankAccounts.ShowFilteringRow = true;
            this.rGridCmbBankAccounts.ShowNullButton = false;
            this.rGridCmbBankAccounts.Size = new System.Drawing.Size(721, 19);
            this.rGridCmbBankAccounts.TabIndex = 0;
            this.rGridCmbBankAccounts.TabStop = false;
            this.rGridCmbBankAccounts.ValidatingProperty = null;
            this.rGridCmbBankAccounts.ValidationType = rComponents.ValidationType.None;
            this.rGridCmbBankAccounts.Value = null;
            this.rGridCmbBankAccounts.SelectedIndexChanged += new System.EventHandler(this.rGridCmbBankAccounts_SelectedIndexChanged);
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(739, 13);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(73, 17);
            this.rLabel1.TabIndex = 1;
            this.rLabel1.Text = "حساب بانکی:";
            // 
            // rGridView1
            // 
            this.rGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridView1.CanAdd = true;
            this.rGridView1.CanDelete = true;
            this.rGridView1.CanEdit = true;
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
            this.rGridView1.EditOnDoubleClick = true;
            this.rGridView1.FieldName = null;
            this.rGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView1.ItemImage = null;
            this.rGridView1.Location = new System.Drawing.Point(12, 36);
            this.rGridView1.MultiSelect = false;
            this.rGridView1.Name = "rGridView1";
            this.rGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView1.RowHeight = 25;
            this.rGridView1.ShowBottomToolbar = false;
            this.rGridView1.ShowGroupPanel = true;
            this.rGridView1.ShowTopToolbar = true;
            this.rGridView1.Size = new System.Drawing.Size(787, 463);
            this.rGridView1.TabIndex = 1;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Add += new System.EventHandler(this.rGridView1_Add);
            this.rGridView1.Edit += new System.EventHandler(this.rGridView1_Edit);
            this.rGridView1.Delete += new System.EventHandler(this.rGridView1_Delete);
            // 
            // frmFuturePaymentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 511);
            this.Controls.Add(this.rGridView1);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.rGridCmbBankAccounts);
            this.Name = "frmFuturePaymentList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "لیست پرداخت های آتیه موسسه";
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbBankAccounts.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbBankAccounts.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbBankAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rGridComboBox rGridCmbBankAccounts;
        private rComponents.rLabel rLabel1;
        private rComponents.rGridView rGridView1;
    }
}