using System.Collections;
using System.Collections.Generic;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;
using rComponents;

namespace Fakher.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptAbsenceCount.
    /// </summary>
    public partial class rptStudentAbsences : Report, IConfigurableReport
    {
        public rptStudentAbsences()
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

        private void txtReportName_ItemDataBinding(object sender, EventArgs e)
        {

        }

        public static int GetAllCount(Participate participate)
        {
            return participate.AbsencesCount;
        }

        public static int GetCount(Participate participate, bool isAccepted)
        {
            if (isAccepted)
                return participate.AcceptedAbsencesCount;
            return participate.RejectedAbsencesCount;
        }

        public static string GetAbsenceText(Participate participate)
        {
            List<Absence> absences = participate.GetAbsences().ToList();
            string txt = "";
            foreach (Absence absence in absences)
            {
                txt += absence.Date;
                if (absences.IndexOf(absence) != absences.Count - 1)
                    txt += " - ";
            }
            return txt;
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return true; }
        }

        public string ReportName
        {
            get { return "گزارش دانشجویان غائب"; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام و نام خانوادگی", "Register.Student.FarsiFullname"},
                               new List<object> {"تعداد کل غیبت", "AbsencesCount"},
                               new List<object> {"غیبت موجه", "AcceptedAbsencesCount"},
                               new List<object> {"غیبت غیرموجه", "RejectedAbsencesCount"}
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
            frm.OptionalSection = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            IList<Participate> participates;
            if (frm.SectionItem != null)
                participates = frm.SectionItem.GetParticipates();
            else
                participates = Participate.GetParticipates(frm.Period, frm.Lesson);
            DataSet = participates;
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion
    }
}