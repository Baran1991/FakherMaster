using DataAccessLayer;

namespace Fakher.Core.DomainModel
{
    public class PayrollItemInfo
    {
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        [NoCascade]
        public virtual PayrollItem PayrollItem { get; set; }
    }
}