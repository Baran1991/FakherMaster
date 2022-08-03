using System.Collections;
using System.Collections.Generic;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;
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
    /// Summary description for rptSignupReciept.
    /// </summary>
    public partial class rptQuitFirstReceipt : Report, IConfigurableReport
    {
        public rptQuitFirstReceipt()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public static string GetReceiptNote(Register register)
        {
            return register.Period.QuitReceiptNote;
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش رسید انصراف"; }
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
                               new List<object> {"وضعیت مالی", "FarsiFinancialStatusVerboseText"}                               
                           };
            }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowStructure = frm.ShowMajor = true;
            frm.ShowLesson = frm.ShowSection = true;
            frm.IsRightToLeft = true;
            frm.OptionalSection = frm.OptionalLesson = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            IList<Register> registers;

            if(frm.SectionItem != null)
            {
                IList<Participate> participates = Participate.GetParticipates(frm.Period, frm.SectionItem.Lesson);
                registers = participates.Where(x => x.SectionItem.Id == frm.SectionItem.Id).Select(x => x.Register).ToList();
            }
            else if(frm.Lesson != null)
            {
                IList<Participate> participates = Participate.GetParticipates(frm.Period, frm.Lesson);
                registers = participates.Select(x => x.Register).ToList();
            }
            else
            {
                registers = Register.GetRegisters(frm.Period, frm.Major);
            }

            DataSet = registers;
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion
    }
}