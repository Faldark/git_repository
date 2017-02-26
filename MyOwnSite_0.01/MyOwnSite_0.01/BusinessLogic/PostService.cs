using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using MyOwnSite_0._01.DataAccess;
using MyOwnSite_0._01.Models;

namespace MyOwnSite_0._01.BusinessLogic
{
    public class PostService : IPostService
    {
        [Dependency]

        public IPostDao PostDao { get; set; }


        public List<Post> List()
        {
            return PostDao.List();
        }

        public List<Post> ListMessageLimit()
        {
            var posts = PostDao.List();

            foreach (var post in posts)
            {
                if (post.Message.Length > 100)
                {
                    post.Message = post.Message.Substring(0, 100);
                }
            }
            return posts;
        }

        public Post Get(int id)
        {
            return PostDao.Get(id);
        }

        public void Insert(Post post)
        {
            PostDao.Insert(post);
        }

        public void Update(Post post)
        {
            PostDao.Update(post);
        }

        public void Delete(int id)
        {
            PostDao.Delete(id);
        }

        public List<Post> GetPostsByUser(int id)
        {
            return PostDao.GetPostsByUser(id);
        }
    }
}