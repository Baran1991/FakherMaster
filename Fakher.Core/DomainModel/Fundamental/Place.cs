using System;
using System.ComponentModel;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Place : DbObject
    {
        public Place()
        {
            Name = "";
            CapacityType = CapacityType.UnDetermined;
            Capacity = 0;
        }

        public virtual string Name { get; set; }
        public virtual CapacityType CapacityType { get; set; }
        public virtual int Capacity { get; set; }

        [NonPersistent]
        public virtual string CapacityText
        {
            get
            {
                if (CapacityType == CapacityType.Determined)
                    return Capacity + " نفر ";
                return "نا محدود";
            }
        }

        #region Overrides of Object

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }

    public enum CapacityType
    {
        [EnumDescription("ظرفیت نامحدود")]
        UnDetermined = 0,
        [EnumDescription("ظرفیت محدود")]
        Determined = 1
    }
}