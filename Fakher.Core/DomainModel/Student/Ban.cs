using DataAccessLayer;
using rComponents;
using System.Collections.Generic;
using System.Linq;

namespace Fakher.Core.DomainModel
{
    public class Ban : DbObject
    {
        public Ban()
        {
            StartDate = PersianDate.Today;
            Status = BanStatus.Active;
        }

        public virtual PersianDate StartDate { get; set; }
        public virtual PersianDate EndDate { get; set; }
        public virtual BanStatus Status { get; set; }
        public virtual string Reason { get; set; }
        [NoCascade]
        public virtual Participate Participate { get; set; }

    }

    public enum BanStatus
    {
        [EnumDescription("در حال تعلیق")]
        Active,
        [EnumDescription("تعلیق پایان یافته")]
        Canceled
    }
}