using System;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class PlacementItem : DbObject
    {
        public PlacementItem()
        {
        }

        public virtual PlacementItemType Type { get; set; }
        public virtual double FromValue { get; set; }
        public virtual double ToValue { get; set; }
        [NoCascade]
        public virtual Lesson Lesson { get; set; }
        [NoCascade]
        public virtual PlacementProtocol Protocol { get; set; }

        public virtual bool HasIntersect(PlacementItem item)
        {
            if (FromValue >= item.FromValue && FromValue <= item.ToValue)
                return true;
            if (ToValue <= item.ToValue && ToValue >= item.FromValue)
                return true;
            return false;
        }

        public virtual bool CanApply(float mark)
        {
            return mark >= FromValue && mark <= ToValue;
        }

        public virtual PlacementItem Clone()
        {
            PlacementItem clone = Services.Clone(this);
            clone.Lesson = Lesson;
            return clone;
        }
    }

    public enum PlacementItemType
    {
        Signup,
        NotSignup
    }
}