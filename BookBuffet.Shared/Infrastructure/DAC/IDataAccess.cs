using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.Shared
{
    public interface IDataAccess
    {
        DataAccessType DACType { get; }
    }
}
