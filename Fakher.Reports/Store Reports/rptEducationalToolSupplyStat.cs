using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Buffet;
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
    public partial class rptEducationalToolSupplyStat : Report, IConfigurableReport
    {
        //public static long GetSumOfUses(int educationalToolId,PersianDate date)
        //{
        //    EducationalTool educationalTool=new EducationalTool();
        //    educationalTool.Id = educationalToolId;
        //    return educationalTool.SumOfSuppliesToDate(date);
        //}
        public static int GetSumOfSuplliesToDate(int buffetProductId, int buffetProductSupplyId, PersianDate date)
        {
            return EducationalTool.SumOfSuppliesToDate(buffetProductId, buffetProductSupplyId, date);
        }
        public static int GetSumOfUsesToDate(int buffetProductId, int buffetProductSupplyId, PersianDate date)
        {
            return EducationalTool.SumOfUsesToDate(buffetProductId, buffetProductSupplyId, date);
        }

        public rptEducationalToolSupplyStat()
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
            get { return "گزارش موجودی"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowDate = true;

            frm.ShowCustomStructure = true;
            frm.CustomText1 = "نام کتاب:";
            frm.CustomGridColumns1 = new Dictionary<string, string> { { "نام", "Name" } };
            frm.CustomGridDataSource1 = EducationalTool.GetAllTools();
            frm.ShowCustomGrid1 = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            EducationalTool tool = frm.CustomGridValue1 as EducationalTool;
            DataSet = tool.GetSupplies(frm.StartDate, frm.EndDate);
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion
    }
}