using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class OralMark : DbObject
    {
        public OralMark()
        {
            Date = PersianDate.Today;
        }

        public virtual PersianDate Date { get; set; }
        public virtual float Value { get; set; }
        [NoCascade]
        public virtual OralExamParticipate Participate { get; set; }
    }
}