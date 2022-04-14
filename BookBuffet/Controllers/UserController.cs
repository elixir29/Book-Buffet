using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookBuffet.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IUserFacade userBFL;


        public UserController()
        {
            userBFL = (IUserFacade)BusinessFacadeFactory.Instance.Create(BusinessFacadeType.UserFacade);
        }
        

        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDTO loginModel)
        {
            bool isValid = userBFL.IsValid(loginModel);

            if (isValid)
            {
                //get current user 
                UserDTO user = userBFL.GetCurrent(loginModel);

                FormsAuthentication.SetAuthCookie(user.UserId.ToString(), true);

                var cookie = new HttpCookie("name", user.UserName);
                Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid username and password");
            return View();
        }
        
        
       
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        
    }
}