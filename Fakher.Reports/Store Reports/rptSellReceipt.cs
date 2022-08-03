using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.Reports
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Fakher.Core.Report;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptBorrowReciept.
    /// </summary>
    public partial class rptSellReceipt : Report
    {
        public List<Use> fItems { get; set; } = new List<Use>();

        public rptSellReceipt()
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
        public IEnumerable DataSet { get; set; }

        public string ReportName
        {
            get; set;
        }

        public static string rptSellReceipt_GetPersonName(Use use)
        {
            return use.Person.FarsiFullname;
        }

        public static string rptSellReceipt_GetRegistrarName(Use use)
        {
            Person registrar = use.GetRegistrar();
            if (registrar != null)
                return registrar.FarsiFullname;
            return "";
        }

        private void txtReportName_ItemDataBinding(object sender, EventArgs e)
        {

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
    }
}