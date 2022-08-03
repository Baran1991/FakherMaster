using System.Collections;
using System.Collections.Generic;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;
using System.Linq;

namespace Fakher.Reports
{
    using rApplicationEventFramework;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptSignupReciept.
    /// </summary>
    public partial class rptSignupReceiptTotal : Report, IConfigurableReport
    {
        public rptSignupReceiptTotal()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public static List<Participate> GetParticipates(Register register) 
        {
            return register.GetParticipates(ParticipateStatus.Participating);
        }    
    
        public static List<Enrollment> GetExamEnrollments(Register register)
        {
            return register.GetGeneralExamEnrollments().ToList();
        }

        public static List<FinancialItem> GetFinancialItems(Register register)
        {
            List<FinancialItem> result = new List<FinancialItem>();
            foreach (FinancialItem item in register.FinancialDocument.Items)
            {
                if(item.Payment != null || item is Discount)
                    result.Add(item);
            }
            return result;
        }

        public static long GetSectionTuitionFee(Participate participate)
        {
            return participate.SectionItem.Section.GetTuitionFee(participate.Register.Major);
        }

        public static string GetReceiptNote(Register register)
        {
            return register.Period.SignupReceiptNote;
        }

        public static string rptSignupReceipt_GetRegistrarName(Register register)
        {
            var registrars = register.GetRegistrars(EntityEventAction.InsertObject);
            var registrar = "";
            foreach(var item in registrars)
            {
                registrar += item.FarsiFormalName + ", ";
            }
            return registrar;
        }

        public static string GetUsername(Register register)
        {
            if (register.Student.UserInfo.LoginStatus == LoginStatus.Disabled || !register.Student.UserInfo.WebLogin)
                return "غیرفعال";
            return register.Student.UserInfo.GetRawUsername();
        }

        public static string GetPassword(Register register)
        {
            if (register.Student.UserInfo.LoginStatus == LoginStatus.Disabled || !register.Student.UserInfo.WebLogin)
                return "غیرفعال";
            return register.Student.UserInfo.GetRawPassword();
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return true; }
        }

        public string ReportName
        {
            get { return "گزارش رسید ثبت نام"; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام", "Student.FarsiFirstName"},
                               new List<object> {"نام خانوادگی", "Student.FarsiLastName"},
                               new List<object> { "شماره دانشجویی", "Code"},
                               new List<object> { "رشته", "Major.Name"},
                               new List<object> { "دوره", "Period.Name"},
                               new List<object> { "کاربر ثبت نام کننده", "Registrar"},
                               new List<object> { "تاریخ ثبت نام", "RegisterDate"},
                               new List<object> {"نوع ثبت نام", "EnrollmentTypeText"},
                               new List<object> {"وضعیت مالی", "FarsiFinancialStatusVerboseText"}
                           };
            }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            //frm.ShowStructure = frm.ShowMajor = true;
            //frm.ShowLesson = frm.ShowSection = true;
            frm.IsRightToLeft = true;
            //frm.OptionalSection = frm.OptionalLesson = true;
            frm.ShowDate = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            IList<Register> registers;
            IList<Participate> participates = Participate.GetParticipates(frm.StartDate, frm.EndDate);
            registers = participates.Select(x => x.Register).ToList();
            DataSet = registers;
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion

        private void textBox22_ItemDataBinding(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.ReportItemBase reportItem = sender as Telerik.Reporting.Processing.ReportItemBase;
            Register register = reportItem.DataObject.RawData as Register;

            //Register register = (DataSource as object[])[0] as Register;

            IQueryable<Enrollment> generalExamEnrollments = register.GetGeneralExamEnrollments();
            int count = generalExamEnrollments.Count();
            if (count > 0)
            {
                textBox22.Value = "+ " + register.GeneralExamsText;
            }
            else
            {
                textBox22.Value = "";
            }
        }

        private void textBox45_ItemDataBinding(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.ReportItemBase reportItem = sender as Telerik.Reporting.Processing.ReportItemBase;
            Participate participate = reportItem.DataObject.RawData as Participate;
            Register register = participate.Register;
            //Register register = (DataSource as object[])[0] as Register;

            if (!register.Period.Department.ShowSignupReceiptEducationalEvents)
            {
                textBox45.Value = "";
                textBox45.Height = new Unit("1px");

                //table2.Body.SetCellContent(0, 0, this.subReport1, 2, 3);
                //table2.Body.SetCellContent(1, 0, this.textBox45, 2, 3);
            }
        }

        private void textBox49_ItemDataBinding(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.ReportItemBase reportItem = sender as Telerik.Reporting.Processing.ReportItemBase;
            Register register = reportItem.DataObject.RawData as Register;

            textBox49.Value = register.FinancialCommitmentText;
        }
    }
}