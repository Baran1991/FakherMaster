namespace rComponents
{
    partial class rGridComboBox
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
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditorControl.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rGridComboBox
            // 
            // 
            // 
            // 
            this.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.EditorControl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.EditorControl.MasterTemplate.EnableGrouping = false;
            this.EditorControl.Name = "";
            this.EditorControl.ReadOnly = true;
            this.EditorControl.ShowGroupPanel = false;
            this.EditorControl.TabIndex = 0;
            // 
            // 
            // 
            this.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.DataBindingComplete += new Telerik.WinControls.UI.GridViewBindingCompleteEventHandler(this.rGridComboBox_DataBindingComplete);
            this.Initialized += new System.EventHandler(this.rGridComboBox_Initialized);
            ((System.ComponentModel.ISupportInitialize)(this.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
