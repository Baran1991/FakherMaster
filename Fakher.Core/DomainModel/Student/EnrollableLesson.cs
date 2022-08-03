using DataAccessLayer;

namespace Fakher.Core.DomainModel
{
    public class EnrollableLesson : DbObject
    {
        [NoCascade]
        public virtual Lesson Lesson { get; set; }
        [NoCascade]
        public virtual StudentConfiguration Configuration { get; set; }
    }
}