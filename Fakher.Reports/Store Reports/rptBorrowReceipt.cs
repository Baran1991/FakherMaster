using System.Collections.Generic;
using Fakher.Core;
using Fakher.Core.DomainModel;
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
    public partial class rptBorrowReceipt : Report
    {
        public rptBorrowReceipt()
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

        public static string rptBorrowReceipt_GetPersonName(Use use)
        {
            return use.Person.FarsiFullname;
        }

        public static string rptBorrowReceipt_GetDescription()
        {
            return AppSetting.GetSetting(SettingKeys.BorrowReceiptDescription);
        }

        private void txtReportName_ItemDataBinding(object sender, EventArgs e)
        {

        }
    }
}