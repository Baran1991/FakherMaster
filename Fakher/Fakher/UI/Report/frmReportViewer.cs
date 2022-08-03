using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rComponents;
using Telerik.ReportViewer.WinForms;

namespace Fakher.UI.Report
{
    public partial class frmReportViewer : Form
    {
        public bool AutoPrint { get; set; }
        public bool CanPrint { get; set; }
        public bool CanExport { get; set; }

        public frmReportViewer(Telerik.Reporting.Report report)
        {
            InitializeComponent();
            CanPrint = true;
            CanExport = true;
            GC.WaitForPendingFinalizers();
            GC.Collect();
            reportViewer1.Report = report;
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            reportViewer1.ShowPrintButton = CanPrint;
            reportViewer1.ShowExportButton = CanExport;
            reportViewer1.RefreshReport();
        }

        public void OnSuccess()
        {
            if (AutoPrint)
                reportViewer1.PrintReport();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (reportViewer1.ProcessingState == ProcessingState.Success)
            {
                timer1.Enabled = false;
                OnSuccess();
            }
        }

        private void frmReportViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            reportViewer1.Dispose();
        }

        private void reportViewer1_RenderingBegin(object sender, CancelEventArgs e)
        {
            GC.Collect();
        }

        private void reportViewer1_UpdateUI(object sender, EventArgs e)
        {
            GC.Collect();
        }

        private void frmReportViewer_Shown(object sender, EventArgs e)
        {
            Program.EndWaiting();
        }
    }
}
