using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookBuffet.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
            public ActionResult Index()
            {
                return View();
            }

            public ActionResult About()
            {
                return View();
            }

            public void Contact()
            {
                Response.Redirect("https://cas.nagarro.com/");
            }
        
    }
}