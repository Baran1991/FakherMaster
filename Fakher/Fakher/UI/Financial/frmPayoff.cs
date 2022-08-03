using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Buffet;
using Fakher.Core.Sentinel;
using Fakher.Reports;
using Fakher.UI.Report;
using rComponents;

namespace Fakher.UI.Financial
{
    public partial class frmPayoff : rRadDetailForm
    {
        private long payoffAmount = 0;
        public frmPayoff()
        {
            InitializeComponent();
            rLabel7.ForeColor = Color.Red;
            rLblPayoffAmount.ForeColor = Color.Red;
            rTextBox1.Enabled = false;
            rGridComboBox1.Columns.Add("نام", "نام", "FarsiFullname");
            rGridComboBox1.DataSource = Employee.GetActiveEmployees();

            FillGridColumns(true);

            //            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date.ToShortDateString()" });
            //            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "DescriptionText"});
            //            rGridView1.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Document.Person.FarsiFullname" });
            //            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Balance", AggregateSummary = AggregateSummary.Sum, Type = ColumnType.GroupedNumber, TextAlign = HorizontalAlignment.Left});

            rDatePicker1.Date = PersianDate.Today;
        }

        private void FillGridColumns(bool showPersonName)
        {
            rGridView1.Mappings.Clear();
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date.ToShortDateString()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "DescriptionText" });
            if (showPersonName)
                rGridView1.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Document.Person.FarsiFullname" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Balance", AggregateSummary = AggregateSummary.Sum, Type = ColumnType.GroupedNumber, TextAlign = HorizontalAlignment.Left });
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear();

            Employee employee = rGridComboBox1.GetValue<Employee>();
            PersianDate date = rDatePicker1.Date;
            if (date == null)
            {
                rMessageBox.ShowError("تاریخ را وارد کنید.");
                return;
            }
            try
            {
                Fill(employee, date);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);

            }
        }

        private  void rBtnPayoff_Click(object sender, EventArgs e)
        {
            Employee employee = rGridComboBox1.GetValue<Employee>();
            PersianDate date = rDatePicker1.Date;
            int amount = rTextBox1.GetValue<int>();
            if (amount == 0)
            {
                rMessageBox.ShowError("مبلغ نامعتبر است.");
                return;

            }
            long financialBalance =  employee.GetFinancialBalance();

            if (date == null)
            {
                rMessageBox.ShowError("تاریخ را وارد کنید.");
                return;
            }

            if (amount <= 0)
            {
                if (rMessageBox.ShowQuestion("مبلغ تسویه حساب منفی است. آیا مطمئن هستید؟") != DialogResult.Yes)
                    return;
                //                rMessageBox.ShowError("مبلغ تسویه حساب نمی تواند منفی یا صفر باشد.");
                //                return;
            }

            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.EmployeePayOff);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }

            if (financialBalance + amount > 0)
                if (rMessageBox.ShowQuestion("با اعمال این مبلغ، مانده این شخص مثبت خواهد شد. آیا مطمئن هستید؟") !=
                    DialogResult.Yes)
                    return;

            FinancialItem item = new FinancialItem(FinancialType.Credit)
            {
                Amount = amount,
                Text =
                                             string.Format("تسویه حساب تراکنش های روزانه تا تاریخ {0} توسط {1}",
                                                           date.ToShortDateString(),
                                                           Program.CurrentEmployee.FarsiFullname),
                Date = date,
                Heading = FinancialHeading.EmployeePayOff,
                Person = employee
            };
            employee.RegisterDailyItem(item);

            financialBalance =  employee.GetFinancialBalance();
            rMessageBox.ShowInformation(string.Format("تسویه حساب انجام شد. مانده فعلی [{0}] مبلغ [{1}] می باشد.",
                                                      employee.FarsiFullname, financialBalance.ToString("C")));

            try
            {
                Fill(employee, date);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);

            }
        }

        private void rGridComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear();
            if (rGridComboBox1.Value == null)
                return;
        }

        private void Clear()
        {
            rGridView1.Clear();
            rTextBox1.Text = "0";
        }

        private async void Fill(Employee employee, PersianDate date)
        {

            Clear();
            FillGridColumns(!(employee is BuffetSeller));

            rGroupBox1.Text = "لیست تراکنش های " + date.ToShortDateString();
            this.Enabled = false;


            IList<FinancialItem> items =
                employee.GetInsertedFinancialItems(date, date).Where(x => x.Type == FinancialType.Credit).Where(
                    x => x.IsPaying && !x.IsClone).ToList();
            IEnumerable<FinancialItem> payoffFinancialItems = employee.GetDailyFinancialItems(date, date, FinancialHeading.EmployeePayOff);
            var cashAmount = items.Where(x => x.Is<Cash>() || x.Is<Receipt>()).Sum(x => x.Amount);
            rLblCash.Text = cashAmount.ToString("C0");
            var ePayAmount = items.Where(x => x.Is<ElectronicPayment>()).Sum(x => x.Amount);
            rLblEPay.Text = ePayAmount.ToString("C0");
            var chequeAmount = items.Where(x => x.Is<Cheque>()).Sum(x => x.Amount);
            rLblCheque.Text = chequeAmount.ToString("C0");
            var amount = payoffFinancialItems.Sum(x => x.Amount);
            rLblPayoffAmount.Text = amount.ToString("C0");
            payoffAmount = amount;
            if (amount == 0)
                rTextBox1.Text = (cashAmount + ePayAmount + chequeAmount).ToString();
            if (items.Count == 0)
            {
                rMessageBox.ShowInformation(string.Format("این شخص در تاریخ [{0}] تراکنشی نداشته است.", date));
                this.Enabled = true;
                return;
            }

            rGridView1.DataBind(items);
            var txtBalance = ( employee.GetFinancialBalance()).ToString("C0");
            rLblBalance.Text = txtBalance;
            this.Enabled = true;

        }

        private void lnkFinancialReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Employee employee = rGridComboBox1.GetValue<Employee>();
            PersianDate date = rDatePicker1.Date;
            rptFaEmployeeFinancialReport rpt = new rptFaEmployeeFinancialReport();
            rpt.Employee = employee;
            rpt.Date = date;
            rpt.PrepareDataset(null);
            rpt.Apply(null);
            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog(this);
        }

        private void linkDayNotPaid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Employee employee = rGridComboBox1.GetValue<Employee>();
            frmDailyNotPayoff frm = new frmDailyNotPayoff(employee);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            var selectedDate = frm.GetSelectedObject<FinancialItem>().Date;
            //rMessageBox.ShowInformation(selectedDate.ToShortDateString());
            rDatePicker1.Text = selectedDate.ToShortDateString();
            linkLabel1_LinkClicked(sender, e);
        }

        private void linkDayNotPaid_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Employee employee = rGridComboBox1.GetValue<Employee>();
            frmEmployeeTotalFinancials frm = new frmEmployeeTotalFinancials(employee);
            frm.ShowDialog();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Employee employee = rGridComboBox1.GetValue<Employee>();
            PersianDate date = rDatePicker1.Date;
            
            long amount =payoffAmount;
            if (amount== 0)
            {
                rMessageBox.ShowError("تسویه حساب انجام نشده است.");
                return;

            }
            if (date == null)
            {
                rMessageBox.ShowError("تاریخ را وارد کنید.");
                return;
            }
            rptFaEmployeeFinancialPayOffReport rpt = new rptFaEmployeeFinancialPayOffReport();
            rpt.Employee = employee;
            rpt.Date = date;
            rpt.Amount = amount;
            rpt.PrepareDataset(null);
            rpt.Apply(null);
            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog(this);
        }
    }
}