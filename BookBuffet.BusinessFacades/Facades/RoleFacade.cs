
using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.BusinessFacades
{
    public class RoleFacade : FacadeBase , IRoleFacade
    {
        public RoleFacade()
            : base(BusinessFacadeType.RoleFacade)
        {

        }

        public void AddRole(int userId)
        {
            IRoleBDC roleBDC = roleBDC = (IRoleBDC)BusinessLayerFactory.Instance.Create(BusinessLayerType.RoleBDC);
            roleBDC.AddRole(userId);
        }

        public bool GetRole(int userId)
        {
            IRoleBDC roleBDC = roleBDC = (IRoleBDC)BusinessLayerFactory.Instance.Create(BusinessLayerType.RoleBDC);
            return roleBDC.GetRole(userId);
        }
    }

}
