namespace Fakher.Controls
{
    partial class PaymentControl
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
            this.radPageView2 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewReceipt = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridViewReceipt = new rComponents.rGridView();
            this.radPageViewEPayments = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridViewEPayments = new rComponents.rGridView();
            this.radPageViewCheque = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridViewCheque = new rComponents.rGridView();
            this.radPageViewCash = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridViewCash = new rComponents.rGridView();
            this.radPageViewDiscount = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridViewDiscount = new rComponents.rGridView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView5 = new rComponents.rGridView();
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.radLabelElement3 = new Telerik.WinControls.UI.RadLabelElement();
            this.radLabelElement2 = new Telerik.WinControls.UI.RadLabelElement();
            this.radLabelElement1 = new Telerik.WinControls.UI.RadLabelElement();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView2)).BeginInit();
            this.radPageView2.SuspendLayout();
            this.radPageViewReceipt.SuspendLayout();
            this.radPageViewEPayments.SuspendLayout();
            this.radPageViewCheque.SuspendLayout();
            this.radPageViewCash.SuspendLayout();
            this.radPageViewDiscount.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView2
            // 
            this.radPageView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPageView2.Controls.Add(this.radPageViewReceipt);
            this.radPageView2.Controls.Add(this.radPageViewEPayments);
            this.radPageView2.Controls.Add(this.radPageViewCheque);
            this.radPageView2.Controls.Add(this.radPageViewCash);
            this.radPageView2.Controls.Add(this.radPageViewDiscount);
            this.radPageView2.Controls.Add(this.radPageViewPage1);
            this.radPageView2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radPageView2.Location = new System.Drawing.Point(0, 0);
            this.radPageView2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radPageView2.Name = "radPageView2";
            this.radPageView2.SelectedPage = this.radPageViewEPayments;
            this.radPageView2.Size = new System.Drawing.Size(1467, 695);
            this.radPageView2.TabIndex = 2;
            this.radPageView2.Text = "radPageView2";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView2.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView2.GetChildAt(0))).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.Fill;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView2.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Bottom;
            // 
            // radPageViewReceipt
            // 
            this.radPageViewReceipt.Controls.Add(this.rGridViewReceipt);
            this.radPageViewReceipt.Location = new System.Drawing.Point(10, 10);
            this.radPageViewReceipt.Name = "radPageViewReceipt";
            this.radPageViewReceipt.Size = new System.Drawing.Size(1446, 641);
            this.radPageViewReceipt.Text = "فــیــش بــانـــکــــی";
            // 
            // rGridViewReceipt
            // 
            this.rGridViewReceipt.CanAdd = true;
            this.rGridViewReceipt.CanDelete = true;
            this.rGridViewReceipt.CanEdit = true;
            this.rGridViewReceipt.CanExport = true;
            this.rGridViewReceipt.CanFilter = true;
            this.rGridViewReceipt.CanGroup = true;
            this.rGridViewReceipt.CanNavigate = true;
            this.rGridViewReceipt.CheckBoxes = false;
            this.rGridViewReceipt.ColumnAutoSize = true;
            this.rGridViewReceipt.ConfirmOnDelete = true;
            this.rGridViewReceipt.CustomAddText = null;
            this.rGridViewReceipt.CustomDeleteText = null;
            this.rGridViewReceipt.CustomEditText = null;
            this.rGridViewReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewReceipt.EditOnDoubleClick = true;
            this.rGridViewReceipt.FieldName = null;
            this.rGridViewReceipt.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewReceipt.ItemImage = null;
            this.rGridViewReceipt.Location = new System.Drawing.Point(0, 0);
            this.rGridViewReceipt.MultiSelect = false;
            this.rGridViewReceipt.Name = "rGridViewReceipt";
            //this.rGridViewReceipt.Paging = false;
            this.rGridViewReceipt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewReceipt.RowHeight = 25;
            this.rGridViewReceipt.ShowBottomToolbar = false;
            this.rGridViewReceipt.ShowGroupPanel = true;
            this.rGridViewReceipt.ShowTopToolbar = true;
            this.rGridViewReceipt.Size = new System.Drawing.Size(1446, 641);
            this.rGridViewReceipt.TabIndex = 0;
            this.rGridViewReceipt.ValidationType = rComponents.ValidationType.None;
            this.rGridViewReceipt.Add += new System.EventHandler(this.rGridViewReceipt_Add);
            this.rGridViewReceipt.Edit += new System.EventHandler(this.rGridViewReceipt_Edit);
            this.rGridViewReceipt.Delete += new System.EventHandler(this.rGridViewReceipt_Delete);
            // 
            // radPageViewEPayments
            // 
            this.radPageViewEPayments.Controls.Add(this.rGridViewEPayments);
            this.radPageViewEPayments.Location = new System.Drawing.Point(10, 10);
            this.radPageViewEPayments.Name = "radPageViewEPayments";
            this.radPageViewEPayments.Size = new System.Drawing.Size(1446, 641);
            this.radPageViewEPayments.Text = "پـرداخت الکترونیـکـی";
            // 
            // rGridViewEPayments
            // 
            this.rGridViewEPayments.CanAdd = true;
            this.rGridViewEPayments.CanDelete = true;
            this.rGridViewEPayments.CanEdit = true;
            this.rGridViewEPayments.CanExport = true;
            this.rGridViewEPayments.CanFilter = true;
            this.rGridViewEPayments.CanGroup = true;
            this.rGridViewEPayments.CanNavigate = true;
            this.rGridViewEPayments.CheckBoxes = false;
            this.rGridViewEPayments.ColumnAutoSize = true;
            this.rGridViewEPayments.ConfirmOnDelete = true;
            this.rGridViewEPayments.CustomAddText = null;
            this.rGridViewEPayments.CustomDeleteText = null;
            this.rGridViewEPayments.CustomEditText = null;
            this.rGridViewEPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewEPayments.EditOnDoubleClick = true;
            this.rGridViewEPayments.FieldName = null;
            this.rGridViewEPayments.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewEPayments.ItemImage = null;
            this.rGridViewEPayments.Location = new System.Drawing.Point(0, 0);
            this.rGridViewEPayments.MultiSelect = false;
            this.rGridViewEPayments.Name = "rGridViewEPayments";
            //this.rGridViewEPayments.Paging = false;
            this.rGridViewEPayments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewEPayments.RowHeight = 25;
            this.rGridViewEPayments.ShowBottomToolbar = false;
            this.rGridViewEPayments.ShowGroupPanel = true;
            this.rGridViewEPayments.ShowTopToolbar = true;
            this.rGridViewEPayments.Size = new System.Drawing.Size(1446, 641);
            this.rGridViewEPayments.TabIndex = 1;
            this.rGridViewEPayments.ValidationType = rComponents.ValidationType.None;
            this.rGridViewEPayments.Add += new System.EventHandler(this.rGridViewEPayments_Add);
            this.rGridViewEPayments.Edit += new System.EventHandler(this.rGridViewEPayments_Edit);
            this.rGridViewEPayments.Delete += new System.EventHandler(this.rGridViewEPayments_Delete);
            // 
            // radPageViewCheque
            // 
            this.radPageViewCheque.Controls.Add(this.rGridViewCheque);
            this.radPageViewCheque.Location = new System.Drawing.Point(10, 10);
            this.radPageViewCheque.Name = "radPageViewCheque";
            this.radPageViewCheque.Size = new System.Drawing.Size(957, 434);
            this.radPageViewCheque.Text = "چـــــک";
            // 
            // rGridViewCheque
            // 
            this.rGridViewCheque.CanAdd = true;
            this.rGridViewCheque.CanDelete = true;
            this.rGridViewCheque.CanEdit = true;
            this.rGridViewCheque.CanExport = true;
            this.rGridViewCheque.CanFilter = true;
            this.rGridViewCheque.CanGroup = true;
            this.rGridViewCheque.CanNavigate = true;
            this.rGridViewCheque.CheckBoxes = false;
            this.rGridViewCheque.ColumnAutoSize = true;
            this.rGridViewCheque.ConfirmOnDelete = true;
            this.rGridViewCheque.CustomAddText = null;
            this.rGridViewCheque.CustomDeleteText = null;
            this.rGridViewCheque.CustomEditText = null;
            this.rGridViewCheque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewCheque.EditOnDoubleClick = true;
            this.rGridViewCheque.FieldName = null;
            this.rGridViewCheque.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewCheque.ItemImage = null;
            this.rGridViewCheque.Location = new System.Drawing.Point(0, 0);
            this.rGridViewCheque.MultiSelect = false;
            this.rGridViewCheque.Name = "rGridViewCheque";
            //this.rGridViewCheque.Paging = false;
            this.rGridViewCheque.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewCheque.RowHeight = 25;
            this.rGridViewCheque.ShowBottomToolbar = false;
            this.rGridViewCheque.ShowGroupPanel = true;
            this.rGridViewCheque.ShowTopToolbar = true;
            this.rGridViewCheque.Size = new System.Drawing.Size(957, 434);
            this.rGridViewCheque.TabIndex = 0;
            this.rGridViewCheque.ValidationType = rComponents.ValidationType.None;
            this.rGridViewCheque.Add += new System.EventHandler(this.rGridViewCheque_Add);
            this.rGridViewCheque.Edit += new System.EventHandler(this.rGridViewCheque_Edit);
            this.rGridViewCheque.Delete += new System.EventHandler(this.rGridViewCheque_Delete);
            // 
            // radPageViewCash
            // 
            this.radPageViewCash.Controls.Add(this.rGridViewCash);
            this.radPageViewCash.Location = new System.Drawing.Point(10, 10);
            this.radPageViewCash.Name = "radPageViewCash";
            this.radPageViewCash.Size = new System.Drawing.Size(957, 434);
            this.radPageViewCash.Text = "وجـــه دســتــی";
            // 
            // rGridViewCash
            // 
            this.rGridViewCash.CanAdd = true;
            this.rGridViewCash.CanDelete = true;
            this.rGridViewCash.CanEdit = true;
            this.rGridViewCash.CanExport = true;
            this.rGridViewCash.CanFilter = true;
            this.rGridViewCash.CanGroup = true;
            this.rGridViewCash.CanNavigate = true;
            this.rGridViewCash.CheckBoxes = false;
            this.rGridViewCash.ColumnAutoSize = true;
            this.rGridViewCash.ConfirmOnDelete = true;
            this.rGridViewCash.CustomAddText = null;
            this.rGridViewCash.CustomDeleteText = null;
            this.rGridViewCash.CustomEditText = null;
            this.rGridViewCash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewCash.EditOnDoubleClick = true;
            this.rGridViewCash.FieldName = null;
            this.rGridViewCash.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewCash.ItemImage = null;
            this.rGridViewCash.Location = new System.Drawing.Point(0, 0);
            this.rGridViewCash.MultiSelect = false;
            this.rGridViewCash.Name = "rGridViewCash";
            //this.rGridViewCash.Paging = false;
            this.rGridViewCash.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewCash.RowHeight = 25;
            this.rGridViewCash.ShowBottomToolbar = false;
            this.rGridViewCash.ShowGroupPanel = true;
            this.rGridViewCash.ShowTopToolbar = true;
            this.rGridViewCash.Size = new System.Drawing.Size(957, 434);
            this.rGridViewCash.TabIndex = 0;
            this.rGridViewCash.ValidationType = rComponents.ValidationType.None;
            this.rGridViewCash.Add += new System.EventHandler(this.rGridViewCash_Add);
            this.rGridViewCash.Edit += new System.EventHandler(this.rGridViewCash_Edit);
            this.rGridViewCash.Delete += new System.EventHandler(this.rGridViewCash_Delete);
            // 
            // radPageViewDiscount
            // 
            this.radPageViewDiscount.Controls.Add(this.rGridViewDiscount);
            this.radPageViewDiscount.Location = new System.Drawing.Point(10, 10);
            this.radPageViewDiscount.Name = "radPageViewDiscount";
            this.radPageViewDiscount.Size = new System.Drawing.Size(957, 434);
            this.radPageViewDiscount.Text = "تــخــفـیــف";
            // 
            // rGridViewDiscount
            // 
            this.rGridViewDiscount.CanAdd = true;
            this.rGridViewDiscount.CanDelete = true;
            this.rGridViewDiscount.CanEdit = true;
            this.rGridViewDiscount.CanExport = true;
            this.rGridViewDiscount.CanFilter = true;
            this.rGridViewDiscount.CanGroup = true;
            this.rGridViewDiscount.CanNavigate = true;
            this.rGridViewDiscount.CheckBoxes = false;
            this.rGridViewDiscount.ColumnAutoSize = true;
            this.rGridViewDiscount.ConfirmOnDelete = true;
            this.rGridViewDiscount.CustomAddText = null;
            this.rGridViewDiscount.CustomDeleteText = null;
            this.rGridViewDiscount.CustomEditText = null;
            this.rGridViewDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewDiscount.EditOnDoubleClick = true;
            this.rGridViewDiscount.FieldName = null;
            this.rGridViewDiscount.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewDiscount.ItemImage = null;
            this.rGridViewDiscount.Location = new System.Drawing.Point(0, 0);
            this.rGridViewDiscount.MultiSelect = false;
            this.rGridViewDiscount.Name = "rGridViewDiscount";
            //this.rGridViewDiscount.Paging = false;
            this.rGridViewDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewDiscount.RowHeight = 25;
            this.rGridViewDiscount.ShowBottomToolbar = false;
            this.rGridViewDiscount.ShowGroupPanel = true;
            this.rGridViewDiscount.ShowTopToolbar = true;
            this.rGridViewDiscount.Size = new System.Drawing.Size(957, 434);
            this.rGridViewDiscount.TabIndex = 0;
            this.rGridViewDiscount.ValidationType = rComponents.ValidationType.None;
            this.rGridViewDiscount.Add += new System.EventHandler(this.rGridViewDiscount_Add);
            this.rGridViewDiscount.Edit += new System.EventHandler(this.rGridViewDiscount_Edit);
            this.rGridViewDiscount.Delete += new System.EventHandler(this.rGridViewDiscount_Delete);
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.rGridView5);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 10);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(957, 405);
            this.radPageViewPage1.Text = "سند حسابداری";
            // 
            // rGridView5
            // 
            this.rGridView5.CanAdd = true;
            this.rGridView5.CanDelete = true;
            this.rGridView5.CanEdit = true;
            this.rGridView5.CanExport = true;
            this.rGridView5.CanFilter = true;
            this.rGridView5.CanGroup = true;
            this.rGridView5.CanNavigate = true;
            this.rGridView5.CheckBoxes = false;
            this.rGridView5.ColumnAutoSize = true;
            this.rGridView5.ConfirmOnDelete = true;
            this.rGridView5.CustomAddText = null;
            this.rGridView5.CustomDeleteText = null;
            this.rGridView5.CustomEditText = null;
            this.rGridView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView5.EditOnDoubleClick = true;
            this.rGridView5.FieldName = null;
            this.rGridView5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView5.ItemImage = null;
            this.rGridView5.Location = new System.Drawing.Point(0, 0);
            this.rGridView5.MultiSelect = false;
            this.rGridView5.Name = "rGridView5";
            //this.rGridView5.Paging = false;
            this.rGridView5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView5.RowHeight = 25;
            this.rGridView5.ShowBottomToolbar = false;
            this.rGridView5.ShowGroupPanel = true;
            this.rGridView5.ShowTopToolbar = true;
            this.rGridView5.Size = new System.Drawing.Size(957, 405);
            this.rGridView5.TabIndex = 0;
            this.rGridView5.ValidationType = rComponents.ValidationType.None;
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.AutoSize = true;
            this.radStatusStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radStatusStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radLabelElement3,
            this.radLabelElement2,
            this.radLabelElement1});
            this.radStatusStrip1.LayoutStyle = Telerik.WinControls.UI.RadStatusBarLayoutStyle.Stack;
            this.radStatusStrip1.Location = new System.Drawing.Point(0, 706);
            this.radStatusStrip1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.Size = new System.Drawing.Size(1467, 34);
            this.radStatusStrip1.SizingGrip = false;
            this.radStatusStrip1.TabIndex = 3;
            this.radStatusStrip1.Text = "radStatusStrip1";
            // 
            // radLabelElement3
            // 
            this.radLabelElement3.AccessibleDescription = "جــمـــع پـــــرداخــــت:";
            this.radLabelElement3.AccessibleName = "جــمـــع پـــــرداخــــت:";
            this.radLabelElement3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabelElement3.ForeColor = System.Drawing.Color.Brown;
            this.radLabelElement3.Margin = new System.Windows.Forms.Padding(1);
            this.radLabelElement3.Name = "radLabelElement3";
            this.radStatusStrip1.SetSpring(this.radLabelElement3, false);
            this.radLabelElement3.Text = "جــمـــع پـــــرداخــــت:";
            this.radLabelElement3.TextWrap = true;
            this.radLabelElement3.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radLabelElement2
            // 
            this.radLabelElement2.Margin = new System.Windows.Forms.Padding(1);
            this.radLabelElement2.Name = "radLabelElement2";
            this.radStatusStrip1.SetSpring(this.radLabelElement2, true);
            this.radLabelElement2.Text = "";
            this.radLabelElement2.TextWrap = true;
            this.radLabelElement2.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radLabelElement1
            // 
            this.radLabelElement1.AccessibleDescription = "جــمـــع تــخــفــیــــف:";
            this.radLabelElement1.AccessibleName = "جــمـــع تــخــفــیــــف:";
            this.radLabelElement1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabelElement1.ForeColor = System.Drawing.Color.Brown;
            this.radLabelElement1.Margin = new System.Windows.Forms.Padding(1);
            this.radLabelElement1.Name = "radLabelElement1";
            this.radStatusStrip1.SetSpring(this.radLabelElement1, false);
            this.radLabelElement1.Text = "جــمـــع تــخــفــیــــف:";
            this.radLabelElement1.TextWrap = true;
            this.radLabelElement1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // PaymentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radStatusStrip1);
            this.Controls.Add(this.radPageView2);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PaymentControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1467, 740);
            this.Load += new System.EventHandler(this.FinancialDocumentControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView2)).EndInit();
            this.radPageView2.ResumeLayout(false);
            this.radPageViewReceipt.ResumeLayout(false);
            this.radPageViewEPayments.ResumeLayout(false);
            this.radPageViewCheque.ResumeLayout(false);
            this.radPageViewCash.ResumeLayout(false);
            this.radPageViewDiscount.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView2;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewDiscount;
        private rComponents.rGridView rGridViewDiscount;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewCash;
        private rComponents.rGridView rGridViewCash;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewCheque;
        private rComponents.rGridView rGridViewCheque;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewEPayments;
        private rComponents.rGridView rGridViewEPayments;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewReceipt;
        private rComponents.rGridView rGridViewReceipt;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private rComponents.rGridView rGridView5;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private Telerik.WinControls.UI.RadLabelElement radLabelElement2;
        private Telerik.WinControls.UI.RadLabelElement radLabelElement1;
        private Telerik.WinControls.UI.RadLabelElement radLabelElement3;
    }
}
