namespace Fakher.UI.Financial
{
    partial class frmRegisterFinancialDetail
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
            this.financialDocumentView1 = new Fakher.Controls.FinancialDocumentView();
            this.rPageView1 = new rComponents.rPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.financialDocumentView2 = new Fakher.Controls.FinancialDocumentView();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rPageView1)).BeginInit();
            this.rPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.radPageViewPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // financialDocumentView1
            // 
            this.financialDocumentView1.CanAdd = false;
            this.financialDocumentView1.CanDelete = false;
            this.financialDocumentView1.CanEdit = false;
            this.financialDocumentView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.financialDocumentView1.Location = new System.Drawing.Point(3, 23);
            this.financialDocumentView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.financialDocumentView1.Name = "financialDocumentView1";
            this.financialDocumentView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.financialDocumentView1.Size = new System.Drawing.Size(1205, 500);
            this.financialDocumentView1.TabIndex = 0;
            this.financialDocumentView1.Add += new System.EventHandler(this.financialDocumentView1_Add);
            this.financialDocumentView1.Delete += new System.EventHandler(this.financialDocumentView1_Delete);
            // 
            // rPageView1
            // 
            this.rPageView1.Controls.Add(this.radPageViewPage1);
            this.rPageView1.Controls.Add(this.radPageViewPage2);
            this.rPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rPageView1.Location = new System.Drawing.Point(0, 0);
            this.rPageView1.Name = "rPageView1";
            this.rPageView1.SelectedPage = this.radPageViewPage1;
            this.rPageView1.Size = new System.Drawing.Size(1232, 776);
            this.rPageView1.TabIndex = 1;
            this.rPageView1.Text = "rPageView1";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.rPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.groupBox2);
            this.radPageViewPage1.Controls.Add(this.groupBox1);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 43);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(1211, 722);
            this.radPageViewPage1.Text = "نمــــــای کلـــی";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1211, 64);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1055, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "چاپ گزارش";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.financialDocumentView2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1211, 574);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // financialDocumentView2
            // 
            this.financialDocumentView2.CanAdd = false;
            this.financialDocumentView2.CanDelete = false;
            this.financialDocumentView2.CanEdit = false;
            this.financialDocumentView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.financialDocumentView2.Location = new System.Drawing.Point(3, 23);
            this.financialDocumentView2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.financialDocumentView2.Name = "financialDocumentView2";
            this.financialDocumentView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.financialDocumentView2.Size = new System.Drawing.Size(1205, 548);
            this.financialDocumentView2.TabIndex = 1;
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.groupBox4);
            this.radPageViewPage2.Controls.Add(this.groupBox3);
            this.radPageViewPage2.Location = new System.Drawing.Point(10, 43);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(1211, 722);
            this.radPageViewPage2.Text = "تــــــــرم جـــاری";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.financialDocumentView1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 196);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1211, 526);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1211, 65);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1032, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "چاپ گزارش";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmRegisterFinancialDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1232, 776);
            this.Controls.Add(this.rPageView1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "frmRegisterFinancialDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشاهده ریز جزئیات امور مالی";
            this.Load += new System.EventHandler(this.frmAdvanceFinancialDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rPageView1)).EndInit();
            this.rPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.radPageViewPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Fakher.Controls.FinancialDocumentView financialDocumentView1;
        private rComponents.rPageView rPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Controls.FinancialDocumentView financialDocumentView2;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}