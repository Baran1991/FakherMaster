using System.Collections;
using System.Linq;
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
    public partial class rptFinancialHeadingStat : Report, IConfigurableReport
    {
        public string Title { get; set; }
        private IReportParameterForm mFrm;

        public rptFinancialHeadingStat()
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

        public static long FilterNaghd(object d)
        {
            Data data = d as Data;
            if (data == null)
                return 0;
            if (data.FinancialItem.Payment is Cash || data.FinancialItem.Payment is Receipt || data.FinancialItem.Payment is ElectronicPayment)
                return data.FinancialItem.Amount;
            if (data.FinancialItem.Payment is Cheque && (data.FinancialItem.Payment as Cheque).Status == ChequeStatus.Passed)
                return data.FinancialItem.Amount;
            return 0;
        }

        public static long FilterInProgressCheque(Data data)
        {
            if (data == null)
                return 0;
            if (data.FinancialItem.Payment is Cheque && (data.FinancialItem.Payment as Cheque).Status == ChequeStatus.InProgress)
                return data.FinancialItem.Amount;
            return 0;
        }

        public static long FilterReturnedCheque(Data data)
        {
            if (data == null)
                return 0;
            if (data.FinancialItem.Payment is Cheque && (data.FinancialItem.Payment as Cheque).Status == ChequeStatus.Returned)
                return data.FinancialItem.Amount;
            return 0;
        }

        public static long FilterSuspendedCheque(Data data)
        {
            if (data == null)
                return 0;
            if (data.FinancialItem.Payment is Cheque && (data.FinancialItem.Payment as Cheque).Status == ChequeStatus.Suspended)
                return data.FinancialItem.Amount;
            return 0;
        }

        private void textBox6_ItemDataBinding(object sender, EventArgs e)
        {
            textBox6.Value = Title;
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش سرفصل های مالی"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            mFrm = frm;
            frm.ShowDate = true;
            frm.ShowStructure = true;
            frm.ShowMajor = true;
            frm.ShowLesson = true;
//            frm.ShowSection = true;
            frm.OptionalMajor = true;
            frm.OptionalLesson = true;
//            frm.OptionalSection = true;
//            frm.ShowParam1 = true;
//            frm.Param1Text = "سرفصل:";
//            frm.Param1DataSource = typeof (FinancialHeading).GetEnumDescriptions();
//            frm.Param1SelectedChanged += new EventHandler(frm_Param1SelectedChanged);
        }

//        private void frm_Param1SelectedChanged(object sender, EventArgs e)
//        {
//            if (mFrm.Param1SelectedIndex == 0)
//                mFrm.ShowDate = true;
//            if (mFrm.Param1SelectedIndex == 1)
//                mFrm.ShowDate = true;
//            if (mFrm.Param1SelectedIndex == 2)
//                mFrm.ShowDate = false;
//        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            IList<Register> registers = null;
//            if(frm.Param1SelectedIndex == 0)
                registers = Register.GetRegisters(frm.StartDate, frm.EndDate);
//            if(frm.Param1SelectedIndex == 1)
//            {
//                registers = Register.GetRegisters(frm.StartDate, frm.EndDate);
//                registers = registers.Where(x => x.Period.Id == frm.Period.Id).ToList();
//            }
//            if(frm.Param1SelectedIndex == 2)
//                registers = Register.GetRegisters(frm.Period);

            IEnumerable<Register> query = null;
            if (frm.ShowSection && frm.SectionItem != null)
            {
                query = from register in registers
                        from participate in register.Participates
                        where participate.SectionItem.Id == frm.SectionItem.Id
                        select register;
            }
            else if (frm.ShowLesson && frm.Lesson != null)
            {
                query = from register in registers
                        from participate in register.Participates
                        where participate.SectionItem.Lesson.Id == frm.Lesson.Id
                        select register;
            }
            else if (frm.Major != null)
            {
                query = from register in registers
                        where register.Major.Id == frm.Major.Id
                        && register.Participates.Count > 0
                        select register;
            }
            else
            {
                query = from register in registers
                        where register.Major.Department.Id == frm.Period.Department.Id
                        && register.Participates.Count > 0
                        select register;
            }

            DataSet = query.ToList();
        }

        public void Apply(IReportParameterForm frm)
        {
            string title = ReportName;

            if (frm.ShowSection && frm.SectionItem != null)
                title += " کلاس/گروه " + frm.SectionItem.Section;
            if (frm.ShowLesson && frm.Lesson != null)
                title += " درس/سطح " + frm.Lesson.Name;
            if (frm.Major != null)
                title += " رشته " + frm.Major.Name;

            title += " از " + frm.StartDate + " تا " + frm.EndDate;

            Title = title;

            List<Data> datas = new List<Data>();
            foreach (Register register in DataSet)
            {
                FinancialDocument document = register.Student.GetGeneralDocument();
                foreach (FinancialItem item in document.Items)
                {
                    Data data = new Data();
                    data.FinancialItem = item;
                    data.Major = register.Major;
                    datas.Add(data);
                }
            }

            DataSource = datas;
        }

        #endregion

        public class Data
        {
            public FinancialItem FinancialItem { get; set; }
            public Major Major { get; set; }
        }
    }
}