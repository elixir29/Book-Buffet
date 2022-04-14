
using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.BusinessLogicLayer
{
    public class CommentBDC : BusinessLayerBase, ICommentBDC
    {

        private readonly IDataAccessFactory dacFactory;
        public CommentBDC()
            : base(BusinessLayerType.CommentBDC)
        {
            dacFactory = DataAccessFactory.Instance;
        }

        public CommentBDC(IDataAccessFactory dacFactory)
            : base(BusinessLayerType.CommentBDC)
        {
            this.dacFactory = dacFactory;
        }

        public void AddComment(CommentDTO comments, string userid, int eventid)
        {
            ICommentDAC commentDAC = commentDAC = (ICommentDAC)DataAccessFactory.Instance.Create(DataAccessType.CommentDAC);
            commentDAC.AddComment(comments,userid,eventid);
        }

        public List<CommentDTO> GetEventComment(int eventid)
        {
            ICommentDAC commentDAC = commentDAC = (ICommentDAC)DataAccessFactory.Instance.Create(DataAccessType.CommentDAC);
            return commentDAC.GetEventComment(eventid);
        }

        public string GetUserName(int userId)
        {
            ICommentDAC commentDAC = commentDAC = (ICommentDAC)DataAccessFactory.Instance.Create(DataAccessType.CommentDAC);
            return commentDAC.GetUserName(userId);
        }
    }

}
