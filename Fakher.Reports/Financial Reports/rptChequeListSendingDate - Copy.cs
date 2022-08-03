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
    public partial class rptChequeListSendingDate : Report, IConfigurableReport
    {
        public List<Cheque> chequItems { get; set; } = new List<Cheque>();
        public rptChequeListSendingDate()
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

        //public string ReportName
        //{
        //    get { return "لیست چکهای ارسالی به بانک "; }
        //}
        public string ReportName
        {
            get;
            set;
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
            DataSet = chequItems;
        }

        public void Apply(IReportParameterForm frm)
        {
            //ChequeStatus status = (ChequeStatus)frm.Param1SelectedIndex;
            txtReportName.Value = ReportName;
            //+ " های " + status.ToDescription() + " از " +
            //                  frm.StartDate.ToShortDateString()
            //                  + " تا " + frm.EndDate.ToShortDateString();
            DataSource = DataSet;
        }

        #endregion
    }
}
