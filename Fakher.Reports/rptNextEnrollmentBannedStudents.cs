using System.Linq;
using Fakher.Core.Report;

namespace Fakher.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using rComponents;
    using Fakher.Core.DomainModel;
    using System.Collections.Generic;
    using System.Collections;

    public partial class rptNextEnrollmentBannedStudents : Report, IConfigurableReport
    {
        public rptNextEnrollmentBannedStudents()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void txtReportName_ItemDataBinding(object sender, EventArgs e)
        {

        }

        public static string TodayDate()
        {
            return PersianDate.Today.ToShortDateString();
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش دانشجویان دارای منع ثبت نام"; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                throw new NotImplementedException();
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
            frm.OptionalLesson = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            IQueryable<Participate> participates;
            if (frm.SectionItem != null)
                participates = frm.SectionItem.GetNextEnrollmentBannedParticipates();
            else if (frm.Lesson != null)
                participates = Participate.GetNextEnrollmentBannedParticipates(frm.Period, frm.Lesson);
            else
                participates = Participate.GetNextEnrollmentBannedParticipates(frm.Period);
            DataSet = participates;
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion
    }
}