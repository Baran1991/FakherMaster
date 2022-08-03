using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Career : DbObject
    {
        [MaximumLength]
        public virtual string Name { get; set; }
        public virtual EducationalDegree EducationalDegree { get; set; }
        public virtual CareerGenderType GenderType { get; set; }
        [MaximumLength]
        public virtual string Qualifications { get; set; } 
        [MaximumLength]
        public virtual string DescriptionHtml { get; set; }
        public virtual PersianDate StartDate { get; set; }
        public virtual PersianDate EndDate { get; set; }

        public Career()
        {
            StartDate = PersianDate.Today;
            GenderType = CareerGenderType.Both;
            EducationalDegree = EducationalDegree.Bachelor;
        }

        [NonPersistent]
        public virtual string StatusText
        {
            get
            {
                if (PersianDate.Today > EndDate)
                    return "پایان یافته";
                return "در حال پذیرش";
            }
        }

        [NonPersistent]
        public virtual string EducationalDegreeText
        {
            get { return EducationalDegree.ToDescription(); }
        }

        [NonPersistent]
        public virtual string GenderTypeText
        {
            get { return GenderType.ToDescription(); }
        }

        public virtual IQueryable<CareerApplicant> GetApplicants()
        {
            var query = from applicant in DbContext.Entity<CareerApplicant>()
                        where applicant.Career.Id == Id
                        select applicant;
            return query;
        }

        public static Career FromId(int id)
        {
            return DbContext.FromId<Career>(id);
        }
        
        public static IList<Career> GetCareers()
        {
            return DbContext.GetAllEntities<Career>();
        }

        public static IList<Career> GetActiveCareers()
        {
            var query = from career in DbContext.Entity<Career>()
                        where PersianDate.Today >= career.StartDate
                              && PersianDate.Today <= career.EndDate
                        select career;
            return query.ToList();
        }
    }

    public enum CareerGenderType
    {
        [EnumDescription("مـرد")]
        Male,
        [EnumDescription("زن")]
        Female,
        [EnumDescription("مـرد-زن")]
        Both
    }
}