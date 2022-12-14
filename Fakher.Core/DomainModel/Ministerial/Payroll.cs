using System;
using System.Collections.Generic;
using DataAccessLayer;
using rComponents;
using System.Linq;

namespace Fakher.Core.DomainModel
{
    public class Payroll : DbObject, IProgressive
    {      
        public Payroll()
        {
            PayrollContracts = new List<PayrollContract>();
        }

        public virtual IList<PayrollContract> PayrollContracts { get; set; }
        [NoCascade]
        public virtual Staff Staff { get; set; }
        public virtual event EventHandler<ProgressEventArgs> Progress;

        [NonPersistent]
        public virtual string MajorText
        {
            get
            {
                string txt = "";
                foreach (PayrollContract payrollContract in PayrollContracts)
                {
                    if (payrollContract.TeachingContract != null)
                    {
                        txt += payrollContract.TeachingContract.Major.Name;
                        if (PayrollContracts.IndexOf(payrollContract) != PayrollContracts.Count - 1)
                            txt += "، ";
                    }
                }
                return txt;
            }
        }

        [NonPersistent]
        public virtual PersianDate StartDate
        {
            get
            {
                var query = from payrollContract in PayrollContracts
                            orderby payrollContract.StartDate
                            select payrollContract;
                return query.First().StartDate;
            }
        }

        [NonPersistent]
        public virtual PersianDate EndDate
        {
            get
            {
                var query = from payrollContract in PayrollContracts
                            orderby payrollContract.EndDate
                            select payrollContract;
                return query.Last().EndDate;
            }
        }

        [NonPersistent]
        public virtual float PayableAmount
        {
            get { return PayrollContracts.Sum(x => x.PayableAmount); }
        }
        [NonPersistent]
        public virtual float PaidAmount
        {
            get { return PayrollContracts.Sum(x => x.PaidAmount); }
        }
        [NonPersistent]
        
        public virtual string PaymentStatus
        {
            get
            {
                if (PayableAmount - PaidAmount == 0)
                    return "تسویه";
                else if (PayableAmount - PaidAmount > 0)
                    return "بستانکار" + "(" + Math.Abs(PayableAmount - PaidAmount).ToString("C0") + ") ";
                else
                    return "بدهکار" + "(" + Math.Abs(PayableAmount - PaidAmount).ToString("C0") + ") ";
            }
        }
        [NonPersistent]
        public virtual IQueryable<PayrollItem> AllItems
        {
            get
            {
                var query = from payrollContract in PayrollContracts
                            from item in payrollContract.Items
                            select item;
                return query.AsQueryable();
            }
        }
        [NonPersistent]
        public virtual IQueryable<PayrollPaid> AllPaied
        {
            get
            {
                var query = from payrollContract in PayrollContracts
                            from item in payrollContract.PaidList
                            select item;
                return query.AsQueryable();
            }
        }
        [NonPersistent]
        public virtual IQueryable<PayrollItem> CreditItems
        {
            get
            {
                var query = from item in AllItems
                            where item.FinancialType == FinancialType.Credit
                            select item;
                return query.AsQueryable();
            }
        }

        [NonPersistent]
        public virtual IQueryable<PayrollItem> DebtItems
        {
            get
            {
                var query = from item in AllItems
                            where item.FinancialType == FinancialType.Debt
                            select item;
                return query.AsQueryable();
            }
        }

        public virtual void OnProgress(string text, int value, int maximum)
        {
            if (Progress != null)
                Progress(this, new ProgressEventArgs());
        }

        public virtual void PreCalculate()
        {
            foreach (PayrollContract payrollContract in PayrollContracts)
            {
                payrollContract.PreCalculate();
            }
        }

        public virtual void Calculate()
        {
            foreach (PayrollContract payrollContract in PayrollContracts)
            {
                payrollContract.Calculate();
            }
        }

        public override string ToString()
        {
            return MajorText + " (" + StartDate.ToShortDateString() + " تا " + EndDate.ToShortDateString() + ")";
        }

        public static Payroll FromId(int id)
        {
            return DbContext.FromId<Payroll>(id);
        }

        public virtual IQueryable<PayrollItem> GetItems(PayrollItemHeading heading)
        {
            var query = from item in AllItems
                        where item.Heading == heading
                        select item;

            return query;
        }
        public virtual IQueryable<PayrollItem> GetCreditItems(PayrollItemHeading heading)
        {
            var query = from item in CreditItems
                        where item.Heading == heading
                        select item;

            return query;
        }
        public virtual IQueryable<PayrollItem> GetDebtItems(PayrollItemHeading heading)
        {
            var query = from item in DebtItems
                        where item.Heading == heading
                        select item;

            return query;
        }
    }
}