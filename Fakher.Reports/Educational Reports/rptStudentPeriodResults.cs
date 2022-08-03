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
    using System.Linq.Expressions;
    /// <summary>
    /// Summary description for rptStudentResults.
    /// </summary>
    public partial class rptStudentPeriodResults : Report, IConfigurableReport
    {
        private IReportParameterForm mFrm;

        public rptStudentPeriodResults()
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
            get { return "گزارش نتیجه دانشجویان به تفکیک ترم"; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام", "Name"},
                               new List<object> {"تاریخ شروع", "StartDate"},
                               new List<object> {"تاریخ پایان", "EndDate"},
                           };
            }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            mFrm = frm;
            frm.ShowStructure = true;
            frm.ShowMajor = true;
            frm.ShowParam1 = true;
            frm.Param1Text = "وضعیت نتیجه:";
            frm.Param1DataSource = frm.Period.GetDefaultResultLabels();
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            DataSet = frm.Period.Department.EducationalPeriods.ToArray();
        }

        public void Apply(IReportParameterForm frm)
        {
            ResultLabel label = frm.Param1SelectedValue as ResultLabel;
            IList periods = new List<EducationalPeriod>();
            DataSet.CopyTo(periods);
            
            txtReportName.Value = ReportName + " با وضعیت " + label.Name;

            var query = from EducationalPeriod period in periods
                        from participate in Participate.GetParticipates(period, frm.Major)
                        where participate.Quit == null
                        && participate.Register.Quit == null
                        && participate.GetResultLabel() != null
                        && participate.GetResultLabel().Text.Trim() == label.Text.Trim()
                        orderby participate.Register.Student.FarsiLastName
                        select participate;

            DataSource = query;
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