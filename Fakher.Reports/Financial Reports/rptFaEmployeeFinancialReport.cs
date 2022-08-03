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
    public partial class rptFaEmployeeFinancialReport : Report, IConfigurableReport
    {
        public Employee Employee { get; set; }
        public PersianDate Date { get; set; }

        public rptFaEmployeeFinancialReport()
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
            get { return "گزارش دریافت های مالی"; }
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
            IList<FinancialItem> items = Employee.GetInsertedFinancialItems(Date, Date)
                .Where(x => x.Type == FinancialType.Credit)
                .ToList();
            DataSet = items.Where(x => x.IsPaying && !x.IsClone).ToList();
        }

        public void Apply(IReportParameterForm frm)
        {
            txtReportName.Value = ReportName + " " + Employee.FarsiFullname + " در تاریخ " + Date;
            DataSource = DataSet;
        }

        #endregion
    }
}