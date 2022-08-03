namespace Fakher.Reports
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class rptEnReportCard
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.TableGroup tableGroup13 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup14 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup15 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.Drawing.FormattingRule formattingRule9 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.Drawing.FormattingRule formattingRule10 = new Telerik.Reporting.Drawing.FormattingRule();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.panel1 = new Telerik.Reporting.Panel();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.table1 = new Telerik.Reporting.Table();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.panel3 = new Telerik.Reporting.Panel();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.shape3 = new Telerik.Reporting.Shape();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4.2999997138977051, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.75, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox1.Style.BackgroundColor = System.Drawing.Color.DarkGray;
            this.textBox1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox1.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "Item";
            // 
            // textBox2
            // 
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4.2999997138977051, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.75, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox2.Style.BackgroundColor = System.Drawing.Color.DarkGray;
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox2.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "Mark";
            // 
            // textBox8
            // 
            this.textBox8.Culture = new System.Globalization.CultureInfo("en");
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(7.0010018348693848, Telerik.Reporting.Drawing.UnitType.Mm));
            this.textBox8.Name = "textBox6";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(86, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(5.17933464050293, Telerik.Reporting.Drawing.UnitType.Mm));
            this.textBox8.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox8.Style.Color = System.Drawing.Color.Black;
            this.textBox8.Style.Font.Bold = true;
            this.textBox8.Style.Font.Name = "Times New Roman";
            this.textBox8.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(14, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBox8.Value = "Report Card";
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pictureBox1,
            this.textBox16,
            this.textBox4,
            this.textBox12});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.20000000298023224, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(1.2182337045669556, Telerik.Reporting.Drawing.UnitType.Cm));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(8.6000003814697266, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(1.8817663192749023, Telerik.Reporting.Drawing.UnitType.Cm));
            this.panel1.Style.BackgroundColor = System.Drawing.Color.Silver;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Mm));
            this.pictureBox1.MimeType = "";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(19.999998092651367, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(18.164844512939453, Telerik.Reporting.Drawing.UnitType.Mm));
            this.pictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.pictureBox1.Value = "=Fields.Register.Student.Photo.Picture";
            // 
            // textBox16
            // 
            this.textBox16.Culture = new System.Globalization.CultureInfo("en");
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(21.002004623413086, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(0.00099921226501464844, Telerik.Reporting.Drawing.UnitType.Mm));
            this.textBox16.Name = "textBox4";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(29.995992660522461, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(5.9999971389770508, Telerik.Reporting.Drawing.UnitType.Mm));
            this.textBox16.Style.Font.Bold = true;
            this.textBox16.Style.Font.Name = "Times New Roman";
            this.textBox16.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox16.Value = "=Fields.Register.Code";
            // 
            // textBox4
            // 
            this.textBox4.Culture = new System.Globalization.CultureInfo("en");
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(21.002004623413086, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(6.0029945373535156, Telerik.Reporting.Drawing.UnitType.Mm));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(63.997989654541016, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(6.001988410949707, Telerik.Reporting.Drawing.UnitType.Mm));
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Style.Font.Name = "Times New Roman";
            this.textBox4.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.Value = "=Fields.Register.Student.EnglishFullname";
            // 
            // textBox12
            // 
            this.textBox12.Culture = new System.Globalization.CultureInfo("en");
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2.10020112991333, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(1.2164844274520874, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox12.Name = "textBox9";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.3997983932495117, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000008344650269, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox12.Style.Font.Bold = false;
            this.textBox12.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(11, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.Value = "=Fields.SectionItem.Lesson.Name + \', \' + Fields.SectionItem.Section.EnglishName +" +
                " \', \' + Fields.Register.Period.Name";
            // 
            // detail
            // 
            //this.detail.ColumnCount = 2;
            this.PageSettings.ColumnCount = 2;
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(7.10020112991333, Telerik.Reporting.Drawing.UnitType.Cm);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.table1,
            this.panel3,
            this.textBox8,
            this.panel1,
            this.shape3,
            this.textBox19});
            this.detail.Name = "detail";
            this.detail.PageBreak = Telerik.Reporting.PageBreak.None;
            // 
            // table1
            // 
            this.table1.Bindings.Add(new Telerik.Reporting.Binding("DataSource", "=GetReportCardItems(ReportItem.DataObject.RawData)"));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(new Telerik.Reporting.Drawing.Unit(4.2999997138977051, Telerik.Reporting.Drawing.UnitType.Cm)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(new Telerik.Reporting.Drawing.Unit(4.2999997138977051, Telerik.Reporting.Drawing.UnitType.Cm)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(new Telerik.Reporting.Drawing.Unit(0.75, Telerik.Reporting.Drawing.UnitType.Cm)));
            this.table1.Body.SetCellContent(0, 0, this.textBox5);
            this.table1.Body.SetCellContent(0, 1, this.textBox6);
            tableGroup13.ReportItem = this.textBox1;
            tableGroup14.ReportItem = this.textBox2;
            this.table1.ColumnGroups.Add(tableGroup13);
            this.table1.ColumnGroups.Add(tableGroup14);
            this.table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox5,
            this.textBox6,
            this.textBox1,
            this.textBox2});
            this.table1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.20000000298023224, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(3.2000000476837158, Telerik.Reporting.Drawing.UnitType.Cm));
            this.table1.Name = "table1";
            tableGroup15.Grouping.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("")});
            tableGroup15.Name = "DetailGroup";
            this.table1.RowGroups.Add(tableGroup15);
            this.table1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(8.59999942779541, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(1.5, Telerik.Reporting.Drawing.UnitType.Cm));
            // 
            // textBox5
            // 
            formattingRule9.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("= RowNumber(\"\") % 2", Telerik.Reporting.FilterOperator.Equal, "0")});
            formattingRule9.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.textBox5.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule9});
            this.textBox5.Culture = new System.Globalization.CultureInfo("en");
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4.2999997138977051, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.75, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox5.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox5.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox5.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "=Fields.Key";
            // 
            // textBox6
            // 
            formattingRule10.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("= RowNumber(\"\") % 2", Telerik.Reporting.FilterOperator.Equal, "0")});
            formattingRule10.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.textBox6.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule10});
            this.textBox6.Culture = new System.Globalization.CultureInfo("en");
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4.2999997138977051, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.75, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox6.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox6.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox6.Style.Font.Bold = true;
            this.textBox6.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = "=Fields.Value";
            // 
            // panel3
            // 
            this.panel3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox9,
            this.textBox3,
            this.textBox7,
            this.textBox14,
            this.textBox10,
            this.textBox11,
            this.textBox18,
            this.textBox13,
            this.textBox15});
            this.panel3.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.20000000298023224, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(4.8000001907348633, Telerik.Reporting.Drawing.UnitType.Cm));
            this.panel3.Name = "panel3";
            this.panel3.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(8.59999942779541, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(1.9001008272171021, Telerik.Reporting.Drawing.UnitType.Cm));
            this.panel3.Style.BackgroundColor = System.Drawing.Color.Silver;
            // 
            // textBox9
            // 
            this.textBox9.Culture = new System.Globalization.CultureInfo("en");
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.00010012308484874666, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.69989991188049316, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000008344650269, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.Value = "Result:";
            // 
            // textBox3
            // 
            this.textBox3.Culture = new System.Globalization.CultureInfo("en");
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2.1002004146575928, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(1.3001006841659546, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox3.Name = "textBox9";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.9995992183685303, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000008344650269, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "=rptEnReportCard_GetRank(ReportItem.DataObject.RawData)";
            // 
            // textBox7
            // 
            this.textBox7.Culture = new System.Globalization.CultureInfo("en");
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2.10020112991333, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.099699176847934723, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox7.Name = "textBox9";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.999598503112793, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000008344650269, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox7.Style.Font.Bold = true;
            this.textBox7.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.Value = "= GetReportCardTotalMark(ReportItem.DataObject.RawData)";
            // 
            // textBox14
            // 
            this.textBox14.Culture = new System.Globalization.CultureInfo("en");
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.099699176847934723, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox14.Name = "textBox9";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000008344650269, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.Value = "Total:";
            // 
            // textBox10
            // 
            this.textBox10.Culture = new System.Globalization.CultureInfo("en");
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(1.3001006841659546, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox10.Name = "textBox9";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000008344650269, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.Value = "Rank:";
            // 
            // textBox11
            // 
            this.textBox11.Culture = new System.Globalization.CultureInfo("en");
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2.1002004146575928, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.69990074634552, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox11.Name = "textBox9";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.19980001449585, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000008344650269, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox11.Style.Font.Bold = true;
            this.textBox11.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox11.Value = "= GetReportCardResult(ReportItem.DataObject.RawData)";
            // 
            // textBox18
            // 
            this.textBox18.Culture = new System.Globalization.CultureInfo("en");
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(5.1000003814697266, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(1.3001006841659546, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox18.Name = "textBox9";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(3.2000000476837158, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000091791152954, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox18.Value = "Board of Education";
            // 
            // shape3
            // 
            this.shape3.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(67.003013610839844, Telerik.Reporting.Drawing.UnitType.Mm));
            this.shape3.Name = "shape3";
            this.shape3.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape3.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(89.5989990234375, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(3.9989967346191406, Telerik.Reporting.Drawing.UnitType.Mm));
            this.shape3.Stretch = true;
            this.shape3.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Dotted;
            // 
            // textBox19
            // 
            this.textBox19.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.20000000298023224, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.00010012308484874666, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(8.6000003814697266, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.69980019330978394, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox19.Style.Color = System.Drawing.Color.Red;
            this.textBox19.Style.Font.Bold = false;
            this.textBox19.Style.Font.Name = "Impact";
            this.textBox19.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(18, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox19.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox19.Value = "Fakher Language College";
            // 
            // textBox13
            // 
            this.textBox13.Culture = new System.Globalization.CultureInfo("en");
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(5.1000003814697266, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.099699176847934723, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000008344650269, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.Value = "Absences:";
            // 
            // textBox15
            // 
            this.textBox15.Culture = new System.Globalization.CultureInfo("en");
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(7.1002001762390137, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.099699176847934723, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox15.Name = "textBox9";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.1997997760772705, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000091791152954, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox15.Style.Font.Bold = true;
            this.textBox15.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox15.Value = "=Fields.AbsencesCount";
            // 
            // rptEnReportCard
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = new Telerik.Reporting.Drawing.Unit(1.5399999618530273, Telerik.Reporting.Drawing.UnitType.Cm);
            this.PageSettings.Margins.Left = new Telerik.Reporting.Drawing.Unit(1.5399999618530273, Telerik.Reporting.Drawing.UnitType.Cm);
            this.PageSettings.Margins.Right = new Telerik.Reporting.Drawing.Unit(1.5399999618530273, Telerik.Reporting.Drawing.UnitType.Cm);
            this.PageSettings.Margins.Top = new Telerik.Reporting.Drawing.Unit(1.5399999618530273, Telerik.Reporting.Drawing.UnitType.Cm);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = new Telerik.Reporting.Drawing.Unit(7.869999885559082, Telerik.Reporting.Drawing.UnitType.Cm);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.Panel panel1;
        private Table table1;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.Panel panel3;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox14;
        private Shape shape3;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox15;
    }
}