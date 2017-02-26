using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MyOwnSite_0._01.BusinessLogic;
using MyOwnSite_0._01.Models;
using OfficeOpenXml;

namespace MyOwnSite_0._01.ExcelExport
{
    public class ExcelExportService
    {
        [Dependency]

        public IExportService ExportService { get; set; }

        public void Export(IEnumerable dataForList, HttpResponseBase responce)
        {
            
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            
            List<Comment> comments = dataForList as List<Comment>;
            if (comments != null)
            {
                workSheet.Cells[1, 1].LoadFromCollection(comments, true);
            }
            List<Post> posts = dataForList as List<Post>;
            if (posts != null)
            {
                workSheet.Cells[1, 1].LoadFromCollection(posts, true);
            }

            using (var memoryStream = new MemoryStream())
            {
                responce.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                responce.AddHeader("content-disposition", "attachment;  filename=Contact.xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(responce.OutputStream);
                responce.Flush();
                responce.End();
                
            }

        }



    }

}
