using DataAccessLayer;
using Fakher.Core.DomainModel;

namespace Fakher.Core.Website
{
    public class DepartmentPage : DbObject
    {
        [NoCascade]
        public virtual Department Department { get; set; }
        [NoCascade]
        public virtual Webpage Webpage { get; set; }
    }
}