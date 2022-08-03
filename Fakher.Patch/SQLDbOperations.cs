using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using Edge32;
using Microsoft.Win32;

namespace Services
{
	public class SQLDbOperations
	{
		private List<string> migratedTables;
		private string mDbName;
		private string mServerName;
		private string mUsername;
		private string mPassword;
		private SQLDB sqlDb;
		private static string mDefaultInstanceName = "MSSQLSERVER";
		public event EventHandler<ProgressEventArgs> Progress;

		private SQLDbOperations()
		{
			migratedTables = new List<string>();
		}

		public SQLDbOperations(string serverName, string db) : this()
		{
			mDbName = db;
			mServerName = serverName;
			sqlDb = new SQLDB(mDbName, mServerName, 0);
		}

		public SQLDbOperations(string serverName, string dbName, string username, string password) : this()
		{
			mDbName = dbName;
			mServerName = serverName;
			mUsername = username;
			mPassword = password;
			sqlDb = new SQLDB(mDbName, mServerName, mUsername, mPassword, 0);
		}

		private void OnProgress(string text, int value, int maxValue)
		{
			if (Progress != null)
				Progress(this, new ProgressEventArgs(text, value, maxValue));
		}

		public void AddMigratedTable(string tableName)
		{
			migratedTables.Add(tableName);
		}

		public void CreateConstraintFromSQL(string sql, bool dropIfExists)
		{
			string[] lines = sql.Split(new char[] { '\n', '\r' });
			int index = 1;
			foreach (string line in lines)
			{
				if (string.IsNullOrEmpty(line))
					continue;
				string table =
					line.Substring(line.IndexOf("table") + 5, line.IndexOf("add") - line.IndexOf("table") - 5).Trim();
				string cName =
					line.Substring(line.IndexOf("constraint") + 10,
								   line.IndexOf("foreign") - line.IndexOf("constraint") - 10).Trim();
				string colName = line.Substring(line.IndexOf("(") + 1, line.IndexOf(")") - line.IndexOf("(") - 1).Trim();

				try
				{
					OnProgress("افزودن قید به جدول [" + table + "]", index, lines.Length);
					if (IsTableExists(table) && IsColumnExists(table, colName))
					{
						if (dropIfExists)
						{
							sqlDb.ExecuteCommand(
								string.Format(
									@"IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'{1}') and OBJECTPROPERTY(id, N'IsForeignKey') = 1 )
															alter table {0} drop constraint {1}",
									table, cName));
						}
						sqlDb.ExecuteCommand(line.Trim());
					}
					index++;
				}
				catch (Exception e)
				{
					throw e;
				}
			}
		}

		public void DropConstraintFromSQL(string sql)
		{
			string[] lines = sql.Split(new char[] { '\n', '\r' });
			string query = "";
			foreach (string line in lines)
			{
				if (string.IsNullOrEmpty(line))
					continue;
				string table =
					line.Substring(line.IndexOf("table") + 5, line.IndexOf("add") - line.IndexOf("table") - 5).Trim();
				string cName =
					line.Substring(line.IndexOf("constraint") + 10,
								   line.IndexOf("foreign") - line.IndexOf("constraint") - 10).Trim();
				string refTable = line.Substring(line.IndexOf("references") + 10).Trim();

				query +=
					string.Format(
						@"IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' 
                                                AND CONSTRAINT_NAME='{1}' AND TABLE_NAME='{0}') 
                                                BEGIN 
                                                    alter table {0} drop constraint {1}; 
                                                END",
						table, cName);
				query += "\n\n";
			}
			sqlDb.ExecuteCommand(query);
		}

		public void DropConstraint(Constraint constraint)
		{
			sqlDb.ExecuteCommand("Alter Table [" + constraint.Table + "] DROP CONSTRAINT " + constraint.Name);
		}

		public void DropAllConstraints(ConstraintType type)
		{
			List<string> tables = GetAllDbTable();
			List<Constraint> mConstraints;
			foreach (string table in tables)
			{
				if (table == "dtproperties" || table == "sysdiagrams")
					continue;

				OnProgress("حذف قیدهای جدول [" + table + "]", tables.IndexOf(table), tables.Count);

				mConstraints = FindConstraintsTo(table);
				foreach (Constraint mConstraint in mConstraints)
					if (mConstraint.Type == type)
						DropConstraint(mConstraint);

				mConstraints = FindConstraintsBy(table);
				foreach (Constraint mConstraint in mConstraints)
					if (mConstraint.Type == type)
						DropConstraint(mConstraint);
			}
		}

		public List<Constraint> FindConstraintsBy(string tableName)
		{
			var mConstraints = new List<Constraint>();

			DataTable table =
				sqlDb.GetAllRows(
					string.Format(
						@"SELECT r2.CONSTRAINT_TYPE, r2.CONSTRAINT_NAME, r2.TABLE_NAME, r2.COLUMN_NAME, r2.[UNIQUE_CONSTRAINT_NAME]
                        , r1.TABLE_NAME as REFERENCE_TABLE_NAME
                        FROM [INFORMATION_SCHEMA].[TABLE_CONSTRAINTS] as r1
                        right join (
                        SELECT t1.CONSTRAINT_TYPE, t1.CONSTRAINT_NAME, t1.TABLE_NAME, t2.COLUMN_NAME, t3.[UNIQUE_CONSTRAINT_NAME] 
                        FROM [INFORMATION_SCHEMA].[TABLE_CONSTRAINTS] as t1
                        Inner join [INFORMATION_SCHEMA].[KEY_COLUMN_USAGE] as t2 on t2.[CONSTRAINT_NAME] = t1.[CONSTRAINT_NAME]
                        left join [INFORMATION_SCHEMA].[REFERENTIAL_CONSTRAINTS] as t3 on t3.[CONSTRAINT_NAME] = t1.[CONSTRAINT_NAME]
                        WHERE t1.TABLE_NAME = '{0}') as r2 on r1.CONSTRAINT_NAME = r2.UNIQUE_CONSTRAINT_NAME;",
						tableName));
			//            DataTable table =
			//                sqlDb.GetAllRows(
			//                    string.Format(
			//                        @"SELECT * FROM [INFORMATION_SCHEMA].[TABLE_CONSTRAINTS]
			//            Inner join [INFORMATION_SCHEMA].[KEY_COLUMN_USAGE] on [INFORMATION_SCHEMA].[KEY_COLUMN_USAGE].[CONSTRAINT_NAME] = [INFORMATION_SCHEMA].[TABLE_CONSTRAINTS].[CONSTRAINT_NAME]
			//            WHERE [INFORMATION_SCHEMA].[TABLE_CONSTRAINTS].TABLE_NAME = '{0}'",
			//                        tableName));

			foreach (DataRow row in table.Rows)
				mConstraints.Add(Constraint.FromDataRow(row));

			return mConstraints;
		}

		public List<Constraint> FindConstraintsTo(string tableName)
		{
			var mConstraints = new List<Constraint>();
			DataTable table =
				sqlDb.GetAllRows(
					string.Format(
						@"Select * from [INFORMATION_SCHEMA].[TABLE_CONSTRAINTS] 
                        Inner join [INFORMATION_SCHEMA].[KEY_COLUMN_USAGE] on [INFORMATION_SCHEMA].[KEY_COLUMN_USAGE].[CONSTRAINT_NAME] = [INFORMATION_SCHEMA].[TABLE_CONSTRAINTS].[CONSTRAINT_NAME]
                        where [INFORMATION_SCHEMA].[TABLE_CONSTRAINTS].[CONSTRAINT_NAME] in (
                        Select [CONSTRAINT_NAME] from [INFORMATION_SCHEMA].[REFERENTIAL_CONSTRAINTS] WHERE [UNIQUE_CONSTRAINT_NAME] in (
                        select [CONSTRAINT_NAME] from [INFORMATION_SCHEMA].[TABLE_CONSTRAINTS] where [CONSTRAINT_TYPE] = N'PRIMARY KEY' and TABLE_NAME = '{0}' ))",
						tableName));
			foreach (DataRow row in table.Rows)
				mConstraints.Add(Constraint.FromDataRow(row));

			return mConstraints;
		}

		public List<Constraint> GetAllDbConstraints()
		{
			List<Constraint> mConstraints = new List<Constraint>();
			DataTable table =
				sqlDb.GetAllRows(
					string.Format(
						@"SELECT * FROM [INFORMATION_SCHEMA].[TABLE_CONSTRAINTS]
                         inner join [INFORMATION_SCHEMA].[CONSTRAINT_COLUMN_USAGE] 
                            on [INFORMATION_SCHEMA].[CONSTRAINT_COLUMN_USAGE].CONSTRAINT_NAME = [INFORMATION_SCHEMA].[TABLE_CONSTRAINTS].CONSTRAINT_NAME
                            WHERE [INFORMATION_SCHEMA].[TABLE_CONSTRAINTS].[CONSTRAINT_CATALOG] = '{0}'",
						mDbName));
			foreach (DataRow row in table.Rows)
			{
				try
				{
					mConstraints.Add(Constraint.FromDataRow(row));
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}
			return mConstraints;
		}

		public Constraint FindIdentityConstraint(string tableName)
		{
			List<Constraint> mConstraints = FindConstraintsBy(tableName);
			foreach (Constraint mConstraint in mConstraints)
				if (mConstraint.Type == ConstraintType.PrimaryKey)
					return mConstraint;
			return null;
		}

		public void ReConstructId(string tableName, IdType idType)
		{
			Constraint idConstraint = FindIdentityConstraint(tableName);
			List<Constraint> mConstraints = FindConstraintsTo(tableName);

			foreach (Constraint cons in mConstraints)
			{
				DropConstraint(cons);
				sqlDb.ExecuteCommand("Alter Table [" + cons.Table + "] add constraint " + cons.Name + " foreign key (" +
								  cons.ColumnName + ") references " + tableName + " ON UPDATE CASCADE ");
				sqlDb.ExecuteCommand(string.Format(@"
						BEGIN TRANSACTION
						SET ARITHABORT ON
						CREATE NONCLUSTERED INDEX {0} ON {1} ({2}) ON [PRIMARY]
						COMMIT", cons.Table + "_" + cons.Name, cons.Table, cons.ColumnName));
//				sqlDb.ExecuteCommand(string.Format(@"
//						BEGIN TRANSACTION
//						SET QUOTED_IDENTIFIER ON
//						SET ARITHABORT ON
//						SET NUMERIC_ROUNDABORT OFF
//						SET CONCAT_NULL_YIELDS_NULL ON
//						SET ANSI_NULLS ON
//						SET ANSI_PADDING ON
//						SET ANSI_WARNINGS ON
//						CREATE NONCLUSTERED INDEX {0} ON {1}
//							({2}) ON [PRIMARY]
//						ALTER TABLE {1} SET (LOCK_ESCALATION = TABLE)
//						COMMIT", cons.Table + "_" + cons.Name, cons.Table, cons.ColumnName));
			}

			DataTable table = sqlDb.GetAllRows("SELECT * FROM " + tableName);

			for (int i = 0; i < table.Rows.Count; i++)
			{
				DataRow row = table.Rows[i];
				string idValue = row[idConstraint.ColumnName] + "";
				string newIdValue = null;

				if (idType == IdType.Guid /*&& StringTools.IsGuid(idValue)*/)
					continue;

				if (idType == IdType.Guid)
					newIdValue = Guid.NewGuid() + "";

				if (idType == IdType.Int32)
					newIdValue = i + 1 + "";

				try
				{
					sqlDb.ExecuteCommand(string.Format("UPDATE [{0}] SET {1} = '{2}' WHERE {1} = '{3}'", idConstraint.Table,
													   idConstraint.ColumnName, newIdValue, idValue));
					OnProgress("بازسازی شناسه های [" + tableName + "] به " + idType, i, table.Rows.Count);
				}
				catch (Exception e)
				{
					throw e;
				}
			}

			foreach (Constraint cons in mConstraints)
			{
				DropConstraint(cons);
				sqlDb.ExecuteCommand("Alter Table [" + cons.Table + "] add constraint " + cons.Name + " foreign key (" +
				  cons.ColumnName + ") references " + tableName);
				sqlDb.ExecuteCommand(string.Format(@"
						BEGIN TRANSACTION
						SET ARITHABORT ON
						DROP INDEX {1}.{0}
						COMMIT
						", cons.Table + "_" + cons.Name, cons.Table));
			}
		}

		public List<string> GetAllDbTable()
		{
			var tables = new List<string>();
			DataTable table =
				sqlDb.GetAllRows(
					@"SELECT * FROM [INFORMATION_SCHEMA].[TABLES] WHERE [INFORMATION_SCHEMA].[TABLES].[TABLE_TYPE] = 'BASE TABLE'");
			foreach (DataRow row in table.Rows)
				tables.Add(row["TABLE_NAME"] + "");
			return tables;
		}

		public bool IsTableExists(string tableName)
		{
			List<string> tables = GetAllDbTable();
			foreach (string table in tables)
			{
				if(table == tableName)
					return true;
			}
			return false;
		}

		public bool IsColumnExists(string tableName, string columnName)
		{
			SqlDataReader sourceReader = null;
			try
			{
				sourceReader = sqlDb.ExcuteReader(string.Format("SELECT * FROM [{0}]", tableName));
				DataTable sourceSchemaTable = sourceReader.GetSchemaTable();
				foreach (DataRow row in sourceSchemaTable.Rows)
				{
					string name = row["ColumnName"] + "";
					if (name.ToLower().Trim() == columnName.ToLower().Trim())
						return true;
				}
				return false;

			}
			finally
			{
				sourceReader.Close();
			}
		}

		public void Migrate(string table, string destinationServer, string destinationDb)
		{
			Migrate(table, destinationServer, destinationDb, null, null);
		}

		public void Migrate(string table, string destinationServer, string destinationDb, string username, string password)
		{
			if (migratedTables.Contains(table))
				return;

			SQLDbOperations destinationOperations;
			if(!string.IsNullOrEmpty(username))
				destinationOperations = new SQLDbOperations(destinationServer, destinationDb, username, password);
			else
				destinationOperations = new SQLDbOperations(destinationServer, destinationDb);
			List<Constraint> mConstraints = destinationOperations.FindConstraintsBy(table);
            destinationOperations.Close();

			foreach (Constraint mConstraint in mConstraints)
				if (mConstraint.Type == ConstraintType.Referential)
					if (table != mConstraint.ReferenceTable)
						Migrate(mConstraint.ReferenceTable, destinationServer, destinationDb, username, password);

			CopyTable(mServerName, mDbName, mUsername, mPassword, table, destinationServer, destinationDb, username, password, table);
			migratedTables.Add(table);
		}

		public void CopyTable(string sourceServer, string sourceDb, string sourceUsername, string sourcePassword, string sourceTableName, string DestinationServer, string DestinationDb, string destinationUsername, string destinationPassword, string destinationTableName)
		{
			SQLDB sourceSQLDB = new SQLDB(sourceDb, sourceServer, sourceUsername, sourcePassword);
			SQLDB destinationSQLDB = new SQLDB(DestinationDb, DestinationServer, destinationUsername, destinationPassword);
			sourceSQLDB.ConnectionTimeout = 0;
			destinationSQLDB.ConnectionTimeout = 0;

			OnProgress("دریافت تعداد داده های جدول [" + sourceTableName + "]", 1, 4);
			int sourceCount = sourceSQLDB.GetCount(sourceTableName);
			OnProgress("دریافت داده های جدول [" + sourceTableName + "]", 2, 4);
			SqlDataReader sourceReader = sourceSQLDB.ExcuteReader("SELECT * FROM [" + sourceTableName + "]");
			OnProgress("دریافت داده های جدول [" + sourceTableName + "]", 3, 4);
			DataTable destinationTable = destinationSQLDB.GetAllRows("SELECT * FROM [" + destinationTableName + "]");
			OnProgress("دریافت داده های جدول [" + sourceTableName + "]", 4, 4);

			if (FindIdentityConstraint(destinationTableName) != null)
			{
			    try
			    {
			        destinationSQLDB.ExecuteCommand(string.Format("SET IDENTITY_INSERT [{0}] ON", destinationTableName));
			    }
			    catch (Exception e)
			    {
			        Console.WriteLine(e);
			    }
			}

			int rowNumber = 0;
			while (sourceReader.Read())
			{
				rowNumber++;
				int index = 0;
				string columnsText = "";
				string paramsText = "";
				string paramName;

				destinationSQLDB.Command.Parameters.Clear();
				DataTable sourceSchemaTable = sourceReader.GetSchemaTable();
				OnProgress("انتقال داده های جدول [" + sourceTableName + "]", rowNumber, sourceCount);

				foreach (DataRow row in sourceSchemaTable.Rows)
				{
					string columnName = row["ColumnName"] + "";
					int columnSize = (int) row["ColumnSize"];

					try
					{

						DataColumn destinationColumn = null;
						foreach (DataColumn dcolumn in destinationTable.Columns)
							if (dcolumn.ColumnName == columnName || dcolumn.ColumnName.ToLower() == columnName.ToLower())
							{
								destinationColumn = dcolumn;
								break;
							}

						if (destinationColumn == null)
							continue;

						index = destinationSQLDB.Command.Parameters.Count;

                        if (index > 0)
                        {
                            columnsText += " , ";
                            paramsText += " , ";
                        }
						columnsText += destinationColumn.ColumnName.Replace("Key", "[Key]");
						paramName = "@P" + index;
						paramsText += paramName;

                        //if (index != sourceSchemaTable.Rows.Count - 1)
                        //{
                        //    columnsText += " , ";
                        //    paramsText += " , ";
                        //}


						if (columnName == "Picture")
						{

						}

						if (columnName == null)
						{

						}
						
						object sourceValue = sourceReader[columnName];
						object destinationValue = null;

						if (sourceValue == null)
						{

						}


						SqlParameter mParameter = destinationSQLDB.Command.Parameters.Add(paramName, GetSqlDbType(destinationColumn.DataType));
						if (mParameter == null)
						{
						}
						if (sourceValue == DBNull.Value)
							destinationValue = sourceValue;
						else
						{
							if (destinationColumn.DataType == typeof(string) && sourceValue.ToString().Length > destinationColumn.MaxLength)
								destinationValue = sourceValue.ToString().Substring(0, destinationColumn.MaxLength);
							else
								destinationValue = Convert.ChangeType(sourceValue, destinationColumn.DataType);
						}

						if (destinationValue == null)
						{

						}

						mParameter.Value = destinationValue;
					}
					catch (Exception e)
					{
						throw e;
					}
				}

				List<string> columns = new List<string>(columnsText.Split(',', ' '));
				foreach (DataColumn column in destinationTable.Columns)
				{
					if(columns.Contains(column.ColumnName))
						continue;
					if(column.AllowDBNull)
						continue;
					
					index = destinationSQLDB.Command.Parameters.Count;
					columnsText += " , " + column.ColumnName + " ";
					paramName = "@P" + index;
					paramsText += " , " + paramName;
					//if (index != destinationTable.Columns.Count - 1)
					//{
					//    columnsText += " , ";
					//    paramsText += " , ";
					//}

					SqlParameter mParameter = destinationSQLDB.Command.Parameters.Add(paramName, GetSqlDbType(column.DataType));
					if (column.DataType == typeof(string))
						mParameter.Value = "";
					else
						mParameter.Value = Activator.CreateInstance(column.DataType);
				}
				try
				{
					destinationSQLDB.ExecuteCommand("INSERT INTO [" + destinationTableName + "](" + columnsText + ") VALUES(" + paramsText + ");");
				}
				catch (Exception e)
				{
					throw e;
				}
			}

			if (FindIdentityConstraint(destinationTableName) != null)
			{
			    try
			    {
			        destinationSQLDB.ExecuteCommand(string.Format("SET IDENTITY_INSERT [{0}] OFF", destinationTableName));
			    }
			    catch (Exception e)
			    {
			        Console.WriteLine(e);
			    }
			}

			sourceSQLDB.Close();
			destinationSQLDB.Close();
			GC.Collect();
		}

		public static SqlDbType GetSqlDbType(Type type)
		{
			if (type == typeof(Boolean))
				return SqlDbType.Bit;
			if (type == typeof(Int16))
				return SqlDbType.SmallInt;
			if (type == typeof(Int32))
				return SqlDbType.Int;
			if (type == typeof(Int64))
				return SqlDbType.BigInt;
			if (type == typeof(Double))
				return SqlDbType.Float;
			if (type == typeof(Decimal))
				return SqlDbType.Decimal;
			if (type == typeof(String))
				return SqlDbType.NVarChar;
			if (type == typeof(DateTime))
				return SqlDbType.DateTime;
			if (type == typeof(Byte[]))
				return SqlDbType.Image;
			return SqlDbType.NVarChar;
		}

		public void ExecuteCommand(string query)
		{
			sqlDb.ExecuteCommand(query);
		}

		public void Close()
		{
			sqlDb.Close();
		}

		public string BackupDatabase()
		{
			string tmpFile = Path.GetTempFileName();
			string sql = "BACKUP DATABASE [" + mDbName + "] TO  DISK = N'" + tmpFile +
						 "' WITH  NOINIT ,  NOUNLOAD ,  NOSKIP ,  STATS = 10,  NOFORMAT ";
			ExecuteCommand(sql);
			return tmpFile;
		}

		public string BackupDatabase(string filename)
		{
			string sql = "BACKUP DATABASE [" + mDbName + "] TO  DISK = N'" + filename +
						 "' WITH  NOINIT ,  NOUNLOAD ,  NOSKIP ,  STATS = 10,  NOFORMAT ";
			ExecuteCommand(sql);
			return filename;
		}

		public void RestoreDatabase(string filename)
		{
			if(string.IsNullOrEmpty(mUsername))
				throw new Exception("Username must be setted for this Method");

			string folderPath = GetDataFolderPath();
			string sql = string.Format("RESTORE DATABASE [{0}] FROM DISK = N'{1}' WITH FILE = 1, MOVE N'TrainingSchool' TO N'{2}\\{0}.mdf',  MOVE N'TrainingSchool_log' TO N'{2}\\{0}_log.LDF',  NOUNLOAD,  REPLACE,  STATS = 10 ", mDbName, filename, folderPath);

			SQLDB db = new SQLDB("master", mServerName, mUsername, mPassword);
			db.ConnectionTimeout = 0;

			db.ExecuteCommand(string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;", mDbName));
			db.ExecuteCommand(sql);
			db.ExecuteCommand(string.Format("ALTER DATABASE [{0}] SET MULTI_USER;", mDbName));
	
			db.Close();
		}

		public string GetDataFolderPath()
		{
			string dbPath = sqlDb.ExecuteScalar("SELECT TOP 1 [filename] FROM [sysfiles]") + "";
			return Path.GetDirectoryName(dbPath);
		}

		public static void ChangeAuthenticationMode(string serverName, SqlAuthentication sqlAuthentication)
		{
			RegistryKey key = Registry.LocalMachine;
			string keyPath = "Software\\Microsoft";
			string instanceName = GetInstanceName(serverName);
			if (instanceName == mDefaultInstanceName)
				keyPath += "\\MSSQLServer\\MSSQLServer";
			else
				keyPath += string.Format("\\Microsoft SQL Server\\{0}\\MSSQLServer", instanceName);
			RegistryKey key2 = key.OpenSubKey(keyPath, true);
			int value = (int) key2.GetValue("LoginMode", 0);
			if(value == 0)
				return;
			int newValue = (int) sqlAuthentication;
			bool needRestart = false;

			if(value != newValue)
			{
				key2.SetValue("LoginMode", newValue);
				key2.Flush();
				needRestart = true;
			}

			key2.Close();
			key.Close();

			if (needRestart)
				RestartDb(serverName);
		}

		public static void RestartDb(string serverName)
		{
//			string instanceName = GetInstanceName(serverName);
//			ServiceController[] services = ServiceController.GetServices();
//			foreach (ServiceController service in services)
//			{
//				if(service.ServiceName.ToLower().EndsWith(instanceName.ToLower()))
//				{
//					service.Stop();
//					service.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 30));
//					service.Start();
//					service.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 30));
//				}
//			}
		}

		private static string GetInstanceName(string servername)
		{
			string instanceName = mDefaultInstanceName;
			if (servername.Contains("\\"))
				instanceName = servername.Split('\\')[1];
			return instanceName;
		}

		public void Detach()
		{
			SQLDB db = new SQLDB("master", mServerName, mUsername, mPassword);
			db.ConnectionTimeout = 0;

			db.ExecuteCommand(string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;", mDbName));
			db.ExecuteCommand(string.Format("EXEC sp_detach_db N'{0}'", mDbName));
			
			db.Close();
		}

		public void DropDatabase()
		{
			SQLDB db = new SQLDB("master", mServerName, mUsername, mPassword);
			db.ConnectionTimeout = 0;

			db.ExecuteCommand(string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;", mDbName));
			db.ExecuteCommand(string.Format("DROP DATABASE {0}", mDbName));

			db.Close();
		}

		public void CreateUser(string user, string pass)
		{
			SQLDB db = new SQLDB("master", mServerName, mUsername, mPassword);
			db.ConnectionTimeout = 0;
			
			db.ExecuteCommand(string.Format(@"EXEC master.dbo.sp_addlogin @loginame = N'{0}', @passwd = N'{1}', @defdb = N'master'", user, pass));
			db.ExecuteCommand(string.Format("EXEC master.dbo.sp_addsrvrolemember @loginame = N'{0}', @rolename = N'sysadmin'", user));
			db.ExecuteCommand(string.Format("USE {0}", mDbName));
			db.ExecuteCommand(string.Format("EXEC dbo.sp_grantdbaccess @loginame = N'{0}', @name_in_db = N'{0}'", user));
			db.ExecuteCommand(string.Format("EXEC sp_addrolemember N'db_owner', N'{0}'", user));
			
			db.Close();
		}

		public void DeleteUser(string username)
		{
			SQLDB db = new SQLDB("master", mServerName, mUsername, mPassword);
			db.ConnectionTimeout = 0;

			db.ExecuteCommand(string.Format("USE [{0}]", mDbName));
			db.ExecuteCommand(string.Format("DROP SCHEMA [{0}]", username));
			db.ExecuteCommand(string.Format("DROP USER [{0}]", username));
			db.ExecuteCommand(string.Format("USE [{0}]", "master"));
			DataTable table = db.GetAllRows(string.Format("select session_id from sys.dm_exec_sessions where login_name = '{0}'", username));
			foreach (DataRow row in table.Rows)
				db.ExecuteCommand(string.Format("KILL {0}", row["session_id"]));
			db.ExecuteCommand(string.Format("DROP LOGIN [{0}]", username));

			db.Close();
		}

		public int GetCount(string tableName)
		{
			return (int) sqlDb.ExecuteScalar(string.Format("SELECT Count(*) FROM [{0}]", tableName));
		}

	}

	public class ProgressEventArgs : EventArgs
	{
		private int mMaxValue;
		private int mValue;
		private string mText;

		public ProgressEventArgs(string text, int value, int maxValue)
		{
			mMaxValue = maxValue;
			mValue = value;
			mText = text;
		}

		public int MaxValue
		{
			get { return mMaxValue; }
			set { mMaxValue = value; }
		}

		public int Value
		{
			get { return mValue; }
			set { mValue = value; }
		}

		public string Text
		{
			get { return mText; }
			set { mText = value; }
		}
	}

	public class Constraint
	{
		public Constraint(ConstraintType type, string name, string table)
		{
			Type = type;
			Name = name;
			Table = table;
		}

		public Constraint(ConstraintType type, string name, string table, string columnName)
		{
			Type = type;
			Name = name;
			Table = table;
			ColumnName = columnName;
		}

		public Constraint(ConstraintType type, string name, string table, string columnName, string referenceTable)
		{
			Type = type;
			Name = name;
			Table = table;
			ColumnName = columnName;
			ReferenceTable = referenceTable;
		}

		public ConstraintType Type { get; set; }

		public string Name { get; set; }

		public string Table { get; set; }

		public string ColumnName { get; set; }

		public string ReferenceTable { get; set; }

		public static Constraint FromDataRow(DataRow row)
		{
			Constraint result = null;
			if (row["CONSTRAINT_TYPE"] + "" == "PRIMARY KEY")
				result = new Constraint(ConstraintType.PrimaryKey, row["CONSTRAINT_NAME"] + "", row["TABLE_NAME"] + "");
			else if (row["CONSTRAINT_TYPE"] + "" == "FOREIGN KEY")
				result = new Constraint(ConstraintType.Referential, row["CONSTRAINT_NAME"] + "", row["TABLE_NAME"] + "");
			else if (row["CONSTRAINT_TYPE"] + "" == "UNIQUE")
				result = new Constraint(ConstraintType.Unique, row["CONSTRAINT_NAME"] + "", row["TABLE_NAME"] + "");
			else if (row["CONSTRAINT_TYPE"] + "" == "CHECK")
				result = new Constraint(ConstraintType.Check, row["CONSTRAINT_NAME"] + "", row["TABLE_NAME"] + "");

			if (row.Table.Columns["COLUMN_NAME"] != null)
				result.ColumnName = row["COLUMN_NAME"] + "";

			if (row.Table.Columns["REFERENCE_TABLE_NAME"] != null)
				result.ReferenceTable = row["REFERENCE_TABLE_NAME"] + "";

			return result;
		}

		public override string ToString()
		{
			return "(" + Name + ") " + Table + "." + ColumnName + " -> " + ReferenceTable;
		}
	}

	public enum ConstraintType
	{
		PrimaryKey,
		Referential,
		Unique,
		Check
	}

	public enum IdType
	{
		Int32,
		Guid,
	}

	public enum SqlAuthentication
	{
		Windows = 1,
		Mixed = 2
	}

}