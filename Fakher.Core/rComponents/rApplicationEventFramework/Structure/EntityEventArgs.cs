using System;

namespace rApplicationEventFramework
{[Serializable]
    public class EntityEventArgs : EventArgs
    {
        public object Entity { get; set; }
        public object EntityId { get; set; }
        public string EntityText { get; set; }
        public string EntityTypeName { get; set; }
        public EntityEventAction Action { get; set; }
    }
}