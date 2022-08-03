using System.Collections;
using System.Collections.Generic;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;
using rComponents;

namespace Fakher.Reports.Exam_Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Linq;

    public partial class rptFaExamTopResultList : Report, IConfigurableReport
    {
        private static Exam mExam;
        private static ExamSection mExamSection;

        public rptFaExamTopResultList()
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

        public static float rptFaExamTopResultList_GetTotalMark(ExamParticipate examParticipate)
        {
            return examParticipate.CalculateMark();
        }

        public static float rptFaExamTopResultList_GetStandardScore(ExamParticipate examParticipate)
        {
            return examParticipate.ExamForm.Exam.CalculateStandardScore(examParticipate);
        }

        public static int rptFaExamTopResultList_GetRank(ExamParticipate participate)
        {
            int rank = participate.ExamForm.Exam.CalculateRank(participate);
            return rank;
        }

        public static double rptFaExamTopResultList_GetTotalMarkOf20(ExamParticipate participate)
        {
            return participate.CalculateMarkOf20();
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return true; }
        }

        public string ReportName
        {
            get { return "گزارش نفرات برتر آزمون"; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام", "Register.Student.FarsiFirstName"},
                               new List<object> {"نام خانوادگی", "Register.Student.FarsiLastName"},
                               new List<object> {"فرم", "ExamForm.Name"},
                               new List<object> {"وضعیت کارت", "CardStatusText"},
                               new List<object> {"وضعیت", "StatusText"}
                           };
            }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowExams = true;
            frm.OptionalExamSection = true;
            frm.Param1Text = "سیاست افراد نامشخص:";
            frm.Param1DataSource = new [] {"هشدار", "تبدیل نمره به صفر"};
            frm.ShowParam1 = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            frm.Exam.CheckKey();
            if (frm.ExamSection != null)
            {
                mExamSection = frm.ExamSection;
                frm.Exam.CheckMarks(frm.ExamSection);
                IList<ExamParticipate> participates = frm.Exam.GetFarsiOrderedParticipates(frm.ExamSection).ToList();
                frm.Exam.EnsurePreCalculation(participates.ToList());
                if (frm.Exam.RankCalculation == RankCalculation.StandardScore)
                    DataSet = participates.OrderByDescending(x => x.ExamForm.Exam.CalculateStandardScoreRank(x));
                if(frm.Exam.RankCalculation == RankCalculation.TotalMark)
                    DataSet = participates.OrderByDescending(x => x.CalculateMark());
            }
            else
            {
                if(frm.Param1SelectedIndex == 0)
                    frm.Exam.CheckAllMarks();
                IList<ExamParticipate> participates = frm.Exam.GetFarsiOrderedParticipates().ToList();
                if (frm.Exam.RankCalculation == RankCalculation.StandardScore)
                    DataSet = participates.OrderByDescending(x => x.ExamForm.Exam.CalculateStandardScoreRank(x));
                if(frm.Exam.RankCalculation == RankCalculation.TotalMark)
                    DataSet = participates.OrderByDescending(x => x.CalculateMark());
            }
        }

        public void Apply(IReportParameterForm frm)
        {
            textBox6.Value = frm.Exam.Name;
            if (frm.Exam.ExamHolding is PaperBasedExamHolding)
                textBox9.Value = frm.Exam.ExamHolding.Formations[0].FarsiText;
            if (frm.Exam.ExamHolding is OnlineExamHolding)
            {
                OnlineExamHolding examHolding = (frm.Exam.ExamHolding as OnlineExamHolding);
                textBox9.Value = examHolding.StartDate + "";
            }
            DataSource = DataSet;
        }

        #endregion
    }
}