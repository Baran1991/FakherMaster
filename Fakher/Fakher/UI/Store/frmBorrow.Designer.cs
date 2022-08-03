namespace Fakher.UI.Store
{
    partial class frmBorrow
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
            this.majorSelector1 = new Fakher.Controls.MajorSelector();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.rGridView1 = new rComponents.rGridView();
            this.rGroupBox2 = new rComponents.rGroupBox(this.components);
            this.rGridView2 = new rComponents.rGridView();
            this.departmentSelector1 = new Fakher.Controls.DepartmentSelector();
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rGridCmbGroup = new rComponents.rGridComboBox(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).BeginInit();
            this.rGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbGroup.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbGroup.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // majorSelector1
            // 
            this.majorSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.majorSelector1.BackColor = System.Drawing.Color.Transparent;
            this.majorSelector1.DepartmentSelector = null;
            this.majorSelector1.Location = new System.Drawing.Point(12, 41);
            this.majorSelector1.Name = "majorSelector1";
            this.majorSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.majorSelector1.ShowNullButton = false;
            this.majorSelector1.Size = new System.Drawing.Size(976, 25);
            this.majorSelector1.TabIndex = 1;
            this.majorSelector1.SelectedChanged += new System.EventHandler(this.majorSelector1_SelectedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rGroupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rGroupBox2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 104);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(976, 375);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.rGroupBox1, 2);
            this.rGroupBox1.Controls.Add(this.rGridView1);
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "کتاب ها";
            this.rGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(970, 181);
            this.rGroupBox1.TabIndex = 0;
            this.rGroupBox1.Text = "کتاب ها";
            // 
            // rGridView1
            // 
            this.rGridView1.CanAdd = false;
            this.rGridView1.CanDelete = false;
            this.rGridView1.CanEdit = true;
            this.rGridView1.CanExport = false;
            this.rGridView1.CanFilter = true;
            this.rGridView1.CanGroup = false;
            this.rGridView1.CanNavigate = false;
            this.rGridView1.CheckBoxes = false;
            this.rGridView1.ColumnAutoSize = true;
            this.rGridView1.ConfirmOnDelete = true;
            this.rGridView1.CustomAddText = null;
            this.rGridView1.CustomDeleteText = null;
            this.rGridView1.CustomEditText = "ثبت امانت کتاب";
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
            this.rGridView1.Size = new System.Drawing.Size(966, 159);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Edit += new System.EventHandler(this.rGridView1_Edit_1);
            // 
            // rGroupBox2
            // 
            this.rGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.rGroupBox2, 2);
            this.rGroupBox2.Controls.Add(this.rGridView2);
            this.rGroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox2.FooterImageIndex = -1;
            this.rGroupBox2.FooterImageKey = "";
            this.rGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox2.HeaderImageIndex = -1;
            this.rGroupBox2.HeaderImageKey = "";
            this.rGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox2.HeaderText = "کتاب های امانت گرفته شده";
            this.rGroupBox2.Location = new System.Drawing.Point(3, 190);
            this.rGroupBox2.Name = "rGroupBox2";
            this.rGroupBox2.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox2.Size = new System.Drawing.Size(970, 182);
            this.rGroupBox2.TabIndex = 1;
            this.rGroupBox2.Text = "کتاب های امانت گرفته شده";
            // 
            // rGridView2
            // 
            this.rGridView2.CanAdd = true;
            this.rGridView2.CanDelete = true;
            this.rGridView2.CanEdit = true;
            this.rGridView2.CanExport = true;
            this.rGridView2.CanFilter = true;
            this.rGridView2.CanGroup = false;
            this.rGridView2.CanNavigate = true;
            this.rGridView2.CheckBoxes = false;
            this.rGridView2.ColumnAutoSize = true;
            this.rGridView2.ConfirmOnDelete = false;
            this.rGridView2.CustomAddText = "رسید امانت";
            this.rGridView2.CustomDeleteText = "رسید عودت";
            this.rGridView2.CustomEditText = "ثبت عودت";
            this.rGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView2.EditOnDoubleClick = true;
            this.rGridView2.FieldName = null;
            this.rGridView2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView2.ItemImage = null;
            this.rGridView2.Location = new System.Drawing.Point(2, 20);
            this.rGridView2.MultiSelect = false;
            this.rGridView2.Name = "rGridView2";
            this.rGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView2.RowHeight = 25;
            this.rGridView2.ShowBottomToolbar = false;
            this.rGridView2.ShowGroupPanel = true;
            this.rGridView2.ShowTopToolbar = true;
            this.rGridView2.Size = new System.Drawing.Size(966, 160);
            this.rGridView2.TabIndex = 0;
            this.rGridView2.ValidationType = rComponents.ValidationType.None;
            this.rGridView2.Add += new System.EventHandler(this.rGridView2_Add);
            this.rGridView2.Edit += new System.EventHandler(this.rGridView2_Edit);
            this.rGridView2.Delete += new System.EventHandler(this.rGridView2_Delete);
            // 
            // departmentSelector1
            // 
            this.departmentSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.departmentSelector1.BackColor = System.Drawing.Color.Transparent;
            this.departmentSelector1.Location = new System.Drawing.Point(12, 12);
            this.departmentSelector1.Name = "departmentSelector1";
            this.departmentSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.departmentSelector1.ShowNullButton = false;
            this.departmentSelector1.Size = new System.Drawing.Size(976, 25);
            this.departmentSelector1.TabIndex = 0;
            this.departmentSelector1.SelectedChanged += new System.EventHandler(this.departmentSelector1_SelectedChanged);
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(910, 74);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(65, 17);
            this.rLabel1.TabIndex = 5;
            this.rLabel1.Text = "گــروه کتـاب:";
            // 
            // rGridCmbGroup
            // 
            this.rGridCmbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridCmbGroup.CompareMember = null;
            this.rGridCmbGroup.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridCmbGroup.NestedRadGridView
            // 
            this.rGridCmbGroup.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridCmbGroup.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridCmbGroup.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridCmbGroup.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rGridCmbGroup.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridCmbGroup.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridCmbGroup.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridCmbGroup.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridCmbGroup.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridCmbGroup.EditorControl.MasterTemplate.EnableFiltering = true;
            this.rGridCmbGroup.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridCmbGroup.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridCmbGroup.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridCmbGroup.EditorControl.Name = "NestedRadGridView";
            this.rGridCmbGroup.EditorControl.ReadOnly = true;
            this.rGridCmbGroup.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridCmbGroup.EditorControl.ShowGroupPanel = false;
            this.rGridCmbGroup.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridCmbGroup.EditorControl.TabIndex = 0;
            this.rGridCmbGroup.FieldName = null;
            this.rGridCmbGroup.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridCmbGroup.Location = new System.Drawing.Point(15, 73);
            this.rGridCmbGroup.MaximumValue = null;
            this.rGridCmbGroup.MinimumValue = null;
            this.rGridCmbGroup.Name = "rGridCmbGroup";
            // 
            // 
            // 
            this.rGridCmbGroup.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridCmbGroup.ShowFilteringRow = true;
            this.rGridCmbGroup.ShowNullButton = false;
            this.rGridCmbGroup.Size = new System.Drawing.Size(888, 19);
            this.rGridCmbGroup.TabIndex = 2;
            this.rGridCmbGroup.TabStop = false;
            this.rGridCmbGroup.ValidatingProperty = null;
            this.rGridCmbGroup.ValidationType = rComponents.ValidationType.None;
            this.rGridCmbGroup.Value = null;
            this.rGridCmbGroup.SelectedIndexChanged += new System.EventHandler(this.rGridCmbGroup_SelectedIndexChanged);
            // 
            // frmBorrow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 491);
            this.Controls.Add(this.rGridCmbGroup);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.departmentSelector1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.majorSelector1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmBorrow";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "امـــانـــت";
            this.Load += new System.EventHandler(this.frmBorrow_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).EndInit();
            this.rGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbGroup.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbGroup.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Fakher.Controls.MajorSelector majorSelector1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private rComponents.rGroupBox rGroupBox2;
        private rComponents.rGridView rGridView2;
        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rGridView rGridView1;
        private Fakher.Controls.DepartmentSelector departmentSelector1;
        private rComponents.rLabel rLabel1;
        private rComponents.rGridComboBox rGridCmbGroup;
    }
}