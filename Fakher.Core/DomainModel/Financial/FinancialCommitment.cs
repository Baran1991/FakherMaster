using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using NHibernate.Linq;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class FinancialCommitment : DbObject
    {
        public virtual PersianDate Date { get; set; }
        public virtual FinancialCommitmentType Type { get; set; }
        public virtual long Amount { get; set; }
        public virtual FinancialCommitmentStatus Status { get; set; }
        public virtual PersianDate PayOffDate { get; set; }
        [NoCascade]
        public virtual Register Register { get; set; }

        public FinancialCommitment()
        {
            Status = FinancialCommitmentStatus.InProgress;
        }

        [NonPersistent]
        public virtual string Text
        {
            get { return "تعهد " + TypeText + " به مبلغ " + AmountText + " در سررسید " + Date + " (" + StatusText + ")"; }
        }

        [NonPersistent]
        public virtual string TypeText
        {
            get { return Type.ToDescription(); }
        }

        [NonPersistent]
        public virtual string StatusText
        {
            get { return Status.ToDescription(); }
        }

        [NonPersistent]
        public virtual string AmountText
        {
            get { return Amount.ToString("C0"); }
        }

        public static List<FinancialCommitment> GetCommitments(PersianDate startDate, PersianDate endDate)
        {
            var query = from commitment in DbContext.Entity<FinancialCommitment>()
                        where commitment.Date >= startDate &&
                              commitment.Date <= endDate
                        select commitment;
            return  query.ToList();
        }

        public static IQueryable<FinancialCommitment> GetCommitments(FinancialCommitmentStatus status)
        {
            var query = from commitment in DbContext.Entity<FinancialCommitment>()
                        where commitment.Status == status
                        select commitment;
            return query;
        }
    }

    public enum FinancialCommitmentType
    {
        [EnumDescription("چک")]
        Cheque,
        [EnumDescription("وجه نقد")]
        Cash,
    }

    public enum FinancialCommitmentStatus
    {
        [EnumDescription("متعهد")]
        InProgress,
        [EnumDescription("انجام شده")]
        PayedOff,
    }
}