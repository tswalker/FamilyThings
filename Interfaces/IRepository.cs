using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyThings.Interfaces
{
    public interface IRepository
    {
        IDbConnector Connector { get; }
    }
}
