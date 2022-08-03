using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Receipt : Payment
    {
        public virtual string ReceiptNumber { get; set; }
        //        [Obsolete]
        //        public virtual string BankName { get; set; }
        public virtual PersianDate SendingtoBankDate { get; set; }
        public virtual Employee employee { get; set; }
        public virtual ReceiptStatus Status { get; set; }
        public virtual BankAccount SendingtoBankName { get; set; }

        public Receipt()
        {
            Item = new FinancialItem(FinancialType.Credit) { Payment = this };
//            Item = new FinancialItem { Type = FinancialType.Credit };
        }
        [NonPersistent]
        public virtual string StatusText
        {
            get
            {
                return Status.ToDescription();
            }
        }

        [NonPersistent]
        public override string Description
        {
            get { return string.Format("واریز به حساب بانک {0} طی فیش شماره {1}", Item.BankAccount, ReceiptNumber); }
        }

//        public virtual string BankName
//        {
//            get
//            {
//                if(!string.IsNullOrEmpty())
//                return Item.BankAccount + "";
//            }
//        }

        public override Payment Clone()
        {
            Receipt receipt = Services.Clone(this);
            receipt.Date = Date;
            return receipt;
        }
        public static IList<Receipt> GetSendingTobankReceipt(ReceiptStatus status)
        {
            List<Receipt> result = new List<Receipt>();
            var query = from c in DbContext.Entity<Receipt>()
                        where c.Status == status
                        orderby c.SendingtoBankDate descending
                        select c;
            result.UniqueAddRange(query.ToList());
            return result;
        }

        public static IList<Receipt> Search(string receiptNumber)
        {
            IList<Receipt> receipts = FromNumber(receiptNumber);
            var query = from receipt in receipts
                        where receipt.Item != null
                              && receipt.Item.Document != null
                              && receipt.Item.Document.Person != null
                        select receipt;
            return query.ToList();
        }

        public static IList<Receipt> FromNumber(string receiptNumber)
        {
            var query = from receipt in DbContext.Entity<Receipt>()
                        where receipt.ReceiptNumber == receiptNumber
                        && receipt.Items.Count > 0
                        select receipt;
            return query.ToList();
        }
        public static IQueryable<Receipt> GetReceipt(IQueryable<Receipt> receipts, ReceiptStatus status)
        {
            var query = from receipt in receipts
                        where receipt.Status == status
                        select receipt;
            return query;
        }

        public static IQueryable<Receipt> GetReceipts(PersianDate startDate, PersianDate endDate)
        {
            List<FinancialItem> items = FinancialItem.GetFinancialItem(startDate, endDate).ToList();

            var receiptsQuery = from item in items
                               where item.Is<Receipt>()
                               select item.Payment as Receipt;

            var query = from receipt in receiptsQuery
                        where receipt.Item != null
                        && receipt.Item.Document != null
                        && receipt.Item.Document.Person != null
                        && receipt.Item.Date >= startDate
                        && receipt.Item.Date <= endDate
                        select receipt;

            return query.AsQueryable();
        }

    }

    public enum ReceiptStatus
    {
        [EnumDescription("درج شده")]
        Inserted,
        [EnumDescription("ارسال به بانک")]
        SentToBank,
        [EnumDescription("تایید شده")]
        Confirmed,
        [EnumDescription("رد شده")]
        Rejected,
    }
}