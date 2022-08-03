using System;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core
{
    public class Sms : DbObject
    {
        public virtual string Code { get; set; }
        public virtual PersianDate CreateDate { get; set; }
        public virtual int CreateHour { get; set; }
        public virtual int CreateMinute { get; set; }
        public virtual int CreateSecond { get; set; }
        public virtual PersianDate SendDate { get; set; }
        public virtual int SendHour { get; set; }
        public virtual int SendMinute { get; set; }
        public virtual int SendSecond { get; set; }
        public virtual string Number { get; set; }
        public virtual SmsStatus Status { get; set; }
        [NoCascade]
        public virtual SmsGroup Group { get; set; }

        public Sms()
        {
            CreateDate = PersianDate.Today;
            CreateHour = DateTime.Now.Hour;
            CreateMinute = DateTime.Now.Minute;
            CreateSecond = DateTime.Now.Second;
            Status = SmsStatus.UnKnown;
        }

        public virtual void Sent(string code)
        {
            Code = code;

            SendDate = PersianDate.Today;
            SendHour = DateTime.Now.Hour;
            SendMinute = DateTime.Now.Minute;
            SendSecond = DateTime.Now.Second;

            if (Code.ToLower().Contains("invalid") || Code.ToLower().Contains("empty"))
                Status = SmsStatus.Failed;
            else
                Status = SmsStatus.Sent;
        }
    }

    public enum SmsStatus
    {
        [EnumDescription("نامشخص")]
        UnKnown,
        [EnumDescription("خطا")]
        Failed,
        [EnumDescription("ارسال شده")]
        Sent,
        [EnumDescription("رسیده شده")]
        Delivered,
    }
}