using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.Core.Website
{
    public class ReportCardLicense
    {
        public virtual PersianDate StartDate { get; set; }
        public virtual int StartHour { get; set; }
        public virtual int StartMinute { get; set; }
        public virtual bool ShowEducationalReportCard { get; set; }
        public virtual IList<Exam> Exams { get; set; }
        [NoCascade]
        public virtual EducationalPeriod EducationalPeriod { get; set; }
        [NoCascade]
        public virtual Major Major { get; set; }

        public ReportCardLicense()
        {
            Exams = new List<Exam>();
        }

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
        public virtual string ShowEducationalReportCardText
        {
            get
            {
                if (ShowEducationalReportCard)
                    return "دارد";
                return "ندارد";
            }
        }

        [NonPersistent]
        public virtual string ExamsText
        {
            get
            {
                string txt = "";
                foreach (Exam exam in Exams)
                {
                    txt += exam.Name;
                    if (Exams.IndexOf(exam) != Exams.Count - 1)
                        txt += " - ";
                }
                return txt;
            }
        }

//        public static IList<ReportCardLicense> GetReportCardLicenses(PersianDate date, int hour, int minute)
//        {
//            var query = from period in DbContext.Entity<EducationalPeriod>()
//                        from license in period.ReportCardLicenses
//                        where date >= license.StartDate
//                              && (hour > license.StartHour 
//                                    || (hour == license.StartHour && minute >= license.StartMinute))
//                        select license;
//            return query.ToList();
//        }

//        public static bool CanViewReportCard(PersianDate date, int hour, int minute, EducationalPeriod currentPeriod)
//        {
//            var query = from period in DbContext.Entity<EducationalPeriod>()
//                        from license in period.ReportCardLicenses
//                        where period.Id == currentPeriod.Id
//                            && date >= license.StartDate
//                              && (hour > license.StartHour 
//                                    || (hour == license.StartHour && minute >= license.StartMinute))
//                        select license;
//            return query.Count() > 0;
//        }

//        public static bool CanViewReportCard(PersianDate date, int hour, int minute, Exam currentExam)
//        {
//            int id = currentExam.Id;
//            var query = from period in DbContext.Entity<EducationalPeriod>()
//                        from license in period.ReportCardLicenses
//                        from exam in license.Exams
//                        where exam.Id == id
//                            && date >= license.StartDate
//                              && (hour > license.StartHour 
//                                    || (hour == license.StartHour && minute >= license.StartMinute))
//                        select license;
//            return query.Count() > 0;
//        }
    }
}