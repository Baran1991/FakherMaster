using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Financial
{
    public partial class frmDailyNotPayoff : rRadForm
    {
        private Employee employee;
        public FinancialItem SelectedObject { get; set; }
        public frmDailyNotPayoff(Core.DomainModel.Employee person)
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Amount" });
            employee = person;
            rDatePicker1.Date = PersianDate.Today;
            rDatePicker2.Date = PersianDate.Today;
        }

        private void rBtnPayoff_Click(object sender, EventArgs e)
        {
            PersianDate date1 = rDatePicker1.Date;
            PersianDate date2 = rDatePicker2.Date;
            if (date1 == null | date2 == null)
            {
                rMessageBox.ShowError("تاریخ را وارد کنید.");
                return;
            }
            IList<FinancialItem> items =
                 employee.GetInsertedFinancialItems(date1, date2).Where(x => x.Type == FinancialType.Credit && x.IsPaying && !x.IsClone).ToList();
            IEnumerable<FinancialItem> payoffFinancialItems = employee.GetDailyFinancialItems(date1, date2, FinancialHeading.EmployeePayOff);
            var groupDate = items.Select(m => new { date = m.CreateDate.ToString() }).Distinct();
            List<FinancialItem> notPaidItems = new List<FinancialItem>();
            foreach (var item in groupDate)
            {
                if(payoffFinancialItems.FirstOrDefault(m=>m.Date.ToString()==item.date)==null)
                {
                   
                        var totalAmount = items.Where(x => x.CreateDate.ToString() == item.date & (x.Is<Cash>() || x.Is<Receipt>() || x.Is<ElectronicPayment>() || x.Is<Cheque>())).Sum(x => x.Amount);

                        notPaidItems.Add(new FinancialItem() { Date = item.date, Amount = totalAmount });
                   
                }
            }
            if(notPaidItems.Count==0)
                rMessageBox.ShowInformation("تاریخ تسویه نشده وجود ندارد.");
            else
            rGridView1.DataBind(notPaidItems);
            rGroupBox1.HeaderText = "تاریخ های تسویه نشده " + employee.FarsiFullname;
        }

        private void rGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectedObject = rGridView1.GetSelectedObject<FinancialItem>();
            Close();
        }
        public T GetSelectedObject<T>() where T : class
        {
            return rGridView1.GetSelectedObject<T>();
        }

        public List<T> GetSelectedObjects<T>() where T : class
        {
            return rGridView1.GetCheckedObjects<T>();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if ( !rGridView1.IsItemSelected)
            {
                rMessageBox.ShowWarning("یک آیتم از لیست را انتخاب کنید.");
                DialogResult = DialogResult.None;
                return;
            }
            SelectedObject = rGridView1.GetSelectedObject<FinancialItem>();
            //rMessageBox.ShowInformation(SelectedObject.Date.ToShortDateString());
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
