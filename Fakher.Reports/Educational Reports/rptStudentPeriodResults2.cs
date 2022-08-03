using System.Collections;
using System.Collections.Generic;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;
using NHibernate;
using NHibernate.Linq;
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
    public partial class rptStudentPeriodResults2 : Report, IConfigurableReport
    {
        private static IReportParameterForm mFrm;
        private static IList mPeriods;

        public rptStudentPeriodResults2()
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
            List<string> list = frm.Period.GetDefaultResultLabels().Select(x => x.Name).ToList();
            list.Insert(0, "همه نتایج");
            frm.Param1DataSource = list.ToArray();
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            DataSet = frm.Period.Department.EducationalPeriods.OrderByDescending(x => x.StartDate).ToArray();
        }

        public void Apply(IReportParameterForm frm)
        {
            mPeriods = new List<EducationalPeriod>();
            DataSet.CopyTo(mPeriods);

            string result = frm.Param1SelectedText;
            txtReportName.Value = ReportName + " با وضعیت " + result;


            var query = from EducationalPeriod period in mPeriods
                        from participate in Participate.GetParticipates(period, frm.Major)
                        where participate.Register.Quit == null
                              && participate.Quit == null
                        orderby participate.Register.Student.FarsiLastName, participate.Register.Period.StartDate descending
                        select participate;

            List<Participate> endResult = new List<Participate>();
            if (mFrm.Param1SelectedIndex > 0)
            {
                var q = query.GroupBy(x => x.Register.Student.Id);
                foreach (IGrouping<int, Participate> grouping in q)
                {
                    if(grouping.Count() != mPeriods.Count)
                        continue;

                    bool shouldInclude = true;
                    foreach (Participate participate in grouping)
                    {
                        string r = participate.GetResultLabel().Name.Trim();
                        if (r != result)
                        {
                            shouldInclude = false;
                            break;
                        }
                    }

                    if (shouldInclude)
                    {
                        endResult.AddRange(grouping.Select(x => x));
                    }
                }
            }
            else
            {
                endResult = query.ToList();
            }

            DataSource = endResult;
        }

        #endregion

        //        public static List<Participate> GetParticipates(Student student)
        //        {
        //            IQueryable<Participate> query = student.GetParticipates(mFrm.Major).Where(x => mPeriods.Contains(x.Register.Period));
        //            if (mFrm.Param1SelectedIndex > 0)
        //                query = query.Where(x => x.GetResultLabel().Name.Trim() == mFrm.Param1SelectedText.Trim());
        //
        //            List<Participate> participates = query.ToList();
        //            return participates;
        //        }

        public static float GetMark(Participate participate)
        {
            return participate.CalculateMark();
        }

        public static string GetResult(Participate participate)
        {
            return participate.GetResultLabel().Name;
        }

        //        public static int rptStudentResults_GetRank(Participate participate)
        //        {
        //            try
        //            {
        //                int rank = participate.SectionItem.CalculateRank(participate);
        //                return rank;
        //            }
        //            catch (Exception e)
        //            {
        //                Console.WriteLine(e);
        //                throw e;
        //            }
        //        }

    }
}