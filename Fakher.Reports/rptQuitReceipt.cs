using System.Collections;
using System.Collections.Generic;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;
using System.Linq;

namespace Fakher.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptSignupReciept.
    /// </summary>
    public partial class rptQuitReceipt : Report, IConfigurableReport
    {
        public rptQuitReceipt()
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
            return register.Period.QuitReceiptNote;
        }

        public static string GetChequeText(Register register)
        {
            if (!register.Quit.ReturnByCheque)
                return "";
            Cheque cheque = register.Quit.FinancialItem.Payment as Cheque;
//            return cheque.Description;
            return "طی چک " + cheque.ChequeNumber + " مورخ " + cheque.Date + " به مبلغ " + cheque.Amount +
                   " عهده بانک " + cheque.BankName + " شعبه " + cheque.BankBranch;
        }

        public static string rptSignupReceipt_GetRegistrarName(Register register)
        {
            Person registrar = register.GetRegistrar();
            if (registrar != null)
                return registrar.FarsiFormalName;
            return register.Registrar;
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
                               new List<object> {"نوع ثبت نام", "EnrollmentTypeText"},
                               new List<object> {"وضعیت مالی", "FarsiFinancialStatusVerboseText"}
                           };
            }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowStructure = frm.ShowMajor = true;
            frm.ShowLesson = frm.ShowSection = true;
            frm.IsRightToLeft = true;
            frm.OptionalSection = frm.OptionalLesson = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            IList<Register> registers;

            if(frm.SectionItem != null)
            {
                IList<Participate> participates = Participate.GetParticipates(frm.Period, frm.SectionItem.Lesson);
                registers = participates.Where(x => x.SectionItem.Id == frm.SectionItem.Id).Select(x => x.Register).ToList();
            }
            else if(frm.Lesson != null)
            {
                IList<Participate> participates = Participate.GetParticipates(frm.Period, frm.Lesson);
                registers = participates.Select(x => x.Register).ToList();
            }
            else
            {
                registers = Register.GetRegisters(frm.Period, frm.Major);
            }

            DataSet = registers;
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }
        public static string rptquitReceipt_GetRegistrarName(Register register)
        {
            Person registrar = register.GetRegistrar();
            if (registrar != null)
                return registrar.FarsiFormalName;
            return register.Registrar;
        }

        #endregion
    }
}