using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DbOperations
    {
        private IDbConnection mConnection;
        private IDbCommand mCommand;
        private IDbTransaction mTransaction;

        public DbOperations(string connectionString)
        {
            mConnection = new SqlConnection(connectionString);
            mConnection.Open();
            mCommand = mConnection.CreateCommand();
        }

        public int Execute(string sql)
        {
            return Execute(sql, false);
        }

        public int Execute(string sql, bool useTransaction, params object[] parameters)
        {
            try
            {
                if (useTransaction)
                {
                    mTransaction = mCommand.Connection.BeginTransaction();
                    mCommand.Transaction = mTransaction;
                }
                mCommand.CommandText = sql;
                for (int i = 0; i < parameters.Length; i++)
                {
                    object parameter = parameters[i];
                    SqlParameter p = new SqlParameter("@P" + i, parameter);
                    mCommand.Parameters.Add(p);
                }
                return mCommand.ExecuteNonQuery();
            }
            catch
            {
                if (useTransaction)
                    mTransaction.Rollback();
                throw;
            }
            finally
            {
                if (useTransaction)
                    mTransaction.Commit();                
            }
        }
        public object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, false);
        }
        public object ExecuteScalar(string sql, bool useTransaction)
        {
            try
            {
                if (useTransaction)
                {
                    mTransaction = mCommand.Connection.BeginTransaction();
                    mCommand.Transaction = mTransaction;
                }
                mCommand.CommandText = sql;
                return mCommand.ExecuteScalar();
            }
            catch
            {
                if (useTransaction)
                    mTransaction.Rollback();
                throw;
            }
            finally
            {
                if (useTransaction)
                    mTransaction.Commit();                
            }
        }

        public void Close()
        {
            mConnection.Close();
        }
    }
}