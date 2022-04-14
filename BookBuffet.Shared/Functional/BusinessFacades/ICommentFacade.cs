using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.Shared
{
    public interface ICommentFacade : IBusinessFacade
    {
        void AddComment(CommentDTO comments, string userid, int eventid);
        List<CommentDTO> GetEventComment(int eventid);
        string GetUserName(int userId);
    }
}
