namespace Fakher.UI.Poll
{
    partial class frmPollList
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
            this.rGridView1 = new rComponents.rGridView();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
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
            this.rGridView1.Location = new System.Drawing.Point(0, 0);
            this.rGridView1.MultiSelect = false;
            this.rGridView1.Name = "rGridView1";
            this.rGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView1.RowHeight = 25;
            this.rGridView1.ShowBottomToolbar = false;
            this.rGridView1.ShowGroupPanel = true;
            this.rGridView1.ShowTopToolbar = true;
            this.rGridView1.Size = new System.Drawing.Size(800, 427);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Delete += new System.EventHandler(this.rGridView1_Delete);
            this.rGridView1.Edit += new System.EventHandler(this.rGridView1_Edit);
            this.rGridView1.Add += new System.EventHandler(this.rGridView1_Add);
            // 
            // frmPollList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 427);
            this.Controls.Add(this.rGridView1);
            this.Name = "frmPollList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "لیست نظرسنجی ها";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private rComponents.rGridView rGridView1;
    }
}