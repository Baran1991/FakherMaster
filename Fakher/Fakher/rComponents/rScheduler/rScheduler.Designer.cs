namespace rComponents
{
    partial class rScheduler
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
            Telerik.WinControls.UI.DateTimeInterval dateTimeInterval1 = new Telerik.WinControls.UI.DateTimeInterval();
            this.radSchedulerNavigator1 = new Telerik.WinControls.UI.RadSchedulerNavigator();
            this.radScheduler1 = new Telerik.WinControls.UI.RadScheduler();
            this.lnkPrint = new System.Windows.Forms.LinkLabel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.radSchedulerNavigator1)).BeginInit();
            this.radSchedulerNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScheduler1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radSchedulerNavigator1
            // 
            this.radSchedulerNavigator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radSchedulerNavigator1.AssociatedScheduler = this.radScheduler1;
            this.radSchedulerNavigator1.Controls.Add(this.lnkPrint);
            this.radSchedulerNavigator1.DateFormat = "yyyy/MM/dd";
            this.radSchedulerNavigator1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radSchedulerNavigator1.Location = new System.Drawing.Point(3, 3);
            this.radSchedulerNavigator1.Name = "radSchedulerNavigator1";
            this.radSchedulerNavigator1.NavigationStepType = Telerik.WinControls.UI.NavigationStepTypes.Day;
            this.radSchedulerNavigator1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.radSchedulerNavigator1.RootElement.StretchVertically = false;
            this.radSchedulerNavigator1.Size = new System.Drawing.Size(937, 74);
            this.radSchedulerNavigator1.TabIndex = 4;
            this.radSchedulerNavigator1.Text = "radSchedulerNavigator1";
            // 
            // radScheduler1
            // 
            dateTimeInterval1.End = new System.DateTime(((long)(0)));
            this.radScheduler1.AccessibleInterval = dateTimeInterval1;
            this.radScheduler1.ActiveViewType = Telerik.WinControls.UI.SchedulerViewType.Week;
            this.radScheduler1.AllowAppointmentMove = false;
            this.radScheduler1.AllowAppointmentResize = false;
            this.radScheduler1.AllowToolTips = true;
            this.radScheduler1.AppointmentTitleFormat = null;
            this.radScheduler1.Culture = new System.Globalization.CultureInfo("fa-IR");
            this.radScheduler1.DataSource = null;
            this.radScheduler1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radScheduler1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radScheduler1.GroupType = Telerik.WinControls.UI.GroupType.None;
            this.radScheduler1.HeaderFormat = "dddd dd MMMM";
            this.radScheduler1.Location = new System.Drawing.Point(0, 0);
            this.radScheduler1.Name = "radScheduler1";
            this.radScheduler1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            // 
            // 
            // 
            this.radScheduler1.RootElement.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.radScheduler1.ShowAppointmentStatus = false;
            this.radScheduler1.ShowNavigationElements = false;
            this.radScheduler1.Size = new System.Drawing.Size(937, 464);
            this.radScheduler1.TabIndex = 1;
            this.radScheduler1.Text = "radScheduler1";
            this.radScheduler1.ContextMenuShowing += new System.EventHandler<Telerik.WinControls.UI.SchedulerContextMenuShowingEventArgs>(this.radScheduler1_ContextMenuShowing);
            this.radScheduler1.ActiveViewChanging += new System.EventHandler<Telerik.WinControls.UI.SchedulerViewChangingEventArgs>(this.radScheduler1_ActiveViewChanging);
            // 
            // lnkPrint
            // 
            this.lnkPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lnkPrint.AutoSize = true;
            this.lnkPrint.BackColor = System.Drawing.Color.Transparent;
            this.lnkPrint.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPrint.Location = new System.Drawing.Point(12, 9);
            this.lnkPrint.Name = "lnkPrint";
            this.lnkPrint.Size = new System.Drawing.Size(97, 13);
            this.lnkPrint.TabIndex = 0;
            this.lnkPrint.TabStop = true;
            this.lnkPrint.Text = "چـــاپ نـمـای جـاری";
            this.lnkPrint.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrint_LinkClicked);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.radSchedulerNavigator1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(943, 544);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.radScheduler1);
            this.panel1.Location = new System.Drawing.Point(3, 77);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(937, 464);
            this.panel1.TabIndex = 7;
            // 
            // rScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "rScheduler";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(943, 544);
            this.Load += new System.EventHandler(this.rScheduler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radSchedulerNavigator1)).EndInit();
            this.radSchedulerNavigator1.ResumeLayout(false);
            this.radSchedulerNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScheduler1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadSchedulerNavigator radSchedulerNavigator1;
        private Telerik.WinControls.UI.RadScheduler radScheduler1;
        private System.Windows.Forms.LinkLabel lnkPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}
