using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBuffet.Shared;

namespace BookBuffet.Shared
{
    public interface IUserBDC : IBusinessLogic
    {
        void AddUser(RegistrationDTO user);
        bool CheckEmailExists(string email);
        bool IsValid(LoginDTO user);
        UserDTO GetCurrent(LoginDTO user);
        int GetId(RegistrationDTO model);
    }
}
