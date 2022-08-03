using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class MessageReceiver : DbObject
    {
        public MessageReceiver()
        {
            Status = MessageStatus.UnRead;
        }

        [NoCascade]
        public virtual Message Message { get; set; }
        [NoCascade]
        public virtual Person Person { get; set; }
        public virtual MessageStatus Status { get; set; }
        public virtual PersianDate ReadDate { get; set; }
        public virtual string ReadTime { get; set; }

        [NonPersistent]
        public virtual string StatusText
        {
            get { return Status.ToDescription(); }
        }

    }

    public enum MessageStatus
    {
        [EnumDescription("خوانده شده")]
        Read,
        [EnumDescription("خوانده نشده")]
        UnRead
    }

}