using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Payment : DbObject
    {
        public virtual string InternalDocumentNumber { get; set; }
        public virtual IList<FinancialItem> Items { get; set; }

        protected Payment()
        {
            InternalDocumentNumber = "";
            Items = new List<FinancialItem>();
        }

        [NonPersistent]
        public virtual FinancialItem Item
        {
            get
            {
                if (Items.Count > 0)
                    return Items[0];
//                foreach (FinancialItem item in Items)
//                    if (item.Document != null)
//                        return item;
                return null;
            }
            set
            {
                if(Items.Count == 0)
                    Items.Add(value);
                else
                    Items[0] = value;
            }
        }

        [NonPersistent]
        public virtual string Description { get; protected set; }

        [NonPersistent]
        public virtual long Amount
        {
            get
            {
                    return Item.Amount;
            }
            set
            {
                Item.Amount = value;
            }
        }
        [NonPersistent]
        public virtual long Amount_Signup
        {
            get
            {
                if (Item.Heading == FinancialHeading.PaidTution)
                    return 0;
                else
                    return Item.Amount;
            }
            set
            {
                Item.Amount = value;
            }
        }

        [NonPersistent]
        public virtual PersianDate Date
        {
            get
            {
                return Item.Date;
            }
            set
            {
                Item.Date = value;
            }
        }

        [NonPersistent]
        public virtual long CashAmount
        {
            get
            {
                if (Item.Is<Cash>() || Item.Is<Receipt>())
                    return Item.Amount;
                return 0;
            }
        }
        [NonPersistent]
        public virtual long CashAmount_Signup
        {
            get
            {
                if (Item.Is<Cash>() || Item.Is<Receipt>() && Item.Heading != FinancialHeading.PaidTution)
                    return Item.Amount;
                return 0;
            }
        }

        [NonPersistent]
        public virtual long ElectronicPaymentAmount
        {
            get
            {
                if (Item.Is<ElectronicPayment>())
                    return Item.Amount;
                return 0;
            }
        }
        [NonPersistent]
        public virtual long ElectronicPaymentAmount_Signup
        {
            get
            {
                if (Item.Is<ElectronicPayment>() && Item.Heading != FinancialHeading.PaidTution)
                    return Item.Amount;
                else
                return 0;
            }
        }
        [NonPersistent]
        public virtual long DiscountAmount
        {
            get
            {
                if (Item.Is<Discount>())
                    return Item.Amount;
                return 0;
            }
        }
        [NonPersistent]
        public virtual long ChequeAmount
        {
            get
            {
                if (Item.Is<Cheque>())
                    return Item.Amount;
                return 0;
            }
        }
        [NonPersistent]
        public virtual long ChequeAmount_Signup
        {
            get
            {
                if (Item.Is<Cheque>() && Item.Heading != FinancialHeading.PaidTution)
                    return Item.Amount;
                return 0;
            }
        }

        public virtual Payment Clone()
        {
            throw new NotImplementedException();
        }
        
    }
}