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
    public partial class rptSignupStatBySection : Report, IConfigurableReport
    {
        private static IList<SectionItem> mSectionItems;

        public string Title { get; set; }

        public rptSignupStatBySection()
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

        private void textBox6_ItemDataBinding(object sender, EventArgs e)
        {
            textBox6.Value = Title;
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public IEnumerable DataSet { get; set; }

        public bool CustomDataset
        {
            get { return true; }
        }

        public string ReportName
        {
            get { return "گزارش آماری-مالی ثبت نام به تفکیک گروه"; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام", "Section.FarsiName"}
                           };
            }
        }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowStructure = true;
            frm.ShowMajor = true;
            frm.ShowLesson = true;
            frm.ShowSection = false;
            frm.OptionalLesson = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            if (frm.Lesson != null)
                DataSet = SectionItem.GetSectionItems(frm.Period, frm.Major, frm.Lesson);
            else
                DataSet = SectionItem.GetSectionItems(frm.Period, frm.Major);
        }

        public void Apply(IReportParameterForm frm)
        {
            Title = ReportName + " از رشته " + frm.Major.Name;

            IList<object> list1 = DataSet as IList<object>;
            IList<SectionItem> list2 = DataSet as IList<SectionItem>;
            mSectionItems = new List<SectionItem>();

            if (list1 != null)
                foreach (SectionItem sectionItem in list1)
                    mSectionItems.Add(sectionItem);
            if (list2 != null)
                foreach (SectionItem sectionItem in list2)
                    mSectionItems.Add(sectionItem);

            DataSource = mSectionItems;
        }

        #endregion

        public static int rptSignupStatBySection_GetCapacity(SectionItem sectionItem)
        {
            return sectionItem.Section.Capacity;
        }

        public static int rptSignupStatBySection_GetLessonCapacity(SectionItem sectionItem)
        {
            int sum = mSectionItems.Where(x=>x.Lesson.Id == sectionItem.Lesson.Id).Select(x => x.Section.Capacity).Sum();
            return sum;
        }

        public static int rptSignupStatBySection_GetTotalCapacity()
        {
            int sum = mSectionItems.Select(x => x.Section.Capacity).Sum();
            return sum;
        }

        public static int rptSignupStatBySection_GetParticipateCount(SectionItem sectionItem)
        {
            return sectionItem.ParticipateCount;
        }

        public static int rptSignupStatBySection_GetLessonParticipateCount(SectionItem sectionItem)
        {
            int sum = mSectionItems.Where(x => x.Lesson.Id == sectionItem.Lesson.Id).Select(x => x.ParticipateCount).Sum();
            return sum;
        }

        public static int rptSignupStatBySection_GetTotalParticipateCount()
        {
            int sum = mSectionItems.Select(x => x.ParticipateCount).Sum();
            return sum;
        }

        public static int rptSignupStatBySection_GetRemainderCount(SectionItem sectionItem)
        {
            return sectionItem.RemainderCount;
        }

        public static int rptSignupStatBySection_GetLessonRemainderCount(SectionItem sectionItem)
        {
            int sum = mSectionItems.Where(x => x.Lesson.Id == sectionItem.Lesson.Id).Select(x => x.RemainderCount).Sum();
            return sum;
        }

        public static int rptSignupStatBySection_GetTotalRemainderCount()
        {
            int sum = mSectionItems.Select(x => x.RemainderCount).Sum();
            return sum;
        }

        public static int rptSignupStatBySection_GetBannedParticipateCount(SectionItem sectionItem)
        {
            return sectionItem.BannedParticipateCount;
        }

        public static int rptSignupStatBySection_GetLessonBannedParticipateCount(SectionItem sectionItem)
        {
            int sum = mSectionItems.Where(x => x.Lesson.Id == sectionItem.Lesson.Id).Select(x => x.BannedParticipateCount).Sum();
            return sum;
        }

        public static int rptSignupStatBySection_GetTotalBannedParticipateCount()
        {
            int sum = mSectionItems.Select(x => x.BannedParticipateCount).Sum();
            return sum;
        }

        public static int rptSignupStatBySection_GetQuitedCount(SectionItem sectionItem)
        {
            return sectionItem.GetAllParticipates().Select(x => x.Register.FullQuitedSign).Sum();
        }        
        
        public static int rptSignupStatBySection_GetLessonQuitedCount(SectionItem sectionItem)
        {
            int sum = mSectionItems.Where(x => x.Lesson.Id == sectionItem.Lesson.Id).Select(x => x.GetAllParticipates()).Select(x => x.Select(y => y.Register.FullQuitedSign).Sum())
                .Sum();
            return sum;
        }

        public static int rptSignupStatBySection_GetTotalQuitedCount()
        {
            int sum = mSectionItems.Select(x => x.GetAllParticipates()).Select(x => x.Select(y => y.Register.FullQuitedSign).Sum())
                .Sum();
            return sum;
        }

        public static long rptSignupStatBySection_GetPayableAmount(SectionItem sectionItem)
        {
            return sectionItem.GetAllParticipates().Select(x => x.Register.PayableTuition).Sum();
        }

        public static long rptSignupStatBySection_GetLessonPayableAmount(SectionItem sectionItem)
        {
            long sum =
                mSectionItems.Where(x => x.Lesson.Id == sectionItem.Lesson.Id).Select(x => x.GetAllParticipates()).
                    Select(x => x.Select(y => y.Register.PayableTuition).Sum())
                    .Sum();
            return sum;
        }

        public static long rptSignupStatBySection_GetTotalPayableAmount()
        {
            long sum =
                mSectionItems.Select(x => x.GetAllParticipates()).
                    Select(x => x.Select(y => y.Register.PayableTuition).Sum())
                    .Sum();
            return sum;
        }

        public static long rptSignupStatBySection_GetCashAmount(SectionItem sectionItem)
        {
            IList<Participate> participates = sectionItem.GetAllParticipates();
            return participates.Select(x => x.Register.FinancialDocument.CashBalance).Sum()
                + participates.Select(x => x.Register.FinancialDocument.ReceiptBalance).Sum()
                + participates.Select(x => x.Register.FinancialDocument.PassedChequeBalance).Sum();
        }

        public static long rptSignupStatBySection_GetLessonCashAmount(SectionItem sectionItem)
        {
            long sum =
                mSectionItems.Where(x => x.Lesson.Id == sectionItem.Lesson.Id).Select(x => x.GetAllParticipates())
                    .Select(
                        x =>
                        x.Select(
                            y => y.Register.FinancialDocument.CashBalance + y.Register.FinancialDocument.ReceiptBalance
                                 + y.Register.FinancialDocument.PassedChequeBalance).Sum()).Sum();
            return sum;
        }

        public static long rptSignupStatBySection_GetTotalCashAmount()
        {
            long sum =
                mSectionItems.Select(x => x.GetAllParticipates())
                    .Select(
                        x =>
                        x.Select(
                            y => y.Register.FinancialDocument.CashBalance + y.Register.FinancialDocument.ReceiptBalance
                                 + y.Register.FinancialDocument.PassedChequeBalance).Sum()).Sum();
            return sum;
        }

        public static long rptSignupStatBySection_GetEPaymentAmount(SectionItem sectionItem)
        {
            IList<Participate> participates = sectionItem.GetAllParticipates();
            return participates.Select(x => x.Register.FinancialDocument.EPaymentBalance).Sum();
        }

        public static long rptSignupStatBySection_GetLessonEPaymentAmount(SectionItem sectionItem)
        {
            long sum =
                mSectionItems.Where(x => x.Lesson.Id == sectionItem.Lesson.Id).Select(x => x.GetAllParticipates())
                    .Select(
                        x =>
                        x.Select(
                            y => y.Register.FinancialDocument.EPaymentBalance).Sum()).Sum();
            return sum;
        }

        public static long rptSignupStatBySection_GetTotalEPaymentAmount()
        {
            long sum =
                mSectionItems.Select(x => x.GetAllParticipates())
                    .Select(
                        x =>
                        x.Select(
                            y => y.Register.FinancialDocument.EPaymentBalance).Sum()).Sum();
            return sum;
        }

        public static long rptSignupStatBySection_GetInProgressAmount(SectionItem sectionItem)
        {
            IList<Participate> participates = sectionItem.GetAllParticipates();
            return participates.Select(x => x.Register.FinancialDocument.InProgressChequeBalance).Sum();
        }

        public static long rptSignupStatBySection_GetLessonInProgressAmount(SectionItem sectionItem)
        {
            long sum =
                mSectionItems.Where(x => x.Lesson.Id == sectionItem.Lesson.Id).Select(x => x.GetAllParticipates())
                    .Select(
                        x =>
                        x.Select(
                            y => y.Register.FinancialDocument.InProgressChequeBalance).Sum()).Sum();
            return sum;
        }

        public static long rptSignupStatBySection_GetTotalInProgressAmount()
        {
            long sum =
                mSectionItems.Select(x => x.GetAllParticipates())
                    .Select(
                        x =>
                        x.Select(
                            y => y.Register.FinancialDocument.InProgressChequeBalance).Sum()).Sum();
            return sum;
        }

        public static long rptSignupStatBySection_GetReturnedAmount(SectionItem sectionItem)
        {
            IList<Participate> participates = sectionItem.GetAllParticipates();
            return participates.Select(x => x.Register.FinancialDocument.ReturnedChequeBalance).Sum();
        }

        public static long rptSignupStatBySection_GetLessonReturnedAmount(SectionItem sectionItem)
        {
            long sum =
                mSectionItems.Where(x => x.Lesson.Id == sectionItem.Lesson.Id).Select(x => x.GetAllParticipates())
                    .Select(
                        x =>
                        x.Select(
                            y => y.Register.FinancialDocument.ReturnedChequeBalance).Sum()).Sum();
            return sum;
        }

        public static long rptSignupStatBySection_GetTotalReturnedAmount()
        {
            long sum =
                mSectionItems.Select(x => x.GetAllParticipates())
                    .Select(
                        x =>
                        x.Select(
                            y => y.Register.FinancialDocument.ReturnedChequeBalance).Sum()).Sum();
            return sum;
        }

        public static long rptSignupStatBySection_GetSuspendAmount(SectionItem sectionItem)
        {
            IList<Participate> participates = sectionItem.GetAllParticipates();
            return participates.Select(x => x.Register.FinancialDocument.SuspendedChequeBalance).Sum();
        }

        public static long rptSignupStatBySection_GetLessonSuspendAmount(SectionItem sectionItem)
        {
            long sum =
                mSectionItems.Where(x => x.Lesson.Id == sectionItem.Lesson.Id).Select(x => x.GetAllParticipates())
                    .Select(
                        x =>
                        x.Select(
                            y => y.Register.FinancialDocument.SuspendedChequeBalance).Sum()).Sum();
            return sum;
        }

        public static long rptSignupStatBySection_GetTotalSuspendAmount()
        {
            long sum =
                mSectionItems.Select(x => x.GetAllParticipates())
                    .Select(
                        x =>
                        x.Select(
                            y => y.Register.FinancialDocument.SuspendedChequeBalance).Sum()).Sum();
            return sum;
        }

        public static long rptSignupStatBySection_GetDiscountBalance(SectionItem sectionItem)
        {
            IList<Participate> participates = sectionItem.GetAllParticipates();
            return participates.Select(x => x.Register.FinancialDocument.DiscountBalance).Sum();
        }        
        
        public static long rptSignupStatBySection_GetLessonDiscountBalance(SectionItem sectionItem)
        {
            long sum =
                mSectionItems.Where(x => x.Lesson.Id == sectionItem.Lesson.Id).Select(x => x.GetAllParticipates())
                    .Select(
                        x =>
                        x.Select(
                            y => y.Register.FinancialDocument.DiscountBalance).Sum()).Sum();
            return sum;
        }     
        
        public static long rptSignupStatBySection_GetTotalDiscountBalance()
        {
            long sum =
                mSectionItems.Select(x => x.GetAllParticipates())
                    .Select(
                        x =>
                        x.Select(
                            y => y.Register.FinancialDocument.DiscountBalance).Sum()).Sum();
            return sum;
        }     
        
        public static long rptSignupStatBySection_GetDebtBalance(SectionItem sectionItem)
        {
            IList<Participate> participates = sectionItem.GetAllParticipates();
            return participates.Select(x => x.Register.DebtAmount).Sum();
        }

        public static long rptSignupStatBySection_GetLessonDebtBalance(SectionItem sectionItem)
        {
            long sum =
                mSectionItems.Where(x => x.Lesson.Id == sectionItem.Lesson.Id).Select(x => x.GetAllParticipates())
                    .Select(
                        x =>
                        x.Select(
                            y => y.Register.DebtAmount).Sum()).Sum();
            return sum;
        }

        public static long rptSignupStatBySection_GetTotalDebtBalance()
        {
            long sum =
                mSectionItems.Select(x => x.GetAllParticipates())
                    .Select(
                        x =>
                        x.Select(
                            y => y.Register.DebtAmount).Sum()).Sum();
            return sum;
        }

        public static long rptSignupStatBySection_GetQuitPenaltyAmount(SectionItem sectionItem)
        {
            IList<Participate> participates = sectionItem.GetAllParticipates();
            return participates.Select(x => x.Register.QuitPenaltyFee).Sum();
        }

        public static long rptSignupStatBySection_GetLessonQuitPenaltyAmount(SectionItem sectionItem)
        {
            long sum =
                mSectionItems.Where(x => x.Lesson.Id == sectionItem.Lesson.Id).Select(x => x.GetAllParticipates())
                    .Select(
                        x =>
                        x.Select(
                            y => y.Register.QuitPenaltyFee).Sum()).Sum();
            return sum;
        }

        public static long rptSignupStatBySection_GetTotalQuitPenaltyAmount()
        {
            long sum =
                mSectionItems.Select(x => x.GetAllParticipates())
                    .Select(
                        x =>
                        x.Select(
                            y => y.Register.QuitPenaltyFee).Sum()).Sum();
            return sum;
        }
    }
}