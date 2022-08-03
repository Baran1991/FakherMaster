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

    public partial class rptTeachingAbstract : Report, IConfigurableReport
    {
        public rptTeachingAbstract()
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

        public string ReportName
        {
            get { return "گزارش خلاصه تدریس مدرسین"; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام", "FarsiFirstName"},
                               new List<object> {"نام خانوادگی", "FarsiLastName"}
                           };
            }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowStructure = false;
            frm.ShowParam1 = true;
            frm.Param1Text = "بازه زمانی:";
            frm.Param1DataSource = new string[] {"در ترم جاری", "در دپارتمان جاری", "در همه دپارتمان ها"};
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            IQueryable<Teacher> teachers = Teacher.GetActiveTeachers();
            DataSet = teachers;
        }

        public void Apply(IReportParameterForm frm)
        {
            List<Data> datas = new List<Data>();
            foreach (Teacher teacher in DataSet)
            {
                if(frm.Param1SelectedIndex == 0)
                {
                    IList<Section> teachingSections = teacher.GetTeachingSections(frm.Period);
                    foreach (Section section in teachingSections)
                        datas.Add(CreateData(section));
                    IList<Replacement> replacements = teacher.GetReplacements(frm.Period);
                    foreach (Replacement replacement in replacements)
                        datas.Add(CreateData(replacement));
                }
                if(frm.Param1SelectedIndex == 1)
                {
                    foreach (EducationalPeriod period in frm.Period.Department.EducationalPeriods)
                    {
                        IList<Section> teachingSections = teacher.GetTeachingSections(period);
                        foreach (Section section in teachingSections)
                            datas.Add(CreateData(section));
                        IList<Replacement> replacements = teacher.GetReplacements(period);
                        foreach (Replacement replacement in replacements)
                            datas.Add(CreateData(replacement));
                    }
                }
                if(frm.Param1SelectedIndex == 2)
                {
                    IQueryable<Major> majors = teacher.GetTeachingMajors();
                    foreach (Major major in majors)
                    {
                        IEnumerable<EducationalPeriod> periods = teacher.GetPresenceTeachingPeriods(major);
                        foreach (EducationalPeriod period in periods)
                        {
                            IList<Section> teachingSections = teacher.GetTeachingSections(period);
                            foreach (Section section in teachingSections)
                                datas.Add(CreateData(section));
                            IList<Replacement> replacements = teacher.GetReplacements(period);
                            foreach (Replacement replacement in replacements)
                                datas.Add(CreateData(replacement));
                        }
                    }
                }
            }
            DataSource = datas;
        }

        #endregion

        private Data CreateData(Replacement replacement)
        {
            Data data = new Data();
            data.Period = replacement.SectionItem.Section.Period;
            data.Teacher = replacement.SectionItem.Section.Teacher;
            data.SectionItem = replacement.SectionItem;
            data.Description = "جانشینی در تاریخ " + replacement.Date.ToShortDateString();
            return data;
        }

        private Data CreateData(Section section)
        {
            Data data = new Data();
            data.Period = section.Period;
            data.Teacher = section.Teacher;
            if (section.Items.Count > 0)
                data.SectionItem = section.Items[0];
            data.Description = "از تاریخ " + section.StartDate.ToShortDateString() + " تا " +
                               section.FinishDate.ToShortDateString();
            return data;
        }

        public class Data
        {
            public EducationalPeriod Period { get; set; }
            public Teacher Teacher { get; set; }
            public SectionItem SectionItem { get; set; }
            public string Description { get; set; }
        }
    }
}