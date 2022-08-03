using DataAccessLayer;

namespace Fakher.Core.DomainModel
{
    public class Privilege : DbObject
    {
        public Privilege()
        {
        }
        [NoCascade]
        public virtual Person Person { get; set; }
    }
}