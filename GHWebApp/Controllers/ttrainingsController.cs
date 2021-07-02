using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GHWebApp;
using GHWebApp.Helpers;
using GHWebApp.Models;

namespace GHWebApp.Controllers
{
    [AuthorizeRoles(RolesUser.Administrator, RolesUser.rApplicant, RolesUser.rManager)]
    public class ttrainingsController : Controller
    {
        private Model1 db = new Model1();
        private string reUserRol;


        // GET: ttrainings
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.rApplicant, RolesUser.rManager)]
        public ActionResult Index()
        {


            IQueryable<ttrainings> TrainingsJob;

             reUserRol = GetRolByUser();
            if (reUserRol == "Applicant")
                TrainingsJob = db.ttrainings.Include(t => t.tlevel).Where(w => w.UserName == User.Identity.Name);
            else
                TrainingsJob = db.ttrainings.Include(t => t.tlevel);


          //  var ttrainings = db.ttrainings.Include(t => t.tlevel);
            return View(TrainingsJob);
        }

        // GET: ttrainings/Details/5
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.rApplicant, RolesUser.rManager)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ttrainings ttrainings = db.ttrainings.Find(id);
            if (ttrainings == null)
            {
                return HttpNotFound();
            }
            return View(ttrainings);
        }

        // GET: ttrainings/Create
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.rApplicant, RolesUser.rManager)]
        public ActionResult Create()
        {
            ViewBag.IDLevel = new SelectList(db.tlevel, "IDLevel", "Name");
            return View();
        }

        // POST: ttrainings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.rApplicant, RolesUser.rManager)]
        public ActionResult Create([Bind(Include = "IDTraining,Name,IDLevel,FromDate,ToDate,Place,Status")] ttrainings ttrainings)
        {
            if (ModelState.IsValid)
            {
                ttrainings.UserName = User.Identity.Name;

                db.ttrainings.Add(ttrainings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDLevel = new SelectList(db.tlevel, "IDLevel", "Name", ttrainings.IDLevel);
            return View(ttrainings);
        }

        // GET: ttrainings/Edit/5
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.rApplicant, RolesUser.rManager)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ttrainings ttrainings = db.ttrainings.Find(id);
            if (ttrainings == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLevel = new SelectList(db.tlevel, "IDLevel", "Name", ttrainings.IDLevel);
            return View(ttrainings);
        }

        // POST: ttrainings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.rApplicant, RolesUser.rManager)]
        public ActionResult Edit([Bind(Include = "IDTraining,Name,IDLevel,FromDate,ToDate,Place,Status")] ttrainings ttrainings)
        {

            reUserRol = GetRolByUser();
            if (reUserRol == "Applicant")
                ttrainings.UserName = User.Identity.Name;


            if (ModelState.IsValid)
            {
                db.Entry(ttrainings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLevel = new SelectList(db.tlevel, "IDLevel", "Name", ttrainings.IDLevel);
            return View(ttrainings);
        }

        // GET: ttrainings/Delete/5
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.rApplicant, RolesUser.rManager)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ttrainings ttrainings = db.ttrainings.Find(id);
            if (ttrainings == null)
            {
                return HttpNotFound();
            }
            return View(ttrainings);
        }

        // POST: ttrainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.rApplicant, RolesUser.rManager)]
        public ActionResult DeleteConfirmed(int id)
        {
            ttrainings ttrainings = db.ttrainings.Find(id);
            db.ttrainings.Remove(ttrainings);
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
