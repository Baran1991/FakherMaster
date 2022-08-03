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

    public partial class rptFaOralExamResult : Report, IConfigurableReport
    {
        public static Exam[] Exams { get; set; }

        public rptFaOralExamResult()
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

        private void textBox6_ItemDataBinding(object sender, EventArgs e)
        {
            string txt = Exams.Length == 1
                             ? Exams[0].Name + " [" + Exams[0].Date.ToShortDateString() + "]"
                             : Exams.Length + " آزمون";
            textBox6.Value = "نتایج مصاحبه " + txt;
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return true; }
        }

        public string ReportName
        {
            get { return "گزارش نتایج مصاحبه"; }
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
                               new List<object> {"وضعیت", "StatusText"},
                               new List<object> {"نمره", "CalculateMark()"}
                           };
            }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowCustomStructure = true;
            frm.CustomText1 = "رشته:";
            frm.CustomGridColumns1 = new Dictionary<string, string> {{"نام", "Name"}};
            frm.CustomGrid1SelectedIndexChanged += OnCustomGrid1SelectedIndexChanged;
            frm.ShowCustomGrid1 = true;

            frm.CustomText2 = "آیتم ارزشیابی:";
            frm.CustomGridColumns2 = new Dictionary<string, string> { { "نام", "Name" } };
            frm.ShowCustomGrid2 = true;
            frm.CustomGrid2SelectedIndexChanged += OnCustomGrid2SelectedIndexChanged;

            frm.CustomGridViewColumns = new Dictionary<string, string>
                                            {
                                                {"نام آزمون", "Name"},
                                                {"نوع آزمون", "FarsiTypeText"},
                                                {"کلاس/گروه", "FarsiExamSectionsText"}
                                            };
            frm.CustomGridViewCheckBoxes = true;
            frm.ShowCustomGridView = true;

            frm.CustomGridDataSource1 = frm.Period.Department.Majors;

//            frm.ShowExams = true;
        }

        private void OnCustomGrid1SelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            Major major = ParamForm.CustomGridValue1 as Major;
            if (major == null)
                return;
            ParamForm.CustomGridDataSource2 = major.GetExamEvaluationItems(ParamForm.Period);
        }

        private void OnCustomGrid2SelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            Major major = ParamForm.CustomGridValue1 as Major;
            EvaluationItem evaluationItem = ParamForm.CustomGridValue2 as EvaluationItem;
            if (evaluationItem == null)
                return;

            ParamForm.CustomGridViewDataSource = major.GetExams(ParamForm.Period, evaluationItem);
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            Exams = frm.CustomGridViewSelectedItems.Select(x => x as Exam).ToArray();
            DataSet = Exams.SelectMany(x => x.GetFarsiOrderedParticipates());
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion
    }
}