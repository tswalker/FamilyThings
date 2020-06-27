using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyThings.Database
{
    class SampleDb
    {
        SqlConnectionStringBuilder _connectionString;
        SqlConnection _connection;

        public SampleDb()
        {
            _connectionString = new SqlConnectionStringBuilder()
            {
                InitialCatalog = "SampleDb",
                DataSource = "localhost",
                ConnectTimeout = 0,
                IntegratedSecurity = true
            };
            _connection = new SqlConnection(_connectionString.ConnectionString);
        }

        public SqlConnection GetSqlConn()
        {
            return _connection;
        }

        public void Open()
        {
            _connection.Open();
        }

        public void Close()
        {
            _connection.Close();
        }
    }
}
