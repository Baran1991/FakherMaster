using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel.Buffet
{
    public class BuffetSale : DbObject
    {
        public virtual PersianDate Date { get; set; }
        public virtual int Hour { get; set; }
        public virtual int Minute { get; set; }
        public virtual int Second { get; set; }
        public virtual IList<BuffetSaleItem> Items { get; set; }
        [NoCascade]
        public virtual BuffetSeller Seller { get; set; }

        public BuffetSale()
        {
            Date = PersianDate.Today;
            Hour = Time.Now.Hour;
            Minute = Time.Now.Minute;
            Second = Time.Now.Second;
            Items = new List<BuffetSaleItem>();
        }

        [NonPersistent]
        public virtual long Price
        {
            get { return Items.Sum(x => x.Price); }
        }

        public virtual void AddItem(BuffetSaleItem item)
        {
            item.BuffetSale = this;
            Items.Add(item);
        }
    }
}