using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    /// <summary>
    /// Summary description for rptExamParticipateList.
    /// </summary>
    public partial class rptFaExamAbsents : Report, IConfigurableReport
    {
        public rptFaExamAbsents()
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
            get { return "گزارش غائبین آزمون"; }
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
                               new List<object> {"اتاق", "ExamFormation.Place.Name"},
                               new List<object> {"شماره صندلی/آزمون", "SeatNumber"},
                               new List<object> {"زمان آزمون", "ExamTimeText"},
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
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            if(frm.ExamSection == null)
                DataSet = frm.Exam.GetAbsentParticipates();
            else
                DataSet = frm.Exam.GetAbsentParticipates(frm.ExamSection);
        }

        public void Apply(IReportParameterForm frm)
        {
            textBox6.Value = ReportName + " " + frm.Exam.Name;
            DataSource = DataSet;
        }

        #endregion
    }
}