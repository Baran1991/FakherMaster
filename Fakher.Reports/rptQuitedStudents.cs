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
    public partial class rptQuitedStudents : Report, IConfigurableReport
    {
        public rptQuitedStudents()
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
            get { return "گزارش دانشجویان انصرافی تک درس"; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام", "Register.Student.FarsiFirstName"},
                               new List<object> {"نام خانوادگی", "Register.Student.FarsiLastName"},
                               new List<object> {"نوع ثبت نام", "Register.EnrollmentTypeText"},
                               new List<object> {"وضعیت مالی", "Register.FarsiFinancialStatusVerboseText" }
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
            IList<Participate> participate;

            if (frm.SectionItem != null)
            {
                var participates = Participate.GetQuitedParticipates(frm.Period.Department, frm.StartDate, frm.EndDate);
                participate = participates.Where(x => x.SectionItem.Id == frm.SectionItem.Id).ToList();
            }
            else if (frm.Lesson != null)
            {
                var participates = Participate.GetQuitedParticipates(frm.Period.Department, frm.StartDate, frm.EndDate);
                participate = participates.Where(x => x.SectionItem.Item.Lesson.Id == frm.Lesson.Id).ToList();

               
            }
            else
            {
                participate = Participate.GetQuitedParticipates(frm.Period.Department, frm.StartDate, frm.EndDate).Where(m=>m.Register.Period==frm.Period&&m.Register.Major==frm.Major).ToList();
                
            }

            DataSet = participate;


            //DataSet = Participate.GetQuitedParticipates(frm.Period.Department, frm.StartDate, frm.EndDate);
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }
    }
}