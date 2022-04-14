using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.Shared
{
    public interface IUserDAC : IDataAccess
    {
        void AddUser(RegistrationDTO model);
        bool CheckEmailExists(string email);
        bool IsValid(LoginDTO model);
        UserDTO GetCurrent(LoginDTO model);
        int GetId(RegistrationDTO model);
    }
}
