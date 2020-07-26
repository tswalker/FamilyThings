using FamilyThings.Interfaces;
using System.Data.SqlClient;

namespace FamilyThings.Databases
{
    public abstract class DbConnector : IDbConnector
    {
        public SqlConnectionStringBuilder ConnectionString { get; private set; }
        public SqlConnection Connection { get; private set; }

        public DbConnector(string catalog,string server,int timeout, bool security)
        {
            ConnectionString = new SqlConnectionStringBuilder()
            {
                InitialCatalog = catalog,
                DataSource = server,
                ConnectTimeout = timeout,
                IntegratedSecurity = security
            };
            Connection = new SqlConnection(ConnectionString.ConnectionString);
        }

        public void Open()
        {
            Connection.Open();
        }

        public void Close()
        {
            Connection.Close();
        }
    }
}
