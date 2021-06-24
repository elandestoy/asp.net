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
    public class trisksController : Controller
    {
        private Model1 db = new Model1();

        // GET: trisks
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Index()
        {
            return View(db.trisks.ToList());
        }

        // GET: trisks/Details/5
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trisks trisks = db.trisks.Find(id);
            if (trisks == null)
            {
                return HttpNotFound();
            }
            return View(trisks);
        }

        // GET: trisks/Create
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: trisks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Create([Bind(Include = "IDRisk,Name,Status")] trisks trisks)
        {
            if (ModelState.IsValid)
            {
                db.trisks.Add(trisks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trisks);
        }

        // GET: trisks/Edit/5
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trisks trisks = db.trisks.Find(id);
            if (trisks == null)
            {
                return HttpNotFound();
            }
            return View(trisks);
        }

        // POST: trisks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Edit([Bind(Include = "IDRisk,Name,Status")] trisks trisks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trisks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trisks);
        }

        // GET: trisks/Delete/5
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trisks trisks = db.trisks.Find(id);
            if (trisks == null)
            {
                return HttpNotFound();
            }
            return View(trisks);
        }

        // POST: trisks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.Assistant)]
        public ActionResult DeleteConfirmed(int id)
        {
            trisks trisks = db.trisks.Find(id);
            db.trisks.Remove(trisks);
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
