namespace Fakher.UI.Educational
{
    partial class frmSignup
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
            this.radBtnPerson = new Telerik.WinControls.UI.RadButton();
            this.radBtnRegister = new Telerik.WinControls.UI.RadButton();
            this.radButton4 = new Telerik.WinControls.UI.RadButton();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radBtnPerson
            // 
            this.radBtnPerson.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radBtnPerson.Location = new System.Drawing.Point(12, 12);
            this.radBtnPerson.Name = "radBtnPerson";
            this.radBtnPerson.Size = new System.Drawing.Size(545, 66);
            this.radBtnPerson.TabIndex = 0;
            this.radBtnPerson.Text = "1. ورود مشخصات فردی";
            this.radBtnPerson.Click += new System.EventHandler(this.radBtnPerson_Click);
            // 
            // radBtnRegister
            // 
            this.radBtnRegister.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radBtnRegister.Location = new System.Drawing.Point(12, 84);
            this.radBtnRegister.Name = "radBtnRegister";
            this.radBtnRegister.Size = new System.Drawing.Size(545, 66);
            this.radBtnRegister.TabIndex = 1;
            this.radBtnRegister.Text = "2. ثبت نام";
            this.radBtnRegister.Click += new System.EventHandler(this.radBtnRegister_Click);
            // 
            // radButton4
            // 
            this.radButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radButton4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.radButton4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radButton4.Location = new System.Drawing.Point(12, 169);
            this.radButton4.Name = "radButton4";
            this.radButton4.Size = new System.Drawing.Size(130, 24);
            this.radButton4.TabIndex = 4;
            this.radButton4.Text = "انصراف";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(148, 169);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "تــایــیــد";
            // 
            // frmSignup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 205);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.radButton4);
            this.Controls.Add(this.radBtnRegister);
            this.Controls.Add(this.radBtnPerson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSignup";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ثبت نام سریع";
            ((System.ComponentModel.ISupportInitialize)(this.radBtnPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton radBtnPerson;
        private Telerik.WinControls.UI.RadButton radBtnRegister;
        private Telerik.WinControls.UI.RadButton radButton4;
        private Telerik.WinControls.UI.RadButton btnOk;
    }
}