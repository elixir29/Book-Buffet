using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookBuffet.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly IUserFacade userBFL;
        private readonly IRoleFacade roleBFL;
        public RegisterController()
        {
            userBFL = (IUserFacade)BusinessFacadeFactory.Instance.Create(BusinessFacadeType.UserFacade);
            roleBFL = (IRoleFacade)BusinessFacadeFactory.Instance.Create(BusinessFacadeType.RoleFacade);
        }
        

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationDTO user)
        {
            var isEmailExist = userBFL.CheckEmailExists(user.UserEmailId);
            if (!isEmailExist)
            {
                ModelState.AddModelError("", errorMessage: "Email Already used!! Try Unique One");
            }
            else
            {
                if (ModelState.IsValid)
                {

                    userBFL.AddUser(user);
                    int id = userBFL.GetId(user);
                    roleBFL.AddRole(id);

                    return RedirectToAction("Login", "User");

                }
            }
            return View();
        }
    }
}