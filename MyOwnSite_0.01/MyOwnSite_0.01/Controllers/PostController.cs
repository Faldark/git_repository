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

        public IUserService UserService { get; set; }

        private UserContext db = new UserContext();

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
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "Name", post.UserId);
            return View(post);
        }

        // GET: /Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
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
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
