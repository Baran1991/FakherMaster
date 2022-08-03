using System.Collections;
using System.Collections.Generic;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;
using rComponents;

namespace Fakher.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptStudentContacts.
    /// </summary>
    public partial class rptFullQuitedStudents : Report, IConfigurableReport
    {
        public rptFullQuitedStudents()
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

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return true; }
        }

        public string ReportName
        {
            get { return "گزارش دانشجویان انصرافی کامل"; }
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
            frm.ShowDate = true;
            frm.ShowStructure = frm.ShowMajor = true;
            frm.ShowLesson = frm.ShowSection = true;
            frm.IsRightToLeft = true;
            frm.OptionalSection = frm.OptionalLesson = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            IList<Register> registers;

            if (frm.SectionItem != null)
            {
                IList<Participate> participates = Participate.GetParticipates(frm.Period, frm.SectionItem.Lesson);
                registers = participates.Where(x => x.SectionItem.Id == frm.SectionItem.Id).Select(x => x.Register).Where(m=>m.Type==RegisterType.FullQuited).ToList();
            }
            else if (frm.Lesson != null)
            {
                IList<Participate> participates = Participate.GetParticipates(frm.Period, frm.Lesson);
                registers = participates.Select(x => x.Register).Where(m => m.Type == RegisterType.FullQuited).ToList();
            }
            else
            {
                registers = Register.GetRegisters(frm.Period, frm.Major).Where(m => m.Type == RegisterType.FullQuited).ToList();
            }

            DataSet = registers;


            //DataSet = Register.GetFullQuitedRegisters(frm.StartDate, frm.EndDate);
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }
    }
}