using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using MyOwnSite_0._01.Models;

namespace MyOwnSite_0._01.Interfaces
{
    public interface IUserContext :IDisposable
    {
        DbSet<User> Users { get; set; }

        int SaveChanges();

    }
}
