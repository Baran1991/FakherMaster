using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
    /// Summary description for rptExamResult.
    /// </summary>
    public partial class rptFaExamResult : Report, IConfigurableReport
    {
        private static Exam mExam;
        private static ExamSection mExamSection;

        public rptFaExamResult()
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

        public static float GetTotalMark(ExamParticipate examParticipate)
        {
            return examParticipate.CalculateMark();
        }

        public static float GetItemMark(ExamParticipate examParticipate, int examItemId)
        {
            foreach (ExamItem item in mExam.Items)
                if (item.Id == examItemId)
                    return examParticipate.CalculateMark(item);
            return -1;
        }

        public static int rptFaExamResult_GetRank(ExamParticipate participate)
        {
            int rank = participate.ExamForm.Exam.CalculateRank(participate);
            return rank;
        }

        private static IQueryable<float> GetMarks(ExamItem item)
        {
            IEnumerable<float> query;
            if (mExamSection != null)
                query = from participate in mExam.GetParticipates().ToList()
                        where participate.GetSection() != null
                        && participate.GetSection().Id == mExamSection.Id
                        select participate.CalculateMark(item);
            else
                query = from participate in mExam.GetParticipates().ToList()
                        select participate.CalculateMark(item);
            return query.AsQueryable();
        }

        private static IQueryable<float> GetMarks()
        {
            IEnumerable<float> query;

            if (mExamSection != null)
                query = from participate in mExam.GetParticipates().ToList()
                        where participate.GetSection() != null
                        && participate.GetSection().Id == mExamSection.Id
                        select participate.CalculateMark();
            else
                query = from participate in mExam.GetParticipates().ToList()
                        select participate.CalculateMark();
            return query.AsQueryable();
        }

        public static float MinItemMark(int examItemId)
        {
            ExamItem item = null;
            foreach (ExamItem examItem in mExam.Items)
                if (examItem.Id == examItemId)
                {
                    item = examItem;
                    break;
                }

            IQueryable<float> query = GetMarks(item);
            if (query.Count() > 0)
                return query.Min();
            return 0;
        }

        public static float AvgItemMark(int examItemId)
        {
            ExamItem item = null;
            foreach (ExamItem examItem in mExam.Items)
                if (examItem.Id == examItemId)
                {
                    item = examItem;
                    break;
                }

            IQueryable<float> query = GetMarks(item);
            if (query.Count() > 0)
                return (float)Math.Round(query.Average(), 2);
            return 0;
        }

        public static float MaxItemMark(int examItemId)
        {
            ExamItem item = null;
            foreach (ExamItem examItem in mExam.Items)
                if (examItem.Id == examItemId)
                {
                    item = examItem;
                    break;
                }

            IQueryable<float> query = GetMarks(item);
            if (query.Count() > 0)
                return query.Max();
            return 0;
        }

        public static float MinMark()
        {
            IQueryable<float> query = GetMarks();
            if (query.Count() > 0)
                return query.Min();
            return 0;
        }

        public static float AvgMark()
        {
            IQueryable<float> query = GetMarks();
            if (query.Count() > 0)
                return (float)Math.Round(query.Average(), 2);
            return 0;
        }

        public static float MaxMark()
        {
            IQueryable<float> query = GetMarks();
            if (query.Count() > 0)
                return query.Max();
            return 0;
        }

        private void AddHeaderColumns()
        {
            float left = 0;
            float cellWidth = pnlHeader.Width.Value / mExam.Items.Count;
            UnitType unitType = pnlHeader.Height.Type;
            pnlHeader.Items.Clear();
            foreach (ExamItem examItem in mExam.Items)
            {
                Telerik.Reporting.TextBox txt = new Telerik.Reporting.TextBox();
                txt.Value = examItem.Name + " (" + examItem.Mark + ")";

                txt.Size = new SizeU(new Unit(cellWidth, unitType), new Unit(pnlHeader.Height.Value, unitType));
                txt.Location = new PointU(new Unit(left, unitType), new Unit(0, unitType));
                txt.Style.BorderStyle.Default = BorderType.Solid;
                txt.Style.TextAlign = HorizontalAlign.Center;
                txt.Style.VerticalAlign = VerticalAlign.Middle;
                pnlHeader.Items.Add(txt);
                left += txt.Size.Width.Value;
            }
        }

        private void AddStudentColumns()
        {
            float left = 0;
            float cellWidth = pnlItems.Width.Value / mExam.Items.Count;
            UnitType unitType = pnlItems.Height.Type;
            pnlItems.Items.Clear();
            foreach (ExamItem examItem in mExam.Items)
            {
                Telerik.Reporting.TextBox txt = new Telerik.Reporting.TextBox();
                txt.Value = string.Format("=GetItemMark(ReportItem.DataObject.RawData, {0})", examItem.Id);

                txt.Size = new SizeU(new Unit(cellWidth, unitType), new Unit(pnlItems.Height.Value, unitType));
                txt.Location = new PointU(new Unit(left, unitType), new Unit(0, unitType));
                txt.Style.BorderStyle.Left = BorderType.Solid;
                txt.Style.TextAlign = HorizontalAlign.Center;
                txt.Style.VerticalAlign = VerticalAlign.Middle;
                pnlItems.Items.Add(txt);
                left += txt.Size.Width.Value;
            }
        }

        private void AddAggregateColumns()
        {
            float left = 0;
            float cellWidth = pnlMinimum.Width.Value / mExam.Items.Count;
            UnitType unitType = pnlMinimum.Height.Type;
            pnlMinimum.Items.Clear();
            pnlAverage.Items.Clear();
            pnlMaximum.Items.Clear();
            foreach (ExamItem examItem in mExam.Items)
            {
                Telerik.Reporting.TextBox txt1 = new Telerik.Reporting.TextBox();
                txt1.Value = string.Format("=MinItemMark({0})", examItem.Id);

                txt1.Size = new SizeU(new Unit(cellWidth, unitType), new Unit(pnlItems.Height.Value, unitType));
                txt1.Location = new PointU(new Unit(left, unitType), new Unit(0, unitType));
                txt1.Style.BorderStyle.Left = BorderType.Solid;
                txt1.Style.TextAlign = HorizontalAlign.Center;
                txt1.Style.VerticalAlign = VerticalAlign.Middle;
                pnlMinimum.Items.Add(txt1);
                //                left += txt1.Size.Width.Value;

                Telerik.Reporting.TextBox txt2 = new Telerik.Reporting.TextBox();
                txt2.Value = string.Format("=AvgItemMark({0})", examItem.Id);

                txt2.Size = new SizeU(new Unit(cellWidth, unitType), new Unit(pnlItems.Height.Value, unitType));
                txt2.Location = new PointU(new Unit(left, unitType), new Unit(0, unitType));
                txt2.Style.BorderStyle.Left = BorderType.Solid;
                txt2.Style.TextAlign = HorizontalAlign.Center;
                txt2.Style.VerticalAlign = VerticalAlign.Middle;
                pnlAverage.Items.Add(txt2);
                //                left += txt2.Size.Width.Value;

                Telerik.Reporting.TextBox txt3 = new Telerik.Reporting.TextBox();
                txt3.Value = string.Format("=MaxItemMark({0})", examItem.Id);

                txt3.Size = new SizeU(new Unit(cellWidth, unitType), new Unit(pnlItems.Height.Value, unitType));
                txt3.Location = new PointU(new Unit(left, unitType), new Unit(0, unitType));
                txt3.Style.BorderStyle.Left = BorderType.Solid;
                txt3.Style.TextAlign = HorizontalAlign.Center;
                txt3.Style.VerticalAlign = VerticalAlign.Middle;
                pnlMaximum.Items.Add(txt3);

                left += txt3.Size.Width.Value;
            }
        }

        private void textBox6_ItemDataBinding(object sender, EventArgs e)
        {
            if(mExamSection != null)
                textBox6.Value = "نتایج آزمون " + mExam.Name + " " + mExamSection.SectionItem.Section.FarsiName + " [" + mExam.Date.ToShortDateString() + "] [" + mExam.QuestionCount + " سئوال]";
            else
                textBox6.Value = "نتایج آزمون " + mExam.Name + " [" + mExam.Date.ToShortDateString() + "] [" + mExam.QuestionCount + " سئوال]";
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش نتایج آزمون"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowExams = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            mExam = frm.Exam;
            frm.Exam.CheckKey();
            if (frm.ExamSection != null)
            {
                mExamSection = frm.ExamSection;
                frm.Exam.CheckMarks(frm.ExamSection);
                IQueryable<ExamParticipate> participates = frm.Exam.GetFarsiOrderedParticipates(frm.ExamSection);
                frm.Exam.EnsurePreCalculation(participates.ToList());
                DataSet = participates;
            }
            else
            {
                frm.Exam.CheckAllMarks();
                DataSet = frm.Exam.GetFarsiOrderedParticipates();
            }
        }

        public void Apply(IReportParameterForm frm)
        {
            AddHeaderColumns();
            AddStudentColumns();
            AddAggregateColumns();

            DataSource = DataSet;
        }

        #endregion

        private void txtTotalMark_ItemDataBinding(object sender, EventArgs e)
        {
            txtTotalMark.Value = "نمره کل (" + mExam.EvaluationItem.Value + ")";
        }
    }
}