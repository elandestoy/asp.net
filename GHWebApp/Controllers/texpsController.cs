using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GHWebApp;
using GHWebApp.Models;

namespace GHWebApp.Controllers
{
    [Authorize]

    public class texpsController : Controller
    {
        private Model1 db = new Model1();

        private string reUserRol;


        // GET: texps
        public ActionResult Index()
        {

            IQueryable<texps> expJob;

            var reUserRol = GetRolByUser();
            if (reUserRol == "Applicant")
                expJob = db.texps.Where(w => w.UserName == User.Identity.Name);
            else
                expJob = db.texps;



            return View(expJob);
        }

        // GET: texps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            texps texps = db.texps.Find(id);
            if (texps == null)
            {
                return HttpNotFound();
            }
            return View(texps);
        }

        // GET: texps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: texps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDExp,JobName,Place,FromDate,ToDate,Salary,Status")] texps texps)
        {
            if (ModelState.IsValid)
            {
                texps.UserName = User.Identity.Name;

                db.texps.Add(texps);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(texps);
        }

        // GET: texps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            texps texps = db.texps.Find(id);
            if (texps == null)
            {
                return HttpNotFound();
            }
            return View(texps);
        }

        // POST: texps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDExp,JobName,Place,FromDate,ToDate,Salary,Status")] texps texps)
        {
            reUserRol = GetRolByUser();
            if (reUserRol == "Applicant")
                texps.UserName = User.Identity.Name;

            if (ModelState.IsValid)
            {
                db.Entry(texps).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(texps);
        }

        // GET: texps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            texps texps = db.texps.Find(id);
            if (texps == null)
            {
                return HttpNotFound();
            }
            return View(texps);
        }

        // POST: texps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            texps texps = db.texps.Find(id);
            db.texps.Remove(texps);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //get Role:
        public string GetRolByUser()
        {
            ApplicationDbContext context;
            context = new ApplicationDbContext();

            var rUser = "";
            if (User.Identity.IsAuthenticated)
            {

                var usersWithRoles = (from user in context.Users
                                      from userRole in user.Roles
                                      join role in context.Roles on userRole.RoleId equals
                                      role.Id
                                      where user.UserName == User.Identity.Name
                                      select new UserViewModel()
                                      {
                                          Username = user.UserName,
                                          Email = user.Email,
                                          RoleName = role.Name
                                      }).FirstOrDefault();

                if (usersWithRoles != null)
                {
                    ViewBag.vRolName = usersWithRoles.RoleName;
                    rUser = usersWithRoles.RoleName;
                }
                else
                {
                    ViewBag.vRolName = "";
                    rUser = "";
                }

            }
            return rUser;
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
