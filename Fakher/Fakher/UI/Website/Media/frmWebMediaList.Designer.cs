namespace Fakher.UI.Website.Media
{
    partial class frmWebMediaList
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
            this.rGridViewMedia = new rComponents.rGridView();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rGridViewMedia
            // 
            this.rGridViewMedia.CanAdd = true;
            this.rGridViewMedia.CanDelete = true;
            this.rGridViewMedia.CanEdit = true;
            this.rGridViewMedia.CanExport = true;
            this.rGridViewMedia.CanFilter = true;
            this.rGridViewMedia.CanGroup = false;
            this.rGridViewMedia.CanNavigate = true;
            this.rGridViewMedia.CheckBoxes = false;
            this.rGridViewMedia.ColumnAutoSize = true;
            this.rGridViewMedia.ConfirmOnDelete = true;
            this.rGridViewMedia.CustomAddText = null;
            this.rGridViewMedia.CustomDeleteText = null;
            this.rGridViewMedia.CustomEditText = "تغییر فایل";
            this.rGridViewMedia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewMedia.EditOnDoubleClick = true;
            this.rGridViewMedia.FieldName = null;
            this.rGridViewMedia.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewMedia.ItemImage = null;
            this.rGridViewMedia.Location = new System.Drawing.Point(0, 0);
            this.rGridViewMedia.MultiSelect = false;
            this.rGridViewMedia.Name = "rGridViewMedia";
            this.rGridViewMedia.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewMedia.RowHeight = 25;
            this.rGridViewMedia.ShowBottomToolbar = false;
            this.rGridViewMedia.ShowGroupPanel = true;
            this.rGridViewMedia.ShowTopToolbar = true;
            this.rGridViewMedia.Size = new System.Drawing.Size(913, 499);
            this.rGridViewMedia.TabIndex = 1;
            this.rGridViewMedia.ValidationType = rComponents.ValidationType.None;
            this.rGridViewMedia.Delete += new System.EventHandler(this.rGridViewMedia_Delete);
            this.rGridViewMedia.Edit += new System.EventHandler(this.rGridViewMedia_Edit);
            this.rGridViewMedia.Add += new System.EventHandler(this.rGridViewMedia_Add);
            // 
            // frmWebMediaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 499);
            this.Controls.Add(this.rGridViewMedia);
            this.Name = "frmWebMediaList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مــخــــزن رسـانـــــه هــا";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private rComponents.rGridView rGridViewMedia;
    }
}