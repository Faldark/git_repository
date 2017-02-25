using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyOwnSite_0._01.Models;

namespace MyOwnSite_0._01.BusinessLogic
{
    public interface ICommentService
    {
        List<Comment> List(int postId);

        Comment Get(int id);
        void Insert(Comment comment);
        void Update(Comment comment);
        void Delete(int id);


    }
}
