using System;
using System.Collections.Generic;
using System.Reflection;

namespace rApplicationEventFramework
{[Serializable]
    public abstract class DbEventHandler
    {
        public virtual void OnChange(object entity, object id, string propertyName, object oldValue, object newValue)
        {

        }

        public virtual void OnInsert(object entity, object id)
        {
            
        }

        public virtual void GetAllClasses()
        {

        }
    }
}