using DataAccessLayer;

namespace Fakher.Core.DomainModel
{
    public class LessonEquivalence : DbObject
    {
        [NoCascade]
        public virtual Lesson EquivalentLesson { get; set; }
        [NoCascade]
        public virtual LessonHolding LessonHolding { get; set; }
    }
}