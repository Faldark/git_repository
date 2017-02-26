using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using MyOwnSite_0._01.DataAccess;
using MyOwnSite_0._01.Models;

namespace MyOwnSite_0._01.BusinessLogic
{
    public class UserService : IUserService
    {
        [Dependency]
        public IUserDao UserDao { get; set; }

        public User FindUserByLogin(string login)
        {
            return UserDao.FindUserByLogin(login);
        }

        public User FindUserById(int id)
        {
            return UserDao.FindUserById(id);
        }

        public bool OnLoginValidate(User user)
        {
            var userFromDatabase = UserDao.FindUserByLogin(user.Name);

            if (userFromDatabase != null && userFromDatabase.Password == user.Password)
                return true;
            return false;
        }

        public User FindUserByEmail(string email)
        {
            return UserDao.FindUserByEmail(email);
        }

        public void Insert(UserForm userForm)
        {
            UserDao.Insert(userForm);
        }

    }
}