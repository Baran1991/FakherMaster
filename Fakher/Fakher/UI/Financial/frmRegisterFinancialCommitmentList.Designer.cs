namespace Fakher.UI.Financial
{
    partial class frmRegisterFinancialCommitmentList
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
            this.rGridViewCommitments = new rComponents.rGridView();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rGridViewCommitments
            // 
            this.rGridViewCommitments.CanAdd = true;
            this.rGridViewCommitments.CanDelete = true;
            this.rGridViewCommitments.CanEdit = true;
            this.rGridViewCommitments.CanExport = true;
            this.rGridViewCommitments.CanFilter = true;
            this.rGridViewCommitments.CanGroup = false;
            this.rGridViewCommitments.CanNavigate = true;
            this.rGridViewCommitments.CheckBoxes = false;
            this.rGridViewCommitments.ColumnAutoSize = true;
            this.rGridViewCommitments.ConfirmOnDelete = true;
            this.rGridViewCommitments.CustomAddText = null;
            this.rGridViewCommitments.CustomDeleteText = null;
            this.rGridViewCommitments.CustomEditText = null;
            this.rGridViewCommitments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewCommitments.EditOnDoubleClick = true;
            this.rGridViewCommitments.FieldName = null;
            this.rGridViewCommitments.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewCommitments.ItemImage = null;
            this.rGridViewCommitments.Location = new System.Drawing.Point(0, 0);
            this.rGridViewCommitments.MultiSelect = false;
            this.rGridViewCommitments.Name = "rGridViewCommitments";
            this.rGridViewCommitments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewCommitments.RowHeight = 25;
            this.rGridViewCommitments.ShowBottomToolbar = false;
            this.rGridViewCommitments.ShowGroupPanel = true;
            this.rGridViewCommitments.ShowTopToolbar = true;
            this.rGridViewCommitments.Size = new System.Drawing.Size(593, 434);
            this.rGridViewCommitments.TabIndex = 0;
            this.rGridViewCommitments.ValidationType = rComponents.ValidationType.None;
            this.rGridViewCommitments.Add += new System.EventHandler(this.rGridViewCommitments_Add);
            this.rGridViewCommitments.Edit += new System.EventHandler(this.rGridViewCommitments_Edit);
            this.rGridViewCommitments.Delete += new System.EventHandler(this.rGridViewCommitments_Delete);
            // 
            // frmFinancialCommitmentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 434);
            this.Controls.Add(this.rGridViewCommitments);
            this.Name = "frmFinancialCommitmentList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "لیست تعهدات مالی";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private rComponents.rGridView rGridViewCommitments;
    }
}