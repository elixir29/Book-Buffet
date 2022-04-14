using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.Shared
{
    public interface IRoleDAC : IDataAccess
    {
        void AddRole(int userId);
        bool GetRole(int userId);
        string[] GetRolesForUser(string userId);
    }
}
