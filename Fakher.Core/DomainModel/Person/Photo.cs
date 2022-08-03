using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Photo : DbObject
    {
        public virtual byte[] PictureBytes
        {
            get
            {
                return Services.ConvertToByteArray(Picture);
            }
            set
            {
                Picture = Services.ConvertToBitmap(value);
            }
        }
        public virtual byte[] IDPictureBytes
        {
            get
            {
                return Services.ConvertToByteArray(IDPicture);
            }
            set
            {
                IDPicture = Services.ConvertToBitmap(value);
            }
        }
        public virtual byte[] NCPictureBytes1
        {
            get
            {
                return Services.ConvertToByteArray(NCPicture1);
            }
            set
            {
                NCPicture1 = Services.ConvertToBitmap(value);
            }
        }
        public virtual byte[] NCPictureBytes2
        {
            get
            {
                return Services.ConvertToByteArray(NCPicture2);
            }
            set
            {
                NCPicture2 = Services.ConvertToBitmap(value);
            }
        }

        [NonPersistent]
        public virtual Bitmap Picture { get; set; }
        [NonPersistent]
        public virtual Bitmap IDPicture { get; set; }
        [NonPersistent]
        public virtual Bitmap NCPicture1 { get; set;}
        [NonPersistent]
        public virtual Bitmap NCPicture2 { get; set; }

        [NonPersistent]
        public virtual bool HasPicture
        {
            get { return Picture != null; }
        }

        [NonPersistent]
        public virtual string HasPictureText
        {
            get
            {
                if (HasPicture)
                    return "دارد";
                return "ندارد";
            }
        }

        public virtual void CorrectPhoto(IDbConnection connection)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "Select * from [PersonPhotos] where Id = " + Id;

            KeyValuePair<int, byte[]> pic = new KeyValuePair<int, byte[]>();

            IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = (int) reader[0];
                byte[] pictureBytes = reader["Picture"] as byte[];
                pic = new KeyValuePair<int, byte[]>(id, pictureBytes);
            }
            reader.Close();

            if (pic.Value == null)
                throw new Exception("برای این دانشجو عکسی ذخیره نشده است");
            
            Bitmap picture;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream stream = new MemoryStream(pic.Value);
            try
            {
                object o = bf.Deserialize(stream);
                picture = (Bitmap)o;
            }
            catch (Exception ex)
            {
                picture = null;
            }
            finally
            {
                stream.Close();
                stream.Dispose();
            }

            if (picture == null)
                throw new Exception("برای این دانشجو عکسی ذخیره نشده است");

            byte[] bytes = Services.ConvertToByteArray(picture);
            picture.Dispose();

            PictureBytes = bytes;
//            IDbCommand command2 = connection.CreateCommand();
//            command2.CommandText = "UPDATE [PersonPhotos] SET PictureBytes = @Param1 where Id = @Param2";
//
//            IDbDataParameter param1 = command2.CreateParameter();
//            param1.ParameterName = "Param1";
//            param1.Value = bytes;
//
//            IDbDataParameter param2 = command2.CreateParameter();
//            param2.ParameterName = "Param2";
//            param2.Value = pic.Key;
//
//            command2.Parameters.Add(param1);
//            command2.Parameters.Add(param2);
//            command2.ExecuteNonQuery();
//            connection.Close();

            Save();
        }

        public static Photo FromId(int id)
        {
            return DbContext.FromId<Photo>(id);
        }
    }
}