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
    public partial class rptEnClassList : Report, IConfigurableReport
    {
        private SectionItem mSectionItem;

        public rptEnClassList()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
        }

        public void Fill()
        {
            AddHeaderColumns(panel2, mSectionItem.SessionCount, true);
            AddHeaderColumns(panel4, mSectionItem.SessionCount, false);
            AddStudentColumns(panel1, mSectionItem.SessionCount);
        }

        private void AddHeaderColumns(ReportItem panel, int count, bool showNumber)
        {
            float right = panel.Right.Value - panel.Left.Value;
            float cellWidth = panel.Width.Value / count;
            for (int i = count; i >= 1; i--)
            {
                Telerik.Reporting.TextBox txt = new Telerik.Reporting.TextBox();
                if (showNumber)
                    txt.Value = i + "";

                txt.Size = new SizeU(new Unit(cellWidth, UnitType.Mm), new Unit(panel.Height.Value, UnitType.Mm));
                txt.Location = new PointU(new Unit(right - txt.Size.Width.Value, UnitType.Mm), new Unit(0, UnitType.Mm));
                txt.Style.BorderStyle.Default = BorderType.Solid;
                txt.Style.TextAlign = HorizontalAlign.Center;
                txt.Style.VerticalAlign = VerticalAlign.Middle;
                txt.Culture = new CultureInfo("en-us");
                txt.KeepTogether = false;
                panel.Items.Add(txt);
                right -= txt.Size.Width.Value;
            }
        }

        private void AddStudentColumns(ReportItem panel, int count)
        {
            float right = panel.Right.Value - panel.Left.Value;
            float cellWidth = panel.Width.Value / count;
            for (int i = count; i >= 1; i--)
            {
                Telerik.Reporting.TextBox txt = new Telerik.Reporting.TextBox();
                txt.Value = string.Format("=IsAbsentText(ReportItem.DataObject.RawData, {0})", i);

                txt.Size = new SizeU(new Unit(cellWidth, UnitType.Mm), new Unit(panel.Height.Value, UnitType.Mm));
                txt.Location = new PointU(new Unit(right - txt.Size.Width.Value, UnitType.Mm), new Unit(0, UnitType.Mm));
                txt.Style.BorderStyle.Left = BorderType.Solid;
                txt.Style.TextAlign = HorizontalAlign.Center;
                txt.Style.VerticalAlign = VerticalAlign.Middle;
                txt.Culture = new CultureInfo("en-us");
                panel.Items.Add(txt);
                right -= txt.Size.Width.Value;
            }
        }

        private void textBox6_ItemDataBinding(object sender, EventArgs e)
        {
            textBox8.Value = mSectionItem.Section.EnglishVerboseFormationText;
            textBox4.Value = mSectionItem.Section.Teacher.EnglishFullname;
            textBox11.Value = mSectionItem.Item.Lesson.Name + " - " + mSectionItem.Section.EnglishName;
            textBox17.Value = mSectionItem.Section.Period.Name;
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
            get { return "گزارش لیست حضور و غیاب کلاس"; }
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
            frm.ShowBothLanguages = true;
            frm.ShowParam1 = true;
            frm.Param1Text = "نمایش وضعیت مالی:";
            frm.Param1DataSource = new string[] { "خیر", "بله" };
            frm.IsRightToLeft = false;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            DataSet = frm.SectionItem.GetEnglishOrderedParticipates().ToList();
        }

        public void Apply(IReportParameterForm frm)
        {
            mSectionItem = frm.SectionItem;
            ReportParameters["ShowFinancialStatus"].Value = frm.Param1SelectedIndex == 1;
            Fill();
            DataSource = DataSet;
        }

        #endregion
    }
}