using GHWebApp.Helpers;
using GHWebApp.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using UserRoleAuthentication.Models;

namespace GHWebApp.Controllers
{
    [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
    public class UsersController : Controller
    {
     //   private Model1 context = new Model1();
       ApplicationDbContext context;

       public UsersController()
        {
            context = new ApplicationDbContext();
        }



        /// <summary>
        /// Get All users
        /// </summary>
        /// <returns></returns>
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Index()
        {
            var users = context.Users.ToList();
            return View(users);
        }

        /// <summary>
        /// Create  a New role
        /// </summary>
        /// <returns></returns>
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Create()
        {
            var _users = new IdentityUser();
            return View(_users);
        }

        /// <summary>
        /// Create a New Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Create(IdentityUser User_)
        {
            //context.Users.Add(User_);
            //context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}

















//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using GHWebApp;

//namespace GHWebApp.Controllers
//{
//    [Authorize]
//    public class ttypesController : Controller
//    {
//        private Model1 db = new Model1();

//        // GET: ttypes
//        public ActionResult Index()
//        {
//            return View(db.ttype.ToList());
//        }

//        // GET: ttypes/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ttype ttype = db.ttype.Find(id);
//            if (ttype == null)
//            {
//                return HttpNotFound();
//            }
//            return View(ttype);
//        }

//        // GET: ttypes/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: ttypes/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "IDType,Name,Status")] ttype ttype)
//        {
//            if (ModelState.IsValid)
//            {
//                db.ttype.Add(ttype);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(ttype);
//        }

//        // GET: ttypes/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ttype ttype = db.ttype.Find(id);
//            if (ttype == null)
//            {
//                return HttpNotFound();
//            }
//            return View(ttype);
//        }

//        // POST: ttypes/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "IDType,Name,Status")] ttype ttype)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(ttype).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(ttype);
//        }

//        // GET: ttypes/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ttype ttype = db.ttype.Find(id);
//            if (ttype == null)
//            {
//                return HttpNotFound();
//            }
//            return View(ttype);
//        }

//        // POST: ttypes/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            ttype ttype = db.ttype.Find(id);
//            db.ttype.Remove(ttype);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
