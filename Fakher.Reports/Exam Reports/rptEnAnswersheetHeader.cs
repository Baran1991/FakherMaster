using System.Collections;
using System.Collections.Generic;
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
    /// Summary description for rptFaAnswersheetHeader.
    /// </summary>
    public partial class rptEnAnswersheetHeader : Report, IConfigurableReport
    {
        private static int count;

        public rptEnAnswersheetHeader()
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
            frm.IsRightToLeft = false;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            frm.Exam.CheckExamHolding();

            if (frm.ExamSection != null)
                DataSet = frm.Exam.GetEnglishOrderedParticipates(frm.ExamSection);
            else
                DataSet = frm.Exam.GetEnglishOrderedParticipates();
        }

        public void Apply(IReportParameterForm frm)
        {
            count = 0;
            DataSource = DataSet;
        }

        #endregion

        public static string EnAnswersheetHeader_GetExamSection(ExamParticipate participate)
        {
            count++;
            ExamSection examSection = participate.GetSection();
            if(examSection != null)
                return examSection.SectionItem.Section.EnglishName;
            return "";
        }

        private void rptEnAnswersheetHeader_Error(object sender, ErrorEventArgs eventArgs)
        {
            Exception exception = eventArgs.Exception;
        }

        public static Image rptEnAnswersheetHeader_GetStudentPhoto(ExamParticipate participate)
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