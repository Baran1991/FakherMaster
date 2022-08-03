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
    public partial class rptFuturePaymentsList : Report, IConfigurableReport
    {
        public rptFuturePaymentsList()
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
            get { return "گزارش پرداخت های آتیه موسسه"; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام", "Student.FarsiFirstName"},
                               new List<object> {"نام خانوادگی", "Student.FarsiLastName"},
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
            frm.ShowDate = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            IQueryable<FinancialItem> items = FinancialItem.GetIssuedFinancialItem(frm.StartDate, frm.EndDate);
            DataSet = items;
        }

        public void Apply(IReportParameterForm frm)
        {
            txtReportName.Value = ReportName + " از " + frm.StartDate + " تا " + frm.EndDate;
            DataSource = DataSet;
        }

        #endregion
    }
}