using System;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer;
using rApplicationEventFramework;
using rComponents;
using System.Linq;

namespace Fakher.Core.DomainModel
{
    public class EducationalTool : DbObject
    {
        public virtual string Name { get; set; }
        public virtual string Author { get; set; }
        public virtual EducationalToolType Type { get; set; }
        [MaximumLength]
        public virtual string Description { get; set; }
        //        public virtual long BuyPrice { get; set; }
        //        public virtual long SellPrice { get; set; }
        //        public virtual int Count { get; set; }
        //        public virtual int Remainder { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual bool Disabled { get; set; }
        public virtual bool ShowInWebsite { get; set; }
        public virtual bool SellInWebsite { get; set; }
        public virtual int WebHits { get; set; }
        public virtual IList<GroupTool> GroupTools { get; set; }
        public virtual IList<EducationalToolSupply> Supplies { get; set; }

        public EducationalTool()
        {
            GroupTools = new List<GroupTool>();
            Supplies = new List<EducationalToolSupply>();
            Type = EducationalToolType.Book;
            WebHits = 0;
            Disabled = false;
        }

        [NonPersistent]
        public virtual long Profit
        {
            get { return LastSellPrice - LastBuyPrice; }
        }

        [NonPersistent]
        public virtual string StatusText
        {
            get
            {
                if (Disabled)
                    return "غیر فعال";
                if (Remainder > 0)
                    return "موجود";
                return "نا موجود";
            }
        }

        [NonPersistent]
        public virtual string TypeText
        {
            get
            {
                return Type.ToDescription();
            }
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

        public static int SumOfSuppliesToDate(int educationalToolId, int educationalToolSupplyId, PersianDate date)
        {
            var previousSupplies = (from educationalToolSupply in DbContext.Entity<EducationalToolSupply>()
                                    where educationalToolSupply.EducationalTool.Id == educationalToolId
                                          && educationalToolSupply.Date <= date
                                          && educationalToolSupply.Id < educationalToolSupplyId
                                    select educationalToolSupply.Count).ToList();
            return previousSupplies.Sum();
        }
        public static int SumOfUsesToDate(int educationalToolId, int educationalToolSupplyId, PersianDate date)
        {
            var previousSupplies = (from educationalToolSupply in DbContext.Entity<EducationalToolSupply>()
                                    where educationalToolSupply.EducationalTool.Id == educationalToolId
                                          && educationalToolSupply.Date <= date
                                          && educationalToolSupply.Id < educationalToolSupplyId
                                    select educationalToolSupply.Count - educationalToolSupply.Remainder).ToList();
            return previousSupplies.Sum();
        }

        public virtual void AddSupply(int addingCount, long buyPrice, long sellPrice)
        {
            EducationalToolSupply supply = new EducationalToolSupply();

            supply.Count += addingCount;
            supply.Remainder += addingCount;
            supply.BuyPrice = buyPrice;
            supply.SellPrice = sellPrice;


        }

        //        public virtual void EditSupply(int totalCount, int remainderCount, long buyPrice, long sellPrice)
        //        {
        //            Count = totalCount;
        //            Remainder = remainderCount;
        //            BuyPrice = buyPrice;
        //            SellPrice = sellPrice;
        //        }

        public virtual Use CreateUse(Person person, UseType type, bool addCashItem)
        {
            Use use = new Use
                          {
                              Person = person,
                              EducationalTool = this,
                              Type = type
                              ,
                              FinancialDocument =
                                  {
                                      Person = person,
                                      Description = "خرید/امانت کتاب"
                                  }
                          };
            if (type == UseType.Buy)
            {
                use.FinancialDocument.Items.Add(new FinancialItem(FinancialType.Debt)
                                                    {
                                                        Amount = LastSellPrice,
                                                        Text = string.Format("{0}", Name),
                                                        Heading = FinancialHeading.ToolSell
                                                    });
                if (addCashItem)
                {
                    FinancialItem cashItem = new Cash { Amount = LastSellPrice }.Item;
                    cashItem.Heading = FinancialHeading.ToolSell;
                    use.FinancialDocument.Items.Add(cashItem);
                }

                use.BuyPrice = LastBuyPrice;
                use.UsePrice = LastSellPrice;
                
            }
            return use;
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual void IncrementHits()
        {
            WebHits++;
        }

        public virtual bool Has(int count)
        {
            return Remainder >= count;
        }

        /// <summary>
        /// Returns Sale Profit
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual long Decrease(int count)
        {
            if (!Has(count))
                throw new MessageException(string.Format("{0} به اندازه کافی موجود نیست.", Name));

            long profit = 0;
            for (int i = 0; i < count; i++)
            {
                foreach (EducationalToolSupply supply in Supplies)
                {
                    if (supply.Has(1))
                    {
                        profit += LastSellPrice - supply.BuyPrice;
                        supply.Decrease(1);
                        break;
                    }
                }
            }
            return profit;
        }

        public virtual void Increase(int count)
        {
            if (Supplies.Count == 0)
                throw new MessageException(string.Format("برای {0} هیچ موجودی ثبت نشده است.", Name));
            Supplies.Last().Increase(1);
        }

        //mohammad
        public virtual IList<Use> GetEducationalToolUses(PersianDate startDate, PersianDate endDate)
        {
            var query = from use in DbContext.Entity<Use>()
                        where use.Date >= startDate.ToShortDateString()
                        && use.Date <= endDate.ToShortDateString()
                        && use.EducationalTool.Id == Id
                        select use;
            return query.ToList();
        }

        public virtual IQueryable<EducationalToolSupply> GetSupplies(PersianDate startDate, PersianDate endDate)
        {
            var query = from supply in Supplies
                        where supply.Date >= startDate
                              && supply.Date <= endDate
                        select supply;
            return query.AsQueryable();
        }

        public static IQueryable<EducationalTool> GetActiveTools()
        {
            var query = from tool in DbContext.Entity<EducationalTool>()
                        where tool.Disabled == false
                        select tool;
            return query;
        }
        //mohammad
        public static IQueryable<EducationalTool> GetAllTools()
        {
            var query = from tool in DbContext.Entity<EducationalTool>()
                        select tool;
            return query;
        }

        public static IQueryable<EducationalTool> GetWebsiteShowingTools()
        {
            var query = from tool in DbContext.Entity<EducationalTool>()
                        where tool.ShowInWebsite
                        select tool;
            return query;
        }

        public static IQueryable<EducationalTool> GetWebsiteSellingTools()
        {
            var query = from tool in DbContext.Entity<EducationalTool>()
                        where tool.SellInWebsite
                        select tool;
            return query;
        }

        public static IQueryable<EducationalTool> GetTools(Major major)
        {
            var query = from tool in GetActiveTools()
                        from @group in tool.GroupTools
                        where @group.Group.Major != null &&
                              @group.Group.Major.Id == major.Id
                        select tool;
            return query;
        }

        public static EducationalTool FromId(int id)
        {
            return DbContext.FromId<EducationalTool>(id);
        }
    }

    public enum EducationalToolType
    {
        [EnumDescription("کـتاب")]
        Book,
        [EnumDescription("لوح آموزشی")]
        Disk,
        [EnumDescription("سایر اقلام")]
        Other,
    }
}