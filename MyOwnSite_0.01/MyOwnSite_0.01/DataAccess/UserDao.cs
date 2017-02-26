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
            
            return DbContext.Users.FirstOrDefault(n => n.Name == login);
        }

        public User FindUserById(int id)
        {
            return DbContext.Users.FirstOrDefault(n => n.UserId == id);
        }

        public User FindUserByEmail(string email)
        {

            return DbContext.Users.FirstOrDefault(n => n.Email == email);
        }

        public void Insert(UserForm userform)
        {
            var user = new User() {Name = userform.Name, Email = userform.Email, Password = userform.Password};
            DbContext.Users.Add(user);
            DbContext.SaveChanges();
        }
    }
}