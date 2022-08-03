using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
    public partial class rptFaExamReportCard : Report, IConfigurableReport
    {
        public static EducationalPeriod Period { get; set; }

        public rptFaExamReportCard()
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
            frm.IsRightToLeft = true;
            frm.Param1Text = "سیاست افراد نامشخص:";
            frm.Param1DataSource = new [] { "هشدار", "تبدیل نمره به صفر" };
            frm.ShowParam1 = true;
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
                if (frm.Param1SelectedIndex == 0)
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

        public static IList<KeyValuePair<ExamItem, ExamParticipate>> rptFaExamReportCard_GetItems(ExamParticipate participate)
        {
            List<KeyValuePair<ExamItem, ExamParticipate>> result = new List<KeyValuePair<ExamItem, ExamParticipate>>();
            foreach (ExamItem item in participate.ExamForm.Exam.Items)
                result.Add(new KeyValuePair<ExamItem, ExamParticipate>(item, participate));
            return result;
        }

        public static int rptFaExamReportCard_GetCorrectCount(KeyValuePair<ExamItem, ExamParticipate> item)
        {
            string rawAnswers = "";
            if (item.Value is PaperBasedExamParticipate)
                rawAnswers = (item.Value as PaperBasedExamParticipate).RawAnswers;
            if (item.Value is OnlineExamParticipate)
                rawAnswers = (item.Value as OnlineExamParticipate).RawAnswers;
            return item.Value.ExamForm.CalculateCorrectCount(item.Key, rawAnswers);
        }

        public static int rptFaExamReportCard_GetWrongCount(KeyValuePair<ExamItem, ExamParticipate> item)
        {
            string rawAnswers = "";
            if (item.Value is PaperBasedExamParticipate)
                rawAnswers = (item.Value as PaperBasedExamParticipate).RawAnswers;
            if (item.Value is OnlineExamParticipate)
                rawAnswers = (item.Value as OnlineExamParticipate).RawAnswers;
            return item.Value.ExamForm.CalculateWrongCount(item.Key, rawAnswers);
        }

        public static int rptFaExamReportCard_GetWhiteCount(KeyValuePair<ExamItem, ExamParticipate> item)
        {
            string rawAnswers = "";
            if (item.Value is PaperBasedExamParticipate)
                rawAnswers = (item.Value as PaperBasedExamParticipate).RawAnswers;
            if (item.Value is OnlineExamParticipate)
                rawAnswers = (item.Value as OnlineExamParticipate).RawAnswers;
            return item.Value.ExamForm.CalculateWhiteCount(item.Key, rawAnswers);
        }

        public static float rptFaExamReportCard_GetMark(KeyValuePair<ExamItem, ExamParticipate> item)
        {
            return (float)((item.Value.CalculateMark(item.Key) * item.Key.Exam.EvaluationItem.Value) / item.Key.Mark);
        }

        public static float rptFaExamReportCard_GetPercent(KeyValuePair<ExamItem, ExamParticipate> item)
        {
            return item.Value.CalculatePercent(item.Key);
        }

        public static float rptFaExamReportCard_GetMarkOf20(KeyValuePair<ExamItem, ExamParticipate> item)
        {
            return item.Value.CalculateMarkOf20(item.Key);
        }

        public static double rptFaExamReportCard_GetStandardScore(KeyValuePair<ExamItem, ExamParticipate> item)
        {
            return item.Key.Exam.CalculateStandardScore(item.Value, item.Key);
        }

        public static int rptFaExamReportCard_GetRank(KeyValuePair<ExamItem, ExamParticipate> item)
        {
            return item.Key.Exam.CalculateRank(item.Value, item.Key);
        }

        public static double rptFaExamReportCard_GetMaxPercent(KeyValuePair<ExamItem, ExamParticipate> item)
        {
            return item.Key.Exam.GetMaximumPercent(item.Key);
        }

        public static double rptFaExamReportCard_GetMinPercent(KeyValuePair<ExamItem, ExamParticipate> item)
        {
            return item.Key.Exam.GetMinimumPercent(item.Key);
        }

        public static string rptFaExamReportCard_GetStatusText(KeyValuePair<ExamItem, ExamParticipate> item)
        {
            return item.Key.Exam.CalculateStatusText(item.Value, item.Key);
        }

        public static double rptFaExamReportCard_GetTotalMark(ExamParticipate participate)
        {
            return participate.CalculateMark();
//            return participate.CalculateMarkOf20();
        }

        public static double rptFaExamReportCard_GetTotalStandardScore(ExamParticipate participate)
        {
            return participate.ExamForm.Exam.CalculateStandardScore(participate);
        }

        public static int rptFaExamReportCard_GetTotalRank(ExamParticipate participate)
        {
//            return participate.ExamForm.Exam.CalculateStandardScoreRank(participate);
            return participate.ExamForm.Exam.CalculateRank(participate);
        }

        public static string rptFaExamReportCard_GetTotalStatusText(ExamParticipate participate)
        {
            return participate.ExamForm.Exam.CalculateStatusText(participate);
        }

        public static Image rptFaExamReportCard_GetStudentPhoto(ExamParticipate participate)
        {
            Bitmap original = participate.Register.Student.Photo.Picture;
            if (original != null)
                return original.GetThumbnailImage(76, 92, null, IntPtr.Zero);
            return null;
        }

        public static Bitmap rptFaExamReportCard_GetImage(ExamParticipate participate)
        {
            if (participate is PaperBasedExamParticipate)
                return (participate as PaperBasedExamParticipate).GetAnswersheetView();
            if (participate is OnlineExamParticipate)
                return (participate as OnlineExamParticipate).GetAnswersheetView();
            return null;
        }

        private void rptFaExamReportCard_Error(object sender, ErrorEventArgs eventArgs)
        {
            Exception exception = eventArgs.Exception;
        }
    }
}