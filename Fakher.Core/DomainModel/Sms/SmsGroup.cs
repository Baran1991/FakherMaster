using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core
{
    public class SmsGroup : DbObject
    {
        public virtual PersianDate CreateDate { get; set; }
        public virtual int CreateHour { get; set; }
        public virtual int CreateMinute { get; set; }
        public virtual int CreateSecond { get; set; }
        public virtual bool SendByService { get; set; }
        public virtual PersianDate SendDate { get; set; }
        public virtual int SendHour { get; set; }
        public virtual int SendMinute { get; set; }
        public virtual int SendSecond { get; set; }
        [MaximumLength]
        public virtual string Text { get; set; }
        [MaximumLength]
        public virtual string ReceiverText { get; set; }
        public virtual SmsGroupStatus Status { get; set; }
        public virtual IList<Sms> Smses { get; set; }

        public SmsGroup()
        {
            Smses = new List<Sms>();
            Status = SmsGroupStatus.UnKnown;
            CreateDate = PersianDate.Today;
            CreateHour = DateTime.Now.Hour;
            CreateMinute = DateTime.Now.Minute;
            CreateSecond = DateTime.Now.Second;
        }

        [NonPersistent]
        public virtual string SingleLineText
        {
            get
            {
                if(string.IsNullOrEmpty(Text))
                    return String.Empty;
                return Text.Replace("\r\n", " ");
            }
        }

        [NonPersistent]
        public virtual string SingleLineReceiverText
        {
            get
            {
                if (string.IsNullOrEmpty(ReceiverText))
                    return String.Empty;
                return ReceiverText.Replace("\r\n", " ").Replace("\n", " ");
            }
        }

        [NonPersistent]
        public virtual Time SendTime
        {
            get { return new Time {Hour = SendHour, Minute = SendMinute, Second = SendSecond}; }
        }

        public virtual Sms CreateSms()
        {
            Sms sms = new Sms {Group = this};
            return sms;
        }

        public virtual void AddSms(Sms sms)
        {
            Smses.Add(sms);
        }

        public virtual void PrepareForSend(PersianDate date, Time time)
        {
            SendDate = date;
            SendHour = time.Hour;
            SendMinute = time.Minute;
            SendSecond = time.Second;

            SendByService = true;
        }

        public virtual void Sent()
        {
            Status = SmsGroupStatus.Sent;
        }

        #region Static Methods

        public static IQueryable<string> GetAllTexts()
        {
            var query = from smsGroup in DbContext.Entity<SmsGroup>()
                        select smsGroup;
            return query.ToList().Where(x => !String.IsNullOrEmpty(x.Text)).Select(x => x.Text).AsQueryable();
        }

        #endregion
    }

    public enum SmsGroupStatus
    {
        [EnumDescription("نامشخص")]
        UnKnown,
        [EnumDescription("ایجاد شده")]
        Created,
        [EnumDescription("ارسال شده")]
        Sent,
    }
}