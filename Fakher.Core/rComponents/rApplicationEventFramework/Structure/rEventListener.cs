using System;
using System.Threading;
using System.Threading.Tasks;
using NHibernate.Engine;
using NHibernate.Event;

namespace rApplicationEventFramework
{[Serializable]
    public class rEventListener : IPostInsertEventListener, IPostUpdateEventListener, IPostDeleteEventListener
    {
        private rApplicationEventFactory mFactory;

        public rEventListener(rApplicationEventFactory factory)
        {
            mFactory = factory;
        }

        #region Implementation of IPostInsertEventListener

        public void OnPostInsert(PostInsertEvent @event)
        {
            mFactory.OnInsertObject(@event.Entity, @event.Id);
        }

        #endregion

        #region Implementation of IPostUpdateEventListener

        public void OnPostUpdate(PostUpdateEvent @event)
        {
            mFactory.OnChangeObject(@event.Entity, @event.Id);
            
            for (int i = 0; i < @event.OldState.Length; i++)
            {
                object oldState = @event.OldState[i];
                object newState = @event.State[i];
                if (oldState == null || newState == null)
                    continue;
                if (oldState.ToString() != newState.ToString())
                    mFactory.OnChangeObject(@event.Entity, @event.Id, @event.Persister.PropertyNames[i], oldState + "",
                                            newState + "");
            }

            foreach (CollectionEntry collection in @event.Session.PersistenceContext.CollectionEntries.Values)
                if (!collection.IsProcessed)
                    collection.IsProcessed = true;
        }

        #endregion

        #region Implementation of IPostDeleteEventListener

        public void OnPostDelete(PostDeleteEvent @event)
        {
            mFactory.OnDeleteObject(@event.Entity, @event.Id);

            foreach (CollectionEntry collection in @event.Session.PersistenceContext.CollectionEntries.Values)
                if (!collection.IsProcessed)
                    collection.IsProcessed = true;
        }

        public Task OnPostInsertAsync(PostInsertEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task OnPostUpdateAsync(PostUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task OnPostDeleteAsync(PostDeleteEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}