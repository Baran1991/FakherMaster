using DataAccessLayer;

namespace Fakher.Core.DomainModel
{
    public class ExamSection : DbObject
    {
        [NoCascade]
        public virtual Exam Exam { get; set; }
        [NoCascade]
        public virtual SectionItem SectionItem { get; set; }
    }
}