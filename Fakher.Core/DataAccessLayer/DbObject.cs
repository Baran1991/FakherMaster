using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Fakher.Core.DomainModel;
using NHibernate;
using rApplicationEventFramework;

namespace DataAccessLayer
{
    public class DbObject
    {
        public virtual int Id { get; set; }
        public virtual bool IsClone { get; set; }
        public virtual bool IsDeleted { get; set; }

        public virtual void Save()
        {
            Save(DbContext.CurrentSession);
            //            DbContext.CurrentSession.SaveOrUpdate(this);
            //            DbContext.CurrentSession.Flush();
        }

        public virtual void Save(ISession session)
        {
            session.SaveOrUpdate(this);
            session.Flush();
        }

        public virtual void SavePartially()
        {
            DbContext.CurrentSession.SaveOrUpdate(this);
        }

        public virtual void Delete()
        {
            DbContext.CurrentSession.Delete(this);
            DbContext.CurrentSession.Flush();
        }

        public virtual void Delete(ISession session)
        {
            session.Delete(this);
            session.Flush();
        }

        public virtual void RefreshEntity()
        {
            DbContext.CurrentSession.Refresh(this);
        }

        public virtual object UnProxy()
        {
            return DbContext.CurrentSession.GetSessionImplementation().PersistenceContext.Unproxy(this);
        }

        public virtual void EntityLoad(object proxy)
        {
            NHibernateUtil.Initialize(proxy);
        }

        public virtual void BeforeSave()
        {

        }

        public virtual void AfterSave()
        {
            
        }

        public virtual Person GetRegistrar()
        {
            return GetRegistrar(EntityEventAction.InsertObject);
        }

        public virtual Person GetRegistrar(EntityEventAction action)
        {
            string fullName = GetType().FullName;
            var query = from entityEvent in DbContext.Entity<EntityEvent>()
                        where entityEvent.Action == action
                              && entityEvent.EntityTypeText == fullName
                              && entityEvent.EntityId == Id
                        orderby entityEvent.Id descending
                        select entityEvent;
            EntityEvent entityEvent1 = query.FirstOrDefault();
            if (entityEvent1 != null)
                return entityEvent1.Registrar;
            return null;
        }
        public virtual IQueryable<Person> GetRegistrars(EntityEventAction action)
        {
            string fullName = GetType().FullName;
            var query = from entityEvent in DbContext.Entity<EntityEvent>()
                        where entityEvent.Action == action
                              && entityEvent.EntityTypeText == fullName
                              && entityEvent.EntityId == Id
                        orderby entityEvent.Id descending
                        select entityEvent.Registrar;
            
                return query;
            
        }
    }

    public class DbObjectTypeDescriptionProvider : TypeDescriptionProvider
    {
        private Type mBaseType;

        public DbObjectTypeDescriptionProvider(Type type)
            : base(TypeDescriptor.GetProvider(type))
        {
            mBaseType = type;
        }

        public override Type GetReflectionType(Type objectType, object instance)
        {
            return base.GetReflectionType(mBaseType, instance);
        }

        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            return base.GetTypeDescriptor(mBaseType, instance);
        }

        public static void Register(Type type)
        {
            TypeDescriptor.AddProvider(new DbObjectTypeDescriptionProvider(type), type);
        }
    }

    public class BindingCollection : ArrayList, ITypedList
    {
        public BindingCollection(ICollection c) : base(c)
        {
        }

        #region Implementation of ITypedList

        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return "";
        }

        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            if (listAccessors == null || listAccessors.Length <= 0)
            {
                return GetTypeProperties(typeof(object));
            }
            return new PropertyDescriptorCollection(null);
        }

        #endregion

        private PropertyDescriptorCollection GetTypeProperties(Type type)
        {
            PropertyInfo[] properties = type.GetProperties();
            PropertyDescriptor descriptor = new MyPropertyDescriptor(null);

            PropertyDescriptorCollection collection = new PropertyDescriptorCollection(new [] { descriptor });
            TypeDescriptionProvider provider = TypeDescriptor.GetProvider(type);

            return provider.GetTypeDescriptor(type).GetProperties();

        }
    }

    public class MyPropertyDescriptor : PropertyDescriptor
    {
        public MyPropertyDescriptor(MemberDescriptor descr) : base(descr)
        {
        }

        #region Overrides of PropertyDescriptor

        public override bool CanResetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override object GetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override void ResetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override void SetValue(object component, object value)
        {
            throw new NotImplementedException();
        }

        public override bool ShouldSerializeValue(object component)
        {
            throw new NotImplementedException();
        }

        public override Type ComponentType
        {
            get { throw new NotImplementedException(); }
        }

        public override bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public override Type PropertyType
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}