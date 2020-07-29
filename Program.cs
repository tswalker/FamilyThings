using FamilyThings.Factory;
using FamilyThings.Repository;


namespace FamilyThings
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = RepositoryFactory.GetRepository(typeof(sqlRepo)) as sqlRepo;
            //repo.CheckParents();
            var record = repo.GetParent(1);
            record.Name = "Johnny";
            
            //SET BREAKPOINT, run update record portion of simpleScript.SQL to modify the record directly
            //                to trigger the exception and conflict resolution.
            repo.UpdateParent(record);
        }
    }
}
