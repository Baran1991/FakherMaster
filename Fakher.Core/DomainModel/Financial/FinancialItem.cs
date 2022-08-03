using System;
using System.Linq;
using DataAccessLayer;
using NHibernate.Id;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class FinancialItem : DbObject
    { 
        public virtual PersianDate Date { get; set; }
        public virtual string Text { get; set; }
        public virtual string OnAcountOf { get; set; }
        public virtual long Amount { get; set; }
        public virtual FinancialType Type { get; set; }
        public virtual FinancialHeading Heading { get; set; }
        //        public virtual bool IsClone { get; set; }
        public virtual FinancialItemMode Mode { get; set; }
        public virtual Payment Payment { get; set; }
        [NoCascade]
        public virtual FinancialDocument Document { get; set; }
        [NoCascade]
        public virtual BankAccount BankAccount { get; set; }
        [NoCascade]
        public virtual Person Person { get; set; }
        [NonPersistent]
        public virtual PersianDate CreateDate { get; set; }
        [NonPersistent]
        public virtual Register registerer { get; set; }
        public virtual PersianDate RegisterDocumentDate { get; set; }

        public FinancialItem()
        {
            Date = PersianDate.Today;
            Heading = FinancialHeading.Signup;
            Mode = FinancialItemMode.Enterance;
            IsClone = false;            
        }

        public FinancialItem(FinancialType type) : this()
        {
            Type = type;
        }
        
        [NonPersistent]
        public virtual string Operator
        {
            get
            {
                if(Person!=null)
                return Person.FarsiFullname;
                return "";
            }
        }
       [NonPersistent]
       public virtual PersianDate ItemDate
        {
            get
            {
                if (Payment is Cheque)
                {
                    if((Payment as Cheque).CreateDate!=null)
                    return (Payment as Cheque).CreateDate;
                }
                
                    return Date;
            }
        }

        [NonPersistent]
        public virtual string DescriptionText
        {
            get
            {
                if(Payment != null)
                    return Payment.Description;
                return Text;
            }
        }
        [NonPersistent]
        public virtual string DebtText
        {
            get
            {
                if(Type == FinancialType.Debt)
                    return Amount + "";
                return "";
            }
        }        
        [NonPersistent]
        public virtual string CreditText
        {
            get
            {
                if(Type == FinancialType.Credit)
                    return Amount + "";
                return "";
            }
        }
        [NonPersistent]
        public virtual string FullDescription
        {
            get {return DescriptionText + " (" + HeadingText+")"; }
        }
        [NonPersistent]
        public virtual string HeadingText
        {
            get { return Heading.ToDescription(); }
        }
        [NonPersistent]
        public virtual long Balance
        {
            get
            {
                if (Type == FinancialType.Credit)
                    return Amount;
                return -Amount;
            }
        }
        [NonPersistent]
        public virtual bool IsPaying
        {
            get { return Payment != null && !(Payment is Discount); }
        }
        [NonPersistent]
        public virtual bool IsDiscount
        {
            get { return Payment != null && Payment is Discount; }
        }
        [NonPersistent]
        public virtual string StatusText
        {
            get
            {
                if (Payment is Cheque)
                {
                    var cheque = Payment as Cheque;
                    return cheque.StatusText;
                }
                else if (Payment is Receipt)
                {
                    var pay = Payment as Receipt;
                    return pay.Status.ToDescription();
                        }
                else
                {
                    return "";
                }
            }
        }

       [NonPersistent]
        public virtual long CashAmount
        {
            get
            {
                if (IsPaying && Payment is Cash)
                    return Amount;
                return 0;
            }
        }
        [NonPersistent]
        public virtual long ReceiptAmount
        {
            get
            {
                if (IsPaying && Payment is Receipt)
                    return Amount;
                return 0;
            }
        }
        [NonPersistent]
        public virtual long EPaymentAmount
        {
            get
            {
                if (IsPaying && Payment is ElectronicPayment)
                    return Amount;
                return 0;
            }
        }
        [NonPersistent]
        public virtual long ChequeAmount
        {
            get
            {
                if (IsPaying && Payment is Cheque)
                    return Amount;
                return 0;
            }
        }
        [NonPersistent]
        public virtual long PassedChequeAmount
        {
            get
            {
                if (IsPaying && Payment is Cheque && (Payment as Cheque).Status == ChequeStatus.Passed)
                    return Amount;
                return 0;
            }
        }
        [NonPersistent]
        public virtual long ReturnedChequeAmount
        {
            get
            {
                if (IsPaying && Payment is Cheque && (Payment as Cheque).Status == ChequeStatus.Returned)
                    return Amount;
                return 0;
            }
        }
        [NonPersistent]
        public virtual long InProgressChequeAmount
        {
            get
            {
                if (IsPaying && Payment is Cheque && (Payment as Cheque).Status == ChequeStatus.InProgress)
                    return Amount;
                return 0;
            }
        }
        [NonPersistent]
        public virtual long SuspendedChequeAmount
        {
            get
            {
                if (IsPaying && Payment is Cheque && (Payment as Cheque).Status == ChequeStatus.Suspended)
                    return Amount;
                return 0;
            }
        }
        [NonPersistent]
        public virtual string TypeText
        {
            get { return Type.ToDescription(); }
        }
        [NonPersistent]
        public virtual string AmountText
        {
            get { return Amount.ToString("C0"); }
        }

        public virtual bool Is<T>() where T : Payment
        {
            return Payment is T;
        }

        public override string ToString()
        {
            return DescriptionText;
        }

        public virtual FinancialItem Clone()
        {
            FinancialItem item = Services.Clone(this);
            item.Date = Date;
            item.IsClone = true;
            item.Text = "کپی از " + Id;
            if(Payment != null)
            {
                Payment payment = Payment.Clone();
                item.Payment = payment;
                payment.Item = item;
            }
            return item;
        }

        #region Static Members

        public static IQueryable<FinancialItem> GetFinancialItem(PersianDate startDate, PersianDate endDate)
        {
            var query = from item in DbContext.Entity<FinancialItem>()
                        where item.Date >= startDate
                              && item.Date <= endDate
                        select item;
            return query;
        }

        public static IQueryable<FinancialItem> GetIssuedFinancialItem(PersianDate startDate, PersianDate endDate)
        {
            var query = from item in DbContext.Entity<FinancialItem>()
                        where item.Date >= startDate
                              && item.Date <= endDate
                              && item.Mode == FinancialItemMode.Issued
                        select item;
            return query;
        }
        #endregion
    }

    public enum FinancialType
    {
        [EnumDescription("کسورات/بدهکار")]
        Debt,
        [EnumDescription("پرداخت/بستانکار")]
        Credit,
    }
    public enum FinancialHeading
    {
        [EnumDescription("تسویه شهریه")]
        Signup,
        [EnumDescription("ما به التفاوت شهریه")]
        TuitionDifference,
        [EnumDescription("ما به التفاوت پرداخت")]
        PayDifference,
        [EnumDescription("فروش کتاب")]
        ToolSell,
        [EnumDescription("صدور کارت")]
        IdCard,
        [EnumDescription("تسویه حساب پرسنل")]
        EmployeePayOff,
        [EnumDescription("انصراف")]
        Quit,
        [EnumDescription("انتقال")]
        Transition,
        [EnumDescription("مصاحبه داخلی")]
        InternalOralExam,
        [EnumDescription("مصاحبه آنلاین")]
        OnlineOramExam,
        [EnumDescription("مصاحبه مجدد")]
        SecondOramExam,
        [EnumDescription("ثبت نام آزمون")]
        ExamSignup,
        [EnumDescription("ثبت نام رزرو")]
        ReserveSignup,
        [EnumDescription("ثبت نام تعیین سطح")]
        LevelDeterminationSignup,
        [EnumDescription("صدور گواهی")]
        ProofDocument,
        [EnumDescription("صدور مدرک")]
        Certificate,
        [EnumDescription("مرخصی")]
        Vacation,
        [EnumDescription("تعیین سطح")]
        Placement,
        [EnumDescription("انتقال")]
        Transfer,
        [EnumDescription("آزمون مجدد")]
        SecondExam,
        [EnumDescription("پرداخت علی الحساب")]
        AlalHesab,
        //[EnumDescription("تسویه شهریه")]
        //TuitionPayOff
        [EnumDescription("لحاظ شهریه")]
        PaidTution
    }

    public enum FinancialPolicy
    {
        [EnumDescription("مستقیم")]
        StraightForward,
        [EnumDescription("اعتباری")]
        Creditor,
    }

    public enum FinancialItemMode
    {
        [EnumDescription("ورودی")]
        Enterance,
        [EnumDescription("صادر شده")]
        Issued,
    }
}