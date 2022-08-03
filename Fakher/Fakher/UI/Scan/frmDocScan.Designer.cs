namespace Fakher.UI
{
    partial class frmDocScan
    {
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lnkDocUploading = new System.Windows.Forms.LinkLabel();
            this.lnkDocScan = new System.Windows.Forms.LinkLabel();
            this.rTwainControl1 = new rTwain.rTwainControl(this.components);
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 88);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(919, 418);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // lnkDocUploading
            // 
            this.lnkDocUploading.AutoSize = true;
            this.lnkDocUploading.Location = new System.Drawing.Point(221, 45);
            this.lnkDocUploading.Name = "lnkDocUploading";
            this.lnkDocUploading.Size = new System.Drawing.Size(96, 17);
            this.lnkDocUploading.TabIndex = 45;
            this.lnkDocUploading.TabStop = true;
            this.lnkDocUploading.Text = "بارگذاری مدارک";
            this.lnkDocUploading.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDocUploading_LinkClicked);
            // 
            // lnkDocScan
            // 
            this.lnkDocScan.AutoSize = true;
            this.lnkDocScan.Location = new System.Drawing.Point(609, 45);
            this.lnkDocScan.Name = "lnkDocScan";
            this.lnkDocScan.Size = new System.Drawing.Size(83, 17);
            this.lnkDocScan.TabIndex = 44;
            this.lnkDocScan.TabStop = true;
            this.lnkDocScan.Text = "اسکن مدارک";
            this.lnkDocScan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDocScan_LinkClicked);
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
            this.btnOk.Location = new System.Drawing.Point(145, 534);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(92, 24);
            this.btnOk.TabIndex = 46;
            this.btnOk.Text = "تایید";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(12, 534);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 24);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmDocScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(933, 701);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lnkDocScan);
            this.Controls.Add(this.lnkDocUploading);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmDocScan";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "فرم اسکن مدارک";
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel lnkDocUploading;
        private System.Windows.Forms.LinkLabel lnkDocScan;
        private rTwain.rTwainControl rTwainControl1;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}