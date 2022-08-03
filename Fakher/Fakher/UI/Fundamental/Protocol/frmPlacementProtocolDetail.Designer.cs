namespace Fakher.UI.Struture.Protocol
{
    partial class frmPlacementProtocolDetail
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
            this.radTxtName = new rComponents.rTextBox(this.components);
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTxtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
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
            this.rGroupBox1.HeaderText = "آیتم های تعیین سطح";
            this.rGroupBox1.Location = new System.Drawing.Point(12, 37);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(677, 275);
            this.rGroupBox1.TabIndex = 1;
            this.rGroupBox1.Text = "آیتم های تعیین سطح";
            // 
            // rGridView1
            // 
            this.rGridView1.CanAdd = true;
            this.rGridView1.CanDelete = true;
            this.rGridView1.CanEdit = true;
            this.rGridView1.CanFilter = true;
            this.rGridView1.CanGroup = false;
            this.rGridView1.CheckBoxes = false;
            this.rGridView1.ColumnAutoSize = true;
            this.rGridView1.ConfirmOnDelete = true;
            this.rGridView1.CustomAddText = null;
            this.rGridView1.CustomDeleteText = null;
            this.rGridView1.CustomEditText = null;
            this.rGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView1.FieldName = "آیتم های تعیین سطح";
            this.rGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView1.ItemImage = null;
            this.rGridView1.Location = new System.Drawing.Point(2, 20);
            this.rGridView1.MultiSelect = false;
            this.rGridView1.Name = "rGridView1";
            this.rGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView1.RowHeight = 25;
            this.rGridView1.ShowBottomToolbar = false;
            this.rGridView1.ShowTopToolbar = true;
            this.rGridView1.Size = new System.Drawing.Size(673, 253);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rGridView1.Edit += new System.EventHandler(this.rGridView1_Edit);
            this.rGridView1.Delete += new System.EventHandler(this.rGridView1_Delete);
            this.rGridView1.Add += new System.EventHandler(this.rGridView1_Add);
            // 
            // radTxtName
            // 
            this.radTxtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radTxtName.BackColor = System.Drawing.Color.Transparent;
            this.radTxtName.FieldName = "نام آیین نامه";
            this.radTxtName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radTxtName.Language = rComponents.TextboxLanguage.Farsi;
            this.radTxtName.Location = new System.Drawing.Point(350, 10);
            this.radTxtName.MaximumValue = null;
            this.radTxtName.MinimumValue = null;
            this.radTxtName.Name = "radTxtName";
            this.radTxtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radTxtName.Size = new System.Drawing.Size(265, 21);
            this.radTxtName.TabIndex = 0;
            this.radTxtName.TabStop = false;
            this.radTxtName.Type = rComponents.rTextBoxType.Text;
            this.radTxtName.ValidatingProperty = null;
            this.radTxtName.ValidationType = rComponents.ValidationType.NotEmpty;
            this.radTxtName.Value = "";
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Location = new System.Drawing.Point(621, 12);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(68, 17);
            this.radLabel2.TabIndex = 17;
            this.radLabel2.Text = "نام آیین نامه:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 318);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "تــایــیــد";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(12, 318);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "انصــراف";
            // 
            // frmPlacementProtocolDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 354);
            this.Controls.Add(this.rGroupBox1);
            this.Controls.Add(this.radTxtName);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Name = "frmPlacementProtocolDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصات آیین نامه";
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radTxtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rGridView rGridView1;
        private rComponents.rTextBox radTxtName;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}