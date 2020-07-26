using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace FamilyThings.Interfaces
{
    public interface IDataContext : IDisposable
    {
        DataContext Context { get; }
    }
}
