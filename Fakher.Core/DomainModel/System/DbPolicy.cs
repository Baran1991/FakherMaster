using DataAccessLayer;
using rApplicationEventFramework;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class DbPolicy : AppPolicy, IDbPolicy
    {
        #region Implementation of IDbEventPolicy

        public virtual string TypeName { get; set; }
        public virtual string FullTypeName { get; set; }
        public virtual EntityEventAction Action { get; set; }
        public virtual string FieldName { get; set; }
        public virtual string FullFieldName { get; set; }

        #endregion

        [NonPersistent]
        public virtual string ActionText
        {
            get { return Action.ToDescription(); }
        }
    }
}