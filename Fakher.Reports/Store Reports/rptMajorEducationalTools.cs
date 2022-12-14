using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Buffet;
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
    /// Summary description for rptStoreSells.
    /// </summary>
    public partial class rptMajorEducationalTools : Report, IConfigurableReport
    {
        //public static long GetSumOfUses(int educationalToolId,PersianDate date)
        //{
        //    EducationalTool educationalTool=new EducationalTool();
        //    educationalTool.Id = educationalToolId;
        //    return educationalTool.SumOfSuppliesToDate(date);
        //}
//        public static int GetSumOfSuplliesToDate(int buffetProductId, int buffetProductSupplyId, PersianDate date)
//        {
//            return EducationalTool.SumOfSuppliesToDate(buffetProductId, buffetProductSupplyId, date);
//        }
//        public static int GetSumOfUsesToDate(int buffetProductId, int buffetProductSupplyId, PersianDate date)
//        {
//            return EducationalTool.SumOfUsesToDate(buffetProductId, buffetProductSupplyId, date);
//        }

        public rptMajorEducationalTools()
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
            get { return "گزارش درس افزارهای رشته"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowStructure = true;
            frm.ShowMajor = true;
            frm.ShowLesson = false;
            frm.ShowSection = false;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            txtReportName.Value = ReportName + " " + frm.Major;
            DataSet = EducationalTool.GetTools(frm.Major);
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion
    }
}