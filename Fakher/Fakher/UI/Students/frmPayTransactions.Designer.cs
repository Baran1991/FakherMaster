namespace Fakher.UI.Students
{
    partial class frmPayTransactions
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
            this.rGridView1 = new rComponents.rGridView();
            this.rLabel1 = new rComponents.rLabel(this.components);
            this.rLabel2 = new rComponents.rLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rGridView1
            // 
            this.rGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridView1.CanAdd = false;
            this.rGridView1.CanDelete = false;
            this.rGridView1.CanEdit = false;
            this.rGridView1.CanExport = true;
            this.rGridView1.CanFilter = true;
            this.rGridView1.CanGroup = false;
            this.rGridView1.CanNavigate = true;
            this.rGridView1.CheckBoxes = false;
            this.rGridView1.ColumnAutoSize = true;
            this.rGridView1.ConfirmOnDelete = true;
            this.rGridView1.CustomAddText = null;
            this.rGridView1.CustomDeleteText = null;
            this.rGridView1.CustomEditText = null;
            this.rGridView1.EditOnDoubleClick = true;
            this.rGridView1.FieldName = null;
            this.rGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView1.ItemImage = null;
            this.rGridView1.Location = new System.Drawing.Point(12, 12);
            this.rGridView1.MultiSelect = false;
            this.rGridView1.Name = "rGridView1";
            this.rGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView1.RowHeight = 25;
            this.rGridView1.ShowBottomToolbar = false;
            this.rGridView1.ShowGroupPanel = true;
            this.rGridView1.ShowTopToolbar = true;
            this.rGridView1.Size = new System.Drawing.Size(672, 378);
            this.rGridView1.TabIndex = 7;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLabel1.ForeColor = System.Drawing.Color.Red;
            this.rLabel1.Location = new System.Drawing.Point(641, 408);
            this.rLabel1.Name = "rLabel1";
            // 
            // 
            // 
            this.rLabel1.RootElement.ForeColor = System.Drawing.Color.Red;
            this.rLabel1.Size = new System.Drawing.Size(43, 18);
            this.rLabel1.TabIndex = 8;
            this.rLabel1.Text = "توجـه:";
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.AutoSize = false;
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(12, 396);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.Size = new System.Drawing.Size(623, 41);
            this.rLabel2.TabIndex = 9;
            this.rLabel2.Text = "فقط تراکنش هایی با وضعیت \"تایید شده\" یا \"تکمیل شده\" به منزله پرداخت موفق هستند. ب" +
                "قیه تراکنش ها حداکثر تا 72 ساعت بعد از سوی بانک به صورت خودکار به حساب شخص برگشت" +
                " می خورند.";
            this.rLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmPayTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 439);
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.rLabel2);
            this.Controls.Add(this.rGridView1);
            this.Name = "frmPayTransactions";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "پرداخت های اینترنتی";
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private rComponents.rGridView rGridView1;
        private rComponents.rLabel rLabel1;
        private rComponents.rLabel rLabel2;
    }
}