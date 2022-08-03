using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using DataAccessLayer;

namespace Edge32
{
	public class GSqlConnection
	{
		private SqlConnection connection;

		public GSqlConnection(SqlConnection connection)
		{
			this.connection = connection;
		}

		public ConnectionState State
		{
			get { return connection.State; }
		}

		public void Close()
		{
			connection.Close();
		}
	}

	public class GSqlCommand
	{
		private SqlCommand command;

		public GSqlCommand(SqlCommand command)
		{
			this.command = command;
		}

		public SqlParameterCollection Parameters
		{
			get { return command.Parameters; }
		}

		public string CommandText
		{
			set { command.CommandText = value; }
		}

		public int ExecuteNonQuery()
		{
			return command.ExecuteNonQuery();
		}

		public object ExecuteScalar()
		{
			return command.ExecuteScalar();
		}

		public SqlDataReader ExecuteReader()
		{
			return command.ExecuteReader();
		}
	}

	public class SQLDB
	{
		private SqlConnection m_Connection;
		private SqlCommand m_command;
		private SqlTransaction transaction;
		private int m_CommandTimeout;

		public int ConnectionTimeout
		{
			get
			{
				return m_CommandTimeout;
			}
			set
			{
				m_CommandTimeout = value;
			}
		}
		public SQLDB()
		{
			m_CommandTimeout = 60;
			m_Connection = new SqlConnection(DbContext.GetConnectionString());
			try
			{
				m_Connection.Open();
			}
			catch (Exception ex)
			{
				m_Connection.Close();
				throw new Exception("نرم افزار قادر به برقراری ارتباط با پایگاه داده نیست.\n" + ex.Message);
			}

			m_command = new SqlCommand();
			m_command.Connection = m_Connection;
		}

		public SQLDB(int commandTimeout)
		{
			m_CommandTimeout = commandTimeout;
            m_Connection = new SqlConnection(DbContext.GetConnectionString());
			try
			{
				m_Connection.Open();
			}
			catch (Exception ex)
			{
				m_Connection.Close();
				throw new Exception("نرم افزار قادر به برقراری ارتباط با پایگاه داده نیست.\n" + ex.Message);
			}

			m_command = new SqlCommand();
			m_command.Connection = m_Connection;
		}

		public SQLDB(string database, int connectionTimeout)
		{
			m_CommandTimeout = connectionTimeout;
            string connectionString = DbContext.GetConnectionString() + "Initial Catalog=" + database + ";Server=" + DbContext.GetAppConfig("DataSource") + ";";
//			string connectionString = EdgeHandler.GetBlankConnectionString() + "Initial Catalog=" + database + ";Server=" + EdgeHandler.GetServerName() + ";";
			m_Connection = new SqlConnection(connectionString);
			try
			{
				m_Connection.Open();
			}
			catch (Exception ex)
			{
				m_Connection.Close();
				throw new Exception("نرم افزار قادر به برقراری ارتباط با پایگاه داده نیست.\n" + ex.Message);
			}

			m_command = new SqlCommand();
			m_command.Connection = m_Connection;
		}

		public SQLDB(string database, string serverName, int commandTimeout)
		{
			m_CommandTimeout = commandTimeout;
			m_Connection =
                new SqlConnection(DbContext.GetConnectionString() + "Persist Security Info=False;Initial Catalog=" + database +
				                  ";Data Source=" + serverName + ";");
			try
			{
				m_Connection.Open();
			}
			catch (Exception ex)
			{
				m_Connection.Close();
				throw new Exception("نرم افزار قادر به برقراری ارتباط با پایگاه داده نیست.\n" + ex.Message);
			}

			m_command = new SqlCommand();
			m_command.Connection = m_Connection;
		}

		public SQLDB(string database, string serverName)
		{
			m_CommandTimeout = 60;
			m_Connection =
				new SqlConnection(DbContext.GetConnectionString() + "Persist Security Info=False;Initial Catalog=" + database +
				                  ";Data Source=" + serverName + ";");
			try
			{
				m_Connection.Open();
			}
			catch (Exception ex)
			{
				m_Connection.Close();
				throw new Exception("نرم افزار قادر به برقراری ارتباط با پایگاه داده نیست.\n" + ex.Message);
			}

			m_command = new SqlCommand();
			m_command.Connection = m_Connection;
		}

		public SQLDB(string database, string serverName, string user, string pass) : this(database, serverName, user, pass, 60)
		{
		}
		public SQLDB(string database, string serverName, string user, string pass, int connectionTimeout)
		{
			m_CommandTimeout = connectionTimeout;
			m_Connection =
				new SqlConnection(
                    string.Format("{0};Persist Security Info=False;Initial Catalog={1};Data Source={2};User ID={3};Password={4};Connection Timeout={5};Pooling=True;Max Pool Size=32768",
					              DbContext.GetConnectionString(), database, serverName, user, pass, connectionTimeout));
			try
			{
				m_Connection.Open();
			}
			catch (Exception ex)
			{
				m_Connection.Close();
				throw new Exception("نرم افزار قادر به برقراری ارتباط با پایگاه داده نیست.\n" + ex.Message);
			}

			m_command = new SqlCommand();
			m_command.Connection = m_Connection;
		}

		public GSqlConnection Connection
		{
			get { return new GSqlConnection(m_Connection); }
		}

		public GSqlCommand Command
		{
			get { return new GSqlCommand(m_command); }
		}

		public SqlDataReader ExcuteReader(string sql)
		{
			try
			{
				m_command.CommandText = sql;
				m_command.CommandTimeout = m_CommandTimeout;
				return m_command.ExecuteReader();
			}
			catch (Exception ex)
			{
				throw new Exception("نرم افزار قادر به اجرای فرمان نمی باشد.\n" + ex.Message);
			}
		}

		public void ExecuteCommand(string cmd)
		{
			try
			{
				m_command.CommandText = cmd;
				m_command.CommandTimeout = m_CommandTimeout;
				m_command.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw new Exception("نرم افزار قادر به اجرای فرمان نمی باشد.\n" + ex.Message);
			}
		}

		public object ExecuteScalar(string cmd)
		{
			try
			{
				m_command.CommandText = cmd;
				m_command.CommandTimeout = m_CommandTimeout;
				return m_command.ExecuteScalar();
			}
			catch (Exception ex)
			{
				throw new Exception("نرم افزار قادر به به اجرای فرمان نمی باشد.\n" + ex.Message);
			}
		}

		public void BeginTransaction()
		{
			transaction = m_Connection.BeginTransaction();
			m_command.Transaction = transaction;
		}

		public void Rollback()
		{
			transaction.Rollback();
		}

		public void Commit()
		{
			transaction.Commit();
		}

		public void Save(string tableName, params object[] args)
		{
			string query = "insert into [" + tableName + "](";
			string columns = "";
			string values = " values(";
			for (int i = 0; i < args.Length; i += 2)
			{
				columns += "[" + args[i] + "]" + ",";

				object value = args[i + 1];
				if (value == null)
					values += "null,";
				else if (value is string)
					values += "N'" + value + "',";
				else if (value is bool)
					values += ((bool) value ? "1," : "0,");
				else
					values += value + ",";
			}

			query += columns.TrimEnd(',') + ") " + values.TrimEnd(',') + ")";
			ExecuteCommand(query);
		}

		public void Update(string tableName, string criteria, params object[] args)
		{
			string query = "Update [" + tableName + "] SET ";

			for (int i = 0; i < args.Length; i += 2)
			{
				query += "[" + args[i] + "] = ";

				object value = args[i + 1];
				if (value == null)
					query += "null,";
				else if (value is string)
					query += "N'" + value + "',";
				else if (value is bool)
					query += ((bool) value ? "1," : "0,");
				else
					query += value + ",";
			}

			query = query.TrimEnd(',') + " Where " + criteria;
			ExecuteCommand(query);
		}

		public void Delete(string tableName, string criteria)
		{
			string query = "Delete From [" + tableName + "] Where " + criteria;
			ExecuteCommand(query);
		}

		public DataTable GetAllRows(string tableName, string criteria)
		{
			return GetAllRows("select * from [" + tableName + "]" + (criteria == "" ? "" : " where " + criteria));
		}

		public DataTable GetAllRows(string selectQuery)
		{
			m_command.CommandText = selectQuery; //
			m_command.CommandTimeout = m_CommandTimeout;
			SqlDataReader reader = null;
			try
			{
				reader = m_command.ExecuteReader();
				DataTable table = new DataTable();
				table.Load(reader);
				return table;
			}
			catch(Exception ex)
			{
				throw;
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
					reader.Close();
			}
		}

		public List<object[]> GetAllRows(string tableName, string fields, string criteria)
		{
			m_command.CommandText = "select " + fields + " from [" + tableName + "]" +
			                        (criteria == "" ? "" : " where " + criteria);
			m_command.CommandTimeout = m_CommandTimeout;
			SqlDataReader reader = null;
			try
			{
				reader = m_command.ExecuteReader();
				List<object[]> result = new List<object[]>();
				while (reader.Read())
				{
					object[] o = new object[reader.FieldCount];
					reader.GetValues(o);
					result.Add(o);
				}
				return result;
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
					reader.Close();
			}
		}

		public int GetCount(string tableName)
		{
			return (int) ExecuteScalar(string.Format("SELECT Count(*) FROM [{0}]", tableName));
		}

        public int GetLastId(string tableName)
        {
            object o = ExecuteScalar("select Max(Id) From " + tableName);
            if (o is DBNull)
                return 0;
            return Convert.ToInt32(o);
        }

        public DataRow GetObjectById(string tableName, int id)
        {
            DataTable table = GetAllRows(tableName, "Id = " + id);
            if (table.Rows.Count > 1)
                throw new Exception("تعداد ردیف ها بیشتر از 1 است.");
            if (table.Rows.Count == 1)
                return table.Rows[0];
            throw new Exception(string.Format("No such Object found in Table '{0}' with Id = {1}", tableName, id));
        }


		public void Close()
		{
			m_Connection.Close();
            m_Connection.Dispose();
		}
	}
}