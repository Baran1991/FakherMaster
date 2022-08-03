namespace Fakher.UI.Educational
{
    partial class frmPresenceList
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
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rGridComboBoxTeacher = new rComponents.rGridComboBox(this.components);
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.rGridView1 = new rComponents.rGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rGroupBox2 = new rComponents.rGroupBox(this.components);
            this.rGridCmbSectionItem = new rComponents.rGridComboBox(this.components);
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.lessonSelector1 = new Fakher.Controls.LessonSelector();
            this.majorSelector1 = new Fakher.Controls.MajorSelector();
            this.rGroupBox3 = new rComponents.rGroupBox(this.components);
            this.rLabel2 = new rComponents.rLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxTeacher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxTeacher.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxTeacher.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).BeginInit();
            this.rGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbSectionItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbSectionItem.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbSectionItem.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox3)).BeginInit();
            this.rGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(387, 25);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(57, 17);
            this.rLabel1.TabIndex = 2;
            this.rLabel1.Text = "نام مدرس:";
            // 
            // rGridComboBoxTeacher
            // 
            this.rGridComboBoxTeacher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridComboBoxTeacher.CompareMember = null;
            this.rGridComboBoxTeacher.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridComboBoxTeacher.NestedRadGridView
            // 
            this.rGridComboBoxTeacher.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridComboBoxTeacher.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBoxTeacher.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridComboBoxTeacher.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rGridComboBoxTeacher.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridComboBoxTeacher.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridComboBoxTeacher.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridComboBoxTeacher.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridComboBoxTeacher.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridComboBoxTeacher.EditorControl.MasterTemplate.EnableFiltering = true;
            this.rGridComboBoxTeacher.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridComboBoxTeacher.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBoxTeacher.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBoxTeacher.EditorControl.Name = "NestedRadGridView";
            this.rGridComboBoxTeacher.EditorControl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.rGridComboBoxTeacher.EditorControl.ReadOnly = true;
            this.rGridComboBoxTeacher.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.rGridComboBoxTeacher.EditorControl.RootElement.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.rGridComboBoxTeacher.EditorControl.ShowGroupPanel = false;
            this.rGridComboBoxTeacher.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridComboBoxTeacher.EditorControl.TabIndex = 0;
            this.rGridComboBoxTeacher.FieldName = null;
            this.rGridComboBoxTeacher.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBoxTeacher.Location = new System.Drawing.Point(5, 24);
            this.rGridComboBoxTeacher.MaximumValue = null;
            this.rGridComboBoxTeacher.MinimumValue = null;
            this.rGridComboBoxTeacher.Name = "rGridComboBoxTeacher";
            // 
            // 
            // 
            this.rGridComboBoxTeacher.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridComboBoxTeacher.ShowFilteringRow = true;
            this.rGridComboBoxTeacher.ShowNullButton = false;
            this.rGridComboBoxTeacher.Size = new System.Drawing.Size(376, 19);
            this.rGridComboBoxTeacher.TabIndex = 5;
            this.rGridComboBoxTeacher.TabStop = false;
            this.rGridComboBoxTeacher.ValidatingProperty = null;
            this.rGridComboBoxTeacher.ValidationType = rComponents.ValidationType.None;
            this.rGridComboBoxTeacher.Value = null;
            this.rGridComboBoxTeacher.SelectedIndexChanged += new System.EventHandler(this.rGridComboBoxTeacher_SelectedIndexChanged);
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
            this.rGroupBox1.HeaderText = "حضورهای مدرس";
            this.rGroupBox1.Location = new System.Drawing.Point(12, 127);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(887, 323);
            this.rGroupBox1.TabIndex = 8;
            this.rGroupBox1.Text = "حضورهای مدرس";
            // 
            // rGridView1
            // 
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
            this.rGridView1.Size = new System.Drawing.Size(883, 301);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Add += new System.EventHandler(this.rGridView1_Add);
            this.rGridView1.Edit += new System.EventHandler(this.rGridView1_Edit);
            this.rGridView1.Delete += new System.EventHandler(this.rGridView1_Delete);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rGroupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rGroupBox3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(911, 121);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // rGroupBox2
            // 
            this.rGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox2.Controls.Add(this.rGridCmbSectionItem);
            this.rGroupBox2.Controls.Add(this.rLabel3);
            this.rGroupBox2.Controls.Add(this.lessonSelector1);
            this.rGroupBox2.Controls.Add(this.majorSelector1);
            this.rGroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox2.FooterImageIndex = -1;
            this.rGroupBox2.FooterImageKey = "";
            this.rGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox2.HeaderImageIndex = -1;
            this.rGroupBox2.HeaderImageKey = "";
            this.rGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox2.HeaderText = "رشته/درس/گــــروه";
            this.rGroupBox2.Location = new System.Drawing.Point(3, 3);
            this.rGroupBox2.Name = "rGroupBox2";
            this.rGroupBox2.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox2.Size = new System.Drawing.Size(450, 115);
            this.rGroupBox2.TabIndex = 0;
            this.rGroupBox2.Text = "رشته/درس/گــــروه";
            // 
            // rGridCmbSectionItem
            // 
            this.rGridCmbSectionItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridCmbSectionItem.CompareMember = null;
            this.rGridCmbSectionItem.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridCmbSectionItem.NestedRadGridView
            // 
            this.rGridCmbSectionItem.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridCmbSectionItem.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridCmbSectionItem.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridCmbSectionItem.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rGridCmbSectionItem.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridCmbSectionItem.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridCmbSectionItem.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridCmbSectionItem.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridCmbSectionItem.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridCmbSectionItem.EditorControl.MasterTemplate.EnableFiltering = true;
            this.rGridCmbSectionItem.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridCmbSectionItem.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridCmbSectionItem.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridCmbSectionItem.EditorControl.Name = "NestedRadGridView";
            this.rGridCmbSectionItem.EditorControl.ReadOnly = true;
            this.rGridCmbSectionItem.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridCmbSectionItem.EditorControl.ShowGroupPanel = false;
            this.rGridCmbSectionItem.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridCmbSectionItem.EditorControl.TabIndex = 0;
            this.rGridCmbSectionItem.FieldName = null;
            this.rGridCmbSectionItem.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridCmbSectionItem.Location = new System.Drawing.Point(8, 88);
            this.rGridCmbSectionItem.MaximumValue = null;
            this.rGridCmbSectionItem.MinimumValue = null;
            this.rGridCmbSectionItem.Name = "rGridCmbSectionItem";
            // 
            // 
            // 
            this.rGridCmbSectionItem.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridCmbSectionItem.ShowFilteringRow = true;
            this.rGridCmbSectionItem.ShowNullButton = false;
            this.rGridCmbSectionItem.Size = new System.Drawing.Size(352, 19);
            this.rGridCmbSectionItem.TabIndex = 3;
            this.rGridCmbSectionItem.TabStop = false;
            this.rGridCmbSectionItem.ValidatingProperty = null;
            this.rGridCmbSectionItem.ValidationType = rComponents.ValidationType.None;
            this.rGridCmbSectionItem.Value = null;
            this.rGridCmbSectionItem.SelectedIndexChanged += new System.EventHandler(this.rGridCmbSectionItem_SelectedIndexChanged);
            // 
            // rLabel3
            // 
            this.rLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel3.BackColor = System.Drawing.Color.Transparent;
            this.rLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel3.Location = new System.Drawing.Point(367, 89);
            this.rLabel3.Name = "rLabel3";
            this.rLabel3.Size = new System.Drawing.Size(42, 17);
            this.rLabel3.TabIndex = 2;
            this.rLabel3.Text = "گــــروه:";
            // 
            // lessonSelector1
            // 
            this.lessonSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lessonSelector1.BackColor = System.Drawing.Color.Transparent;
            this.lessonSelector1.Location = new System.Drawing.Point(5, 56);
            this.lessonSelector1.MajorSelector = this.majorSelector1;
            this.lessonSelector1.Name = "lessonSelector1";
            this.lessonSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lessonSelector1.ShowAllLessons = false;
            this.lessonSelector1.ShowExamHoldingLessons = false;
            this.lessonSelector1.ShowNullButton = false;
            this.lessonSelector1.Size = new System.Drawing.Size(440, 24);
            this.lessonSelector1.TabIndex = 1;
            this.lessonSelector1.SelectedChanged += new System.EventHandler(this.lessonSelector1_SelectedChanged);
            // 
            // majorSelector1
            // 
            this.majorSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.majorSelector1.BackColor = System.Drawing.Color.Transparent;
            this.majorSelector1.DepartmentSelector = null;
            this.majorSelector1.Location = new System.Drawing.Point(6, 25);
            this.majorSelector1.Name = "majorSelector1";
            this.majorSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.majorSelector1.ShowNullButton = false;
            this.majorSelector1.Size = new System.Drawing.Size(439, 25);
            this.majorSelector1.TabIndex = 0;
            // 
            // rGroupBox3
            // 
            this.rGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox3.Controls.Add(this.rLabel2);
            this.rGroupBox3.Controls.Add(this.rGridComboBoxTeacher);
            this.rGroupBox3.Controls.Add(this.rLabel1);
            this.rGroupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox3.FooterImageIndex = -1;
            this.rGroupBox3.FooterImageKey = "";
            this.rGroupBox3.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox3.HeaderImageIndex = -1;
            this.rGroupBox3.HeaderImageKey = "";
            this.rGroupBox3.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox3.HeaderText = "مـــــــــدرس";
            this.rGroupBox3.Location = new System.Drawing.Point(459, 3);
            this.rGroupBox3.Name = "rGroupBox3";
            this.rGroupBox3.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox3.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox3.Size = new System.Drawing.Size(449, 115);
            this.rGroupBox3.TabIndex = 1;
            this.rGroupBox3.Text = "مـــــــــدرس";
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.AutoSize = false;
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLabel2.ForeColor = System.Drawing.Color.Red;
            this.rLabel2.Location = new System.Drawing.Point(5, 49);
            this.rLabel2.Name = "rLabel2";
            // 
            // 
            // 
            this.rLabel2.RootElement.ForeColor = System.Drawing.Color.Red;
            this.rLabel2.Size = new System.Drawing.Size(439, 61);
            this.rLabel2.TabIndex = 6;
            this.rLabel2.Text = "دقت کنید؛ گروه و سطح و رشته مدرس را به درستی انتخاب کنید. بسیار دقت کنید!";
            this.rLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPresenceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.rGroupBox1);
            this.Name = "frmPresenceList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "لیست ثبت حضور مدرس";
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxTeacher.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxTeacher.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxTeacher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).EndInit();
            this.rGroupBox2.ResumeLayout(false);
            this.rGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbSectionItem.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbSectionItem.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbSectionItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox3)).EndInit();
            this.rGroupBox3.ResumeLayout(false);
            this.rGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private rComponents.rLabel rLabel1;
        private rComponents.rGridComboBox rGridComboBoxTeacher;
        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rGridView rGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private rComponents.rGroupBox rGroupBox2;
        private rComponents.rGroupBox rGroupBox3;
        private Fakher.Controls.LessonSelector lessonSelector1;
        private Fakher.Controls.MajorSelector majorSelector1;
        private rComponents.rLabel rLabel2;
        private rComponents.rGridComboBox rGridCmbSectionItem;
        private rComponents.rLabel rLabel3;
    }
}