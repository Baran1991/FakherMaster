using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class ObserveMark : DbObject
    {
        public ObserveMark()
        {
            Date = PersianDate.Today;
            Type = ObserveMarkType.Observe;
        }

        public virtual PersianDate Date { get; set; }
        public virtual ObserveMarkType Type { get; set; }
        public virtual float Mark { get; set; }
        [NoCascade]
        public virtual SectionItem SectionItem { get; set; }

        [NonPersistent]
        public virtual string TypeText
        {
            get { return Type.ToDescription(); }
        }
    }

    public enum ObserveMarkType
    {
        [EnumDescription("آبزرو")]
        Observe,
        [EnumDescription("آبزرو کلاس")]
        ClassObserve,
        [EnumDescription("آبزرو موسسه")]
        InstituteObserve
    }
}