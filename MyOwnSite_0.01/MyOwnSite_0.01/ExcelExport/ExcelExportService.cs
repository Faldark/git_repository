using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MyOwnSite_0._01.BusinessLogic;
using MyOwnSite_0._01.Models;
using OfficeOpenXml;

namespace MyOwnSite_0._01.ExcelExport
{
    public class ExcelExportService
    {


        //public void ExportService(List<Comment> comments)
        //{
            
            
            
        //    ExcelPackage excel = new ExcelPackage();
        //    var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
        //    workSheet.Cells[1, 1].LoadFromCollection(comments, true);
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //        Response.AddHeader("content-disposition", "attachment;  filename=Contact.xlsx");
        //        excel.SaveAs(memoryStream);
        //        memoryStream.WriteTo(Response.OutputStream);
        //        Response.Flush();
        //        Response.End();


        //    }

        //}



    }

}
