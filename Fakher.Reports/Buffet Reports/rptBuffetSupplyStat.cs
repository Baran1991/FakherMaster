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
    public partial class rptBuffetSupplyStat : Report, IConfigurableReport
    {
        public rptBuffetSupplyStat()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        
        public static int GetSumOfSuplliesToDate(int educationalToolId, int educationalToolSupplyId, PersianDate date)
        {
            return BuffetProduct.SumOfSuppliesToDate(educationalToolId, educationalToolSupplyId, date);
        }
        public static int GetSumOfUsesToDate(int educationalToolId, int educationalToolSupplyId, PersianDate date)
        {
            return EducationalTool.SumOfUsesToDate(educationalToolId, educationalToolSupplyId, date);
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
            frm.CustomText1 = "نام کالا:";
            frm.CustomGridColumns1 = new Dictionary<string, string> { { "نام", "Name" } };
            frm.CustomGridDataSource1 = BuffetProduct.GetAllProducts();
            frm.ShowCustomStructure = true;
            frm.ShowCustomGrid1 = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            BuffetProduct product = frm.CustomGridValue1 as BuffetProduct;
            DataSet = product.Supplies;
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion
    }
}