using System.Collections;
using System.Linq;
using DataAccessLayer;
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
    using System.Collections.Generic;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptDailyRegisterStat.
    /// </summary>
    public partial class rptReserveListFullStat : Report, IConfigurableReport
    {
        public string Title { get; set; }
        private static IEnumerable mReserveLists;

        public rptReserveListFullStat()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void textBox6_ItemDataBinding(object sender, EventArgs e)
        {
            textBox6.Value = Title;
        }

        public static string TodayDate()
        {
            return PersianDate.Today.ToShortDateString();
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش لیست های رزرو"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowStructure = true;
            frm.ShowMajor = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            List<ReserveList> reserveLists = ReserveList.GetReserveList(frm.Period, frm.Major);
            DataSet = reserveLists;
        }

        public void Apply(IReportParameterForm frm)
        {
            Title = ReportName + " رشته " + frm.Major.Name;
            mReserveLists = DataSet;
            DataSource = DataSet;
        }

        #endregion

        public static long rptReserveListFullStat_GetPayableTuition(ReserveList reserveList)
        {
            var query = from reserve in reserveList.Reserves
                        select reserve.PayableTuition;
            return query.Sum();
        }

        public static long rptReserveListFullStat_GetPayableTuition()
        {
            var query = from ReserveList reserveList in mReserveLists
                        select rptReserveListFullStat_GetPayableTuition(reserveList);
            return query.Sum();
        }

        public static long rptReserveListFullStat_GetCash(ReserveList reserveList)
        {
            return reserveList.Reserves.Sum(x => x.FinancialDocument.CashBalance) +
                   reserveList.Reserves.Sum(x => x.FinancialDocument.ReceiptBalance) +
                   reserveList.Reserves.Sum(x => x.FinancialDocument.EPaymentBalance) +
                   reserveList.Reserves.Sum(x => x.FinancialDocument.PassedChequeBalance);
        }

        public static long rptReserveListFullStat_GetCash()
        {
            var query = from ReserveList reserveList in mReserveLists
                        select rptReserveListFullStat_GetCash(reserveList);
            return query.Sum();
        }

        public static long rptReserveListFullStat_GetInProgressCheque(ReserveList reserveList)
        {
            return reserveList.Reserves.Sum(x => x.FinancialDocument.InProgressChequeBalance);
        }

        public static long rptReserveListFullStat_GetInProgressCheque()
        {
            var query = from ReserveList reserveList in mReserveLists
                        select rptReserveListFullStat_GetInProgressCheque(reserveList);
            return query.Sum();
        }

        public static long rptReserveListFullStat_GetReturnedCheque(ReserveList reserveList)
        {
            return reserveList.Reserves.Sum(x => x.FinancialDocument.ReturnedChequeBalance);
        }

        public static long rptReserveListFullStat_GetReturnedCheque()
        {
            var query = from ReserveList reserveList in mReserveLists
                        select rptReserveListFullStat_GetReturnedCheque(reserveList);
            return query.Sum();
        }

        public static long rptReserveListFullStat_GetSuspendedCheque(ReserveList reserveList)
        {
            return reserveList.Reserves.Sum(x => x.FinancialDocument.SuspendedChequeBalance);
        }

        public static long rptReserveListFullStat_GetSuspendedCheque()
        {
            var query = from ReserveList reserveList in mReserveLists
                        select rptReserveListFullStat_GetSuspendedCheque(reserveList);
            return query.Sum();
        }

        public static long rptReserveListFullStat_GetDiscount(ReserveList reserveList)
        {
            return reserveList.Reserves.Sum(x => x.FinancialDocument.DiscountBalance);
        }

        public static long rptReserveListFullStat_GetDiscount()
        {
            var query = from ReserveList reserveList in mReserveLists
                        select rptReserveListFullStat_GetDiscount(reserveList);
            return query.Sum();
        }

        public static long rptReserveListFullStat_GetDebt(ReserveList reserveList)
        {
            return reserveList.Reserves.Sum(x => x.FinancialDocument.DebtBalance);
        }

        public static long rptReserveListFullStat_GetDebt()
        {
            var query = from ReserveList reserveList in mReserveLists
                        select rptReserveListFullStat_GetDebt(reserveList);
            return query.Sum();
        }
    }
}