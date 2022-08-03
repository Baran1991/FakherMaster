using System;

namespace rApplicationEventFramework
{[Serializable]
    public class MeetPolicyEventArgs : EventArgs
    {
        private IPolicy _mPolicy;
        private object mEntity;
        private object mEntityId;
        private object mPreviousValue;
        private object mCurrentValue;
            
        public MeetPolicyEventArgs(IPolicy _mPolicy)
        {
            this._mPolicy = _mPolicy;
        }

        public IPolicy Policy
        {
            get { return _mPolicy; }
            set { _mPolicy = value; }
        }

        public object Entity
        {
            get { return mEntity; }
            set { mEntity = value; }
        }

        public object EntityId
        {
            get { return mEntityId; }
            set { mEntityId = value; }
        }

        public object PreviousValue
        {
            get { return mPreviousValue; }
            set { mPreviousValue = value; }
        }

        public object CurrentValue
        {
            get { return mCurrentValue; }
            set { mCurrentValue = value; }
        }
    }
}