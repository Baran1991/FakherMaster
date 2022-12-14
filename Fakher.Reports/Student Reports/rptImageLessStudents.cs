using System.Collections;
using System.Collections.Generic;
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
    public partial class rptImageLessStudents : Report, IConfigurableReport
    {
        public rptImageLessStudents()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void txtReportName_ItemDataBinding(object sender, EventArgs e)
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
            get { return "گزارش دانشجویان فاقد عکــس"; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام", "Register.Student.FarsiFirstName"},
                               new List<object> {"نام خانوادگی", "Register.Student.FarsiLastName"},
                               new List<object> {"تلفن ثابت", "Register.Student.ContactInfo.Phone"},
                               new List<object> {"تلفن همراه", "Register.Student.ContactInfo.Mobile"},
                               new List<object> {"آدرس", "Register.Student.ContactInfo.Address"},
                           };
            }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowStructure = true;
            frm.ShowMajor = true;
            frm.ShowLesson = true;
            frm.ShowSection = true;
            frm.OptionalLesson = frm.OptionalSection = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            IList<Register> registers;

            if(frm.SectionItem != null)
            {
                registers = Register.GetImageLessRegisters(frm.Period, frm.SectionItem.Lesson);
            }
            else if (frm.Lesson != null)
            {
                registers = Register.GetImageLessRegisters(frm.Period, frm.Lesson);
            }
            else
            {
                registers = Register.GetImageLessRegisters(frm.Period, frm.Major);
            }
            DataSet = registers;
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion
    }
}