using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Makeup : DbObject
    {
        public Makeup()
        {
            Date = PersianDate.Today;
            Formation = new Formation();
        }

        public virtual PersianDate Date { get; set; }
        public virtual Formation Formation { get; set; }
        [NoCascade]
        public virtual SectionItem SectionItem { get; set; }
    }
}