using System;
using System.Linq;
using DataAccessLayer;
using rApplicationEventFramework;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class EntityEvent : DbObject, IEntityEvent
    {
        public EntityEvent()
        {
            Date = PersianDate.Today;
            Hour = DateTime.Now.Hour;
            Minute = DateTime.Now.Minute;
        }

        #region Implementation of IEntityEvent

        public virtual EntityEventAction Action { get; set; }
        public virtual PersianDate Date { get; set; }
        public virtual int Hour { get; set; }
        public virtual int Minute { get; set; }
        public virtual int EntityId { get; set; }
        public virtual string EntityText { get; set; }
        public virtual string EntityTypeText { get; set; }
        public virtual Person Registrar { get; set; }
        public virtual string RegistrarText { get; set; }
        public virtual int BatchNumber { get; set; }

        #endregion

        public static int GetNextBatchNumber()
        {
            var query = from entity in DbContext.Entity<EntityEvent>()
                        orderby entity.BatchNumber descending
                        select entity.BatchNumber;
            int lastNumber = query.FirstOrDefault();
            return lastNumber + 1;
        }
    }
}