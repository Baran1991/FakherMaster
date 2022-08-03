using DataAccessLayer;
using rApplicationEventFramework;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class PersonalInfo : DbObject
    {
        public virtual string FarsiFirstName { get; set; }
        public virtual string FarsiLastName { get; set; }
        public virtual string FarsiFatherName { get; set; }
        public virtual string EnglishFirstName { get; set; }
        public virtual string EnglishLastName { get; set; }
        public virtual string EnglishFatherName { get; set; }
        public virtual PersianDate BirthDate { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual MarriageStatus MarriageStatus { get; set; }
        public virtual string BirthPlace { get; set; }
        public virtual string IdNumber { get; set; }
        public virtual string NationalCode { get; set; }
        public virtual string Job { get; set; }
        public virtual string SpecialDisease { get; set; }

        [NonPersistent]
        public virtual string FarsiFullname
        {
            get { return FarsiFirstName + " " + FarsiLastName; }
        }

        [NonPersistent]
        public virtual string Title
        {
            get
            {
                if (Gender == Gender.Male)
                    return "آقای";
                return "خانم";
            }
        }

        [NonPersistent]
        public virtual string FarsiFormalName
        {
            get { return Title + " " + FarsiLastName; }
        }

        [NonPersistent]
        public virtual string EnglishFullname
        {
            get { return EnglishFirstName + " " + EnglishLastName; }
        }

        [NonPersistent]
        public virtual string GenderAndMarriageText
        {
            get { return Gender.ToDescription() + "/" + MarriageStatus.ToDescription(); }
        }
    }
}