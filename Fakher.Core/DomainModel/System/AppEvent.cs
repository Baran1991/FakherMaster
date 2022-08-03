using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rApplicationEventFramework;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class AppEvent : DbObject, IApplicationEvent
    {
        #region Implementation of IApplicationEvent

        public virtual string Date { get; set; }
        public virtual string Time { get; set; }
        public virtual string ObjectId { get; set; }
        public virtual string Description { get; set; }
        public virtual string Entity { get; set; }
        public virtual string Operator { get; set; }
        public virtual string Actor { get; set; }

        #endregion

        public static IList<AppEvent> GetEvents(PersianDate date)
        {
            var query = from appEvent in DbContext.Entity<AppEvent>()
                        where appEvent.Date == date.ToShortDateString()
                        select appEvent;
            return query.ToList();
        }
    }
}