using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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

    public partial class rptMasterCard : Report, IConfigurableReport
    {
        public static Major mMajor;
        public static EducationalPeriod mPeriod;

        public rptMasterCard()
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
            get { return "گزارش Master Card دانشجویان"; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام", "Student.FarsiFirstName"},
                               new List<object> {"نام خانوادگی", "Student.FarsiLastName"}
                           };
            }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowStructure = true;
            frm.ShowMajor = true;
            frm.ShowLesson = true;
            frm.ShowSection = true;
            frm.IsRightToLeft = false;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            IList<Register> registers = frm.SectionItem.GetFarsiOrderedParticipates().Select(x => x.Register).ToList();
            DataSet = registers;
        }

        public void Apply(IReportParameterForm frm)
        {
            DataBind(frm.Major, frm.Period, DataSet);
        }

        public void DataBind(Major major, EducationalPeriod period, IEnumerable dataSet)
        {
            mMajor = major;
            mPeriod = period;

            Fill();
            DataSource = dataSet;
        }

        #endregion

        private static Lesson rptMasterCard_FindLesson(int id)
        {
            foreach (Lesson lesson in mMajor.Lessons)
                if (lesson.Id == id)
                    return lesson;
            return null;
        }

        public static float GetMark(Register register, int lessonId, int groupId)
        {
            Lesson lesson = rptMasterCard_FindLesson(lessonId);
            Participate participate = register.Student.GetAllParticipates(lesson).LastOrDefault();
            if (participate != null)
            {
                EvaluationProtocol evaluationProtocol =
                    participate.SectionItem.Item.Lesson.GetEvaluationProtocol(participate.Register.Period);
                foreach (EvaluationGroup @group in evaluationProtocol.EvaluationGroups)
                {
                    if (@group.Id == groupId)
                        return participate.CalculateMark(@group);
                }
            }

            return -1;
        }

        public static string GetMarkText(Register register, int lessonId, string groupName, string nullText)
        {
            Lesson lesson = rptMasterCard_FindLesson(lessonId);
            Participate participate = register.Student.GetAllParticipates(lesson).LastOrDefault();
            if (participate != null)
            {
                EvaluationProtocol evaluationProtocol =
                    participate.SectionItem.Item.Lesson.GetEvaluationProtocol(participate.Register.Period);
                foreach (EvaluationGroup @group in evaluationProtocol.EvaluationGroups)
                {
                    if (@group.Name == groupName)
                        return Math.Round(participate.CalculateMark(@group), 2) + "";
                }
            }

            return nullText;
        }

        public static float GetMark(Register register, int lessonId)
        {
            Lesson lesson = rptMasterCard_FindLesson(lessonId);
            Participate participate = register.Student.GetAllParticipates(lesson).LastOrDefault();
            if (participate != null)
                return participate.CalculateMark();
            return -1;
        }

        public static string GetMarkText(Register register, int lessonId, string nullText)
        {
            Lesson lesson = rptMasterCard_FindLesson(lessonId);
            Participate participate = register.Student.GetAllParticipates(lesson).LastOrDefault();

            try
            {
                return Math.Round(participate.Register.CalculateMark(lesson), 2) + "";
            }
            catch (Exception ex)
            {
                return nullText;
            }
        }

        public static string rptMasterCard_GetTotalAverageMarkText(Register register)
        {
            float sum = 0;
            int count = 0;
            IList<Lesson> lessons = mMajor.Lessons.OrderBy(x => x.Code).ToList();
            for (int i = 0; i < lessons.Count; i++)
            {
                Lesson lesson = lessons[i];
                if (lesson.HoldingType != HoldingType.Lesson)
                    continue;
                try
                {
                    Participate participate = register.Student.GetAllParticipates(lesson).LastOrDefault();
                    float mark = participate.CalculateMark();
                    sum += mark;
                    count++;
                }
                catch (Exception ex)
                {

                }
            }
            float avg = sum / count;
            return Math.Round(avg, 2) + "";
        }

        public static string GetStatus(Register register, int lessonId)
        {
            Lesson lesson = rptMasterCard_FindLesson(lessonId);
            Participate participate = register.Student.GetAllParticipates(lesson).LastOrDefault();
            if (participate != null)
                return participate.GetResultLabel().Name;
            return "N/A";
        }

        public static int GetAbsents(Register register, int lessonId)
        {
            Lesson lesson = rptMasterCard_FindLesson(lessonId);
            Participate participate = register.Student.GetAllParticipates(lesson).LastOrDefault();
            if (participate != null)
                return participate.GetAbsences().Count();
            return 0;
        }

        public static int GetTotalAbsents(Register register)
        {
            var query = from participate in register.Participates
                        select participate.GetAbsences().Count();
            return query.Sum();
        }

        public static int GetFirstTotalAbsents(Register register)
        {
            IList<Lesson> lessons = mMajor.Lessons.OrderBy(x => x.Name).ToList();
            int count = 0;
            int sum = 0;
            foreach (Lesson lesson in lessons)
            {
                if (lesson.HoldingType != HoldingType.Lesson)
                    continue;
                Participate participate = register.GetLastParticipate(lesson);
                if (participate != null)
                    sum += participate.AbsencesCount;
                count++;
                if (count >= 4)
                    break;
            }
            return sum;
        }

        public static int GetSecondTotalAbsents(Register register)
        {
            IList<Lesson> lessons = mMajor.Lessons.OrderBy(x => x.Name).ToList();
            int count = 0;
            int sum = 0;
            foreach (Lesson lesson in lessons)
            {
                if (lesson.HoldingType != HoldingType.Lesson)
                    continue;
                count++;
                if (count > 4)
                {
                    Participate participate = register.GetLastParticipate(lesson);
                    if (participate != null)
                    {
                        sum += participate.AbsencesCount;
                    }
                    if (count >= 8)
                        break;
                }
            }
            return sum;
        }

        public static string GetTeacher(Register register, int lessonId)
        {
            foreach (Participate participate in register.Participates)
            {
                if (participate.SectionItem.Item.Lesson.Id == lessonId)
                {
                    return participate.SectionItem.Section.Teacher.EnglishFullname;
                }
            }
            return "-";
        }

        public static string GetSecondTeacher(Register register, int lessonId)
        {
            foreach (Participate participate in register.Participates)
            {
                if (participate.SectionItem.Item.Lesson.Id == lessonId)
                {
                    Teacher secondTeacher = participate.SectionItem.Section.SecondTeacher;
                    if(secondTeacher != null)
                        return secondTeacher.EnglishFullname;
                    break;
                }
            }
            return "-";
        }

        public static string rptMasterCard_GetSectionName(Register register)
        {
            if (register.Participates.Count > 0)
                return register.Participates[0].SectionItem.Section.EnglishName;
            return "";
        }

        public void Fill()
        {
            float cellWidth = 0.9f;
            float cellHeight = 1.8f;
            float markHeight = 0.5f;
            float left = 0;
            float top = 0;
            IList<Lesson> lessons = mMajor.Lessons.Where(x=>x.HoldingType == HoldingType.Lesson).OrderBy(x => x.Code).ToList();
            for (int i = 0; i < lessons.Count; i++)
            {
                Lesson lesson = lessons[i];
//                if (lesson.HoldingType != HoldingType.Lesson)
//                    continue;
                EvaluationProtocol evaluationProtocol = lesson.GetEvaluationProtocol(mPeriod);
                if (evaluationProtocol == null)
                    continue;
                    //throw new Exception(string.Format("آیین نامه ارزشیابی {0} تعریف نشده است.", lesson.Name));

                float titleWidth = (evaluationProtocol.EvaluationGroups.Count + 3) * cellWidth;
                float titleHeight = 0.5f;

                Telerik.Reporting.TextBox txtLesson = new Telerik.Reporting.TextBox();
                txtLesson.Style.TextAlign = HorizontalAlign.Center;
                txtLesson.Style.VerticalAlign = VerticalAlign.Middle;
                txtLesson.Width = new Unit(titleWidth, UnitType.Cm);
                txtLesson.Height = new Unit(titleHeight, UnitType.Cm);
                txtLesson.Value = lesson.Name;
                txtLesson.Left = new Unit(left, UnitType.Cm);
                txtLesson.Top = new Unit(top, UnitType.Cm);
                txtLesson.Style.BorderStyle.Default = BorderType.Solid;
                panel2.Items.Add(txtLesson);

                if (i == 0)
                {
                    Telerik.Reporting.TextBox txtTeacher = new Telerik.Reporting.TextBox();
                    txtTeacher.Style.TextAlign = HorizontalAlign.Center;
                    txtTeacher.Style.VerticalAlign = VerticalAlign.Middle;
                    txtTeacher.Style.Font.Size = new Unit(11);
                    txtTeacher.Width = new Unit(titleWidth, UnitType.Cm);
                    txtTeacher.Height = new Unit(titleHeight, UnitType.Cm);
                    txtTeacher.Value = "= 'Teacher: ' + GetTeacher(ReportItem.DataObject.RawData, " + lesson.Id + ")";
                    txtTeacher.Left = new Unit(left, UnitType.Cm);
                    txtTeacher.Top = new Unit(txtLesson.Bottom.Value + cellHeight + markHeight, UnitType.Cm);
                    txtTeacher.Culture = new CultureInfo("en-us");

                    panel2.Items.Add(txtTeacher);
                }
                else if (i == 4)
                {
                    Telerik.Reporting.TextBox txtTeacher = new Telerik.Reporting.TextBox();
                    txtTeacher.Style.TextAlign = HorizontalAlign.Center;
                    txtTeacher.Style.VerticalAlign = VerticalAlign.Middle;
                    txtTeacher.Style.Font.Size = new Unit(11);
                    txtTeacher.Width = new Unit(titleWidth, UnitType.Cm);
                    txtTeacher.Height = new Unit(titleHeight, UnitType.Cm);
                    txtTeacher.Value = "= 'Teacher: ' + GetSecondTeacher(ReportItem.DataObject.RawData, " + lesson.Id + ")";
                    txtTeacher.Left = new Unit(left, UnitType.Cm);
                    txtTeacher.Top = new Unit(txtLesson.Bottom.Value + cellHeight + markHeight, UnitType.Cm);
                    txtTeacher.Culture = new CultureInfo("en-us");

                    panel2.Items.Add(txtTeacher);
                }

                foreach (EvaluationGroup @group in evaluationProtocol.EvaluationGroups)
                {
                    #region Groups

                    Telerik.Reporting.TextBox txtGroup = new Telerik.Reporting.TextBox();
                    txtGroup.Angle = 270;
                    txtGroup.Value = @group.Name;
                    txtGroup.Width = new Unit(cellWidth, UnitType.Cm);
                    txtGroup.Height = new Unit(cellHeight, UnitType.Cm);
                    txtGroup.Left = new Unit(left, UnitType.Cm);
                    txtGroup.Top = new Unit(txtLesson.Bottom.Value, UnitType.Cm);
                    txtGroup.Style.TextAlign = HorizontalAlign.Center;
                    txtGroup.Style.VerticalAlign = VerticalAlign.Middle;
                    txtGroup.Style.BorderStyle.Default = BorderType.Solid;
                    txtGroup.Style.BackgroundColor = Color.Pink;
                    txtGroup.Style.Font.Bold = true;

                    Telerik.Reporting.TextBox txtGroupMark = new Telerik.Reporting.TextBox();
                    txtGroupMark.Value = "=GetMarkText(ReportItem.DataObject.RawData, " + lesson.Id + ", '" + @group.Name + "', '--')";
                    txtGroupMark.Width = new Unit(cellWidth, UnitType.Cm);
                    txtGroupMark.Height = new Unit(markHeight, UnitType.Cm);
                    txtGroupMark.Left = new Unit(left, UnitType.Cm);
                    txtGroupMark.Top = new Unit(txtGroup.Bottom.Value, UnitType.Cm);
                    txtGroupMark.Style.TextAlign = HorizontalAlign.Center;
                    txtGroupMark.Style.VerticalAlign = VerticalAlign.Middle;
                    txtGroupMark.Style.BorderStyle.Default = BorderType.Solid;
                    txtGroupMark.Style.Font.Size = new Unit(11);
                    txtGroupMark.Culture = new CultureInfo("en-us");
                    txtGroupMark.Format = "{0:0.00}";

                    #endregion

                    panel2.Items.Add(txtGroup);
                    panel2.Items.Add(txtGroupMark);
                    left += cellWidth;
                }

                #region Total Grade

                Telerik.Reporting.TextBox txtTotal = new Telerik.Reporting.TextBox();
                txtTotal.Angle = 270;
                txtTotal.Value = "Total";
                txtTotal.Width = new Unit(cellWidth, UnitType.Cm);
                txtTotal.Height = new Unit(cellHeight, UnitType.Cm);
                txtTotal.Left = new Unit(left, UnitType.Cm);
                txtTotal.Top = new Unit(txtLesson.Bottom.Value, UnitType.Cm);
                txtTotal.Style.TextAlign = HorizontalAlign.Center;
                txtTotal.Style.VerticalAlign = VerticalAlign.Middle;
                txtTotal.Style.BorderStyle.Default = BorderType.Solid;
                txtTotal.Style.BackgroundColor = Color.Pink;
                txtTotal.Style.Font.Bold = true;

                Telerik.Reporting.TextBox txtTotalValue = new Telerik.Reporting.TextBox();
                txtTotalValue.Value = "=GetMarkText(ReportItem.DataObject.RawData, " + lesson.Id + ", '--')";
                txtTotalValue.Width = new Unit(cellWidth, UnitType.Cm);
                txtTotalValue.Height = new Unit(markHeight, UnitType.Cm);
                txtTotalValue.Left = new Unit(left, UnitType.Cm);
                txtTotalValue.Top = new Unit(txtTotal.Bottom.Value, UnitType.Cm);
                txtTotalValue.Style.TextAlign = HorizontalAlign.Center;
                txtTotalValue.Style.VerticalAlign = VerticalAlign.Middle;
                txtTotalValue.Style.BorderStyle.Default = BorderType.Solid;
                txtTotalValue.Style.Font.Size = new Unit(11);
                txtTotalValue.Culture = new CultureInfo("en-us");
                txtTotalValue.Format = "{0:0.00}";

                panel2.Items.Add(txtTotal);
                panel2.Items.Add(txtTotalValue);

                #endregion
                left += cellWidth;

                #region Absents

                Telerik.Reporting.TextBox txtAbsents = new Telerik.Reporting.TextBox();
                txtAbsents.Angle = 270;
                txtAbsents.Value = "Absences";
                txtAbsents.Width = new Unit(cellWidth, UnitType.Cm);
                txtAbsents.Height = new Unit(cellHeight, UnitType.Cm);
                txtAbsents.Left = new Unit(left, UnitType.Cm);
                txtAbsents.Top = new Unit(txtLesson.Bottom.Value, UnitType.Cm);
                txtAbsents.Style.TextAlign = HorizontalAlign.Center;
                txtAbsents.Style.VerticalAlign = VerticalAlign.Middle;
                txtAbsents.Style.BorderStyle.Default = BorderType.Solid;
                txtAbsents.Style.BackgroundColor = Color.Pink;
                txtAbsents.Style.Font.Bold = true;

                Telerik.Reporting.TextBox txtAbsentsValue = new Telerik.Reporting.TextBox();
                txtAbsentsValue.Value = "=GetAbsents(ReportItem.DataObject.RawData, " + lesson.Id + ")";
                txtAbsentsValue.Width = new Unit(cellWidth, UnitType.Cm);
                txtAbsentsValue.Height = new Unit(markHeight, UnitType.Cm);
                txtAbsentsValue.Left = new Unit(left, UnitType.Cm);
                txtAbsentsValue.Top = new Unit(txtAbsents.Bottom.Value, UnitType.Cm);
                txtAbsentsValue.Style.TextAlign = HorizontalAlign.Center;
                txtAbsentsValue.Style.VerticalAlign = VerticalAlign.Middle;
                txtAbsentsValue.Style.BorderStyle.Default = BorderType.Solid;
                txtAbsentsValue.Style.Font.Size = new Unit(11);
                txtAbsentsValue.Culture = new CultureInfo("en-us");

                panel2.Items.Add(txtAbsents);
                panel2.Items.Add(txtAbsentsValue);

                #endregion
                left += cellWidth;

                #region P/F

                Telerik.Reporting.TextBox txtStatus = new Telerik.Reporting.TextBox();
                txtStatus.Angle = 270;
                txtStatus.Value = "Result";
                txtStatus.Width = new Unit(cellWidth, UnitType.Cm);
                txtStatus.Height = new Unit(cellHeight, UnitType.Cm);
                txtStatus.Left = new Unit(left, UnitType.Cm);
                txtStatus.Top = new Unit(txtLesson.Bottom.Value, UnitType.Cm);
                txtStatus.Style.TextAlign = HorizontalAlign.Center;
                txtStatus.Style.VerticalAlign = VerticalAlign.Middle;
                txtStatus.Style.BorderStyle.Default = BorderType.Solid;
                txtStatus.Style.BackgroundColor = Color.Pink;
                txtStatus.Style.Font.Bold = true;

                Telerik.Reporting.TextBox txtStatusValue = new Telerik.Reporting.TextBox();
                txtStatusValue.Value = "=GetStatus(ReportItem.DataObject.RawData, " + lesson.Id + ")";
                txtStatusValue.Width = new Unit(cellWidth, UnitType.Cm);
                txtStatusValue.Height = new Unit(markHeight, UnitType.Cm);
                txtStatusValue.Left = new Unit(left, UnitType.Cm);
                txtStatusValue.Top = new Unit(txtStatus.Bottom.Value, UnitType.Cm);
                txtStatusValue.Style.TextAlign = HorizontalAlign.Center;
                txtStatusValue.Style.VerticalAlign = VerticalAlign.Middle;
                txtStatusValue.Style.BorderStyle.Default = BorderType.Solid;
                txtStatusValue.Culture = new CultureInfo("en-us");
                txtStatusValue.Style.Font.Bold = true;
                txtStatusValue.Style.Font.Size = new Unit(11);
                txtStatusValue.TextWrap = false;

                panel2.Items.Add(txtStatus);
                panel2.Items.Add(txtStatusValue);

                #endregion
                left += cellWidth;

                if (left + titleWidth > panel2.Right.Value)
                {
                    top += titleHeight + cellHeight + markHeight + 1f;
                    left = 0;
                }
            }

            left = 0;
            top = 0.2f;
            lessons = mMajor.Lessons.Where(x => x.HoldingType == HoldingType.Exam).OrderBy(x => x.Code).ToList();
            foreach (Lesson lesson in lessons)
            {
                #region Oral Exam

                Telerik.Reporting.TextBox txtExam = new Telerik.Reporting.TextBox();
                txtExam.Value = lesson.Name;
                txtExam.Width = new Unit(cellHeight, UnitType.Cm);
                txtExam.Height = new Unit(cellWidth, UnitType.Cm);
                txtExam.Left = new Unit(left, UnitType.Cm);
                txtExam.Top = new Unit(top, UnitType.Cm);
                txtExam.Style.TextAlign = HorizontalAlign.Center;
                txtExam.Style.VerticalAlign = VerticalAlign.Middle;
                txtExam.Style.BorderStyle.Default = BorderType.Solid;
                txtExam.Style.BackgroundColor = Color.Pink;
                txtExam.Style.Font.Bold = true;

                Telerik.Reporting.TextBox txtExamValue = new Telerik.Reporting.TextBox();
                txtExamValue.Value = "=GetMarkText(ReportItem.DataObject.RawData, " + lesson.Id + ", ' ')";
                txtExamValue.Width = new Unit(cellHeight, UnitType.Cm);
                txtExamValue.Height = new Unit(cellWidth, UnitType.Cm);
                txtExamValue.Left = new Unit(txtExam.Right.Value, UnitType.Cm);
                txtExamValue.Top = new Unit(top, UnitType.Cm);
                txtExamValue.Style.TextAlign = HorizontalAlign.Center;
                txtExamValue.Style.VerticalAlign = VerticalAlign.Middle;
                txtExamValue.Style.BorderStyle.Default = BorderType.Solid;
                txtExamValue.Culture = new CultureInfo("en-us");

                #endregion

                panel3.Items.Add(txtExam);
                panel3.Items.Add(txtExamValue);
                left += 2 * cellWidth + 2.8f;
            }

            #region Second Total Absents
            Telerik.Reporting.TextBox txtTotalAbsents = new Telerik.Reporting.TextBox();
            txtTotalAbsents.Value = "Absences";
            txtTotalAbsents.Width = new Unit(cellHeight + 0.1, UnitType.Cm);
            txtTotalAbsents.Height = new Unit(cellWidth, UnitType.Cm);
            txtTotalAbsents.Left = new Unit(left, UnitType.Cm);
            txtTotalAbsents.Top = new Unit(top, UnitType.Cm);
            txtTotalAbsents.Style.TextAlign = HorizontalAlign.Center;
            txtTotalAbsents.Style.VerticalAlign = VerticalAlign.Middle;
            txtTotalAbsents.Style.BorderStyle.Default = BorderType.Solid;
            txtTotalAbsents.Style.BackgroundColor = Color.Pink;
            txtTotalAbsents.Style.Font.Bold = true;

            Telerik.Reporting.TextBox txtFirstTotalAbsentsValue = new Telerik.Reporting.TextBox();
            txtFirstTotalAbsentsValue.Value = "=GetFirstTotalAbsents(ReportItem.DataObject.RawData)";
            txtFirstTotalAbsentsValue.Width = new Unit(cellHeight / 2, UnitType.Cm);
            txtFirstTotalAbsentsValue.Height = new Unit(cellWidth, UnitType.Cm);
            txtFirstTotalAbsentsValue.Left = new Unit(txtTotalAbsents.Right.Value, UnitType.Cm);
            txtFirstTotalAbsentsValue.Top = new Unit(top, UnitType.Cm);
            txtFirstTotalAbsentsValue.Style.TextAlign = HorizontalAlign.Center;
            txtFirstTotalAbsentsValue.Style.VerticalAlign = VerticalAlign.Middle;
            txtFirstTotalAbsentsValue.Style.BorderStyle.Default = BorderType.Solid;
            txtFirstTotalAbsentsValue.Culture = new CultureInfo("en-us");

            Telerik.Reporting.TextBox txtSecondTotalAbsentsValue = new Telerik.Reporting.TextBox();
            txtSecondTotalAbsentsValue.Value = "=GetSecondTotalAbsents(ReportItem.DataObject.RawData)";
            txtSecondTotalAbsentsValue.Width = new Unit(cellHeight / 2, UnitType.Cm);
            txtSecondTotalAbsentsValue.Height = new Unit(cellWidth, UnitType.Cm);
            txtSecondTotalAbsentsValue.Left = new Unit(txtFirstTotalAbsentsValue.Right.Value, UnitType.Cm);
            txtSecondTotalAbsentsValue.Top = new Unit(top, UnitType.Cm);
            txtSecondTotalAbsentsValue.Style.TextAlign = HorizontalAlign.Center;
            txtSecondTotalAbsentsValue.Style.VerticalAlign = VerticalAlign.Middle;
            txtSecondTotalAbsentsValue.Style.BorderStyle.Default = BorderType.Solid;
            txtSecondTotalAbsentsValue.Culture = new CultureInfo("en-us");
            #endregion
            panel3.Items.Add(txtTotalAbsents);
            panel3.Items.Add(txtFirstTotalAbsentsValue);
            panel3.Items.Add(txtSecondTotalAbsentsValue);

            #region Average Grade

            left += 2 * cellHeight + 1f;
            Telerik.Reporting.TextBox txtAverageGradeText = new Telerik.Reporting.TextBox();
            txtAverageGradeText.Value = "A.G";
            txtAverageGradeText.Width = new Unit(cellHeight + 0.1, UnitType.Cm);
            txtAverageGradeText.Height = new Unit(cellWidth, UnitType.Cm);
            txtAverageGradeText.Left = new Unit(left, UnitType.Cm);
            txtAverageGradeText.Top = new Unit(top, UnitType.Cm);
            txtAverageGradeText.Style.TextAlign = HorizontalAlign.Center;
            txtAverageGradeText.Style.VerticalAlign = VerticalAlign.Middle;
            txtAverageGradeText.Style.BorderStyle.Default = BorderType.Solid;
            txtAverageGradeText.Style.BackgroundColor = Color.Pink;
            txtAverageGradeText.Style.Font.Bold = true;

            Telerik.Reporting.TextBox txtAverageGrade = new Telerik.Reporting.TextBox();
            txtAverageGrade.Value = "=rptMasterCard_GetTotalAverageMarkText(ReportItem.DataObject.RawData)";
            txtAverageGrade.Width = new Unit(cellHeight, UnitType.Cm);
            txtAverageGrade.Height = new Unit(cellWidth, UnitType.Cm);
            txtAverageGrade.Left = new Unit(txtAverageGradeText.Right.Value, UnitType.Cm);
            txtAverageGrade.Top = new Unit(top, UnitType.Cm);
            txtAverageGrade.Style.TextAlign = HorizontalAlign.Center;
            txtAverageGrade.Style.VerticalAlign = VerticalAlign.Middle;
            txtAverageGrade.Style.BorderStyle.Default = BorderType.Solid;
            txtAverageGrade.Culture = new CultureInfo("en-us");

            #endregion
            panel3.Items.Add(txtAverageGradeText);
            panel3.Items.Add(txtAverageGrade);

        }
    }
}