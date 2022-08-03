using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel.Buffet
{
    public class BuffetSaleItem : DbObject
    {
        [NoCascade]
        public virtual BuffetSale BuffetSale { get; set; }
        [NoCascade]
        public virtual BuffetProduct BuffetProduct { get; set; }
        public virtual int Count { get; set; }
        public virtual long? SaleItemProfit { get; set; }

        public BuffetSaleItem()
        {
            Count = 1;
        }

        [NonPersistent]
        public virtual long Price
        {
            get { return Count * BuffetProduct.LastSellPrice; }
        }

        [NonPersistent]
        public virtual long Profit
        {
            get
            {
                if (SaleItemProfit.HasValue)
                    return SaleItemProfit.Value;
                return Count * BuffetProduct.Profit;
            }
        }

        public static IQueryable<BuffetSaleItem> GetItems(PersianDate startDate, PersianDate endDate)
        {
            var query = from item in DbContext.Entity<BuffetSaleItem>()
                        where item.BuffetSale != null
                              && item.BuffetSale.Date >= startDate
                              && item.BuffetSale.Date <= endDate
                        select item;
            return query;
        }
    }
}