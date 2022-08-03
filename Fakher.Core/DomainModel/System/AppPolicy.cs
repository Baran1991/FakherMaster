using System;
using DataAccessLayer;
using rApplicationEventFramework;

namespace Fakher.Core.DomainModel
{
    public class AppPolicy : DbObject, IPolicy
    {
        #region Implementation of IPolicy

        public virtual string Expression { get; set; }
        public virtual string EventCode { get; set; }

        #endregion
    }
}