using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.DataAccessLayer
{
    public class RoleDAC : DACBase ,IRoleDAC
    {
        public RoleDAC()
            : base(DataAccessType.RoleDAC)
        {

        }
        public void AddRole(int userId)
        {
            Role role = new Role()
            {
                UserId = userId,
                RoleName = "User"
            };
            using (var context = new BookBuffetEntities())
            {
                context.Role.Add(role);
                context.SaveChanges();
            }
        }

        public bool GetRole(int userId)
        {
            using (var context = new BookBuffetEntities())
            {
                var result = (from Role in context.Role
                              where Role.UserId == userId
                              select Role.RoleName).ToString();

                if (result == "Admin")
                {
                    return true;
                }
                return false;
            }
        }

        public string[] GetRolesForUser(string id)
        {
            int userId = int.Parse(id);
            using (var context = new BookBuffetEntities())
            {
                var result = (from user in context.User
                              join role in context.Role on user.UserId equals role.UserId
                              where user.UserId == userId
                              select role.RoleName).ToArray();
                return result;
            }
        }

    }

}
