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
    /// Summary description for rptExamRequestList.
    /// </summary>
    public partial class rptCertificateList : Report, IConfigurableReport
    {
        public rptCertificateList()
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

        private void textBox6_ItemDataBinding(object sender, EventArgs e)
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
            get { return "گزارش مدارک"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowDate = true;
            frm.ShowStructure = true;
            frm.ShowMajor = true;

            frm.ShowParam1 = true;
            frm.Param1Text = "وضعیت مدرک:";
            frm.Param1DataSource = typeof(CertificateStatus).GetEnumDescriptions();
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            CertificateStatus status = (CertificateStatus) frm.Param1SelectedIndex;
//            IList<Certificate> certificates = Certificate.GetCertificates(frm.StartDate, frm.EndDate);
            IEnumerable<Certificate> query = DbContext.Entity<Certificate>().Where(x => x.Status == status && x.Major.Id == frm.Major.Id);
            if (status == CertificateStatus.Requested)
                query = query.Where(x => x.RequestDate >= frm.StartDate && x.RequestDate <= frm.EndDate);
            if (status == CertificateStatus.Issued)
                query = query.Where(x => x.IssueDate >= frm.StartDate && x.IssueDate <= frm.EndDate);
            if (status == CertificateStatus.Delivered)
                query = query.Where(x => x.DeliverDate >= frm.StartDate && x.DeliverDate <= frm.EndDate);

            DataSet = query;
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
            textBox6.Value = ReportName; // +" " + frm.Param1Text;
        }

        #endregion
    }
}