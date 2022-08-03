using System.Linq;
using DataAccessLayer;
using Fakher.Core.Website;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class ActivityMark : DbObject
    {
       
        public virtual PersianDate Date { get; set; }
        [NoCascade]
        public virtual Person Person { get; set; }
        [NoCascade]
        public virtual SectionItem SectionItem { get; set; }
        public virtual float Mark { get; set; }
      public virtual string Description { get; set; }

        public ActivityMark()
        {
            Date = PersianDate.Today;
            Mark = 0;
        }

      
    }
}