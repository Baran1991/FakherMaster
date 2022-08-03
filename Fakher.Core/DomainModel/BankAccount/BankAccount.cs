using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class BankAccount : DbObject
    {
        public virtual string BankName { get; set; }
        public virtual string Branch { get; set; }
        public virtual string AccountNumber { get; set; }
        public virtual long InitialBalance { get; set; }
        public virtual bool HasPOS { get; set; }

        [NonPersistent]
        public virtual string HasPOSText
        {
            get { return HasPOS ? "دارد" : "ندارد"; }
        }

        public virtual IQueryable<ChequeBook> GetChequeBooks()
        {
            var query = from chequeBook in DbContext.Entity<ChequeBook>()
                        where chequeBook.BankAccount.Id == Id
                        select chequeBook;
            return query;
        }

        public override string ToString()
        {
            return BankName + " شعبه " + Branch;
        }

        public static IQueryable<BankAccount> GetPOSAccounts()
        {
            var query = from account in DbContext.GetAll<BankAccount>()
                        where account.HasPOS
                        select account;
            return query;
        }
        public static IQueryable<BankAccount> GetBankName()
        {
            var query = from bankAccount in DbContext.Entity<BankAccount>()                      
                        select bankAccount;
            return query;
        }

        public virtual IQueryable<FinancialItem> GetFinancialItems(FinancialItemMode mode)
        {
            var query = from item in DbContext.Entity<FinancialItem>()
                        where item.Mode == mode
                              && item.BankAccount.Id == Id
                        select item;
            return query;
        }
        public virtual IQueryable<FinancialItem> GetFinancialItems(FinancialItemMode mode,PersianDate date1,PersianDate date2)
        {
            var query = from item in DbContext.Entity<FinancialItem>()
                        join registerer in DbContext.Entity <Register>() on item.Document equals registerer.FinancialDocument 
                        where item.Mode == mode
                              && item.BankAccount.Id == Id && item.Date<=date2 && item.Date>=date1
                              
                        select new FinancialItem() { registerer=registerer,Id=item.Id,Amount= item.Amount,Date=item.Date,Payment=item.Payment,Type=item.Type};
            return query;
        }
    }
}
