using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rApplicationEventFramework;
using rComponents;

namespace Fakher.Core.DomainModel
{
    [EventClass("مدرس")]
    public class Teacher : Staff
    {
        public Teacher()
        {
            
        }

        public virtual bool HasToefle { get; set; }
        public virtual bool HasIelts { get; set; }
        [NoCascade]
        public virtual IList<Section> TeachingSections { get; set; }

        public virtual Formation GetConflictingFormation(Formation formation)
        {
            var query = from f in DbContext.Entity<Formation>()
                        where (f.Section.StartDate < formation.Section.FinishDate || f.Section.FinishDate > formation.Section.StartDate)
                        select f;

            List<Formation> queryFormations = query.ToList();
            foreach (Formation queryFormation in queryFormations)
            {
                if (queryFormation.Section.Teacher.Id != Id)
                    continue;
                if (queryFormation.Day != formation.Day)
                    continue;
                if (queryFormation.StartTimeInMinutes > formation.StartTimeInMinutes && queryFormation.StartTimeInMinutes < formation.FinishTimeInMinutes)
                    return queryFormation;
                if (queryFormation.FinishTimeInMinutes > formation.StartTimeInMinutes && queryFormation.FinishTimeInMinutes < formation.FinishTimeInMinutes)
                    return queryFormation;
            }
            return null;
        }

        public virtual IQueryable<Lesson> GetTeachingLessons(EducationalPeriod period)
        {
            IList<Section> sections = GetTeachingSections(period);
            var query = from section in sections
                        from item in section.Items
                        select item.Lesson;

            return query.AsQueryable();
        }

        public virtual IQueryable<Lesson> GetTeachingLessons(Major major)
        {
            if (TeachingSections == null | !TeachingSections.Any())
            {
                TeachingSections = DbContext.Entity<Section>().Where(m => m.Teacher == this).ToList();
            }
            var query = from section in TeachingSections
                        from item in section.Items
                        where section.Major.Id == major.Id
                        select item.Lesson;

            return query.AsQueryable();
        }

        public virtual IList<Section> GetTeachingSections(EducationalPeriod period)
        {
            if(TeachingSections==null|!TeachingSections.Any())
            {
                TeachingSections= DbContext.Entity<Section>().Where(m => m.Teacher == this).ToList();
            }
            var query = from section in TeachingSections
                        where section.Period.Id == period.Id
                        select section;
            return query.ToList();
        }

        public virtual IList<Section> GetTeachingSections(EducationalPeriod period, Major major)
        {
            if (TeachingSections == null | !TeachingSections.Any())
            {
                TeachingSections = DbContext.Entity<Section>().Where(m => m.Teacher == this).ToList();
            }
            var query = from section in TeachingSections
                        where section.Period.Id == period.Id
                        && section.Major.Id == major.Id
                        select section;
            return query.ToList();
        }

        public virtual IList<Section> GetTeachingSections(Major major, PersianDate startDate, PersianDate endDate)
        {
            if (TeachingSections == null | !TeachingSections.Any())
            {
                TeachingSections = DbContext.Entity<Section>().Where(m => m.Teacher == this).ToList();
            }
            var query = from section in TeachingSections
                        where section.Major.Id == major.Id
                        && startDate >= section.StartDate && startDate <= section.FinishDate
                        && endDate >= section.StartDate
                        select section;
            return query.ToList();
        }

        public virtual IList<Section> GetTeachingSections(PersianDate startDate, PersianDate endDate)
        {
            if (TeachingSections == null | !TeachingSections.Any())
            {
                TeachingSections = DbContext.Entity<Section>().Where(m => m.Teacher == this).ToList();
            }
            var query = from section in TeachingSections
                        where startDate >= section.StartDate && startDate <= section.FinishDate
                        && endDate >= section.StartDate
                        select section;
            return query.ToList();
        }

        public static IQueryable<Teacher> GetEmployingTeachers(Major major)
        {
            var query = from contract in DbContext.Entity<TeachingContract>()
                        where contract.Major.Id == major.Id
                        select contract.Staff as Teacher;
            return query;
        }

        public new static List<Teacher> Search(string firstName, string lastName)
        {
            List<Teacher> result = new List<Teacher>();

            var query = from teacher in DbContext.Entity<Teacher>()
                        where teacher.FarsiFirstName == firstName
                        && teacher.FarsiLastName == lastName
                        select teacher;
            result.UniqueAddRange(query.ToList());

            query = from teacher in DbContext.Entity<Teacher>()
                    where teacher.FarsiFirstName.StartsWith(firstName)
                    && teacher.FarsiLastName.StartsWith(lastName)
                    select teacher;
            result.UniqueAddRange(query.ToList());

            query = from teacher in DbContext.Entity<Teacher>()
                    where teacher.FarsiFirstName.Contains(firstName)
                    && teacher.FarsiLastName.Contains(lastName)
                    select teacher;
            result.UniqueAddRange(query.ToList());

            return result.Where(x => !x.Disabled).ToList();
        }

        public new static Teacher FromName(string firstName, string lastName)
        {
            var query = from teacher in DbContext.Entity<Teacher>()
                        where teacher.FarsiFirstName == firstName && teacher.FarsiLastName == lastName
                        && !teacher.Disabled
                        select teacher;
            return query.FirstOrDefault();
        }

        public new static Teacher FromLogin(string username, string password)
        {
            IQueryable<Teacher> query = DbContext.Entity<Teacher>().Where(p => p.UserInfo.Username == username && p.UserInfo.Password == password);
            var query2 = from teacher in query.ToList()
                         where teacher.UserInfo.LoginStatus == LoginStatus.Enabled
                         && !teacher.Disabled
                         select teacher;
            return query2.FirstOrDefault();
        }

        public static Teacher FromId(int id)
        {
            return DbContext.FromId<Teacher>(id);
        }

        public static Teacher FromLogin(string code, string encUsername, string encPassword)
        {
            IQueryable<Teacher> query =
                DbContext.Entity<Teacher>().Where(
                    p => p.Code == code
                        && p.UserInfo.Username == encUsername
                        && p.UserInfo.Password == encPassword);
            var query2 = from teacher in query.ToList()
                         where teacher.UserInfo.LoginStatus == LoginStatus.Enabled
                         && !teacher.Disabled
                         select teacher;
            return query2.FirstOrDefault();
        }

        public static List<Teacher> SearchByFirstname(string firstName)
        {
            List<Teacher> result = new List<Teacher>();
            if (string.IsNullOrEmpty(firstName))
                return result;

            var query = from teacher in DbContext.Entity<Teacher>()
                        where teacher.FarsiFirstName == firstName
                        select teacher;
            result.UniqueAddRange(query.ToList());

            query = from teacher in DbContext.Entity<Teacher>()
                    where teacher.FarsiFirstName.StartsWith(firstName)
                    select teacher;
            result.UniqueAddRange(query.ToList());

            return result.Where(x => !x.Disabled).ToList();
        }

        public static List<Teacher> SearchByLastname(string lastName)
        {
            List<Teacher> result = new List<Teacher>();
            if (string.IsNullOrEmpty(lastName))
                return result;

            var query = from teacher in DbContext.Entity<Teacher>()
                        where teacher.FarsiLastName == lastName
                        select teacher;
            result.UniqueAddRange(query.ToList());

            query = from teacher in DbContext.Entity<Teacher>()
                    where teacher.FarsiLastName.StartsWith(lastName)
                    select teacher;
            result.UniqueAddRange(query.ToList());

            return result.Where(x => !x.Disabled).ToList();
        }

        public virtual IList<Replacement> GetReplacements()
        {
            var query = from replacement in DbContext.Entity<Replacement>()
                        where replacement.Teacher.Id == Id
                        select replacement;
            return query.ToList();
        }

        public virtual IList<Replacement> GetReplacements(EducationalPeriod period)
        {
            var query = from replacement in DbContext.Entity<Replacement>()
                        where replacement.Teacher.Id == Id
                        && replacement.SectionItem.Section.Period.Id == period.Id
                        select replacement;
            return query.ToList();
        }

        public virtual IList<Replacement> GetReplacements(PersianDate startDate, PersianDate endDate)
        {
            var query = from replacement in DbContext.Entity<Replacement>()
                        where replacement.Teacher.Id == Id
                        && replacement.Date >= startDate
                        && replacement.Date <= endDate
                        select replacement;
            return query.ToList();
        }

        public virtual IQueryable<EducationalPeriod> GetPresenceTeachingPeriods(Major major)
        {
            var query = from section in GetPresenceSections(major)
                        group section by section.Period
                            into g
                            select g.Key;
            return query.AsQueryable();
        }

        public virtual IQueryable<EducationalPeriod> GetPresenceTeachingPeriods(int year, Major major)
        {
            var query = from section in GetPresenceSections(major)
                        group section by section.Period
                            into g
                            where g.Key.Year == year
                            select g.Key;
            return query.AsQueryable();
        }

        public virtual int GetPresenceTeachingHours(Major major)
        {
            var query = from section in GetPresenceSections(major)
                        select section.HoldingHours;
            return query.Sum();
        }

        public virtual IQueryable<Section> GetPresenceSections(Major major)
        {
            var query = from presence in Presences
                        group presence by presence.SectionItem.Section
                            into g
                            orderby g.Key.GroupNumber
                            select g.Key;

            //            var query = from section in TeachingSections
            //                        where section.Major.Id == major.Id
            //                        && section.WageCalculation
            //                        && PersianDate.Today >= section.FinishDate
            //                        select section;
            return query.AsQueryable();
        }

//        public static IList<Teacher> GetTeachers()
//        {
//            return DbContext.GetAllEntities<Teacher>();
//        }

        public virtual TeachingContract GetContract(PersianDate startDate, PersianDate endDate)
        {
            var query = from contract in Contracts
                        where startDate >= contract.StartDate && startDate <= contract.EndDate
                              && endDate >= contract.StartDate && endDate <= contract.EndDate
                        orderby contract.Id descending
                        select contract;
            return query.LastOrDefault() as TeachingContract;
        }

        public virtual IQueryable<Department> GetTeachingDepartments()
        {
            if (TeachingSections == null | !TeachingSections.Any())
            {
                TeachingSections = DbContext.Entity<Section>().Where(m => m.Teacher == this).ToList();
            }
            var query = from section in TeachingSections
                        group section by section.Period.Department into g
                        select g.Key;
            return query.AsQueryable();
        }

        public virtual IQueryable<EducationalPeriod> GetTeachingPeriods()
        {
            if (TeachingSections == null | !TeachingSections.Any())
            {
                TeachingSections = DbContext.Entity<Section>().Where(m => m.Teacher == this).ToList();
            }
            var query = from section in TeachingSections
                        group section by section.Period into g
                        select g.Key;
            return query.AsQueryable();
        }

        public virtual IQueryable<EducationalPeriod> GetTeachingPeriods(Department department)
        {
            if (TeachingSections == null | !TeachingSections.Any())
            {
                TeachingSections = DbContext.Entity<Section>().Where(m => m.Teacher == this).ToList();
            }
            var query = from section in TeachingSections
                        where section.Period.Department.Id == department.Id
                        group section by section.Period into g
                        select g.Key;
            return query.AsQueryable();
        }

        public virtual IQueryable<EducationalPeriod> GetTeachingPeriods(Major major)
        {
            if (TeachingSections == null | !TeachingSections.Any())
            {
                TeachingSections = DbContext.Entity<Section>().Where(m => m.Teacher == this).ToList();
            }
            var query = from section in TeachingSections
                        where section.Major.Id == major.Id
                        group section by section.Period into g
                        select g.Key;
            return query.AsQueryable();
        }

        //        public virtual IQueryable<TeachingContract> GetContract(EducationalPeriod period, Department department)
        //        {
        //            var query = from contract in Contracts
        //                        where (contract as TeachingContract).Period.Id == period.Id
        //                              && (contract as TeachingContract).Major.Department.Id == department.Id
        //                        select contract as TeachingContract;
        //            return query.AsQueryable();
        //        }

        public virtual IList<Section> GetPresenceSections(PersianDate startDate, PersianDate endDate)
        {
            IQueryable<Presence> queryable = GetPresences(startDate, endDate);
            var query = from presence in queryable.ToList()
                        group presence by presence.SectionItem.Section
                            into g
                            orderby g.Key.GroupNumber
                            select g.Key;
            return query.ToList();
        }

        public virtual IList<Section> GetPresenceSections(Major major, PersianDate startDate, PersianDate endDate)
        {
            return GetPresenceSections(startDate, endDate).Where(x => x.Major.Id == major.Id).ToList();
        }

        public virtual IList<Replacement> GetPresenceReplacements(PersianDate startDate, PersianDate endDate)
        {
            IList<Replacement> replacements = GetReplacements();
            var query = from replacement in replacements
                        where replacement.Date >= startDate && replacement.Date <= endDate
                        orderby replacement.SectionItem.Section.GroupNumber
                        select replacement;
            return query.ToList();
        }

        public virtual IQueryable<Major> GetTeachingMajors()
        {
            if (TeachingSections == null | !TeachingSections.Any())
            {
                TeachingSections = DbContext.Entity<Section>().Where(m => m.Teacher == this).ToList();
            }
            var query = from section in TeachingSections
                        group section by section.Major
                            into g
                            select g.Key;
            return query.AsQueryable();
        }

        public static IQueryable<Teacher> GetActiveTeachers()
        {
            var query = from teacher in DbContext.Entity<Teacher>()
                        where teacher.Disabled == false
                        select teacher;
            return query;
        }

        public static IQueryable<Teacher> GetAllTeachers()
        {
            var query = from teacher in DbContext.Entity<Teacher>()
                        select teacher;
            return query;
        }
    }
}