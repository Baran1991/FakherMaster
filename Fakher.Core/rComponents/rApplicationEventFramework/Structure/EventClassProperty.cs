using System;

namespace rApplicationEventFramework
{[Serializable]
    public class EventClassProperty : Attribute
    {
        private string mName;
        private string mInitialValue;
        private string mFullname;

        public EventClassProperty(string name)
        {
            mName = name;
        }

        public EventClassProperty(string name, string initialValue)
            : this(name)
        {
            mInitialValue = initialValue;
        }

        #region Properties

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        public string InitialValue
        {
            get { return mInitialValue; }
            set { mInitialValue = value; }
        }

        public string Fullname
        {
            get { return mFullname; }
            set { mFullname = value; }
        }

        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}