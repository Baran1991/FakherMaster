using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel.Buffet
{
    public class BuffetSupply : DbObject
    {
        public virtual PersianDate Date { get; set; }
        public virtual long BuyPrice { get; set; }
        public virtual long SellPrice { get; set; }
        public virtual int Count { get; set; }
        public virtual int Remainder { get; set; }
        public virtual string BillNo { get; set; }
        [NoCascade]
        public virtual BuffetProduct BuffetProduct { get; set; }

        [NonPersistent]
        public virtual long Profit
        {
            get { return SellPrice - BuyPrice; }
        }

        public BuffetSupply()
        {
            Date = PersianDate.Today;
        }

        public virtual bool Has(int count)
        {
            return Remainder >= count;
        }

        public virtual void Decrease(int count)
        {
            Remainder -= count;
        }

        public static IQueryable<BuffetSupply> GetSuplies(string invoiceNumber)
        {
            var query = from supply in DbContext.Entity<BuffetSupply>()
                        where supply.BillNo == invoiceNumber
                        select supply;
            return query;
        }
    }
}