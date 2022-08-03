using System;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class OnlineExamHolding : ExamHolding
    {
        public virtual int StartHour { get; set; }
        public virtual int StartMinute { get; set; }
        public virtual int EndHour { get; set; }
        public virtual int EndMinute { get; set; }
        public virtual bool HasDuration { get; set; }
        public virtual int Duration { get; set; }

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
                DateTime startSystemDateTime = StartDate.ToSystemDateTime();
                return new DateTime(startSystemDateTime.Year, startSystemDateTime.Month, startSystemDateTime.Day, StartHour, StartMinute, 0);
            }
        }

        [NonPersistent]
        public virtual DateTime EndDateTime
        {
            get
            {
                DateTime endSystemDateTime = EndDate.ToSystemDateTime();
                return new DateTime(endSystemDateTime.Year, endSystemDateTime.Month, endSystemDateTime.Day, EndHour, EndMinute, 0);
            }
        }

        [NonPersistent]
        public override string FormationText
        {
            get 
            { 
                string text = "";
                text += StartDate.ToShortDateString();
                if (HasEnd && EndDate != null && EndDate != StartDate)
                    text += " تا " + EndDate.ToShortDateString();
                text += " - ";
                text += StartTime;
                text += " تا " + EndTime;

                return text;
            }
        }

//        public virtual bool CanParticipation(PersianDate date, int hour, int minute)
//        {
//            DateTime nowSystemDateTime = date.ToSystemDateTime();
//            DateTime startSystemDateTime = StartDate.ToSystemDateTime();
//            DateTime endSystemDateTime = EndDate.ToSystemDateTime();
//            
//            DateTime now = new DateTime(nowSystemDateTime.Year, nowSystemDateTime.Month, nowSystemDateTime.Day, hour, minute, 0);
//            DateTime startDateTime = new DateTime(startSystemDateTime.Year, startSystemDateTime.Month, startSystemDateTime.Day, StartHour, StartMinute, 0);
//            DateTime endDateTime = new DateTime(endSystemDateTime.Year, endSystemDateTime.Month, endSystemDateTime.Day, EndHour, EndMinute, 0);
//
//            if (HasEnd)
//                return now >= startDateTime && now <= endDateTime;
//
//            return now >= startDateTime;
//        }
    }
}