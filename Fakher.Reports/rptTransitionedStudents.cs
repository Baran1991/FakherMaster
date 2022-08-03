using System.Collections;
using System.Collections.Generic;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;
using rComponents;
using System.Linq;
namespace Fakher.Reports
{
    using DataAccessLayer;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptStudentContacts.
    /// </summary>
    public partial class rptTransitionedStudents : Report, IConfigurableReport
    {
        private IReportParameterForm mFrm;
        public rptTransitionedStudents()
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
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش دانشجویان انتقالی"; }
        }
        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"تاریخ انتقال", "Register.Transition.Date"},
                               new List<object> {"نام و نام خانوادگی", "Register.Student.FarsiFullname"},
                              new List<object> {"درس/سطح", "SectionItem.Lesson.Name"},
                               new List<object> {"گروه", "SectionItem.Section.FarsiName"},
                               new List<object> {"نقد", "Register.FinancialDocument.CashBalance", typeof(float)},
                               new List<object> {"الکترونیک", "Register.FinancialDocument.EPaymentBalance", typeof(float)},
                               new List<object> {"چک", "Register.FinancialDocument.ChequeBalance()", typeof(float)},
                               new List<object> {"شعبه مقصد", "Register.Transition.Branch.Name" }
                           };
            }
        }

    

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            mFrm = frm;
            frm.ShowStructure = true;
            frm.ShowMajor = true;
            frm.ShowLesson = true;
            frm.ShowSection = true;
            frm.OptionalLesson = true;
            frm.OptionalSection = true;
            frm.ShowParam1 = true;

            frm.ShowDate = true;
            frm.Param1Text = "شعبه مقصد:";
            
            frm.Param1DataSource = DbContext.GetAllEntities<Branch>();
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            var branch = frm.Param1SelectedValue as Branch;
            IList<Participate> totalParticipates;
            if (frm.SectionItem != null)
                totalParticipates = frm.SectionItem.GetAllParticipatesWithAllStatus();
            else if (frm.Lesson != null)
                totalParticipates = Participate.GetParticipates(frm.Period, frm.Lesson);
            else
                totalParticipates = Participate.GetParticipates(frm.Period, frm.Major);
            var query = from participate in totalParticipates
                        where participate.Register.Transition != null
                       && participate.Register.Transition.Date<=frm.EndDate 
                       && participate.Register.Transition.Date>=frm.StartDate
                       && participate.Register.Transition.Branch==branch
                        orderby participate.Register.Student.FarsiLastName
                        select participate;


            DataSet = query.ToList();
           
            
        }

        public void Apply(IReportParameterForm frm)
        {
            //ResultLabel label = frm.Param1SelectedValue as ResultLabel;
            txtReportName.Value = ReportName + "به شعبه  " + frm.Param1SelectedValue;
            DataSource = DataSet;
        }
    }
}