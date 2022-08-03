namespace Fakher.Controls
{
    partial class MessageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkPrint = new System.Windows.Forms.LinkLabel();
            this.rLblTo = new rComponents.rLabel(this.components);
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.rLblFrom = new rComponents.rLabel(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rLblSubject = new rComponents.rLabel(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rTextBox1 = new rComponents.rTextBox(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLblTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lnkPrint);
            this.panel1.Controls.Add(this.rLblTo);
            this.panel1.Controls.Add(this.rLabel3);
            this.panel1.Controls.Add(this.rLblFrom);
            this.panel1.Controls.Add(this.rLabel1);
            this.panel1.Controls.Add(this.rLblSubject);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 88);
            this.panel1.TabIndex = 0;
            // 
            // lnkPrint
            // 
            this.lnkPrint.AutoSize = true;
            this.lnkPrint.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPrint.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPrint.Location = new System.Drawing.Point(3, 3);
            this.lnkPrint.Name = "lnkPrint";
            this.lnkPrint.Size = new System.Drawing.Size(50, 16);
            this.lnkPrint.TabIndex = 0;
            this.lnkPrint.TabStop = true;
            this.lnkPrint.Text = "چــــــاپ";
            this.lnkPrint.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrint_LinkClicked);
            // 
            // rLblTo
            // 
            this.rLblTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rLblTo.AutoSize = false;
            this.rLblTo.BackColor = System.Drawing.Color.Transparent;
            this.rLblTo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLblTo.Location = new System.Drawing.Point(3, 60);
            this.rLblTo.Name = "rLblTo";
            this.rLblTo.Size = new System.Drawing.Size(538, 17);
            this.rLblTo.TabIndex = 3;
            this.rLblTo.Text = "rLabel2";
            // 
            // rLabel3
            // 
            this.rLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel3.BackColor = System.Drawing.Color.Transparent;
            this.rLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel3.Location = new System.Drawing.Point(547, 60);
            this.rLabel3.Name = "rLabel3";
            this.rLabel3.Size = new System.Drawing.Size(20, 17);
            this.rLabel3.TabIndex = 2;
            this.rLabel3.Text = "به:";
            // 
            // rLblFrom
            // 
            this.rLblFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rLblFrom.AutoSize = false;
            this.rLblFrom.BackColor = System.Drawing.Color.Transparent;
            this.rLblFrom.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLblFrom.Location = new System.Drawing.Point(3, 37);
            this.rLblFrom.Name = "rLblFrom";
            this.rLblFrom.Size = new System.Drawing.Size(538, 17);
            this.rLblFrom.TabIndex = 3;
            this.rLblFrom.Text = "rLabel2";
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(547, 37);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(17, 17);
            this.rLabel1.TabIndex = 2;
            this.rLabel1.Text = "از:";
            // 
            // rLblSubject
            // 
            this.rLblSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rLblSubject.AutoSize = false;
            this.rLblSubject.BackColor = System.Drawing.Color.Transparent;
            this.rLblSubject.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLblSubject.Location = new System.Drawing.Point(59, 3);
            this.rLblSubject.Name = "rLblSubject";
            this.rLblSubject.Size = new System.Drawing.Size(505, 28);
            this.rLblSubject.TabIndex = 1;
            this.rLblSubject.Text = "rLabel1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(572, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // rTextBox1
            // 
            this.rTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox1.AutoScroll = true;
            this.rTextBox1.Culture = null;
            this.rTextBox1.FieldName = null;
            this.rTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox1.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox1.Location = new System.Drawing.Point(3, 94);
            this.rTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox1.MaximumValue = null;
            this.rTextBox1.MinimumValue = null;
            this.rTextBox1.Multiline = true;
            this.rTextBox1.Name = "rTextBox1";
            this.rTextBox1.ReadOnly = true;
            this.rTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.rTextBox1.RootElement.StretchVertically = true;
            this.rTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.rTextBox1.Size = new System.Drawing.Size(650, 168);
            this.rTextBox1.TabIndex = 0;
            this.rTextBox1.TabStop = false;
            this.rTextBox1.Type = rComponents.rTextBoxType.Text;
            this.rTextBox1.ValidatingProperty = null;
            this.rTextBox1.ValidationType = rComponents.ValidationType.None;
            // 
            // MessageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.rTextBox1);
            this.Controls.Add(this.panel1);
            this.Name = "MessageView";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(656, 265);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLblTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private rComponents.rLabel rLblSubject;
        private rComponents.rLabel rLblTo;
        private rComponents.rLabel rLabel3;
        private rComponents.rLabel rLblFrom;
        private rComponents.rLabel rLabel1;
        private System.Windows.Forms.LinkLabel lnkPrint;
        private rComponents.rTextBox rTextBox1;
    }
}
