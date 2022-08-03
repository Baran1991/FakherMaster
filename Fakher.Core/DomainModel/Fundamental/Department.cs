using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Fakher.Core.Website;
using NHibernate;
using rApplicationEventFramework;
using rComponents;

namespace Fakher.Core.DomainModel
{
    [EventClass("دپارتمان")]
    public class Department : DbObject, IMessageReceiver
    {
        [EventClassProperty("کد دپارتمان", "0")]
        public virtual int Code { get; set; }
        [EventClassProperty("نام دپارتمان", null)]
        public virtual string Name { get; set; }
        public virtual string RegisterExpression { get; set; }
        public virtual Language ReportLanguage { get; set; }
        public virtual bool ShowSignupReceiptEducationalEvents { get; set; }
        public virtual IList<Major> Majors { get; set; }
        public virtual IList<EducationalPeriod> EducationalPeriods { get; set; }
        public virtual IList<Person> AllowedPersons { get; set; }
        public virtual IList<ResponsiblePerson> ResponsiblePersons { get; set; }
        public virtual IList<DepartmentPage> DepartmentPages { get; set; }

        public Department()
        {
            Code = 1;
            ReportLanguage = Language.Farsi;
            Majors = new List<Major>();
            EducationalPeriods = new List<EducationalPeriod>();
            AllowedPersons = new List<Person>();
            ResponsiblePersons = new List<ResponsiblePerson>();
            DepartmentPages = new List<DepartmentPage>();
        }

        [NonPersistent]
        public virtual string MessageAddress
        {
            get { return "[" + Name + "]"; }
        }

        #region Static Members

        public static Department FromName(string name)
        {
            var query = from department in DbContext.Entity<Department>()
                        where department.Name == name
                        select department;
            return query.FirstOrDefault();
        }

        public static int GetNextCode()
        {
            var query = from dept in DbContext.Entity<Department>() orderby dept.Code descending select dept;
            Department department = query.FirstOrDefault();
            if (department == null)
                return 1;
            return department.Code + 1;
        }

        public static IList<Department> GetDepartments()
        {
            return DbContext.GetAllEntities<Department>();
        }

        public static Department FromId(object id)
        {
            return DbContext.FromId<Department>(id);
        }

        #endregion

        public override string ToString()
        {
            return Name;
        }
        public virtual bool CanDelete()
        {

            if (this.EducationalPeriods.Any())
                return false;
            if (this.Majors.Any())
                return false;

            if (this.DepartmentPages.Any())
                return false;
            if (this.ResponsiblePersons.Any())
                return false;
            if (this.AllowedPersons.Any())
                return false;
            return true;
        }
        public virtual EducationalPeriod GetProperPeriod()
        {
            EducationalPeriod properPeriod = null;
            bool found = false;
            if (EducationalPeriods.Count > 0)
            {
                properPeriod = EducationalPeriods.Last();
                foreach (EducationalPeriod period in EducationalPeriods)
                {
                    PersianDate today = PersianDate.Today;
                    if (today >= period.StartDate && today <= period.EndDate)
                    {
                        properPeriod = period;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    TimeSpan lastTimeSpan = new TimeSpan(730, 0, 0, 0);
                    foreach (EducationalPeriod period in EducationalPeriods)
                    {
                        PersianDate today = PersianDate.Today;

                        TimeSpan timeSpan = period.StartDate - today;
                        if (timeSpan >= new TimeSpan() && timeSpan <= lastTimeSpan)
                        {
                            properPeriod = period;
                            lastTimeSpan = timeSpan;
                        }
                    }
                }
            }
            return properPeriod;
        }

        public virtual string BuildRegisterExpression(Register register)
        {
            if (string.IsNullOrEmpty(RegisterExpression))
                return register.Major.Name;

            string txt = RegisterExpression;
            txt = txt.Replace("{نام رشته}", register.Major.Name);
            Participate lastParticipate = register.GetLastParticipate();
            if (lastParticipate != null)
            {
                txt = txt.Replace("{نام درس}", lastParticipate.SectionItem.Item.Lesson.Name);
                txt = txt.Replace("{نام گروه}", lastParticipate.SectionItem.Section.FarsiName);
            }
            else
            {
                txt = txt.Replace("{نام درس}", "");
                txt = txt.Replace("{نام گروه}", "");

            }
            return txt;
        }

    }

    public enum Language
    {
        [EnumDescription("فـارســی")]
        Farsi,
        [EnumDescription("انگلـیـســی")]
        English,
    }
}