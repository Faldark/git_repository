using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using MyOwnSite_0._01.Models;
using ModelStateDictionary = System.Web.Mvc.ModelStateDictionary;

namespace MyOwnSite_0._01.Interfaces
{
    public interface IValidator
    {
        void Validate(UserForm model);

         ModelStateDictionary Dictionary { get; set; }
    }
}
