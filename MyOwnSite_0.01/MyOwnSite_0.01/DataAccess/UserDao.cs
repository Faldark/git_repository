using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MyOwnSite_0._01.BusinessLogic;
using MyOwnSite_0._01.Interfaces;
using MyOwnSite_0._01.Models;





namespace MyOwnSite_0._01.DataAccess
{
    public class UserDao :IUserDao
    {

        


        [Dependency]
        public IUserContext DbContext { get; set; }

        


        public User FindUserByLogin(string login)
        {
            


            var databaseConnection = DbContext as UserContext;
            var user = databaseConnection.Users.FirstOrDefault(n => n.Name == login);

            return user;
        }
    }
}