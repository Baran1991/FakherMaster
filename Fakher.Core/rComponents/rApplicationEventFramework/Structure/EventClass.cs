using System;
using System.Collections.Generic;

namespace rApplicationEventFramework
{[Serializable]
    public class EventClass : Attribute
    {
        private string mName;
        private string mDescription;
        private string mFullName;
        private List<EventClassProperty> mEventProperties;

        public EventClass()
        {
            mName = "";
            mDescription = "";
            mFullName = "";
            mEventProperties = new List<EventClassProperty>();
        }

        public EventClass(string name) : this()
        {
            mName = name;
        }

        public EventClass(string name, string description) : this(name)
        {
            mDescription = description;
        }

        #region Properties

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        public string FullName
        {
            get { return mFullName; }
            set { mFullName = value; }
        }

        public List<EventClassProperty> EventProperties
        {
            get { return mEventProperties; }
            set { mEventProperties = value; }
        }

        #endregion

        public override string ToString()
        {
            return Name;
        }

        internal EventClassProperty GetProperty(string fullFieldName)
        {
            foreach (EventClassProperty property in mEventProperties)
            {
                if (property.Fullname == fullFieldName)
                    return property;
            }
            return null;
        }
    }
}