
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class PlacementProtocol : Protocol
    {
        public PlacementProtocol()
        {
            PlacementItems = new List<PlacementItem>();
        }

        public virtual IList<PlacementItem> PlacementItems { get; set; }

        public virtual PlacementItem GetPlacementItem(float mark)
        {
            foreach (PlacementItem item in PlacementItems)
            {
                if(item.CanApply(mark))
                    return item;
            }
            throw new ArgumentOutOfRangeException(string.Format("برای نمره [{0}] آیین نامه تعیین سطح تعریف نشده است.", mark));
        }

        public static IList<PlacementProtocol> GetProtocols(EducationalPeriod period)
        {
            var query = from protocol in DbContext.Entity<PlacementProtocol>()
                        where protocol.Period.Id == period.Id
                        select protocol;
            return query.ToList();
        }

        public virtual PlacementProtocol Clone()
        {
            PlacementProtocol clone = Services.Clone(this);
            foreach (PlacementItem item in PlacementItems)
            {
                PlacementItem itemClone = item.Clone();
                itemClone.Protocol = clone;
                clone.PlacementItems.Add(itemClone);
            }
            return clone;
        }
    }
}