
using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.BusinessFacades
{
    public class CommentFacade : FacadeBase, ICommentFacade
    {
        private readonly ICommentBDC commentBDC;
        public CommentFacade()
            : base(BusinessFacadeType.CommentFacade)
        {
            commentBDC = (ICommentBDC)BusinessLayerFactory.Instance.Create(BusinessLayerType.CommentBDC);
        }

        public void AddComment(CommentDTO comments, string userid, int eventid)
        {
            commentBDC.AddComment(comments,userid,eventid);
        }

        public List<CommentDTO> GetEventComment(int eventid)
        {
            return commentBDC.GetEventComment(eventid);
        }

        public string GetUserName(int userId)
        {
            return commentBDC.GetUserName(userId);
        }
    }

}
