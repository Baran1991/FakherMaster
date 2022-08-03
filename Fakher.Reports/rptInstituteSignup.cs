using System.Collections;
using System.Collections.Generic;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;
using System.Linq;
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
    /// Summary description for rptInstituteSignup.
    /// </summary>
    public partial class rptInstituteSignup : Report, IConfigurableReport
    {
        private static IList<Register> mAllRegisters;
        private static IList<Register> mRegisters;

        public rptInstituteSignup()
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
            get { return "گزارش کلی آماری-مالی موسسه"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowDate = true;
            frm.ShowStructure = false;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            DataSet = DbContext.GetAllEntities<Department>();
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
            textBox6.Value = ReportName + string.Format(" از تاریخ {0} تا {1}", frm.StartDate.ToShortDateString(),
                                            frm.EndDate.ToShortDateString());
            mAllRegisters = Register.GetRegisters(frm.StartDate, frm.EndDate);
            mRegisters = mAllRegisters.Where(x => x.Type == RegisterType.Participation).Where(x=>x.Participates.Count > 0).ToList();
        }

        #endregion

        public static int SignupCount()
        {
            return mRegisters.Sum(x => x.ParticipationSign);
        }
        public static int SignupCount(Major major)
        {
            return mRegisters.Where(x => x.Major.Id == major.Id).Sum(x => x.ParticipationSign);
        }
        public static int SignupCountDept(Department department)
        {
            return mRegisters.Where(x => x.Period.Department.Id == department.Id).Sum(x => x.ParticipationSign);
        }
        public static int QuitCount()
        {
            return mAllRegisters.Sum(x => x.FullQuitedSign);
        }
        public static int QuitCount(Major major)
        {
            return mAllRegisters.Where(x => x.Major.Id == major.Id).Sum(x => x.FullQuitedSign);
        }
        public static int QuitCountDept(Department department)
        {
            return mAllRegisters.Where(x => x.Period.Department.Id == department.Id).Sum(x => x.FullQuitedSign);
        }
        public static int DebtCount()
        {
            return mRegisters.Sum(x => x.DebtorSign);
        }
        public static int DebtCount(Major major)
        {
            return mRegisters.Where(x => x.Major.Id == major.Id).Sum(x => x.DebtorSign);
        }
        public static int DebtCountDept(Department department)
        {
            return mRegisters.Where(x => x.Period.Department.Id == department.Id).Sum(x => x.DebtorSign);
        }
        public static long PayableAmount()
        {
            return mRegisters.Sum(x => x.PayableTuition);
        }
        public static long PayableAmount(Major major)
        {
            return mRegisters.Where(x => x.Major.Id == major.Id).Sum(x => x.PayableTuition);
        }
        public static long PayableAmountDept(Department department)
        {
            return mRegisters.Where(x => x.Period.Department.Id == department.Id).Sum(x => x.PayableTuition);
        }
        public static long CashAmount()
        {
            return mRegisters.Sum(x => x.FinancialDocument.CashBalance + x.FinancialDocument.ReceiptBalance + x.FinancialDocument.PassedChequeBalance + x.FinancialDocument.EPaymentBalance);
        }
        public static long CashAmount(Major major)
        {
            return mRegisters.Where(x => x.Major.Id == major.Id).Sum(x => x.FinancialDocument.CashBalance + x.FinancialDocument.ReceiptBalance + x.FinancialDocument.PassedChequeBalance + x.FinancialDocument.EPaymentBalance);
        }
        public static long CashAmountDept(Department department)
        {
            return mRegisters.Where(x => x.Period.Department.Id == department.Id).Sum(x => x.FinancialDocument.CashBalance + x.FinancialDocument.ReceiptBalance + x.FinancialDocument.PassedChequeBalance + x.FinancialDocument.EPaymentBalance);
        }
        public static long InProgressChequeAmount()
        {
            return mRegisters.Sum(x => x.FinancialDocument.InProgressChequeBalance);
        }
        public static long InProgressChequeAmount(Major major)
        {
            return mRegisters.Where(x => x.Major.Id == major.Id).Sum(x => x.FinancialDocument.InProgressChequeBalance);
        }
        public static long InProgressChequeAmountDept(Department department)
        {
            return mRegisters.Where(x => x.Period.Department.Id == department.Id).Sum(x => x.FinancialDocument.InProgressChequeBalance);
        }
        public static long ReturnedChequeAmount()
        {
            return mRegisters.Sum(x => x.FinancialDocument.ReturnedChequeBalance);
        }
        public static long ReturnedChequeAmount(Major major)
        {
            return mRegisters.Where(x => x.Major.Id == major.Id).Sum(x => x.FinancialDocument.ReturnedChequeBalance);
        }
        public static long ReturnedChequeAmountDept(Department department)
        {
            return mRegisters.Where(x => x.Period.Department.Id == department.Id).Sum(x => x.FinancialDocument.ReturnedChequeBalance);
        }
        public static long SuspendedChequeAmount()
        {
            return mRegisters.Sum(x => x.FinancialDocument.SuspendedChequeBalance);
        }
        public static long SuspendedChequeAmount(Major major)
        {
            return mRegisters.Where(x => x.Major.Id == major.Id).Sum(x => x.FinancialDocument.SuspendedChequeBalance);
        }
        public static long SuspendedChequeAmountDept(Department department)
        {
            return mRegisters.Where(x => x.Period.Department.Id == department.Id).Sum(x => x.FinancialDocument.SuspendedChequeBalance);
        }
        public static long DiscountAmount()
        {
            return mRegisters.Sum(x => x.FinancialDocument.DiscountBalance);
        }
        public static long DiscountAmount(Major major)
        {
            return mRegisters.Where(x => x.Major.Id == major.Id).Sum(x => x.FinancialDocument.DiscountBalance);
        }
        public static long DiscountAmountDept(Department department)
        {
            return mRegisters.Where(x => x.Period.Department.Id == department.Id).Sum(x => x.FinancialDocument.DiscountBalance);
        }
        public static long DebtAmount()
        {
            return mRegisters.Sum(x => x.DebtAmount);
        }
        public static long DebtAmount(Major major)
        {
            return mRegisters.Where(x => x.Major.Id == major.Id).Sum(x => x.DebtAmount);
        }
        public static long DebtAmountDept(Department department)
        {
            return mRegisters.Where(x => x.Period.Department.Id == department.Id).Sum(x => x.DebtAmount);
        }
        public static long QuitAmount()
        {
            return mAllRegisters.Sum(x => x.QuitPenaltyFee);
        }
        public static long QuitAmount(Major major)
        {
            return mAllRegisters.Where(x => x.Major.Id == major.Id).Sum(x => x.QuitPenaltyFee);
        }
        public static long QuitAmountDept(Department department)
        {
            return mAllRegisters.Where(x => x.Period.Department.Id == department.Id).Sum(x => x.QuitPenaltyFee);
        }
    }
}