using System;
using System.Collections.Generic;
using System.Linq;
using FamilyLibrary;

namespace FamilyThings
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities util = new Utilities();
            List<ModelThing> things = new List<ModelThing>();
            List<ModelThing> data = util.GetAllThingsById(things,1);


        }
    }
}
