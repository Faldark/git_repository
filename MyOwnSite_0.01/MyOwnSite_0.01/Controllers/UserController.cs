using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Practices.Unity;
using MyOwnSite_0._01.BusinessLogic;
using MyOwnSite_0._01.Interfaces;
using MyOwnSite_0._01.Models;
using MyOwnSite_0._01.Validators;

namespace MyOwnSite_0._01.Controllers
{
    public class UserController : Controller
    {
        
        [Dependency]
        public IUserService UserService { get; set; }

        [Dependency]
        public IValidator Validator { get; set; }
        
        
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(UserForm model)
        {
            Validator.Dictionary = ModelState;

            Validator.Validate(model);

            if (ModelState.IsValid)
            {
                UserService.Insert(model);
                
                return RedirectToAction("Login", "User");
            }
            
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            bool result = UserService.OnLoginValidate(model);

            if (result)
            {


                FormsAuthentication.SetAuthCookie(model.Name, false);

                return RedirectToRoute(new {controller = "User", action = "Welcome"});

                //return RedirectToAction("Welcome", "User", model);

            }
            return View();
            
        }

        [Authorize]
        public ActionResult Welcome()
        {
            ViewBag.User = System.Web.HttpContext.Current.User.Identity.Name;

            return View();

        }

        
        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        
    }
}