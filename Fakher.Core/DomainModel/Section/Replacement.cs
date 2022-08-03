using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Replacement : DbObject
    {
        public Replacement()
        {
            Date = PersianDate.Today;
        }

        public virtual PersianDate Date { get; set; }
        public virtual float ReplacementHours { get; set; }
        public virtual string Reason { get; set; }
        [NoCascade]
        public virtual Teacher Teacher { get; set; }
        [NoCascade]
        public virtual SectionItem SectionItem { get; set; }
    }
}