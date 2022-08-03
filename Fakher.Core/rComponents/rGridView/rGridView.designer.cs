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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rGridView));
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.radSplitButtonElement1 = new Telerik.WinControls.UI.RadSplitButtonElement();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.radLabelElement1 = new Telerik.WinControls.UI.RadLabelElement();
            this.btnDelete = new Telerik.WinControls.UI.RadButtonElement();
            this.btnEdit = new Telerik.WinControls.UI.RadButtonElement();
            this.btnAdd = new Telerik.WinControls.UI.RadButtonElement();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radGridView1.Location = new System.Drawing.Point(3, 38);
            // 
            // radGridView1
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.MasterTemplate.AutoGenerateColumns = false;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            // 
            // 
            // 
            this.radGridView1.RootElement.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.radGridView1.Size = new System.Drawing.Size(627, 416);
            this.radGridView1.TabIndex = 0;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.radGridView1_MouseDoubleClick);
            this.radGridView1.DataBindingComplete += new Telerik.WinControls.UI.GridViewBindingCompleteEventHandler(this.radGridView1_DataBindingComplete);
            this.radGridView1.SelectionChanged += new System.EventHandler(this.radGridView1_SelectionChanged);
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.AutoSize = true;
            this.radStatusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radStatusStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radStatusStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radSplitButtonElement1,
            this.radLabelElement1,
            this.btnDelete,
            this.btnEdit,
            this.btnAdd});
            this.radStatusStrip1.LayoutStyle = Telerik.WinControls.UI.RadStatusBarLayoutStyle.Stack;
            this.radStatusStrip1.Location = new System.Drawing.Point(3, 3);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.Size = new System.Drawing.Size(627, 37);
            this.radStatusStrip1.SizingGrip = false;
            this.radStatusStrip1.TabIndex = 8;
            this.radStatusStrip1.Text = "radStatusStrip1";
            this.radStatusStrip1.ThemeName = "Breeze";
            // 
            // radSplitButtonElement1
            // 
            this.radSplitButtonElement1.ArrowButtonMinSize = new System.Drawing.Size(12, 12);
            this.radSplitButtonElement1.DefaultItem = null;
            this.radSplitButtonElement1.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.radSplitButtonElement1.DropDownDirection = Telerik.WinControls.UI.RadDirection.Down;
            this.radSplitButtonElement1.ExpandArrowButton = false;
            this.radSplitButtonElement1.Image = ((System.Drawing.Image)(resources.GetObject("radSplitButtonElement1.Image")));
            this.radSplitButtonElement1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem1});
            this.radSplitButtonElement1.Margin = new System.Windows.Forms.Padding(1);
            this.radSplitButtonElement1.Name = "radSplitButtonElement1";
            this.radSplitButtonElement1.ShowArrow = true;
            this.radStatusStrip1.SetSpring(this.radSplitButtonElement1, false);
            this.radSplitButtonElement1.Text = "radSplitButtonElement1";
            this.radSplitButtonElement1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "ارسال به اکسل";
            this.radMenuItem1.Click += new System.EventHandler(this.radMenuItem1_Click);
            // 
            // radLabelElement1
            // 
            this.radLabelElement1.Margin = new System.Windows.Forms.Padding(1);
            this.radLabelElement1.Name = "radLabelElement1";
            this.radStatusStrip1.SetSpring(this.radLabelElement1, true);
            this.radLabelElement1.Text = "";
            this.radLabelElement1.TextWrap = true;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = false;
            this.btnDelete.Bounds = new System.Drawing.Rectangle(0, 0, 90, 25);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(1);
            this.btnDelete.Name = "btnDelete";
            this.radStatusStrip1.SetSpring(this.btnDelete, false);
            this.btnDelete.Text = "حــذف";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = false;
            this.btnEdit.Bounds = new System.Drawing.Rectangle(0, 0, 90, 25);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(1);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Padding = new System.Windows.Forms.Padding(0);
            this.radStatusStrip1.SetSpring(this.btnEdit, false);
            this.btnEdit.Text = "ویـرایـش";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
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
            // rGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
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
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private Telerik.WinControls.UI.RadLabelElement radLabelElement1;
        private Telerik.WinControls.UI.RadButtonElement btnAdd;
        private Telerik.WinControls.UI.RadButtonElement btnDelete;
        private Telerik.WinControls.UI.RadButtonElement btnEdit;
        private Telerik.WinControls.UI.RadSplitButtonElement radSplitButtonElement1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    }
}
