using System.Collections.Generic;
using System.Linq;
using FamilyThings.ViewModels;

namespace FamilyThings
{
    class Utilities
    {
        public List<ModelThing> GetAllThingsById(List<ModelThing> things, int id)
        {
            return things.Where(x => x.Id.Equals(id) && !x.Description.Equals(string.Empty)).ToList();
        }

        public List<ModelThing> GetMoreThingsById(List<ModelThing> things, int id)
        {
            var items = things.Where(x => x.Id.Equals(id));
            var filtered = items.Where(x => !x.Description.Equals(string.Empty));
            return filtered.ToList();
        }
    }
}
