using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DataAccessLayer;
using rApplicationEventFramework;
using rComponents;

namespace Fakher.Core.DomainModel
{
    [EventClass("چک")]
    public class Cheque : Payment
    {
        [EventClassProperty("شماره چک", null)]
        public virtual string ChequeNumber { get; set; }
        [EventClassProperty("بانک چک", null)]
        public virtual string BankName { get; set; }
        [EventClassProperty("شعبه بانک چک", null)]
        public virtual string BankBranch { get; set; }
        public virtual ChequeStatus Status { get; set; }
        [NoCascade]
        public virtual ChequeBook ChequeBook { get; set; }
        public virtual string OrderOf { get; set; }
        public virtual string Payee { get; set; }
        public virtual PersianDate CreateDate { get; set; }
        public virtual PersianDate SendingtoBankDate { get; set; }
        public virtual BankAccount SendingtoBankName { get; set; }

        public virtual PersianDate ReturningDate { get; set; }

        public virtual Employee employee { get; set; }

        public Cheque()
        {
            Status = ChequeStatus.InProgress;
            Item = new FinancialItem { Type = FinancialType.Credit, Payment = this };
            CreateDate = PersianDate.Today;
            //            Item = new FinancialItem {Type = FinancialType.Credit };
        }

        [EventClassProperty("وضعیت چک", null)]
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
            get
            {
                if (Item.Mode == FinancialItemMode.Enterance)
                    return string.Format("چک {0} بانک {1} شعبه {2}، سررسید {3} ({4})", ChequeNumber, BankName, BankBranch, Date, Status.ToDescription());
                return string.Format("چک {0} حساب {1}، سررسید {2} بابت {3} در وجه {4}", ChequeNumber, Item.BankAccount, Date, OrderOf, Payee);
            }
        }

        public static IQueryable<Cheque> GetCheques(PersianDate startDate, PersianDate endDate)
        {
            List<FinancialItem> items = FinancialItem.GetFinancialItem(startDate, endDate).ToList();

            var chequesQuery = from item in items
                               where item.Is<Cheque>()
                               select item.Payment as Cheque;

            var query = from c in chequesQuery
                        where c.Item != null
                        && c.Item.Document != null
                        && c.Item.Document.Person != null
                        && c.Item.Date >= startDate
                        && c.Item.Date <= endDate
                        select c;

            return query.AsQueryable();
        }

        public static IQueryable<Cheque> GetCheques(IQueryable<Cheque> cheques, ChequeStatus status)
        {
            var query = from cheque in cheques
                        where cheque.Status == status
                        select cheque;
            return query;
        }
       
        public static IQueryable<Cheque> GetAllCheques(IQueryable<Cheque> cheques)
        {
            var query = from cheque in cheques
                        select cheque;
            return query;
        }
        public static IList<Cheque> GetSendingTobankCheques(ChequeStatus status)
        {
            var query = from c in DbContext.Entity<Cheque>()
                        where c.Status == status 
                        orderby c.SendingtoBankDate descending
                        select c;
            return query.ToList();
        }
        public static IList<Cheque> Search(string chequeNumber)
        {
            IList<Cheque> cheques = FromNumber(chequeNumber);
            var query = from cheque in cheques
                        where cheque.Item != null
                              && cheque.Item.Document != null
                              && cheque.Item.Document.Person != null
                        select cheque;
            return query.ToList();
        }
      
        public static IList<Cheque> FromNumber(string chequeNumber)
        {
            var query = from c in DbContext.Entity<Cheque>()
                        where c.ChequeNumber == chequeNumber
                              && c.Items.Count > 0
                        select c;
            return query.ToList();
        }
       
        public static IList<Cheque> FromDate(string chequeDate)
        {
            var query = from c in DbContext.Entity<Cheque>()
                        where c.SendingtoBankDate == chequeDate
                              && c.Items.Count > 0
                        select c;
            return query.ToList();
        }

        public override Payment Clone()
        {
            Cheque cheque = Services.Clone(this);
            cheque.Date = Date;
            return cheque;
        }
    }

    public enum ChequeStatus
    {
        [EnumDescription(" در دست اقدام")]
        InProgress,
        [EnumDescription("وصول شده")]
        Passed,
        [EnumDescription("برگشت شده")]
        Returned,
        [EnumDescription("معلق/بدون اقدام")]
        Suspended,
        [EnumDescription("عودت داده شده")]
        Canceled,
        [EnumDescription("ارسال به بانک")]
        SentToBank,
        [EnumDescription("ضمانت")]
        Support,
    }
}