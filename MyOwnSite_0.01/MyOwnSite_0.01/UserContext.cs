using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MyOwnSite_0._01.Interfaces;
using MyOwnSite_0._01.Models;

namespace MyOwnSite_0._01
{
    public class UserContext :DbContext, IUserContext
    {
        public DbSet<User> Users { get; set; }

        //public System.Data.Entity.DbSet<MyOwnSite_0._01.Models.UserForm> UserForms { get; set; }

    }
}