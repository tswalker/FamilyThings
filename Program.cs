using FamilyThings.Factory;
using FamilyThings.Repository;


namespace FamilyThings
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = RepositoryFactory.GetRepository(typeof(sqlRepo)) as sqlRepo;
            repo.CheckParents();
        }
    }
}
