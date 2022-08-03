using System;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Discount : Payment
    {
        public virtual string Title { get; set; }

        public Discount()
        {
            Item = new FinancialItem(FinancialType.Credit) { Payment = this };
//            Item = new FinancialItem { Type = FinancialType.Credit };
        }

        [NonPersistent]
        public override string Description
        {
            get { return "تخفیف " + Title; }
        }

        public override Payment Clone()
        {
            Discount discount = Services.Clone(this);
            discount.Date = Date;
            return discount;
        }
    }
}