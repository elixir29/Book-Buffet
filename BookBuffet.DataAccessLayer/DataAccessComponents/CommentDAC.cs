
using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.DataAccessLayer
{
    public class CommentDAC : DACBase, ICommentDAC
    {
        public CommentDAC()
            : base(DataAccessType.CommentDAC)
        {

        }
        public void AddComment(CommentDTO comments, string userid, int eventid)
        {
            int uid = int.Parse(userid);
            Comment comment = new Comment
            {
                CommentText = comments.CommentText,
                EventId = eventid,
                UserId = uid,
                CommentDate = DateTime.Now
            };
            using (var context = new BookBuffetEntities())
            {
                context.Comment.Add(comment);
                context.SaveChanges();
            }
        }

        public List<CommentDTO> GetEventComment(int eventid)
        {
            List<CommentDTO> model = new List<CommentDTO>();
            List<Comment> dbcomment = null;
            using (var context = new BookBuffetEntities())
            {
                dbcomment = context.Comment.
                             Where(x => x.EventId == eventid).
                             OrderBy(x => x.CommentDate).ToList();
            };

            foreach (var item in dbcomment)
            {
                if (item.EventId == eventid)
                {
                    CommentDTO tempModel = new CommentDTO
                    {
                        CommentDate = item.CommentDate,
                        CommentText = item.CommentText,
                        UserName = GetUserName(item.UserId)
                    };
                    model.Add(tempModel);
                }

            }
            return model;
        }

        public string GetUserName(int userId)
        {
            using (var context = new BookBuffetEntities())
            {
                string result = (from User in context.User
                                 where User.UserId == userId
                                 select User.UserName).FirstOrDefault();
                return result;
            }
        }
    }
}
