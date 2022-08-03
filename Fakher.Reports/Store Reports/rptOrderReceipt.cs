using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Order;
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
    /// Summary description for rptBorrowReciept.
    /// </summary>
    public partial class rptOrderReceipt : Report
    {
        public rptOrderReceipt()
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

        public static string rptSellReceipt_GetPersonName(Order order)
        {
            return order.Person.FarsiFullname;
        }

        private void txtReportName_ItemDataBinding(object sender, EventArgs e)
        {

        }
    }
}