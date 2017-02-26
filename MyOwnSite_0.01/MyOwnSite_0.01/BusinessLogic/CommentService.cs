using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using MyOwnSite_0._01.DataAccess;
using MyOwnSite_0._01.Models;

namespace MyOwnSite_0._01.BusinessLogic
{
    public class CommentService : ICommentService
    {

        [Dependency]
        public ICommentDao CommentDao { get; set; }

        public List<Comment> List(int postId)
        {
            return CommentDao.List(postId);
        }

        public Comment Get(int id)
        {
            return CommentDao.Get(id);
        }

        public void Insert(Comment comment)
        {
            CommentDao.Insert(comment);
        }

        public void Update(Comment comment)
        {
            CommentDao.Update(comment);
        }

        public void Delete(int id)
        {
            CommentDao.Delete(id);
        }

        public List<Comment> GetCommentsByUser(int id)
        {
            return CommentDao.GetCommentsByUser(id);
        }
    }
}