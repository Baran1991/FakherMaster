namespace Fakher.UI.Educational.Students
{
    partial class frmStudentFileList
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
            this.rGridViewStudents = new rComponents.rGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox1.Controls.Add(this.rGridViewStudents);
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "پرونده آموزشی دانشجویان";
            this.rGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(951, 470);
            this.rGroupBox1.TabIndex = 1;
            this.rGroupBox1.Text = "پرونده آموزشی دانشجویان";
            // 
            // rGridViewStudents
            // 
            this.rGridViewStudents.CanAdd = false;
            this.rGridViewStudents.CanDelete = true;
            this.rGridViewStudents.CanEdit = true;
            this.rGridViewStudents.CanExport = true;
            this.rGridViewStudents.CanFilter = true;
            this.rGridViewStudents.CanGroup = false;
            this.rGridViewStudents.CanNavigate = true;
            this.rGridViewStudents.CheckBoxes = false;
            this.rGridViewStudents.ColumnAutoSize = true;
            this.rGridViewStudents.ConfirmOnDelete = true;
            this.rGridViewStudents.CustomAddText = null;
            this.rGridViewStudents.CustomDeleteText = null;
            this.rGridViewStudents.CustomEditText = null;
            this.rGridViewStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridViewStudents.FieldName = null;
            this.rGridViewStudents.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewStudents.ItemImage = null;
            this.rGridViewStudents.Location = new System.Drawing.Point(2, 20);
            this.rGridViewStudents.MultiSelect = false;
            this.rGridViewStudents.Name = "rGridViewStudents";
            this.rGridViewStudents.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewStudents.RowHeight = 25;
            this.rGridViewStudents.ShowBottomToolbar = false;
            this.rGridViewStudents.ShowTopToolbar = true;
            this.rGridViewStudents.Size = new System.Drawing.Size(947, 448);
            this.rGridViewStudents.TabIndex = 0;
            this.rGridViewStudents.ValidationType = rComponents.ValidationType.None;
            this.rGridViewStudents.Delete += new System.EventHandler(this.rGridViewStudents_Delete);
            this.rGridViewStudents.Edit += new System.EventHandler(this.rGridViewStudents_Edit);
            // 
            // frmStudentFileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 494);
            this.Controls.Add(this.rGroupBox1);
            this.Name = "frmStudentFileList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "پرونده آموزشی دانشجویان";
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rGridView rGridViewStudents;
    }
}