using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.EnterpriseServices.Internal;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MyOwnSite_0._01.BusinessLogic;
using MyOwnSite_0._01.ExcelExport;
using MyOwnSite_0._01.Models;
using OfficeOpenXml;

namespace MyOwnSite_0._01.Controllers
{
    public class AdminController : Controller
    {
        private User user = new User();

        [Dependency]
        public IExportService ExportService { get; set; }
        
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            
            var result = ExportService.Export(Request.QueryString);

            ExcelExportService service = new ExcelExportService();
            service.Export(result, Response);
            
                return View();
            }
        
        }
    }
}