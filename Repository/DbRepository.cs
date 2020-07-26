using FamilyThings.Interfaces;
using System.Data.Linq;

namespace FamilyThings.Repository
{
    public abstract class DbRepository : IRepository
    {
        public IDbConnector Connector { get; private set; }
        public IDataContext DbContext { get; private set; }
        public DataContext Context { get; private set; }

        public DbRepository(IDataContext context, IDbConnector connector)
        {
            DbContext = context;
            Connector = connector;
            Context = DbContext.Context;
        }
    }
}
