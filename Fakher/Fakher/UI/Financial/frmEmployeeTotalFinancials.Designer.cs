namespace Fakher.UI.Financial
{
    partial class frmEmployeeTotalFinancials
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
            this.rDatePicker1 = new rComponents.rDatePicker(this.components);
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.rDatePicker2 = new rComponents.rDatePicker(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rBtnPayoff = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnPayoff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rDatePicker1
            // 
            this.rDatePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePicker1.Culture = null;
            this.rDatePicker1.FieldName = null;
            this.rDatePicker1.Location = new System.Drawing.Point(265, 30);
            this.rDatePicker1.Mask = "1###/##/##";
            this.rDatePicker1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePicker1.Name = "rDatePicker1";
            this.rDatePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePicker1.SelectionStart = 10;
            this.rDatePicker1.Size = new System.Drawing.Size(100, 25);
            this.rDatePicker1.TabIndex = 3;
            this.rDatePicker1.TabStop = false;
            this.rDatePicker1.Text = "1___/__/__";
            this.rDatePicker1.ValidationType = rComponents.ValidationType.None;
            this.rDatePicker1.Value = "";
            // 
            // rLabel3
            // 
            this.rLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel3.BackColor = System.Drawing.Color.Transparent;
            this.rLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel3.Location = new System.Drawing.Point(371, 32);
            this.rLabel3.Name = "rLabel3";
            this.rLabel3.Size = new System.Drawing.Size(62, 24);
            this.rLabel3.TabIndex = 2;
            this.rLabel3.Text = "از تاریخ:";
            // 
            // rDatePicker2
            // 
            this.rDatePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rDatePicker2.Culture = null;
            this.rDatePicker2.FieldName = null;
            this.rDatePicker2.Location = new System.Drawing.Point(72, 30);
            this.rDatePicker2.Mask = "1###/##/##";
            this.rDatePicker2.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rDatePicker2.Name = "rDatePicker2";
            this.rDatePicker2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rDatePicker2.SelectionStart = 10;
            this.rDatePicker2.Size = new System.Drawing.Size(100, 25);
            this.rDatePicker2.TabIndex = 5;
            this.rDatePicker2.TabStop = false;
            this.rDatePicker2.Text = "1___/__/__";
            this.rDatePicker2.ValidationType = rComponents.ValidationType.None;
            this.rDatePicker2.Value = "";
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(178, 32);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(62, 24);
            this.rLabel1.TabIndex = 4;
            this.rLabel1.Text = "تا تاریخ:";
            // 
            // rBtnPayoff
            // 
            this.rBtnPayoff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtnPayoff.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rBtnPayoff.Location = new System.Drawing.Point(72, 101);
            this.rBtnPayoff.Name = "rBtnPayoff";
            this.rBtnPayoff.Size = new System.Drawing.Size(361, 26);
            this.rBtnPayoff.TabIndex = 6;
            this.rBtnPayoff.Text = "گزارش مجموع دریافت های مالی";
            this.rBtnPayoff.Click += new System.EventHandler(this.rBtnPayoff_Click);
            // 
            // frmEmployeeTotalFinancials
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(497, 215);
            this.Controls.Add(this.rBtnPayoff);
            this.Controls.Add(this.rDatePicker2);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.rDatePicker1);
            this.Controls.Add(this.rLabel3);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmEmployeeTotalFinancials";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "جمع دریافت های مالی";
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDatePicker2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnPayoff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private rComponents.rDatePicker rDatePicker1;
        private rComponents.rLabel rLabel3;
        private rComponents.rDatePicker rDatePicker2;
        private rComponents.rLabel rLabel1;
        private Telerik.WinControls.UI.RadButton rBtnPayoff;
    }
}