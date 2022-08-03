using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Core.Sentinel;
using rComponents;

namespace Fakher.UI.Financial
{
    public partial class frmBankTransactionList : rRadForm
    {
        private BankAccount bAccount;
        public frmBankTransactionList(BankAccount account)
        {
            InitializeComponent();
            bAccount = account;
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "DescriptionText" });
           
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Amount", AggregateSummary = AggregateSummary.Sum, Type = ColumnType.GroupedNumber, TextAlign = HorizontalAlignment.Left });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "دانشجو", ObjectProperty = "registerer.Student.FarsiFullname" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
        
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
            rGridView1.DataBind(bAccount.GetFinancialItems(FinancialItemMode.Enterance,date1,date2));
           
            rGroupBox1.HeaderText = "لیست تراکنش های " + bAccount.BankName;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            FinancialItem item=rGridView1.GetSelectedObject<FinancialItem>();
            if(item.Payment is Cheque)
            {
                try
                {
                    Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.ChequeChangeStatus);
                    Cheque cheque = item.Payment as Cheque;
                    frmChequeDetail frm = new frmChequeDetail(cheque);
                    if (!frm.ProcessObject())
                        return;
                    cheque.Save();
                    rGridView1.UpdateGridView();
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }
            }
            else if(item.Payment is Receipt)
            {
                try
                {
                    Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.RecieptChangeStatus);
                    Receipt receipt = item.Payment as Receipt;
                    frmReceiptDetail frm = new frmReceiptDetail(receipt);
                    if (!frm.ProcessObject())
                        return;
                    receipt.Save();
                    rGridView1.UpdateGridView();
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }
            }
            else if(item.Payment is ElectronicPayment)
            {
                try
                {
                    Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.RecieptChangeStatus);
                    ElectronicPayment receipt = item.Payment as ElectronicPayment;
                    frmElectronicPaymentDetail frm = new frmElectronicPaymentDetail(receipt);
                    if (!frm.ProcessObject())
                        return;
                    receipt.Save();
                    rGridView1.UpdateGridView();
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }
            }
            else if (item.Payment is Cash)
            {
                try
                {
                    Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.RecieptChangeStatus);
                    Cash receipt = item.Payment as Cash;
                    frmCashDetail frm = new frmCashDetail(receipt);
                    if (!frm.ProcessObject())
                        return;
                    receipt.Save();
                    rGridView1.UpdateGridView();
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }
            }
            else 
            {
                rMessageBox.ShowInformation("تراکنش مورد نظر، قابل ویرایش نمی باشد!");
            }
        }
    }
}
