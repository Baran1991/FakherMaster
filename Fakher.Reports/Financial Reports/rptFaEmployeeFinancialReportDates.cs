using System.Collections;
using System.Collections.Generic;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;
using rComponents;
using System.Linq;

namespace Fakher.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptDiscountedRegisters.
    /// </summary>
    public partial class rptFaEmployeeFinancialReportDates : Report, IConfigurableReport
    {
        public Employee Employee { get; set; }
        public PersianDate DateFrom { get; set; }
        public PersianDate DateTo { get; set; }
        public rptFaEmployeeFinancialReportDates()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public static string TodayDate()
        {
            return PersianDate.Today.ToShortDateString();
        }

        public static string GetMajor(FinancialItem item)
        {
            try
            {
                Person person = item.Document.Person.UnProxy() as Person;
                Student student = person as Student;
                Register register = student.GetRegister(item);
                return register.Major.Name;
            }
            catch (Exception ex)
            {
                return "نامشخص";
            }
        }

        private void txtReportName_ItemDataBinding(object sender, EventArgs e)
        {

        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش مجموع دریافت های مالی"; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>();
            }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowStructure = false;
            frm.ShowMajor = false;
            frm.ShowDate = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            IList<FinancialItem> items = Employee.GetInsertedFinancialItems(DateFrom, DateTo)
                .Where(x => x.Type == FinancialType.Credit& x.IsPaying && !x.IsClone)
                .ToList();
            //DataSet = items.Where(x => x.IsPaying && !x.IsClone);
            var lst = new List<FinancialItem>();
            lst.Add(new FinancialItem() { Amount = items.Where(m => m.Is<Cash>() | m.Is<Receipt>()).Sum(m => m.Payment.CashAmount), Text = "پرداخت نقدی" ,CreateDate=DateTo,Date=DateFrom});
            lst.Add(new FinancialItem() { Amount = items.Where(m => m.Is<ElectronicPayment>() ).Sum(m => m.Payment.ElectronicPaymentAmount), Text = "پرداخت الکترونیکی", CreateDate = DateTo, Date = DateFrom });
            lst.Add(new FinancialItem() { Amount = items.Where(m => m.Is<Cheque>()).Sum(m => m.Payment.ChequeAmount), Text = "چک", CreateDate = DateTo, Date = DateFrom });
            DataSet = lst;

        }

        public void Apply(IReportParameterForm frm)
        {
            txtReportName.Value = ReportName + " " + Employee.FarsiFullname + " از تاریخ " + DateFrom +" تا تاریخ "+DateTo;
            DataSource = DataSet;
        }

        #endregion
    }
}