using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MyOwnSite_0._01.Models;
using MyOwnSite_0._01;
using MyOwnSite_0._01.BusinessLogic;

namespace MyOwnSite_0._01.Controllers
{
    public class PostController : Controller
    {

        [Dependency]

        public IPostService PostService { get; set; }

        [Dependency]

        public ICommentService CommentService { get; set; }



        [Dependency]

        public IUserService UserService { get; set; }

        // GET: /Post/
        public ActionResult Index()
        {
            var posts = PostService.ListMessageLimit();

            return View(posts);
        }

        // GET: /Post/Details/5
        public ActionResult Details(int id)
        {
            
            Post post = PostService.Get(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: /Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PostId,Id,Title,Message")] Post post)
        {
            if (ModelState.IsValid)
            {
                
                var name = System.Web.HttpContext.Current.User.Identity.Name;

                var user = UserService.FindUserByLogin(name);

                post.UserId = user.UserId;

                PostService.Insert(post);
                
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: /Post/Edit/5
        public ActionResult Edit(int id)
        {

            Post post = PostService.Get(id);
            
            if (post == null)
            {
                return HttpNotFound();
            }
            
            return View(post);
        }

        // POST: /Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,UserId,Title,Message,CreatedOn")] Post post)
        {
            if (ModelState.IsValid)
            {

                PostService.Update(post);
                
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: /Post/Delete/5
        public ActionResult Delete(int id)
        {
            
            Post post = PostService.Get(id);
            
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: /Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = PostService.Get(id);

            PostService.Delete(id);

            return RedirectToAction("Index");
        }


        public ActionResult CreateComment(int id)
        {
            Comment model = new Comment {PostId = id};


            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment([Bind(Include = "CommentId,PostId,Id,Title,Message")] Comment comment)
        {
            if (ModelState.IsValid)
            {

                var name = System.Web.HttpContext.Current.User.Identity.Name;

                var user = UserService.FindUserByLogin(name);

                comment.UserId = user.UserId;

                CommentService.Insert(comment);

                return RedirectToAction("Index");

                ////Strange redirectToAction Behavior, need to investigate later
                //return RedirectToAction("Details", comment.PostId);
            }

            return View(comment);
        }

        // GET: /Post/Delete/5
        public ActionResult DeleteComment(int id)
        {

            Comment comment = CommentService.Get(id);

            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: /Post/Delete/5
        [HttpPost, ActionName("DeleteComment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCommentConfirmed(int id)
        {
            Comment post = CommentService.Get(id);

            CommentService.Delete(id);

            return RedirectToAction("Index");
        }





        // GET: /Post/Edit/5
        public ActionResult EditComment(int id)
        {

            Comment comment = CommentService.Get(id);

            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        // POST: /Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComment([Bind(Include = "CommentId,PostId,UserId,Title,Message,CreatedOn")] Comment comment)
        {
            if (ModelState.IsValid)
            {

                CommentService.Update(comment);

                return RedirectToAction("Index");
            }
            return View(comment);
        }



     }

    









}
