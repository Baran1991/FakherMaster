namespace Fakher.UI.Financial
{
    partial class frmOutHistoryList
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
            this.rGridViewQuits = new rComponents.rGridView();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rGridViewQuits
            // 
            this.rGridViewQuits.CanAdd = true;
            this.rGridViewQuits.CanDelete = true;
            this.rGridViewQuits.CanEdit = true;
            this.rGridViewQuits.CanExport = true;
            this.rGridViewQuits.CanFilter = true;
            this.rGridViewQuits.CanGroup = false;
            this.rGridViewQuits.CanNavigate = true;
            this.rGridViewQuits.CheckBoxes = false;
            this.rGridViewQuits.ColumnAutoSize = true;
            this.rGridViewQuits.ConfirmOnDelete = true;
            this.rGridViewQuits.CustomAddText = null;
            this.rGridViewQuits.CustomDeleteText = null;
            this.rGridViewQuits.CustomEditText = null;
            this.rGridViewQuits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewQuits.EditOnDoubleClick = true;
            this.rGridViewQuits.FieldName = null;
            this.rGridViewQuits.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewQuits.ItemImage = null;
            this.rGridViewQuits.Location = new System.Drawing.Point(0, 0);
            this.rGridViewQuits.MultiSelect = false;
            this.rGridViewQuits.Name = "rGridViewQuits";
            this.rGridViewQuits.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewQuits.RowHeight = 25;
            this.rGridViewQuits.ShowBottomToolbar = false;
            this.rGridViewQuits.ShowGroupPanel = true;
            this.rGridViewQuits.ShowTopToolbar = true;
            this.rGridViewQuits.Size = new System.Drawing.Size(1271, 683);
            this.rGridViewQuits.TabIndex = 0;
            this.rGridViewQuits.ValidationType = rComponents.ValidationType.None;
            this.rGridViewQuits.Edit += new System.EventHandler(this.rGridViewQuits_Edit);
            this.rGridViewQuits.Delete += new System.EventHandler(this.rGridViewQuits_Delete);
            // 
            // frmOutHistoryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 683);
            this.Controls.Add(this.rGridViewQuits);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmOutHistoryList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "سوابق انصراف";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private rComponents.rGridView rGridViewQuits;
    }
}