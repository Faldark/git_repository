using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Cache;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyOwnSite_0._01.BusinessLogic
{
    public interface IExportService
    {
        void Export(NameValueCollection parameters);

    }
}
