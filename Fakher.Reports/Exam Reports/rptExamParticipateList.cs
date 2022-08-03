using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fakher.Core.Report;
using rComponents;

namespace Fakher.Reports.Exam_Reports
{
    using Fakher.Core.DomainModel;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Web.UI.WebControls;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptExamParticipateList.
    /// </summary>
    public partial class rptExamParticipateList : Report, IConfigurableReport
    {
        public rptExamParticipateList()
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
            get { return "گزارش شرکت کنندگان آزمون"; }
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
            frm.ShowParam1 = true;
            frm.Param1Text = "وضعیت شرکت کنندگان: ";
            frm.Param1DataSource = typeof(ParticipationExamStatus).GetEnumDescriptions();
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            var list =new List<ExamParticipate>();
            var status = (ParticipationExamStatus)frm.Param1SelectedIndex;
            if (frm.ExamSection == null)
                list = frm.Exam.GetParticipates().ToList();
            else
                list = frm.Exam.GetParticipates(frm.ExamSection).ToList();
            if (status == ParticipationExamStatus.absence)
                list = list.Where(m => m.Status == ExamParticipateStatus.Absent).ToList();
            else if (status == ParticipationExamStatus.none)
                list = list.Where(m => m.Status == ExamParticipateStatus.UnKnown).ToList();
            else if (status == ParticipationExamStatus.hasResult)
                list = list.Where(m => m.Status == ExamParticipateStatus.HasResult).ToList();

            else if (status == ParticipationExamStatus.notParticipate)
                list = frm.Exam.GetNotParticipates();
            DataSet = list;
            
        }

        public void Apply(IReportParameterForm frm)
        {
            textBox6.Value = ReportName + " " + frm.Exam.Name;
            DataSource = DataSet;
        }

        #endregion
    }
    public enum ParticipationExamStatus
    {
        [EnumDescription("ثبت نام نشده")]
        notParticipate,
        [EnumDescription("همه ثبت نامی ها")]
        participate,
        [EnumDescription("غایب")]
        absence,
        
        [EnumDescription("نمره ثبت شده")]
        hasResult,
        [EnumDescription("نا مشخص")]
        none,

    }
}