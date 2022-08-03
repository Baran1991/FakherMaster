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
    public partial class rptStudentResultDetails : Report, IConfigurableReport
    {
        public rptStudentResultDetails()
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
            get { return "گزارش تحلیل نتیجه دانشجویان"; }
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
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            DataSet = frm.SectionItem.GetFarsiOrderedParticipates();
        }

        public void Apply(IReportParameterForm frm)
        {
            txtReportName.Value = ReportName + " درس/سطح " + frm.Lesson.Name + " " + frm.SectionItem.Section.FarsiName
                + " [" + frm.SectionItem.Section.Teacher.FarsiFullname + "]";

            EvaluationProtocol evaluationProtocol = frm.Lesson.GetEvaluationProtocol(frm.Period);
            Fill(evaluationProtocol);

            DataSource = DataSet;
        }

        #endregion

        public static float rptStudentResultDetails_GetMark(Participate participate, int groupId)
        {
            try
            {
                EvaluationGroup @group = DbContext.FromId<EvaluationGroup>(groupId);
                float count = participate.CalculateMark(@group);
                return count;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }        
        
        public static float rptStudentResultDetails_GetMark(Participate participate)
        {
            try
            {
                return participate.CalculateMark();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public static string rptStudentResultDetails_GetResult(Participate participate)
        {
            try
            {
                ResultLabel label = participate.GetResultLabel();
                return label.Name;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public static int rptStudentResultDetails_GetRank(Participate participate)
        {
            try
            {
                int rank = participate.SectionItem.CalculateRank(participate);
                return rank;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        private void Fill(EvaluationProtocol protocol)
        {
            float width = panel1.Width.Value/protocol.EvaluationGroups.Count;
            float left = panel1.Right.Value - width - panel1.Left.Value;

            panel1.Items.Clear();
            panel2.Items.Clear();
            foreach (EvaluationGroup evaluationGroup in protocol.EvaluationGroups)
            {
                #region Header 1

                Telerik.Reporting.TextBox txtHeader = new Telerik.Reporting.TextBox();
                txtHeader.Value = " (" + evaluationGroup.TotalValue + ")" + evaluationGroup.Name;
                txtHeader.Height = new Unit(panel1.Height.Value, panel1.Height.Type);
                txtHeader.Width = new Unit(width, panel1.Width.Type);
                txtHeader.Top = new Unit(0);
                txtHeader.Left = new Unit(left, panel1.Right.Type);
                txtHeader.Style.BorderStyle.Default = BorderType.Solid;
                txtHeader.Style.TextAlign = HorizontalAlign.Center;
                txtHeader.Style.VerticalAlign = VerticalAlign.Middle;
                txtHeader.Style.BackgroundColor = Color.DarkKhaki;
                txtHeader.Style.Font.Name = "B Nazanin";
//                txtHeader.Style.Font.Size = new Unit(12);
                txtHeader.Style.Font.Bold = true;
                panel1.Items.Add(txtHeader);

                #endregion 

                #region Detail

                Telerik.Reporting.TextBox txtCountValue = new Telerik.Reporting.TextBox();
                txtCountValue.Value = string.Format("=rptStudentResultDetails_GetMark(ReportItem.DataObject.RawData, {0})", evaluationGroup.Id);
                txtCountValue.Height = new Unit(panel2.Height.Value, panel2.Height.Type);
                txtCountValue.Width = new Unit(width, panel2.Width.Type);
                txtCountValue.Top = new Unit(0);
                txtCountValue.Left = new Unit(left, panel2.Right.Type);
                txtCountValue.Style.BorderStyle.Right = BorderType.Solid;
                txtCountValue.Style.BorderStyle.Left = BorderType.Solid;
                txtCountValue.Style.TextAlign = HorizontalAlign.Center;
                txtCountValue.Style.VerticalAlign = VerticalAlign.Middle;
                txtCountValue.Style.Font.Name = "B Nazanin";
//                txtCountValue.Style.Font.Size = new Unit(12);
                panel2.Items.Add(txtCountValue);

                #endregion

                #region Report Footer
//
//                Telerik.Reporting.TextBox txtSumCount = new Telerik.Reporting.TextBox();
//                txtSumCount.Value = string.Format("=GetTotalCount({0})", resultLabel.Id);
//                txtSumCount.Height = new Unit(panel4.Height.Value, panel4.Height.Type);
//                txtSumCount.Width = new Unit(width / 2, panel4.Width.Type);
//                txtSumCount.Top = new Unit(0);
//                txtSumCount.Left = new Unit(left + (width / 2), panel4.Right.Type);
//                txtSumCount.Style.BorderStyle.Default = BorderType.Solid;
//                txtSumCount.Style.TextAlign = HorizontalAlign.Center;
//                txtSumCount.Style.VerticalAlign = VerticalAlign.Middle;
//                txtSumCount.Style.BackgroundColor = Color.DarkKhaki;
//                txtSumCount.Style.Font.Name = "B Nazanin";
//                txtSumCount.Style.Font.Bold = true;
//                panel4.Items.Add(txtSumCount);
//
//                Telerik.Reporting.TextBox txtSumPercent = new Telerik.Reporting.TextBox();
//                txtSumPercent.Value = string.Format("=GetTotalPercent({0})", resultLabel.Id);
//                txtSumPercent.Height = new Unit(panel4.Height.Value, panel4.Height.Type);
//                txtSumPercent.Width = new Unit(width / 2, panel4.Width.Type);
//                txtSumPercent.Top = new Unit(0);
//                txtSumPercent.Left = new Unit(left, panel4.Right.Type);
//                txtSumPercent.Style.BorderStyle.Default = BorderType.Solid;
//                txtSumPercent.Style.TextAlign = HorizontalAlign.Center;
//                txtSumPercent.Style.VerticalAlign = VerticalAlign.Middle;
//                txtSumPercent.Style.BackgroundColor = Color.DarkKhaki;
//                txtSumPercent.Style.Font.Name = "B Nazanin";
//                txtSumPercent.Style.Font.Bold = true;
//                panel4.Items.Add(txtSumPercent);
//
                #endregion 

                left -= width;
            }
        }
    }
}