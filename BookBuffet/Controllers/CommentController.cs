using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookBuffet.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentFacade commentBFL;
        public CommentController()
        {
            commentBFL = (ICommentFacade)BusinessFacadeFactory.Instance.Create(BusinessFacadeType.CommentFacade);
        }
        

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CommentDTO comment)
        {
            int eventid = int.Parse(Request.Url.Segments.Last());

            string userid = HttpContext.User.Identity.Name;

            commentBFL.AddComment(comment, userid, eventid);

            return RedirectToAction("Details", "Event", new { id = eventid });
        }
        

        public ActionResult Show()
        {

            int eventid = int.Parse(Request.Url.Segments.Last());

            dynamic dynamic = new ExpandoObject();
            dynamic.CommentDTO = commentBFL.GetEventComment(eventid);

            return View(dynamic);
        }
        
    }

}