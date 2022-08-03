using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class EducationalInfo : DbObject
    {
        public virtual EducationalDegree EducationalDegree { get; set; }
        public virtual string EducationalMajor { get; set; }
        public virtual string EducationalUniversity { get; set; }
        public virtual float EducationalDegreeMark { get; set; }

        [NonPersistent]
        public virtual string EducationalDegreeText
        {
            get { return EducationalDegree.ToDescription(); }
        }
    }
}