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
    using System.Security.Cryptography;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptDiscountedRegisters.
    /// </summary>
    public partial class rptAlalHesab : Report, IConfigurableReport
    {
        public Staff staff { get; set; }
        public PersianDate Date { get; set; }
        public List<FinancialItem> fItems { get; set; } = new List<FinancialItem>();
        public bool forTeacher { get; set; }
        public bool forEmployee { get; set; }

        public rptAlalHesab()
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
            frm.ShowCustomStructure = true;
            frm.CustomText1 = "شخص:";
            frm.CustomGridColumns1 = new Dictionary<string, string> { { "نام", "FarsiFullname" } };
            frm.CustomGrid1SelectedIndexChanged += OnCustomGrid1SelectedIndexChanged;
            frm.ShowCustomGrid1 = true;
            frm.ShowDate = true;
            
            if (!forEmployee)
                frm.CustomGridDataSource1 = Teacher.GetActiveTeachers();
            else
                frm.CustomGridDataSource1 = Employee.GetActiveEmployees();

        }
        private void OnCustomGrid1SelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            Staff staff = ParamForm.CustomGridValue1 as Staff;
            if (staff == null)
                return;
            fItems = staff.GetAlalHesabFinancialItems().ToList();
        }
        public void PrepareDataset(IReportParameterForm frm)
        {
            DataSet = fItems.Where(m=>m.Date<=frm.EndDate&&m.Date>=frm.StartDate);
        }

        public void Apply(IReportParameterForm frm)
        {
            if (!forEmployee)
                txtReportName.Value = "  پرداخت های علی الحساب مدرس از تاریخ" + frm.StartDate.ToShortDateString()
                                  + " تا " + frm.EndDate.ToShortDateString();
            else
                txtReportName.Value = "  پرداخت های علی الحساب پرسنل از تاریخ" + frm.StartDate.ToShortDateString()
                                  + " تا " + frm.EndDate.ToShortDateString();
            DataSource = DataSet;
        }

        #endregion
    }
}