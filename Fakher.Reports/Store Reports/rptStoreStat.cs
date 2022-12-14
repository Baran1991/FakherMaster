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
    /// Summary description for rptStoreSells.
    /// </summary>
    public partial class rptStoreStat : Report, IConfigurableReport
    {
        public rptStoreStat()
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

        //        public static string GetTotalCount()
        //        {
        //            Telerik.Reporting.DataSource
        //        }
        //
        //        public static string GetTotalAmount()
        //        {
        //            
        //        }
        //
        //        public static string GetTotalProfit()
        //        {
        //            
        //        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش فروش و سود انتشارات"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowDate = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            DataSet = Use.GetUses(frm.StartDate, frm.EndDate).ToList();
        }

        public void Apply(IReportParameterForm frm)
        {
            txtReportName.Value = ReportName + " از " + frm.StartDate + " تا " + frm.EndDate;
            DataSource = DataSet;
        }

        #endregion

        private List<double> SellSumList = new List<double>();
        private List<double> BenefitSumList = new List<double>();
        private void textBox7_ItemDataBound(object sender, EventArgs e)
        {
            SellSumList.Add((double)((Telerik.Reporting.Processing.TextBox)sender).Value);
        }

        private void textBox23_ItemDataBound(object sender, EventArgs e)
        {
            ((Telerik.Reporting.Processing.TextBox)sender).Value = string.Format("{0:C0}", SellSumList.Sum());
        }

        private void textBox19_ItemDataBound(object sender, EventArgs e)
        {
            BenefitSumList.Add((double)((Telerik.Reporting.Processing.TextBox)sender).Value);
        }

        private void textBox12_ItemDataBound(object sender, EventArgs e)
        {
            ((Telerik.Reporting.Processing.TextBox)sender).Value = string.Format("{0:C0}", BenefitSumList.Sum());
        }
    }
}