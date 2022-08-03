using System.Net.Mail;
using DataAccessLayer;

namespace Fakher.Core.DomainModel
{
    public class ContactInfo : DbObject
    {
        public ContactInfo()
        {
            Province = "فارس";
            City = "شیراز";
            Mobile = "09";
        }

        public virtual string Province { get; set; }
        public virtual string City { get; set; }
        public virtual string Address { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string Email { get; set; }

        [NonPersistent]
        public virtual string ProvinceAndCityText
        {
            get 
            {
                string txt = Province;
                if (!string.IsNullOrEmpty(City))
                    txt += " - " + City;
                return txt;
            }
        }

        [NonPersistent]
        public virtual MailAddress EmailAddress
        {
            get
            {
                if(!string.IsNullOrEmpty(Email))
                    return new MailAddress(Email);
                return null;
            }
        }
    }
}