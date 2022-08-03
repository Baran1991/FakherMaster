using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class FinancialDocument : DbObject
    {
        public FinancialDocument()
        {
            DocumentDate = PersianDate.Today;
            Items = new List<FinancialItem>();
        }

        public virtual string Description { get; set; }
        public virtual IList<FinancialItem> Items { get; set; }
        public virtual PersianDate DocumentDate { get; set; }
        [NoCascade]
        public virtual Person Person { get; set; }

        #region Properties

        [NonPersistent]
        public virtual IQueryable<FinancialItem> CashItems
        {
            get
            {
                var query = from item in Items
                            where item.IsPaying && item.Is<Cash>()
                            select item;
                return query.AsQueryable();
            }
        }

        [NonPersistent]
        public virtual long CashBalance
        {
            get
            {
                return CashItems.Sum(x => x.Balance);
            }
        }

        [NonPersistent]
        public virtual IQueryable<FinancialItem> ReceiptItems
        {
            get
            {
                var query = from item in Items
                            where item.IsPaying && item.Is<Receipt>()
                            select item;
                return query.AsQueryable();
            }
        }

        [NonPersistent]
        public virtual long ReceiptBalance
        {
            get
            {
                return ReceiptItems.Sum(x => x.Balance);
            }
        }

        [NonPersistent]
        public virtual IQueryable<FinancialItem> EPaymentItems
        {
            get
            {
                var query = from item in Items
                            where item.IsPaying && item.Is<ElectronicPayment>()
                            select item;
                return query.AsQueryable();
            }
        }

        [NonPersistent]
        public virtual long EPaymentBalance
        {
            get
            {
                return EPaymentItems.Sum(x => x.Balance);
            }
        }

        [NonPersistent]
        public virtual IQueryable<FinancialItem> ChequeItems
        {
            get
            {
                var query = from item in Items
                            where item.IsPaying && item.Is<Cheque>()
                            && (item.Payment as Cheque).Status != ChequeStatus.Canceled
                            select item;
                return query.AsQueryable();
            }
        }

        [NonPersistent]
        public virtual long ChequeBalance
        {
            get
            {
                return ChequeItems.Sum(x => x.Balance);
            }
        }

        [NonPersistent]
        public virtual IQueryable<FinancialItem> PassedChequeItems
        {
            get
            {
                var query = from item in ChequeItems
                            where (item.Payment as Cheque).Status == ChequeStatus.Passed
                            select item;
                return query.AsQueryable();
            }
        }

        [NonPersistent]
        public virtual long PassedChequeBalance
        {
            get
            {
                return PassedChequeItems.Sum(x => x.Balance);
            }
        }

        [NonPersistent]
        public virtual IQueryable<FinancialItem> ReturnedChequeItems
        {
            get
            {
                var query = from item in ChequeItems
                            where (item.Payment as Cheque).Status == ChequeStatus.Returned
                            select item;
                return query.AsQueryable();
            }
        }

        [NonPersistent]
        public virtual long ReturnedChequeBalance
        {
            get
            {
                return ReturnedChequeItems.Sum(x => x.Balance);
            }
        }

        [NonPersistent]
        public virtual IQueryable<FinancialItem> InProgressChequeItems
        {
            get
            {
                var query = from item in ChequeItems
                            where (item.Payment as Cheque).Status == ChequeStatus.InProgress
                            select item;
                return query.AsQueryable();
            }
        }

        [NonPersistent]
        public virtual long InProgressChequeBalance
        {
            get
            {
                return InProgressChequeItems.Sum(x => x.Balance);
            }
        }

        [NonPersistent]
        public virtual IQueryable<PersianDate> InProgressChequeDates
        {
            get { return InProgressChequeItems.Select(x => x.Date); }
        }

        [NonPersistent]
        public virtual string InProgressChequeDatesText
        {
            get 
            {
                List<PersianDate> dates = InProgressChequeDates.ToList();
                string txt = "";
                foreach (PersianDate date in dates)
                {
                    txt += date.ToShortDateString();
                    if (dates.IndexOf(date) != dates.Count - 1)
                        txt += ", ";
                }
                return txt;
            }
        }

        [NonPersistent]
        public virtual IQueryable<FinancialItem> SuspendedChequeItems
        {
            get
            {
                var query = from item in ChequeItems
                            where (item.Payment as Cheque).Status == ChequeStatus.Suspended
                            select item;
                return query.AsQueryable();
            }
        }

        [NonPersistent]
        public virtual long SuspendedChequeBalance
        {
            get
            {
                return SuspendedChequeItems.Sum(x => x.Balance);
            }
        }

        [NonPersistent]
        public virtual IQueryable<FinancialItem> CanceledChequeItems
        {
            get
            {
                var query = from item in ChequeItems
                            where (item.Payment as Cheque).Status == ChequeStatus.Canceled
                            select item;
                return query.AsQueryable();
            }
        }

        [NonPersistent]
        public virtual IQueryable<FinancialItem> DebtChequeItems
        {
            get
            {
                return ReturnedChequeItems.Union(SuspendedChequeItems);
            }
        }

        [NonPersistent]
        public virtual long CanceledChequeBalance
        {
            get
            {
                return CanceledChequeItems.Sum(x => x.Balance);
            }
        }

        [NonPersistent]
        public virtual long ChequeDebtBalance
        {
            get
            {
                return DebtChequeItems.Sum(x => x.Balance);
//                return ReturnedChequeBalance + SuspendedChequeBalance;
            }
        }

        [NonPersistent]
        public virtual IQueryable<FinancialItem> DiscountItems
        {
            get
            {
                var query = from item in Items
                            where item.IsDiscount
                            select item;
                return query.AsQueryable();
            }
        }
        

        [NonPersistent]
        public virtual long DiscountBalance
        {
            get
            {
                return DiscountItems.Sum(x => x.Balance);
            }
        }

        [NonPersistent]
        public virtual string DiscountText
        {
            get
            {
                List<string> texts = DiscountItems.Select(x=>x.DescriptionText).ToList();
                string txt = "";
                foreach (string text in texts)
                    if(!string.IsNullOrEmpty(text))
                        txt += "[" + text.Trim() + "]";
                return txt;
            }
        }

      
       
        [NonPersistent]
        
        public virtual long Balance
        {
            get
            {
                long balance = 0;
                foreach (FinancialItem item in Items)
                    balance += item.Balance;
                return balance;
            }
        }

        [NonPersistent]
        public virtual IQueryable<FinancialItem> PaymentItems
        {
            get
            {
//                var query = from item in Items
//                            where item.IsPaying
//                            select item;
//                return query.ToList();
                return CashItems.Union(ReceiptItems).Union(EPaymentItems).Union(ChequeItems);
            }
        }

        [NonPersistent]
        public virtual long PayedBalance
        {
            get
            {
                long balance = 0;
                foreach (FinancialItem item in PaymentItems)
                    balance += item.Balance;
                return balance;
            }
        }

        #endregion

        #region Item Methods

        [NonPersistent]
        public virtual IQueryable<FinancialItem> GetCashItems(FinancialHeading heading)
        {
            var query = from item in GetItems(heading)
                        where item.IsPaying && item.Is<Cash>()
                        select item;
            return query.AsQueryable();
        }

        [NonPersistent]
        public virtual IQueryable<FinancialItem> GetReceiptItems(FinancialHeading heading)
        {
            var query = from item in GetItems(heading)
                        where item.IsPaying && item.Is<Receipt>()
                        select item;
            return query.AsQueryable();
        }

        [NonPersistent]
        public virtual IQueryable<FinancialItem> GetEPaymentItems(FinancialHeading heading)
        {
            var query = from item in GetItems(heading)
                        where item.IsPaying && item.Is<ElectronicPayment>()
                        select item;
            return query.AsQueryable();
        }

        [NonPersistent]
        public virtual IQueryable<FinancialItem> GetChequeItems(FinancialHeading heading)
        {
            var query = from item in GetItems(heading)
                        where item.IsPaying && item.Is<Cheque>()
                        && (item.Payment as Cheque).Status != ChequeStatus.Canceled
                        select item;
            return query.AsQueryable();
        }

        [NonPersistent]
        public virtual IQueryable<FinancialItem> GetDiscountItems(FinancialHeading heading)
        {
            var query = from item in GetItems(heading)
                        where item.IsDiscount
                        select item;
            return query.AsQueryable();
        }
        [NonPersistent]
        public virtual long GetDiscountBalance(FinancialHeading heading)
        {
            return GetDiscountItems(heading).Sum(x => x.Balance);
        }
        [NonPersistent]
        public virtual IQueryable<FinancialItem> GetPayedItems(FinancialHeading heading)
        {
            return GetCashItems(heading).Union(GetReceiptItems(heading)).Union(GetEPaymentItems(heading)).Union(GetChequeItems(heading));
        }

        [NonPersistent]
        public virtual long GetPayedBalance(FinancialHeading heading)
        {
            return GetPayedItems(heading).Sum(x => x.Balance);
        }

        [NonPersistent]
        public virtual IQueryable<FinancialItem> GetSuspendedChequeItems(FinancialHeading heading)
        {
            var query = from item in ChequeItems
                        where (item.Payment as Cheque).Status == ChequeStatus.Suspended
                        select item;
            return query.AsQueryable();
        }

        [NonPersistent]
        public virtual IQueryable<FinancialItem> GetReturnedChequeItems(FinancialHeading heading)
        {
            var query = from item in GetChequeItems(heading)
                        where (item.Payment as Cheque).Status == ChequeStatus.Returned
                        select item;
            return query.AsQueryable();
        }

        [NonPersistent]
        public virtual IQueryable<FinancialItem> GetDebtChequeItems(FinancialHeading heading)
        {
            return GetReturnedChequeItems(heading).Union(GetSuspendedChequeItems(heading));
        }

        [NonPersistent]
        public virtual long GetChequeDebtBalance(FinancialHeading heading)
        {
            return DebtChequeItems.Sum(x => x.Balance);
        }

        #endregion

        [NonPersistent]
        public virtual FinancialStatus FinancialStatus
        {
            get
            {
                if (Balance < 0)
                    return FinancialStatus.Debtor;
//                if (ChequeDebtBalance > 0)
//                    return FinancialStatus.Debtor;
//                if (HasInProgressCheque())
//                    return FinancialStatus.ChequePromised;
                if (Balance > 0)
                    return FinancialStatus.Creditor;
                return FinancialStatus.Balanced;
            }
        }

        [NonPersistent]
        public virtual string FarsiFinancialStatusText
        {
            get
            {
                return FinancialStatus.ToDescription();
            }
        }

        [NonPersistent]
        public virtual string EnglishFinancialStatusText
        {
            get
            {
                return FinancialStatus.ToString();
            }
        }

        [NonPersistent]
        public virtual string FarsiFinancialStatusVerboseText
        {
            get
            {
                if (FinancialStatus != FinancialStatus.Balanced)
                    return FarsiFinancialStatusText + " (" + Math.Abs(Balance).ToString("C0") + ") ";
                if (FinancialStatus == FinancialStatus.ChequePromised)
                    return FarsiFinancialStatusText + " (" + InProgressChequeDatesText + ") ";
                return FarsiFinancialStatusText;
            }
        }

        [NonPersistent]
        public virtual long DebtBalance
        {
            get
            {
                if (FinancialStatus == FinancialStatus.Debtor)
                    return Balance;
                return 0;
            }
        }

//        public virtual bool HasInProgressCheque()
//        {
//            var query = from FinancialItem chequeItem in GetPaymentItems<Cheque>()
//                        where (chequeItem.Payment as Cheque).Status == ChequeStatus.InProgress
//                        select chequeItem;
//            return query.Count() > 0;
//        }

//        public virtual IQueryable<FinancialItem> GetPaymentItems<T>() where T : Payment
//        {
//            var q = from item in PaymentItems
//                    where item.Payment is T
//                    select item;
//
//            return q.AsQueryable();
//        }

        public virtual IQueryable<FinancialItem> GetItems(PersianDate startDate, PersianDate endDate)
        {
            var query = from FinancialItem item in Items 
                        where item.Date >= startDate && item.Date <= endDate 
                        select item;
            return query.AsQueryable();
        }

        public virtual IQueryable<FinancialItem> GetItems(FinancialType type)
        {
            var query = from FinancialItem item in Items
                        where item.Type == type
                        select item;
            return query.AsQueryable();
        }        
        
        public virtual IQueryable<FinancialItem> GetItems(FinancialHeading heading)
        {
            var query = from FinancialItem item in Items
                        where item.Heading == heading 
                        select item;
            return query.AsQueryable();
        }

        public virtual void AddItem(FinancialItem financialItem)
        {
            financialItem.Document = this;
            Items.Add(financialItem);
        }

        public virtual void RemoveItems(FinancialHeading heading, FinancialType type)
        {
            for (int i = Items.Count - 1; i >= 0; i--)
            {
                FinancialItem item = Items[i];
                if (item.Heading == heading && item.Type == type)
                    Items.Remove(item);
            }
        }

        public virtual IList<PayTransaction> GetPayTransactions()
        {
            var query = from transactionItem in DbContext.Entity<PayTransactionItem>()
                        where transactionItem.FinancialDocument.Id == Id
                        select transactionItem.PayTransaction;
            return query.ToList();
        }
    }

    public enum FinancialStatus
    {
        [EnumDescription("بدهکار")]
        Debtor,
        [EnumDescription("متعهد چک")]
        ChequePromised,
        [EnumDescription("بستانکار")]
        Creditor,
        [EnumDescription("تسـویــه")]
        Balanced,
        [EnumDescription("برگشت چک")]
        ReturnedCheque
    }
}