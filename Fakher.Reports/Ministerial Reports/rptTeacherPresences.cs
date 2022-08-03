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

    public partial class rptTeacherPresences : Report, IConfigurableReport
    {
        public rptTeacherPresences()
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

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش ساعات حضور"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { return new List<List<object>>(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowTeacherStructure = true;
            frm.ShowDate = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
//            DataSet = frm.Teacher.GetPresences(frm.StartDate, frm.EndDate);
        }

        public void Apply(IReportParameterForm frm)
        {
            txtReportName.Value = ReportName + " " + frm.Teacher.FarsiFullname + " از " + frm.StartDate + " تا " +
                                  frm.EndDate;
            List<Data> datas = new List<Data>();
            IList<Presence> presences = frm.Teacher.GetPresences(frm.StartDate, frm.EndDate).ToList();
            foreach (Presence presence in presences)
                datas.Add(CreateData(presence));

            IList<Replacement> replacements = frm.Teacher.GetReplacements(frm.StartDate, frm.EndDate);
            foreach (Replacement replacement in replacements)
                datas.Add(CreateData(replacement));

            DataSource = datas;
        }

        #endregion

        private Data CreateData(Replacement replacement)
        {
            Data data = new Data();
            data.Position = 1;
            data.Period = replacement.SectionItem.Section.Period;
            data.Teacher = replacement.SectionItem.Section.Teacher;
            data.SectionItem = replacement.SectionItem;
            data.Description = "جانشینی مورخ " + replacement.Date;
            data.TotalHours = replacement.ReplacementHours;
            return data;
        }

        private Data CreateData(Presence presence)
        {
            Data data = new Data();
            data.Position = 0;
            data.Period = presence.SectionItem.Section.Period;
            data.Teacher = presence.SectionItem.Section.Teacher;
            data.SectionItem = presence.SectionItem;
            data.Description = "تدریس";
            data.TotalHours = presence.Duration.TotalHours;
            return data;
        }

        public class Data
        {
            public EducationalPeriod Period { get; set; }
            public Teacher Teacher { get; set; }
            public SectionItem SectionItem { get; set; }
            public int Position { get; set; }
            public double TotalHours { get; set; } 
            public string Description { get; set; }
        }
    }
}