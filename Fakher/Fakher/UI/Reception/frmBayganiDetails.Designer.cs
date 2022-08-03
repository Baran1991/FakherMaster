namespace Fakher.UI.Persons
{
    partial class frmBayganiDetails
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
            this.rLabel21 = new rComponents.rLabel(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.rTextBoxEmployee = new rComponents.rTextBox(this.components);
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.rLabelBayganiNo = new rComponents.rLabel(this.components);
            this.rTextBoxDate = new rComponents.rTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBoxEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabelBayganiNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBoxDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rLabel21
            // 
            this.rLabel21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel21.BackColor = System.Drawing.Color.Transparent;
            this.rLabel21.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel21.Location = new System.Drawing.Point(212, 19);
            this.rLabel21.Name = "rLabel21";
            this.rLabel21.Size = new System.Drawing.Size(52, 24);
            this.rLabel21.TabIndex = 3;
            this.rLabel21.Text = "اپراتور:";
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(445, 18);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(47, 24);
            this.rLabel1.TabIndex = 4;
            this.rLabel1.Text = "تاریخ:";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnPrint.Location = new System.Drawing.Point(132, 154);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(227, 26);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "چاپ شماره بایگانی";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // rTextBoxEmployee
            // 
            this.rTextBoxEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBoxEmployee.Culture = null;
            this.rTextBoxEmployee.Enabled = false;
            this.rTextBoxEmployee.FieldName = null;
            this.rTextBoxEmployee.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBoxEmployee.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBoxEmployee.Location = new System.Drawing.Point(24, 19);
            this.rTextBoxEmployee.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBoxEmployee.MaximumValue = null;
            this.rTextBoxEmployee.MinimumValue = null;
            this.rTextBoxEmployee.Name = "rTextBoxEmployee";
            this.rTextBoxEmployee.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rTextBoxEmployee.Size = new System.Drawing.Size(182, 25);
            this.rTextBoxEmployee.TabIndex = 8;
            this.rTextBoxEmployee.TabStop = false;
            this.rTextBoxEmployee.Type = rComponents.rTextBoxType.Text;
            this.rTextBoxEmployee.ValidatingProperty = null;
            this.rTextBoxEmployee.ValidationType = rComponents.ValidationType.None;
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.rLabel2.Location = new System.Drawing.Point(357, 78);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(135, 24);
            this.rLabel2.TabIndex = 9;
            this.rLabel2.Text = "شماره بایگانی: ";
            // 
            // rLabelBayganiNo
            // 
            this.rLabelBayganiNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabelBayganiNo.BackColor = System.Drawing.Color.Transparent;
            this.rLabelBayganiNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.rLabelBayganiNo.Location = new System.Drawing.Point(230, 78);
            this.rLabelBayganiNo.Name = "rLabelBayganiNo";
            this.rLabelBayganiNo.Size = new System.Drawing.Size(18, 24);
            this.rLabelBayganiNo.TabIndex = 10;
            this.rLabelBayganiNo.Text = "۰";
            // 
            // rTextBoxDate
            // 
            this.rTextBoxDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBoxDate.Culture = null;
            this.rTextBoxDate.Enabled = false;
            this.rTextBoxDate.FieldName = null;
            this.rTextBoxDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBoxDate.Language = rComponents.TextboxLanguage.DontCare;
            this.rTextBoxDate.Location = new System.Drawing.Point(310, 19);
            this.rTextBoxDate.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBoxDate.MaximumValue = null;
            this.rTextBoxDate.MinimumValue = null;
            this.rTextBoxDate.Name = "rTextBoxDate";
            this.rTextBoxDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rTextBoxDate.Size = new System.Drawing.Size(129, 25);
            this.rTextBoxDate.TabIndex = 11;
            this.rTextBoxDate.TabStop = false;
            this.rTextBoxDate.Type = rComponents.rTextBoxType.Text;
            this.rTextBoxDate.ValidatingProperty = null;
            this.rTextBoxDate.ValidationType = rComponents.ValidationType.None;
            // 
            // frmBayganiDetails
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(520, 192);
            this.Controls.Add(this.rTextBoxDate);
            this.Controls.Add(this.rLabelBayganiNo);
            this.Controls.Add(this.rLabel2);
            this.Controls.Add(this.rTextBoxEmployee);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.rLabel21);
            this.Name = "frmBayganiDetails";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "سایر توضیحات";
            ((System.ComponentModel.ISupportInitialize)(this.rLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBoxEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabelBayganiNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBoxDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private rComponents.rLabel rLabel21;
        private rComponents.rLabel rLabel1;
        private Telerik.WinControls.UI.RadButton btnPrint;
        private rComponents.rTextBox rTextBoxEmployee;
        private rComponents.rLabel rLabel2;
        private rComponents.rLabel rLabelBayganiNo;
        private rComponents.rTextBox rTextBoxDate;
    }
}