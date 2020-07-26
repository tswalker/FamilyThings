using System.Data.SqlClient;

namespace FamilyThings.Interfaces
{
    public interface IDbConnector
    {
        SqlConnectionStringBuilder ConnectionString { get;}
        SqlConnection Connection { get; }

        void Open();
        void Close();
    }
}