namespace Fakher.UI.Exam
{
    partial class frmQuestionnaireExamList
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
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.rGridComboBoxEvalItem = new rComponents.rGridComboBox(this.components);
            this.majorSelector1 = new Fakher.Controls.MajorSelector();
            this.rGridView1 = new rComponents.rGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rGridView2 = new rComponents.rGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxEvalItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxEvalItem.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxEvalItem.EditorControl.MasterTemplate)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(759, 43);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(75, 17);
            this.rLabel2.TabIndex = 9;
            this.rLabel2.Text = "آیتم ارزشیابی:";
            // 
            // rGridComboBoxEvalItem
            // 
            this.rGridComboBoxEvalItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridComboBoxEvalItem.CompareMember = null;
            this.rGridComboBoxEvalItem.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridComboBoxEvalItem.NestedRadGridView
            // 
            this.rGridComboBoxEvalItem.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridComboBoxEvalItem.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBoxEvalItem.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridComboBoxEvalItem.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rGridComboBoxEvalItem.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridComboBoxEvalItem.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridComboBoxEvalItem.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridComboBoxEvalItem.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridComboBoxEvalItem.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridComboBoxEvalItem.EditorControl.MasterTemplate.EnableFiltering = true;
            this.rGridComboBoxEvalItem.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridComboBoxEvalItem.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBoxEvalItem.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBoxEvalItem.EditorControl.Name = "NestedRadGridView";
            this.rGridComboBoxEvalItem.EditorControl.ReadOnly = true;
            this.rGridComboBoxEvalItem.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridComboBoxEvalItem.EditorControl.ShowGroupPanel = false;
            this.rGridComboBoxEvalItem.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridComboBoxEvalItem.EditorControl.TabIndex = 0;
            this.rGridComboBoxEvalItem.FieldName = null;
            this.rGridComboBoxEvalItem.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBoxEvalItem.Location = new System.Drawing.Point(14, 41);
            this.rGridComboBoxEvalItem.MaximumValue = null;
            this.rGridComboBoxEvalItem.MinimumValue = null;
            this.rGridComboBoxEvalItem.Name = "rGridComboBoxEvalItem";
            // 
            // 
            // 
            this.rGridComboBoxEvalItem.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridComboBoxEvalItem.ShowFilteringRow = true;
            this.rGridComboBoxEvalItem.ShowNullButton = false;
            this.rGridComboBoxEvalItem.Size = new System.Drawing.Size(739, 19);
            this.rGridComboBoxEvalItem.TabIndex = 10;
            this.rGridComboBoxEvalItem.TabStop = false;
            this.rGridComboBoxEvalItem.ValidatingProperty = null;
            this.rGridComboBoxEvalItem.ValidationType = rComponents.ValidationType.None;
            this.rGridComboBoxEvalItem.Value = null;
            this.rGridComboBoxEvalItem.SelectedIndexChanged += new System.EventHandler(this.rGridComboBoxEvalItem_SelectedIndexChanged);
            // 
            // majorSelector1
            // 
            this.majorSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.majorSelector1.BackColor = System.Drawing.Color.Transparent;
            this.majorSelector1.DepartmentSelector = null;
            this.majorSelector1.Location = new System.Drawing.Point(12, 12);
            this.majorSelector1.Name = "majorSelector1";
            this.majorSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.majorSelector1.ShowNullButton = false;
            this.majorSelector1.Size = new System.Drawing.Size(826, 25);
            this.majorSelector1.TabIndex = 11;
            this.majorSelector1.SelectedChanged += new System.EventHandler(this.majorSelector1_SelectedChanged);
            // 
            // rGridView1
            // 
            this.rGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.rGridView1.CustomEditText = "";
            this.rGridView1.EditOnDoubleClick = true;
            this.rGridView1.FieldName = null;
            this.rGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView1.ItemImage = null;
            this.rGridView1.Location = new System.Drawing.Point(3, 3);
            this.rGridView1.MultiSelect = false;
            this.rGridView1.Name = "rGridView1";
            this.rGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView1.RowHeight = 25;
            this.rGridView1.ShowBottomToolbar = false;
            this.rGridView1.ShowGroupPanel = true;
            this.rGridView1.ShowTopToolbar = true;
            this.rGridView1.Size = new System.Drawing.Size(820, 174);
            this.rGridView1.TabIndex = 12;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Edit += new System.EventHandler(this.rGridView1_Edit);
            this.rGridView1.SelectedItemChanged += new System.EventHandler(this.rGridView1_SelectedItemChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.rGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rGridView2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 66);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(826, 360);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // rGridView2
            // 
            this.rGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridView2.CanAdd = false;
            this.rGridView2.CanDelete = false;
            this.rGridView2.CanEdit = true;
            this.rGridView2.CanExport = true;
            this.rGridView2.CanFilter = true;
            this.rGridView2.CanGroup = false;
            this.rGridView2.CanNavigate = true;
            this.rGridView2.CheckBoxes = false;
            this.rGridView2.ColumnAutoSize = true;
            this.rGridView2.ConfirmOnDelete = true;
            this.rGridView2.CustomAddText = null;
            this.rGridView2.CustomDeleteText = null;
            this.rGridView2.CustomEditText = null;
            this.rGridView2.EditOnDoubleClick = true;
            this.rGridView2.FieldName = null;
            this.rGridView2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView2.ItemImage = null;
            this.rGridView2.Location = new System.Drawing.Point(3, 183);
            this.rGridView2.MultiSelect = false;
            this.rGridView2.Name = "rGridView2";
            this.rGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView2.RowHeight = 25;
            this.rGridView2.ShowBottomToolbar = false;
            this.rGridView2.ShowGroupPanel = true;
            this.rGridView2.ShowTopToolbar = true;
            this.rGridView2.Size = new System.Drawing.Size(820, 174);
            this.rGridView2.TabIndex = 13;
            this.rGridView2.ValidationType = rComponents.ValidationType.None;
            this.rGridView2.Edit += new System.EventHandler(this.rGridView2_Edit);
            // 
            // frmQuestionnaireExamList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 438);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.majorSelector1);
            this.Controls.Add(this.rGridComboBoxEvalItem);
            this.Controls.Add(this.rLabel2);
            this.Name = "frmQuestionnaireExamList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "لیست آزمون";
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxEvalItem.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxEvalItem.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBoxEvalItem)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rLabel rLabel2;
        private rComponents.rGridComboBox rGridComboBoxEvalItem;
        private Fakher.Controls.MajorSelector majorSelector1;
        private rComponents.rGridView rGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private rComponents.rGridView rGridView2;
    }
}