using System;
using DataAccessLayer;
using rApplicationEventFramework;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class AppLog : DbObject, IAppLog
    {
        public virtual PersianDate Date { get; set; }
        public virtual string Time { get; set; }
        [MaximumLength]
        public virtual string Description { get; set; }
        public virtual string Actor { get; set; }
        public virtual string IP { get; set; }
        [MaximumLength]
        public virtual string UserAgent { get; set; }

        public AppLog()
        {
            Date = PersianDate.Today;
            Time = rComponents.Time.Now.ToString();
        }
    }
}