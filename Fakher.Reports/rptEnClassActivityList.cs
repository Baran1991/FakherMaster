using System.Collections;
using System.Globalization;
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
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for rptClassList.
    /// </summary>
    public partial class rptEnClassActivityList : Report, IConfigurableReport
    {
        public Section Section { get; set; }
        public Lesson Lesson { get; set; }
        public EvaluationGroup EvaluationGroup { get; set; }
        private Dictionary<string, int> items;

        public rptEnClassActivityList()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            items = new Dictionary<string, int>();
            items.Add("Dialogue", 7);
            items.Add("Reading", 7);
            items.Add("Speaking", 7);
            items.Add("Listening", 7);
            items.Add("Homework", 7);
            items.Add("Dictation Notebooks", 7);
        }

        public void Fill()
        {
            AddGroupColumns();
        }

        private void AddGroupColumns_old()
        {
            float left = 0;
            float cellWidth = panel2.Width.Value;
            
            Telerik.Reporting.TextBox txt = new Telerik.Reporting.TextBox();
            txt.Value = EvaluationGroup.Name;

            txt.Size = new SizeU(new Unit(cellWidth, UnitType.Mm), new Unit(panel2.Height.Value, UnitType.Mm));
            txt.Location = new PointU(new Unit(left, UnitType.Mm), new Unit(0, UnitType.Mm));
            txt.Style.BorderStyle.Default = BorderType.Solid;
            txt.Style.TextAlign = HorizontalAlign.Center;
            txt.Style.VerticalAlign = VerticalAlign.Middle;
            txt.Culture = new CultureInfo("en-us");
            panel2.Items.Add(txt);

            float itemLeft = left;
            float itemCellWidth = txt.Size.Width.Value/EvaluationGroup.Items.Count;
            foreach (EvaluationItem evaluationItem in EvaluationGroup.Items)
            {
                Telerik.Reporting.TextBox txtItem = new Telerik.Reporting.TextBox();
                txtItem.Value = evaluationItem.Name;
                txtItem.Size = new SizeU(new Unit(itemCellWidth, UnitType.Mm),
                                         new Unit(panel4.Height.Value, UnitType.Mm));
                txtItem.Location = new PointU(new Unit(itemLeft, UnitType.Mm), new Unit(0, UnitType.Mm));
                txtItem.Style.BorderStyle.Default = BorderType.Solid;
                txtItem.Style.TextAlign = HorizontalAlign.Center;
                txtItem.Style.VerticalAlign = VerticalAlign.Middle;
                txtItem.Culture = new CultureInfo("en-us");
                panel4.Items.Add(txtItem);

                float markLeft = itemLeft;
                float markWidth = txtItem.Size.Width.Value/7;
                for (int i = 0; i < 7; i++)
                {
                    Telerik.Reporting.TextBox txtMark = new Telerik.Reporting.TextBox();
                    txtMark.Value = "";
                    txtMark.Size = new SizeU(new Unit(markWidth, UnitType.Mm),
                                             new Unit(panel1.Height.Value, UnitType.Mm));
                    txtMark.Location = new PointU(new Unit(markLeft, UnitType.Mm), new Unit(0, UnitType.Mm));
                    txtMark.Style.BorderStyle.Left = BorderType.Solid;
                    txtMark.Style.BorderStyle.Right = BorderType.Solid;
                    txtMark.Style.TextAlign = HorizontalAlign.Center;
                    txtMark.Style.VerticalAlign = VerticalAlign.Middle;
                    txtMark.Culture = new CultureInfo("en-us");
                    panel1.Items.Add(txtMark);
                    markLeft += txtMark.Size.Width.Value;
                }
                itemLeft += txtItem.Size.Width.Value;
            }
        }

        private void AddGroupColumns()
        {
            float left = 0;
            float cellWidth = panel2.Width.Value;
            
            Telerik.Reporting.TextBox txt = new Telerik.Reporting.TextBox();
            txt.KeepTogether = false;
            txt.Value = "Class Activity";

            txt.Size = new SizeU(new Unit(cellWidth, UnitType.Mm), new Unit(panel2.Height.Value, UnitType.Mm));
            txt.Location = new PointU(new Unit(left, UnitType.Mm), new Unit(0, UnitType.Mm));
            txt.Style.BorderStyle.Default = BorderType.Solid;
            txt.Style.TextAlign = HorizontalAlign.Center;
            txt.Style.VerticalAlign = VerticalAlign.Middle;
            txt.Culture = new CultureInfo("en-us");
            panel2.Items.Add(txt);

            float itemLeft = left;
            float itemCellWidth = txt.Size.Width.Value/items.Count;
            foreach (KeyValuePair<string, int> item in items)
            {
                Telerik.Reporting.TextBox txtItem = new Telerik.Reporting.TextBox();
                txtItem.KeepTogether = false;
                txtItem.Value = item.Key;
                txtItem.Size = new SizeU(new Unit(itemCellWidth, UnitType.Mm),
                                         new Unit(panel4.Height.Value, UnitType.Mm));
                txtItem.Location = new PointU(new Unit(itemLeft, UnitType.Mm), new Unit(0, UnitType.Mm));
                txtItem.Style.BorderStyle.Default = BorderType.Solid;
                txtItem.Style.TextAlign = HorizontalAlign.Center;
                txtItem.Style.VerticalAlign = VerticalAlign.Middle;
                txtItem.Culture = new CultureInfo("en-us");
                panel4.Items.Add(txtItem);

                float markLeft = itemLeft;
                float markWidth = txtItem.Size.Width.Value / item.Value;
                for (int i = 0; i < item.Value; i++)
                {
                    Telerik.Reporting.TextBox txtMark = new Telerik.Reporting.TextBox();
                    txtMark.KeepTogether = false;
                    txtMark.Value = "";
                    txtMark.Size = new SizeU(new Unit(markWidth, UnitType.Mm),
                                             new Unit(panel1.Height.Value, UnitType.Mm));
                    txtMark.Location = new PointU(new Unit(markLeft, UnitType.Mm), new Unit(0, UnitType.Mm));
                    txtMark.Style.BorderStyle.Left = BorderType.Solid;
                    txtMark.Style.BorderStyle.Right = BorderType.Solid;
                    txtMark.Style.TextAlign = HorizontalAlign.Center;
                    txtMark.Style.VerticalAlign = VerticalAlign.Middle;
                    txtMark.Culture = new CultureInfo("en-us");
                    panel1.Items.Add(txtMark);
                    markLeft += txtMark.Size.Width.Value;
                }
                itemLeft += txtItem.Size.Width.Value;
            }
        }

        private void textBox6_ItemDataBinding(object sender, EventArgs e)
        {
            textBox8.Value = Section.EnglishVerboseFormationText;
            textBox4.Value = Section.Teacher.EnglishFullname;
            textBox11.Value = Lesson.Name + " - " + Section.EnglishName;
            textBox17.Value = Section.Period.Name;
        }

        public static string IsAbsentText(Participate participate, int sessionNum)
        {
            PersianDate sessionDate = participate.SectionItem.Section.GetSessionDate(sessionNum);
            bool isAbsent = participate.IsAbsent(sessionDate);
            if (isAbsent)
                return "Ab";
            return "";
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش لیست فعالیت کلاسی دانشجویان"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowStructure = frm.ShowMajor = true;
            frm.ShowLesson = frm.ShowSection = true;
            frm.ShowBothLanguages = false;
            frm.ShowParam1 = false;
            frm.IsRightToLeft = false;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            DataSet = frm.SectionItem.GetEnglishOrderedParticipates().ToList();
        }

        public void Apply(IReportParameterForm frm)
        {
            Section = frm.SectionItem.Section;
            Lesson = frm.Lesson;
            Fill();
            DataSource = DataSet;
//            Section = frm.SectionItem.Section;
//            Lesson = frm.Lesson;
//            Fill();
//            DataSource = frm.SectionItem.GetParticipates().OrderBy(x => x.Register.Student.EnglishLastName).ToList();
        }

        #endregion
    }
}