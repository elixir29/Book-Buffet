using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.Shared
{
    public enum DataAccessType
    {
        [QualifiedTypeName("BookBuffet.DataAccessLayer.dll", "BookBuffet.DataAccessLayer.UserDAC")]
        UserDAC,
        [QualifiedTypeName("BookBuffet.DataAccessLayer.dll", "BookBuffet.DataAccessLayer.RoleDAC")]
        RoleDAC,
        [QualifiedTypeName("BookBuffet.DataAccessLayer.dll", "BookBuffet.DataAccessLayer.EventDAC")]
        EventDAC,
        [QualifiedTypeName("BookBuffet.DataAccessLayer.dll", "BookBuffet.DataAccessLayer.CommentDAC")]
        CommentDAC
    }
}
