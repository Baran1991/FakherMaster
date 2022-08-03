using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
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
    /// Summary description for rptIdCard.
    /// </summary>
    public partial class rptFaExamCard : Report, IConfigurableReport
    {
        public rptFaExamCard()
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
            get { return "گزارش کارت ورود به جلسه"; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام", "Register.Student.FarsiFirstName"},
                               new List<object> {"نام خانوادگی", "Register.Student.FarsiLastName"},
                               new List<object> {"وضعیت مالی", "Register.FarsiFinancialStatusVerboseText"}
                           };
            }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowExams = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            frm.Exam.CheckExamHolding();

            DataSet = frm.Exam.GetParticipates();
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion

        private void rptFaExamCard_ItemDataBound(object sender, EventArgs e)
        {
//            foreach (ExamParticipate participate in (DataSource as IEnumerable))
//            {
//                participate.SetExamCardReceive(true);
//                participate.Save();
//            }
        }

        private void textBox6_ItemDataBinding(object sender, EventArgs e)
        {
            string note = "";
            foreach (ExamParticipate participate in (DataSource as IEnumerable))
            {
                note = participate.ExamForm.Exam.CardNote;
                break;
            }
            textBox6.Value = note;
        }

        public static string rptFaExamCard_GetDay(ExamParticipate participate)
        {
            if (participate.Formation != null)
                return participate.Formation.DayText;
            return "";
        }

        public static string rptFaExamCard_GetTime(ExamParticipate participate)
        {
            if (participate.Formation != null)
                return participate.Formation.Time;
            return "";
        }

        public static string rptFaExamCard_GetPlace(ExamParticipate participate)
        {
            if (participate.Formation != null)
                return participate.Formation.Place.Name;
            return "";
        }

        public static string rptFaExamCard_GetExamNumber(ExamParticipate participate)
        {
            if (participate.ExamForm.Exam.Type == ExamType.OralExam)
                return participate.ExamForm.Name;
            return participate.SeatNumber + "";
        }

        public static string rptFaExamCard_GetExamNumberText(ExamParticipate participate)
        {
            if (participate.ExamForm.Exam.Type == ExamType.OralExam)
                return "شماره پاکت";
            return "شمـاره صندلـی";
        }

        public static Image rptFaExamCard_GetStudentPhoto(ExamParticipate participate)
        {
            try
            {
                Bitmap original = participate.Register.Student.Photo.Picture;
                if (original != null)
                {
                    Bitmap bmp = new Bitmap(original);
                    Image image = bmp.GetThumbnailImage(75, 82, null, IntPtr.Zero);
                    bmp.Dispose();
                    return image;
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }
    }
}