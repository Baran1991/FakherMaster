using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Buffet;
using Fakher.Core.Report;
using rComponents;

namespace Fakher.Reports.Buffet_Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    public partial class rptProductStat : Report, IConfigurableReport
    {
        public rptProductStat()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public BuffetProduct BuffetProduct { get; set; }


        public static string TodayDate()
        {
            return PersianDate.Today.ToShortDateString();
        }

        private void txtReportName_ItemDataBinding(object sender, EventArgs e)
        {
            if (ParamForm != null)
            {
                if (ParamForm.StartDate == ParamForm.EndDate)
                    txtReportName.Value = ReportName + " " + BuffetProduct.Name + " (" +
                                          ParamForm.StartDate.ToShortDateString() + ")";
                else
                    txtReportName.Value = ReportName + " " + BuffetProduct.Name + " (" +
                                          ParamForm.StartDate.ToShortDateString() + " تا " +
                                          ParamForm.EndDate.ToShortDateString() + ")";
            }
            else
            {
                txtReportName.Value = ReportName + " " + BuffetProduct.Name + " (" +
                                          PersianDate.Today.ToShortDateString() + ")";
            }
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش فروش یک کالا"; }
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

            frm.CustomText1 = "کالا:";
            frm.CustomGridColumns1 = new Dictionary<string, string> {{"نام کالا", "Name"}};
            frm.CustomGridDataSource1 = BuffetProduct.GetAllProducts();
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            BuffetProduct = frm.CustomGridValue1 as BuffetProduct;
            DataSet = BuffetProduct.GetSupplies(frm.StartDate, frm.EndDate);
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion
    }
}