namespace Fakher.UI.Exam
{
    partial class frmEnterMark
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
            this.rLabel4 = new rComponents.rLabel(this.components);
            this.rGridComboBoxItems = new rComponents.rGridComboBox(this.components);
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.rGridView1 = new rComponents.rGridView();
            this.majorSelector1 = new Fakher.Controls.MajorSelector();
            this.lessonSelector1 = new Fakher.Controls.LessonSelector();
            this.sectionItemSelector1 = new Fakher.Controls.SectionItemSelector();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxItems.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxItems.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rLabel4
            // 
            this.rLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel4.BackColor = System.Drawing.Color.Transparent;
            this.rLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel4.Location = new System.Drawing.Point(865, 106);
            this.rLabel4.Name = "rLabel4";
            this.rLabel4.Size = new System.Drawing.Size(75, 17);
            this.rLabel4.TabIndex = 3;
            this.rLabel4.Text = "آیتم ارزشیابی:";
            // 
            // rGridComboBoxItems
            // 
            this.rGridComboBoxItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridComboBoxItems.CompareMember = null;
            this.rGridComboBoxItems.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridComboBoxItems.NestedRadGridView
            // 
            this.rGridComboBoxItems.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridComboBoxItems.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBoxItems.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridComboBoxItems.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rGridComboBoxItems.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridComboBoxItems.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridComboBoxItems.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridComboBoxItems.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridComboBoxItems.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridComboBoxItems.EditorControl.MasterTemplate.EnableFiltering = true;
            this.rGridComboBoxItems.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridComboBoxItems.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBoxItems.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBoxItems.EditorControl.Name = "NestedRadGridView";
            this.rGridComboBoxItems.EditorControl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.rGridComboBoxItems.EditorControl.ReadOnly = true;
            this.rGridComboBoxItems.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.rGridComboBoxItems.EditorControl.RootElement.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.rGridComboBoxItems.EditorControl.ShowGroupPanel = false;
            this.rGridComboBoxItems.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridComboBoxItems.EditorControl.TabIndex = 0;
            this.rGridComboBoxItems.FieldName = null;
            this.rGridComboBoxItems.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBoxItems.Location = new System.Drawing.Point(15, 106);
            this.rGridComboBoxItems.MaximumValue = null;
            this.rGridComboBoxItems.MinimumValue = null;
            this.rGridComboBoxItems.Name = "rGridComboBoxItems";
            // 
            // 
            // 
            this.rGridComboBoxItems.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridComboBoxItems.ShowFilteringRow = true;
            this.rGridComboBoxItems.ShowNullButton = false;
            this.rGridComboBoxItems.Size = new System.Drawing.Size(843, 19);
            this.rGridComboBoxItems.TabIndex = 3;
            this.rGridComboBoxItems.TabStop = false;
            this.rGridComboBoxItems.ValidatingProperty = null;
            this.rGridComboBoxItems.ValidationType = rComponents.ValidationType.None;
            this.rGridComboBoxItems.Value = null;
            this.rGridComboBoxItems.SelectedIndexChanged += new System.EventHandler(this.rGridComboBoxItems_SelectedIndexChanged);
            // 
            // rGroupBox1
            // 
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
            this.rGroupBox1.HeaderText = "نمرات";
            this.rGroupBox1.Location = new System.Drawing.Point(12, 131);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(931, 355);
            this.rGroupBox1.TabIndex = 4;
            this.rGroupBox1.Text = "نمرات";
            // 
            // rGridView1
            // 
            this.rGridView1.CanAdd = true;
            this.rGridView1.CanDelete = true;
            this.rGridView1.CanEdit = false;
            this.rGridView1.CanExport = true;
            this.rGridView1.CanFilter = false;
            this.rGridView1.CanGroup = false;
            this.rGridView1.CanNavigate = true;
            this.rGridView1.CheckBoxes = false;
            this.rGridView1.ColumnAutoSize = true;
            this.rGridView1.ConfirmOnDelete = true;
            this.rGridView1.CustomAddText = "ستون نمره جدید";
            this.rGridView1.CustomDeleteText = "حذف ستون نمره";
            this.rGridView1.CustomEditText = null;
            this.rGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView1.FieldName = null;
            this.rGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView1.ItemImage = null;
            this.rGridView1.Location = new System.Drawing.Point(2, 20);
            this.rGridView1.MultiSelect = false;
            this.rGridView1.Name = "rGridView1";
            this.rGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView1.RowHeight = 25;
            this.rGridView1.ShowBottomToolbar = false;
            this.rGridView1.ShowTopToolbar = true;
            this.rGridView1.Size = new System.Drawing.Size(927, 333);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Delete += new System.EventHandler(this.rGridView1_Delete);
            this.rGridView1.CellValueChanged += new System.EventHandler<Telerik.WinControls.UI.GridViewCellEventArgs>(this.rGridView1_CellValueChanged);
            this.rGridView1.CellValidating += new System.EventHandler<Telerik.WinControls.UI.CellValidatingEventArgs>(this.rGridView1_CellValidating);
            this.rGridView1.Add += new System.EventHandler(this.rGridView1_Add);
            // 
            // majorSelector1
            // 
            this.majorSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.majorSelector1.BackColor = System.Drawing.Color.Transparent;
            this.majorSelector1.Location = new System.Drawing.Point(12, 12);
            this.majorSelector1.Name = "majorSelector1";
            this.majorSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.majorSelector1.ShowNullButton = false;
            this.majorSelector1.Size = new System.Drawing.Size(931, 25);
            this.majorSelector1.TabIndex = 0;
            // 
            // lessonSelector1
            // 
            this.lessonSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lessonSelector1.BackColor = System.Drawing.Color.Transparent;
            this.lessonSelector1.Location = new System.Drawing.Point(12, 43);
            this.lessonSelector1.MajorSelector = this.majorSelector1;
            this.lessonSelector1.Name = "lessonSelector1";
            this.lessonSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lessonSelector1.ShowNullButton = false;
            this.lessonSelector1.Size = new System.Drawing.Size(931, 24);
            this.lessonSelector1.TabIndex = 1;
            this.lessonSelector1.SelectedChanged += new System.EventHandler(this.lessonSelector1_SelectedChanged);
            // 
            // sectionItemSelector1
            // 
            this.sectionItemSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sectionItemSelector1.BackColor = System.Drawing.Color.Transparent;
            this.sectionItemSelector1.LessonSelector = this.lessonSelector1;
            this.sectionItemSelector1.Location = new System.Drawing.Point(12, 73);
            this.sectionItemSelector1.Name = "sectionItemSelector1";
            this.sectionItemSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sectionItemSelector1.ShowNullButton = false;
            this.sectionItemSelector1.Size = new System.Drawing.Size(931, 24);
            this.sectionItemSelector1.TabIndex = 2;
            this.sectionItemSelector1.SelectedChanged += new System.EventHandler(this.sectionItemSelector1_SelectedChanged);
            // 
            // frmEnterMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 498);
            this.Controls.Add(this.sectionItemSelector1);
            this.Controls.Add(this.lessonSelector1);
            this.Controls.Add(this.majorSelector1);
            this.Controls.Add(this.rGroupBox1);
            this.Controls.Add(this.rGridComboBoxItems);
            this.Controls.Add(this.rLabel4);
            this.Name = "frmEnterMark";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ورود نمره دستی";
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxItems.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxItems.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rLabel rLabel4;
        private rComponents.rGridComboBox rGridComboBoxItems;
        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rGridView rGridView1;
        private Fakher.Controls.MajorSelector majorSelector1;
        private Fakher.Controls.LessonSelector lessonSelector1;
        private Fakher.Controls.SectionItemSelector sectionItemSelector1;
    }
}