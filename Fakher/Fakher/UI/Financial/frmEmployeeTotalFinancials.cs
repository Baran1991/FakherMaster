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
    public partial class frmEmployeeTotalFinancials : rRadForm
    {
        private Employee employee;
        public FinancialItem SelectedObject { get; set; }
        public frmEmployeeTotalFinancials(Core.DomainModel.Employee person)
        {
            InitializeComponent();

            employee = person;
            rDatePicker1.Date = PersianDate.Today;
            rDatePicker2.Date = PersianDate.Today;
        }

        private void rBtnPayoff_Click(object sender, EventArgs e)
        {
            PersianDate date1 = rDatePicker1.Date;
            PersianDate date2 = rDatePicker2.Date;
            if (date1 == null | date2 == null)
            {
                rMessageBox.ShowError("تاریخ را وارد کنید.");
                return;
            }
            rptFaEmployeeFinancialReportDates rpt = new rptFaEmployeeFinancialReportDates();
            rpt.Employee = employee;
            rpt.DateFrom = date1;
            rpt.DateTo = date2;
            rpt.PrepareDataset(null);
            rpt.Apply(null);
            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog(this);
        }

       
      
    }
}
