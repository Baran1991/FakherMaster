using System;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Transition : DbObject
    {
        public Transition()
        {
            Date = PersianDate.Today;
            Hour = Time.Now.Hour;
            Minute = Time.Now.Minute;
            FinancialItem = new FinancialItem { Heading = FinancialHeading.Transition};
            Status = TransitionStatus.InProgress;
        }

        public virtual int Code { get; set; }
        public virtual PersianDate Date { get; set; }
        public virtual int Hour { get; set; }
        public virtual int Minute { get; set; }
        public virtual string Reason { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual TransitionStatus Status { get; set; }
        public virtual bool ReturnByCheque { get; set; }
        public virtual bool ReturnByEpayment { get; set; }
        public virtual string ReturnedCardNumber { get; set; }
        [NoCascade]
        public virtual Person Person { get; set; }
        /// <summary>
        /// مقداری که کسر کرده ایم برای خودمان یعنی همان درآمد از انصرافی ها
        /// </summary>
        public virtual long PenaltyFee { get; set; }
        /// <summary>
        /// احتمالا مقدار پولی هست که به شخص بازگردانده می شود
        /// </summary>
        public virtual FinancialItem FinancialItem { get; set; }
        // یعنی مجموع penalty و item با هم می شود همان مقدار شهریه ثبت نامی که اول داده است


        [NonPersistent]
        public virtual string StatusText
        {
            get { return Status.ToDescription(); }
        }

        public override string ToString()
        {
            return string.Format("انتقال به علت [{0}]", Reason);
        }
        [NonPersistent]
        public virtual string BranchName
        {
            get { return Branch.Name; }
        }
        public virtual Transition Clone()
        {
            Transition clone = Services.Clone<Transition>(this);
            clone.Date = Date.Clone();
            clone.FinancialItem = FinancialItem.Clone();
            return clone;
        }
        //[NonPersistent]
        //public virtual string LessonName
        //{
        //    get { return Register.parti}
        //}
        public override void BeforeSave()
        {
            var query = from Transition in DbContext.Entity<Transition>()
                        orderby Transition.Code descending
                        select Transition;

            int num = 1001;
            if (query.Count() > 0)
            {
                Transition first = query.First();
                num = first.Code + 1;
            }
            Code =  num;
        }
    }

    public enum TransitionStatus
    {
        [EnumDescription("در دست اقدام")]
        InProgress,
        [EnumDescription("صادر شده")]
        Issued,
        [EnumDescription("تحویل شده")]
        Delivered,
    }
}