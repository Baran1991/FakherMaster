using System.Collections;
using System.Collections.Generic;
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

    /// <summary>
    /// Summary description for rptExamRequestList.
    /// </summary>
    public partial class rptExamRequestList : Report, IConfigurableReport
    {
        public rptExamRequestList()
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

        private void textBox6_ItemDataBinding(object sender, EventArgs e)
        {

        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش درخواست های آزمون"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowDate = true;
            frm.ShowParam1 = true;
            frm.Param1Text = "وضعیت درخواست:";
            frm.Param1DataSource = typeof (ExamRequestStatus).GetEnumDescriptions();
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            IList<ExamRequest> requests = ExamRequest.GetRequests(frm.StartDate, frm.EndDate);
            IQueryable<ExamRequest> examRequests = ExamRequest.GetRequests(requests, (ExamRequestStatus)frm.Param1SelectedIndex);
            DataSet = examRequests;
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
            textBox6.Value = ReportName + " " + frm.Param1Text;
        }

        #endregion
    }
}