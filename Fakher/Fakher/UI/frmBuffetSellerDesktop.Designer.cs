namespace Fakher.UI
{
    partial class frmBuffetSellerDesktop
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.rGridViewProducts = new rComponents.rGridView();
            this.rGroupBox2 = new rComponents.rGroupBox(this.components);
            this.rGridViewCart = new rComponents.rGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.گزارشهاToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.گزارشفروشروزانهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).BeginInit();
            this.rGroupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rGroupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rGroupBox2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 55);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(908, 441);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox1.Controls.Add(this.rGridViewProducts);
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "کالاها و محصولات";
            this.rGroupBox1.Location = new System.Drawing.Point(457, 3);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(448, 435);
            this.rGroupBox1.TabIndex = 0;
            this.rGroupBox1.Text = "کالاها و محصولات";
            // 
            // rGridViewProducts
            // 
            this.rGridViewProducts.CanAdd = false;
            this.rGridViewProducts.CanDelete = false;
            this.rGridViewProducts.CanEdit = true;
            this.rGridViewProducts.CanExport = false;
            this.rGridViewProducts.CanFilter = true;
            this.rGridViewProducts.CanGroup = false;
            this.rGridViewProducts.CanNavigate = true;
            this.rGridViewProducts.CheckBoxes = false;
            this.rGridViewProducts.ColumnAutoSize = true;
            this.rGridViewProducts.ConfirmOnDelete = true;
            this.rGridViewProducts.CustomAddText = null;
            this.rGridViewProducts.CustomDeleteText = null;
            this.rGridViewProducts.CustomEditText = "اضافه به سبد";
            this.rGridViewProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewProducts.EditOnDoubleClick = true;
            this.rGridViewProducts.FieldName = null;
            this.rGridViewProducts.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewProducts.ItemImage = null;
            this.rGridViewProducts.Location = new System.Drawing.Point(2, 20);
            this.rGridViewProducts.MultiSelect = false;
            this.rGridViewProducts.Name = "rGridViewProducts";
            this.rGridViewProducts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewProducts.RowHeight = 25;
            this.rGridViewProducts.ShowBottomToolbar = false;
            this.rGridViewProducts.ShowGroupPanel = true;
            this.rGridViewProducts.ShowTopToolbar = true;
            this.rGridViewProducts.Size = new System.Drawing.Size(444, 413);
            this.rGridViewProducts.TabIndex = 0;
            this.rGridViewProducts.ValidationType = rComponents.ValidationType.None;
            this.rGridViewProducts.Edit += new System.EventHandler(this.rGridViewProducts_Edit);
            this.rGridViewProducts.Load += new System.EventHandler(this.rGridViewProducts_Load);
            // 
            // rGroupBox2
            // 
            this.rGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox2.Controls.Add(this.rGridViewCart);
            this.rGroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox2.FooterImageIndex = -1;
            this.rGroupBox2.FooterImageKey = "";
            this.rGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox2.HeaderImageIndex = -1;
            this.rGroupBox2.HeaderImageKey = "";
            this.rGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox2.HeaderText = "سبد خرید";
            this.rGroupBox2.Location = new System.Drawing.Point(3, 3);
            this.rGroupBox2.Name = "rGroupBox2";
            this.rGroupBox2.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox2.Size = new System.Drawing.Size(448, 435);
            this.rGroupBox2.TabIndex = 0;
            this.rGroupBox2.Text = "سبد خرید";
            // 
            // rGridViewCart
            // 
            this.rGridViewCart.CanAdd = true;
            this.rGridViewCart.CanDelete = true;
            this.rGridViewCart.CanEdit = false;
            this.rGridViewCart.CanExport = true;
            this.rGridViewCart.CanFilter = true;
            this.rGridViewCart.CanGroup = false;
            this.rGridViewCart.CanNavigate = true;
            this.rGridViewCart.CheckBoxes = false;
            this.rGridViewCart.ColumnAutoSize = true;
            this.rGridViewCart.ConfirmOnDelete = true;
            this.rGridViewCart.CustomAddText = "ثبت نهایی";
            this.rGridViewCart.CustomDeleteText = null;
            this.rGridViewCart.CustomEditText = null;
            this.rGridViewCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewCart.EditOnDoubleClick = true;
            this.rGridViewCart.FieldName = null;
            this.rGridViewCart.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewCart.ItemImage = null;
            this.rGridViewCart.Location = new System.Drawing.Point(2, 20);
            this.rGridViewCart.MultiSelect = false;
            this.rGridViewCart.Name = "rGridViewCart";
            this.rGridViewCart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewCart.RowHeight = 25;
            this.rGridViewCart.ShowBottomToolbar = false;
            this.rGridViewCart.ShowGroupPanel = true;
            this.rGridViewCart.ShowTopToolbar = true;
            this.rGridViewCart.Size = new System.Drawing.Size(444, 413);
            this.rGridViewCart.TabIndex = 1;
            this.rGridViewCart.ValidationType = rComponents.ValidationType.None;
            this.rGridViewCart.Add += new System.EventHandler(this.rGridViewCart_Add);
            this.rGridViewCart.Delete += new System.EventHandler(this.rGridViewCart_Delete);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Bisque;
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.rLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 52);
            this.panel1.TabIndex = 13;
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(321, 29);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(262, 18);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "label1";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLabel1.Location = new System.Drawing.Point(312, 4);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(280, 22);
            this.rLabel1.TabIndex = 8;
            this.rLabel1.Text = "موسسه آموزش عالی آزاد فاخــــــــــر";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.گزارشهاToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(905, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // گزارشهاToolStripMenuItem
            // 
            this.گزارشهاToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.گزارشفروشروزانهToolStripMenuItem});
            this.گزارشهاToolStripMenuItem.Name = "گزارشهاToolStripMenuItem";
            this.گزارشهاToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.گزارشهاToolStripMenuItem.Text = "گزارش ها";
            // 
            // گزارشفروشروزانهToolStripMenuItem
            // 
            this.گزارشفروشروزانهToolStripMenuItem.Name = "گزارشفروشروزانهToolStripMenuItem";
            this.گزارشفروشروزانهToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.گزارشفروشروزانهToolStripMenuItem.Text = "گزارش فروش امــروز";
            this.گزارشفروشروزانهToolStripMenuItem.Click += new System.EventHandler(this.گزارشفروشروزانهToolStripMenuItem_Click);
            // 
            // frmBuffetSellerDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 496);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmBuffetSellerDesktop";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "میزکار فروشگاه";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).EndInit();
            this.rGroupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rGridView rGridViewProducts;
        private rComponents.rGroupBox rGroupBox2;
        private rComponents.rGridView rGridViewCart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private rComponents.rLabel rLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem گزارشهاToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem گزارشفروشروزانهToolStripMenuItem;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
    }
}