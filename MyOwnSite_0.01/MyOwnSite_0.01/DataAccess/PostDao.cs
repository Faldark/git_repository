using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            //DbContext.Posts.Include(u => u.PostId).ToList()
            var posts = from s in DbContext.Posts select s;
            return posts.ToList();
        }

        public Post Get(int id)
        {
            return DbContext.Posts.First(p => p.PostId == id);
        }

    }
}