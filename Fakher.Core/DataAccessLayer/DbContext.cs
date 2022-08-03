using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.IO;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using Fakher.Core.DomainModel;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Event;

using NHibernate.Tool.hbm2ddl;
using rApplicationEventFramework;
using rComponents;
using System.Linq;

using System.Runtime.Serialization.Formatters.Binary;
using FluentNHibernate.Conventions.Helpers;

namespace DataAccessLayer
{
    public static class DbContext
    {
        private static List<ISession> Sessions;
        private static rEventListener mEventListener;
        
        private static DbEventListener mDbEventListener;
        private static bool mExclusiveSession { get; set; }
        private static Semaphore mSemaphore;

        public static event EventHandler<MeetPolicyEventArgs> PolicyMeeted;
        public static event EventHandler<EntityEventArgs> EntityEvent;
        public static ISessionFactory SessionFactory;
        public static rApplicationEventFactory ApplicationEventFactory;
        public static event EventHandler UnitOfWorkOpening;
        public static event EventHandler UnitOfWorkOpen;
        public static event EventHandler UnitOfWorkClosing;
        public static event EventHandler UnitOfWorkClose;
        public static event EventHandler ExclusiveSessionStart;
        public static event EventHandler ExclusiveSessionEnd;
        private const string SERIALIZED_CFG = "configuration.bin";
        static DbContext()
        {
            Sessions = new List<ISession>();
            ApplicationEventFactory = new rApplicationEventFactory(typeof(DbObject).Assembly);
            ApplicationEventFactory.InsertEntityEvent = true;
            ApplicationEventFactory.DeleteEntityEvent = true;
            ApplicationEventFactory.PolicyMeeted += new EventHandler<MeetPolicyEventArgs>(mApplicationEventFactory_PolicyMeeted);
            ApplicationEventFactory.EntityEvent += new EventHandler<EntityEventArgs>(ApplicationEventFactory_EntityEvent);
            mEventListener = new rEventListener(ApplicationEventFactory);
            mDbEventListener = new DbEventListener();
            mSemaphore = new Semaphore(1, 1);
        }

        static void ApplicationEventFactory_EntityEvent(object sender, EntityEventArgs e)
        {
            if (EntityEvent != null)
                EntityEvent(sender, e);
        }

        static void mApplicationEventFactory_PolicyMeeted(object sender, MeetPolicyEventArgs e)
        {
            if (PolicyMeeted != null)
                PolicyMeeted(sender, e);
        }

        public static void OnUnitOfWorkOpening()
        {
            if (UnitOfWorkOpening != null)
                UnitOfWorkOpening(null, EventArgs.Empty);
        }

        public static void OnUnitOfWorkOpen()
        {
            if (UnitOfWorkOpen != null)
                UnitOfWorkOpen(null, EventArgs.Empty);
        }

        public static void OnUnitOfWorkClosing()
        {
            if (UnitOfWorkClosing != null)
                UnitOfWorkClosing(null, EventArgs.Empty);
        }

        public static void OnUnitOfWorkClose()
        {
            if (UnitOfWorkClose != null)
                UnitOfWorkClose(null, EventArgs.Empty);
        }

        public static void OnExclusiveSessionStart()
        {
            if (ExclusiveSessionStart != null)
                ExclusiveSessionStart(null, EventArgs.Empty);
        }

        public static void OnExclusiveSessionEnd()
        {
            if (ExclusiveSessionEnd != null)
                ExclusiveSessionEnd(null, EventArgs.Empty);
        }

        public static ISession CreateUnitOfWork()
        {
            if (mExclusiveSession)
            {
                if (!mSemaphore.WaitOne(250))
                    throw new Exception("در حال حاضر امکان اتصال به پایگاه داده وجود ندارد.");
            }
            ISession session = SessionFactory.OpenSession();
            session.FlushMode = FlushMode.Never;
            OnUnitOfWorkOpening();
            return session;
        }

        public static ISession OpenUnitOfWork()
        {
//            if (mExclusiveSession)
//            {
//                if (!mSemaphore.WaitOne(250))
//                    throw new Exception("در حال حاضر امکان اتصال به پایگاه داده وجود ندارد.");
//            }
//            ISession session = SessionFactory.OpenSession();
//            OnUnitOfWorkOpening();
//            Sessions.Push(session);
            ISession session = CreateUnitOfWork();
            Sessions.Add(session);
            OnUnitOfWorkOpen();
            return session;
        }

        public static ISession OpenUnitOfWork(bool exclusively)
        {
            if (exclusively)
                StartExclusiveSession(false);
//            mExclusiveSession = exclusively;
//            OnExclusiveSessionStart();
            return OpenUnitOfWork();
        }

        public static void StartExclusiveSession(bool getSemaphore)
        {
            mExclusiveSession = true;
            if (getSemaphore && !mSemaphore.WaitOne(250))
                throw new Exception("در حال حاضر امکان اتصال به پایگاه داده وجود ندارد.");

            OnExclusiveSessionStart();
        }

        public static void EndExclusiveSession()
        {
            if (!mExclusiveSession)
                return;
            mExclusiveSession = false;
            mSemaphore.Release();
            OnExclusiveSessionEnd();
        }

        public static void CloseUnitOfWork()
        {
            ISession session = Sessions.Last();
            CloseUnitOfWork(session);
        }

        public static void CloseUnitOfWork(ISession session)
        {
            OnUnitOfWorkClosing();

            if (!session.IsOpen)
                return;
            if (Sessions.Contains(session))
                Sessions.Remove(session);

//            session.Clear();
            session.Close();
            session.Dispose();
            GC.Collect();

            OnUnitOfWorkClose();
            if (mExclusiveSession)
                EndExclusiveSession();
        }

        public static ISession CurrentSession
        {
            get
            {
                ISession session;
                if (HttpContext.Current == null)
                {
//                    session = Sessions.Peek();
                    session = Sessions.Last();
                }
                else
                {
//                    session = WebsiteHandler.CurrentDbISession;
                    session = SessionFactory.GetCurrentSession();
                }
                if (!session.IsOpen || !session.IsConnected)
                    session.Reconnect();
                return session;
            }
        }

        public static void Evict(object obj)
        {
            ISession[] sessions = Sessions.ToArray();
            foreach (ISession session in sessions)
            {
                if (session.Contains(obj))
                    session.Evict(obj);
            }
        }

        public static ITransaction BeginTransaction()
        {
            ITransaction transaction = CurrentSession.BeginTransaction();
            return transaction;
        }

        public static void BackToMainSession()
        {
            for (int i = Sessions.Count; i > 1; i--)
            {
//                ISession session = Sessions.Pop();
                ISession session = Sessions.Last();
                CloseUnitOfWork(session);
            }
        }

        public static bool IsMainSession()
        {
            return Sessions.Count == 1;
        }

        public static void InitializeDb()
        {
            //            string status = GetAppSetting("Status");
            //            if(status != null && status == "0")
            //            {
            //                Environment.Exit(1);
            //                return;
            //            }

            //            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            //var nhConfig = new Configuration().DataBaseIntegration(db => {
            //    db.Dialect<MsSql2012Dialect>(); db.ConnectionStringName = "db";
            //    db.BatchSize = 100;
            //}); var sessionFactory = nhConfig.BuildSessionFactory();

            
            var fluentConfiguration =Build();
            //FluentConfiguration fluentConfiguration = Fluently.Configure();
            //            fluentConfiguration.Database(
            //                MsSqlConfiguration.MsSql2012
            //                .DefaultSchema("dbo").ConnectionString(connstr => connstr.FromConnectionStringWithKey("db"))
            //                //.ConnectionString(GetConnectionString())
            //                //                .QuerySubstitutions("'True'=1, 'False'=0")
            //                .UseReflectionOptimizer()
            //                .AdoNetBatchSize(100)
            //                //                .Raw("connection.release_mode", "on_close")
            //                //                .Raw("generate_statistics", "true")
            //                //                                .ShowSql()
            //                //                .Cache(c => c.UseQueryCache().ProviderClass(typeof(NHibernate.Caches.SysCache.SysCacheProvider).AssemblyQualifiedName))
            //                );

            //            AutoPersistenceModel autoPersistenceModel = AutoMap.AssemblyOf<DbObject>(new DbContextConfiguration())
            //                .IgnoreBase(typeof(DbObject))
            //                .IgnoreBase(typeof(FinancialEntity))
            //                .IncludeBase<Person>()
            //                .Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Always()
            //                                 , new ClassConvention()
            //                                 , new SubClassConvention()
            //                                 , new JoinedSubClassConvention()
            //                                 , new HasManyConvention()
            //                                 , new ReferenceConvention()
            //                                 , new PersianDateConvention()
            //                                 , new EnumConvention()
            //                                 , new MaxLengthConvention()
            ////                                 , new PropertyConvention()
            //                                )
            //                .Override<Lesson>(map => map.HasManyToMany(x => x.Prerequisites)
            //                                             .Table("LessonPrerequisites").ChildKeyColumn("Prerequisite_id").
            //                                             ParentKeyColumn("Lesson_id"))
            //                .Override<Person>(map => map.HasManyToMany(x => x.AllowedDepartments)
            //                                             .Table("PersonAllowedDepartments").ChildKeyColumn("Department_id").
            //                                             ParentKeyColumn("Person_id"))
            ////                .Override<ReportCardLicense>(map => map.HasManyToMany(x=>x.Exams)
            ////                                             .Table("ReportCardLicenseExams").ChildKeyColumn("Exam_id").
            ////                                             ParentKeyColumn("ReportCardLicense_id"))
            //                .Override<Person>(map => map.References(x => x.Photo).LazyLoad())
            ////                .Override<PersonPhoto>(map => map.Map(x => x.Picture).Length(int.MaxValue).CustomSqlType("image"))
            //                .Override<Photo>(map => map.Map(x => x.PictureBytes).CustomSqlType("varbinary(MAX)").Length(int.MaxValue))
            //                .Override<FinancialDocument>(map => map.HasMany(x => x.Items).KeyColumn("Document_id"))
            //                .Override<FinancialItem>(map => map.References(x => x.Payment).Not.LazyLoad().Cascade.All())
            //                .Override<DbPolicy>(map => map.Not.LazyLoad())
            //                .Override<ExamForm>(map => map.Map(x => x.Key, "[Key]"))
            //                .Override<LessonHolding>(map => map.HasManyToMany(x => x.AllowedMajors)
            //                    .Table("LessonAllowedMajors").ChildKeyColumn("Major_id").ParentKeyColumn("LessonPeriod_id"))
            //                .Override<Register>(map=>map.References(x=>x.Period).Cascade.None())
            //                .Override<Register>(map=>map.HasMany(x=>x.Participates).Cascade.SaveUpdate())
            //                .Override<Participate>(map=>map.References(x=>x.SectionItem).Cascade.None())
            //                .Override<Fakher.Core.Website.MenuItem>(map=>map.HasMany(x=>x.Childs).KeyColumn("Parent_id"))
            ////                .Override<OnlineExamParticipate>(map=>map.Map(x=>x.RawAnswers).ReadOnly())

            ////                .Override<ExamParticipate>(map=>map.References(x=>x.Exam).Cascade.None())
            ////                .Override<OnlineExamParticipate>(map=>map.DynamicUpdate())
            //                ;

            ////            autoPersistenceModel.ValidationEnabled = false;
            ////            autoPersistenceModel.WriteMappingsTo("D:\\1");

            //            fluentConfiguration.Mappings(m => m.AutoMappings.Add(autoPersistenceModel));

            
            SessionFactory = fluentConfiguration.BuildSessionFactory();
        }
        public static Configuration GetConfiguration()
        {

            FluentConfiguration fluentConfiguration = Fluently.Configure();

            fluentConfiguration.Database(
                MsSqlConfiguration.MsSql2012
                .DefaultSchema("dbo").ConnectionString(connstr => connstr.FromConnectionStringWithKey("db"))

                .UseReflectionOptimizer()
                .AdoNetBatchSize(100)
                              );

            AutoPersistenceModel autoPersistenceModel = AutoMap.AssemblyOf<DbObject>(new DbContextConfiguration())
                .IgnoreBase(typeof(DbObject))
                .IgnoreBase(typeof(FinancialEntity))
                .IncludeBase<Person>()
                .Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Always()
                                 , new ClassConvention()
                                 , new SubClassConvention()
                                 , new JoinedSubClassConvention()
                                 , new HasManyConvention()
                                 , new ReferenceConvention()
                                 , new PersianDateConvention()
                                 , new EnumConvention()
                                 , new MaxLengthConvention()
                                )
                .Override<Lesson>(map => map.HasManyToMany(x => x.Prerequisites)
                                             .Table("LessonPrerequisites").ChildKeyColumn("Prerequisite_id").
                                             ParentKeyColumn("Lesson_id"))
                .Override<Person>(map => map.HasManyToMany(x => x.AllowedDepartments)
                                             .Table("PersonAllowedDepartments").ChildKeyColumn("Department_id").
                                             ParentKeyColumn("Person_id"))

                .Override<Person>(map => map.References(x => x.Photo).LazyLoad())
               //.Override<Person>(map => map.Map(x => x.Notes).CustomSqlType("nvarchar(MAX)").Length(int.MaxValue))
                .Override<Photo>(map => map.Map(x => x.PictureBytes).CustomSqlType("varbinary(MAX)").Length(int.MaxValue))
                //.Override<Photo>(map => map.Map(x => x.NCPicture1).CustomSqlType("image").Length(int.MaxValue))
                //.Override<Photo>(map => map.Map(x => x.NCPicture2).CustomSqlType("image").Length(int.MaxValue))
                .Override<Photo>(map => map.Map(x => x.IDPictureBytes).CustomSqlType("varbinary(MAX)").Length(int.MaxValue))
                .Override<Photo>(map => map.Map(x => x.NCPictureBytes1).CustomSqlType("varbinary(MAX)").Length(int.MaxValue))
                .Override<Photo>(map => map.Map(x => x.NCPictureBytes2).CustomSqlType("varbinary(MAX)").Length(int.MaxValue))
                .Override<FinancialDocument>(map => map.HasMany(x => x.Items).KeyColumn("Document_id"))
                .Override<FinancialItem>(map => map.References(x => x.Payment).Not.LazyLoad().Cascade.All())
                .Override<DbPolicy>(map => map.Not.LazyLoad())
                .Override<ExamForm>(map => map.Map(x => x.Key, "[Key]"))
                .Override<LessonHolding>(map => map.HasManyToMany(x => x.AllowedMajors)
                    .Table("LessonAllowedMajors").ChildKeyColumn("Major_id").ParentKeyColumn("LessonPeriod_id"))
                .Override<Register>(map => map.References(x => x.Period).Cascade.None())
                .Override<Register>(map => map.HasMany(x => x.Participates).Cascade.SaveUpdate())
                .Override<Participate>(map => map.References(x => x.SectionItem).Cascade.None())
                .Override<Fakher.Core.Website.MenuItem>(map => map.HasMany(x => x.Childs).KeyColumn("Parent_id"))

                ;


            fluentConfiguration.Mappings(m => m.AutoMappings.Add(autoPersistenceModel));
            fluentConfiguration.ExposeConfiguration(Config);
            return fluentConfiguration.BuildConfiguration();
            //fluentConfiguration.ExposeConfiguration(Config);
            //SessionFactory = fluentConfiguration.BuildSessionFactory();
        }
        public static Configuration Build()
        {
            var cfg = LoadConfigurationFromFile();
            if (cfg == null)
            {
                cfg = GetConfiguration();
                SaveConfigurationToFile(cfg);
            }
            return cfg;
        }
        private static Configuration LoadConfigurationFromFile()
        {
            var configFileName = SERIALIZED_CFG;
            if (HttpContext.Current!=null)
                configFileName=HttpContext.Current.Server.MapPath("~/" + SERIALIZED_CFG);
            
            if (!IsConfigurationFileValid()) return null; try { using (var file = File.Open(configFileName!=null?configFileName: SERIALIZED_CFG, FileMode.Open)) { var bf = new BinaryFormatter(); return bf.Deserialize(file) as Configuration; } }
            catch (Exception)
            {             // Something went wrong             // Just build a new one         
                return null;
            }
        }

        private static bool IsConfigurationFileValid()
        {
            var configFileName = SERIALIZED_CFG;
            if (HttpContext.Current != null)
                configFileName = HttpContext.Current.Server.MapPath("~/" + SERIALIZED_CFG);
            if (!File.Exists(configFileName != null ? configFileName : SERIALIZED_CFG))
                return false;
            var configInfo = new FileInfo(configFileName != null ? configFileName : SERIALIZED_CFG);
            var asm = Assembly.GetExecutingAssembly();
            if (asm.Location == null)
                return false;       // If the assembly is newer,        // the serialized config is stale      
            var asmInfo = new FileInfo(asm.Location);
            if (asmInfo.LastWriteTime > configInfo.LastWriteTime)
                return false;        // If the app.config is newer,         // the serialized config is stale 
            var appDomain = AppDomain.CurrentDomain;
            var appConfigPath = appDomain.SetupInformation.ConfigurationFile;
            var appConfigInfo = new FileInfo(appConfigPath);
            if (appConfigInfo.LastWriteTime > configInfo.LastWriteTime)
                return false;      // It's still fresh 
            return true;
        }
        private static void SaveConfigurationToFile(Configuration cfg)
        {
            var configFileName = SERIALIZED_CFG;
            if (HttpContext.Current != null)
                configFileName = HttpContext.Current.Server.MapPath("~/" + SERIALIZED_CFG);

            using (var file = File.Open(configFileName != null ? configFileName : SERIALIZED_CFG, FileMode.Create))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(file, cfg);
            }
        }
        public static void CloseDb()
        {
            BackToMainSession();
            SessionFactory.Close();
        }

        public static string GetDatabaseName()
        {
            //return "FakherMIS2";
            return "FakherMIS4";
        }

        public static string GetConnectionString()
        {
            //            SqlConnectionStringBuilder x = new SqlConnectionStringBuilder();
            ////            x.MultipleActiveResultSets = true;
            //            x.DataSource = GetAppConfig("DataSource");
            //            x.InitialCatalog = GetDatabaseName();
            //            x.UserID = GetUser().Key;
            //            x.Password = GetUser().Value;
            //            x.MaxPoolSize = 1000;

            //return x.ConnectionString;

            return System.Configuration.ConfigurationManager.
    ConnectionStrings["db"].ConnectionString;
        }

        public static KeyValuePair<string, string> GetUser()
        {
            if (HttpContext.Current != null)
                return new KeyValuePair<string, string>("MISWebUser", "9aK7hgc3IkbMflFC");
            return new KeyValuePair<string, string>("MISAppUser", "hnX6DP7cx8NEEQvD");
        }

//        public static string GetAppSetting(string name)
//        {
//            DbOperations dbOperations = new DbOperations(GetConnectionString());
//            object scalar = dbOperations.ExecuteScalar(string.Format("Select Data from [AppSettings] where Name='{0}'", name));
//            dbOperations.Close();
//            if (scalar == null)
//                return null;
//            return scalar + "";
//        }

        public static void Config(Configuration cfg)
        {
            //            for logical delete
            //            cfg.SetListener(ListenerType.Delete, new LogicalDelete());

            cfg.SetListeners(ListenerType.PostInsert, new IPostInsertEventListener[] { mEventListener, mDbEventListener });
            cfg.SetListeners(ListenerType.PostUpdate, new IPostUpdateEventListener[] { /*mEventListener,*/ mDbEventListener });
//            cfg.SetListeners(ListenerType.PostDelete, new IPostDeleteEventListener[] { mEventListener });

            cfg.SetListeners(ListenerType.PreInsert, new IPreInsertEventListener[] { mDbEventListener });
            cfg.SetListeners(ListenerType.PreUpdate, new IPreUpdateEventListener[] { mDbEventListener });

//            cfg.SetListener(ListenerType.PostInsert, mEventListener);
//            cfg.SetListener(ListenerType.PostUpdate, mEventListener);
//            cfg.SetListener(ListenerType.PostDelete, mEventListener);

//            cfg.SetListener(ListenerType.PreInsert, mDbEventListener);
//            cfg.SetListener(ListenerType.PreUpdate, mDbEventListener);

//            cfg.SetListener(ListenerType.PostInsert, mDbEventListener);
//            cfg.SetListener(ListenerType.PostUpdate, mDbEventListener);

            if (HttpContext.Current != null)
                cfg.SetProperty("current_session_context_class", "web");
            
            SchemaUpdate schemaUpdate = new SchemaUpdate(cfg);
            schemaUpdate.Execute(true, true);
        }

        public static string GetAppConfig(string key)
        {
            //            string value = ConfigurationManager.AppSettings[key];
            //            return value;

            string path;
            if (HttpContext.Current == null)
                path = Application.StartupPath;
            else
                path = HttpContext.Current.Server.MapPath("~");

            string source = ".";
            XmlTextReader reader = new XmlTextReader(path + "\\AppConfig.xml");
            while (reader.Read())
            {
                //"DataSource" 
                if (reader.Name == key && reader.NodeType == XmlNodeType.Element)
                {
                    reader.Read();
                    source = reader.Value;
                    break;
                }
            }
            reader.Close();
            return source;
        }

        public static void CreateBackup(string filename)
        {
            //            string file = Path.GetFileName(filename);
            //            string backupDir;
            //            RegistryKey registry;
            //            try
            //            {
            //                registry = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Microsoft SQL Server").OpenSubKey("MSSQL.1").OpenSubKey("MSSQLServer");
            //                backupDir = registry.GetValue("BackupDirectory") as string;
            //            }
            //            catch (Exception ex)
            //            {
            //                throw new Exception("تهیه پشتیبان فقط برای کاربرهای با سطح دسترسی مدیر در ویندوز امکان پذیر است.\nکاربر ویندوز شما قادر به تهیه پشتیبان نیست.", ex);
            //            }

            IDbConnection connection = CurrentSession.Connection;
            IDbCommand command = connection.CreateCommand();
            try
            {
                command.CommandText = "BACKUP DATABASE " + GetDatabaseName() + " TO DISK=N'" + filename + "' WITH FORMAT";
                command.ExecuteNonQuery();
                //                File.Copy(backupDir + "\\" + file, filename, true);
                //                File.Delete(backupDir + "\\" + file);
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در هنگام ایجاد پشتیبان از پایگاه داده \n" + ex.Message, ex);
            }
        }

        public static void RestoreBackup(string fileName)
        {
            //            string file = Path.GetFileName(fileName);
            //            string backupDir;
            //            RegistryKey registry;
            //            try
            //            {
            //                registry = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Microsoft SQL Server").OpenSubKey("MSSQL.1").OpenSubKey("MSSQLServer");
            //                backupDir = registry.GetValue("BackupDirectory") as string;
            //            }
            //            catch (Exception ex)
            //            {
            //                throw new Exception("تهیه پشتیبان فقط برای کاربرهای با سطح دسترسی مدیر در ویندوز امکان پذیر است.\nکاربر ویندوز شما قادر به تهیه پشتیبان نیست.", ex);
            //            }

            IDbConnection connection = CurrentSession.Connection;
            IDbCommand command = connection.CreateCommand();
            string defaultDB = connection.Database;
            //            string tmpBackupFile = backupDir + "\\" + file;
            try
            {
                //                File.Copy(fileName, tmpBackupFile, true);
                connection.ChangeDatabase("master");
                command.CommandText = "RESTORE DATABASE " + defaultDB + " FROM DISK=N'" + fileName + "' WITH REPLACE";
                command.ExecuteNonQuery();
                connection.ChangeDatabase(defaultDB);
                //                File.Delete(tmpBackupFile);
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در هنگام ایجاد پشتیبان از پایگاه داده \n" + ex.Message, ex);
            }
        }
      
        public static IQueryable<T> Entity<T>()
        {
            IQueryable<T> queryable = CurrentSession.Query<T>();
            //            INHibernateQueryable<T> nHibernateQueryable = CurrentSession.Linq<T>();
            //            nHibernateQueryable.QueryOptions.SetCachable(true);
            //            return nHibernateQueryable;
            return queryable;
        }

        //        public static IQueryable<T> Expand<T>(this IQueryable<T> queryable, Expression<Func<T, object>> func)
        //        {
        //            PropertyInfo propertyInfo = (func.Body as MemberExpression).Member as PropertyInfo;
        //            IQueryable<T> query = (queryable as INHibernateQueryable<T>).Expand(propertyInfo.Name);
        //            return query;
        //        }

        public static int GetCount<T>()
        {
            var query = from obj in Entity<T>() select obj;
            return query.Count();
        }

        public static List<T> GetAllEntities<T>()
        {
            var query = from obj in Entity<T>() select obj;
            return query.ToList();
        }

        public static IQueryable<T> GetAll<T>()
        {
            var query = from obj in Entity<T>() select obj;
            return query;
        }

        public static T FromId<T>(object id)
        {
            //            ISession session = OpenSession();
            return CurrentSession.Get<T>(id);
        }

        public static int RunSQL(string sql)
        {
            using (IDbCommand dbCommand = CurrentSession.Connection.CreateCommand())
            {
                dbCommand.CommandText = sql;
                return dbCommand.ExecuteNonQuery();
            }
        }
    }

    public class DbContextConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Member member)
        {
            int length = member.MemberInfo.GetCustomAttributes(typeof(NonPersistent), true).Length;
            if (length != 0)
            {

            }
            return member.IsProperty && length == 0 && base.ShouldMap(member);
        }

        public override bool ShouldMap(Type type)
        {
            bool shouldMap = type.IsSubclassOf(typeof(DbObject));
            if(shouldMap)
            {
//                DbObjectTypeDescriptionProvider.Register(type);
            }
            return shouldMap;
        }
    }

    public class NonPersistent : Attribute
    {

    }

    public class MaximumLength : Attribute
    {

    }

    public class Attendant : Attribute
    {

    }    
    
    public class NoProxy : Attribute
    {

    }

    public class NoCascade : Attribute
    {

    }

    public class PersianDateConvention : UserTypeConvention<PersianDate>
    {

    }

    public class EnumConvention : IUserTypeConvention
    {
        public bool Accept(Type type)
        {
            return type.IsEnum;
        }

        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Property.PropertyType.IsEnum);
        }

        public void Apply(IPropertyInstance instance)
        {
            instance.CustomType(instance.Property.PropertyType);
        }
    }

    public class ClassConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table(Services.PluralOf(instance.EntityType.Name));
            instance.Where("IsDeleted is null or IsDeleted = 0");
            instance.DynamicUpdate();
        }
    }

    public class SubClassConvention : ISubclassConvention
    {
        public void Apply(ISubclassInstance instance)
        {
            instance.DynamicUpdate();
        }
    }

    public class JoinedSubClassConvention : IJoinedSubclassConvention
    {
        public void Apply(IJoinedSubclassInstance instance)
        {
            instance.DynamicUpdate();
        }
    }

    public class ReferenceConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
//            instance.Not.LazyLoad();
//            instance.Fetch.Join();

            instance.LazyLoad();
//            instance.Cascade.SaveUpdate();   // ba if NoCascade payeen edgham shod

            int length = instance.Property.MemberInfo.GetCustomAttributes(typeof(Attendant), false).Length;
            if (length > 0)
            {
                instance.Not.LazyLoad();
                instance.Fetch.Join();
            }

            length = instance.Property.MemberInfo.GetCustomAttributes(typeof(NoProxy), false).Length;
            if (length > 0)
            {
                instance.LazyLoad(Laziness.NoProxy);
            }

            length = instance.Property.MemberInfo.GetCustomAttributes(typeof(NoCascade), false).Length;
            if (length > 0)
            {
                instance.Cascade.None();
            }
            else
            {
                instance.Cascade.SaveUpdate();
            }
        }
    }

    public class HasManyConvention : IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            //            instance.Inverse();

            instance.LazyLoad();
            //            instance.Cascade.All(); // ba if NoCascade payeen edgham shod


            //            instance.Where("IsDeleted is null or IsDeleted = 0");
            // ba many to many relation'ha moshkel dasht chon ke table many to many isdeleted nadare

            int length = instance.Member.GetCustomAttributes(typeof(Attendant), true).Length;
            if (length > 0)
            {
                instance.Not.LazyLoad();
                //instance.Fetch.Join();
               
            }

            length = instance.Member.GetCustomAttributes(typeof(NoCascade), true).Length;
            if (length > 0)
            {
                instance.Cascade.None();
            }
            else
            {
                instance.Cascade.All();
            }
        }
    }

    public class MaxLengthConvention : AttributePropertyConvention<MaximumLength>
    {
        protected override void Apply(MaximumLength attribute, IPropertyInstance instance)
        {
            instance.Length(10000);
        }
    }

    //    public class PropertyConvention : IPropertyConvention
    //    {
    //        #region Implementation of IConvention<IPropertyInspector,IPropertyInstance>
    //
    //        public void Apply(IPropertyInstance instance)
    //        {
    //        }
    //
    //        #endregion
    //    }
    //    public class LogicalDelete : DefaultDeleteEventListener
    //    {
    //        protected override void DeleteEntity(IEventSource session, object entity, EntityEntry entityEntry, bool isCascadeDeleteEnabled, IEntityPersister persister, ISet transientEntities)
    //        {
    //            if (entity is DbObject)
    //            {
    //                (entity as DbObject).IsDeleted = true;
    //                CascadeBeforeDelete(session, persister, entity, entityEntry, transientEntities);
    //                CascadeAfterDelete(session, persister, entity, transientEntities);
    //            }
    //            else
    //            {
    //                base.DeleteEntity(session, entity, entityEntry, isCascadeDeleteEnabled, persister, transientEntities);
    //            }
    //        }
    //    }


    //public class ConfigurationBuilder { private const string SERIALIZED_CFG = "configuration.bin";
 
    //    public static Configuration GetConfiguration(Configuration Config)
    //    {
            
    //        FluentConfiguration fluentConfiguration = Fluently.Configure();
            
    //        fluentConfiguration.Database(
    //            MsSqlConfiguration.MsSql2012
    //            .DefaultSchema("dbo").ConnectionString(connstr => connstr.FromConnectionStringWithKey("db"))

    //            .UseReflectionOptimizer()
    //            .AdoNetBatchSize(100)
    //                          );

    //        AutoPersistenceModel autoPersistenceModel = AutoMap.AssemblyOf<DbObject>(new DbContextConfiguration())
    //            .IgnoreBase(typeof(DbObject))
    //            .IgnoreBase(typeof(FinancialEntity))
    //            .IncludeBase<Person>()
    //            .Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Always()
    //                             , new ClassConvention()
    //                             , new SubClassConvention()
    //                             , new JoinedSubClassConvention()
    //                             , new HasManyConvention()
    //                             , new ReferenceConvention()
    //                             , new PersianDateConvention()
    //                             , new EnumConvention()
    //                             , new MaxLengthConvention()
    //                            )
    //            .Override<Lesson>(map => map.HasManyToMany(x => x.Prerequisites)
    //                                         .Table("LessonPrerequisites").ChildKeyColumn("Prerequisite_id").
    //                                         ParentKeyColumn("Lesson_id"))
    //            .Override<Person>(map => map.HasManyToMany(x => x.AllowedDepartments)
    //                                         .Table("PersonAllowedDepartments").ChildKeyColumn("Department_id").
    //                                         ParentKeyColumn("Person_id"))

    //            .Override<Person>(map => map.References(x => x.Photo).LazyLoad())
    //            .Override<Photo>(map => map.Map(x => x.PictureBytes).CustomSqlType("varbinary(MAX)").Length(int.MaxValue))
    //            .Override<FinancialDocument>(map => map.HasMany(x => x.Items).KeyColumn("Document_id"))
    //            .Override<FinancialItem>(map => map.References(x => x.Payment).Not.LazyLoad().Cascade.All())
    //            .Override<DbPolicy>(map => map.Not.LazyLoad())
    //            .Override<ExamForm>(map => map.Map(x => x.Key, "[Key]"))
    //            .Override<LessonHolding>(map => map.HasManyToMany(x => x.AllowedMajors)
    //                .Table("LessonAllowedMajors").ChildKeyColumn("Major_id").ParentKeyColumn("LessonPeriod_id"))
    //            .Override<Register>(map => map.References(x => x.Period).Cascade.None())
    //            .Override<Register>(map => map.HasMany(x => x.Participates).Cascade.SaveUpdate())
    //            .Override<Participate>(map => map.References(x => x.SectionItem).Cascade.None())
    //            .Override<Fakher.Core.Website.MenuItem>(map => map.HasMany(x => x.Childs).KeyColumn("Parent_id"))

    //            ;


    //        fluentConfiguration.Mappings(m => m.AutoMappings.Add(autoPersistenceModel));
    //        fluentConfiguration.ExposeConfiguration(Config);
    //        return fluentConfiguration.BuildConfiguration();
    //        //fluentConfiguration.ExposeConfiguration(Config);
    //        //SessionFactory = fluentConfiguration.BuildSessionFactory();
    //    }
    //    public Configuration Build(Configuration Config)
    //{
    //    var cfg = LoadConfigurationFromFile();
    //    if (cfg == null)
    //    {
    //            cfg = GetConfiguration(Config);
    //        SaveConfigurationToFile(cfg);
    //    }
    //    return cfg;
    //}
    //private Configuration LoadConfigurationFromFile()
    //{
    //    if (!IsConfigurationFileValid()) return null; try { using (var file = File.Open(SERIALIZED_CFG, FileMode.Open)) { var bf = new BinaryFormatter(); return bf.Deserialize(file) as Configuration; } }
    //    catch (Exception)
    //    {             // Something went wrong             // Just build a new one         
    //        return null;
    //    }
    //}

    //    private bool IsConfigurationFileValid()
    //    {     // If we don't have a cached config,      // force a new one to be built    
    //        if (!File.Exists(SERIALIZED_CFG))
    //            return false;
    //        var configInfo = new FileInfo(SERIALIZED_CFG);
    //        var asm = Assembly.GetExecutingAssembly();
    //        if (asm.Location == null) 
    //            return false;       // If the assembly is newer,        // the serialized config is stale      
    //        var asmInfo = new FileInfo(asm.Location);
    //        if (asmInfo.LastWriteTime > configInfo.LastWriteTime)
    //            return false;        // If the app.config is newer,         // the serialized config is stale 
    //        var appDomain = AppDomain.CurrentDomain;
    //        var appConfigPath = appDomain.SetupInformation.ConfigurationFile;
    //        var appConfigInfo = new FileInfo(appConfigPath);
    //        if (appConfigInfo.LastWriteTime > configInfo.LastWriteTime)
    //            return false;      // It's still fresh 
    //        return true;
    //    }
    //    private void SaveConfigurationToFile(Configuration cfg)
    //{
    //    using (var file = File.Open(SERIALIZED_CFG, FileMode.Create))
    //    { var bf = new BinaryFormatter(); 
    //            bf.Serialize(file, cfg); 
    //        }
    //}
    //}
}