using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    /// Summary description for rptFaAnswersheetHeader.
    /// </summary>
    public partial class rptFaAnswersheetHeader : Report, IConfigurableReport
    {
        public rptFaAnswersheetHeader()
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
            get { return "گزارش سربرگ و کدینگ پاسخنامه"; }
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
            frm.Param1Text = "پارامتر گزارش:";
            frm.ShowParam1 = true;
            frm.Param1DataSource = new string[] {"همه دانشجویان", "دانشجویان دارای کارت آزمون"};
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            frm.Exam.CheckExamHolding();

            IQueryable<ExamParticipate> participates;
            if (frm.ExamSection != null)
                participates = frm.Exam.GetParticipates(frm.ExamSection).OrderBy(x => x.SeatNumber);
            else
                participates = frm.Exam.GetParticipates().ToList().OrderBy(x => x.SeatNumber).AsQueryable();

            if (frm.Param1SelectedIndex == 0)
                DataSet = participates;
            else
                DataSet = participates.Where(x => x.CardDelivered);
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion

        public static Image rptFaAnswersheetHeader_GetStudentPhoto(ExamParticipate participate)
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