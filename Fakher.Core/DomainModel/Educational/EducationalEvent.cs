using System.Collections.Generic;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class EducationalEvent : DbObject
    {
        public virtual PersianDate Date { get; set; }
        public virtual string Title { get; set; }
        [NoCascade]
        public virtual Section Section { get; set; }

        [NonPersistent]
        public virtual string Text
        {
            get { return Title + " (" + Date.ToShortDateString() + ")"; }
        }

        public EducationalEvent()
        {
            Date = PersianDate.Today;
        }
    }
}