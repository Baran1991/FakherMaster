using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;
using System;
using NHibernate.Linq;
using System.Threading.Tasks;

namespace Fakher.Core.DomainModel
{
    public class PreEnrollment : DbObject
    {
        public virtual Person Student { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Province { get; set; }
        public virtual string City { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual PersianDate Date { get; set; }
        public virtual int Hour { get; set; }
        public virtual int Minute { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual PersianDate ContactDate { get; set; }
        public virtual int ContactHour { get; set; }
        public virtual int ContactMinute { get; set; }
        public virtual ContactStatus Status { get; set; }
        public virtual PersianDate LastUpdateDate { get; set; }
        public virtual bool InternetRegisteration { get; set; }
        [NoCascade]
        public virtual PreEnrollmentList PreEnrollmentList { get; set; }

        public PreEnrollment()
        {
            Date = PersianDate.Today;
            Hour = DateTime.Now.Hour;
            Minute = DateTime.Now.Minute;
            InternetRegisteration = false;
        }

        [NonPersistent]
        public virtual string StatusText
        {
            get
            {
                return Status.ToDescription();
            }
        }

        [NonPersistent]
        public virtual string RegisterationTypeText
        {
            get
            {
                if (InternetRegisteration)
                    return "اینترنتی";
                return "حضوری";
            }
        }

        [NonPersistent]
        public virtual string RegisterDateTime
        {
            get { return Date + " " + Hour + ":" + Minute; }
        }

        [NonPersistent]
        public virtual String Fullname
        {
            get { return FirstName + " " + LastName; }
        }

        public virtual string GetPreEnrollmentSmsText()
        {
            return "پیش ثبت نام شما با موفقیت ثبت گردید.\nموسسه فاخر";
        }
        public static long GetPreEnrollmentsCount(ContactStatus status)
        {
            var query = from preEnrollments in DbContext.Entity<PreEnrollment>()
                        where preEnrollments.Status==status
                        select preEnrollments;
            return  query.Count();
        }
        public static long GetPreEnrollmentsCount(PreEnrollmentList pre)
        {
            var query = from preEnrollments in DbContext.Entity<PreEnrollment>()
                        where preEnrollments.PreEnrollmentList == pre
                        select preEnrollments;
            return query.Count();
        }
        public static IList<PreEnrollment> GetPreEnrollments()
        {
            var query = from preEnrollments in DbContext.Entity<PreEnrollment>()
                        orderby preEnrollments.Date
                        select preEnrollments;
            return query.ToList();
        }

        public static IQueryable<PreEnrollment> GetPreEnrollments(IList<PreEnrollment> preEnrollmentList, ContactStatus status)
        {
            var query = from preEnrollments in preEnrollmentList
                        where preEnrollments.Status == status
                        orderby preEnrollments.Date
                        select preEnrollments;
            return query.AsQueryable();
        }

        public static PreEnrollment FromStudent(Student student)
        {
            PreEnrollment preEnrollment = new PreEnrollment();
            preEnrollment.FirstName = student.FarsiFirstName;
            preEnrollment.LastName = student.FarsiLastName;
            preEnrollment.Province = student.ContactInfo.Province;
            preEnrollment.City = student.ContactInfo.City;
            preEnrollment.Phone = student.ContactInfo.Mobile;
            preEnrollment.Email = student.UserInfo.Email ?? student.ContactInfo.Email;

            return preEnrollment;
        }

        public enum ContactStatus
        {
            [EnumDescription("در انتظار رسیدگی")]
            Waiting,
            [EnumDescription("تمــاس موفـــــق")]
            ContactMade,
            [EnumDescription("تمـاس بدون پـاسخ")]
            NoAnswerContact,
        }
    }
}