using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Microsoft.Practices.Unity;
using MyOwnSite_0._01.ExcelExport;
using MyOwnSite_0._01.Models;

namespace MyOwnSite_0._01.BusinessLogic
{
    public class ExportService :IExportService
    {

        [Microsoft.Practices.Unity.Dependency]
        public IUserService UserService { get; set; }

        [Microsoft.Practices.Unity.Dependency]
        public IPostService PostService { get; set; }
        [Microsoft.Practices.Unity.Dependency]
        public ICommentService CommentService { get; set; }


        public IEnumerable Export(NameValueCollection parameters)
        {
            var exportParameters = ExtractParams(parameters);
            
            return CollectData(exportParameters); ;
        }

        private ExcelExportParams ExtractParams(NameValueCollection parameters)
        {
            ExcelExportParams settings = new ExcelExportParams();
            var userId = parameters["id"];
            var export = parameters["export"];

            if (userId != null)
            {
                settings.UserId = int.Parse(userId);
            }
            else
            {
                settings.UserId = 0;
            }
            if (export != null)
            {
                settings.Export = export;
            }
            else
            {
                settings.Export = null;
            }
            return settings;
        }

        private IEnumerable CollectData(ExcelExportParams parameters)
        {

            if (parameters.Export == "comments")
            {
                return CommentService.GetCommentsByUser(parameters.UserId);
            }
            else 
            {
                 return PostService.GetPostsByUser(parameters.UserId);
            }
            
        }
    }
}