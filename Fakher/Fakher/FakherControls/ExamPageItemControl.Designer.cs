namespace Fakher.Application_Controls
{
    partial class ExamPageItemControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExamPageItemControl));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBoxEdit = new System.Windows.Forms.PictureBox();
            this.pictureBoxDelete = new System.Windows.Forms.PictureBox();
            this.rHtmlLabel1 = new rComponents.rHtmlLabel();
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.pictureBoxDown = new System.Windows.Forms.PictureBox();
            this.pictureBoxUp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUp)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Edit.png");
            this.imageList1.Images.SetKeyName(1, "Edit.png");
            this.imageList1.Images.SetKeyName(2, "Delete.png");
            this.imageList1.Images.SetKeyName(3, "Delete.png");
            this.imageList1.Images.SetKeyName(4, "up.png");
            this.imageList1.Images.SetKeyName(5, "up-bw.png");
            this.imageList1.Images.SetKeyName(6, "down.png");
            this.imageList1.Images.SetKeyName(7, "down-bw.png");
            // 
            // pictureBoxEdit
            // 
            this.pictureBoxEdit.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxEdit.Image")));
            this.pictureBoxEdit.Location = new System.Drawing.Point(25, 3);
            this.pictureBoxEdit.Name = "pictureBoxEdit";
            this.pictureBoxEdit.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxEdit.TabIndex = 1;
            this.pictureBoxEdit.TabStop = false;
            this.pictureBoxEdit.MouseLeave += new System.EventHandler(this.pictureBoxEdit_MouseLeave);
            this.pictureBoxEdit.Click += new System.EventHandler(this.pictureBoxEdit_Click);
            this.pictureBoxEdit.MouseEnter += new System.EventHandler(this.pictureBoxEdit_MouseEnter);
            // 
            // pictureBoxDelete
            // 
            this.pictureBoxDelete.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDelete.Image")));
            this.pictureBoxDelete.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxDelete.Name = "pictureBoxDelete";
            this.pictureBoxDelete.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxDelete.TabIndex = 1;
            this.pictureBoxDelete.TabStop = false;
            this.pictureBoxDelete.MouseLeave += new System.EventHandler(this.pictureBoxDelete_MouseLeave);
            this.pictureBoxDelete.Click += new System.EventHandler(this.pictureBoxDelete_Click);
            this.pictureBoxDelete.MouseEnter += new System.EventHandler(this.pictureBoxDelete_MouseEnter);
            // 
            // rHtmlLabel1
            // 
            this.rHtmlLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rHtmlLabel1.BodyHtml = null;
            this.rHtmlLabel1.BodyText = null;
            this.rHtmlLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rHtmlLabel1.DocumentText = "<html><body></body></html>";
            this.rHtmlLabel1.Location = new System.Drawing.Point(3, 25);
            this.rHtmlLabel1.Name = "rHtmlLabel1";
            this.rHtmlLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rHtmlLabel1.Size = new System.Drawing.Size(615, 112);
            this.rHtmlLabel1.TabIndex = 2;
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.AutoSize = false;
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLabel1.Location = new System.Drawing.Point(208, 3);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(410, 17);
            this.rLabel1.TabIndex = 3;
            // 
            // pictureBoxDown
            // 
            this.pictureBoxDown.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDown.Image")));
            this.pictureBoxDown.Location = new System.Drawing.Point(54, 3);
            this.pictureBoxDown.Name = "pictureBoxDown";
            this.pictureBoxDown.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxDown.TabIndex = 4;
            this.pictureBoxDown.TabStop = false;
            this.pictureBoxDown.MouseLeave += new System.EventHandler(this.pictureBoxDown_MouseLeave);
            this.pictureBoxDown.Click += new System.EventHandler(this.pictureBoxDown_Click);
            this.pictureBoxDown.MouseEnter += new System.EventHandler(this.pictureBoxDown_MouseEnter);
            // 
            // pictureBoxUp
            // 
            this.pictureBoxUp.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxUp.Image")));
            this.pictureBoxUp.Location = new System.Drawing.Point(76, 3);
            this.pictureBoxUp.Name = "pictureBoxUp";
            this.pictureBoxUp.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxUp.TabIndex = 5;
            this.pictureBoxUp.TabStop = false;
            this.pictureBoxUp.MouseLeave += new System.EventHandler(this.pictureBoxUp_MouseLeave);
            this.pictureBoxUp.Click += new System.EventHandler(this.pictureBoxUp_Click);
            this.pictureBoxUp.MouseEnter += new System.EventHandler(this.pictureBoxUp_MouseEnter);
            // 
            // ExamPageItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBoxUp);
            this.Controls.Add(this.pictureBoxDown);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.rHtmlLabel1);
            this.Controls.Add(this.pictureBoxDelete);
            this.Controls.Add(this.pictureBoxEdit);
            this.Name = "ExamPageItemControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(621, 140);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBoxEdit;
        private System.Windows.Forms.PictureBox pictureBoxDelete;
        private rComponents.rHtmlLabel rHtmlLabel1;
        private rComponents.rLabel rLabel1;
        private System.Windows.Forms.PictureBox pictureBoxDown;
        private System.Windows.Forms.PictureBox pictureBoxUp;
    }
}
