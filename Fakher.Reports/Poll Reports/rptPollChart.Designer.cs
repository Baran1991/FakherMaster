namespace Fakher.Reports.Poll_Reports
{
    partial class rptPollChart
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptPollChart));
            Telerik.Reporting.Charting.Styles.Corners corners1 = new Telerik.Reporting.Charting.Styles.Corners();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins1 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.Corners corners2 = new Telerik.Reporting.Charting.Styles.Corners();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins2 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.LabelItem labelItem1 = new Telerik.Reporting.Charting.LabelItem();
            Telerik.Reporting.Charting.LabelItem labelItem2 = new Telerik.Reporting.Charting.LabelItem();
            Telerik.Reporting.Charting.LabelItem labelItem3 = new Telerik.Reporting.Charting.LabelItem();
            Telerik.Reporting.Charting.LabelItem labelItem4 = new Telerik.Reporting.Charting.LabelItem();
            Telerik.Reporting.Charting.Styles.Corners corners3 = new Telerik.Reporting.Charting.Styles.Corners();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins3 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.txtDate = new Telerik.Reporting.TextBox();
            this.textBox36 = new Telerik.Reporting.TextBox();
            this.pictureBox2 = new Telerik.Reporting.PictureBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox30 = new Telerik.Reporting.TextBox();
            this.txtReportName = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.chart1 = new Telerik.Reporting.Chart();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = new Telerik.Reporting.Drawing.Unit(3.2999999523162842D, Telerik.Reporting.Drawing.UnitType.Cm);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox13,
            this.txtDate,
            this.textBox36,
            this.pictureBox2,
            this.textBox10,
            this.textBox30,
            this.txtReportName});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(1.2061502933502197D, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(3.1998999118804932D, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.39364966750144958D, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox13.Style.Font.Name = "B Nazanin";
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.Value = "= \' صفحه \' + PageNumber + \' از \' + PageCount";
            // 
            // txtDate
            // 
            this.txtDate.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.41240033507347107D, Telerik.Reporting.Drawing.UnitType.Cm));
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(3.1998999118804932D, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.39364966750144958D, Telerik.Reporting.Drawing.UnitType.Cm));
            this.txtDate.Style.Font.Name = "B Nazanin";
            this.txtDate.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.txtDate.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtDate.Value = "= \'تاریخ گزارش: \' + TodayDate()";
            // 
            // textBox36
            // 
            this.textBox36.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.80927532911300659D, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox36.Name = "textBox36";
            this.textBox36.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(3.1998999118804932D, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.39364966750144958D, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox36.Style.Font.Name = "B Nazanin";
            this.textBox36.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox36.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox36.Value = "= \' زمان گزارش: \' + Now().ToShortTimeString()";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(259.17703247070312D, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Mm));
            this.pictureBox2.MimeType = "image/png";
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(17.821950912475586D, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(15.99799919128418D, Telerik.Reporting.Drawing.UnitType.Mm));
            this.pictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox2.Value = ((object)(resources.GetObject("pictureBox2.Value")));
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(216.84368896484375D, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(5.942664623260498D, Telerik.Reporting.Drawing.UnitType.Mm));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(42.277694702148438D, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(3.9979984760284424D, Telerik.Reporting.Drawing.UnitType.Mm));
            this.textBox10.Style.Font.Name = "B Nazanin";
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox10.Value = "موسسه آموزش عالی آزاد";
            // 
            // textBox30
            // 
            this.textBox30.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(216.84368896484375D, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Mm));
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(42.277687072753906D, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(6.49899435043335D, Telerik.Reporting.Drawing.UnitType.Mm));
            this.textBox30.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox30.Style.Color = System.Drawing.Color.Black;
            this.textBox30.Style.Font.Bold = true;
            this.textBox30.Style.Font.Name = "B Titr";
            this.textBox30.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(14D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox30.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox30.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox30.Value = "فاخــــــــــر";
            // 
            // txtReportName
            // 
            this.txtReportName.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.0010012307902798057D, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(15.999998092651367D, Telerik.Reporting.Drawing.UnitType.Mm));
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(276.99801635742188D, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(8D, Telerik.Reporting.Drawing.UnitType.Mm));
            this.txtReportName.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.txtReportName.Style.Color = System.Drawing.Color.Black;
            this.txtReportName.Style.Font.Bold = true;
            this.txtReportName.Style.Font.Name = "B Titr";
            this.txtReportName.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(16D, Telerik.Reporting.Drawing.UnitType.Point);
            this.txtReportName.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txtReportName.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtReportName.Value = "گزارش نمودار نظرسنجی";
            this.txtReportName.ItemDataBinding += new System.EventHandler(this.txtReportName_ItemDataBinding);
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(8.1000003814697266D, Telerik.Reporting.Drawing.UnitType.Cm);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.chart1});
            this.detail.Name = "detail";
            // 
            // chart1
            // 
            this.chart1.Appearance.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.chart1.Appearance.FillStyle.FillType = Telerik.Reporting.Charting.Styles.FillType.Gradient;
            this.chart1.Appearance.FillStyle.MainColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(234)))));
            this.chart1.Appearance.FillStyle.SecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(172)))), ((int)(((byte)(137)))));
            this.chart1.BitmapResolution = 96F;
            this.chart1.ChartTitle.Appearance.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            corners1.BottomLeft = Telerik.Reporting.Charting.Styles.CornerType.Round;
            corners1.BottomRight = Telerik.Reporting.Charting.Styles.CornerType.Round;
            corners1.TopLeft = Telerik.Reporting.Charting.Styles.CornerType.Round;
            corners1.TopRight = Telerik.Reporting.Charting.Styles.CornerType.Round;
            this.chart1.ChartTitle.Appearance.Corners = corners1;
            chartMargins1.Bottom = new Telerik.Reporting.Charting.Styles.Unit(14D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins1.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins1.Right = new Telerik.Reporting.Charting.Styles.Unit(10D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins1.Top = new Telerik.Reporting.Charting.Styles.Unit(4D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            this.chart1.ChartTitle.Appearance.Dimensions.Margins = chartMargins1;
            this.chart1.ChartTitle.Appearance.FillStyle.MainColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(183)))), ((int)(((byte)(144)))));
            this.chart1.ChartTitle.Appearance.Position.AlignedPosition = Telerik.Reporting.Charting.Styles.AlignedPositions.Top;
            this.chart1.ChartTitle.Appearance.Visible = false;
            this.chart1.ChartTitle.TextBlock.Appearance.TextProperties.Color = System.Drawing.Color.White;
            this.chart1.ChartTitle.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
            this.chart1.ChartTitle.Visible = false;
            this.chart1.Docking = Telerik.Reporting.DockingStyle.Fill;
            this.chart1.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chart1.Legend.Appearance.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            corners2.BottomLeft = Telerik.Reporting.Charting.Styles.CornerType.Round;
            corners2.BottomRight = Telerik.Reporting.Charting.Styles.CornerType.Round;
            corners2.TopLeft = Telerik.Reporting.Charting.Styles.CornerType.Round;
            corners2.TopRight = Telerik.Reporting.Charting.Styles.CornerType.Round;
            this.chart1.Legend.Appearance.Corners = corners2;
            chartMargins2.Right = new Telerik.Reporting.Charting.Styles.Unit(1D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins2.Top = new Telerik.Reporting.Charting.Styles.Unit(18D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            this.chart1.Legend.Appearance.Dimensions.Margins = chartMargins2;
            this.chart1.Legend.Appearance.FillStyle.MainColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(183)))), ((int)(((byte)(144)))));
            this.chart1.Legend.Appearance.Visible = false;
            labelItem1.Marker.Visible = true;
            labelItem1.TextBlock.Text = "بسیار خوب";
            labelItem2.Marker.Visible = true;
            labelItem2.TextBlock.Text = "خوب";
            labelItem3.Marker.Visible = true;
            labelItem3.TextBlock.Text = "متوسط";
            labelItem4.Marker.Visible = true;
            labelItem4.TextBlock.Text = "ضعیف";
            this.chart1.Legend.Items.AddRange(new Telerik.Reporting.Charting.LabelItem[] {
            labelItem1,
            labelItem2,
            labelItem3,
            labelItem4});
            this.chart1.Legend.Visible = false;
            this.chart1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Cm));
            this.chart1.Name = "chart1";
            this.chart1.PlotArea.Appearance.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(93)))));
            corners3.BottomLeft = Telerik.Reporting.Charting.Styles.CornerType.Round;
            corners3.BottomRight = Telerik.Reporting.Charting.Styles.CornerType.Round;
            corners3.RoundSize = 6;
            corners3.TopLeft = Telerik.Reporting.Charting.Styles.CornerType.Round;
            corners3.TopRight = Telerik.Reporting.Charting.Styles.CornerType.Round;
            this.chart1.PlotArea.Appearance.Corners = corners3;
            chartMargins3.Bottom = new Telerik.Reporting.Charting.Styles.Unit(12D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins3.Left = new Telerik.Reporting.Charting.Styles.Unit(10D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins3.Right = new Telerik.Reporting.Charting.Styles.Unit(22D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins3.Top = new Telerik.Reporting.Charting.Styles.Unit(18D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            this.chart1.PlotArea.Appearance.Dimensions.Margins = chartMargins3;
            this.chart1.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.chart1.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(107)))), ((int)(((byte)(186)))));
            this.chart1.PlotArea.EmptySeriesMessage.Appearance.Visible = true;
            this.chart1.PlotArea.EmptySeriesMessage.Visible = true;
            this.chart1.PlotArea.XAxis.Appearance.MajorGridLines.Color = System.Drawing.Color.DimGray;
            this.chart1.PlotArea.XAxis.Appearance.MajorTick.Color = System.Drawing.Color.Black;
            this.chart1.PlotArea.XAxis.Appearance.TextAppearance.TextProperties.Color = System.Drawing.Color.Black;
            this.chart1.PlotArea.XAxis.AxisLabel.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.chart1.PlotArea.XAxis.MinValue = 1D;
            this.chart1.PlotArea.YAxis.Appearance.MajorGridLines.Color = System.Drawing.Color.Black;
            this.chart1.PlotArea.YAxis.AxisLabel.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.chart1.PlotArea.YAxis.MaxValue = 100D;
            this.chart1.PlotArea.YAxis.Step = 10D;
            this.chart1.PlotArea.YAxis2.AxisLabel.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.chart1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(27.700000762939453D, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(8.1000003814697266D, Telerik.Reporting.Drawing.UnitType.Cm));
            this.chart1.Skin = "Gradient";
            this.chart1.ItemDataBinding += new System.EventHandler(this.chart1_ItemDataBinding);
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = new Telerik.Reporting.Drawing.Unit(3D, Telerik.Reporting.Drawing.UnitType.Cm);
            this.pageFooterSection1.Name = "pageFooterSection1";
            this.pageFooterSection1.Style.Visible = false;
            // 
            // rptPollChart
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.Name = "Report1";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins.Bottom = new Telerik.Reporting.Drawing.Unit(10D, Telerik.Reporting.Drawing.UnitType.Mm);
            this.PageSettings.Margins.Left = new Telerik.Reporting.Drawing.Unit(10D, Telerik.Reporting.Drawing.UnitType.Mm);
            this.PageSettings.Margins.Right = new Telerik.Reporting.Drawing.Unit(10D, Telerik.Reporting.Drawing.UnitType.Mm);
            this.PageSettings.Margins.Top = new Telerik.Reporting.Drawing.Unit(10D, Telerik.Reporting.Drawing.UnitType.Mm);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = new Telerik.Reporting.Drawing.Unit(27.700000762939453D, Telerik.Reporting.Drawing.UnitType.Cm);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.Chart chart1;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox txtDate;
        private Telerik.Reporting.TextBox textBox36;
        private Telerik.Reporting.PictureBox pictureBox2;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox30;
        private Telerik.Reporting.TextBox txtReportName;
    }
}