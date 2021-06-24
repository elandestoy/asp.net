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
    public class tlevelsController : Controller
    {
        private Model1 db = new Model1();

        // GET: tlevels
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Index()
        {
            return View(db.tlevel.ToList());
        }

        // GET: tlevels/Details/5
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlevel tlevel = db.tlevel.Find(id);
            if (tlevel == null)
            {
                return HttpNotFound();
            }
            return View(tlevel);
        }

        // GET: tlevels/Create
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: tlevels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Create([Bind(Include = "IDLevel,Name,Status")] tlevel tlevel)
        {
            if (ModelState.IsValid)
            {
                db.tlevel.Add(tlevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tlevel);
        }

        // GET: tlevels/Edit/5
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlevel tlevel = db.tlevel.Find(id);
            if (tlevel == null)
            {
                return HttpNotFound();
            }
            return View(tlevel);
        }

        // POST: tlevels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Edit([Bind(Include = "IDLevel,Name,Status")] tlevel tlevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tlevel);
        }

        // GET: tlevels/Delete/5
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlevel tlevel = db.tlevel.Find(id);
            if (tlevel == null)
            {
                return HttpNotFound();
            }
            return View(tlevel);
        }

        // POST: tlevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult DeleteConfirmed(int id)
        {
            tlevel tlevel = db.tlevel.Find(id);
            db.tlevel.Remove(tlevel);
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
