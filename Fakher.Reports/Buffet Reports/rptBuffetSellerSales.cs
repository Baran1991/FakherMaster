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
    public partial class rptBuffetSellerSales : Report, IConfigurableReport
    {
        public BuffetSeller BuffetSeller { get; set; }

        public rptBuffetSellerSales()
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
            if (ParamForm != null)
            {
                if (ParamForm.StartDate == ParamForm.EndDate)
                    txtReportName.Value = ReportName + " " + BuffetSeller.FarsiFullname + " (" +
                                          ParamForm.StartDate.ToShortDateString() + ")";
                else
                    txtReportName.Value = ReportName + " " + BuffetSeller.FarsiFullname + " (" +
                                          ParamForm.StartDate.ToShortDateString() + " تا " +
                                          ParamForm.EndDate.ToShortDateString() + ")";
            }
            else
            {
                txtReportName.Value = ReportName + " " + BuffetSeller.FarsiFullname + " (" +
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
            get { return "گزارش فروش"; }
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

            frm.CustomText1 = "فروشنده:";
            frm.CustomGridColumns1 = new Dictionary<string, string>();
            frm.CustomGridColumns1.Add("نام", "FarsiFullname");

            frm.CustomGridDataSource1 = BuffetSeller.GetBuffetSellers();
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            BuffetSeller = frm.CustomGridValue1 as BuffetSeller;
            DataSet = BuffetSaleItem.GetItems(frm.StartDate, frm.EndDate);
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion
    }
}