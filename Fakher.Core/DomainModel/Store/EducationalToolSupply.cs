using DataAccessLayer;
using Fakher.Core.DomainModel.Buffet;
using rComponents;
using System.Linq;

namespace Fakher.Core.DomainModel
{
    public class EducationalToolSupply : DbObject
    {
        public virtual PersianDate Date { get; set; }
        public virtual long BuyPrice { get; set; }
        public virtual long SellPrice { get; set; }
        public virtual int Count { get; set; }
        public virtual int Remainder { get; set; }
        public virtual string BillNo { get; set; }
        [NoCascade]
        public virtual EducationalTool EducationalTool { get; set; }

        public EducationalToolSupply()
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

        public virtual void Increase(int count)
        {
            Remainder += count;
        }

        public static IQueryable<EducationalToolSupply> GetSuppliesToDate(PersianDate endDate)
        {
            var query = from educationalToolSupply in DbContext.Entity<EducationalToolSupply>()
                        where educationalToolSupply.Date <= endDate.ToShortDateString()
                        select educationalToolSupply;
            return query.AsQueryable();
        }

        public static IQueryable<EducationalToolSupply> GetSuplies(string invoiceNumber)
        {
            var query = from educationalToolSupply in DbContext.Entity<EducationalToolSupply>()
                        where educationalToolSupply.BillNo == invoiceNumber
                        select educationalToolSupply;
            return query;
        }
    }
}