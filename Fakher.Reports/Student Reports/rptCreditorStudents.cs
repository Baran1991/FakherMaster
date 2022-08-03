using System.Collections;
using System.Collections.Generic;
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
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptDebtorStudents.
    /// </summary>
    public partial class rptCreditorStudents : Report, IConfigurableReport
    {
        public rptCreditorStudents()
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

        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش دانشجویان بستانکار"; }
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
            frm.ShowLesson = true;
            frm.ShowSection = true;
            frm.OptionalSection = true;
            frm.OptionalLesson = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            IList<Register> registers = Register.GetRegisters(frm.Period, frm.Major);
            IEnumerable<Register> query = registers.Where(x => x.Type == RegisterType.Participation);

            if (frm.Lesson != null)
            {
                query = from register in registers
                        from participate in register.Participates
                        where participate.SectionItem.Lesson.Id == frm.Lesson.Id
                        select register;
            }
            else if (frm.SectionItem != null)
            {
                query = from register in registers
                        from participate in register.Participates
                        where participate.SectionItem.Id == frm.SectionItem.Id
                        select register;
            }

            IQueryable<Register> creditorRegisters = Register.GetCreditorRegisters(query.ToList());
            DataSet = creditorRegisters.ToList();
        }

        public void Apply(IReportParameterForm frm)
        {
            if(frm.Major != null)
            {
                txtReportName.Value = ReportName + " رشته " + frm.Major.Name;
            }
            if (frm.Lesson != null)
            {
                txtReportName.Value = ReportName + " درس/سطح " + frm.Lesson.Name;
            }
            else if (frm.SectionItem != null)
            {
                txtReportName.Value = ReportName + " گروه " + frm.SectionItem.Section;
            }

            DataSource = DataSet;
        }

        #endregion
    }
}