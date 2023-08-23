using ProjectConfig.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConfig
{
    public class DataBaseManager : IDisposable
    {

        /// <summary>
        /// The SQL connection.
        /// </summary>
        public SqlConnection sqlConnection
        {
            get;
            set;
        }

        /// <summary>
        /// The SQL Command
        /// </summary>
        public SqlCommand sqlCommand
        {
            get;
            set;
        }

        /// <summary>
        /// The SQL Data Adapter.
        /// </summary>
        public SqlDataAdapter sqlDataAdapter
        {
            get;
            set;
        }

        /// <summary>
        /// Boolean variable for disposed.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Constructor for DatabaseConnection class.
        /// </summary>
        public DataBaseManager()
        {
            this.sqlCommand = new SqlCommand();
            this.sqlDataAdapter = new SqlDataAdapter();

            this.sqlConnection = GetConnection();
        }

        /// <summary>
        /// Method to get the database connection.
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection()
        {
            this.sqlConnection = new SqlConnection();

            //this.sqlConnection.ConnectionString = KeyValut.DBConnectionString;
            this.sqlConnection.ConnectionString = Configurations.DBConnectionString;
            if (this.sqlConnection.State == ConnectionState.Closed)
            {
                this.sqlConnection.Open();
            }


            return this.sqlConnection;
        }

        /// <summary>
        /// Method to dispose off the objects.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    if (!ReferenceEquals(sqlCommand, null))
                    {
                        sqlCommand.Dispose();
                    }

                    if (!ReferenceEquals(sqlConnection, null))
                    {
                        sqlConnection.Dispose();
                    }

                    if (!ReferenceEquals(sqlDataAdapter, null))
                    {
                        sqlDataAdapter.Dispose();
                    }
                }

                // Note disposing has been done.
                disposed = true;
            }
        }

    }
}
