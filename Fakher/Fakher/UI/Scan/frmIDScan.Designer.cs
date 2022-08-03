namespace Fakher.UI
{
    partial class frmIDScan
    {
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lnkPrint = new System.Windows.Forms.LinkLabel();
            this.lnkIDUploading = new System.Windows.Forms.LinkLabel();
            this.lnkIDScan = new System.Windows.Forms.LinkLabel();
            this.lnk_OkID = new System.Windows.Forms.LinkLabel();
            this.lnk_DelID = new System.Windows.Forms.LinkLabel();
            this.IDpictureBox = new System.Windows.Forms.PictureBox();
            this.rTwainControl1 = new rTwain.rTwainControl(this.components);
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.IDpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lnkPrint
            // 
            this.lnkPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkPrint.AutoSize = true;
            this.lnkPrint.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPrint.Location = new System.Drawing.Point(541, 294);
            this.lnkPrint.Name = "lnkPrint";
            this.lnkPrint.Size = new System.Drawing.Size(40, 17);
            this.lnkPrint.TabIndex = 36;
            this.lnkPrint.TabStop = true;
            this.lnkPrint.Text = "پرینت";
            this.lnkPrint.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrint_LinkClicked);
            // 
            // lnkIDUploading
            // 
            this.lnkIDUploading.AutoSize = true;
            this.lnkIDUploading.Location = new System.Drawing.Point(490, 173);
            this.lnkIDUploading.Name = "lnkIDUploading";
            this.lnkIDUploading.Size = new System.Drawing.Size(121, 17);
            this.lnkIDUploading.TabIndex = 33;
            this.lnkIDUploading.TabStop = true;
            this.lnkIDUploading.Text = "بارگذاری شناسنامه";
            this.lnkIDUploading.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkIDUploading_LinkClicked);
            // 
            // lnkIDScan
            // 
            this.lnkIDScan.AutoSize = true;
            this.lnkIDScan.Location = new System.Drawing.Point(503, 125);
            this.lnkIDScan.Name = "lnkIDScan";
            this.lnkIDScan.Size = new System.Drawing.Size(108, 17);
            this.lnkIDScan.TabIndex = 31;
            this.lnkIDScan.TabStop = true;
            this.lnkIDScan.Text = "اسکن شناسنامه";
            this.lnkIDScan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkIDScan_LinkClicked);
            // 
            // lnk_OkID
            // 
            this.lnk_OkID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lnk_OkID.AutoSize = true;
            this.lnk_OkID.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnk_OkID.Location = new System.Drawing.Point(525, 218);
            this.lnk_OkID.Name = "lnk_OkID";
            this.lnk_OkID.Size = new System.Drawing.Size(86, 17);
            this.lnk_OkID.TabIndex = 35;
            this.lnk_OkID.TabStop = true;
            this.lnk_OkID.Text = "ذخیره در فایل";
            this.lnk_OkID.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_OkID_LinkClicked);
            // 
            // lnk_DelID
            // 
            this.lnk_DelID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lnk_DelID.AutoSize = true;
            this.lnk_DelID.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnk_DelID.Location = new System.Drawing.Point(525, 258);
            this.lnk_DelID.Name = "lnk_DelID";
            this.lnk_DelID.Size = new System.Drawing.Size(78, 17);
            this.lnk_DelID.TabIndex = 34;
            this.lnk_DelID.TabStop = true;
            this.lnk_DelID.Text = " حذف عکس";
            this.lnk_DelID.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_DelID_LinkClicked);
            // 
            // IDpictureBox
            // 
            this.IDpictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.IDpictureBox.Location = new System.Drawing.Point(45, 50);
            this.IDpictureBox.Name = "IDpictureBox";
            this.IDpictureBox.Size = new System.Drawing.Size(395, 306);
            this.IDpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IDpictureBox.TabIndex = 32;
            this.IDpictureBox.TabStop = false;
            // 
            // rTwainControl1
            // 
            this.rTwainControl1.ShowUI = false;
            this.rTwainControl1.DocumentScanned += new System.EventHandler<rTwain.DocumentScannedEventArgs>(this.rTwainControl1_DocumentScanned);
            this.rTwainControl1.ScanFinished += new System.EventHandler(this.rTwainControl1_ScanFinished);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(205, 363);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 26);
            this.btnOk.TabIndex = 41;
            this.btnOk.Text = "تایید";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(42, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 26);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmIDScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(644, 494);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lnkPrint);
            this.Controls.Add(this.lnkIDUploading);
            this.Controls.Add(this.lnkIDScan);
            this.Controls.Add(this.lnk_OkID);
            this.Controls.Add(this.lnk_DelID);
            this.Controls.Add(this.IDpictureBox);
            this.Name = "frmIDScan";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "فرم اسکن شناسنامه";
            this.Load += new System.EventHandler(this.frmIDScan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IDpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.LinkLabel lnkPrint;
        private System.Windows.Forms.LinkLabel lnkIDUploading;
        private System.Windows.Forms.LinkLabel lnkIDScan;
        private System.Windows.Forms.LinkLabel lnk_OkID;
        private System.Windows.Forms.LinkLabel lnk_DelID;
        private System.Windows.Forms.PictureBox IDpictureBox;
        private rTwain.rTwainControl rTwainControl1;
        private System.ComponentModel.IContainer components;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}