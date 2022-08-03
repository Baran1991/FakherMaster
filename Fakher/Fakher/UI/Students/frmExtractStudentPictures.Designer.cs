namespace Fakher.UI.Students
{
    partial class frmExtractStudentPictures
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
            this.lnkPath = new System.Windows.Forms.LinkLabel();
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.rGroupBox2 = new rComponents.rGroupBox(this.components);
            this.rGroupBox3 = new rComponents.rGroupBox(this.components);
            this.rLabel4 = new rComponents.rLabel(this.components);
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.rTextBox1 = new rComponents.rTextBox(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).BeginInit();
            this.rGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox3)).BeginInit();
            this.rGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lnkPath
            // 
            this.lnkPath.AutoSize = true;
            this.lnkPath.BackColor = System.Drawing.Color.Transparent;
            this.lnkPath.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPath.Location = new System.Drawing.Point(5, 27);
            this.lnkPath.Name = "lnkPath";
            this.lnkPath.Size = new System.Drawing.Size(66, 13);
            this.lnkPath.TabIndex = 1;
            this.lnkPath.TabStop = true;
            this.lnkPath.Text = "انتخاب مسیر";
            this.lnkPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPath_LinkClicked);
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Arial Narrow", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLabel1.Location = new System.Drawing.Point(788, 12);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(43, 47);
            this.rLabel1.TabIndex = 2;
            this.rLabel1.Text = "1.";
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.AutoSize = false;
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.BorderVisible = true;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(77, 25);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rLabel2.Size = new System.Drawing.Size(688, 17);
            this.rLabel2.TabIndex = 4;
            // 
            // rLabel3
            // 
            this.rLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel3.BackColor = System.Drawing.Color.Transparent;
            this.rLabel3.Font = new System.Drawing.Font("Arial Narrow", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLabel3.Location = new System.Drawing.Point(788, 77);
            this.rLabel3.Name = "rLabel3";
            this.rLabel3.Size = new System.Drawing.Size(43, 47);
            this.rLabel3.TabIndex = 2;
            this.rLabel3.Text = "2.";
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox1.Controls.Add(this.rLabel2);
            this.rGroupBox1.Controls.Add(this.lnkPath);
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "مسیر ذخیره عکس ها";
            this.rGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(770, 59);
            this.rGroupBox1.TabIndex = 5;
            this.rGroupBox1.Text = "مسیر ذخیره عکس ها";
            // 
            // rGroupBox2
            // 
            this.rGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox2.Controls.Add(this.rTextBox1);
            this.rGroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox2.FooterImageIndex = -1;
            this.rGroupBox2.FooterImageKey = "";
            this.rGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox2.HeaderImageIndex = -1;
            this.rGroupBox2.HeaderImageKey = "";
            this.rGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox2.HeaderText = "شمـاره هـای دانشجویی (در هر خط فقط یک شماره دانشجویی)";
            this.rGroupBox2.Location = new System.Drawing.Point(12, 77);
            this.rGroupBox2.Name = "rGroupBox2";
            this.rGroupBox2.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox2.Size = new System.Drawing.Size(770, 207);
            this.rGroupBox2.TabIndex = 6;
            this.rGroupBox2.Text = "شمـاره هـای دانشجویی (در هر خط فقط یک شماره دانشجویی)";
            // 
            // rGroupBox3
            // 
            this.rGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox3.Controls.Add(this.progressBar1);
            this.rGroupBox3.Controls.Add(this.radButton1);
            this.rGroupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox3.FooterImageIndex = -1;
            this.rGroupBox3.FooterImageKey = "";
            this.rGroupBox3.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox3.HeaderImageIndex = -1;
            this.rGroupBox3.HeaderImageKey = "";
            this.rGroupBox3.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox3.HeaderText = "استخراج";
            this.rGroupBox3.Location = new System.Drawing.Point(7, 290);
            this.rGroupBox3.Name = "rGroupBox3";
            this.rGroupBox3.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox3.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox3.Size = new System.Drawing.Size(770, 69);
            this.rGroupBox3.TabIndex = 6;
            this.rGroupBox3.Text = "استخراج";
            // 
            // rLabel4
            // 
            this.rLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel4.BackColor = System.Drawing.Color.Transparent;
            this.rLabel4.Font = new System.Drawing.Font("Arial Narrow", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLabel4.Location = new System.Drawing.Point(783, 290);
            this.rLabel4.Name = "rLabel4";
            this.rLabel4.Size = new System.Drawing.Size(43, 47);
            this.rLabel4.TabIndex = 2;
            this.rLabel4.Text = "3.";
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.Location = new System.Drawing.Point(5, 24);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(760, 24);
            this.radButton1.TabIndex = 0;
            this.radButton1.Text = "استخــراج";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // rTextBox1
            // 
            this.rTextBox1.AcceptsReturn = true;
            this.rTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox1.AutoScroll = true;
            this.rTextBox1.Culture = null;
            this.rTextBox1.FieldName = null;
            this.rTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox1.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox1.Location = new System.Drawing.Point(5, 23);
            this.rTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox1.MaximumValue = null;
            this.rTextBox1.MinimumValue = null;
            this.rTextBox1.Multiline = true;
            this.rTextBox1.Name = "rTextBox1";
            this.rTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.rTextBox1.RootElement.StretchVertically = true;
            this.rTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.rTextBox1.Size = new System.Drawing.Size(760, 179);
            this.rTextBox1.TabIndex = 0;
            this.rTextBox1.TabStop = false;
            this.rTextBox1.Type = rComponents.rTextBoxType.Text;
            this.rTextBox1.ValidatingProperty = null;
            this.rTextBox1.ValidationType = rComponents.ValidationType.None;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(5, 54);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(760, 10);
            this.progressBar1.TabIndex = 1;
            // 
            // frmExtractStudentPictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 363);
            this.Controls.Add(this.rGroupBox3);
            this.Controls.Add(this.rGroupBox2);
            this.Controls.Add(this.rGroupBox1);
            this.Controls.Add(this.rLabel4);
            this.Controls.Add(this.rLabel3);
            this.Controls.Add(this.rLabel1);
            this.Name = "frmExtractStudentPictures";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "استخراج عکس دانشجویان";
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            this.rGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).EndInit();
            this.rGroupBox2.ResumeLayout(false);
            this.rGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox3)).EndInit();
            this.rGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkPath;
        private rComponents.rLabel rLabel1;
        private rComponents.rLabel rLabel2;
        private rComponents.rLabel rLabel3;
        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rGroupBox rGroupBox2;
        private rComponents.rGroupBox rGroupBox3;
        private Telerik.WinControls.UI.RadButton radButton1;
        private rComponents.rLabel rLabel4;
        private rComponents.rTextBox rTextBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}