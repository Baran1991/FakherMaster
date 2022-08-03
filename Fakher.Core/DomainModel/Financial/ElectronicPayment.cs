using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Security.Tokens;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class ElectronicPayment : Payment
    {
        public ElectronicPayment()
        {
            Item = new FinancialItem { Type = FinancialType.Credit, Payment = this };
            Type = ElectronicPaymentType.CardPayment;
        }

        public virtual string CardNumber { get; set; }
        public virtual string TraceNumber { get; set; }
        public virtual string TransactionNumber { get; set; }
        public virtual ElectronicPaymentType Type { get; set; }

        [NonPersistent]
        public override string Description
        {
            get
            {
                string txt = "";
                if(Type == ElectronicPaymentType.CardPayment)
                    txt += "پرداخت الکترونیکی";
                if(Type == ElectronicPaymentType.InternetPayment)
                    txt += "پرداخت اینترنتی";

                if (!string.IsNullOrEmpty(CardNumber))
                    txt += string.Format("، کارت شماره {0}", CardNumber);
                if(!string.IsNullOrEmpty(TraceNumber))
                    txt += string.Format("، شماره پیگیری {0}", TraceNumber); 
                if(!string.IsNullOrEmpty(TransactionNumber))
                    txt += string.Format("، شماره تراکنش {0}", TransactionNumber);
                return txt;
            }
        }
        public static IList<ElectronicPayment> Search(string cardNumber,string transNumber,string traceNumber)
        {
            var list = from receipt in DbContext.Entity<ElectronicPayment>().ToList() where receipt.Items.Count > 0 select receipt;
            if(!string.IsNullOrEmpty(cardNumber))
            {
                list = list.ToList().Where(m => m.CardNumber == cardNumber);
            }
            if (!string.IsNullOrEmpty(traceNumber))
            {
                list = list.ToList().Where(m => m.TraceNumber == traceNumber);
            }
            if (!string.IsNullOrEmpty(transNumber))
            {
                list = list.ToList().Where(m => m.TraceNumber == transNumber);
            }
            return list.ToList();
        }
        public override Payment Clone()
        {
            ElectronicPayment electronicPayment = Services.Clone(this);
            electronicPayment.Date = Date;
            return electronicPayment;
        }

        public static IQueryable<ElectronicPayment> GetElectronicPayments(PersianDate startDate, PersianDate endDate)
        {
            List<FinancialItem> items = FinancialItem.GetFinancialItem(startDate, endDate).ToList();

            var electronicPaymentsQuery = from item in items
                               where item.Is<ElectronicPayment>()
                               select item.Payment as ElectronicPayment;

            var query = from ePayment in electronicPaymentsQuery
                        where ePayment.Item != null
                        && ePayment.Item.Document != null
                        && ePayment.Item.Document.Person != null
                        && ePayment.Item.Date >= startDate
                        && ePayment.Item.Date <= endDate
                        select ePayment;

            return query.AsQueryable();
        }

        public virtual PayTransaction GetTransaction()
        {
            int itemId = Item.Id;
            var query = from transactionItem in DbContext.Entity<PayTransactionItem>()
                        where transactionItem.FinancialItem.Id == itemId
                        select transactionItem.PayTransaction;
            return query.FirstOrDefault();
        }
    }

    public enum ElectronicPaymentType
    {
        [EnumDescription("پرداخت با کارت")]
        CardPayment,
        [EnumDescription("پرداخت اینترنتی")]
        InternetPayment
    }
}