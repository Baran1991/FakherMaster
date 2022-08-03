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
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Linq;

    /// <summary>
    /// Summary description for rptDiscountedRegisters.
    /// </summary>
    public partial class rptDiscountedRegisters : Report, IConfigurableReport
    {
        public rptDiscountedRegisters()
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

        public string ReportName
        {
            get { return "گزارش تخفیف دانشجویان"; }
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
            DataSet = Register.GetRegisters(frm.Period, frm.Major).Where(x=>x.FinancialDocument.DiscountBalance > 0);
        }

        public void Apply(IReportParameterForm frm)
        {
            txtReportName.Value = ReportName + " رشته " + frm.Major.Name;

            DataSource = DataSet;
        }

        #endregion
    }
}