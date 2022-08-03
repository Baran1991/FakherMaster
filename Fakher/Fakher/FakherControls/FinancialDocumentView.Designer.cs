namespace Fakher.Controls
{
    partial class FinancialDocumentView
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
            this.rGridView5 = new rComponents.rGridView();
            this.SuspendLayout();
            // 
            // rGridView5
            // 
            this.rGridView5.CanAdd = false;
            this.rGridView5.CanDelete = false;
            this.rGridView5.CanEdit = false;
            this.rGridView5.CanExport = true;
            this.rGridView5.CanFilter = true;
            this.rGridView5.CanGroup = false;
            this.rGridView5.CanNavigate = true;
            this.rGridView5.CheckBoxes = false;
            this.rGridView5.ColumnAutoSize = true;
            this.rGridView5.ConfirmOnDelete = true;
            this.rGridView5.CustomAddText = null;
            this.rGridView5.CustomDeleteText = null;
            this.rGridView5.CustomEditText = null;
            this.rGridView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView5.FieldName = null;
            this.rGridView5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView5.ItemImage = null;
            this.rGridView5.Location = new System.Drawing.Point(0, 0);
            this.rGridView5.MultiSelect = false;
            this.rGridView5.Name = "rGridView5";
            this.rGridView5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView5.RowHeight = 25;
            this.rGridView5.ShowBottomToolbar = false;
            this.rGridView5.ShowTopToolbar = true;
            this.rGridView5.Size = new System.Drawing.Size(872, 491);
            this.rGridView5.TabIndex = 1;
            this.rGridView5.ValidationType = rComponents.ValidationType.None;
            this.rGridView5.Delete += new System.EventHandler(this.rGridView5_Delete);
            this.rGridView5.Edit += new System.EventHandler(this.rGridView5_Edit);
            this.rGridView5.Add += new System.EventHandler(this.rGridView5_Add);
            // 
            // FinancialDocumentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rGridView5);
            this.Name = "FinancialDocumentView";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(872, 491);
            this.Load += new System.EventHandler(this.FinancialDocumentView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private rComponents.rGridView rGridView5;
    }
}
