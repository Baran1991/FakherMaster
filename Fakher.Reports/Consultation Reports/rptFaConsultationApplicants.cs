using System.Collections;
using System.Collections.Generic;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Consult;
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
    /// Summary description for rptToolSupply.
    /// </summary>
    public partial class rptFaConsultationApplicants : Report, IConfigurableReport
    {
        public rptFaConsultationApplicants()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void textBox6_ItemDataBinding(object sender, EventArgs e)
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
            get { return "لیست شرکت کنندگان مشاوره حضوری"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowCustomStructure = true;
            frm.CustomText1 = "جلسه مشاوره:";
            frm.CustomGridColumns1 = new Dictionary<string, string> {{"نام", "Name"}, {"تاریخ", "HoldingDate"}};
            frm.CustomGridDataSource1 = DbContext.GetAllEntities<ConsultationSession>();
            frm.ShowCustomGrid1 = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            ConsultationSession session = frm.CustomGridValue1 as ConsultationSession;
            DataSet = session.GetApplicants();
        }

        public void Apply(IReportParameterForm frm)
        {
            ConsultationSession session = frm.CustomGridValue1 as ConsultationSession;
            textBox6.Value = ReportName + " " + session.Name;
            DataSource = DataSet;
        }

        #endregion
    }
}