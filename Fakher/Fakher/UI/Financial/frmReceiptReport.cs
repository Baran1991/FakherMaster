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
    public partial class frmReceiptReport : rRadForm
    {
        Student selectedStudent { get; set; }
        public frmReceiptReport()
        {
            InitializeComponent();
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "*" ,ObjectProperty = "" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شماره قیش", ObjectProperty = "ReceiptNumber" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ سررسید", ObjectProperty = "Item.Date" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Item.Document.Person.FarsiFullname" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Item.Amount" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "بانک ", ObjectProperty = "BankName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تلفن ثابت", ObjectProperty = "Item.Document.Person.ContactInfo.Phone" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تلفن همراه", ObjectProperty = "Item.Document.Person.ContactInfo.Mobile" });
            //rGridView2.Mappings.Add(new ColumnMapping { Caption = "آدرس", ObjectProperty = "Item.Document.Person.ContactInfo.Address" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "بانک ارسالی", ObjectProperty = "SendingtoBankName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "همکار دریافت کننده", ObjectProperty = "employee" });


            //rGridView2.CustomButtons.Add(new rGridViewButton { Text = "پنل دانشجو", VisibleOnSelect = true, Position = rGridViewButtonPosition.Before });

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
            //var list = DbContext.Entity<Receipt>().Where(m => m.Item.Date<= date2 && m.Item.Date >= date1);

            List<Receipt> Receipts = Receipt.GetReceipts(date1, date2).ToList();
            rGridView2.DataBind(Receipts);            
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

        //private void rGridView2_CustomButtonClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        List<Register> registers = rGridView2.GetCheckedObjects<Register>();
        //        if (rGridView2.GetCheckedObjects<object>().Count == 0)
        //        {
        //            rMessageBox.ShowWarning("یک دانشجو را انتخاب نمایید.");
        //        }
        //        selectedStudent = registers[0].Student;
        //        frmReceptionPanel frm = new frmReceptionPanel(selectedStudent);
        //        frm.ShowDialog(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
            
        //}
    }
}
