using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.Shared
{
    public interface IUserFacade : IBusinessFacade
    {
        void AddUser(RegistrationDTO user);
        bool CheckEmailExists(string email);
        bool IsValid(LoginDTO user);
        UserDTO GetCurrent(LoginDTO user);
        int GetId(RegistrationDTO model);
    }
}
