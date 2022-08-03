namespace Fakher.UI.Report
{
    partial class frmReportViewer
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
            this.reportViewer1 = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ParametersAreaVisible = false;
            this.reportViewer1.Resources.ProcessingReportMessage = "ســـاخــــــت گــزارش...";
            this.reportViewer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportViewer1.Size = new System.Drawing.Size(603, 326);
            this.reportViewer1.TabIndex = 0;
            //this.reportViewer1.RenderingBegin += new System.ComponentModel.CancelEventHandler(this.reportViewer1_RenderingBegin);
            this.reportViewer1.RenderingBegin += new Telerik.ReportViewer.Common.RenderingBeginEventHandler(this.reportViewer1_RenderingBegin);
            this.reportViewer1.UpdateUI += new System.EventHandler(this.reportViewer1_UpdateUI);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 326);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReportViewer";
            this.Text = "نمایش گزارش";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReportViewer_FormClosed);
            this.Load += new System.EventHandler(this.frmReportViewer_Load);
            this.Shown += new System.EventHandler(this.frmReportViewer_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.ReportViewer.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Timer timer1;
    }
}