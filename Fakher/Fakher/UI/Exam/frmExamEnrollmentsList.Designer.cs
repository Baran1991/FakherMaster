namespace Fakher.UI.Exam
{
    partial class frmExamEnrollmentsList
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
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rGridCmbTrainingPlan = new rComponents.rGridComboBox(this.components);
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.rGridView1 = new rComponents.rGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbTrainingPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbTrainingPlan.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbTrainingPlan.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // majorSelector1
            // 
            this.majorSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.majorSelector1.BackColor = System.Drawing.Color.Transparent;
            this.majorSelector1.DepartmentSelector = null;
            this.majorSelector1.Location = new System.Drawing.Point(13, 13);
            this.majorSelector1.Name = "majorSelector1";
            this.majorSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.majorSelector1.ShowNullButton = false;
            this.majorSelector1.Size = new System.Drawing.Size(814, 25);
            this.majorSelector1.TabIndex = 0;
            this.majorSelector1.SelectedChanged += new System.EventHandler(this.majorSelector1_SelectedChanged);
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(747, 45);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(83, 17);
            this.rLabel1.TabIndex = 1;
            this.rLabel1.Text = "برنامه آمـوزشی:";
            // 
            // rGridCmbTrainingPlan
            // 
            this.rGridCmbTrainingPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridCmbTrainingPlan.CompareMember = null;
            this.rGridCmbTrainingPlan.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridCmbTrainingPlan.NestedRadGridView
            // 
            this.rGridCmbTrainingPlan.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridCmbTrainingPlan.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridCmbTrainingPlan.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridCmbTrainingPlan.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // rGridCmbTrainingPlan.NestedRadGridView
            // 
            this.rGridCmbTrainingPlan.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridCmbTrainingPlan.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridCmbTrainingPlan.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridCmbTrainingPlan.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridCmbTrainingPlan.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridCmbTrainingPlan.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridCmbTrainingPlan.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridCmbTrainingPlan.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridCmbTrainingPlan.EditorControl.Name = "NestedRadGridView";
            this.rGridCmbTrainingPlan.EditorControl.ReadOnly = true;
            this.rGridCmbTrainingPlan.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridCmbTrainingPlan.EditorControl.ShowGroupPanel = false;
            this.rGridCmbTrainingPlan.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridCmbTrainingPlan.EditorControl.TabIndex = 0;
            this.rGridCmbTrainingPlan.FieldName = null;
            this.rGridCmbTrainingPlan.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridCmbTrainingPlan.Location = new System.Drawing.Point(15, 45);
            this.rGridCmbTrainingPlan.MaximumValue = null;
            this.rGridCmbTrainingPlan.MinimumValue = null;
            this.rGridCmbTrainingPlan.Name = "rGridCmbTrainingPlan";
            // 
            // 
            // 
            this.rGridCmbTrainingPlan.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridCmbTrainingPlan.ShowFilteringRow = true;
            this.rGridCmbTrainingPlan.ShowNullButton = false;
            this.rGridCmbTrainingPlan.Size = new System.Drawing.Size(727, 19);
            this.rGridCmbTrainingPlan.TabIndex = 3;
            this.rGridCmbTrainingPlan.TabStop = false;
            this.rGridCmbTrainingPlan.ValidatingProperty = null;
            this.rGridCmbTrainingPlan.ValidationType = rComponents.ValidationType.None;
            this.rGridCmbTrainingPlan.Value = null;
            this.rGridCmbTrainingPlan.SelectedIndexChanged += new System.EventHandler(this.rGridCmbTrainingPlan_SelectedIndexChanged);
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
            this.rGroupBox1.HeaderText = "آزمــــونهـا";
            this.rGroupBox1.Location = new System.Drawing.Point(13, 70);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(814, 332);
            this.rGroupBox1.TabIndex = 5;
            this.rGroupBox1.Text = "آزمــــونهـا";
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
            this.rGridView1.Size = new System.Drawing.Size(810, 310);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            // 
            // frmExamEnrollmentsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 414);
            this.Controls.Add(this.rGroupBox1);
            this.Controls.Add(this.rGridCmbTrainingPlan);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.majorSelector1);
            this.Name = "frmExamEnrollmentsList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "لیست افراد ثبت نام اولیه شده در آزمون";
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbTrainingPlan.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbTrainingPlan.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridCmbTrainingPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Fakher.Controls.MajorSelector majorSelector1;
        private rComponents.rLabel rLabel1;
        private rComponents.rGridComboBox rGridCmbTrainingPlan;
        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rGridView rGridView1;
    }
}