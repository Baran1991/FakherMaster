using System;
using System.Data;
using System.Data.Common;
using NHibernate;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace rComponents
{
    public partial class PersianDate : IUserType
    {
        #region Implementation of NHibernate.IUserType

        public new bool Equals(object x, object y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            return (x as PersianDate) == (y as PersianDate);
        }

        public int GetHashCode(object x)
        {
            return (x as PersianDate).ToString().GetHashCode();
        }

        public object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            var obj = NHibernateUtil.String.NullSafeGet(rs, names[0],session);

            if (obj == null) return null;

            var dateString = (string)obj;

            return FromString(dateString);
        }

        public void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            if (value == null)
            {
                ((IDataParameter)cmd.Parameters[index]).Value = DBNull.Value;
            }
            else
            {
                PersianDate dateTime = value as PersianDate;
                ((IDataParameter)cmd.Parameters[index]).Value = dateTime.ToString();
            }
        }

        public object DeepCopy(object value)
        {
            return value;
        }

        public object Replace(object original, object target, object owner)
        {
            return original;
        }

        public object Assemble(object cached, object owner)
        {
            return DeepCopy(cached);
        }

        public object Disassemble(object value)
        {
            return DeepCopy(value);
        }

       

       
        public SqlType[] SqlTypes
        {
            get { return new[] { NHibernateUtil.String.SqlType }; }
        }

        public Type ReturnedType
        {
            get { return typeof(PersianDate); }
        }

        public bool IsMutable
        {
            get { return false; }
        }

        #endregion
    }
}