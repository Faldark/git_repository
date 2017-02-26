using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using MyOwnSite_0._01.Interfaces;
using MyOwnSite_0._01.Models;

namespace MyOwnSite_0._01.DataAccess
{
    public class PostDao : IPostDao
    {
        [Dependency]
        public IUserContext DbContext { get; set; }


        public List<Post> List()
        {
            var posts = from s in DbContext.Posts select s;
            return posts.ToList();
        }

        public Post Get(int id)
        {
            return DbContext.Posts.First(p => p.PostId == id);
        }

        public void Insert(Post post)
        {
            post.CreatedOn = DateTime.Now;
            DbContext.Posts.Add(post);
            DbContext.SaveChanges();
        }

        public void Update(Post post)
        {
           DbContext.Entry(post).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Post post = Get(id);
            if (post != null)
            {
                DbContext.Posts.Remove(post);
                DbContext.SaveChanges();
            }
        }

        public List<Post> GetPostsByUser(int id)
        {

            if (id != 0)
            {
                var posts = from s in DbContext.Posts where s.UserId == id select s;
                return posts.ToList();
            }
            else
            {
                var posts = from s in DbContext.Posts select s;
                return posts.ToList();
            }

        }

    }
}