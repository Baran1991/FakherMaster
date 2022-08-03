using System.ComponentModel;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Absence : DbObject
    {
        public Absence()
        {
            Date = PersianDate.Today;
            Status = AbsenceStatus.Rejected;
            Reason = "";
        }

        public virtual PersianDate Date { get; set; }
        public virtual string Reason { get; set; }
        public virtual AbsenceStatus Status { get; set; }
        [NoCascade]
        public virtual Person Person { get; set; }
        [NoCascade]
        public virtual SectionItem SectionItem { get; set; }

        [NonPersistent]
        public virtual string StatusText
        {
            get
            {
                return Status.ToDescription();
            }
        }
    }

    public enum AbsenceStatus
    {
        [EnumDescription("موجه")]
        Accepted,
        [EnumDescription("غیرموجه")]
        Rejected
    }
}