namespace rComponents
{
    partial class rGridView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rGridView));
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.btnTools = new Telerik.WinControls.UI.RadSplitButtonElement();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.tabOffice12Shape1 = new Telerik.WinControls.UI.TabOffice12Shape();
            this.btnLast = new Telerik.WinControls.UI.RadButtonElement();
            this.lblRecord = new Telerik.WinControls.UI.RadLabelElement();
            this.btnFirst = new Telerik.WinControls.UI.RadButtonElement();
            this.radLabelElement1 = new Telerik.WinControls.UI.RadLabelElement();
            this.btnDelete = new Telerik.WinControls.UI.RadButtonElement();
            this.btnEdit = new Telerik.WinControls.UI.RadButtonElement();
            this.btnAdd = new Telerik.WinControls.UI.RadButtonElement();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.انتخابهمهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.انـتـخابمـعـکـوسToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.انـتخابهیچـکـدامToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.AutoSizeRows = true;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radGridView1.GroupExpandAnimationType = Telerik.WinControls.UI.GridExpandAnimationType.Slide;
            this.radGridView1.Location = new System.Drawing.Point(3, 38);
            // 
            // radGridView1
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
            this.radGridView1.MasterTemplate.AllowColumnReorder = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.MasterTemplate.AllowRowResize = false;
            this.radGridView1.MasterTemplate.AutoGenerateColumns = false;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            // 
            // 
            // 
            this.radGridView1.RootElement.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(627, 416);
            this.radGridView1.TabIndex = 0;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.CellValidating += new Telerik.WinControls.UI.CellValidatingEventHandler(this.radGridView1_CellValidating);
            this.radGridView1.SelectionChanged += new System.EventHandler(this.radGridView1_SelectionChanged);
            this.radGridView1.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridView1_CellDoubleClick);
            this.radGridView1.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridView1_CellValueChanged);
            this.radGridView1.DataBindingComplete += new Telerik.WinControls.UI.GridViewBindingCompleteEventHandler(this.radGridView1_DataBindingComplete);
            this.radGridView1.FilterChanged += new Telerik.WinControls.UI.GridViewCollectionChangedEventHandler(this.radGridView1_FilterChanged);
            this.radGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.radGridView1_MouseDoubleClick);
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.AutoSize = true;
            this.radStatusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radStatusStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radStatusStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnTools,
            this.btnLast,
            this.lblRecord,
            this.btnFirst,
            this.radLabelElement1,
            this.btnDelete,
            this.btnEdit,
            this.btnAdd});
            this.radStatusStrip1.LayoutStyle = Telerik.WinControls.UI.RadStatusBarLayoutStyle.Stack;
            this.radStatusStrip1.Location = new System.Drawing.Point(3, 3);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radStatusStrip1.Size = new System.Drawing.Size(627, 37);
            this.radStatusStrip1.SizingGrip = false;
            this.radStatusStrip1.TabIndex = 8;
            this.radStatusStrip1.Text = "radStatusStrip1";
            this.radStatusStrip1.ThemeName = "Breeze";
            // 
            // btnTools
            // 
            this.btnTools.AccessibleDescription = "       ";
            this.btnTools.AccessibleName = "       ";
            this.btnTools.ArrowButtonMinSize = new System.Drawing.Size(12, 12);
            this.btnTools.DefaultItem = null;
            this.btnTools.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.btnTools.DropDownDirection = Telerik.WinControls.UI.RadDirection.Down;
            this.btnTools.ExpandArrowButton = false;
            this.btnTools.Image = ((System.Drawing.Image)(resources.GetObject("btnTools.Image")));
            this.btnTools.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem1});
            this.btnTools.Margin = new System.Windows.Forms.Padding(1);
            this.btnTools.Name = "btnTools";
            this.btnTools.Shape = this.tabOffice12Shape1;
            this.btnTools.ShowArrow = false;
            this.radStatusStrip1.SetSpring(this.btnTools, false);
            this.btnTools.Text = "       ";
            this.btnTools.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTools.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.AccessibleDescription = "ارسال به اکسل";
            this.radMenuItem1.AccessibleName = "ارسال به اکسل";
            this.radMenuItem1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "ارسال به اکسل";
            this.radMenuItem1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.radMenuItem1.Click += new System.EventHandler(this.radMenuItem1_Click);
            // 
            // btnLast
            // 
            this.btnLast.AccessibleDescription = "        ";
            this.btnLast.AccessibleName = "        ";
            this.btnLast.Image = ((System.Drawing.Image)(resources.GetObject("btnLast.Image")));
            this.btnLast.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLast.Margin = new System.Windows.Forms.Padding(1);
            this.btnLast.Name = "btnLast";
            this.btnLast.Shape = this.tabOffice12Shape1;
            this.radStatusStrip1.SetSpring(this.btnLast, false);
            this.btnLast.Text = "        ";
            this.btnLast.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // lblRecord
            // 
            this.lblRecord.AccessibleDescription = "رکورد 0 از 0";
            this.lblRecord.AccessibleName = "رکورد 0 از 0";
            this.lblRecord.Margin = new System.Windows.Forms.Padding(1);
            this.lblRecord.Name = "lblRecord";
            this.radStatusStrip1.SetSpring(this.lblRecord, false);
            this.lblRecord.Text = "رکورد 0 از 0";
            this.lblRecord.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRecord.TextWrap = true;
            this.lblRecord.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // btnFirst
            // 
            this.btnFirst.AccessibleDescription = "        ";
            this.btnFirst.AccessibleName = "        ";
            this.btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.Image")));
            this.btnFirst.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFirst.Margin = new System.Windows.Forms.Padding(1);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Shape = this.tabOffice12Shape1;
            this.radStatusStrip1.SetSpring(this.btnFirst, false);
            this.btnFirst.Text = "        ";
            this.btnFirst.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // radLabelElement1
            // 
            this.radLabelElement1.Margin = new System.Windows.Forms.Padding(1);
            this.radLabelElement1.Name = "radLabelElement1";
            this.radStatusStrip1.SetSpring(this.radLabelElement1, true);
            this.radLabelElement1.Text = "";
            this.radLabelElement1.TextWrap = true;
            this.radLabelElement1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleDescription = "حــذف";
            this.btnDelete.AccessibleName = "حــذف";
            this.btnDelete.AutoSize = false;
            this.btnDelete.Bounds = new System.Drawing.Rectangle(0, 0, 90, 25);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(1);
            this.btnDelete.Name = "btnDelete";
            this.radStatusStrip1.SetSpring(this.btnDelete, false);
            this.btnDelete.Text = "حــذف";
            this.btnDelete.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleDescription = "ویـرایـش";
            this.btnEdit.AccessibleName = "ویـرایـش";
            this.btnEdit.AutoSize = false;
            this.btnEdit.Bounds = new System.Drawing.Rectangle(0, 0, 90, 25);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(1);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Padding = new System.Windows.Forms.Padding(0);
            this.radStatusStrip1.SetSpring(this.btnEdit, false);
            this.btnEdit.Text = "ویـرایـش";
            this.btnEdit.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleDescription = "جــدیـــد";
            this.btnAdd.AccessibleName = "جــدیـــد";
            this.btnAdd.AutoSize = false;
            this.btnAdd.Bounds = new System.Drawing.Rectangle(0, 0, 90, 25);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(0);
            this.radStatusStrip1.SetSpring(this.btnAdd, false);
            this.btnAdd.Text = "جــدیـــد";
            this.btnAdd.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.radGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.radStatusStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(633, 457);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.انتخابهمهToolStripMenuItem,
            this.انـتـخابمـعـکـوسToolStripMenuItem,
            this.انـتخابهیچـکـدامToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(207, 88);
            // 
            // انتخابهمهToolStripMenuItem
            // 
            this.انتخابهمهToolStripMenuItem.Name = "انتخابهمهToolStripMenuItem";
            this.انتخابهمهToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.انتخابهمهToolStripMenuItem.Text = "انـتـخاب هـمــه";
            this.انتخابهمهToolStripMenuItem.Click += new System.EventHandler(this.انتخابهمهToolStripMenuItem_Click);
            // 
            // انـتـخابمـعـکـوسToolStripMenuItem
            // 
            this.انـتـخابمـعـکـوسToolStripMenuItem.Name = "انـتـخابمـعـکـوسToolStripMenuItem";
            this.انـتـخابمـعـکـوسToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.انـتـخابمـعـکـوسToolStripMenuItem.Text = "انـتـخاب مـعـکـوس";
            this.انـتـخابمـعـکـوسToolStripMenuItem.Click += new System.EventHandler(this.انـتـخابمـعـکـوسToolStripMenuItem_Click);
            // 
            // انـتخابهیچـکـدامToolStripMenuItem
            // 
            this.انـتخابهیچـکـدامToolStripMenuItem.Name = "انـتخابهیچـکـدامToolStripMenuItem";
            this.انـتخابهیچـکـدامToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.انـتخابهیچـکـدامToolStripMenuItem.Text = "انـتخاب هیچـکـدام";
            this.انـتخابهیچـکـدامToolStripMenuItem.Click += new System.EventHandler(this.انـتخابهیچـکـدامToolStripMenuItem_Click);
            // 
            // rGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "rGridView";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(633, 457);
            this.Load += new System.EventHandler(this.rGridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private Telerik.WinControls.UI.RadLabelElement radLabelElement1;
        private Telerik.WinControls.UI.RadButtonElement btnAdd;
        private Telerik.WinControls.UI.RadButtonElement btnDelete;
        private Telerik.WinControls.UI.RadButtonElement btnEdit;
        private Telerik.WinControls.UI.RadSplitButtonElement btnTools;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadButtonElement btnLast;
        private Telerik.WinControls.UI.RadButtonElement btnFirst;
        private Telerik.WinControls.UI.RadLabelElement lblRecord;
        private Telerik.WinControls.UI.TabOffice12Shape tabOffice12Shape1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem انتخابهمهToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem انـتـخابمـعـکـوسToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem انـتخابهیچـکـدامToolStripMenuItem;

    }
}
