using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using MyOwnSite_0._01.BusinessLogic;

namespace MyOwnSite_0._01
{
    

    public class MvcApplication : System.Web.HttpApplication
    {
       


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();


            //Database.SetInitializer(new DropCreateDatabaseAlways<UserContext>());



            Database.SetInitializer<UserContext>(new DropCreateDatabaseIfModelChanges<UserContext>());

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            

            
        }
        
        

    }
}
