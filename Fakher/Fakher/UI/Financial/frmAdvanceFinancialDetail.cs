using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Reports;
using Fakher.UI.Report;
using rComponents;

namespace Fakher.UI.Financial
{
    public partial class frmAdvanceFinancialDetail : rRadDetailForm
    {
        public bool IsCustomed { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

        public frmAdvanceFinancialDetail(FinancialDocument document)
        {
            InitializeComponent();
            SetProcessingObject(document);
            financialDocumentView1.Databind(document);
        }

        public frmAdvanceFinancialDetail(IList<FinancialItem> items)
        {
            InitializeComponent();
            FinancialDocument document = new FinancialDocument();
            foreach (var item in items)
                document.Items.Add(item);

            SetProcessingObject(document);
            financialDocumentView1.Databind(document);
        }

        private void financialDocumentView1_Add(object sender, EventArgs e)
        {
            FinancialDocument document = GetProcessingObject<FinancialDocument>();
            FinancialItem financialItem = new FinancialItem();
            frmFinancialItemDetail frm = new frmFinancialItemDetail(financialItem);
            if (!frm.ProcessObject())
                return;
            document.AddItem(financialItem);
            document.Save();
            
            financialDocumentView1.Databind(document);
        }

        private void financialDocumentView1_Delete(object sender, EventArgs e)
        {
            FinancialDocument document = GetProcessingObject<FinancialDocument>();
            FinancialItem financialItem = financialDocumentView1.GetSelectedItem();
            financialItem.Document.Items.Remove(financialItem);
            financialItem.Document.Save();

            financialDocumentView1.Databind(document);
        }

        private void frmAdvanceFinancialDetail_Load(object sender, EventArgs e)
        {
            if(IsCustomed)
            {
                financialDocumentView1.CanAdd = CanAdd;
                financialDocumentView1.CanEdit = CanEdit;
                financialDocumentView1.CanDelete = CanDelete;
            }
        }

        private void toolStripBtnReport_Click(object sender, EventArgs e)
        {
            rptFaEmployeeFinancialReport rpt = new rptFaEmployeeFinancialReport();
            rpt.Employee = Program.CurrentEmployee;
            rpt.Date = PersianDate.Today;
            rpt.PrepareDataset(null);
            rpt.Apply(null);
            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog(this);
        }
    }
}
