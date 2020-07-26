using FamilyThings.Databases;
using FamilyThings.DbContext;
using FamilyThings.Interfaces;
using FamilyThings.Repository;
using System;

namespace FamilyThings.Factory
{
    public static class RepositoryFactory
    {
        private static readonly IDbConnector _database;
        private static readonly IDataContext _dataContext;

        static RepositoryFactory()
        {
            _database = new DbSql();
            _dataContext = new UniversalContext(_database.Connection);
        }

        public static IRepository GetRepository(Type repo)
        {
            switch (repo.GetType())
            {
                case var _ when repo.Equals(typeof(sqlRepo)):
                    {
                        return new sqlRepo(_dataContext, _database);
                    }
                default: return null;
            }
        }
    }
}
