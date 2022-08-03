using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using NHibernate;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace DataAccessLayer
{
    public class ImageUserType : IUserType
    {

        public Object Assemble(Object cached, Object owner)
        {

            return (cached);

        }

        public Object DeepCopy(Object value)
        {

            if (value == null)
            {

                return (null);

            }

            else
            {

                return ((value as ICloneable).Clone());

            }

        }

        public Object Disassemble(Object value)
        {

            return (value);

        }

        public Int32 GetHashCode(Object x)
        {

            return (x != null ? x.GetHashCode() : 0);

        }

        public Boolean IsMutable
        {

            get
            {

                return (false);

            }

        }

        public Object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {

            Byte[] data = NHibernateUtil.Binary.NullSafeGet(rs, names[0],session) as Byte[];

            if (data != null)
            {

                using (Stream stream = new MemoryStream(data))
                {

                    Image image = Image.FromStream(stream);

                    return (image);

                }

            }

            else
            {

                return (null);

            }

        }

        public void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {

            if (value == null)
            {

                NHibernateUtil.Binary.NullSafeSet(cmd, null, index,session);

            }

            else
            {

                using (MemoryStream stream = new MemoryStream())
                {

                    Image image = value as Image;

                    image.Save(stream, ImageFormat.Png);

                    NHibernateUtil.String.NullSafeSet(cmd, stream.GetBuffer(), index,session);

                }

            }

        }

        public Object Replace(Object original, Object target, Object owner)
        {

            return (original);

        }

        public Type ReturnedType
        {

            get
            {

                return (typeof(Image));

            }

        }

        public SqlType[] SqlTypes
        {

            get
            {

                return (new SqlType[] { new SqlType(DbType.Binary) });

            }

        }

        Boolean IUserType.Equals(Object o1, Object o2)
        {

            return (Object.Equals(o1, o2));

        }

        
       
    }
}