namespace Fakher.Reports.Exam_Reports
{
    partial class rptFaExamHoldingSeatLabel
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.txtExam = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            //this.detail.ColumnCount = 4;
            this.PageSettings.ColumnCount = 4;
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(2.39989972114563, Telerik.Reporting.Drawing.UnitType.Cm);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.txtExam,
            this.textBox2,
            this.textBox3});
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Dashed;
            this.detail.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Dashed;
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.20000001788139343, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.067708365619182587, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(5.7999997138977051, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000008344650269, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Name = "B Titr";
            this.textBox1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "موسسه آموزش عالی آزاد فاخـــر";
            // 
            // txtExam
            // 
            this.txtExam.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.20000001788139343, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.6679081916809082, Telerik.Reporting.Drawing.UnitType.Cm));
            this.txtExam.Name = "txtExam";
            this.txtExam.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(5.7999997138977051, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000008344650269, Telerik.Reporting.Drawing.UnitType.Cm));
            this.txtExam.Style.Font.Bold = true;
            this.txtExam.Style.Font.Name = "B Traffic";
            this.txtExam.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(11, Telerik.Reporting.Drawing.UnitType.Point);
            this.txtExam.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txtExam.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtExam.Value = "=Fields.ExamForm.Exam.Name + \' - کلاس \' + Fields.Formation.Place.Name";
            // 
            // textBox2
            // 
            this.textBox2.Anchoring = Telerik.Reporting.AnchoringStyles.Bottom;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.20000043511390686, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(1.6699999570846558, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(5.7999997138977051, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.64999997615814209, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox2.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Name = "B Titr";
            this.textBox2.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(25, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.TextWrap = false;
            this.textBox2.Value = "=Fields.SeatNumber";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.20000003278255463, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(1.2681081295013428, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(5.7999997138977051, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.37500011920928955, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox3.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Name = "B Traffic";
            this.textBox3.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(11, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.TextWrap = false;
            this.textBox3.Value = "=Fields.Register.Student.FarsiFullname + \' / \' + Fields.Register.Student.FarsiFat" +
                "herName";
            // 
            // group1
            // 
            this.group1.GroupFooter = this.groupFooterSection1;
            this.group1.GroupHeader = this.groupHeaderSection1;
            this.group1.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("=Fields.Formation.Place")});
            this.group1.Name = "group1";
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = new Telerik.Reporting.Drawing.Unit(0.19989916682243347, Telerik.Reporting.Drawing.UnitType.Cm);
            this.groupFooterSection1.Name = "groupFooterSection1";
            this.groupFooterSection1.Style.Visible = false;
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = new Telerik.Reporting.Drawing.Unit(0.13229161500930786, Telerik.Reporting.Drawing.UnitType.Cm);
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            this.groupHeaderSection1.PageBreak = Telerik.Reporting.PageBreak.Before;
            this.groupHeaderSection1.Style.Visible = false;
            // 
            // rptFaExamHoldingSeatLabel
            // 
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.detail});
            this.Name = "rptFaExamSeatLabel";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins.Bottom = new Telerik.Reporting.Drawing.Unit(10, Telerik.Reporting.Drawing.UnitType.Mm);
            this.PageSettings.Margins.Left = new Telerik.Reporting.Drawing.Unit(25, Telerik.Reporting.Drawing.UnitType.Mm);
            this.PageSettings.Margins.Right = new Telerik.Reporting.Drawing.Unit(25, Telerik.Reporting.Drawing.UnitType.Mm);
            this.PageSettings.Margins.Top = new Telerik.Reporting.Drawing.Unit(10, Telerik.Reporting.Drawing.UnitType.Mm);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Sortings.AddRange(new Telerik.Reporting.Sorting[] {
            new Telerik.Reporting.Sorting("=Fields.SeatNumber", Telerik.Reporting.SortDirection.Asc)});
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = new Telerik.Reporting.Drawing.Unit(6.1750006675720215, Telerik.Reporting.Drawing.UnitType.Cm);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.Group group1;
        private Telerik.Reporting.GroupFooterSection groupFooterSection1;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection1;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox txtExam;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
    }
}