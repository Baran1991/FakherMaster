using System;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Quit : DbObject
    {
        public Quit()
        {
            Date = PersianDate.Today;
            RefundDate = PersianDate.Today;
            Hour = Time.Now.Hour;
            Minute = Time.Now.Minute;
            FinancialItem = new FinancialItem { Heading = FinancialHeading.Quit};
            Status = QuitStatus.InProgress;
        }

        public virtual int Code { get; set; }
        public virtual PersianDate Date { get; set; }
        public virtual PersianDate RefundDate { get; set; }
        public virtual int Hour { get; set; }
        public virtual int Minute { get; set; }
        public virtual string Reason { get; set; }
        public virtual QuitStatus Status { get; set; }
        public virtual bool ReturnByCheque { get; set; }
        public virtual bool ReturnByEpayment { get; set; }
        public virtual string ReturnedCardNumber { get; set; }
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
            return string.Format("انصراف به علت [{0}]", Reason);
        }

        public virtual Quit Clone()
        {
            Quit clone = Services.Clone<Quit>(this);
            clone.Date = Date.Clone();
            clone.FinancialItem = FinancialItem.Clone();
            return clone;
        }

        public override void BeforeSave()
        {
            var query = from quit in DbContext.Entity<Quit>()
                        orderby quit.Code descending
                        select quit;

            int num = 1001;
            if (query.Count() > 0)
            {
                Quit first = query.First();
                num = first.Code + 1;
            }
            Code =  num;
        }
    }

    public enum QuitStatus
    {
        [EnumDescription("در دست اقدام")]
        InProgress,
        [EnumDescription("صادر شده")]
        Issued,
        [EnumDescription("تحویل شده")]
        Delivered,
    }
}