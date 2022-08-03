using System.ComponentModel;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Delay : DbObject
    {
        public Delay()
        {
            Date = PersianDate.Today;
           
        }

        public virtual PersianDate Date { get; set; }
       
        [NoCascade]
        public virtual Person Person { get; set; }
        [NoCascade]
        public virtual SectionItem SectionItem { get; set; }

       
    }

}