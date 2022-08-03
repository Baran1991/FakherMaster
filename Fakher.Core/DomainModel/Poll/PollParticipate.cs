using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel.Poll
{
    public class PollParticipate : DbObject
    {
        public virtual PersianDate Date { get; set; }
        public virtual int Hour { get; set; }
        public virtual int Minute { get; set; }
        public virtual int Second { get; set; }
        [NoCascade]
        public virtual Person Person { get; set; }
        [NoCascade]
        public virtual PollItem PollItem { get; set; }

        public PollParticipate()
        {
            Date = PersianDate.Today;
            Hour = Time.Now.Hour;
            Minute = Time.Now.Minute;
            Second = Time.Now.Second;
        }
    }
}