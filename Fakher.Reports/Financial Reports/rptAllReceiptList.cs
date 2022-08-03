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
    public partial class rptAllReceiptList : Report, IConfigurableReport
    {
        public rptAllReceiptList()
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
                               new List<object> { "شماره فیش", "ReceiptNumber"},
                               new List<object> { "تاریخ سررسید", "Item.Date"},
                               new List<object> { "متعلق به", "Item.Document.Person.FarsiFullname"},
                               new List<object> { "مبلغ", "Item.Amount"},
                               new List<object> { "بانک", "Item.BankAccount.BankName"},
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
            get { return "لیست فیش های واریز نقدی بانک"; }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowDate = true;
            frm.ShowParam1 = false;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            List<Receipt> receipts = Receipt.GetReceipts(frm.StartDate, frm.EndDate).ToList();
            IQueryable<Receipt> orderedReceipts = receipts.OrderBy(x => x.Date).AsQueryable();
            DataSet = orderedReceipts.ToList();
        }

        public void Apply(IReportParameterForm frm)
        {
            ReceiptStatus status = (ReceiptStatus)frm.Param1SelectedIndex;
            txtReportName.Value = ReportName + " های "  + " از " +
                                  frm.StartDate.ToShortDateString()
                                  + " تا " + frm.EndDate.ToShortDateString();
            DataSource = DataSet;


        }

        #endregion
    }
}