using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.Shared
{
    public enum BusinessFacadeType
    {
        [QualifiedTypeName("BookBuffet.BusinessFacades.dll", "BookBuffet.BusinessFacades.CommentFacade")]
        CommentFacade,
        [QualifiedTypeName("BookBuffet.BusinessFacades.dll", "BookBuffet.BusinessFacades.EventFacade")]
        EventFacade,
        [QualifiedTypeName("BookBuffet.BusinessFacades.dll", "BookBuffet.BusinessFacades.RoleFacade")]
        RoleFacade,
        [QualifiedTypeName("BookBuffet.BusinessFacades.dll", "BookBuffet.BusinessFacades.UserFacade")]
        UserFacade
    }
}
