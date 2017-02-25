using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using MyOwnSite_0._01.Models;

namespace MyOwnSite_0._01.Controllers
{
    public class AdminController : Controller
    {
        private User user = new User();

        //
        // GET: /Admin/
        public ActionResult Index()
        {

            user = FillUserFromParams(Request.QueryString);
            return View(user);
        }

        private User FillUserFromParams(NameValueCollection parameters)
        {
            var userId = parameters["userid"];
            var name = parameters["name"];
            var password = parameters["password"];
            var email = parameters["email"];



            if (userId != null)
            {
                user.UserId = int.Parse(userId);
            }
            else
            {
                user.UserId = 0;
            }
            if (name != null)
            {
                user.Name = name;
            }
            else
            {
                user.Name = "null";
            }
            if (password != null)
            {
                user.Password = password;
            }
            else
            {
                user.Password = "null";
            }
            if (email != null)
            {
                user.Email = email;
            }
            else
            {
                user.Email = "null@null.com";
            }

            return user;
        }
    }
}