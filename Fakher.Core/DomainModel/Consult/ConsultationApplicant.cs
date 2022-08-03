using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel.Consult
{
    public class ConsultationApplicant : DbObject
    {
        public virtual PersianDate Date { get; set; }
        public virtual int Hour { get; set; }
        public virtual int Minute { get; set; }
        [NoCascade]
        public virtual Student Student { get; set; }
        [NoCascade]
        public virtual ConsultationSession Session { get; set; }
        public virtual Formation Formation { get; set; }
        public virtual bool InternetRegisteration { get; set; }

        [NonPersistent]
        public virtual string RegisterationTypeText
        {
            get
            {
                if (InternetRegisteration)
                    return "اینترنتی";
                return "حضوری";
            }
        }

        [NonPersistent]
        public virtual string RegisterDateTime
        {
            get { return Date + " " + Hour + ":" + Minute; }
        }

        public ConsultationApplicant()
        {
            Date = PersianDate.Today;
            Hour = Time.Now.Hour;
            Minute = Time.Now.Minute;
        }
    }
}