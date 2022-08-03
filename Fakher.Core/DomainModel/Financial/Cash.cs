using System;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Cash : Payment
    {
        public Cash()
        {
            Item = new FinancialItem(FinancialType.Credit) { Payment = this};
//            Item = new FinancialItem { Type = FinancialType.Credit };
        }

        [NonPersistent]
        public override string Description
        {
            get { return "پرداخت نقدی"; }
        }

        public override Payment Clone()
        {
            Cash cash = Services.Clone(this);
            cash.Date = Date;
            return cash;
        }
    }
}