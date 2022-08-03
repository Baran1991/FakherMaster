using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Financial
{
    public partial class frmFuturePaymentList : rRadForm
    {
        public frmFuturePaymentList()
        {
            InitializeComponent();

            rGridCmbBankAccounts.Columns.Add("بانک", "بانک", "BankName");
            rGridCmbBankAccounts.Columns.Add("شعبه", "شعبه", "Branch");

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "DescriptionText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "AmountText" });

            rGridCmbBankAccounts.DataSource = DbContext.GetAllEntities<BankAccount>();
        }

        private void rGridCmbBankAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            BankAccount bankAccount = rGridCmbBankAccounts.GetValue<BankAccount>();
            if(bankAccount == null)
                return;
            List<FinancialItem> items = bankAccount.GetFinancialItems(FinancialItemMode.Issued).ToList();
            rGridView1.DataBind(items);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            BankAccount bankAccount = rGridCmbBankAccounts.GetValue<BankAccount>();
            Cheque cheque= new Cheque();
            cheque.Item.Mode = FinancialItemMode.Issued;
            cheque.Item.BankAccount = bankAccount;

            frmIssuedChequeDetail frm = new frmIssuedChequeDetail(cheque);
            if (!frm.ProcessObject())
                return;

            cheque.Save();
            rGridView1.Insert(cheque.Item);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            BankAccount bankAccount = rGridCmbBankAccounts.GetValue<BankAccount>();
            Cheque cheque = rGridView1.GetSelectedObject<Cheque>();

            frmIssuedChequeDetail frm = new frmIssuedChequeDetail(cheque);
            if (!frm.ProcessObject())
                return;

            cheque.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            BankAccount bankAccount = rGridCmbBankAccounts.GetValue<BankAccount>();
            Cheque cheque = rGridView1.GetSelectedObject<Cheque>();

            cheque.Delete();
            rGridView1.RemoveSelectedRow();
        }
    }
}
