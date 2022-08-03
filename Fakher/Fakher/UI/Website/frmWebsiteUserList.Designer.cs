namespace Fakher.UI.Website
{
    partial class frmWebsiteUserList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWebsiteUserList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnReSend = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnRemove = new System.Windows.Forms.ToolStripButton();
            this.rGridView1 = new rComponents.rGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnReSend,
            this.toolStripBtnRemove});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(816, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnReSend
            // 
            this.toolStripBtnReSend.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnReSend.Image")));
            this.toolStripBtnReSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnReSend.Name = "toolStripBtnReSend";
            this.toolStripBtnReSend.Size = new System.Drawing.Size(159, 22);
            this.toolStripBtnReSend.Text = "ارسال مجدد ایمیل فعالسازی";
            this.toolStripBtnReSend.Click += new System.EventHandler(this.toolStripBtnReSend_Click);
            // 
            // toolStripBtnRemove
            // 
            this.toolStripBtnRemove.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnRemove.Image")));
            this.toolStripBtnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnRemove.Name = "toolStripBtnRemove";
            this.toolStripBtnRemove.Size = new System.Drawing.Size(108, 22);
            this.toolStripBtnRemove.Text = "حـــذف فعالسازی";
            this.toolStripBtnRemove.ToolTipText = "حـــذف فعالسازی";
            this.toolStripBtnRemove.Click += new System.EventHandler(this.toolStripBtnRemove_Click);
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
            this.rGridView1.CustomEditText = null;
            this.rGridView1.EditOnDoubleClick = true;
            this.rGridView1.FieldName = null;
            this.rGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView1.ItemImage = null;
            this.rGridView1.Location = new System.Drawing.Point(0, 28);
            this.rGridView1.MultiSelect = false;
            this.rGridView1.Name = "rGridView1";
            this.rGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView1.RowHeight = 25;
            this.rGridView1.ShowBottomToolbar = false;
            this.rGridView1.ShowGroupPanel = true;
            this.rGridView1.ShowTopToolbar = true;
            this.rGridView1.Size = new System.Drawing.Size(816, 445);
            this.rGridView1.TabIndex = 3;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            // 
            // frmWebsiteUserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 476);
            this.Controls.Add(this.rGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmWebsiteUserList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "کــاربران سایت";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnReSend;
        private System.Windows.Forms.ToolStripButton toolStripBtnRemove;
        private rComponents.rGridView rGridView1;
    }
}