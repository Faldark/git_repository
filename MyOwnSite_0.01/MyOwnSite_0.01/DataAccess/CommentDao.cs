using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc.Html;
using System.Web.Services.Description;
using Microsoft.Practices.Unity;
using MyOwnSite_0._01.Interfaces;
using MyOwnSite_0._01.Models;

namespace MyOwnSite_0._01.DataAccess
{
    public class CommentDao : ICommentDao
    {
        [Dependency]

        public IUserContext DbContext { get; set; }


        public List<Comment> List(int postId)
        {
            var comments = from s in DbContext.Comments where s.PostId == postId select s;
            return comments.ToList();
        }

        public Comment Get(int id)
        {
            return DbContext.Comments.First(p => p.CommentId == id);
        }

        public void Insert(Comment comment)
        {
            comment.CreatedOn = DateTime.Now;
            DbContext.Comments.Add(comment);
            DbContext.SaveChanges();
        }

        public void Update(Comment comment)
        {
            DbContext.Entry(comment).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Comment comment = Get(id);
            if (comment != null)
            {
                DbContext.Comments.Remove(comment);
                DbContext.SaveChanges();

            }
        }

        public List<Comment> GetCommentsByUser(int id)
        {
            
            if (id != 0)
            {
                var comments = from s in DbContext.Comments where s.UserId == id select s;
                return comments.ToList();
            }
            else 
            {
                var comments = from s in DbContext.Comments select s ;                          
                          

               
                return comments.ToList();
            }
            
        }


    }
}