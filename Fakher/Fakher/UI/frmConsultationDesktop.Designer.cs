namespace Fakher.UI
{
    partial class frmConsultationDesktop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultationDesktop));
            this.label36 = new System.Windows.Forms.Label();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lnkChangePassword = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label36
            // 
            this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(751, 360);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(100, 22);
            this.label36.TabIndex = 94;
            this.label36.Text = "ســیـــســـتــــم";
            // 
            // pictureBox15
            // 
            this.pictureBox15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox15.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox15.Image")));
            this.pictureBox15.Location = new System.Drawing.Point(857, 350);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(58, 58);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox15.TabIndex = 93;
            this.pictureBox15.TabStop = false;
            // 
            // lnkChangePassword
            // 
            this.lnkChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkChangePassword.AutoSize = true;
            this.lnkChangePassword.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkChangePassword.Location = new System.Drawing.Point(767, 382);
            this.lnkChangePassword.Name = "lnkChangePassword";
            this.lnkChangePassword.Size = new System.Drawing.Size(70, 13);
            this.lnkChangePassword.TabIndex = 92;
            this.lnkChangePassword.TabStop = true;
            this.lnkChangePassword.Text = "تغییر رمز عبور";
            // 
            // frmConsultationDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 473);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.pictureBox15);
            this.Controls.Add(this.lnkChangePassword);
            this.Name = "frmConsultationDesktop";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "سیستم جامع موسسه آموزش عالی آزاد فاخــــــر - میـــز کــار مشــاوران";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.LinkLabel lnkChangePassword;
    }
}