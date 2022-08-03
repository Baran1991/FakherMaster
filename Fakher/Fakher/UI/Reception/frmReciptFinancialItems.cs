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
    public partial class frmReciptFinancialItems : rRadDetailForm
    {
        private Register selectedRegister;

        public frmReciptFinancialItems(Register register)
        {
            InitializeComponent();
            selectedRegister = register;
            
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ سند مالی", ObjectProperty = "Date.ToShortDateString()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "سرفصل", ObjectProperty = "HeadingText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "DescriptionText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Document.Person.FarsiFullname" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "بدهکار", ObjectProperty = "DebtText", AggregateSummary = AggregateSummary.Sum });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "بستانکار", ObjectProperty = "CreditText", AggregateSummary = AggregateSummary.Sum });

            rGridView1.DataBind(register.FinancialDocument.Items);

            //            FinancialDocument allDocument = new FinancialDocument() {Person = register.Student};
            //            foreach (Register reg in register.Student.Registers)
            //                foreach (FinancialItem item in reg.FinancialDocument.Items)
            //                    allDocument.AddItem(item.Clone());
            //
            //            foreach (Certificate certificate in register.Student.GetCertificates())
            //                foreach (FinancialItem item in certificate.FinancialDocument.Items)
            //                    allDocument.AddItem(item.Clone());
            
        }


        
        private void button1_Click(object sender, EventArgs e)
        {
            rptFaStudentFinancialReciept rpt = new rptFaStudentFinancialReciept();
            rpt.student = selectedRegister.Student;
            rpt.register = selectedRegister;
            var items = rGridView1.GetCheckedObjects<FinancialItem>();
            if(items.Count==0)
            {
                rMessageBox.ShowError("لطفا چند آیتم انتخاب کنید!");
                return;
            }
            //rpt.Date = rDatePicker1.Date;
            rpt.fItems = new List<FinancialItem>();

            rpt.ReportName = "رسید " + items[0].HeadingText;
            rpt.fItems = items;
            rpt.PrepareDataset(null);
            rpt.Apply(null);
            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog(this);
        }
    }
}
