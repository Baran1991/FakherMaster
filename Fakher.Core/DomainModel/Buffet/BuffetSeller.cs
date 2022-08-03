using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using NHibernate.Linq;
using rComponents;

namespace Fakher.Core.DomainModel.Buffet
{
    public class BuffetSeller : Employee
    {
        public virtual void RegisterTransactionFor(BuffetSale buffetSale)
        {
            FinancialItem item = new FinancialItem(FinancialType.Debt)
            {
                Amount = buffetSale.Price,
                Text = string.Format("فروش شماره [{0}]  ", buffetSale.Id)
            };

            RegisterDailyItem(item);
        }

        public virtual IQueryable<BuffetSale> GetBuffetSales()
        {
            var query = from sale in DbContext.Entity<BuffetSale>()
                        where sale.Seller != null
                              && sale.Seller.Id == Id
                        select sale;
            return query;
        }

        public virtual IQueryable<BuffetSale> GetBuffetSales(PersianDate startDate, PersianDate endDate)
        {
            var query = from sale in GetBuffetSales()
                        where sale.Date >= startDate && sale.Date <= endDate
                        select sale;
            return query;
        }

        public virtual IQueryable<BuffetSaleItem> GetBuffetSaleItems(PersianDate startDate, PersianDate endDate)
        {
            var query = from sale in GetBuffetSales(startDate, endDate)
                        from item in sale.Items
                        select item;
            return query;
        }

        public override long GetFinancialBalance()
        {
            long sum =( GetBuffetSales().ToList()).Sum(x => x.Price);

            IEnumerable<FinancialItem> payOffItems = GetDailyFinancialItems(FinancialHeading.EmployeePayOff);
            long payoffSum = payOffItems.Sum(x => x.Amount);

            return payoffSum - sum;
        }

        public override IEnumerable<FinancialItem> GetInsertedFinancialItems(PersianDate startDate, PersianDate endDate)
        {
            List<FinancialItem> items = new List<FinancialItem>();
            List<BuffetSale> sales = GetBuffetSales(startDate, endDate).ToList();
            foreach (BuffetSale sale in sales)
            {
                Cash cash = new Cash { Amount = sale.Price, Date = sale.Date };
                items.Add(cash.Item);
            }
            return items;
        }

        public static IList<BuffetSeller> GetBuffetSellers()
        {
            return DbContext.GetAllEntities<BuffetSeller>();
        }
    }
}