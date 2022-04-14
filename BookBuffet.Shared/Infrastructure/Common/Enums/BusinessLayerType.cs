using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.Shared
{
    public enum BusinessLayerType
    {
        [QualifiedTypeName("BookBuffet.BusinessLogicLayer.dll", "BookBuffet.BusinessLogicLayer.CommentBDC")]
        CommentBDC,
        [QualifiedTypeName("BookBuffet.BusinessLogicLayer.dll", "BookBuffet.BusinessLogicLayer.EventBDC")]
        EventBDC,
        [QualifiedTypeName("BookBuffet.BusinessLogicLayer.dll", "BookBuffet.BusinessLogicLayer.RoleBDC")]
        RoleBDC,
        [QualifiedTypeName("BookBuffet.BusinessLogicLayer.dll", "BookBuffet.BusinessLogicLayer.UserBDC")]
        UserBDC
    }
}
