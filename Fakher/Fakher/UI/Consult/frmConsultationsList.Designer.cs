﻿namespace Fakher.UI.Consult
{
    partial class frmConsultationsList
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
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView1 = new rComponents.rGridView();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView2 = new rComponents.rGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            this.radPageViewPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView1
            // 
            this.radPageView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Controls.Add(this.radPageViewPage2);
            this.radPageView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radPageView1.Location = new System.Drawing.Point(12, 12);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage2;
            this.radPageView1.Size = new System.Drawing.Size(900, 485);
            this.radPageView1.TabIndex = 1;
            this.radPageView1.Text = "radPageView1";
            this.radPageView1.SelectedPageChanged += new System.EventHandler(this.radPageView1_SelectedPageChanged);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.rGridView1);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(879, 438);
            this.radPageViewPage1.Text = "درخواست های مشــاوره بدون پاسخ";
            // 
            // rGridView1
            // 
            this.rGridView1.CanAdd = false;
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
            this.rGridView1.Size = new System.Drawing.Size(879, 438);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Edit += new System.EventHandler(this.rGridView1_Edit);
            this.rGridView1.Delete += new System.EventHandler(this.rGridView1_Delete);
            this.rGridView1.CustomButtonClick += new System.EventHandler<rComponents.CustomButtonClickEventArgs>(this.rGridView1_CustomButtonClick);
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.rGridView2);
            this.radPageViewPage2.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(879, 438);
            this.radPageViewPage2.Text = "کـــل درخــواســت هـــای مشــاوره";
            // 
            // rGridView2
            // 
            this.rGridView2.CanAdd = false;
            this.rGridView2.CanDelete = true;
            this.rGridView2.CanEdit = true;
            this.rGridView2.CanExport = true;
            this.rGridView2.CanFilter = true;
            this.rGridView2.CanGroup = false;
            this.rGridView2.CanNavigate = true;
            this.rGridView2.CheckBoxes = false;
            this.rGridView2.ColumnAutoSize = true;
            this.rGridView2.ConfirmOnDelete = true;
            this.rGridView2.CustomAddText = null;
            this.rGridView2.CustomDeleteText = null;
            this.rGridView2.CustomEditText = null;
            this.rGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView2.EditOnDoubleClick = true;
            this.rGridView2.FieldName = null;
            this.rGridView2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView2.ItemImage = null;
            this.rGridView2.Location = new System.Drawing.Point(0, 0);
            this.rGridView2.MultiSelect = false;
            this.rGridView2.Name = "rGridView2";
            this.rGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView2.RowHeight = 25;
            this.rGridView2.ShowBottomToolbar = false;
            this.rGridView2.ShowGroupPanel = true;
            this.rGridView2.ShowTopToolbar = true;
            this.rGridView2.Size = new System.Drawing.Size(879, 438);
            this.rGridView2.TabIndex = 1;
            this.rGridView2.ValidationType = rComponents.ValidationType.None;
            this.rGridView2.Edit += new System.EventHandler(this.rGridView2_Edit);
            this.rGridView2.Delete += new System.EventHandler(this.rGridView2_Delete);
            this.rGridView2.CustomButtonClick += new System.EventHandler<rComponents.CustomButtonClickEventArgs>(this.rGridView2_CustomButtonClick);
            // 
            // frmConsultationsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 509);
            this.Controls.Add(this.radPageView1);
            this.Name = "frmConsultationsList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "لیست درخواست های مشـاوره";
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private rComponents.rGridView rGridView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private rComponents.rGridView rGridView2;
    }
}