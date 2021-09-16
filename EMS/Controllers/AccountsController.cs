using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EMS.Controllers
{
    public class AccountsController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            using (EMSEntities1 context = new EMSEntities1())
            {
                bool IsValidUser = context.EmpUsers.Any(user => user.EmailID.ToLower() ==
                     model.UserEmail.ToLower() && user.Password == model.UserPassword);
                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.UserEmail, false);
                    return RedirectToAction("Index", "Employees");
                }
                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(EmpUser model)
        {
            using (EMSEntities1 context = new EMSEntities1())
            {
                context.EmpUsers.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}