using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Use : DbObject
    {
        public Use()
        {
            Type = UseType.Buy;
            FinancialDocument = new FinancialDocument();
            Date = PersianDate.Today;
        }

        public virtual int BatchNumber { get; set; }
        [NoCascade]
        public virtual Person Person { get; set; }
        public virtual long BuyPrice { get; set; }
        /// <summary>
        /// SellPrice
        /// </summary>
        public virtual long UsePrice { get; set; }
        public virtual long? UseProfit { get; set; }
        [NoCascade]
        public virtual EducationalTool EducationalTool { get; set; }
        public virtual UseType Type { get; set; }
        public virtual PersianDate Date { get; set; }
        public virtual long FactorNo { get; set; } = 100000;
        public virtual PersianDate ReturnDate { get; set; }
        public virtual FinancialDocument FinancialDocument { get; set; }
        [NonPersistent]
        public virtual int count { get; set; }
        [NonPersistent]
        public virtual long Price
        {
            get
            {
                FinancialItem item = FinancialDocument.GetItems(FinancialType.Debt).FirstOrDefault();
                if (item != null)
                    return item.Amount;
                return EducationalTool.LastSellPrice;
            }         
    }
        //public virtual long NextFactorNo()
        //{
        //    var factorNo = DbContext.Entity<Use>().Max(m => m.FactorNo) + 1;
        //    return factorNo;
        //}
        public static long GetNextFactorNo()
        {
            var query = from use in DbContext.Entity<Use>()
                        orderby use.FactorNo descending
                        select use.FactorNo;
            long lastNumber = query.FirstOrDefault();
            return lastNumber + 1;
        }
        [NonPersistent]
        public virtual long Profit
        {
            get
            {
                if (UseProfit.HasValue)
                    return UseProfit.Value;
                return EducationalTool.Profit;
            }
        }

        [NonPersistent]
        public virtual long UsePrice_t
        {
            get
            {                
                return UsePrice*count;
            }
        }

        [NonPersistent]
        public virtual string ReturnStatusText
        {
            get
            {
                if (!IsReturned)
                    return "در حال امانت";
                return "برگشت داده شده";
            }
        }

        [NonPersistent]
        public virtual string TypeText
        {
            get { return Type.ToDescription(); }
        }

        [NonPersistent]
        public virtual long SumOfUsesToDate
        {
            get { return GetUsesToDate(Date).LongCount(); }
        }

        [NonPersistent]
        public virtual bool IsReturned
        {
            get { return ReturnDate != null; }
        }

        [NonPersistent]
        public virtual string BorrowStatusText
        {
            get
            {
                if (!IsReturned)
                    return "در حال امانت";
                return "عودت داده شده";
            }
        }

        public static IList<Use> GetUses(PersianDate startDate, PersianDate endDate)
        {
            var query = from use in DbContext.Entity<Use>()
                        where use.Date >= startDate.ToShortDateString() && use.Date <= endDate.ToShortDateString()
                        select use;
            return query.ToList();
        }

        public static IQueryable<Use> GetUsesToDate(PersianDate endDate)
        {
            var query = from use in DbContext.Entity<Use>()
                        where use.Date <= endDate.ToShortDateString()
                        select use;
            return query.AsQueryable();
        }

        public static IQueryable<Use> GetUses(IList<Use> uses, UseType type)
        {
            var query = from use in uses
                        where use.Type == type
                        select use;
            return query.AsQueryable();
        }

        public static int GetNextBatchNumber()
        {
            var query = from use in DbContext.Entity<Use>()
                        orderby use.BatchNumber descending
                        select use.BatchNumber;
            int lastNumber = query.FirstOrDefault();
            return lastNumber + 1;
        }
    }

    public enum UseType
    {
        [EnumDescription("خرید")]
        Buy,
        [EnumDescription("امانت")]
        Borrow
    }
}