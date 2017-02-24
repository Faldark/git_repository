using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyOwnSite_0._01.Models;

namespace MyOwnSite_0._01.BusinessLogic
{
    public interface IPostService
    {
        List<Post> List();
        List<Post> ListMessageLimit();

        Post Get(int id);

        void Insert(Post post);



    }
}
