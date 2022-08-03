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
    public partial class frmRegisterFinancialDetail : rRadDetailForm
    {
        public bool IsCustomed { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        private Register selectedRegister;
        public frmRegisterFinancialDetail(Register register)
        {
            InitializeComponent();
            SetProcessingObject(register);
            selectedRegister = register;
            rPageView1.SelectedPage = radPageViewPage1;

            financialDocumentView1.Databind(register.FinancialDocument);
            
            
//            FinancialDocument allDocument = new FinancialDocument() {Person = register.Student};
//            foreach (Register reg in register.Student.Registers)
//                foreach (FinancialItem item in reg.FinancialDocument.Items)
//                    allDocument.AddItem(item.Clone());
//
//            foreach (Certificate certificate in register.Student.GetCertificates())
//                foreach (FinancialItem item in certificate.FinancialDocument.Items)
//                    allDocument.AddItem(item.Clone());

            FinancialDocument generalDocument = register.Student.GetGeneralDocument();
            financialDocumentView2.Databind(generalDocument);
        }

        private void financialDocumentView1_Add(object sender, EventArgs e)
        {
            rptFaStudentFinancialDetails rpt = new rptFaStudentFinancialDetails();
            rpt.document = selectedRegister.Student.GetGeneralDocument();
            rpt.PrepareDataset(null);
            rpt.Apply(null);
            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog(this);
            //FinancialDocument document = GetProcessingObject<FinancialDocument>();
            //FinancialItem financialItem = new FinancialItem();
            //frmFinancialItemDetail frm = new frmFinancialItemDetail(financialItem);
            //if (!frm.ProcessObject())
            //    return;
            //document.AddItem(financialItem);
            //document.Save();

            //financialDocumentView1.Databind(document);
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
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            rptFaStudentFinancialDetails rpt = new rptFaStudentFinancialDetails();
            rpt.document = selectedRegister.Student.GetGeneralDocument();
            rpt.PrepareDataset(null);
            rpt.Apply(null);
            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rptFaStudentFinancialDetails rpt = new rptFaStudentFinancialDetails();
            rpt.document = selectedRegister.FinancialDocument;
            rpt.PrepareDataset(null);
            rpt.Apply(null);
            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog(this);



        }
    }
}
