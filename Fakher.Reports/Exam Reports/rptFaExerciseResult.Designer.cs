namespace Fakher.Reports
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class rptFaExerciseResult
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptFaExerciseResult));
            Telerik.Reporting.Drawing.FormattingRule formattingRule1 = new Telerik.Reporting.Drawing.FormattingRule();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.pictureBox2 = new Telerik.Reporting.PictureBox();
            this.textBox30 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.txtTotalMark = new Telerik.Reporting.TextBox();
            this.pnlHeader = new Telerik.Reporting.Panel();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.txtDate = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.pnlItems = new Telerik.Reporting.Panel();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.reportFooterSection1 = new Telerik.Reporting.ReportFooterSection();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.pnlMinimum = new Telerik.Reporting.Panel();
            this.pnlAverage = new Telerik.Reporting.Panel();
            this.pnlMaximum = new Telerik.Reporting.Panel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(4.2D);
            this.pageHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox8,
            this.textBox13,
            this.textBox10,
            this.pictureBox2,
            this.textBox30,
            this.textBox6,
            this.textBox2,
            this.textBox5,
            this.textBox1,
            this.txtTotalMark,
            this.pnlHeader,
            this.textBox3,
            this.txtDate});
            this.pageHeader.Name = "pageHeader";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.806D));
            this.textBox8.Name = "textBox13";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2D), Telerik.Reporting.Drawing.Unit.Cm(0.394D));
            this.textBox8.Style.Font.Name = "B Nazanin";
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox8.Value = "= \' زمان گزارش: \' + Now().ToShortTimeString()";
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(1.203D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2D), Telerik.Reporting.Drawing.Unit.Cm(0.394D));
            this.textBox13.Style.Font.Name = "B Nazanin";
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.Value = "= \' صفحه \' + PageNumber + \' از \' + PageCount";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(217.72D), Telerik.Reporting.Drawing.Unit.Mm(6.09D));
            this.textBox10.Name = "textBox2";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(42.28D), Telerik.Reporting.Drawing.Unit.Mm(4D));
            this.textBox10.Style.Font.Name = "B Nazanin";
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox10.Value = "موسسه آموزش عالی آزاد";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(260D), Telerik.Reporting.Drawing.Unit.Mm(0D));
            this.pictureBox2.MimeType = "image/png";
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(17D), Telerik.Reporting.Drawing.Unit.Mm(16D));
            this.pictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox2.Value = ((object)(resources.GetObject("pictureBox2.Value")));
            // 
            // textBox30
            // 
            this.textBox30.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(217.72D), Telerik.Reporting.Drawing.Unit.Mm(0D));
            this.textBox30.Name = "textBox22";
            this.textBox30.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(42.28D), Telerik.Reporting.Drawing.Unit.Mm(6.5D));
            this.textBox30.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox30.Style.Color = System.Drawing.Color.Black;
            this.textBox30.Style.Font.Bold = true;
            this.textBox30.Style.Font.Name = "B Titr";
            this.textBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.textBox30.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox30.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox30.Value = "فاخــــــــــر";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(16D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(277D), Telerik.Reporting.Drawing.Unit.Mm(5.18D));
            this.textBox6.Style.BackgroundColor = System.Drawing.Color.DarkKhaki;
            this.textBox6.Style.Color = System.Drawing.Color.Black;
            this.textBox6.Style.Font.Bold = true;
            this.textBox6.Style.Font.Name = "B Nazanin";
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = "نتایج تمرین بلکبورد";
            this.textBox6.ItemDataBinding += new System.EventHandler(this.textBox6_ItemDataBinding);
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(19.527D), Telerik.Reporting.Drawing.Unit.Cm(2.4D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.162D), Telerik.Reporting.Drawing.Unit.Cm(1.159D));
            this.textBox2.Style.BackgroundColor = System.Drawing.Color.DarkKhaki;
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.Color = System.Drawing.Color.Black;
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Name = "B Nazanin";
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "نام و نام خانوادگی";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(26.7D), Telerik.Reporting.Drawing.Unit.Cm(2.4D));
            this.textBox5.Name = "textBox4";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1D), Telerik.Reporting.Drawing.Unit.Cm(1.159D));
            this.textBox5.Style.BackgroundColor = System.Drawing.Color.DarkKhaki;
            this.textBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.Color = System.Drawing.Color.Black;
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Style.Font.Name = "B Nazanin";
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "ردیف";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(18.008D), Telerik.Reporting.Drawing.Unit.Cm(2.4D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.519D), Telerik.Reporting.Drawing.Unit.Cm(1.159D));
            this.textBox1.Style.BackgroundColor = System.Drawing.Color.DarkKhaki;
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.Style.Color = System.Drawing.Color.Black;
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Name = "B Nazanin";
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "فرم تمرین";
            // 
            // txtTotalMark
            // 
            this.txtTotalMark.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.808D), Telerik.Reporting.Drawing.Unit.Cm(2.4D));
            this.txtTotalMark.Name = "txtTotalMark";
            this.txtTotalMark.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.819D), Telerik.Reporting.Drawing.Unit.Cm(1.159D));
            this.txtTotalMark.Style.BackgroundColor = System.Drawing.Color.DarkKhaki;
            this.txtTotalMark.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.txtTotalMark.Style.Color = System.Drawing.Color.Black;
            this.txtTotalMark.Style.Font.Bold = true;
            this.txtTotalMark.Style.Font.Name = "B Nazanin";
            this.txtTotalMark.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txtTotalMark.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtTotalMark.Value = "";
            this.txtTotalMark.ItemDataBinding += new System.EventHandler(this.txtTotalMark_ItemDataBinding);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.627D), Telerik.Reporting.Drawing.Unit.Cm(2.4D));
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(12.381D), Telerik.Reporting.Drawing.Unit.Cm(1.159D));
            this.pnlHeader.Style.BackgroundColor = System.Drawing.Color.DarkKhaki;
            this.pnlHeader.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pnlHeader.Style.Font.Bold = true;
            this.pnlHeader.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.pnlHeader.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.pnlHeader.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(2.4D));
            this.textBox3.Name = "txtTotalMark";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.808D), Telerik.Reporting.Drawing.Unit.Cm(1.159D));
            this.textBox3.Style.BackgroundColor = System.Drawing.Color.DarkKhaki;
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox3.Style.Color = System.Drawing.Color.Black;
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Name = "B Nazanin";
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "رتــبـــه";
            this.textBox3.ItemDataBinding += new System.EventHandler(this.txtTotalMark_ItemDataBinding);
            // 
            // txtDate
            // 
            this.txtDate.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.412D));
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2D), Telerik.Reporting.Drawing.Unit.Cm(0.394D));
            this.txtDate.Style.Font.Name = "B Nazanin";
            this.txtDate.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.txtDate.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtDate.Value = "= \'تاریخ گزارش: \' + TodayDate()";
            // 
            // detail
            // 
            formattingRule1.Filters.Add(new Telerik.Reporting.Filter("=RowNumber(\"\") % 2", Telerik.Reporting.FilterOperator.Equal, "0"));
            formattingRule1.Style.BackgroundColor = System.Drawing.Color.DarkKhaki;
            this.detail.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.602D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox7,
            this.textBox12,
            this.textBox18,
            this.textBox14,
            this.textBox11,
            this.pnlItems,
            this.textBox4});
            this.detail.Name = "detail";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(267D), Telerik.Reporting.Drawing.Unit.Mm(0.02D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(10D), Telerik.Reporting.Drawing.Unit.Mm(6D));
            this.textBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox7.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.Font.Name = "B Nazanin";
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.Value = "= RowNumber(\"\")";
            // 
            // textBox12
            // 
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(28.08D), Telerik.Reporting.Drawing.Unit.Mm(0D));
            this.textBox12.Name = "textBox1";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(28.08D), Telerik.Reporting.Drawing.Unit.Mm(6D));
            this.textBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox12.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox12.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox12.Style.Font.Bold = true;
            this.textBox12.Style.Font.Name = "B Nazanin";
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.Value = "=GetTotalMark(ReportItem.DataObject.RawData)";
            // 
            // textBox18
            // 
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(195.27D), Telerik.Reporting.Drawing.Unit.Mm(0.02D));
            this.textBox18.Name = "textBox1";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(39.62D), Telerik.Reporting.Drawing.Unit.Mm(6D));
            this.textBox18.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox18.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox18.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox18.Style.Font.Name = "B Nazanin";
            this.textBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox18.TextWrap = false;
            this.textBox18.Value = "=Fields.Register.Student.FarsiLastName";
            // 
            // textBox14
            // 
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(234.89D), Telerik.Reporting.Drawing.Unit.Mm(0.02D));
            this.textBox14.Name = "textBox1";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(32D), Telerik.Reporting.Drawing.Unit.Mm(6D));
            this.textBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.Style.Font.Name = "B Nazanin";
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.TextWrap = false;
            this.textBox14.Value = "=Fields.Register.Student.FarsiFirstName";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(180.08D), Telerik.Reporting.Drawing.Unit.Mm(0.02D));
            this.textBox11.Name = "textBox1";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(15.19D), Telerik.Reporting.Drawing.Unit.Mm(6D));
            this.textBox11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox11.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox11.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox11.Style.Font.Name = "B Nazanin";
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox11.Value = "=Fields.ExamForm.Name";
            // 
            // pnlItems
            // 
            this.pnlItems.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.627D), Telerik.Reporting.Drawing.Unit.Cm(0.003D));
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(12.381D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.pnlItems.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pnlItems.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pnlItems.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.pnlItems.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox4
            // 
            this.textBox4.Format = "{0:#.}";
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D));
            this.textBox4.Name = "textBox1";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(28.08D), Telerik.Reporting.Drawing.Unit.Mm(6D));
            this.textBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox4.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Style.Font.Name = "B Nazanin";
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.Value = "=rptFaExamResult_GetRank(ReportItem.DataObject.RawData)";
            // 
            // reportFooterSection1
            // 
            this.reportFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.817D);
            this.reportFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox17,
            this.textBox16,
            this.textBox9,
            this.textBox15,
            this.textBox19,
            this.textBox20,
            this.pnlMinimum,
            this.pnlAverage,
            this.pnlMaximum});
            this.reportFooterSection1.Name = "reportFooterSection1";
            // 
            // textBox17
            // 
            this.textBox17.Culture = new System.Globalization.CultureInfo("en");
            this.textBox17.Format = "{0:#.00}";
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(28.19D), Telerik.Reporting.Drawing.Unit.Mm(12.09D));
            this.textBox17.Name = "textBox1";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(27.97D), Telerik.Reporting.Drawing.Unit.Mm(6D));
            this.textBox17.Style.BackgroundColor = System.Drawing.Color.DarkKhaki;
            this.textBox17.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox17.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox17.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox17.Style.Font.Bold = true;
            this.textBox17.Style.Font.Name = "Arial";
            this.textBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox17.Value = "=MaxMark()";
            // 
            // textBox16
            // 
            this.textBox16.Culture = new System.Globalization.CultureInfo("en");
            this.textBox16.Format = "{0:#.00}";
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(28.08D), Telerik.Reporting.Drawing.Unit.Mm(6D));
            this.textBox16.Name = "textBox1";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(28.08D), Telerik.Reporting.Drawing.Unit.Mm(5.99D));
            this.textBox16.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox16.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox16.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox16.Style.Font.Bold = true;
            this.textBox16.Style.Font.Name = "Arial";
            this.textBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox16.Value = "=AvgMark()";
            // 
            // textBox9
            // 
            this.textBox9.Culture = new System.Globalization.CultureInfo("en");
            this.textBox9.Format = "{0:#.00}";
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(28.08D), Telerik.Reporting.Drawing.Unit.Mm(0D));
            this.textBox9.Name = "textBox1";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(28.08D), Telerik.Reporting.Drawing.Unit.Mm(6D));
            this.textBox9.Style.BackgroundColor = System.Drawing.Color.DarkKhaki;
            this.textBox9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox9.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.Font.Bold = true;
            this.textBox9.Style.Font.Name = "Arial";
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.Value = "=MinMark()";
            // 
            // textBox15
            // 
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(180.08D), Telerik.Reporting.Drawing.Unit.Mm(12.08D));
            this.textBox15.Name = "textBox3";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(96.92D), Telerik.Reporting.Drawing.Unit.Mm(6D));
            this.textBox15.Style.BackgroundColor = System.Drawing.Color.DarkKhaki;
            this.textBox15.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox15.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox15.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox15.Style.Font.Bold = true;
            this.textBox15.Style.Font.Name = "B Nazanin";
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox15.Value = "حداکثر ";
            // 
            // textBox19
            // 
            this.textBox19.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(180.08D), Telerik.Reporting.Drawing.Unit.Mm(6D));
            this.textBox19.Name = "textBox3";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(96.92D), Telerik.Reporting.Drawing.Unit.Mm(6D));
            this.textBox19.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox19.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox19.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox19.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox19.Style.Font.Bold = true;
            this.textBox19.Style.Font.Name = "B Nazanin";
            this.textBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox19.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox19.Value = "میانگین";
            // 
            // textBox20
            // 
            this.textBox20.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(180.08D), Telerik.Reporting.Drawing.Unit.Mm(0D));
            this.textBox20.Name = "textBox3";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(96.92D), Telerik.Reporting.Drawing.Unit.Mm(6D));
            this.textBox20.Style.BackgroundColor = System.Drawing.Color.DarkKhaki;
            this.textBox20.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox20.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox20.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox20.Style.Font.Bold = true;
            this.textBox20.Style.Font.Name = "B Nazanin";
            this.textBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox20.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox20.Value = "حداقل";
            // 
            // pnlMinimum
            // 
            this.pnlMinimum.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.627D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.pnlMinimum.Name = "pnlMinimum";
            this.pnlMinimum.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(12.381D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.pnlMinimum.Style.BackgroundColor = System.Drawing.Color.DarkKhaki;
            this.pnlMinimum.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pnlMinimum.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pnlMinimum.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.pnlMinimum.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // pnlAverage
            // 
            this.pnlAverage.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.627D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.pnlAverage.Name = "pnlAverage";
            this.pnlAverage.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(12.381D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.pnlAverage.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pnlAverage.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pnlAverage.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.pnlAverage.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // pnlMaximum
            // 
            this.pnlMaximum.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.627D), Telerik.Reporting.Drawing.Unit.Cm(1.208D));
            this.pnlMaximum.Name = "pnlMaximum";
            this.pnlMaximum.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(12.381D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.pnlMaximum.Style.BackgroundColor = System.Drawing.Color.DarkKhaki;
            this.pnlMaximum.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pnlMaximum.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pnlMaximum.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.pnlMaximum.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // rptFaExerciseResult
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeader,
            this.detail,
            this.reportFooterSection1});
            this.Name = "rptFaExerciseResult";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Cm(1D), Telerik.Reporting.Drawing.Unit.Cm(1D), Telerik.Reporting.Drawing.Unit.Cm(1D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Mm;
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(27.7D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeader;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.PictureBox pictureBox2;
        private Telerik.Reporting.TextBox textBox30;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox txtTotalMark;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.Panel pnlHeader;
        private Telerik.Reporting.Panel pnlItems;
        private ReportFooterSection reportFooterSection1;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.Panel pnlMaximum;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.Panel pnlAverage;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.Panel pnlMinimum;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox txtDate;
    }
}