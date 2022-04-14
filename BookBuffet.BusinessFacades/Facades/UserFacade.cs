using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.BusinessFacades
{
    class UserFacade : FacadeBase , IUserFacade
    {
        private readonly IUserBDC userBDC;
        public UserFacade()
            : base(BusinessFacadeType.UserFacade)
        {
            userBDC = (IUserBDC)BusinessLayerFactory.Instance.Create(BusinessLayerType.UserBDC);
        }

        public void AddUser(RegistrationDTO model)
        {
            userBDC.AddUser(model);
        }

        public bool CheckEmailExists(string email)
        {
            return userBDC.CheckEmailExists(email);
        }

        public bool IsValid(LoginDTO user)
        {
            return userBDC.IsValid(user);
        }

        public UserDTO GetCurrent(LoginDTO user)
        {
            return userBDC.GetCurrent(user);
        }

        public int GetId(RegistrationDTO model)
        {
            return userBDC.GetId(model);
        }

    }

}
