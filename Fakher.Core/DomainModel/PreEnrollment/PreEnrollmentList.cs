using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rApplicationEventFramework;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class PreEnrollmentList : DbObject
    {
        public virtual string Name { get; set; }
        [NoCascade]
        public virtual Major Major { get; set; }
        [MaximumLength]
        public virtual string RecieptNote { get; set; }
        public virtual IList<PreEnrollment> PreEnrollments { get; set; }
       
        public virtual PersianDate Date { get; set; }
        public virtual int Hour { get; set; }
        public virtual int Minute { get; set; }
        public virtual bool InternetRegisterable { get; set; }
        public virtual PersianDate InternetRegisterStartDate { get; set; }
        public virtual int InternetRegisterStartHoure { get; set; }
        public virtual int InternetRegisterStartMinute { get; set; }
        public virtual PersianDate InternetRegisterFinishDate { get; set; }
        public virtual int InternetRegisterFinishHoure { get; set; }
        public virtual int InternetRegisterFinishMinute { get; set; }
        public virtual int ClassNo { get; set; }
        public virtual int ClassCa { get; set; }        
        public PreEnrollmentList()
        {
            Date = PersianDate.Today;
            Hour = DateTime.Now.Hour;
            Minute = DateTime.Now.Minute;
            InternetRegisterable = false;
            InternetRegisterStartDate = PersianDate.Today;
            InternetRegisterStartHoure = DateTime.Now.Hour;
            InternetRegisterStartMinute = DateTime.Now.Minute;
            InternetRegisterFinishDate = PersianDate.Today;
            InternetRegisterFinishHoure = 23;
            InternetRegisterFinishMinute = 59;
        }
        [NonPersistent]
        public virtual DateTime InternetRegisterStartDateTime
        {
            get
            {
                DateTime systemDateTime = InternetRegisterStartDate.ToSystemDateTime();
                return new DateTime(systemDateTime.Year, systemDateTime.Month, systemDateTime.Day, InternetRegisterStartHoure, InternetRegisterStartMinute, 0);
            }
        }
        
        [NonPersistent]
        public virtual DateTime InternetRegisterFinishDateTime
        {
            get
            {
                DateTime systemDateTime = InternetRegisterFinishDate.ToSystemDateTime();
                return new DateTime(systemDateTime.Year, systemDateTime.Month, systemDateTime.Day, InternetRegisterFinishHoure, InternetRegisterFinishMinute, 0);
            }
        }
        [NonPersistent]
        public virtual DateTime DateTime
        {
            get
            {
                if (Date != null)
                {
                    DateTime systemDateTime = Date.ToSystemDateTime();
                    return new DateTime(systemDateTime.Year, systemDateTime.Month, systemDateTime.Day, Hour, Minute, 0);
                }
                else
                {
                    return new DateTime();
                }
            }
        }
        [NonPersistent]
        public virtual string Time
        {
            get { return Hour.ToString("D2") + ":" + Minute.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':');

                if (timeItems.Length < 2)
                    throw new ArgumentException();
                Hour = Convert.ToInt32(timeItems[0]);
                Minute = Convert.ToInt32(timeItems[1]);
            }
        }
        [NonPersistent]
        public virtual string InternetRegisterStartTime
        {
            get { return InternetRegisterStartHoure.ToString("D2") + ":" + InternetRegisterStartMinute.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':');

                if (timeItems.Length < 2)
                    throw new ArgumentException();
                InternetRegisterStartHoure = Convert.ToInt32(timeItems[0]);
                InternetRegisterStartMinute = Convert.ToInt32(timeItems[1]);
            }
        }
        [NonPersistent]
        public virtual string InternetRegisterFinishTime
        {
            get { return InternetRegisterFinishHoure.ToString("D2") + ":" + InternetRegisterFinishMinute.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':');

                if (timeItems.Length < 2)
                    throw new ArgumentException();
                InternetRegisterFinishHoure = Convert.ToInt32(timeItems[0]);
                InternetRegisterFinishMinute = Convert.ToInt32(timeItems[1]);
            }
        }
        public override string ToString()
        {
            return Name;
        }
        public static PreEnrollmentList FromId(int id)
        {
            return DbContext.FromId<PreEnrollmentList>(id);
        }
        public static IList<PreEnrollmentList> GetLists(Major major)
        {
            var query = from list in DbContext.Entity<PreEnrollmentList>()
                        where list.Major.Id == major.Id
                        select list;
            return query.ToList();
        }

        public static IList<PreEnrollmentList> GetLists(Department department)
        {
            var query = from list in DbContext.Entity<PreEnrollmentList>()
                        where list.Major.Department.Id == department.Id
                        select list;
            return query.ToList();
        }
        public virtual bool CanRegisterByInternet()
        {


            DateTime now = DateTime.Now;

            return now >= InternetRegisterStartDateTime && now <= InternetRegisterFinishDateTime;


        }
      
    }
}