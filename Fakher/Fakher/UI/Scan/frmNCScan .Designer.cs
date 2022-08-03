namespace Fakher.UI
{
    partial class frmNCScan
    {
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lnkPrint1 = new System.Windows.Forms.LinkLabel();
            this.lnkNCUploading1 = new System.Windows.Forms.LinkLabel();
            this.lnkNCScan1 = new System.Windows.Forms.LinkLabel();
            this.lnk_OkNC1 = new System.Windows.Forms.LinkLabel();
            this.lnk_DelNC1 = new System.Windows.Forms.LinkLabel();
            this.NCpictureBox1 = new System.Windows.Forms.PictureBox();
            this.rTwainControl1 = new rTwain.rTwainControl(this.components);
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.NCpictureBox2 = new System.Windows.Forms.PictureBox();
            this.lnkNCUploading2 = new System.Windows.Forms.LinkLabel();
            this.lnkNCScan2 = new System.Windows.Forms.LinkLabel();
            this.lnkPrint2 = new System.Windows.Forms.LinkLabel();
            this.lnk_OkNC2 = new System.Windows.Forms.LinkLabel();
            this.lnk_DelNC2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.NCpictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NCpictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lnkPrint1
            // 
            this.lnkPrint1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkPrint1.AutoSize = true;
            this.lnkPrint1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPrint1.Location = new System.Drawing.Point(902, 272);
            this.lnkPrint1.Name = "lnkPrint1";
            this.lnkPrint1.Size = new System.Drawing.Size(40, 17);
            this.lnkPrint1.TabIndex = 36;
            this.lnkPrint1.TabStop = true;
            this.lnkPrint1.Text = "پرینت";
            this.lnkPrint1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrint_LinkClicked);
            // 
            // lnkNCUploading1
            // 
            this.lnkNCUploading1.AutoSize = true;
            this.lnkNCUploading1.Location = new System.Drawing.Point(850, 145);
            this.lnkNCUploading1.Name = "lnkNCUploading1";
            this.lnkNCUploading1.Size = new System.Drawing.Size(138, 17);
            this.lnkNCUploading1.TabIndex = 33;
            this.lnkNCUploading1.TabStop = true;
            this.lnkNCUploading1.Text = "بارگذاری کارت ملی(رو)";
            this.lnkNCUploading1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNCUploading_LinkClicked);
            // 
            // lnkNCScan1
            // 
            this.lnkNCScan1.AutoSize = true;
            this.lnkNCScan1.Location = new System.Drawing.Point(863, 97);
            this.lnkNCScan1.Name = "lnkNCScan1";
            this.lnkNCScan1.Size = new System.Drawing.Size(125, 17);
            this.lnkNCScan1.TabIndex = 31;
            this.lnkNCScan1.TabStop = true;
            this.lnkNCScan1.Text = "اسکن کارت ملی(رو)";
            this.lnkNCScan1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNCScan_LinkClicked);
            // 
            // lnk_OkNC1
            // 
            this.lnk_OkNC1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lnk_OkNC1.AutoSize = true;
            this.lnk_OkNC1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnk_OkNC1.Location = new System.Drawing.Point(886, 196);
            this.lnk_OkNC1.Name = "lnk_OkNC1";
            this.lnk_OkNC1.Size = new System.Drawing.Size(86, 17);
            this.lnk_OkNC1.TabIndex = 35;
            this.lnk_OkNC1.TabStop = true;
            this.lnk_OkNC1.Text = "ذخیره در فایل";
            this.lnk_OkNC1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_OkNC_LinkClicked);
            // 
            // lnk_DelNC1
            // 
            this.lnk_DelNC1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lnk_DelNC1.AutoSize = true;
            this.lnk_DelNC1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnk_DelNC1.Location = new System.Drawing.Point(886, 236);
            this.lnk_DelNC1.Name = "lnk_DelNC1";
            this.lnk_DelNC1.Size = new System.Drawing.Size(78, 17);
            this.lnk_DelNC1.TabIndex = 34;
            this.lnk_DelNC1.TabStop = true;
            this.lnk_DelNC1.Text = " حذف عکس";
            this.lnk_DelNC1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_DelNC_LinkClicked);
            // 
            // NCpictureBox1
            // 
            this.NCpictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.NCpictureBox1.Location = new System.Drawing.Point(520, 58);
            this.NCpictureBox1.Name = "NCpictureBox1";
            this.NCpictureBox1.Size = new System.Drawing.Size(313, 266);
            this.NCpictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NCpictureBox1.TabIndex = 32;
            this.NCpictureBox1.TabStop = false;
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
            this.btnOk.Location = new System.Drawing.Point(371, 330);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 26);
            this.btnOk.TabIndex = 41;
            this.btnOk.Text = "تایید";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(208, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 26);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NCpictureBox2
            // 
            this.NCpictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.NCpictureBox2.Location = new System.Drawing.Point(12, 58);
            this.NCpictureBox2.Name = "NCpictureBox2";
            this.NCpictureBox2.Size = new System.Drawing.Size(315, 266);
            this.NCpictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NCpictureBox2.TabIndex = 43;
            this.NCpictureBox2.TabStop = false;
            // 
            // lnkNCUploading2
            // 
            this.lnkNCUploading2.AutoSize = true;
            this.lnkNCUploading2.Location = new System.Drawing.Point(332, 145);
            this.lnkNCUploading2.Name = "lnkNCUploading2";
            this.lnkNCUploading2.Size = new System.Drawing.Size(159, 17);
            this.lnkNCUploading2.TabIndex = 45;
            this.lnkNCUploading2.TabStop = true;
            this.lnkNCUploading2.Text = "بارگذاری کارت ملی(پشت)";
            this.lnkNCUploading2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNCUploading2_LinkClicked);
            // 
            // lnkNCScan2
            // 
            this.lnkNCScan2.AutoSize = true;
            this.lnkNCScan2.Location = new System.Drawing.Point(345, 97);
            this.lnkNCScan2.Name = "lnkNCScan2";
            this.lnkNCScan2.Size = new System.Drawing.Size(146, 17);
            this.lnkNCScan2.TabIndex = 44;
            this.lnkNCScan2.TabStop = true;
            this.lnkNCScan2.Text = "اسکن کارت ملی(پشت)";
            this.lnkNCScan2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNCScan2_LinkClicked);
            // 
            // lnkPrint2
            // 
            this.lnkPrint2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkPrint2.AutoSize = true;
            this.lnkPrint2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPrint2.Location = new System.Drawing.Point(380, 272);
            this.lnkPrint2.Name = "lnkPrint2";
            this.lnkPrint2.Size = new System.Drawing.Size(40, 17);
            this.lnkPrint2.TabIndex = 48;
            this.lnkPrint2.TabStop = true;
            this.lnkPrint2.Text = "پرینت";
            this.lnkPrint2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrint2_LinkClicked);
            // 
            // lnk_OkNC2
            // 
            this.lnk_OkNC2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lnk_OkNC2.AutoSize = true;
            this.lnk_OkNC2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnk_OkNC2.Location = new System.Drawing.Point(364, 196);
            this.lnk_OkNC2.Name = "lnk_OkNC2";
            this.lnk_OkNC2.Size = new System.Drawing.Size(86, 17);
            this.lnk_OkNC2.TabIndex = 47;
            this.lnk_OkNC2.TabStop = true;
            this.lnk_OkNC2.Text = "ذخیره در فایل";
            this.lnk_OkNC2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_OkNC2_LinkClicked);
            // 
            // lnk_DelNC2
            // 
            this.lnk_DelNC2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lnk_DelNC2.AutoSize = true;
            this.lnk_DelNC2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnk_DelNC2.Location = new System.Drawing.Point(364, 236);
            this.lnk_DelNC2.Name = "lnk_DelNC2";
            this.lnk_DelNC2.Size = new System.Drawing.Size(78, 17);
            this.lnk_DelNC2.TabIndex = 46;
            this.lnk_DelNC2.TabStop = true;
            this.lnk_DelNC2.Text = " حذف عکس";
            this.lnk_DelNC2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_DelNC2_LinkClicked);
            // 
            // frmNCScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1007, 499);
            this.Controls.Add(this.lnkPrint2);
            this.Controls.Add(this.lnk_OkNC2);
            this.Controls.Add(this.lnk_DelNC2);
            this.Controls.Add(this.lnkNCUploading2);
            this.Controls.Add(this.lnkNCScan2);
            this.Controls.Add(this.NCpictureBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lnkPrint1);
            this.Controls.Add(this.lnkNCUploading1);
            this.Controls.Add(this.lnkNCScan1);
            this.Controls.Add(this.lnk_OkNC1);
            this.Controls.Add(this.lnk_DelNC1);
            this.Controls.Add(this.NCpictureBox1);
            this.Name = "frmNCScan";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "فرم اسکن کارت ملی";
            this.Load += new System.EventHandler(this.frmNCScan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NCpictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NCpictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.LinkLabel lnkPrint1;
        private System.Windows.Forms.LinkLabel lnkNCUploading1;
        private System.Windows.Forms.LinkLabel lnkNCScan1;
        private System.Windows.Forms.LinkLabel lnk_OkNC1;
        private System.Windows.Forms.LinkLabel lnk_DelNC1;
        private System.Windows.Forms.PictureBox NCpictureBox1;
        private rTwain.rTwainControl rTwainControl1;
        private System.ComponentModel.IContainer components;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private System.Windows.Forms.PictureBox NCpictureBox2;
        private System.Windows.Forms.LinkLabel lnkNCUploading2;
        private System.Windows.Forms.LinkLabel lnkNCScan2;
        private System.Windows.Forms.LinkLabel lnkPrint2;
        private System.Windows.Forms.LinkLabel lnk_OkNC2;
        private System.Windows.Forms.LinkLabel lnk_DelNC2;
    }
}