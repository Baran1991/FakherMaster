namespace Fakher.Reports
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class rptFaAnswersheetHeader
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.panel1 = new Telerik.Reporting.Panel();
            this.barcode1 = new Telerik.Reporting.Barcode();
            this.panel2 = new Telerik.Reporting.Panel();
            this.textBox30 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = new Telerik.Reporting.Drawing.Unit(0.99999988079071045, Telerik.Reporting.Drawing.UnitType.Cm);
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Style.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.barcode1});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.99999988079071045, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.2503010630607605, Telerik.Reporting.Drawing.UnitType.Cm));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.4999995231628418, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(2.6997992992401123, Telerik.Reporting.Drawing.UnitType.Cm));
            this.panel1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // barcode1
            // 
            this.barcode1.Checksum = false;
            this.barcode1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.30000025033950806, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.24969910085201263, Telerik.Reporting.Drawing.UnitType.Cm));
            this.barcode1.Name = "barcode1";
            this.barcode1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(5.8999996185302734, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(2.0999996662139893, Telerik.Reporting.Drawing.UnitType.Cm));
            this.barcode1.Stretch = true;
            this.barcode1.Style.Font.Bold = true;
            this.barcode1.Style.Font.Name = "B Titr";
            this.barcode1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(14, Telerik.Reporting.Drawing.UnitType.Point);
            this.barcode1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.barcode1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.barcode1.Symbology = Telerik.Reporting.Barcode.SymbologyType.Code39;
            this.barcode1.Value = "=Fields.Code";
            // 
            // panel2
            // 
            this.panel2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox30,
            this.textBox10,
            this.textBox2,
            this.textBox3,
            this.pictureBox1,
            this.textBox1});
            this.panel2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(8.3000001907348633, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Cm));
            this.panel2.Name = "panel2";
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(10, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(2.8999998569488525, Telerik.Reporting.Drawing.UnitType.Cm));
            this.panel2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // textBox30
            // 
            this.textBox30.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(28.861154556274414, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Mm));
            this.textBox30.Name = "textBox22";
            this.textBox30.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(42.277687072753906, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(6.49899435043335, Telerik.Reporting.Drawing.UnitType.Mm));
            this.textBox30.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox30.Style.Color = System.Drawing.Color.Black;
            this.textBox30.Style.Font.Bold = true;
            this.textBox30.Style.Font.Name = "B Titr";
            this.textBox30.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(14, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox30.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox30.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox30.Value = "فاخــــــــــر";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(28.861150741577148, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(5.9979987144470215, Telerik.Reporting.Drawing.UnitType.Mm));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(42.277694702148438, Telerik.Reporting.Drawing.UnitType.Mm), new Telerik.Reporting.Drawing.Unit(3.9999959468841553, Telerik.Reporting.Drawing.UnitType.Mm));
            this.textBox10.Style.Font.Name = "B Nazanin";
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox10.Value = "موسسه آموزش عالی آزاد";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.00010052680590888485, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(1.0000004768371582, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox2.Name = "textBox1";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(8.0996990203857422, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.40000000596046448, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Name = "B Traffic";
            this.textBox2.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.TextWrap = false;
            this.textBox2.Value = "=Fields.Register.Student.FarsiFullname + \' / \' + Fields.Register.Student.FarsiFat" +
                "herName + \' / \' + Fields.ExamForm.Exam.Lesson.Major.Name";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.00010012308484874666, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(1.7999999523162842, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox3.Name = "textBox1";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(8.0996990203857422, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.40000000596046448, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Name = "B Nazanin";
            this.textBox3.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(11, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.TextWrap = false;
            this.textBox3.Value = "=\'فرم آزمون: \' + Fields.ExamForm.Name + \'        \' + \'شماره صندلی: \' + Fields.Sea" +
                "tNumber";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(8.09999942779541, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.30000025033950806, Telerik.Reporting.Drawing.UnitType.Cm));
            this.pictureBox1.MimeType = "";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.8999000787734985, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(2.1999998092651367, Telerik.Reporting.Drawing.UnitType.Cm));
            this.pictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox1.Value = "=Fields.Register.Student.Photo.Picture";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.00010012308484874666, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(1.4000000953674316, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(8.0996990203857422, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.40000000596046448, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox1.Style.Font.Bold = false;
            this.textBox1.Style.Font.Name = "B Traffic";
            this.textBox1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.TextWrap = false;
            this.textBox1.Value = "=Fields.ExamForm.Exam.Name";
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(4.1999993324279785, Telerik.Reporting.Drawing.UnitType.Cm);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1,
            this.panel2});
            this.detail.Name = "detail";
            this.detail.PageBreak = Telerik.Reporting.PageBreak.After;
            this.detail.Style.Visible = true;
            // 
            // rptFaAnswersheetHeader
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeader,
            this.detail});
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Cm);
            this.PageSettings.Margins.Left = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Cm);
            this.PageSettings.Margins.Right = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Cm);
            this.PageSettings.Margins.Top = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Cm);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = new Telerik.Reporting.Drawing.Unit(19, Telerik.Reporting.Drawing.UnitType.Cm);
            this.Name = "rptFaAnswersheetHeader";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeader;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.Panel panel1;
        private Barcode barcode1;
        private Telerik.Reporting.Panel panel2;
        private Telerik.Reporting.TextBox textBox30;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.PictureBox pictureBox1;
    }
}