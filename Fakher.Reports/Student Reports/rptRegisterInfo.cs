using System.Collections;
using System.Collections.Generic;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;
using rComponents;
using System.Linq;

namespace Fakher.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    
    /// <summary>
    /// Summary description for rptCareerApplicants.
    /// </summary>
    public partial class rptRegisterInfo : Report, IConfigurableReport
    {
        public Core.DomainModel.Career Career { get; set; }

        public rptRegisterInfo()
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

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش اطلاعات فردی دانشجو"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {

        }

        public void PrepareDataset(IReportParameterForm frm)
        {

        }

        public void Apply(IReportParameterForm frm)
        {

        }

        #endregion
    }
}