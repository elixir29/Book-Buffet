using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookBuffet.Shared
{
    public interface IRoleFacade : IBusinessFacade
    {
        void AddRole(int userId);
        bool GetRole(int userId);
    }
}
