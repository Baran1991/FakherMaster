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
    public partial class rptFaReportCard : Report, IConfigurableReport
    {
        public static EducationalPeriod Period { get; set; }

        public rptFaReportCard()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

//        public static string GetMark(Participate participate, string id)
//        {
//            EvaluationItem item = DbContext.FromId<EvaluationItem>(id);
//            return participate.CalculateMark(item) + "";
//        }

        public static IList<KeyValuePair<string, string>> GetFaReportItemItems(Participate participate)
        {
            List<KeyValuePair<string, string>> result  = new List<KeyValuePair<string, string>>();

            List<EvaluationItem> items = participate.SectionItem.Item.Lesson.GetEvaluationProtocol(Period).GetAllItems().ToList();
            foreach (EvaluationItem item in items)
            {
                float mark = participate.CalculateMark(item);
                result.Add(new KeyValuePair<string, string>(item.Name, mark.ToString()));
            }
            return result;
        }

        public static string GetReportCardTotalMark(Participate participate)
        {
            return participate.CalculateMark() + "";
        }

        public static string GetReportCardResult(Participate participate)
        {
            return participate.GetResultLabel().Name;
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
            DataSet = frm.SectionItem.GetParticipates();
        }

        public void Apply(IReportParameterForm frm)
        {
            Period = frm.Period;
            DataSource = DataSet;
        }

        #endregion
    }
}