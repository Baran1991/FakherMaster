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
    /// Summary description for rptChequeList.
    /// </summary>
    public partial class rptChequeList : Report, IConfigurableReport
    {
        public rptChequeList()
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

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> { "شماره چک", "ChequeNumber"},
                               new List<object> { "تاریخ سررسید", "Item.Date"},
                               new List<object> { "متعلق به", "Item.Document.Person.FarsiFullname"},
                               new List<object> { "مبلغ", "Item.Amount"},
                               new List<object> { "بانک", "BankName"},
                               new List<object> { "تلفن ثابت", "Item.Document.Person.ContactInfo.Phone"},
                               new List<object> { "تلفن همراه", "Item.Document.Person.ContactInfo.Mobile"},
                               new List<object> { "وضعیت", "StatusText" },
                               new List<object> { "بانک ارسالی", "SendingtoBankName" },
                               new List<object> { "همکار دریافت کننده", "employee" }
                           };
            }
        }

        public string ReportName
        {
            get { return "لیست چک "; }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowDate = true;
            frm.ShowParam1 = true;
            frm.Param1Text = "وضعیت چک:";
            frm.Param1DataSource = typeof(ChequeStatus).GetEnumDescriptions();

            //frm.ShowParam2 = true;
            //frm.Param2Text = "همکار دریافت کننده:";
            //frm.Param2DataSource = typeof(Employee).GetEnumDescriptions();

            //frm.ShowParam1 = true;
            //frm.Param1Text = "بانک:";
            //frm.Param1DataSource = typeof(BankAccount).GetEnumDescriptions();

            frm.OptionalSection = true;
            frm.ShowStructure = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            ChequeStatus status = (ChequeStatus)frm.Param1SelectedIndex;
            List<Cheque> cheques = Cheque.GetCheques(frm.StartDate, frm.EndDate).ToList();
            IQueryable<Cheque> orderedCheques = cheques.OrderBy(x => x.Date).AsQueryable();
            DataSet = Cheque.GetCheques(orderedCheques, status);
        }

        public void Apply(IReportParameterForm frm)
        {
            ChequeStatus status = (ChequeStatus)frm.Param1SelectedIndex;
            txtReportName.Value = ReportName + " های " + status.ToDescription() + " از " +
                                  frm.StartDate.ToShortDateString()
                                  + " تا " + frm.EndDate.ToShortDateString();
            DataSource = DataSet;
        }

        #endregion
    }
}
