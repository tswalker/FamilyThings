using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using FamilyThings.DbContext.Local;
using FamilyThings.Enumerations;
using FamilyThings.Interfaces;


#if DEBUG
using DataModel = FamilyThings.DbContext.Local;
#elif RELEASE
using DataModel = FamilyThings.DbContext.Local;
#endif

namespace FamilyThings.Repository
{
    class sqlRepo : DbRepository
    {
        public sqlRepo(IDataContext context, IDbConnector connector) : base(context, connector) { }

        public void CheckParents()
        {
            var parents = Context.GetTable<DataModel.ParentContainer>();
            var children = Context.GetTable<DataModel.ChildContainer>();
            var colors = Context.GetTable<DataModel.ColorType>();

            // iterate through parents' children via LUT(cross-reference table)
            foreach (var parent in parents)
            {
                Console.Write("Parent: {0} has children: ", parent.Name);
                int counter = 0;
                foreach (var child in parent.ParentChildLinkage)
                {
                    var separator = "";
                    if (counter > 0) { separator = ", "; }
                    Console.Write(separator + child.ChildContainer.Name);
                    counter++;
                }
                Console.WriteLine();
                foreach (var child in parent.ParentChildLinkage)
                {
                    if (child.ChildContainer.ColorTypeId.Equals(ColorTypeEnum.Red.Id))
                    {
                        Console.WriteLine(child.ChildContainer.Name + " likes the color red.");
                    }
                    //The following fails because we are unable implicitly convert from Nullable to bool?
                    //if (child.ChildContainer.ColorType?.Id.Equals(ColorTypeEnum.Red.Id))
                    //{
                    //    Console.WriteLine(child.ChildContainer.Name + " likes the color red");
                    //}
                    //instead use a null check in the evaluation first
                    if (child.ChildContainer.ColorType != null && child.ChildContainer.ColorType.Id.Equals(ColorTypeEnum.Yellow.Id))
                    {
                        Console.WriteLine(child.ChildContainer.Name + " likes the color yellow.");
                    }
                }
            }
            //use enumeration class to do comparison
            Console.WriteLine();
            Console.WriteLine("Find all colors greater than or equal to Yellow:");
            foreach (var color in colors)
            {
                if (color.Id >= ColorTypeEnum.Yellow.Id) { Console.WriteLine(color.Name); }
            }

            //use enumeration class to match a particular field type or by record Id
            //adds use of NULL checks to ensure table record has a value (otherwise it fails)
            Console.WriteLine();
            Console.WriteLine("Find all children that like the color Blue:");
            foreach (var child in children)
            {
                //switching(casting smells funny)
                switch (child.ColorTypeId)
                {
                    case (int)ColorTypeEnum.ColorEnum.Red:
                        {
                            Console.WriteLine(child.Name + " prefers the color " + ColorTypeEnum.Red.Name + ".");
                            break;
                        }
                }

                //more explicit use of table related data instead of casting and switches
                if (colors.Contains(child.ColorType) && child.ColorType.Name.Equals(ColorTypeEnum.Yellow.Name))
                {
                    Console.WriteLine(child.Name + " prefers the color " + ColorTypeEnum.Yellow.Name + ".");
                }
                if (!colors.Contains(child.ColorType))
                {
                    Console.WriteLine();
                    Console.WriteLine(child.Name + " does not have a color... :(");  //you found something that enums can't help with
                }

                //type of string comparison (use NULL check on record)
                if (ColorTypeEnum.Blue.Symbol.Equals(child.ColorType?.Symbol))
                {
                    Console.Write(child.Name + " likes the color " + ColorTypeEnum.Blue.Name + ".");
                }

                //record Id matching (use NULL check on record)
                if (ColorTypeEnum.Blue.Matches(child.ColorType?.Id))
                {
                    Console.WriteLine(" Blue Magic...!");
                }
            }

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }

        public DataModel.ParentContainer GetParent(int id)
        {
            var parents = Context.GetTable<ParentContainer>();
            var record = parents.Where(x => x.Id.Equals(id)).FirstOrDefault();
            return record;
        }

        public void UpdateParent(DataModel.ParentContainer parent)
        {
            try
            {
                var parents = Context.GetTable<ParentContainer>();
                var record = parents.Where(x => x.Id.Equals(parent.Id)).FirstOrDefault();
                record = parent;
                Context.SubmitChanges(ConflictMode.FailOnFirstConflict);
            }
            catch (ChangeConflictException e)
            {
                foreach(ObjectChangeConflict occ in Context.ChangeConflicts)
                {
                    MetaTable metaTable = Context.Mapping.GetTable(occ.Object.GetType());
                    ParentContainer entityInConflict = (ParentContainer)occ.Object;
                    foreach(var conflict in occ.MemberConflicts)
                    {
                        object currentValue = conflict.CurrentValue;
                        object originalValue = conflict.OriginalValue;
                        object databaseValue = conflict.DatabaseValue;
                        MemberInfo mi = conflict.Member;
                        Console.WriteLine("Change conflict detected on Member: {0}, Current: {1}, Original: {2}, Database: {3}",mi.Name,currentValue,originalValue,databaseValue);
                    }
                }
            }
        }
    }
}
