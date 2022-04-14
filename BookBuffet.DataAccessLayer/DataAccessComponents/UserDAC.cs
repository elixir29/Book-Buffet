using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.DataAccessLayer
{
    public class UserDAC : DACBase , IUserDAC
    {
        public UserDAC()
            : base(DataAccessType.UserDAC)
        {

        }
        public void AddUser(RegistrationDTO model)
        {
            User user = new User()
            {
                UserName = model.UserName,
                UserPassword = model.UserPassword,
                UserEmailId = model.UserEmailId
            };
            using (var context = new BookBuffetEntities())
            {
                context.User.Add(user);
                context.SaveChanges();
            }
        }

        //check if email exists or not
        public bool CheckEmailExists(string email)
        {
            using (var context = new BookBuffetEntities())
            {
                var result = (from User in context.User
                              where User.UserEmailId == email
                              select User).Count();
                if (result > 0)
                {
                    return false;
                }
                return true;
            }

        }

        //check for verified users
        public bool IsValid(LoginDTO model)
        {
            using (var context = new BookBuffetEntities())
            {
                bool result = context.User.Any(x => x.UserPassword == model.UserPassword &&
                                           x.UserEmailId == model.UserEmailId);
                return result;
            }
        }

        //return current user
        public UserDTO GetCurrent(LoginDTO model)
        {
            BookBuffetEntities databaseContext = new BookBuffetEntities();
            User user= databaseContext.User.Single(x => x.UserEmailId == model.UserEmailId);
            return new UserDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
                UserEmailId = user.UserEmailId,
                UserPassword = user.UserPassword
            };
        }

        //get current user id
        public int GetId(RegistrationDTO model)
        {
            var context = new BookBuffetEntities();
            return context.User.Max(x => x.UserId);
        }

    }

}
