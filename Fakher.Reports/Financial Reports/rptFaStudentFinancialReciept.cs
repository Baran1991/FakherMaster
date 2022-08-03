using System.Collections;
using System.Collections.Generic;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;
using rComponents;
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
    /// Summary description for rptDiscountedRegisters.
    /// </summary>
    public partial class rptFaStudentFinancialReciept : Report, IConfigurableReport
    {
        public Student student { get; set; }
        public Register register { get; set; }

        public PersianDate Date { get; set; }
        public List<FinancialItem> fItems { get; set; } = new List<FinancialItem>();
        public rptFaStudentFinancialReciept()
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

        public static string GetMajor(FinancialItem item)
        {
            try
            {
                Person person = item.Document.Person.UnProxy() as Person;
                Student student = person as Student;
                Register register = student.GetRegister(item);
                return register.Major.Name;
                
            }
            catch (Exception ex)
            {
                return "نامشخص";
            }
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
            get;
            set;
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>();
            }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowStructure = false;
            frm.ShowMajor = false;
            frm.ShowDate = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            //var lst = new List<FinancialItem>();
            //lst.Add(new FinancialItem() { Text = "حساب روزانه شما به  مبلغ" + Amount.ToString() + "در تاریخ " + Date + " تسویه شد.", Amount = Amount, Date = Date });
            DataSet = fItems;
        }
        //public static string rptSignupReceipt_GetRegistrarName(Register register)
        //{
        //    Person registrar = register.GetRegistrar();
        //    if (registrar != null)
        //        return registrar.FarsiFormalName;
        //    return register.Registrar;
        //}

        public void Apply(IReportParameterForm frm)
        {
            txtReportName.Value = ReportName + " " + student.FarsiFullname + "  به شماره دانشجویی:  " + register.Code + "   رشته:   " + register.Major + "   دوره:   " + register.Period + " ";
            DataSource = DataSet;
        }

        #endregion
    }
}