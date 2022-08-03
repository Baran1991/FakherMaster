using System;
using System.Collections.Generic;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;
using System.Linq;

namespace Fakher.Core.Website
{
    public class EnrollmentLicense : DbObject
    {
        public virtual EnrollmentLicenseType LicenseType { get; set; }
        public virtual EnrollmentLicenseParticipantType ParticipantType { get; set; }
        [NoCascade]
        public virtual Major Major { get; set; }
        [NoCascade]
        public virtual Lesson Lesson { get; set; }
        [NoCascade]
        public virtual EducationalPeriod EducationalPeriod { get; set; }
        public virtual PersianDate StartDate { get; set; }
        public virtual int StartHour { get; set; }
        public virtual int StartMinute { get; set; }
        public virtual PersianDate EndDate { get; set; }
        public virtual int EndHour { get; set; }
        public virtual int EndMinute { get; set; }
        public virtual string Description { get; set; }
//        public virtual bool NewSignup { get; set; }
//        public virtual bool ExistingRegisterSignup { get; set; }
//        public virtual bool CanChange { get; set; }

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

        [NonPersistent]
        public virtual string LicenseTypeText
        {
            get { return LicenseType.ToDescription(); }
        }

        [NonPersistent]
        public virtual string ParticipantTypeText
        {
            get { return ParticipantType.ToDescription(); }
        }

        [NonPersistent]
        public virtual bool HasLesson
        {
            get
            {
                return ParticipantType == EnrollmentLicenseParticipantType.LessonStudents
                       || ParticipantType == EnrollmentLicenseParticipantType.LessonBalancedStudents
                       || ParticipantType == EnrollmentLicenseParticipantType.LessonDebtorStudents;
            }
        }

        [NonPersistent]
        public virtual string EnrollText
        {
            get
            {
                string txt = Major.Name + " - تــرم " + EducationalPeriod.Name;
                if (HasLesson)
                    txt += " - درس/سطــح " + Lesson + "";
                return txt;
            }
        }

        public virtual bool CanEnroll(Student student)
        {
            if (ParticipantType == EnrollmentLicenseParticipantType.AllStudents)
                return true;
            if (ParticipantType == EnrollmentLicenseParticipantType.BalancedStudents)
                return student.FinancialStatus == FinancialStatus.Balanced;
            if (ParticipantType == EnrollmentLicenseParticipantType.DebtorStudents)
                return student.FinancialStatus == FinancialStatus.Debtor;

            // baghiye mishe agar lesson dasht:
            return true;
        }

        public virtual bool CanEnrollIn(Lesson lesson)
        {
            if (HasLesson)
                return lesson.Id == Lesson.Id;
            return true;
        }

        public static IList<EnrollmentLicense> GetEnrollmentLicenses(EducationalPeriod period)
        {
            var query = from enrollmentLicense in DbContext.Entity<EnrollmentLicense>()
                        where enrollmentLicense.EducationalPeriod.Id == period.Id
                        select enrollmentLicense;
            return query.ToList();
        }

        public static IList<EnrollmentLicense> GetEnrollmentLicenses(EnrollmentLicenseType type, PersianDate date, int hour, int minute)
        {
            DateTime nowDateTime = date.ToSystemDateTime();
            DateTime now = new DateTime(nowDateTime.Year, nowDateTime.Month, nowDateTime.Day, hour, minute, 0);

            var query = from period in DbContext.Entity<EducationalPeriod>()
                        from license in period.EnrollmentLicenses
                        where license.LicenseType == type
                        select license;
            List<EnrollmentLicense> licenses = query.ToList();
            var query2 = from license in licenses
                         where now >= license.StartDateTime && now <= license.EndDateTime
                         select license;
            return query2.ToList();

//            var query = from period in DbContext.Entity<EducationalPeriod>()
//                        from license in period.EnrollmentLicenses
//                        where (date > license.StartDate && date < license.EndDate)
//                              || (date == license.StartDate && ((hour > license.StartHour)
//                                                                ||
//                                                                (hour == license.StartHour &&
//                                                                 minute >= license.StartMinute)))
//                              || (date == license.EndDate && ((hour < license.EndHour)
//                                                              ||
//                                                              (hour == license.EndHour && minute <= license.EndMinute)))
//                        select license;
//            return query.ToList();
        }

        public static EnrollmentLicense FromId(int id)
        {
            return DbContext.FromId<EnrollmentLicense>(id);
        }
    }

    public enum EnrollmentLicenseParticipantType
    {
        [EnumDescription("همه دانشجویان")]
        AllStudents,
        [EnumDescription("همه دانشجویان تسویه")]
        BalancedStudents,
//        [EnumDescription("همه دانشجویان بستانکار")]
//        CreditorStudents,
        [EnumDescription("همه دانشجویان بدهکار")]
        DebtorStudents,
//        [EnumDescription("همه دانشجویان رشتـه")]
//        MajorStudents,
//        [EnumDescription("دانشجویان تسویه رشتـه")]
//        MajorBalancedStudents,
//        [EnumDescription("دانشجویان بستانکار رشته")]
//        MajorCreditorStudents,
//        [EnumDescription("دانشجویان بدهکار رشته")]
//        MajorDebtorStudents,
        [EnumDescription("همه دانشجویان درس/سطح")]
        LessonStudents,
        [EnumDescription("دانشجویان تسویه درس/سطح")]
        LessonBalancedStudents,
//        [EnumDescription("دانشجویان بستانکار درس/سطح")]
//        LessonCreditorStudents,
        [EnumDescription("دانشجویان بدهکار درس/سطح")]
        LessonDebtorStudents,
    }

    public enum EnrollmentLicenseType
    {
        [EnumDescription("ثبت نام کلاسـی")]
        SectionEnrollment,
        [EnumDescription("ثبت نام دانشجو جدید در موسسه")]
        NewStudentEnrollment,
        [EnumDescription("ثبت نام در آزمون")]
        ExamEnrollment,
//        [EnumDescription("همه دانشجویان")]
//        AllStudents,
//        [EnumDescription("همه دانشجویان تسویه")]
//        BalancedStudents,
//        [EnumDescription("همه دانشجویان بستانکار")]
//        CreditorStudents,
//        [EnumDescription("همه دانشجویان بدهکار")]
//        DebtorStudents,
//        [EnumDescription("همه دانشجویان رشتـه")]
//        MajorStudents,
//        [EnumDescription("دانشجویان تسویه رشتـه")]
//        MajorBalancedStudents,
//        [EnumDescription("دانشجویان بستانکار رشته")]
//        MajorCreditorStudents,
//        [EnumDescription("دانشجویان بدهکار رشته")]
//        MajorDebtorStudents,
//        [EnumDescription("همه دانشجویان درس/سطح")]
//        LessonStudents,
//        [EnumDescription("دانشجویان تسویه درس/سطح")]
//        LessonBalancedStudents,
//        [EnumDescription("دانشجویان بستانکار درس/سطح")]
//        LessonCreditorStudents,
//        [EnumDescription("دانشجویان بدهکار درس/سطح")]
//        LessonDebtorStudents,
    }
}