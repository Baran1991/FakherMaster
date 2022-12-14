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
    public partial class rptEPaymentList : Report, IConfigurableReport
    {
        public rptEPaymentList()
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
            get { return "لیست پرداخت های الکترونیکی"; }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowDate = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            List<ElectronicPayment> electronicPayments = ElectronicPayment.GetElectronicPayments(frm.StartDate, frm.EndDate).ToList();
            IQueryable<ElectronicPayment> orderedElectronicPayments = electronicPayments.OrderBy(x => x.Date).AsQueryable();
            DataSet = orderedElectronicPayments.ToList();
        }

        public void Apply(IReportParameterForm frm)
        {
            txtReportName.Value = ReportName + " از " +
                                  frm.StartDate.ToShortDateString()
                                  + " تا " + frm.EndDate.ToShortDateString();
            DataSource = DataSet;
        }

        #endregion
    }
}