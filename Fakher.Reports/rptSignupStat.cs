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
    public partial class rptSignupStat : Report, IConfigurableReport
    {
        public string Title { get; set; }
        private IReportParameterForm mFrm;

        public rptSignupStat()
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

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش آماری-مالی ثبت نام دانشجویان"; }
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
            frm.ShowSection = true;
            frm.OptionalMajor = true;
            frm.OptionalLesson = true;
            frm.OptionalSection = true;
            frm.ShowParam1 = true;
            frm.Param1Text = "نحوه اعمال تاریخ:";
            frm.Param1DataSource = new string[] {"در دپارتمان جاری", "در ترم جاری", "کــل ترم جاری" };
            frm.Param1SelectedChanged += new EventHandler(frm_Param1SelectedChanged);
        }

        private void frm_Param1SelectedChanged(object sender, EventArgs e)
        {
            if (mFrm.Param1SelectedIndex == 0)
                mFrm.ShowDate = true;
            if (mFrm.Param1SelectedIndex == 1)
                mFrm.ShowDate = true;
            if (mFrm.Param1SelectedIndex == 2)
                mFrm.ShowDate = false;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            IList<Register> registers = null;
            if(frm.Param1SelectedIndex == 0)
                registers = Register.GetRegisters(frm.StartDate, frm.EndDate);
            if(frm.Param1SelectedIndex == 1)
            {
                registers = Register.GetRegisters(frm.StartDate, frm.EndDate);
                registers = registers.Where(x => x.Period.Id == frm.Period.Id).ToList();
            }
            if(frm.Param1SelectedIndex == 2)
                registers = Register.GetRegisters(frm.Period);

            IEnumerable<Register> query = null;
            if (frm.SectionItem != null)
            {
                query = from register in registers
                        from participate in register.Participates
                        where participate.SectionItem.Id == frm.SectionItem.Id
                        select register;
            }
            else if (frm.Lesson != null)
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

//            IList<Register> quited = (from register in query
//                                      from participate in register.Participates
//                                     where participate.GetBans(BanStatus.Active).Count() > 0
//                                        select register).ToList();
//            IList<Register> par = (from register in query
//                                     where register.Type == RegisterType.Participation
//                                     select register).ToList();
//
//            List<IGrouping<string, Register>> list1 = (from register in query
//                          group register by register.Student.FarsiFullname into g
//                          where g.Count() > 1
//                          select g).ToList();
//
//            IList<Register> par2 = (from register in registers
//                                     where register.Type == RegisterType.Participation
//                                     && register.Participates.Count == 1
//                                     select register).ToList();
//            IList<Register> par3 = (from register in registers
//                                     where register.Type == RegisterType.Participation
//                                                                          && register.Participates.Count > 0
//
//                                     select register).ToList();
//            IList<Register> vacationed = (from register in query
//                                     where register.Type == RegisterType.TermVacation
//                                     select register).ToList();
//            IList<Register> vacationed2 = (from register in query
//                                     where register.Type == RegisterType.PartialVacation
//                                     select register).ToList();
//            var query3 = from register in query
//                         group register by register.Participates[0].SectionItem.Lesson
//                         into g
//                         select g;
//            List<IGrouping<Lesson, Register>> list = query3.ToList();
        }

        public void Apply(IReportParameterForm frm)
        {
            string title = ReportName;

            if (frm.SectionItem != null)
                title += " کلاس/گروه " + frm.SectionItem.Section;
            else if (frm.Lesson != null)
                title += " درس/سطح " + frm.Lesson.Name;
            else if (frm.Major != null)
                title += " رشته " + frm.Major.Name;
            else
                title += " دپارتمان " + frm.Period.Department.Name;

            if (frm.Param1SelectedIndex == 0)
                title += " از " + frm.StartDate + " تا " + frm.EndDate;
            if (frm.Param1SelectedIndex == 1)
                title += " از " + frm.StartDate + " تا " + frm.EndDate + " در ترم " + frm.Period.Name;
            if (frm.Param1SelectedIndex == 2)
                title += " در کل ترم " + frm.Period.Name;

            Title = title;
            DataSource = DataSet;
        }

        #endregion
    }
}