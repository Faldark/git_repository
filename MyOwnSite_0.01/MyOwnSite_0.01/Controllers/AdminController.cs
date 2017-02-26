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
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            var result = ExportService.Export(Request.QueryString);
            
            List<Comment> comments = result as List<Comment>;
            if (comments != null)
            {
                workSheet.Cells[1, 1].LoadFromCollection(comments, true);
            }
            List<Post> posts = result as List<Post>;
            if (posts != null)
            {
                workSheet.Cells[1, 1].LoadFromCollection(posts, true);
            }

            
            //ExcelPackage excel = new ExcelPackage();
            //var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            //workSheet.Cells[1, 1].LoadFromCollection(result, true);
            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=Contact.xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
                

            }

            //user = FillUserFromParams(Request.QueryString);

               

                return View();
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