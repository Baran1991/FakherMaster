﻿namespace Fakher.UI.Educational.Students
{
    partial class frmRegisterAbsences
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
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.rGridView1 = new rComponents.rGridView();
            this.rGroupBox2 = new rComponents.rGroupBox(this.components);
            this.rGridViewAbsents = new rComponents.rGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).BeginInit();
            this.rGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox1.Controls.Add(this.rGridView1);
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "درس / سطح";
            this.rGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(891, 203);
            this.rGroupBox1.TabIndex = 0;
            this.rGroupBox1.Text = "درس / سطح";
            // 
            // rGridView1
            // 
            this.rGridView1.CanAdd = false;
            this.rGridView1.CanDelete = false;
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
            this.rGridView1.CustomEditText = "";
            this.rGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView1.FieldName = null;
            this.rGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView1.ItemImage = null;
            this.rGridView1.Location = new System.Drawing.Point(2, 20);
            this.rGridView1.MultiSelect = false;
            this.rGridView1.Name = "rGridView1";
            this.rGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView1.RowHeight = 25;
            this.rGridView1.ShowBottomToolbar = false;
            this.rGridView1.ShowTopToolbar = false;
            this.rGridView1.Size = new System.Drawing.Size(887, 181);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.SelectedItemChanged += new System.EventHandler(this.rGridView1_SelectedItemChanged);
            // 
            // rGroupBox2
            // 
            this.rGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox2.Controls.Add(this.rGridViewAbsents);
            this.rGroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox2.FooterImageIndex = -1;
            this.rGroupBox2.FooterImageKey = "";
            this.rGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox2.HeaderImageIndex = -1;
            this.rGroupBox2.HeaderImageKey = "";
            this.rGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox2.HeaderText = "غیبت ها";
            this.rGroupBox2.Location = new System.Drawing.Point(12, 224);
            this.rGroupBox2.Name = "rGroupBox2";
            this.rGroupBox2.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox2.Size = new System.Drawing.Size(891, 203);
            this.rGroupBox2.TabIndex = 0;
            this.rGroupBox2.Text = "غیبت ها";
            // 
            // rGridViewAbsents
            // 
            this.rGridViewAbsents.CanAdd = true;
            this.rGridViewAbsents.CanDelete = true;
            this.rGridViewAbsents.CanEdit = true;
            this.rGridViewAbsents.CanExport = true;
            this.rGridViewAbsents.CanFilter = true;
            this.rGridViewAbsents.CanGroup = false;
            this.rGridViewAbsents.CanNavigate = true;
            this.rGridViewAbsents.CheckBoxes = false;
            this.rGridViewAbsents.ColumnAutoSize = true;
            this.rGridViewAbsents.ConfirmOnDelete = true;
            this.rGridViewAbsents.CustomAddText = "ثبت غیبت";
            this.rGridViewAbsents.CustomDeleteText = null;
            this.rGridViewAbsents.CustomEditText = null;
            this.rGridViewAbsents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewAbsents.FieldName = null;
            this.rGridViewAbsents.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewAbsents.ItemImage = null;
            this.rGridViewAbsents.Location = new System.Drawing.Point(2, 20);
            this.rGridViewAbsents.MultiSelect = false;
            this.rGridViewAbsents.Name = "rGridViewAbsents";
            this.rGridViewAbsents.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewAbsents.RowHeight = 25;
            this.rGridViewAbsents.ShowBottomToolbar = false;
            this.rGridViewAbsents.ShowTopToolbar = true;
            this.rGridViewAbsents.Size = new System.Drawing.Size(887, 181);
            this.rGridViewAbsents.TabIndex = 0;
            this.rGridViewAbsents.ValidationType = rComponents.ValidationType.None;
            this.rGridViewAbsents.Delete += new System.EventHandler(this.rGridViewAbsents_Delete);
            this.rGridViewAbsents.Edit += new System.EventHandler(this.rGridViewAbsents_Edit);
            this.rGridViewAbsents.Add += new System.EventHandler(this.rGridViewAbsents_Add);
            // 
            // frmRegisterAbsences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 439);
            this.Controls.Add(this.rGroupBox2);
            this.Controls.Add(this.rGroupBox1);
            this.Name = "frmRegisterAbsences";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "غیبت دانشجو";
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).EndInit();
            this.rGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rGridView rGridView1;
        private rComponents.rGroupBox rGroupBox2;
        private rComponents.rGridView rGridViewAbsents;
    }
}