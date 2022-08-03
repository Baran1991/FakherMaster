using System.Collections;
using System.Collections.Generic;
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
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptStudentContacts.
    /// </summary>
    public partial class rptRegisterContacts : Report, IConfigurableReport
    {
        public rptRegisterContacts()
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
            get { return true; }
        }

        public string ReportName
        {
            get { return "گزارش اطلاعات تماس دانشجویان"; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام", "Student.FarsiFirstName"},
                               new List<object> {"نام خانوادگی", "Student.FarsiLastName"},
                                new List<object> {"نام پدر", "Student.FarsiFatherName"},
                                 new List<object> {"کد ملی", "Student.NationalCode"},
                               new List<object> {"نوع ثبت نام", "RegisterParticipationText"},
                               new List<object> {"تلفن ثابت", "Student.ContactInfo.Phone"},
                               new List<object> {"تلفن همراه", "Student.ContactInfo.Mobile"},
                               new List<object> {"آدرس", "Student.ContactInfo.Address"},
                           };
            }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowStructure = true;
            frm.ShowMajor = true;
            frm.ShowLesson = frm.ShowSection = true;
            frm.OptionalSection = true;
            frm.OptionalLesson = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
//            IEnumerable<Participate> participates;
            IEnumerable<Register> registers;

            if (frm.SectionItem != null)
            {
                registers = from participate in frm.SectionItem.GetParticipates()
                               select participate.Register;
            }
            else if (frm.Lesson != null)
                registers = from participate in Participate.GetParticipates(frm.Period, frm.Lesson)
                               group participate by participate.Register into g
                               select g.Key;
            else
            {
                registers = Register.GetRegisters(frm.Period, frm.Major);
//                participates = from register in registers
//                               from participate in register.Participates
//                               group participate by participate.Register.Id
//                               into g
//                               select g.First();

//                participates = from participate in Participate.GetParticipates(frm.Period, frm.Major)
//                               group participate by participate.Register.Id
//                               into g
//                               select g.First();
            }

            DataSet = registers;
        }

        public void Apply(IReportParameterForm frm)
        {
            if (frm.SectionItem != null)
                txtReportName.Value = ReportName + " " + frm.SectionItem.Section.FarsiName + " " +
                                  frm.SectionItem.Section.MasterItemText;
            else if (frm.Lesson != null)
                txtReportName.Value = ReportName + " درس/سطح " + frm.Lesson.Name;
            else
                txtReportName.Value = ReportName + " رشته " + frm.Major.Name;

            DataSource = DataSet;
        }

        #endregion
    }
}