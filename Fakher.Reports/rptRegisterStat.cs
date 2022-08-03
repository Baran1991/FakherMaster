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
    public partial class rptRegisterStat : Report, IConfigurableReport
    {
        public string Title { get; set; }
        private static IList<SectionItem> mSectionItems;

        public rptRegisterStat()
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
            get { return "گزارش آمار دانشجویان به تفکیک درس/سطح"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {

        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            IList<SectionItem> sectionItems = SectionItem.GetSectionItems(frm.Period);
            DataSet = sectionItems;
        }

        public void Apply(IReportParameterForm frm)
        {
            Title = ReportName;

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

        public static float ConvertToPercent(float value, float total)
        {
            return (value/total)*100;
        }

        public static int rptRegisterStat_GetGroupCount(SectionItem sectionItem)
        {
            return mSectionItems.Where(x=>x.Lesson.Id == sectionItem.Lesson.Id).Count();
        }

        public static int rptRegisterStat_GetMajorGroupCount(SectionItem sectionItem)
        {
            return mSectionItems.Where(x=>x.Lesson.Major.Id == sectionItem.Lesson.Major.Id).Count();
        }

        public static int rptRegisterStat_GetTotalGroupCount()
        {
            return mSectionItems.Count();
        }

        public static int rptRegisterStat_GetCapacity(SectionItem sectionItem)
        {
            return mSectionItems.Where(x => x.Lesson.Id == sectionItem.Lesson.Id).Select(x => x.Section.Capacity).Sum();
        }

        public static int rptRegisterStat_GetMajorCapacity(SectionItem sectionItem)
        {
            return mSectionItems.Where(x => x.Lesson.Major.Id == sectionItem.Lesson.Major.Id).Select(x => x.Section.Capacity).Sum();
        }

        public static int rptRegisterStat_GetTotalCapacity()
        {
            return mSectionItems.Select(x => x.Section.Capacity).Sum();
        }

        public static int rptRegisterStat_GetParticipateCount(SectionItem sectionItem)
        {
            return mSectionItems.Where(x => x.Lesson.Id == sectionItem.Lesson.Id).Select(x => x.ParticipateCount).Sum();
        }

        public static int rptRegisterStat_GetMajorParticipateCount(SectionItem sectionItem)
        {
            int sum = mSectionItems.Where(x => x.Lesson.Major.Id == sectionItem.Lesson.Major.Id).Select(x => x.ParticipateCount).Sum();
            return sum;
        }

        public static int rptRegisterStat_GetTotalParticipateCount()
        {
            int sum = mSectionItems.Select(x => x.ParticipateCount).Sum();
            return sum;
        }

        public static float rptRegisterStat_GetParticipatePercent(SectionItem sectionItem)
        {
            return ConvertToPercent(rptRegisterStat_GetParticipateCount(sectionItem),
                                    rptRegisterStat_GetCapacity(sectionItem));
        }

        public static float rptRegisterStat_GetMajorParticipatePercent(SectionItem sectionItem)
        {
            return ConvertToPercent(rptRegisterStat_GetMajorParticipateCount(sectionItem),
                        rptRegisterStat_GetMajorCapacity(sectionItem));
        }

        public static float rptRegisterStat_GetTotalParticipatePercent()
        {
            return ConvertToPercent(rptRegisterStat_GetTotalParticipateCount(),
                        rptRegisterStat_GetTotalCapacity());
        }

        public static int rptRegisterStat_GetRemainderCount(SectionItem sectionItem)
        {
            return mSectionItems.Where(x => x.Lesson.Id == sectionItem.Lesson.Id).Select(x => x.RemainderCount).Sum();
        }

        public static int rptRegisterStat_GetMajorRemainderCount(SectionItem sectionItem)
        {
            return mSectionItems.Where(x => x.Lesson.Major.Id == sectionItem.Lesson.Major.Id).Select(x => x.RemainderCount).Sum();
        }

        public static int rptRegisterStat_GetTotalRemainderCount()
        {
            return mSectionItems.Select(x => x.RemainderCount).Sum();
        }

        public static float rptRegisterStat_GetRemainderPercent(SectionItem sectionItem)
        {
            return ConvertToPercent(rptRegisterStat_GetRemainderCount(sectionItem),
                                    rptRegisterStat_GetCapacity(sectionItem));
        }

        public static float rptRegisterStat_GetMajorRemainderPercent(SectionItem sectionItem)
        {
            return ConvertToPercent(rptRegisterStat_GetMajorRemainderCount(sectionItem),
                                    rptRegisterStat_GetMajorCapacity(sectionItem));
        }

        public static float rptRegisterStat_GetTotalRemainderPercent()
        {
            return ConvertToPercent(rptRegisterStat_GetTotalRemainderCount(),
                                    rptRegisterStat_GetTotalCapacity());
        }

        public static int rptRegisterStat_GetBannedParticipateCount(SectionItem sectionItem)
        {
            return mSectionItems.Where(x => x.Lesson.Id == sectionItem.Lesson.Id).Select(x => x.BannedParticipateCount).Sum();
        }

        public static int rptRegisterStat_GetMajorBannedParticipateCount(SectionItem sectionItem)
        {
            return mSectionItems.Where(x => x.Lesson.Major.Id == sectionItem.Lesson.Major.Id).Select(x => x.BannedParticipateCount).Sum();
        }

        public static int rptRegisterStat_GetTotalBannedParticipateCount()
        {
            return mSectionItems.Select(x => x.BannedParticipateCount).Sum();
        }

        public static float rptRegisterStat_GetBannedParticipatePercent(SectionItem sectionItem)
        {
            return ConvertToPercent(rptRegisterStat_GetBannedParticipateCount(sectionItem),
                                    rptRegisterStat_GetParticipateCount(sectionItem));
        }

        public static float rptRegisterStat_GetMajorBannedParticipatePercent(SectionItem sectionItem)
        {
            return ConvertToPercent(rptRegisterStat_GetMajorBannedParticipateCount(sectionItem),
                                    rptRegisterStat_GetMajorParticipateCount(sectionItem));
        }

        public static float rptRegisterStat_GetTotalBannedParticipatePercent()
        {
            return ConvertToPercent(rptRegisterStat_GetTotalBannedParticipateCount(),
                                    rptRegisterStat_GetTotalParticipateCount());
        }

        public static int rptRegisterStat_GetQuitedCount(SectionItem sectionItem)
        {
            var query = from item in mSectionItems
                        from participate in item.GetAllParticipates()
                        where item.Lesson.Id == sectionItem.Lesson.Id
                        select participate.Register.FullQuitedSign;
            return query.Sum();
        }

        public static int rptRegisterStat_GetMajorQuitedCount(SectionItem sectionItem)
        {
            var query = from item in mSectionItems
                        from participate in item.GetAllParticipates()
                        where item.Lesson.Major.Id == sectionItem.Lesson.Major.Id
                        select participate.Register.FullQuitedSign;
            return query.Sum();
        }

        public static int rptRegisterStat_GetTotalQuitedCount()
        {
            var query = from item in mSectionItems
                        from participate in item.GetAllParticipates()
                        select participate.Register.FullQuitedSign;
            return query.Sum();
        }

        public static float rptRegisterStat_GetQuitedPercent(SectionItem sectionItem)
        {
            return ConvertToPercent(rptRegisterStat_GetQuitedCount(sectionItem),
                                    rptRegisterStat_GetParticipateCount(sectionItem));
        }

        public static float rptRegisterStat_GetMajorQuitedPercent(SectionItem sectionItem)
        {
            return ConvertToPercent(rptRegisterStat_GetMajorQuitedCount(sectionItem),
                                    rptRegisterStat_GetMajorParticipateCount(sectionItem));
        }

        public static float rptRegisterStat_GetTotalQuitedPercent()
        {
            return ConvertToPercent(rptRegisterStat_GetTotalQuitedCount(),
                                    rptRegisterStat_GetTotalParticipateCount());
        }

        public static int rptRegisterStat_GetDebtorCount(SectionItem sectionItem)
        {
            var query = from item in mSectionItems
                        from participate in item.GetAllParticipates()
                        where item.Lesson.Id == sectionItem.Lesson.Id
                        select participate.Register.DebtorSign;
            return query.Sum();
        }

        public static int rptRegisterStat_GetMajorDebtorCount(SectionItem sectionItem)
        {
            var query = from item in mSectionItems
                        from participate in item.GetAllParticipates()
                        where item.Lesson.Major.Id == sectionItem.Lesson.Major.Id
                        select participate.Register.DebtorSign;
            return query.Sum();
        }

        public static int rptRegisterStat_GetTotalDebtorCount()
        {
            var query = from item in mSectionItems
                        from participate in item.GetAllParticipates()
                        select participate.Register.DebtorSign;
            return query.Sum();
        }

        public static float rptRegisterStat_GetDebtorPercent(SectionItem sectionItem)
        {
            return ConvertToPercent(rptRegisterStat_GetDebtorCount(sectionItem),
                                    rptRegisterStat_GetParticipateCount(sectionItem));
        }

        public static float rptRegisterStat_GetMajorDebtorPercent(SectionItem sectionItem)
        {
            return ConvertToPercent(rptRegisterStat_GetMajorDebtorCount(sectionItem),
                                    rptRegisterStat_GetMajorParticipateCount(sectionItem));
        }

        public static float rptRegisterStat_GetTotalDebtorPercent()
        {
            return ConvertToPercent(rptRegisterStat_GetTotalDebtorCount(),
                                    rptRegisterStat_GetTotalParticipateCount());
        }

        public static int rptRegisterStat_GetNewSignupCount(SectionItem sectionItem)
        {
            var query = from item in mSectionItems
                        from participate in item.GetAllParticipates()
                        where item.Lesson.Id == sectionItem.Lesson.Id
                        && participate.IsFirstSignup()
                        select participate;
            return query.Count();
        }

        public static int rptRegisterStat_GetMajorNewSignupCount(SectionItem sectionItem)
        {
            var query = from item in mSectionItems
                        from participate in item.GetAllParticipates()
                        where item.Lesson.Major.Id == sectionItem.Lesson.Major.Id
                        && participate.IsFirstSignup()
                        select participate;
            return query.Count();
        }

        public static int rptRegisterStat_GetTotalNewSignupCount()
        {
            var query = from item in mSectionItems
                        from participate in item.GetAllParticipates()
                        where participate.IsFirstSignup()
                        select participate;
            return query.Count();
        }

        public static float rptRegisterStat_GetNewSignupPercent(SectionItem sectionItem)
        {
            return ConvertToPercent(rptRegisterStat_GetNewSignupCount(sectionItem),
                                    rptRegisterStat_GetParticipateCount(sectionItem));
        }

        public static float rptRegisterStat_GetMajorNewSignupPercent(SectionItem sectionItem)
        {
            return ConvertToPercent(rptRegisterStat_GetMajorNewSignupCount(sectionItem),
                                    rptRegisterStat_GetMajorParticipateCount(sectionItem));
        }

        public static float rptRegisterStat_GetTotalNewSignupPercent()
        {
            return ConvertToPercent(rptRegisterStat_GetTotalNewSignupCount(),
                                    rptRegisterStat_GetTotalParticipateCount());
        }

        public static int rptRegisterStat_GetReSignupCount(SectionItem sectionItem)
        {
            var query = from item in mSectionItems
                        from participate in item.GetAllParticipates()
                        where item.Lesson.Id == sectionItem.Lesson.Id
                        && participate.IsReSignup()
                        select participate;
            return query.Count();
        }

        public static int rptRegisterStat_GetMajorReSignupCount(SectionItem sectionItem)
        {
            var query = from item in mSectionItems
                        from participate in item.GetAllParticipates()
                        where item.Lesson.Major.Id == sectionItem.Lesson.Major.Id
                        && participate.IsReSignup()
                        select participate;
            return query.Count();
        }

        public static int rptRegisterStat_GetTotalReSignupCount()
        {
            var query = from item in mSectionItems
                        from participate in item.GetAllParticipates()
                        where participate.IsReSignup()
                        select participate;
            return query.Count();
        }

        public static float rptRegisterStat_GetReSignupPercent(SectionItem sectionItem)
        {
            return ConvertToPercent(rptRegisterStat_GetReSignupCount(sectionItem),
                                    rptRegisterStat_GetParticipateCount(sectionItem));
        }

        public static float rptRegisterStat_GetMajorReSignupPercent(SectionItem sectionItem)
        {
            return ConvertToPercent(rptRegisterStat_GetMajorReSignupCount(sectionItem),
                                    rptRegisterStat_GetMajorParticipateCount(sectionItem));
        }

        public static float rptRegisterStat_GetTotalReSignupPercent()
        {
            return ConvertToPercent(rptRegisterStat_GetTotalReSignupCount(),
                                    rptRegisterStat_GetTotalParticipateCount());
        }
    }
}