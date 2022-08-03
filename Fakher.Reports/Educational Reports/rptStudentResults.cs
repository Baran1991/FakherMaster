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
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Linq;
    /// <summary>
    /// Summary description for rptStudentResults.
    /// </summary>
    public partial class rptStudentResults : Report, IConfigurableReport
    {
        private IReportParameterForm mFrm;

        public rptStudentResults()
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

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return true; }
        }

        public string ReportName
        {
            get { return "گزارش نتیجه دانشجویان"; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام", "Register.Student.FarsiFirstName"},
                               new List<object> {"نام خانوادگی", "Register.Student.FarsiLastName"},
                               new List<object> {"درس/سطح", "SectionItem.Lesson.Name"},
                               new List<object> {"گروه", "SectionItem.Section.FarsiName"},
                               new List<object> {"غیبت موجه", "AcceptedAbsencesCount"},
                               new List<object> {"غیبت غیرموجه", "RejectedAbsencesCount"},
                               new List<object> {"نمره کل", "CalculateMark()", typeof(float)},
                               new List<object> {"نتیجه", "GetResultLabel().Name"}
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
            frm.SelectedLessonChanged += new EventHandler(frm_SelectedLessonChanged);
            frm.Param1Text = "وضعیت نتیجه:";
            frm.Param1DataSource = new string[] {""};
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            ResultLabel label = frm.Param1SelectedValue as ResultLabel;
            IList<Participate> totalParticipates;
            if(frm.SectionItem != null)
                totalParticipates = frm.SectionItem.GetParticipates();
            else if(frm.Lesson != null)
                totalParticipates = Participate.GetParticipates(frm.Period, frm.Lesson);
            else
                totalParticipates = Participate.GetParticipates(frm.Period, frm.Major);

            var query = from participate in totalParticipates
                        where participate.Quit == null
                        && participate.Register.Quit == null
                        && participate.GetResultLabel() == label
                        orderby participate.Register.Student.FarsiLastName
                        select participate;
            DataSet = query.ToList();
        }

        public void Apply(IReportParameterForm frm)
        {
            ResultLabel label = frm.Param1SelectedValue as ResultLabel;
            txtReportName.Value = ReportName + " با وضعیت " + label.Name;

            DataSource = DataSet;
        }

        private void frm_SelectedLessonChanged(object sender, EventArgs e)
        {
            if(mFrm.Lesson == null)
                return;
            mFrm.Param1DataSource = mFrm.Lesson.GetResultProtocol(mFrm.Period).Labels;
        }

        #endregion

        public static float GetMark(Participate participate)
        {
            return participate.CalculateMark();
        }

        public static string GetResult(Participate participate)
        {
            return participate.GetResultLabel().Name;
        }

        public static int rptStudentResults_GetRank(Participate participate)
        {
            try
            {
                int rank = participate.SectionItem.CalculateRank(participate);
                return rank;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

    }
}