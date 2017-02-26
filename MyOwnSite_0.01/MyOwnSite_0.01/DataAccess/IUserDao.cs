using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MyOwnSite_0._01.Models;

namespace MyOwnSite_0._01.DataAccess
{
    public interface IUserDao
    {
        User FindUserByLogin(string login);

        User FindUserById(int id);

        User FindUserByEmail(string email);

        void Insert(UserForm userForm);
    }
}
