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
using Fakher.UI.Financial;
using rComponents;

namespace Fakher.UI
{
    public partial class frmBankAccountList : rRadForm
    {
        public frmBankAccountList()
        {
            InitializeComponent();
            rGridView1.CustomButtons.Add(new rGridViewButton { Text = "تراکنش ها", VisibleOnSelect = true, Position = rGridViewButtonPosition.After });
            rGridView1.CustomButtonClick += RGridView1_CustomButtonClick;
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام بانک", ObjectProperty = "BankName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شعبه", ObjectProperty = "Branch" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره حساب", ObjectProperty = "AccountNumber" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "دستگاه POS", ObjectProperty = "HasPOSText" });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "از شماره", ObjectProperty = "StartNumber" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تا شماره", ObjectProperty = "EndNumber" });

            List<BankAccount> bankAccounts = DbContext.GetAllEntities<BankAccount>();
            rGridView1.DataBind(bankAccounts);
            if (bankAccounts.Count > 0)
                FillGrid2(bankAccounts[0]);
        }

        private void RGridView1_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            BankAccount bankAccount = rGridView1.GetSelectedObject<BankAccount>();
            frmBankTransactionList frm = new frmBankTransactionList(bankAccount);
            frm.ShowDialog();
        }

        private void rGridView1_SelectedItemChanged(object sender, EventArgs e)
        {
            BankAccount bankAccount = rGridView1.GetSelectedObject<BankAccount>();
            if(bankAccount != null)
                FillGrid2(bankAccount);
        }

        private void FillGrid2(BankAccount bankAccount)
        {
            IQueryable<ChequeBook> chequeBooks = bankAccount.GetChequeBooks();
            rGridView2.DataBind(chequeBooks);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            BankAccount bankAccount = new BankAccount();
            frmBankAccountDetail frm = new frmBankAccountDetail(bankAccount);
            if (!frm.ProcessObject())
                return;

            bankAccount.Save();
            rGridView1.Insert(bankAccount);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            BankAccount bankAccount = rGridView1.GetSelectedObject<BankAccount>();
            frmBankAccountDetail frm = new frmBankAccountDetail(bankAccount);
            if (!frm.ProcessObject())
                return;

            bankAccount.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            BankAccount bankAccount = rGridView1.GetSelectedObject<BankAccount>();
            bankAccount.Delete();

            rGridView1.RemoveSelectedRow();
        }

        private void rGridView2_Add(object sender, EventArgs e)
        {
            BankAccount bankAccount = rGridView1.GetSelectedObject<BankAccount>();
            ChequeBook chequeBook = new ChequeBook() {BankAccount = bankAccount};
            frmChequeBookDetail frm = new frmChequeBookDetail(chequeBook);
            if (!frm.ProcessObject())
                return;

            chequeBook.Save();
            rGridView2.Insert(chequeBook);
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            ChequeBook chequeBook = rGridView2.GetSelectedObject<ChequeBook>();
            frmChequeBookDetail frm = new frmChequeBookDetail(chequeBook);
            if (!frm.ProcessObject())
                return;

            chequeBook.Save();
            rGridView2.UpdateGridView();
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            ChequeBook chequeBook = rGridView2.GetSelectedObject<ChequeBook>();
            chequeBook.Delete();

            rGridView2.RemoveSelectedRow();
        }
      
        }
}
