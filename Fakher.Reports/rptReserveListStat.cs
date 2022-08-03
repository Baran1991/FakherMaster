using System.Collections;
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
    using System.Collections.Generic;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptDailyRegisterStat.
    /// </summary>
    public partial class rptReserveListStat : Report, IConfigurableReport
    {
        public string Title { get; set; }

        public rptReserveListStat()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void textBox6_ItemDataBinding(object sender, EventArgs e)
        {
            textBox6.Value = Title;
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
            get { return "گزارش آمار رزرو"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowStructure = true;
            frm.ShowMajor = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            List<ReserveList> reserveLists = ReserveList.GetReserveList(frm.Period, frm.Major);
            DataSet = reserveLists;
        }

        public void Apply(IReportParameterForm frm)
        {
            Title = ReportName + " رشته " + frm.Major.Name;
            DataSource = DataSet;
        }

        #endregion
    }
}