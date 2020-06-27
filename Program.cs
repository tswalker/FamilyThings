using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyThings.DbContext;
using FamilyThings.Database;

namespace FamilyThings
{
    class Program
    {
        static void Main(string[] args)
        {
            DbConnector db = new DbConnector();
            SampleDb context = new SampleDb(db.GetSqlConn());
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
                foreach (var child in parent.ParentChildLinkage)
                {
                    if (child.ChildContainer.ColorType.Id.Equals(ColorTypeEnum.Red.Id))
                    {
                        Console.WriteLine(child.ChildContainer.Name + " likes the color red");
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Find all colors greater than or equal to Yellow...");
            var colors = context.GetTable<ColorType>();
            foreach(var color in colors)
            {
                if (color.Id >= ColorTypeEnum.Yellow.Id) { Console.WriteLine(color.Name); }
            }

            Console.WriteLine();
            Console.WriteLine("Find all children that like the color Blue...");
            var children = context.GetTable<ChildContainer>();
            foreach(var child in children)
            {
                if (ColorTypeEnum.Blue.Symbol.Equals(child.ColorType.Symbol))
                {
                    Console.WriteLine(child.Name + " likes the color " + ColorTypeEnum.Blue.Name);
                }
            }


            Console.WriteLine("Press any key to close...");
            Console.ReadLine();
        }
    }
}
