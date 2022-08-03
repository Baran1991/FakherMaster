namespace Fakher.Controls
{
    partial class DepartmentSelector
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
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rGridComboBox1 = new rComponents.rGridComboBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.AutoSize = false;
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(630, 5);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(76, 17);
            this.rLabel1.TabIndex = 7;
            this.rLabel1.Text = "دپـــارتـمــــان:";
            this.rLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // rGridComboBox1
            // 
            this.rGridComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridComboBox1.CompareMember = null;
            this.rGridComboBox1.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // rGridComboBox1.NestedRadGridView
            // 
            this.rGridComboBox1.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rGridComboBox1.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBox1.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rGridComboBox1.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // rGridComboBox1.NestedRadGridView
            // 
            this.rGridComboBox1.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridComboBox1.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rGridComboBox1.EditorControl.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBox1.EditorControl.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rGridComboBox1.EditorControl.Name = "NestedRadGridView";
            this.rGridComboBox1.EditorControl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.rGridComboBox1.EditorControl.ReadOnly = true;
            this.rGridComboBox1.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridComboBox1.EditorControl.ShowGroupPanel = false;
            this.rGridComboBox1.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rGridComboBox1.EditorControl.TabIndex = 0;
            this.rGridComboBox1.FieldName = null;
            this.rGridComboBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridComboBox1.Location = new System.Drawing.Point(3, 3);
            this.rGridComboBox1.MaximumValue = null;
            this.rGridComboBox1.MinimumValue = null;
            this.rGridComboBox1.Name = "rGridComboBox1";
            // 
            // 
            // 
            this.rGridComboBox1.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.rGridComboBox1.ShowFilteringRow = true;
            this.rGridComboBox1.ShowNullButton = false;
            this.rGridComboBox1.Size = new System.Drawing.Size(621, 19);
            this.rGridComboBox1.TabIndex = 8;
            this.rGridComboBox1.TabStop = false;
            this.rGridComboBox1.ValidatingProperty = null;
            this.rGridComboBox1.ValidationType = rComponents.ValidationType.None;
            this.rGridComboBox1.Value = null;
            this.rGridComboBox1.SelectedIndexChanged += new System.EventHandler(this.rGridComboBox1_SelectedIndexChanged);
            // 
            // DepartmentSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.rGridComboBox1);
            this.Controls.Add(this.rLabel1);
            this.Name = "DepartmentSelector";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(709, 25);
            this.Load += new System.EventHandler(this.DepartmentSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridComboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rLabel rLabel1;
        private rComponents.rGridComboBox rGridComboBox1;
    }
}
