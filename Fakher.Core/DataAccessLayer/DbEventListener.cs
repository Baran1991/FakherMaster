using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using NHibernate.Event;

namespace DataAccessLayer
{[Serializable]
    public class DbEventListener : IPreInsertEventListener, IPreUpdateEventListener, IPostInsertEventListener, IPostUpdateEventListener
    {
        #region IPreInsertEventListener Members

        public bool OnPreInsert(PreInsertEvent @event)
        {
            MethodInfo methodInfo = @event.Entity.GetType().GetMethod("BeforeSave");
            if (methodInfo != null)
                methodInfo.Invoke(@event.Entity, null);
            return false;
        }

        #endregion

        #region IPreUpdateEventListener Members

        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            MethodInfo methodInfo = @event.Entity.GetType().GetMethod("BeforeSave");
            if (methodInfo != null)
                methodInfo.Invoke(@event.Entity, null);
            return false;
        }

        #endregion

        #region Implementation of IPostInsertEventListener

        public void OnPostInsert(PostInsertEvent @event)
        {
            MethodInfo methodInfo = @event.Entity.GetType().GetMethod("AfterSave");
            if (methodInfo != null)
                methodInfo.Invoke(@event.Entity, null);
        }

        #endregion

        #region Implementation of IPostUpdateEventListener

        public void OnPostUpdate(PostUpdateEvent @event)
        {
            MethodInfo methodInfo = @event.Entity.GetType().GetMethod("AfterSave");
            if (methodInfo != null)
                methodInfo.Invoke(@event.Entity, null);
        }

        public Task<bool> OnPreInsertAsync(PreInsertEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> OnPreUpdateAsync(PreUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task OnPostInsertAsync(PostInsertEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task OnPostUpdateAsync(PostUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}