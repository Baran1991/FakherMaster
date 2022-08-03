using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    /// <summary>
    /// Summary description for rptExamAnalysis.
    /// </summary>
    public partial class rptExamAnalysis : Report, IConfigurableReport
    {
        private static Exam mExam;
        private static IList<ExamParticipate> mParticipates;
        private static int mCurrentQuestionNumber;
        private static ExamItem mCurrentExamItem;
        private static ExamForm mCurrentExamForm;

        public rptExamAnalysis()
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
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش تحلیل آزمون"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowExams = true;
            frm.OptionalExamSection = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            if (frm.ExamSection != null)
                mParticipates = frm.Exam.GetParticipates(frm.ExamSection).ToList();
            else
                mParticipates = frm.Exam.GetParticipates().ToList();

            List<QuestionAnalysis> analyses = new List<QuestionAnalysis>();

            foreach (ExamItem item in frm.Exam.Items)
            {
                foreach (ExamForm examForm in frm.Exam.Forms)
                {
                    var query = from participate in mParticipates
                                where participate.ExamForm.Id == examForm.Id
                                select participate;

                    for (int i = item.StartIndex; i <= item.EndIndex; i++)
                    {
                        QuestionAnalysis analysis = new QuestionAnalysis();
                        analysis.ExamItem = item;
                        analysis.ExamForm = examForm;
                        analysis.QuestionNumber = i;

                        foreach (ExamParticipate participate in query)
                        {
                            if (participate.IsAnswered(i - 1))
                            {
                                analysis.AnsweredCount++;
                                if (participate.IsCorrect(i - 1))
                                    analysis.CorrectCount++;
                                else
                                    analysis.WrongCount++;
                            }
                            else
                                analysis.NotAnsweredCount++;
                        }
                        analyses.Add(analysis);
                    }
                }
            }

            DataSet = analyses;
        }

        public void Apply(IReportParameterForm frm)
        {
            if (frm.ExamSection != null)
                txtReportName.Value = ReportName + frm.Exam.Name + " " + frm.ExamSection.SectionItem.Section.FarsiName;
            else
                txtReportName.Value = ReportName + frm.Exam.Name;

            DataSource = DataSet;
        }

        #endregion

        public static double rptExamAnalysis_GetHardnessCoefficient(QuestionAnalysis questionAnalysis)
        {
            double d = (double) questionAnalysis.CorrectCount / (questionAnalysis.AnsweredCount + questionAnalysis.NotAnsweredCount);
            return d*100;
        }
    }

    public class QuestionAnalysis
    {
        public QuestionAnalysis()
        {
            AnsweredCount = 0;
            NotAnsweredCount = 0;
            CorrectCount = 0;
            WrongCount = 0;
        }

        public int QuestionNumber { get; set; }
        public ExamForm ExamForm { get; set; }
        public ExamItem ExamItem { get; set; }
        public int AnsweredCount { get; set; }
        public int NotAnsweredCount { get; set; }
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
    }
}