using System;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Presence : DbObject
    {
        public Presence()
        {
            Date = PersianDate.Today;
            
        }

        public virtual PersianDate Date { get; set; }
        public virtual int StartHour { get; set; }
        public virtual int StartMinute { get; set; }
        public virtual int EndHour { get; set; }
        public virtual int EndMinute { get; set; }
        [NoCascade]
        public virtual Person Person { get; set; }
        [NoCascade]
        public virtual SectionItem SectionItem { get; set; }

        [NonPersistent]
        public virtual string StartTime
        {
            get { return StartHour.ToString("D2") + ":" + StartMinute.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':');

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
                string[] timeItems = value.Split(':');

                if (timeItems.Length < 2)
                    throw new ArgumentException();
                EndHour = Convert.ToInt32(timeItems[0]);
                EndMinute = Convert.ToInt32(timeItems[1]);
            }
        }

        [NonPersistent]
        public virtual TimeSpan Duration
        {
            get
            {
                return new TimeSpan(EndHour, EndMinute, 0) - new TimeSpan(StartHour, StartMinute, 0);
            }
        }

        [NonPersistent]
        public virtual int StartTimeInMinutes
        {
            get
            {
                return (StartHour * 60) + StartMinute;
                
            }
        }

        [NonPersistent]
        public virtual int EndTimeInMinutes
        {
            get
            {
                return (EndHour * 60) + EndMinute;
            }
        }

    }
}