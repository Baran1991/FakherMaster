﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Buffet;
using Fakher.Core.Report;
using rComponents;

namespace Fakher.Reports.Store_Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptEducationalToolUseStat.
    /// </summary>
    public partial class rptEducationalToolUseStat : Report, IConfigurableReport
    {
        public rptEducationalToolUseStat()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public EducationalTool EducationalTool { get; set; }

        public static string TodayDate()
        {
            return PersianDate.Today.ToShortDateString();
        }

        private void txtReportName_ItemDataBinding(object sender, EventArgs e)
        {
            if (ParamForm != null)
            {
                if (ParamForm.StartDate == ParamForm.EndDate)
                    txtReportName.Value = ReportName + " " + EducationalTool.Name + " (" +
                                          ParamForm.StartDate.ToShortDateString() + ")";
                else
                    txtReportName.Value = ReportName + " " + EducationalTool.Name + " (" +
                                          ParamForm.StartDate.ToShortDateString() + " تا " +
                                          ParamForm.EndDate.ToShortDateString() + ")";
            }
            else
            {
                txtReportName.Value = ReportName + " " + EducationalTool.Name + " (" +
                                          PersianDate.Today.ToShortDateString() + ")";
            }
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش فروش یک درس افزار"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowDate = true;
            frm.ShowCustomStructure = true;

            frm.CustomText1 = "کتاب :";
            frm.CustomGridColumns1 = new Dictionary<string, string>() {{"نام کتاب", "Name"}};
            frm.ShowCustomGrid1 = true;

            frm.CustomGridDataSource1 = EducationalTool.GetAllTools();
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            EducationalTool = frm.CustomGridValue1 as EducationalTool;
            DataSet = EducationalTool.GetEducationalToolUses(frm.StartDate, frm.EndDate).Where(x => x.Type == UseType.Buy);
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion
    }
}