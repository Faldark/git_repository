using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Cache;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MyOwnSite_0._01.ExcelExport;

namespace MyOwnSite_0._01.BusinessLogic
{
    public interface IExportService
    {

        IList Export(NameValueCollection parameters);

        //ExcelExportParams ExtractParams(NameValueCollection parameters);

    }
}
