using DataAccessLayer;

namespace Fakher.Core.DomainModel
{
    public class CreditPayment : Payment
    {
        public CreditPayment()
        {
            Item = new FinancialItem(FinancialType.Credit) { Payment = this };
        }

        [NonPersistent]
        public override string Description
        {
            get { return string.Format("پرداخت از اعتبار"); }
        }
    }
}