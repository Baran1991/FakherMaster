using System;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class CareerApplicant : DbObject
    {
        public virtual long Code { get; set; }
        [Attendant]
        public virtual PersonalInfo PersonalInfo { get; set; }
        [Attendant]
        public virtual EducationalInfo EducationalInfo { get; set; }
        [Attendant]
        public virtual ContactInfo ContactInfo { get; set; }
        public virtual Photo Photo { get; set; }
        [MaximumLength]
        public virtual string Experiences { get; set; }
        public virtual PersianDate Date { get; set; }
        public virtual int Hour { get; set; }
        public virtual int Minute { get; set; }
        public virtual int Second { get; set; }
        [NoCascade]
        public virtual Career Career { get; set; }

        public CareerApplicant()
        {
            PersonalInfo = new PersonalInfo();
            EducationalInfo = new EducationalInfo();
            ContactInfo = new ContactInfo();
            Date = PersianDate.Today;
            Hour = Time.Now.Hour;
            Minute = Time.Now.Minute;
            Second = Time.Now.Second;
        }

        public virtual void GenerateCode()
        {
            DateTime now = DateTime.Now;
            long preNum = now.Ticks % 10000;
            string prefix = preNum.ToString();
            while (prefix.Length < 4)
            {
                int random = new Random().Next(1, 9);
                prefix = random + prefix;
            }

            string number = prefix.Substring(0, 2) + Id.ToString() + prefix.Substring(2, 2);
            long code = Convert.ToInt64(number);
            Code = code;
        }

        [NonPersistent]
        public virtual string SubmitTimeText
        {
            get { return Hour + ":" + Minute + ":" + Second; }
        }

        [NonPersistent]
        public virtual string SubmitDateText
        {
            get { return Date.ToShortDateString(); }
        }

    }
}