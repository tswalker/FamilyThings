using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContext = FamilyThings.DbContext;
using Database = FamilyThings.Database;
using FamilyThings.DbContext;
using System.Runtime.CompilerServices;

namespace FamilyThings
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SampleDb db = new Database.SampleDb();
            DbContext.SampleDb context = new DbContext.SampleDb(db.GetSqlConn());

            var parents = context.GetTable<ParentContainer>();

            foreach(var parent in parents)
            {
                Console.Write("Parent: {0} has children: ", parent.Name);
                foreach (var child in parent.ParentChildLinkage)
                {
                    var separator = "";
                    if (parent.ParentChildLinkage.Count > 1) { separator = ","; }
                    Console.Write(child.ChildContainer.Name + separator);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to close...");
            Console.ReadLine();
        }
    }
}
