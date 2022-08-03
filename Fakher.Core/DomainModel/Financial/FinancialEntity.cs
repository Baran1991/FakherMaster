using System;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class FinancialEntity : DbObject, IFinancialEntity
    {
        public virtual FinancialDocument FinancialDocument { get; set; }

        #region Implementation of IFinancialEntity

        [NonPersistent]
        public virtual long PayableTuition
        {
            get { throw new NotImplementedException(); }
        }

        [NonPersistent]
        public virtual FinancialHeading Heading
        {
            get { throw new NotImplementedException(); }
        }

        [NonPersistent]
        public virtual long PayDifference
        {
            get { return FinancialDocument.GetItems(FinancialHeading.PayDifference).Sum(x => x.Balance); }
        }

        [NonPersistent]
        public virtual long TuitionDifference
        {
            get { return FinancialDocument.GetItems(FinancialHeading.TuitionDifference).Sum(x => x.Balance); }
        }

        [NonPersistent]
        public virtual long EffectivePayableTuition
        {
            get { return (PayableTuition - TuitionDifference - PayDifference) - (FinancialDocument.GetDiscountBalance(Heading)); }
        }

        [NonPersistent]
        public virtual long IncompletePayDebtBalance
        {
            //get { return EffectivePayableTuition - FinancialDocument.GetPayedBalance(Heading); }
            get { return EffectivePayableTuition - FinancialDocument.PayedBalance; }
        }



        [NonPersistent]
        public virtual int DebtorSign
        {
            get
            {
                if (DebtAmount > 0)
                    return 1;
                return 0;
            }
        }

        [NonPersistent]
        public virtual long DebtAmount
        {
            get
            {
                return IncompletePayDebtBalance + FinancialDocument.GetChequeDebtBalance(Heading);
            }
        }

        [NonPersistent]
        public virtual string DebtReasonText
        {
            get
            {
                if (IncompletePayDebtBalance > 0)
                    return "کسر پرداخت";
                if (FinancialDocument.ChequeDebtBalance > 0)
                {
                    string txt = "";
                    foreach (FinancialItem item in FinancialDocument.DebtChequeItems)
                        txt += item.Text;
                    return txt;
                }
                return "نامشخص";
            }
        }

        [NonPersistent]
        public virtual long CreditAmount
        {
            get
            {
                //return (FinancialDocument.GetPayedBalance(Heading) - EffectivePayableTuition);
                return (FinancialDocument.PayedBalance - EffectivePayableTuition);
            }
        }

        [NonPersistent]
        public virtual int CreditSign
        {
            get
            {
                if (CreditAmount > 0)
                    return 1;
                return 0;
            }
        }
        [NonPersistent]
        public virtual FinancialStatus FinancialStatus
        {
            get
            {
                if (FinancialDocument.ReturnedChequeBalance > 0)
                    return FinancialStatus.ReturnedCheque;
                if (DebtAmount > 0)
                    return FinancialStatus.Debtor;
                if (FinancialDocument.InProgressChequeBalance > 0)
                    return FinancialStatus.ChequePromised;
                if (CreditAmount > 0)
                    return FinancialStatus.Creditor;
                return FinancialStatus.Balanced;
            }
        }

        [NonPersistent]
        public virtual string FarsiFinancialStatusText
        {
            get { return FinancialStatus.ToDescription(); }
        }

        [NonPersistent]
        public virtual string FarsiFinancialStatusVerboseText
        {
            get
            {
                if (FinancialStatus == FinancialStatus.Debtor)
                    return FarsiFinancialStatusText + " (" + Math.Abs(DebtAmount).ToString("C0") + ") ";
                if (FinancialStatus == FinancialStatus.ChequePromised)
                    return FarsiFinancialStatusText + " (" + FinancialDocument.InProgressChequeDatesText + ") ";
                if (FinancialStatus == FinancialStatus.Creditor)
                    return FarsiFinancialStatusText + " (" + Math.Abs(CreditAmount).ToString("C0") + ") ";
                return FarsiFinancialStatusText;
            }
        }

        public virtual string TestAmount
        {
            get
            {
                if (FinancialStatus == FinancialStatus.Debtor)
                    return (-DebtAmount).ToString();
                if (FinancialStatus == FinancialStatus.ChequePromised)
                    return FinancialDocument.InProgressChequeDatesText ;
                if (FinancialStatus == FinancialStatus.Creditor)
                    return  Math.Abs(CreditAmount).ToString();
                return "0";
            }
            set { }
        }
        [NonPersistent]
        public virtual string EnglishFinancialStatusText
        {
            get
            {
                return FinancialStatus.ToString();
            }
        }

        [NonPersistent]
        public virtual string EnglishFinancialStatusVerboseText
        {
            get
            {
                if (FinancialStatus != FinancialStatus.Balanced)
                    return EnglishFinancialStatusText + " (" + Math.Abs(DebtAmount).ToString("C0") + ") ";
                if (FinancialStatus == FinancialStatus.ChequePromised)
                    return EnglishFinancialStatusText + " (" + FinancialDocument.InProgressChequeDatesText + ") ";
                if (FinancialStatus == FinancialStatus.Creditor)
                    return EnglishFinancialStatusText + " (" + Math.Abs(CreditAmount).ToString("C0") + ") ";
                return EnglishFinancialStatusText;
            }
        }

        #endregion
    }
}