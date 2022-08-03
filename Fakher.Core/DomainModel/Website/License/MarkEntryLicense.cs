using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.Core.Website
{
    public class MarkEntryLicense : DbObject
    {
        public virtual string EntryCode { get; set; }
        [NoCascade]
        public virtual Major Major { get; set; }
        [NoCascade]
        public virtual Lesson Lesson { get; set; }
        [NoCascade]
        public virtual EducationalPeriod EducationalPeriod { get; set; }
        [NoCascade]
        public virtual EvaluationItem EvaluationItem { get; set; }
        public virtual PersianDate StartDate { get; set; }
        public virtual int StartHour { get; set; }
        public virtual int StartMinute { get; set; }
        public virtual PersianDate EndDate { get; set; }
        public virtual int EndHour { get; set; }
        public virtual int EndMinute { get; set; }

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

        public override string ToString()
        {
            return EvaluationItem.Name;
        }

        public static string GenerateCode()
        {
            DateTime now = DateTime.Now;
            long num = now.Ticks % 1000000;
            string code = num.ToString();
            while (code.Length < 6)
            {
                int random = new Random().Next(1, 9);
                code = random + code;
            }

            return code;
        }

        public static IList<MarkEntryLicense> GetMarkEntryLicenses(PersianDate date, int hour, int minute)
        {
            DateTime nowDateTime = date.ToSystemDateTime();
            DateTime now = new DateTime(nowDateTime.Year, nowDateTime.Month, nowDateTime.Day, hour, minute, 0);

            var query = from license in DbContext.Entity<MarkEntryLicense>()
                        where date >= license.StartDate
                        select license;
            List<MarkEntryLicense> licenses = query.ToList();

            var query2 = from license in licenses
                         where now >= license.StartDateTime && now <= license.EndDateTime
                         select license;
            return query2.ToList();
        }

        public static MarkEntryLicense FromId(int id)
        {
            return DbContext.FromId<MarkEntryLicense>(id);
        }
    }
}