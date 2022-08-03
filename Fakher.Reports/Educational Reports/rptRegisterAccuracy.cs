using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;
using rComponents;

namespace Fakher.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptChequeList.
    /// </summary>
    public partial class rptRegisterAccuracy : Report, IConfigurableReport
    {
        public rptRegisterAccuracy()
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
            txtReportName.Value = ReportName;
        }

        public static string GetLastStatus(Register register)
        {
            return register.Student.GetPrevEducationalStatus(register.Major, register.Period);
        }

        public static string GetFinancialItemsText(Register register)
        {
            string items = "";
            foreach (FinancialItem item in register.FinancialDocument.PaymentItems)
            {
                items += "مبلغ " + item.Amount.ToString("C0") + " طی " + item.DescriptionText + "\r\n";
            }
            return items;
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return true; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام", "Student.FarsiFirstName"},
                               new List<object> {"نام خانوادگی", "Student.FarsiLastName"},
                               new List<object> {"نوع ثبت نام", "EnrollmentTypeText"},
                           };
            }
        }

        public string ReportName
        {
            get { return "گزارش صحت ثبت نام دانشجویان در ترم جاری"; }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowStructure = true;
            frm.ShowMajor = true;
            frm.ShowLesson = false;
            frm.ShowSection = false;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            IList<Register> registers = Register.GetRegisters(frm.Period, frm.Major);
            DataSet = registers;
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion
    }
}