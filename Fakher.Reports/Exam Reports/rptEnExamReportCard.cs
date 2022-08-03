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

    public partial class rptEnExamReportCard : Report, IConfigurableReport
    {
        public static EducationalPeriod Period { get; set; }

        public rptEnExamReportCard()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return true; }
        }

        public string ReportName
        {
            get { return "گزارش کارنامه آزمون"; }
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
            frm.ShowExams = true;
            frm.OptionalExamSection = true;
            frm.IsRightToLeft = false;
            frm.ShowParam1 = false;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            frm.Exam.CheckKey();
            frm.Exam.UseParticipatesCache();
            if (frm.ExamSection != null)
            {
                frm.Exam.CheckMarks(frm.ExamSection);
                DataSet = frm.Exam.GetFarsiOrderedParticipates(frm.ExamSection);
            }
            else
            {
                frm.Exam.CheckAllMarks();
                DataSet = frm.Exam.GetFarsiOrderedParticipates();
            }
        }

        public void Apply(IReportParameterForm frm)
        {
            Period = frm.Period;
            DataSource = DataSet;
        }

        #endregion

        public static string rptEnExamReportCard_GetTeacherName(ExamParticipate participate)
        {
            return participate.ExamForm.Exam.ExamSections[0].SectionItem.Section.Teacher.EnglishFullname;
        }

        public static IList<KeyValuePair<ExamItem, ExamParticipate>> rptEnExamReportCard_GetItems(ExamParticipate participate)
        {
            List<KeyValuePair<ExamItem, ExamParticipate>> result = new List<KeyValuePair<ExamItem, ExamParticipate>>();
            foreach (ExamItem item in participate.ExamForm.Exam.Items)
                result.Add(new KeyValuePair<ExamItem, ExamParticipate>(item, participate));
            return result;
        }

        public static string rptEnExamReportCard_GetItemName(KeyValuePair<ExamItem, ExamParticipate> item)
        {
            return item.Key.Name + "\n(" + item.Key.Mark + ")";
        }

        public static float rptEnExamReportCard_GetMark(KeyValuePair<ExamItem, ExamParticipate> item)
        {
            return item.Value.CalculateMark(item.Key);
        }

        public static float rptEnExamReportCard_GetPercent(KeyValuePair<ExamItem, ExamParticipate> item)
        {
            return item.Value.CalculatePercent(item.Key);
        }

        public static string rptEnExamReportCardGetTotalPercent(ExamParticipate participate)
        {
            return participate.CalculateMark() + "";
        }

        public static float rptEnExamReportCard_AvgExamItemMark(KeyValuePair<ExamItem, ExamParticipate> item)
        {
            var query = from participate in item.Key.Exam.GetParticipates().ToList()
                        select participate.CalculateMark(item.Key);
            return (float)Math.Round(query.Average(), 2);
        }

        public static float rptEnExamReportCard_MaxExamItemMark(KeyValuePair<ExamItem, ExamParticipate> item)
        {
            var query = from participate in item.Key.Exam.GetParticipates().ToList()
                        select participate.CalculateMark(item.Key);
            return query.Max();
        }

        public static string rptEnExamReportCard_GetTotalMark(ExamParticipate participate)
        {
            return participate.CalculateMark() + "";
        }

        public static float rptEnExamReportCard_AvgExamMark(ExamParticipate participate)
        {
            var query = from p in participate.ExamForm.Exam.GetParticipates().ToList()
                        select p.CalculateMark();
            return (float)Math.Round(query.Average(), 2);
        }

        public static float rptEnExamReportCard_MaxExamMark(ExamParticipate participate)
        {
            var query = from p in participate.ExamForm.Exam.GetParticipates().ToList()
                        select p.CalculateMark();
            return query.Max();
        }

        public static string rptEnExamReportCard_GetExamName(ExamParticipate participate)
        {
            ExamSection examSection = participate.GetSection();
            if (examSection != null)
                return participate.ExamForm.Exam.Name + " " + examSection.SectionItem.Section.EnglishName + " [" + examSection.SectionItem.Section.Teacher.EnglishFullname + "]";
            return "";
        }
    }
}