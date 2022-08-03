using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel.Buffet
{
    public class BuffetProduct : DbObject
    {
        public virtual string Name { get; set; }
        public virtual IList<BuffetSupply> Supplies { get; set; }

        public BuffetProduct()
        {
            Supplies = new List<BuffetSupply>();
        }

        [NonPersistent]
        public virtual long LastBuyPrice
        {
            get
            {
                if (Supplies.Count > 0)
                    return Supplies.Last().BuyPrice;
                return 0;
            }
        }

        [NonPersistent]
        public virtual long LastSellPrice
        {
            get
            {
                if (Supplies.Count > 0)
                    return Supplies.Last().SellPrice;
                return 0;
            }
        }

        [NonPersistent]
        public virtual long Profit
        {
            get { return LastSellPrice - LastBuyPrice; }
        }

        [NonPersistent]
        public virtual int Count
        {
            get { return Supplies.Sum(x => x.Count); }
        }

        [NonPersistent]
        public virtual int Remainder
        {
            get { return Supplies.Sum(x => x.Remainder); }
        }

        [NonPersistent]
        public virtual bool HasRemainder
        {
            get { return Remainder > 0; }
        }

        public static IList<BuffetProduct> GetAllProducts()
        {
            return DbContext.GetAllEntities<BuffetProduct>();
        }

        public virtual bool Has(int count)
        {
            return Remainder >= count;
        }

//        /// <summary>
//        /// Sync with Decrease
//        /// </summary>
//        /// <param name="count"></param>
//        /// <returns></returns>
//        public virtual long CalculateSaleProfit(int count)
//        {
//            if (!Has(count))
//                throw new MessageException(string.Format("{0} به اندازه کافی موجود نیست.", Name));
//
//            long profit = 0;
//            for (int i = 0; i < count; i++)
//            {
//                foreach (BuffetSupply supply in Supplies)
//                {
//                    if (supply.Has(1))
//                    {
//                        profit += LastSellPrice - supply.BuyPrice;
//                        break;
//                    }
//                }
//            }
//            return profit;
//        }

        /// <summary>
        /// Returns Sale Profit
        /// </summary>
        /// <param name="count"></param>
        public virtual long Decrease(int count)
        {
            if (!Has(count))
                throw new MessageException(string.Format("{0} به اندازه کافی موجود نیست.", Name));

            long profit = 0;
            for (int i = 0; i < count; i++)
            {
                foreach (BuffetSupply supply in Supplies)
                {
                    if (supply.Has(1))
                    {
                        profit += LastSellPrice - supply.BuyPrice;
                        supply.Decrease(1);
                        break;
                    }
                }
            }

//            foreach (BuffetSupply supply in Supplies)
//            {
//                if (supply.Has(count))
//                {
//                    supply.Decrease(count);
//                    return;
//                }
//            }
//            throw new MessageException(string.Format("{0} به اندازه کافی موجود نیست.", Name));
            return profit;
        }

        public override string ToString()
        {
            return Name;
        }

        //mohammad
        public virtual IQueryable<BuffetSupply> GetSupplies(PersianDate startDate, PersianDate endDate)
        {
            var query = from item in Supplies
                        where item.Date >= startDate
                              && item.Date <= endDate
                        select item;
            return query.AsQueryable();
        }
        public static int SumOfSuppliesToDate(int buffetProductId, int buffetProductSupplyId, PersianDate date)
        {
            var previousSupplies = (from buffetProductSupply in DbContext.Entity<BuffetSupply>()
                                    where buffetProductSupply.BuffetProduct.Id == buffetProductId
                                          && buffetProductSupply.Date <= date
                                          && buffetProductSupply.Id < buffetProductSupplyId
                                    select buffetProductSupply.Count).ToList();
            return previousSupplies.Sum();
        }
        public static int SumOfUsesToDate(int buffetProductId, int buffetProductSupplyId, PersianDate date)
        {
            var previousSupplies = (from buffetProductSupply in DbContext.Entity<BuffetSupply>()
                                    where buffetProductSupply.BuffetProduct.Id == buffetProductId
                                          && buffetProductSupply.Date <= date
                                          && buffetProductSupply.Id < buffetProductSupplyId
                                    select buffetProductSupply.Count-buffetProductSupply.Remainder).ToList();
            return previousSupplies.Sum();
        }
    }
}