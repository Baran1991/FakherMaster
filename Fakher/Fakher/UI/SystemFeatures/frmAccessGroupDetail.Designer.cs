namespace Fakher.UI
{
    partial class frmAccessGroupDetail
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
            this.radTextBox1 = new rComponents.rTextBox(this.components);
            this.radLabel1 = new rComponents.rLabel(this.components);
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.radTreeView1 = new Telerik.WinControls.UI.RadTreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.انتخـــابهـــمــــهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.انــتـــخــــابهـیـچکـدامToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rComboBox1 = new rComponents.rComboBox(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridViewAccessTags = new rComponents.rGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            this.radPageViewPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radTextBox1
            // 
            this.radTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.radTextBox1.Culture = null;
            this.radTextBox1.FieldName = "نام دپارتمان";
            this.radTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radTextBox1.Language = rComponents.TextboxLanguage.Farsi;
            this.radTextBox1.Location = new System.Drawing.Point(286, 10);
            this.radTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.radTextBox1.MaximumValue = null;
            this.radTextBox1.MinimumValue = null;
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radTextBox1.Size = new System.Drawing.Size(169, 19);
            this.radTextBox1.TabIndex = 0;
            this.radTextBox1.TabStop = false;
            this.radTextBox1.Type = rComponents.rTextBoxType.Text;
            this.radTextBox1.ValidatingProperty = null;
            this.radTextBox1.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radLabel1.Location = new System.Drawing.Point(461, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(81, 17);
            this.radLabel1.TabIndex = 5;
            this.radLabel1.Text = "نام گروه کاربری:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 340);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "تــایــیــد";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(12, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "انصــراف";
            // 
            // radTreeView1
            // 
            this.radTreeView1.CheckBoxes = true;
            this.radTreeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.radTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTreeView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radTreeView1.Location = new System.Drawing.Point(0, 0);
            this.radTreeView1.Name = "radTreeView1";
            this.radTreeView1.Size = new System.Drawing.Size(509, 251);
            this.radTreeView1.SpacingBetweenNodes = -1;
            this.radTreeView1.TabIndex = 0;
            this.radTreeView1.Text = "radTreeView1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.انتخـــابهـــمــــهToolStripMenuItem,
            this.انــتـــخــــابهـیـچکـدامToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(184, 48);
            // 
            // انتخـــابهـــمــــهToolStripMenuItem
            // 
            this.انتخـــابهـــمــــهToolStripMenuItem.Name = "انتخـــابهـــمــــهToolStripMenuItem";
            this.انتخـــابهـــمــــهToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.انتخـــابهـــمــــهToolStripMenuItem.Text = "انـتـخــــاب هــــمـــــه";
            this.انتخـــابهـــمــــهToolStripMenuItem.Click += new System.EventHandler(this.انتخـــابهـــمــــهToolStripMenuItem_Click);
            // 
            // انــتـــخــــابهـیـچکـدامToolStripMenuItem
            // 
            this.انــتـــخــــابهـیـچکـدامToolStripMenuItem.Name = "انــتـــخــــابهـیـچکـدامToolStripMenuItem";
            this.انــتـــخــــابهـیـچکـدامToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.انــتـــخــــابهـیـچکـدامToolStripMenuItem.Text = "انــتـــخــــاب هـیـچکـدام";
            this.انــتـــخــــابهـیـچکـدامToolStripMenuItem.Click += new System.EventHandler(this.انــتـــخــــابهـیـچکـدامToolStripMenuItem_Click);
            // 
            // rComboBox1
            // 
            this.rComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rComboBox1.DropDownAnimationEnabled = true;
            this.rComboBox1.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rComboBox1.FieldName = null;
            this.rComboBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rComboBox1.Location = new System.Drawing.Point(12, 11);
            this.rComboBox1.MaximumValue = null;
            this.rComboBox1.MinimumValue = null;
            this.rComboBox1.Name = "rComboBox1";
            this.rComboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rComboBox1.ShowImageInEditorArea = true;
            this.rComboBox1.Size = new System.Drawing.Size(169, 19);
            this.rComboBox1.TabIndex = 1;
            this.rComboBox1.ValidatingProperty = null;
            this.rComboBox1.ValidationType = rComponents.ValidationType.None;
            this.rComboBox1.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.rComboBox1_SelectedIndexChanged);
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(187, 12);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(76, 17);
            this.rLabel1.TabIndex = 5;
            this.rLabel1.Text = "نوع دسترسی:";
            // 
            // radPageView1
            // 
            this.radPageView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Controls.Add(this.radPageViewPage2);
            this.radPageView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radPageView1.Location = new System.Drawing.Point(12, 36);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage1;
            this.radPageView1.Size = new System.Drawing.Size(530, 298);
            this.radPageView1.TabIndex = 6;
            this.radPageView1.Text = "radPageView1";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.radTreeView1);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(509, 251);
            this.radPageViewPage1.Text = "سطح دسترسی های مجاز";
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.rGridViewAccessTags);
            this.radPageViewPage2.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(509, 251);
            this.radPageViewPage2.Text = "مجــوزهـا";
            // 
            // rGridViewAccessTags
            // 
            this.rGridViewAccessTags.CanAdd = true;
            this.rGridViewAccessTags.CanDelete = true;
            this.rGridViewAccessTags.CanEdit = true;
            this.rGridViewAccessTags.CanExport = true;
            this.rGridViewAccessTags.CanFilter = true;
            this.rGridViewAccessTags.CanGroup = false;
            this.rGridViewAccessTags.CanNavigate = true;
            this.rGridViewAccessTags.CheckBoxes = false;
            this.rGridViewAccessTags.ColumnAutoSize = true;
            this.rGridViewAccessTags.ConfirmOnDelete = true;
            this.rGridViewAccessTags.CustomAddText = null;
            this.rGridViewAccessTags.CustomDeleteText = null;
            this.rGridViewAccessTags.CustomEditText = null;
            this.rGridViewAccessTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewAccessTags.EditOnDoubleClick = true;
            this.rGridViewAccessTags.FieldName = null;
            this.rGridViewAccessTags.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewAccessTags.ItemImage = null;
            this.rGridViewAccessTags.Location = new System.Drawing.Point(0, 0);
            this.rGridViewAccessTags.MultiSelect = false;
            this.rGridViewAccessTags.Name = "rGridViewAccessTags";
            this.rGridViewAccessTags.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewAccessTags.RowHeight = 25;
            this.rGridViewAccessTags.ShowBottomToolbar = false;
            this.rGridViewAccessTags.ShowGroupPanel = true;
            this.rGridViewAccessTags.ShowTopToolbar = true;
            this.rGridViewAccessTags.Size = new System.Drawing.Size(509, 251);
            this.rGridViewAccessTags.TabIndex = 0;
            this.rGridViewAccessTags.ValidationType = rComponents.ValidationType.None;
            this.rGridViewAccessTags.Delete += new System.EventHandler(this.rGridViewAccessTags_Delete);
            this.rGridViewAccessTags.Edit += new System.EventHandler(this.rGridViewAccessTags_Edit);
            this.rGridViewAccessTags.Add += new System.EventHandler(this.rGridViewAccessTags_Add);
            // 
            // frmAccessGroupDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 376);
            this.Controls.Add(this.radPageView1);
            this.Controls.Add(this.rComboBox1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btnCancel);
            this.Name = "frmAccessGroupDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات گروه کاربری";
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rTextBox radTextBox1;
        private rComponents.rLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadTreeView radTreeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem انتخـــابهـــمــــهToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem انــتـــخــــابهـیـچکـدامToolStripMenuItem;
        private rComponents.rComboBox rComboBox1;
        private rComponents.rLabel rLabel1;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private rComponents.rGridView rGridViewAccessTags;
    }
}