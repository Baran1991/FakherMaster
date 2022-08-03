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

    public partial class rptTeacherPayments : Report, IConfigurableReport
    {
        public rptTeacherPayments()
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

        private void txtReportName_ItemDataBinding(object sender, EventArgs e)
        {

        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return true; }
        }

        public string ReportName
        {
            get { return "گزارش پرداخت های مدرس"; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام", "FarsiFirstName"},
                               new List<object> {"نام خانوادگی", "FarsiLastName"}
                           };
            }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowDate = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            IQueryable<Teacher> teachers = Teacher.GetActiveTeachers();
            DataSet = teachers;
        }

        public void Apply(IReportParameterForm frm)
        {
            List<Data> datas = new List<Data>();
            foreach (Teacher teacher in DataSet)
            {
                List<Payroll> payrolls = teacher.Payrolls.Where(x => x.StartDate >= frm.StartDate && x.StartDate <= frm.EndDate).ToList();

                Data data =new Data();
                data.Teacher = teacher;
                data.PresenceHours = teacher.GetPresences(frm.StartDate, frm.EndDate).Sum(x => x.Duration.TotalHours);
                data.SectionsCount = teacher.GetPresenceSections(frm.StartDate, frm.EndDate).Count();
                data.ReplacementHours = teacher.GetPresenceReplacements(frm.StartDate, frm.EndDate).Sum(x => x.ReplacementHours);

                data.WorkingAmount = payrolls.SelectMany(x => x.GetItems(PayrollItemHeading.Working)).Sum(x => x.Amount);

                data.OverTimeAmount = payrolls.SelectMany(x => x.GetItems(PayrollItemHeading.OverTime)).Sum(x => x.Amount);
                data.OverTimeAmount += payrolls.SelectMany(x => x.GetItems(PayrollItemHeading.HolidayOverTime)).Sum(x => x.Amount);
                
                data.InsuranceAmount = payrolls.SelectMany(x => x.GetItems(PayrollItemHeading.Insurance)).Sum(x => x.Amount);
                data.TaxAmount = payrolls.SelectMany(x => x.GetItems(PayrollItemHeading.Tax)).Sum(x => x.Amount);

                data.OtherCreditAmount = payrolls.SelectMany(x => x.GetCreditItems(PayrollItemHeading.Other)).Sum(x => x.Amount);
                data.OtherCreditAmount += payrolls.SelectMany(x => x.GetCreditItems(PayrollItemHeading.Transportation)).Sum(x => x.Amount);
                data.OtherCreditAmount += payrolls.SelectMany(x => x.GetCreditItems(PayrollItemHeading.Food)).Sum(x => x.Amount);
                data.OtherCreditAmount += payrolls.SelectMany(x => x.GetCreditItems(PayrollItemHeading.Uniform)).Sum(x => x.Amount);

                data.OtherDebtAmount = payrolls.SelectMany(x => x.GetDebtItems(PayrollItemHeading.Other)).Sum(x => x.Amount);
                data.OtherDebtAmount += payrolls.SelectMany(x => x.GetDebtItems(PayrollItemHeading.Transportation)).Sum(x => x.Amount);
                data.OtherDebtAmount += payrolls.SelectMany(x => x.GetDebtItems(PayrollItemHeading.Food)).Sum(x => x.Amount);
                data.OtherDebtAmount += payrolls.SelectMany(x => x.GetDebtItems(PayrollItemHeading.Uniform)).Sum(x => x.Amount);

                data.TotalPayment = payrolls.Sum(x => x.PayableAmount);

                datas.Add(data);
            }
            DataSource = datas;
        }

        #endregion

        public class Data
        {
            public Teacher Teacher { get; set; }
            public double PresenceHours { get; set; }
            public int SectionsCount { get; set; }
            public double ReplacementHours { get; set; }
            public double WorkingAmount { get; set; }
            public double OverTimeAmount { get; set; }
            public double InsuranceAmount { get; set; }
            public double TaxAmount { get; set; }
            public double OtherCreditAmount { get; set; }
            public double OtherDebtAmount { get; set; }

            public double TotalPayment { get; set; }
        }
    }
}