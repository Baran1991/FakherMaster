namespace Fakher.Controls
{
    partial class ReceiverSelector
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
            this.lnkSelectDepartment = new System.Windows.Forms.LinkLabel();
            this.lnkSelectTeacher = new System.Windows.Forms.LinkLabel();
            this.lnkSelectEmployee = new System.Windows.Forms.LinkLabel();
            this.rTextBox1 = new rComponents.rTextBox(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // lnkSelectDepartment
            // 
            this.lnkSelectDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkSelectDepartment.AutoSize = true;
            this.lnkSelectDepartment.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkSelectDepartment.Location = new System.Drawing.Point(373, 25);
            this.lnkSelectDepartment.Name = "lnkSelectDepartment";
            this.lnkSelectDepartment.Size = new System.Drawing.Size(74, 13);
            this.lnkSelectDepartment.TabIndex = 24;
            this.lnkSelectDepartment.TabStop = true;
            this.lnkSelectDepartment.Text = "انتخاب دپارتمان";
            this.lnkSelectDepartment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSelectDepartment_LinkClicked);
            // 
            // lnkSelectTeacher
            // 
            this.lnkSelectTeacher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkSelectTeacher.AutoSize = true;
            this.lnkSelectTeacher.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkSelectTeacher.Location = new System.Drawing.Point(209, 25);
            this.lnkSelectTeacher.Name = "lnkSelectTeacher";
            this.lnkSelectTeacher.Size = new System.Drawing.Size(68, 13);
            this.lnkSelectTeacher.TabIndex = 23;
            this.lnkSelectTeacher.TabStop = true;
            this.lnkSelectTeacher.Text = "انتخاب مدرس";
            this.lnkSelectTeacher.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSelectTeacher_LinkClicked);
            // 
            // lnkSelectEmployee
            // 
            this.lnkSelectEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkSelectEmployee.AutoSize = true;
            this.lnkSelectEmployee.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkSelectEmployee.Location = new System.Drawing.Point(290, 25);
            this.lnkSelectEmployee.Name = "lnkSelectEmployee";
            this.lnkSelectEmployee.Size = new System.Drawing.Size(70, 13);
            this.lnkSelectEmployee.TabIndex = 22;
            this.lnkSelectEmployee.TabStop = true;
            this.lnkSelectEmployee.Text = "انتخاب پرسنل";
            this.lnkSelectEmployee.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSelectEmployee_LinkClicked);
            // 
            // rTextBox1
            // 
            this.rTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox1.AutoScroll = true;
            this.rTextBox1.Culture = null;
            this.rTextBox1.FieldName = null;
            this.rTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox1.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBox1.Location = new System.Drawing.Point(3, 3);
            this.rTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox1.MaximumValue = null;
            this.rTextBox1.MinimumValue = null;
            this.rTextBox1.Name = "rTextBox1";
            this.rTextBox1.ReadOnly = true;
            this.rTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rTextBox1.Size = new System.Drawing.Size(441, 19);
            this.rTextBox1.TabIndex = 20;
            this.rTextBox1.TabStop = false;
            this.rTextBox1.Type = rComponents.rTextBoxType.Text;
            this.rTextBox1.ValidatingProperty = null;
            this.rTextBox1.ValidationType = rComponents.ValidationType.None;
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(450, 4);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(62, 17);
            this.rLabel1.TabIndex = 21;
            this.rLabel1.Text = "گــیـــرنـــده:";
            // 
            // ReceiverSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lnkSelectDepartment);
            this.Controls.Add(this.lnkSelectTeacher);
            this.Controls.Add(this.lnkSelectEmployee);
            this.Controls.Add(this.rTextBox1);
            this.Controls.Add(this.rLabel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "ReceiverSelector";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(515, 45);
            this.Load += new System.EventHandler(this.ReceiverSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkSelectDepartment;
        private System.Windows.Forms.LinkLabel lnkSelectTeacher;
        private System.Windows.Forms.LinkLabel lnkSelectEmployee;
        private rComponents.rTextBox rTextBox1;
        private rComponents.rLabel rLabel1;
    }
}
