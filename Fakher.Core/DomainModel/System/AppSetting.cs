using DataAccessLayer;

namespace Fakher.Core.DomainModel
{
    public class AppSetting : DbObject
    {
        public virtual string Name { get; set; }
        public virtual string Data { get; set; }

        public static string GetSetting(string name)
        {
            DbOperations dbOperations = new DbOperations(DbContext.GetConnectionString());
            object scalar = dbOperations.ExecuteScalar(string.Format("Select Top 1 Data from [AppSettings] where Name='{0}'", name));
            dbOperations.Close();
            if (scalar == null)
                return null;
            return scalar + "";
        }

        public static T GetSetting<T>(string name)
        {
            DbOperations dbOperations = new DbOperations(DbContext.GetConnectionString());
            object scalar = dbOperations.ExecuteScalar(string.Format("Select Top 1 Data from [AppSettings] where Name='{0}'", name));
            dbOperations.Close();
            if (scalar == null)
                return default(T);
            return (T) scalar;
        }

//        public static void SetSetting(string name, string data)
//        {
//            string setting = GetSetting(name);
//            if(setting == null)
//            {
//                DbOperations dbOperations = new DbOperations(DbContext.GetConnectionString());
//                dbOperations.Execute(string.Format(
//                        "INSERT INTO [AppSettings]([Name], [Data]) VALUES(N'{0}', N'{1}')", name, data));
//                dbOperations.Close();
//            }
//            else
//            {
//                DbOperations dbOperations = new DbOperations(DbContext.GetConnectionString());
//                dbOperations.Execute(string.Format(
//                        "Update [AppSettings] SET Data=N'{1}' where Name=N'{0}'", name, data));
//                dbOperations.Close();
//            }
//        }

        public static void SetSetting(string name, string data)
        {
            string setting = GetSetting(name);
            if(setting == null)
            {
                DbOperations dbOperations = new DbOperations(DbContext.GetConnectionString());
                dbOperations.Execute("INSERT INTO [AppSettings]([Name], [Data]) VALUES(@P0, @P1)", false, name, data);
                dbOperations.Close();
            }
            else
            {
                DbOperations dbOperations = new DbOperations(DbContext.GetConnectionString());
                dbOperations.Execute("Update [AppSettings] SET Data=@P0 where Name=@P1", false, data, name);
                dbOperations.Close();
            }
        }
    }
}