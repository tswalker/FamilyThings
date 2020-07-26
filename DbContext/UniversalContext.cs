using FamilyThings.Interfaces;
using System.Data;
using System.Data.Linq;

#if DEBUG
using Context = FamilyThings.DbContext.Local.SampleDb;
#elif RELEASE
using Context = FamilyThings.DbContext.Local.SampleDb;
#endif

namespace FamilyThings.DbContext
{
    public class UniversalContext : Context, IDataContext
    {
        DataContext IDataContext.Context => this;

        public UniversalContext(IDbConnection connection) : base(connection) { }
    }
}
