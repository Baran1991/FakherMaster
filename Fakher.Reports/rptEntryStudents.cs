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
    public partial class rptEntryStudents : Report, IConfigurableReport
    {
        public rptEntryStudents()
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

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش دانشجویان ورودی"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowDate = true;
            frm.ShowStructure = true;
            frm.ShowMajor = true;
            frm.ShowLesson = false;
            frm.ShowSection = false;
            frm.OptionalMajor = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            if (frm.Major != null)
                DataSet = Register.GetEntryRegisters(frm.StartDate, frm.EndDate, frm.Major);
            else
                DataSet = Register.GetEntryRegisters(frm.StartDate, frm.EndDate);
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }
    }
}