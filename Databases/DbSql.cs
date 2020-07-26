
namespace FamilyThings.Databases
{
    public class DbSql : DbConnector
    {
        private static readonly string database = "SampleDb";
        private static readonly string instance = "localhost";
        private static readonly int timeout = 0;
        private static readonly bool security = true;

        public DbSql() : base(database, instance, timeout, security) { }
    }
}
