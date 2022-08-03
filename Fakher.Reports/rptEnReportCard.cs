using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;

namespace Fakher.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptEnReportCard.
    /// </summary>
    public partial class rptEnReportCard : Report, IConfigurableReport
    {
        public static EducationalPeriod Period { get; set; }

        public rptEnReportCard()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public static IList<KeyValuePair<string, string>> GetReportCardItems(Participate participate)
        {
            List<KeyValuePair<string, string>> result  = new List<KeyValuePair<string, string>>();

            EvaluationProtocol evaluationProtocol = participate.SectionItem.Item.Lesson.GetEvaluationProtocol(Period);
            foreach (EvaluationGroup @group in evaluationProtocol.EvaluationGroups)
            {
                float mark = participate.CalculateMark(@group);
                result.Add(new KeyValuePair<string, string>(@group.Name + " (" + @group.TotalValue + ")", mark.ToString()));
            }
            return result;
        }

        public static string GetReportCardTotalMark(Participate participate)
        {
            float mark = participate.CalculateMark();
            EvaluationProtocol evaluationProtocol = participate.SectionItem.Lesson.GetEvaluationProtocol(participate.Register.Period);
            if(evaluationProtocol != null)
                return mark + " / " + Math.Round(evaluationProtocol.TotalValue, 2);
            return mark + "";
        }

        public static string GetReportCardResult(Participate participate)
        {
            return participate.GetResultLabel().Name;
        }

        public static int rptEnReportCard_GetRank(Participate participate)
        {
            int rank = participate.SectionItem.CalculateRank(participate);
            return rank;
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return true; }
        }

        public string ReportName
        {
            get { return "گزارش کارنامه"; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام", "Register.Student.FarsiFirstName"},
                               new List<object> {"نام خانوادگی", "Register.Student.FarsiLastName"}
                           };
            }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowStructure = frm.ShowMajor = true;
            frm.ShowLesson = frm.ShowSection = true;
            frm.IsRightToLeft = false;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            DataSet = frm.SectionItem.GetEnglishOrderedParticipates();
        }

        public void Apply(IReportParameterForm frm)
        {
            Period = frm.Period;
            DataSource = DataSet;
        }

        #endregion
    }
}