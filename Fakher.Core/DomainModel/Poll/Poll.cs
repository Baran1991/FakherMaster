using System;
using System.Collections;
using System.Collections.Generic;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel.Poll
{
    public class Poll : DbObject
    {
        public virtual string Name { get; set; }
        public virtual string Text { get; set; }
        public virtual PersianDate StartDate { get; set; }
        public virtual int StartHour { get; set; }
        public virtual int StartMinute { get; set; }
        public virtual bool HasEnd { get; set; }
        public virtual PersianDate EndDate { get; set; }
        public virtual int EndHour { get; set; }
        public virtual int EndMinute { get; set; }
        public virtual IList<PollItem> Items { get; set; }

        public Poll()
        {
            Items = new List<PollItem>();
            HasEnd = true;
        }

        [NonPersistent]
        public virtual string StartDateText
        {
            get
            {
                return StartDate.ToShortDateString();
            }
        }
        [NonPersistent]
        public virtual string StartTime
        {
            get { return StartHour.ToString("D2") + ":" + StartMinute.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':', ' ');

                if (timeItems.Length < 2)
                    throw new ArgumentException();
                StartHour = Convert.ToInt32(timeItems[0]);
                StartMinute = Convert.ToInt32(timeItems[1]);
            }
        }
        [NonPersistent]
        public virtual string EndTime
        {
            get { return EndHour.ToString("D2") + ":" + EndMinute.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':', ' ');

                if (timeItems.Length < 2)
                    throw new ArgumentException();
                EndHour = Convert.ToInt32(timeItems[0]);
                EndMinute = Convert.ToInt32(timeItems[1]);
            }
        }
        [NonPersistent]
        public virtual DateTime StartDateTime
        {
            get
            {
                DateTime systemDateTime = StartDate.ToSystemDateTime();
                return new DateTime(systemDateTime.Year, systemDateTime.Month, systemDateTime.Day, StartHour, StartMinute, 0);
            }
        }
        [NonPersistent]
        public virtual DateTime EndDateTime
        {
            get
            {
                DateTime systemDateTime = EndDate.ToSystemDateTime();
                return new DateTime(systemDateTime.Year, systemDateTime.Month, systemDateTime.Day, EndHour, EndMinute, 0);
            }
        }
        public virtual bool CanViewPoll()
        {


            DateTime now = DateTime.Now;

            return now >= StartDateTime && now <= EndDateTime;


        }
        [NonPersistent]
        public virtual string EndDateText
        {
            get
            {
                if (!HasEnd)
                    return "ندارد";
                return EndDate.ToShortDateString();
            }
        }

        #region Static Methods

        public static Poll FromId(int id)
        {
            return DbContext.FromId<Poll>(id);
        }

        public static IList<Poll> GetAllPolls()
        {
            return DbContext.GetAllEntities<Poll>();
        }

        #endregion

    }
}