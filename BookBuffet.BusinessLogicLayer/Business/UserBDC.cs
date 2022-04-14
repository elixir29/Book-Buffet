
using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.BusinessLogicLayer
{
    class UserBDC :BusinessLayerBase, IUserBDC
    {
        private readonly IDataAccessFactory dacFactory;
        public UserBDC()
            : base(BusinessLayerType.UserBDC)
        {
            dacFactory = DataAccessFactory.Instance;
        }

        public UserBDC(IDataAccessFactory dacFactory)
            : base(BusinessLayerType.UserBDC)
        {
            this.dacFactory = dacFactory;
        }

        public void AddUser(RegistrationDTO model)
        {
            IUserDAC userDAC = userDAC = (IUserDAC)DataAccessFactory.Instance.Create(DataAccessType.UserDAC);
            userDAC.AddUser(model);
        }

        public bool CheckEmailExists(string email)
        {
            IUserDAC userDAC = userDAC = (IUserDAC)DataAccessFactory.Instance.Create(DataAccessType.UserDAC);
            return userDAC.CheckEmailExists(email);
        }

        public bool IsValid(LoginDTO user)
        {
            IUserDAC userDAC = userDAC = (IUserDAC)DataAccessFactory.Instance.Create(DataAccessType.UserDAC);
            return userDAC.IsValid(user);
        }

        public UserDTO GetCurrent(LoginDTO user)
        {
            IUserDAC userDAC = userDAC = (IUserDAC)DataAccessFactory.Instance.Create(DataAccessType.UserDAC);
            return userDAC.GetCurrent(user);
        }

        public int GetId(RegistrationDTO model)
        {
            IUserDAC userDAC = userDAC = (IUserDAC)DataAccessFactory.Instance.Create(DataAccessType.UserDAC);
            return userDAC.GetId(model);
        }

    }

}
