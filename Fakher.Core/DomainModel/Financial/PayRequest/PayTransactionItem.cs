using System;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class PayTransactionItem : DbObject
    {
        public virtual string Text { get; set; }
        public virtual long Amount { get; set; }
        public virtual PayTransactionItemType Type { get; set; }
        public virtual FinancialHeading Heading { get; set; }
        [NoCascade]
        public virtual FinancialDocument FinancialDocument { get; set; }
        public virtual FinancialItem FinancialItem { get; set; }
        [NoCascade]
        public virtual PayTransaction PayTransaction { get; set; }

        public PayTransactionItem()
        {
            Heading = FinancialHeading.Signup;
            Type = PayTransactionItemType.ElectronicPayment;
        }

        public virtual FinancialItem CreateFinancialItem()
        {
            FinancialItem item = null;

            if(Type == PayTransactionItemType.Debt)
            {
                item = new FinancialItem(FinancialType.Debt);
            }
            if(Type == PayTransactionItemType.ElectronicPayment)
            {
                ElectronicPayment payment = new ElectronicPayment();
                item = payment.Item;
            }
            if(Type == PayTransactionItemType.Credit)
            {
                CreditPayment payment = new CreditPayment();
                item = payment.Item;
            }

            item.Date = PersianDate.Today;
            item.Amount = Amount;
            item.Heading = Heading;
            item.Text = Text;

            return item;
        }
    }

    public enum PayTransactionItemType
    {
        [EnumDescription("بدهکار/کسورات")]
        Debt,
        ElectronicPayment,
        Credit,
    }
}