﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
        //
        // GET: /User/
        [Dependency]
        public ILogic logic { get; set; }

        [Dependency]
        public IUserService UserService { get; set; }

        [Dependency]
        public IValidator Validator { get; set; }


        //public UserContext _context;

        //public UserController(IUserContext context)
        //{
        //    _context = context as UserContext;
        //}

        [Dependency]
        public IUserContext Userctx { get; set; }


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
                FormsAuthentication.SetAuthCookie(model.Name,false);
                return RedirectToAction("Welcome", "User");
            }
            return RedirectToAction("");

            //var result = UserService.FindUserByLogin(model.Name);
            //string name = result.Name + "this is returned NAME";

            //return name;
        }
        //[Authorize]
        public string Welcome()
        {
            

            //var _context = Userctx as UserContext;
            
            //var name = (from d in _context.Users where d.Name == "Cindy" select d).Single();

            //var result = name.Password;



            
           

            return logic.ShowMessage();

        }



        public string LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return "Logout Is Completed";
        }



    }
}