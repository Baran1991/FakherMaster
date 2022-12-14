using Fakher.Core.DomainModel.Poll;
using Telerik.Reporting.Charting;
using Telerik.Reporting.Charting.Styles;
using rComponents;

namespace Fakher.Reports.Poll_Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for Report1.
    /// </summary>
    public partial class rptPollChart : Report
    {
        public rptPollChart()
        {
            InitializeComponent();
        }

        public static string TodayDate()
        {
            return PersianDate.Today.ToShortDateString();
        }

        private void chart1_ItemDataBinding(object sender, EventArgs e)
        {
            Poll poll = DataSource as Poll;

            chart1.PlotArea.XAxis.Appearance.TextAppearance.TextProperties.Font = new System.Drawing.Font("Tahoma", 10f);
            chart1.PlotArea.XAxis.Appearance.TextAppearance.AutoTextWrap = AutoTextWrap.False;

//            chart1.PlotArea.XAxis.Appearance.MajorGridLines.Visible = false;
//            chart1.PlotArea.XAxis.Appearance.MinorGridLines.Visible = false;
            //chart1.PlotArea.XAxis.Appearance.LabelAppearance.RotationAngle = -45;
//            chart1.PlotArea.YAxis.Appearance.MajorGridLines.Visible = false;
//            chart1.PlotArea.YAxis.Appearance.MinorGridLines.Visible = false;


            chart1.PlotArea.XAxis.Clear();
            chart1.PlotArea.XAxis.AutoScale = false;
            chart1.Series.Clear();

            ChartSeries series1 = new ChartSeries("excelent", ChartSeriesType.Bar);
            series1.DefaultLabelValue = "بسیار خوب";
            chart1.Series.Add(series1);
            ChartSeries series2 = new ChartSeries("good", ChartSeriesType.Bar);
            series2.DefaultLabelValue = " خوب";
            chart1.Series.Add(series2);
            ChartSeries series3 = new ChartSeries("average", ChartSeriesType.Bar);
            series3.DefaultLabelValue = "متوسط";
            chart1.Series.Add(series3);
            ChartSeries series4 = new ChartSeries("week", ChartSeriesType.Bar);
            series4.DefaultLabelValue = "ضعیف";
            chart1.Series.Add(series4);
            foreach (PollItem item in poll.Items)
            {
                chart1.PlotArea.XAxis.AddItem(item.Text);
                //series.PlotArea.XAxis.AddItem(item.Text);
                series1.AddItem(item.Hits_1);
                //series.PlotArea.XAxis.AddItem(" خوب");
                series2.AddItem(item.Hits_2);
                //series.PlotArea.XAxis.AddItem("متوسط");
                series3.AddItem(item.Hits_3);
                //series.PlotArea.XAxis.AddItem("ضعیف");
                series4.AddItem(item.Hits_4);
            }
            
        }

        private void txtReportName_ItemDataBinding(object sender, EventArgs e)
        {
            Poll poll = DataSource as Poll;
            txtReportName.Value = "گزارش نمودار " + poll.Name;
        }
    }
}