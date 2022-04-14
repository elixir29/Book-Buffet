
using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.BusinessLogicLayer
{
    public class RoleBDC :  BusinessLayerBase, IRoleBDC
    {
        private readonly IDataAccessFactory dacFactory;
        public RoleBDC()
            : base(BusinessLayerType.RoleBDC)
        {
            dacFactory = DataAccessFactory.Instance;
        }

        public RoleBDC(IDataAccessFactory dacFactory)
            : base(BusinessLayerType.RoleBDC)
        {
            this.dacFactory = dacFactory;
        }

        

        public void AddRole(int userId)
        {
            IRoleDAC roleDAC = (IRoleDAC)dacFactory.Create(DataAccessType.RoleDAC);
            roleDAC.AddRole(userId);
        }

        public bool GetRole(int userId)
        {
            IRoleDAC roleDAC = (IRoleDAC)dacFactory.Create(DataAccessType.RoleDAC);
            return roleDAC.GetRole(userId);
        }
    }

}
