using System.Collections;
using System.Collections.Generic;
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
    using System.Linq;
    /// <summary>
    /// Summary description for rptStudentResults.
    /// </summary>
    public partial class rptSectionResults : Report, IConfigurableReport
    {
        private static IList<SectionItem> mSectionItems;

        public rptSectionResults()
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
            get { return "گزارش تحلیل نتیجه گروه ها"; }
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
            frm.ShowLesson = true;
            frm.ShowSection = true;
            frm.OptionalSection = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            if(frm.SectionItem != null)
            {
                mSectionItems = new List<SectionItem> { frm.SectionItem };
            }
            else
            {
                mSectionItems = SectionItem.GetSectionItems(frm.Period, frm.Major, frm.Lesson);
            }

            DataSet = mSectionItems;
        }

        public void Apply(IReportParameterForm frm)
        {
            ResultProtocol resultProtocol = frm.Lesson.GetResultProtocol(frm.Period);
            Fill(resultProtocol);

            txtReportName.Value = ReportName + "ی درس/سطح " + frm.Lesson.Name;
            DataSource = DataSet;
        }

        #endregion

        public static float GetCount(SectionItem item, int labelId)
        {
            ResultLabel label = DbContext.FromId<ResultLabel>(labelId);
            int count = item.GetParticipates(label).Count();
            return count;
        }

        public static float GetPercent(SectionItem item, int labelId)
        {
            ResultLabel label = DbContext.FromId<ResultLabel>(labelId);
            int count = item.GetParticipates(label).Count();
            int participateCount = item.ParticipateCount;
            if (participateCount != 0)
                return (count * 100) / participateCount;
            return 0;
        }

        public static float GetTotalCount(int labelId)
        {
            ResultLabel label = DbContext.FromId<ResultLabel>(labelId);
            var query = from sectionItem in mSectionItems
                        from participate in sectionItem.GetParticipates(label)
                        select participate;
            return query.Count();
        }

        public static float GetTotalPercent(int labelId)
        {
            ResultLabel label = DbContext.FromId<ResultLabel>(labelId);
            var query1 = from sectionItem in mSectionItems
                         from participate in sectionItem.GetParticipates()
                         select participate;
            var query2 = from sectionItem in mSectionItems
                         from participate in sectionItem.GetParticipates(label)
                         select participate;
            int participateCount = query1.Count();
            if(participateCount != 0)
                return (query2.Count() * 100) / participateCount;
            return 0;
        }

        private void Fill(ResultProtocol protocol)
        {
            float width = panel1.Width.Value/protocol.Labels.Count;
            float left = panel1.Right.Value - width;

            panel1.Items.Clear();
            panel2.Items.Clear();
            foreach (ResultLabel resultLabel in protocol.Labels)
            {
                #region Header 1

                Telerik.Reporting.TextBox txtHeader = new Telerik.Reporting.TextBox();
                txtHeader.Value = resultLabel.Name;
                txtHeader.Height = new Unit(panel1.Height.Value, panel1.Height.Type);
                txtHeader.Width = new Unit(width, panel1.Width.Type);
                txtHeader.Top = new Unit(0);
                txtHeader.Left = new Unit(left, panel1.Right.Type);
                txtHeader.Style.BorderStyle.Default = BorderType.Solid;
                txtHeader.Style.TextAlign = HorizontalAlign.Center;
                txtHeader.Style.VerticalAlign = VerticalAlign.Middle;
                txtHeader.Style.BackgroundColor = Color.DarkKhaki;
                txtHeader.Style.Font.Name = "B Nazanin";
                txtHeader.Style.Font.Bold = true;
                panel1.Items.Add(txtHeader);

                #endregion 

                #region Header 2

                Telerik.Reporting.TextBox txtHeaderCount = new Telerik.Reporting.TextBox();
                txtHeaderCount.Value = "تعداد";
                txtHeaderCount.Height = new Unit(panel3.Height.Value, panel3.Height.Type);
                txtHeaderCount.Width = new Unit(width / 2, panel3.Width.Type);
                txtHeaderCount.Top = new Unit(0);
                txtHeaderCount.Left = new Unit(left + (width / 2), panel3.Right.Type);
                txtHeaderCount.Style.BorderStyle.Default = BorderType.Solid;
                txtHeaderCount.Style.TextAlign = HorizontalAlign.Center;
                txtHeaderCount.Style.VerticalAlign = VerticalAlign.Middle;
                txtHeaderCount.Style.BackgroundColor = Color.DarkKhaki;
                txtHeaderCount.Style.Font.Name = "B Nazanin";
                panel3.Items.Add(txtHeaderCount);

                Telerik.Reporting.TextBox txtHeaderPercent = new Telerik.Reporting.TextBox();
                txtHeaderPercent.Value = "درصد";
                txtHeaderPercent.Height = new Unit(panel3.Height.Value, panel3.Height.Type);
                txtHeaderPercent.Width = new Unit(width / 2, panel3.Width.Type);
                txtHeaderPercent.Top = new Unit(0);
                txtHeaderPercent.Left = new Unit(left, panel3.Right.Type);
                txtHeaderPercent.Style.BorderStyle.Default = BorderType.Solid;
                txtHeaderPercent.Style.TextAlign = HorizontalAlign.Center;
                txtHeaderPercent.Style.VerticalAlign = VerticalAlign.Middle;
                txtHeaderPercent.Style.BackgroundColor = Color.DarkKhaki;
                txtHeaderPercent.Style.Font.Name = "B Nazanin";
                panel3.Items.Add(txtHeaderPercent);

                #endregion

                #region Detail

                Telerik.Reporting.TextBox txtCountValue = new Telerik.Reporting.TextBox();
                txtCountValue.Value = string.Format("=GetCount(ReportItem.DataObject.RawData, {0})", resultLabel.Id);
                txtCountValue.Height = new Unit(panel2.Height.Value, panel2.Height.Type);
                txtCountValue.Width = new Unit(width / 2, panel2.Width.Type);
                txtCountValue.Top = new Unit(0);
                txtCountValue.Left = new Unit(left + (width / 2), panel2.Right.Type);
                txtCountValue.Style.BorderStyle.Default = BorderType.Solid;
                txtCountValue.Style.TextAlign = HorizontalAlign.Center;
                txtCountValue.Style.VerticalAlign = VerticalAlign.Middle;
                txtCountValue.Style.Font.Name = "B Nazanin";
                panel2.Items.Add(txtCountValue);

                Telerik.Reporting.TextBox txtPercentValue = new Telerik.Reporting.TextBox();
                txtPercentValue.Value = string.Format("=GetPercent(ReportItem.DataObject.RawData, {0})", resultLabel.Id);
                txtPercentValue.Height = new Unit(panel2.Height.Value, panel2.Height.Type);
                txtPercentValue.Width = new Unit(width / 2, panel2.Width.Type);
                txtPercentValue.Top = new Unit(0);
                txtPercentValue.Left = new Unit(left, panel2.Right.Type);
                txtPercentValue.Style.BorderStyle.Default = BorderType.Solid;
                txtPercentValue.Style.TextAlign = HorizontalAlign.Center;
                txtPercentValue.Style.VerticalAlign = VerticalAlign.Middle;
                txtPercentValue.Style.Font.Name = "B Nazanin";
                panel2.Items.Add(txtPercentValue);

                #endregion

                #region Report Footer

                Telerik.Reporting.TextBox txtSumCount = new Telerik.Reporting.TextBox();
                txtSumCount.Value = string.Format("=GetTotalCount({0})", resultLabel.Id);
                txtSumCount.Height = new Unit(panel4.Height.Value, panel4.Height.Type);
                txtSumCount.Width = new Unit(width / 2, panel4.Width.Type);
                txtSumCount.Top = new Unit(0);
                txtSumCount.Left = new Unit(left + (width / 2), panel4.Right.Type);
                txtSumCount.Style.BorderStyle.Default = BorderType.Solid;
                txtSumCount.Style.TextAlign = HorizontalAlign.Center;
                txtSumCount.Style.VerticalAlign = VerticalAlign.Middle;
                txtSumCount.Style.BackgroundColor = Color.DarkKhaki;
                txtSumCount.Style.Font.Name = "B Nazanin";
                txtSumCount.Style.Font.Bold = true;
                panel4.Items.Add(txtSumCount);

                Telerik.Reporting.TextBox txtSumPercent = new Telerik.Reporting.TextBox();
                txtSumPercent.Value = string.Format("=GetTotalPercent({0})", resultLabel.Id);
                txtSumPercent.Height = new Unit(panel4.Height.Value, panel4.Height.Type);
                txtSumPercent.Width = new Unit(width / 2, panel4.Width.Type);
                txtSumPercent.Top = new Unit(0);
                txtSumPercent.Left = new Unit(left, panel4.Right.Type);
                txtSumPercent.Style.BorderStyle.Default = BorderType.Solid;
                txtSumPercent.Style.TextAlign = HorizontalAlign.Center;
                txtSumPercent.Style.VerticalAlign = VerticalAlign.Middle;
                txtSumPercent.Style.BackgroundColor = Color.DarkKhaki;
                txtSumPercent.Style.Font.Name = "B Nazanin";
                txtSumPercent.Style.Font.Bold = true;
                panel4.Items.Add(txtSumPercent);

                #endregion 

                left -= width;
            }
        }
    }
}