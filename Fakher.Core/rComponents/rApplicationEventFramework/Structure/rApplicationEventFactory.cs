using System;
using System.Collections.Generic;
using System.Reflection;

namespace rApplicationEventFramework
{[Serializable]
    public class rApplicationEventFactory
    {
        private Assembly mAssembly;
        private List<EventClass> mClasses;
        private List<IPolicy> mPolicies;

        public bool InsertEntityEvent { get; set; }
        public bool EditEntityEvent { get; set; }
        public bool DeleteEntityEvent { get; set; }

        public event EventHandler<MeetPolicyEventArgs> PolicyMeeted;
        public event EventHandler<EntityEventArgs> EntityEvent;

        public static string OldValueText;
        public static string OldValueDescription;
        public static string NewValueText;
        public static string NewValueDescription;

        static rApplicationEventFactory()
        {
            OldValueText = "{0}";
            OldValueDescription = "{مقدار قدیم}";
            NewValueText = "{1}";
            NewValueDescription = "{مقدار جدید}";
        }

        public rApplicationEventFactory(Assembly assembly)
        {
            mAssembly = assembly;
            mPolicies = new List<IPolicy>();
            InitializeClasses();
        }

        private void InitializeClasses()
        {
            try
            {
                mClasses = new List<EventClass>();
                Assembly assembly = Assembly.GetExecutingAssembly();
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    object[] mObjects = type.GetCustomAttributes(typeof(EventClass), true);
                    if (mObjects.Length > 0)
                    {
                        EventClass eventClass = (mObjects[0] as EventClass);
                        eventClass.FullName = type.FullName;
                        eventClass.EventProperties.Clear();

                        PropertyInfo[] properties = type.GetProperties();
                        foreach (PropertyInfo propertyInfo in properties)
                        {
                            object[] mPropertyAttributes = propertyInfo.GetCustomAttributes(typeof(EventClassProperty), true);
                            if (mPropertyAttributes.Length > 0)
                            {
                                EventClassProperty eventClassProperty = (mPropertyAttributes[0] as EventClassProperty);
                                eventClassProperty.Fullname = propertyInfo.Name;
                                eventClass.EventProperties.Add(eventClassProperty);
                            }
                        }

                        mClasses.Add(eventClass);
                    }
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (Exception exSub in ex.LoaderExceptions)
                {
                    sb.AppendLine(exSub.Message);
                    System.IO.FileNotFoundException exFileNotFound = exSub as System.IO.FileNotFoundException;
                    if (exFileNotFound != null)
                    {
                        if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
                        {
                            sb.AppendLine("Fusion Log:");
                            sb.AppendLine(exFileNotFound.FusionLog);
                        }
                    }
                    sb.AppendLine();
                }
                string errorMessage = sb.ToString();
                //Display or log the error based on your application.
            }

        }

        #region Properties

        public Assembly Assembly
        {
            get { return mAssembly; }
            set { mAssembly = value; }
        }

        public List<IPolicy> Policies
        {
            get { return mPolicies; }
            set { mPolicies = value; }
        }

        public List<EventClass> Classes
        {
            get { return mClasses; }
            set { mClasses = value; }
        }

        #endregion

        public void OnInsertObject(object entity, object id)
        {
            string objectTypeName = entity.GetType().FullName;
            List<IDbPolicy> typePolicies = GetDbObjectPolicies(objectTypeName);

            if(InsertEntityEvent)
                OnEntityEvent(entity, id, EntityEventAction.InsertObject);

            foreach (IDbPolicy typePolicy in typePolicies)
            {
                if (typePolicy.Action == EntityEventAction.InsertObject)
                    OnPolicyMeeted(typePolicy, entity, id, null, null);
            }
        }

        public void OnDeleteObject(object entity, object id)
        {
            string objectTypeName = entity.GetType().FullName;
            List<IDbPolicy> typePolicies = GetDbObjectPolicies(objectTypeName);

            if (DeleteEntityEvent)
                OnEntityEvent(entity, id, EntityEventAction.DeleteObject);

            foreach (IDbPolicy typePolicy in typePolicies)
            {
                if (typePolicy.Action == EntityEventAction.DeleteObject)
                    OnPolicyMeeted(typePolicy, entity, id, null, null);
            }
        }

        public void OnChangeObject(object entity, object id)
        {
            string objectTypeName = entity.GetType().FullName;
            List<IDbPolicy> typePolicies = GetDbObjectPolicies(objectTypeName);

            if (EditEntityEvent)
                OnEntityEvent(entity, id, EntityEventAction.EditObject);

            foreach (IDbPolicy typePolicy in typePolicies)
            {
                if (typePolicy.Action == EntityEventAction.EditObject)
                    OnPolicyMeeted(typePolicy, entity, id, null, null);
            }
            
        }

        public void OnChangeObject(object entity, object id, string propertyName, object previousValue, object currentValue)
        {
            string objectTypeName = entity.GetType().FullName;
//            List<DbObjectEventPolicy> typePolicies = GetDbObjectPolicies(objectTypeName);
            List<IDbPolicy> fieldPolicies = GetDbObjectPolicies(objectTypeName, propertyName);
            EventClass eventClass = GetEventClass(objectTypeName);
            EventClassProperty property = null;
            if(eventClass != null)
                property = eventClass.GetProperty(propertyName);

//            foreach (DbObjectEventPolicy typePolicy in typePolicies)
//            {
//                if(typePolicy.Action == DbObjectEventPolicyAction.EditObject)
//                    OnPolicyMeeted(typePolicy, entity, id, previousValue, currentValue);
//            }

            if (property != null && previousValue + "" == property.InitialValue + "")
            {
                foreach (IDbPolicy fieldPolicy in fieldPolicies)
                {
                    if (fieldPolicy.Action == EntityEventAction.InsertFieldValue)
                        OnPolicyMeeted(fieldPolicy, entity, id, previousValue, currentValue);
                }
            }
            else
            {
                foreach (IDbPolicy fieldPolicy in fieldPolicies)
                {
                    if (fieldPolicy.Action == EntityEventAction.EditFieldValue)
                        OnPolicyMeeted(fieldPolicy, entity, id, previousValue, currentValue);
                }
            }
        }

        private void OnPolicyMeeted(IPolicy policy, object entity, object entityId, object preValue, object currValue)
        {
            if (PolicyMeeted != null)
            {
                MeetPolicyEventArgs eventArgs = new MeetPolicyEventArgs(policy);
                eventArgs.Entity = entity;
                eventArgs.PreviousValue = preValue;
                eventArgs.CurrentValue = currValue;
                eventArgs.EntityId = entityId;
                PolicyMeeted(this, eventArgs);
            }
        }

        private void OnEntityEvent(object entity, object entityId, EntityEventAction action)
        {
            if (EntityEvent != null
                && !(entity is IEntityEvent)
                && !(entity is IPolicy)
                && !(entity is IApplicationEvent))
            {
                EntityEventArgs eventArgs = new EntityEventArgs();
                eventArgs.Action = action;
                eventArgs.Entity = entity;
                eventArgs.EntityId = entityId;
                string entityTypeName = entity.GetType().FullName;
                
                EventClass eventClass = GetEventClass(entityTypeName);
                if(eventClass != null)
                    eventArgs.EntityText = eventClass.Name;

                eventArgs.EntityTypeName = entityTypeName;
                EntityEvent(this, eventArgs);
            }
        }

        private List<IDbPolicy> GetDbObjectPolicies(string typeName)
        {
            List<IDbPolicy> result = new List<IDbPolicy>();
            foreach (IPolicy policy in mPolicies)
            {
                if (policy is IDbPolicy && (policy as IDbPolicy).FullTypeName == typeName)
                {
                    result.Add(policy as IDbPolicy);
                }
            }
            return result;
        }

        private List<IDbPolicy> GetDbObjectPolicies(string typeName, string fieldName)
        {
            List<IDbPolicy> policies = GetDbObjectPolicies(typeName);
            List<IDbPolicy> result = new List<IDbPolicy>();
            foreach (IDbPolicy policy in policies)
            {
                if (policy.FullFieldName == fieldName)
                {
                    result.Add(policy);
                }
            }
            return result;
        }

        private EventClass GetEventClass(string fullTypeName)
        {
            foreach (EventClass eventClass in mClasses)
            {
                if(eventClass.FullName == fullTypeName)
                {
                    return eventClass;
                }
            }
            return null;
        }

        public void MeetPolicy(IPolicy policy)
        {
            OnPolicyMeeted(policy, null, null, null, null);
        }

        public string BuildExpression(IPolicy policy, object entity, object previousValue, object currentValue)
        {
            string result = policy.Expression;
            if(policy is IDbPolicy)
            {
                EventClass eventClass = GetEventClass((policy as IDbPolicy).FullTypeName);
                foreach (EventClassProperty property in eventClass.EventProperties)
                {
                    object value = entity.GetType().GetProperty(property.Fullname).GetValue(entity, null);
                    result = result.Replace("{" + property.Name + "}", value + "");
                }
            }
            if(previousValue != null)
                result = result.Replace(OldValueText, previousValue + "");
            if(currentValue != null)
                result = result.Replace(NewValueText, currentValue + "");
            return result;
        }

    }
}