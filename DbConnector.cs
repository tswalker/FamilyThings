using System.Data.SqlClient;

namespace FamilyThings.Database
{
    class DbConnector
    {
        SqlConnectionStringBuilder _connectionString;
        SqlConnection _connection;

        public DbConnector()
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
