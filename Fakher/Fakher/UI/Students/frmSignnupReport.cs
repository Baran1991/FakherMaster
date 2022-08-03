using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using Fakher.UI;
using Fakher.UI.Reception;
using Telerik.WinControls.UI;

namespace Fakher.UI.Persons
{
    public partial class frmSignnupReport : rRadForm
    {
        Student selectedStudent { get; set; }
        public frmSignnupReport()
        {
            InitializeComponent();
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "*" ,ObjectProperty = "" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام و نام خانوادگی", ObjectProperty = "Student" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Code" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شماره تلفن", ObjectProperty = "Student.ContactInfo.Mobile" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Major.Name" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "دوره ", ObjectProperty = "Period.Name" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام کاربر ثبت نام کننده", ObjectProperty = "Registrar" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت نام", ObjectProperty = "RegisterDate" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت نام", ObjectProperty = "EnrollmentTypeText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FarsiFinancialStatusVerboseText"});
            rGridView2.Mappings.Add(new ColumnMapping { Caption = " مبلغ", ObjectProperty = "TestAmount",Type=ColumnType.GroupedNumber, AggregateSummary = AggregateSummary.Sum });

            rGridView2.CustomButtons.Add(new rGridViewButton { Text = "پنل دانشجو", VisibleOnSelect = true, Position = rGridViewButtonPosition.Before });
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersianDate date1 = rDatePicker1.Date;
            PersianDate date2 = rDatePicker2.Date;
            if (date1 == null | date2 == null)
            {
                rMessageBox.ShowError("تاریخ را وارد کنید.");
                return;
            }
            var list = DbContext.Entity<Register>().Where(m => m.RegisterDate <= date2 && m.RegisterDate >= date1);
            rGridView2.DataBind(list);            
        }


        private void button2_Click(object sender, EventArgs e)
        {         
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;
            pd.Document = doc;
            doc.DefaultPageSettings.Landscape = true;
            //printPrvDlg.Document = doc;
            //printPrvDlg.ShowDialog();
            pd.PrinterSettings.DefaultPageSettings.Landscape = true;
            if (pd.ShowDialog() == DialogResult.OK)
                doc.Print();
        }
        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Print image
            //this.rGridView2.Height=rGridView2.ScrollControlIntoView.Height
                
            Bitmap bm = new Bitmap(this.rGridView2.Width, this.rGridView2.Height);
            this.AutoScroll = true;
            rGridView2.DrawToBitmap(bm, new Rectangle(0, 0, rGridView2.Width, rGridView2.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
        }
        //private void rGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    selectedStudent = rGridView2.GetSelectedObject<Student>();
        //    ShowDialogForm(new frmReceptionPanel(selectedStudent) { AutoCloseUnitOfWork = false });
        //}

        private void rGridView2_CustomButtonClick(object sender, EventArgs e)
        {
            try
            {
                List<Register> registers = rGridView2.GetCheckedObjects<Register>();
                if (rGridView2.GetCheckedObjects<object>().Count == 0)
                {
                    rMessageBox.ShowWarning("یک دانشجو را انتخاب نمایید.");
                }
                selectedStudent = registers[0].Student;
                frmReceptionPanel frm = new frmReceptionPanel(selectedStudent);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
