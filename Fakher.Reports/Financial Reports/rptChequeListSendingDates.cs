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
    /// Summary description for rptChequeList.
    /// </summary>
    public partial class rptChequeListSendingDates : Report, IConfigurableReport
    {
        public List<Cheque> fItems { get; set; } = new List<Cheque>();
        public rptChequeListSendingDates()
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

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public string ReportName
        {
            get; set;
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowDate = true;
            frm.ShowParam1 = true;
            frm.Param1Text = "وضعیت چک:";
            frm.Param1DataSource = typeof(ChequeStatus).GetEnumDescriptions();
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            DataSet = fItems;
        }

        public void Apply(IReportParameterForm frm)
        {
            txtReportName.Value = ReportName;
            DataSource = DataSet;
        }

        #endregion
    }
}
