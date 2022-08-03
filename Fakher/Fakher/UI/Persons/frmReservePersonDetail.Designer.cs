namespace Fakher.UI.Person
{
    partial class frmReservePersonDetail
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
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerTranslate = new System.ComponentModel.BackgroundWorker();
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.rTextBox8 = new rComponents.rTextBox(this.components);
            this.rLabel8 = new rComponents.rLabel(this.components);
            this.rTextBox7 = new rComponents.rTextBox(this.components);
            this.rLabel7 = new rComponents.rLabel(this.components);
            this.rTextBox6 = new rComponents.rTextBox(this.components);
            this.rTextBox4 = new rComponents.rTextBox(this.components);
            this.rLabel6 = new rComponents.rLabel(this.components);
            this.rTextBox5 = new rComponents.rTextBox(this.components);
            this.rLabel4 = new rComponents.rLabel(this.components);
            this.rLabel5 = new rComponents.rLabel(this.components);
            this.rTextBox3 = new rComponents.rTextBox(this.components);
            this.rLabel3 = new rComponents.rLabel(this.components);
            this.rTextBox2 = new rComponents.rTextBox(this.components);
            this.rLabel2 = new rComponents.rLabel(this.components);
            this.rTextBox1 = new rComponents.rTextBox(this.components);
            this.rLabel1 = new rComponents.rLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(172, 173);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 24);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "تــایــیــد";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(36, 173);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "انصــراف";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorkerTranslate
            // 
            this.backgroundWorkerTranslate.WorkerSupportsCancellation = true;
            this.backgroundWorkerTranslate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTranslate_DoWork);
            this.backgroundWorkerTranslate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTranslate_RunWorkerCompleted);
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGroupBox1.Controls.Add(this.rTextBox8);
            this.rGroupBox1.Controls.Add(this.rLabel8);
            this.rGroupBox1.Controls.Add(this.rTextBox7);
            this.rGroupBox1.Controls.Add(this.rLabel7);
            this.rGroupBox1.Controls.Add(this.rTextBox6);
            this.rGroupBox1.Controls.Add(this.rTextBox4);
            this.rGroupBox1.Controls.Add(this.rLabel6);
            this.rGroupBox1.Controls.Add(this.rTextBox5);
            this.rGroupBox1.Controls.Add(this.rLabel4);
            this.rGroupBox1.Controls.Add(this.rLabel5);
            this.rGroupBox1.Controls.Add(this.rTextBox3);
            this.rGroupBox1.Controls.Add(this.rLabel3);
            this.rGroupBox1.Controls.Add(this.rTextBox2);
            this.rGroupBox1.Controls.Add(this.rLabel2);
            this.rGroupBox1.Controls.Add(this.rTextBox1);
            this.rGroupBox1.Controls.Add(this.rLabel1);
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "مشخصات فردی";
            this.rGroupBox1.Location = new System.Drawing.Point(31, 12);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(3, 20, 3, 3);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.rGroupBox1.Size = new System.Drawing.Size(802, 140);
            this.rGroupBox1.TabIndex = 0;
            this.rGroupBox1.Text = "مشخصات فردی";
            // 
            // rTextBox8
            // 
            this.rTextBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox8.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox8.Culture = null;
            this.rTextBox8.FieldName = "نام پدر انگلیسی";
            this.rTextBox8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox8.Language = rComponents.TextboxLanguage.English;
            this.rTextBox8.Location = new System.Drawing.Point(115, 107);
            this.rTextBox8.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox8.MaximumValue = null;
            this.rTextBox8.MinimumValue = null;
            this.rTextBox8.Name = "rTextBox8";
            this.rTextBox8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox8.Size = new System.Drawing.Size(256, 22);
            this.rTextBox8.TabIndex = 7;
            this.rTextBox8.TabStop = false;
            this.rTextBox8.Type = rComponents.rTextBoxType.Text;
            this.rTextBox8.ValidatingProperty = null;
            this.rTextBox8.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // rLabel8
            // 
            this.rLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel8.BackColor = System.Drawing.Color.Transparent;
            this.rLabel8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel8.Location = new System.Drawing.Point(5, 109);
            this.rLabel8.Name = "rLabel8";
            this.rLabel8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rLabel8.Size = new System.Drawing.Size(52, 20);
            this.rLabel8.TabIndex = 6;
            this.rLabel8.Text = "Mobile:";
            // 
            // rTextBox7
            // 
            this.rTextBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox7.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox7.Culture = null;
            this.rTextBox7.FieldName = "نام پدر";
            this.rTextBox7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox7.Language = rComponents.TextboxLanguage.Farsi;
            this.rTextBox7.Location = new System.Drawing.Point(421, 105);
            this.rTextBox7.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox7.MaximumValue = null;
            this.rTextBox7.MinimumValue = null;
            this.rTextBox7.Name = "rTextBox7";
            this.rTextBox7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rTextBox7.Size = new System.Drawing.Size(241, 22);
            this.rTextBox7.TabIndex = 4;
            this.rTextBox7.TabStop = false;
            this.rTextBox7.Type = rComponents.rTextBoxType.Text;
            this.rTextBox7.ValidatingProperty = null;
            this.rTextBox7.ValidationType = rComponents.ValidationType.None;
            // 
            // rLabel7
            // 
            this.rLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel7.BackColor = System.Drawing.Color.Transparent;
            this.rLabel7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel7.Location = new System.Drawing.Point(681, 107);
            this.rLabel7.Name = "rLabel7";
            this.rLabel7.Size = new System.Drawing.Size(82, 20);
            this.rLabel7.TabIndex = 3;
            this.rLabel7.Text = "شماره تلفن:";
            // 
            // rTextBox6
            // 
            this.rTextBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox6.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox6.Culture = null;
            this.rTextBox6.FieldName = "نام پدر انگلیسی";
            this.rTextBox6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox6.Language = rComponents.TextboxLanguage.English;
            this.rTextBox6.Location = new System.Drawing.Point(115, 77);
            this.rTextBox6.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox6.MaximumValue = null;
            this.rTextBox6.MinimumValue = null;
            this.rTextBox6.Name = "rTextBox6";
            this.rTextBox6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox6.Size = new System.Drawing.Size(256, 22);
            this.rTextBox6.TabIndex = 5;
            this.rTextBox6.TabStop = false;
            this.rTextBox6.Type = rComponents.rTextBoxType.Text;
            this.rTextBox6.ValidatingProperty = null;
            this.rTextBox6.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // rTextBox4
            // 
            this.rTextBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox4.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox4.Culture = null;
            this.rTextBox4.FieldName = "نام خانوادگی انگلیسی";
            this.rTextBox4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox4.Language = rComponents.TextboxLanguage.English;
            this.rTextBox4.Location = new System.Drawing.Point(115, 52);
            this.rTextBox4.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox4.MaximumValue = null;
            this.rTextBox4.MinimumValue = null;
            this.rTextBox4.Name = "rTextBox4";
            this.rTextBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox4.Size = new System.Drawing.Size(256, 22);
            this.rTextBox4.TabIndex = 4;
            this.rTextBox4.TabStop = false;
            this.rTextBox4.Type = rComponents.rTextBoxType.Text;
            this.rTextBox4.ValidatingProperty = null;
            this.rTextBox4.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // rLabel6
            // 
            this.rLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel6.BackColor = System.Drawing.Color.Transparent;
            this.rLabel6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel6.Location = new System.Drawing.Point(5, 79);
            this.rLabel6.Name = "rLabel6";
            this.rLabel6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rLabel6.Size = new System.Drawing.Size(93, 20);
            this.rLabel6.TabIndex = 0;
            this.rLabel6.Text = "Father Name:";
            // 
            // rTextBox5
            // 
            this.rTextBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox5.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox5.Culture = null;
            this.rTextBox5.FieldName = "نام پدر";
            this.rTextBox5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox5.Language = rComponents.TextboxLanguage.Farsi;
            this.rTextBox5.Location = new System.Drawing.Point(421, 77);
            this.rTextBox5.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox5.MaximumValue = null;
            this.rTextBox5.MinimumValue = null;
            this.rTextBox5.Name = "rTextBox5";
            this.rTextBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rTextBox5.Size = new System.Drawing.Size(241, 22);
            this.rTextBox5.TabIndex = 2;
            this.rTextBox5.TabStop = false;
            this.rTextBox5.Type = rComponents.rTextBoxType.Text;
            this.rTextBox5.ValidatingProperty = null;
            this.rTextBox5.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rTextBox5.Leave += new System.EventHandler(this.rTextBox5_Leave);
            // 
            // rLabel4
            // 
            this.rLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel4.BackColor = System.Drawing.Color.Transparent;
            this.rLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel4.Location = new System.Drawing.Point(20, 54);
            this.rLabel4.Name = "rLabel4";
            this.rLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rLabel4.Size = new System.Drawing.Size(74, 20);
            this.rLabel4.TabIndex = 0;
            this.rLabel4.Text = "LastName:";
            // 
            // rLabel5
            // 
            this.rLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel5.BackColor = System.Drawing.Color.Transparent;
            this.rLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel5.Location = new System.Drawing.Point(681, 79);
            this.rLabel5.Name = "rLabel5";
            this.rLabel5.Size = new System.Drawing.Size(50, 20);
            this.rLabel5.TabIndex = 0;
            this.rLabel5.Text = "نام پدر:";
            // 
            // rTextBox3
            // 
            this.rTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox3.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox3.Culture = null;
            this.rTextBox3.FieldName = "نام خانوادگی";
            this.rTextBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox3.Language = rComponents.TextboxLanguage.Farsi;
            this.rTextBox3.Location = new System.Drawing.Point(421, 52);
            this.rTextBox3.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox3.MaximumValue = null;
            this.rTextBox3.MinimumValue = null;
            this.rTextBox3.Name = "rTextBox3";
            this.rTextBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rTextBox3.Size = new System.Drawing.Size(241, 22);
            this.rTextBox3.TabIndex = 1;
            this.rTextBox3.TabStop = false;
            this.rTextBox3.Type = rComponents.rTextBoxType.Text;
            this.rTextBox3.ValidatingProperty = null;
            this.rTextBox3.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rTextBox3.Leave += new System.EventHandler(this.rTextBox3_Leave);
            // 
            // rLabel3
            // 
            this.rLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel3.BackColor = System.Drawing.Color.Transparent;
            this.rLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel3.Location = new System.Drawing.Point(681, 54);
            this.rLabel3.Name = "rLabel3";
            this.rLabel3.Size = new System.Drawing.Size(88, 20);
            this.rLabel3.TabIndex = 0;
            this.rLabel3.Text = "نام خانوادگی:";
            // 
            // rTextBox2
            // 
            this.rTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox2.Culture = null;
            this.rTextBox2.FieldName = "نام انگلیسی";
            this.rTextBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox2.Language = rComponents.TextboxLanguage.English;
            this.rTextBox2.Location = new System.Drawing.Point(115, 27);
            this.rTextBox2.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox2.MaximumValue = null;
            this.rTextBox2.MinimumValue = null;
            this.rTextBox2.Name = "rTextBox2";
            this.rTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rTextBox2.Size = new System.Drawing.Size(256, 22);
            this.rTextBox2.TabIndex = 3;
            this.rTextBox2.TabStop = false;
            this.rTextBox2.Type = rComponents.rTextBoxType.Text;
            this.rTextBox2.ValidatingProperty = null;
            this.rTextBox2.ValidationType = rComponents.ValidationType.NotEmpty;
            // 
            // rLabel2
            // 
            this.rLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel2.BackColor = System.Drawing.Color.Transparent;
            this.rLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel2.Location = new System.Drawing.Point(41, 29);
            this.rLabel2.Name = "rLabel2";
            this.rLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rLabel2.Size = new System.Drawing.Size(48, 20);
            this.rLabel2.TabIndex = 0;
            this.rLabel2.Text = "Name:";
            // 
            // rTextBox1
            // 
            this.rTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.rTextBox1.Culture = null;
            this.rTextBox1.FieldName = "نام";
            this.rTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBox1.Language = rComponents.TextboxLanguage.Farsi;
            this.rTextBox1.Location = new System.Drawing.Point(421, 27);
            this.rTextBox1.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.rTextBox1.MaximumValue = null;
            this.rTextBox1.MinimumValue = null;
            this.rTextBox1.Name = "rTextBox1";
            this.rTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rTextBox1.Size = new System.Drawing.Size(241, 22);
            this.rTextBox1.TabIndex = 0;
            this.rTextBox1.TabStop = false;
            this.rTextBox1.Type = rComponents.rTextBoxType.Text;
            this.rTextBox1.ValidatingProperty = null;
            this.rTextBox1.ValidationType = rComponents.ValidationType.NotEmpty;
            this.rTextBox1.Leave += new System.EventHandler(this.rTextBox1_Leave);
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rLabel1.Location = new System.Drawing.Point(681, 29);
            this.rLabel1.Name = "rLabel1";
            this.rLabel1.Size = new System.Drawing.Size(29, 20);
            this.rLabel1.TabIndex = 0;
            this.rLabel1.Text = "نام:";
            // 
            // frmReservePersonDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1000, 229);
            this.Controls.Add(this.rGroupBox1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmReservePersonDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "مشخصـات فــــردی";
            this.Load += new System.EventHandler(this.frmPersonDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            this.rGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTranslate;
        private rComponents.rGroupBox rGroupBox1;
        private rComponents.rTextBox rTextBox6;
        private rComponents.rTextBox rTextBox4;
        private rComponents.rLabel rLabel6;
        private rComponents.rTextBox rTextBox5;
        private rComponents.rLabel rLabel4;
        private rComponents.rLabel rLabel5;
        private rComponents.rTextBox rTextBox3;
        private rComponents.rLabel rLabel3;
        private rComponents.rTextBox rTextBox2;
        private rComponents.rLabel rLabel2;
        private rComponents.rTextBox rTextBox1;
        private rComponents.rLabel rLabel1;
        private rComponents.rTextBox rTextBox8;
        private rComponents.rLabel rLabel8;
        private rComponents.rTextBox rTextBox7;
        private rComponents.rLabel rLabel7;
    }
}