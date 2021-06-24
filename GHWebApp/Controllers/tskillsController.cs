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

namespace GHWebApp.Controllers
{
    [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
    public class tskillsController : Controller
    {
        private Model1 db = new Model1();

        // GET: tskills
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Index()
        {
            return View(db.tskills.ToList());
        }

        // GET: tskills/Details/5
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tskills tskills = db.tskills.Find(id);
            if (tskills == null)
            {
                return HttpNotFound();
            }
            return View(tskills);
        }

        // GET: tskills/Create
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: tskills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Create([Bind(Include = "IDSkills,Name,Status")] tskills tskills)
        {
            if (ModelState.IsValid)
            {
                db.tskills.Add(tskills);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tskills);
        }

        // GET: tskills/Edit/5
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tskills tskills = db.tskills.Find(id);
            if (tskills == null)
            {
                return HttpNotFound();
            }
            return View(tskills);
        }

        // POST: tskills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Edit([Bind(Include = "IDSkills,Name,Status")] tskills tskills)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tskills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tskills);
        }

        // GET: tskills/Delete/5
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tskills tskills = db.tskills.Find(id);
            if (tskills == null)
            {
                return HttpNotFound();
            }
            return View(tskills);
        }

        // POST: tskills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult DeleteConfirmed(int id)
        {
            tskills tskills = db.tskills.Find(id);
            db.tskills.Remove(tskills);
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
