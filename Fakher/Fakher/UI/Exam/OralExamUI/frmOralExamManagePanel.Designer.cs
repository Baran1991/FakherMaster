namespace Fakher.UI.Exam
{
    partial class frmOralExamManagePanel
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
            this.examSelector1 = new Fakher.Controls.ExamSelector();
            this.examParticipateInfo1 = new Fakher.Controls.ExamParticipateInfo();
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.rGridView1 = new rComponents.rGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lnkResultReport = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // examSelector1
            // 
            this.examSelector1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.examSelector1.Dock = System.Windows.Forms.DockStyle.Top;
            this.examSelector1.ExamType = Fakher.Core.DomainModel.ExamType.OralExam;
            this.examSelector1.FilterExamType = true;
            this.examSelector1.Location = new System.Drawing.Point(0, 0);
            this.examSelector1.Name = "examSelector1";
            this.examSelector1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.examSelector1.ShowExamSections = true;
            this.examSelector1.ShowNullButton = false;
            this.examSelector1.Size = new System.Drawing.Size(766, 86);
            this.examSelector1.TabIndex = 0;
            this.examSelector1.SelectedChanged += new System.EventHandler(this.examSelector1_SelectedChanged);
            // 
            // examParticipateInfo1
            // 
            this.examParticipateInfo1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.examParticipateInfo1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.examParticipateInfo1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.examParticipateInfo1.Location = new System.Drawing.Point(0, 274);
            this.examParticipateInfo1.Name = "examParticipateInfo1";
            this.examParticipateInfo1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.examParticipateInfo1.Size = new System.Drawing.Size(766, 205);
            this.examParticipateInfo1.TabIndex = 1;
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
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
            this.rGroupBox1.HeaderText = "شرکت کنندگان در مصاحبه";
            this.rGroupBox1.Location = new System.Drawing.Point(12, 92);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(742, 176);
            this.rGroupBox1.TabIndex = 2;
            this.rGroupBox1.Text = "شرکت کنندگان در مصاحبه";
            // 
            // rGridView1
            // 
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
            this.rGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView1.EditOnDoubleClick = true;
            this.rGridView1.FieldName = null;
            this.rGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView1.ItemImage = null;
            this.rGridView1.Location = new System.Drawing.Point(2, 20);
            this.rGridView1.MultiSelect = false;
            this.rGridView1.Name = "rGridView1";
            this.rGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView1.RowHeight = 25;
            this.rGridView1.ShowBottomToolbar = false;
            this.rGridView1.ShowGroupPanel = true;
            this.rGridView1.ShowTopToolbar = true;
            this.rGridView1.Size = new System.Drawing.Size(738, 154);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.SelectedItemChanged += new System.EventHandler(this.rGridView1_SelectedItemChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lnkResultReport
            // 
            this.lnkResultReport.AutoSize = true;
            this.lnkResultReport.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkResultReport.Location = new System.Drawing.Point(12, 89);
            this.lnkResultReport.Name = "lnkResultReport";
            this.lnkResultReport.Size = new System.Drawing.Size(117, 13);
            this.lnkResultReport.TabIndex = 1;
            this.lnkResultReport.TabStop = true;
            this.lnkResultReport.Text = "گـزارش نتایـج مصاحـبـــه";
            this.lnkResultReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkResultReport_LinkClicked);
            // 
            // frmOralExamManagePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 479);
            this.Controls.Add(this.lnkResultReport);
            this.Controls.Add(this.rGroupBox1);
            this.Controls.Add(this.examParticipateInfo1);
            this.Controls.Add(this.examSelector1);
            this.Name = "frmOralExamManagePanel";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "پنل امور اداری مصاحبه";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmOralExamManagePanel_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOralExamManagePanel_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Fakher.Controls.ExamSelector examSelector1;
        private Fakher.Controls.ExamParticipateInfo examParticipateInfo1;
        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rGridView rGridView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.LinkLabel lnkResultReport;
    }
}