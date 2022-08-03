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

    /// <summary>
    /// Summary description for rptStudentContacts.
    /// </summary>
    public partial class rptIncompleteRegisterContacts : Report, IConfigurableReport
    {
        public rptIncompleteRegisterContacts()
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
            get { return "گزارش دانشجویان دارای مدارک ناقص"; }
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
            IList<Register> registers = Register.GetIncompletedRegisters(frm.Period, frm.Major);
            DataSet = registers;
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion
    }
}