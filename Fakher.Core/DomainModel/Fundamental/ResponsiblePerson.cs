using DataAccessLayer;

namespace Fakher.Core.DomainModel
{
    public class ResponsiblePerson : DbObject
    {
        [NoCascade]
        public virtual Department Department { get; set; }
        [NoCascade]
        public virtual Person Person { get; set; }
        public virtual bool ReceiveEmails { get; set; }
    }
}