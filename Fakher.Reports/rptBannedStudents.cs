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

    public partial class rptBannedStudents : Report, IConfigurableReport
    {
        public rptBannedStudents()
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

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش دانشجویان معلـــق"; }
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
                participates = frm.SectionItem.GetBannedParticipates();
            else if (frm.Lesson != null)
                participates = Participate.GetBannedParticipates(frm.Period, frm.Lesson);
            else
                participates = Participate.GetBannedParticipates(frm.Period);

            DataSet = participates;
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion
    }
}