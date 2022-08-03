namespace Fakher.UI.Website
{
    partial class frmMenuItemList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuItemList));
            this.radTreeView1 = new Telerik.WinControls.UI.RadTreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnAddSubMenu = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnDelete = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radTreeView1
            // 
            this.radTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radTreeView1.Location = new System.Drawing.Point(0, 28);
            this.radTreeView1.Name = "radTreeView1";
            this.radTreeView1.ShowLines = true;
            this.radTreeView1.Size = new System.Drawing.Size(677, 383);
            this.radTreeView1.SpacingBetweenNodes = -1;
            this.radTreeView1.TabIndex = 0;
            this.radTreeView1.Text = "radTreeView1";
            this.radTreeView1.DoubleClick += new System.EventHandler(this.radTreeView1_DoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnAdd,
            this.toolStripBtnAddSubMenu,
            this.toolStripBtnEdit,
            this.toolStripBtnDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(677, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnAdd
            // 
            this.toolStripBtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnAdd.Image")));
            this.toolStripBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAdd.Name = "toolStripBtnAdd";
            this.toolStripBtnAdd.Size = new System.Drawing.Size(94, 22);
            this.toolStripBtnAdd.Text = "مــنــــو جـدیــد";
            this.toolStripBtnAdd.Click += new System.EventHandler(this.toolStripBtnAdd_Click);
            // 
            // toolStripBtnAddSubMenu
            // 
            this.toolStripBtnAddSubMenu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnAddSubMenu.Image")));
            this.toolStripBtnAddSubMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAddSubMenu.Name = "toolStripBtnAddSubMenu";
            this.toolStripBtnAddSubMenu.Size = new System.Drawing.Size(112, 22);
            this.toolStripBtnAddSubMenu.Text = "زیــرمنــــو جــدیـــد";
            this.toolStripBtnAddSubMenu.Click += new System.EventHandler(this.toolStripBtnAddSubMenu_Click);
            // 
            // toolStripBtnEdit
            // 
            this.toolStripBtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnEdit.Image")));
            this.toolStripBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnEdit.Name = "toolStripBtnEdit";
            this.toolStripBtnEdit.Size = new System.Drawing.Size(72, 22);
            this.toolStripBtnEdit.Text = "ویــرایــش";
            this.toolStripBtnEdit.Click += new System.EventHandler(this.toolStripBtnEdit_Click);
            // 
            // toolStripBtnDelete
            // 
            this.toolStripBtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnDelete.Image")));
            this.toolStripBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnDelete.Name = "toolStripBtnDelete";
            this.toolStripBtnDelete.Size = new System.Drawing.Size(59, 22);
            this.toolStripBtnDelete.Text = "حـــذف";
            this.toolStripBtnDelete.Click += new System.EventHandler(this.toolStripBtnDelete_Click);
            // 
            // frmMenuItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 413);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.radTreeView1);
            this.Name = "frmMenuItemList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "منـــــــــوها";
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTreeView radTreeView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnAdd;
        private System.Windows.Forms.ToolStripButton toolStripBtnAddSubMenu;
        private System.Windows.Forms.ToolStripButton toolStripBtnEdit;
        private System.Windows.Forms.ToolStripButton toolStripBtnDelete;
    }
}