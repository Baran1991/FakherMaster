using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using DataAccessLayer;
using rComponents;
using System.Linq;

namespace Fakher.Core.DomainModel
{
    public class PayTransaction : DbObject
    {
        public virtual PersianDate StartDate { get; set; }
        public virtual int StartHour { get; set; }
        public virtual int StartMinute { get; set; }
        public virtual int StartSecond { get; set; }
        public virtual PersianDate ConfirmDate { get; set; }
        public virtual int ConfirmHour { get; set; }
        public virtual int ConfirmMinute { get; set; }
        public virtual int ConfirmSecond { get; set; }
        public virtual PersianDate CompleteDate { get; set; }
        public virtual int CompleteHour { get; set; }
        public virtual int CompleteMinute { get; set; }
        public virtual int CompleteSecond { get; set; }
        public virtual PersianDate ReverseDate { get; set; }
        public virtual int ReverseHour { get; set; }
        public virtual int ReverseMinute { get; set; }
        public virtual int ReverseSecond { get; set; }
        public virtual long Amount { get; set; }
        public virtual string Description { get; set; }
        public virtual PayRequestStatus Status { get; set; }
        [NoCascade]
        public virtual Person Person { get; set; }
        public virtual IList<PayTransactionItem> Items { get; set; }

        public PayTransaction()
        {
            Status = PayRequestStatus.Unknown;
            StartDate = PersianDate.Today;
            StartTime = DateTime.Now.ToLongTimeString();
//            Heading = FinancialHeading.Signup;
            Items = new List<PayTransactionItem>();
        }

        [NonPersistent]
        public virtual string StartTime
        {
            get { return StartHour.ToString("D2") + ":" + StartMinute.ToString("D2") + ":" + StartSecond.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':', ' ');

                if (timeItems.Length < 3)
                    throw new ArgumentException();
                StartHour = Convert.ToInt32(timeItems[0]);
                StartMinute = Convert.ToInt32(timeItems[1]);
                StartSecond = Convert.ToInt32(timeItems[2]);
            }
        }

        [NonPersistent]
        public virtual string ConfirmTime
        {
            get { return ConfirmHour.ToString("D2") + ":" + ConfirmMinute.ToString("D2") + ":" + ConfirmSecond.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':', ' ');

                if (timeItems.Length < 3)
                    throw new ArgumentException();
                ConfirmHour = Convert.ToInt32(timeItems[0]);
                ConfirmMinute = Convert.ToInt32(timeItems[1]);
                ConfirmSecond = Convert.ToInt32(timeItems[2]);
            }
        }

        [NonPersistent]
        public virtual string CompleteTime
        {
            get { return CompleteHour.ToString("D2") + ":" + CompleteMinute.ToString("D2") + ":" + CompleteSecond.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':', ' ');

                if (timeItems.Length < 3)
                    throw new ArgumentException();
                CompleteHour = Convert.ToInt32(timeItems[0]);
                CompleteMinute = Convert.ToInt32(timeItems[1]);
                CompleteSecond = Convert.ToInt32(timeItems[2]);
            }
        }

        [NonPersistent]
        public virtual string ReverseTime
        {
            get { return ReverseHour.ToString("D2") + ":" + ReverseMinute.ToString("D2") + ":" + ReverseSecond.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':', ' ');

                if (timeItems.Length < 3)
                    throw new ArgumentException();
                ReverseHour = Convert.ToInt32(timeItems[0]);
                ReverseMinute = Convert.ToInt32(timeItems[1]);
                ReverseSecond = Convert.ToInt32(timeItems[2]);
            }
        }

        [NonPersistent]
        public virtual string StatusText
        {
            get { return Status.ToDescription(); }
        }

//        [NonPersistent]
//        public virtual long Amount
//        {
//            get
//            {
//                if(Items.Count > 0)
//                    return Items.Sum(x => x.Amount);
//                return 0;
//            }
//        }

        public virtual PayTransactionItem AddItem(PayTransactionItemType type, long amount, FinancialDocument document
            , string text, FinancialHeading heading)
        {
            PayTransactionItem item = new PayTransactionItem();
            item.Type = type;
            item.Amount = amount;
            item.FinancialDocument = document;
            item.Text = text;
            item.Heading = heading;

            item.PayTransaction = this;
            Items.Add(item);
            return item;
        }

        protected virtual void BypassCertificateError()
        {
            ServicePointManager.ServerCertificateValidationCallback +=
                delegate(
                    Object sender1,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
        }

        /// <summary>
        /// Id should be initialized with DB before
        /// </summary>
        public virtual void Start(string callbackUrl)
        {
            throw new NotImplementedException();
        }

        public virtual void PreTransfer()
        {
            throw new NotImplementedException();
        }

        public virtual void PostTransfer()
        {
            throw new NotImplementedException();
        }

        public virtual void Complete()
        {
            throw new NotImplementedException();
        }

        public virtual string Inquiry()
        {
            throw new NotImplementedException();
        }

        public virtual void Reverse()
        {
            throw new NotImplementedException();
        }
    }

    public enum PayRequestStatus
    {
        [EnumDescription("نا مشخص")]
        Unknown,
        [EnumDescription("شروع شده")]
        Started,
        [EnumDescription("ارجاع به درگاه پرداخت اینترنتی")]
        PreTransfer,
        [EnumDescription("بازگشت از درگاه پرداخت اینترنتی")]
        PostTransfer,
        [EnumDescription("تایید شده")]
        Verified,
        [EnumDescription("تکمیل شده")]
        Completed,
        [EnumDescription("برگشت شده")]
        Reversed,
    }
}