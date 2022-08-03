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
    /// Summary description for rptDiscountedRegisters.
    /// </summary>
    public partial class rptFaStudentFinancialDetails : Report, IConfigurableReport
    {
        public FinancialDocument document { get; set; }
        public PersianDate Date { get; set; }
        public List<FinancialItem> fItems { get; set; } = new List<FinancialItem>();
        public rptFaStudentFinancialDetails()
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
            get;
            set;
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>();
            }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowStructure = false;
            frm.ShowMajor = false;
            frm.ShowDate = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            //var lst = new List<FinancialItem>();
            //lst.Add(new FinancialItem() { Text = "حساب روزانه شما به  مبلغ" + Amount.ToString() + "در تاریخ " + Date + " تسویه شد.", Amount = Amount, Date = Date });
            DataSet = document.Items;
        }

        public void Apply(IReportParameterForm frm)
        {
            txtReportName.Value = ReportName + " " + document.Person.FarsiFullname + " در تاریخ " + Date;
            DataSource = DataSet;
        }

        #endregion
    }
}