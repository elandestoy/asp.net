using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GHWebApp;

namespace GHWebApp.Controllers
{
    [Authorize]
    public class tlangsController : Controller
    {
        private Model1 db = new Model1();

        // GET: tlangs
        public ActionResult Index()
        {
            return View(db.tlangs.ToList());
        }

        // GET: tlangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlangs tlangs = db.tlangs.Find(id);
            if (tlangs == null)
            {
                return HttpNotFound();
            }
            return View(tlangs);
        }

        // GET: tlangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tlangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLangs,Name,Status")] tlangs tlangs)
        {
            if (ModelState.IsValid)
            {
                db.tlangs.Add(tlangs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tlangs);
        }

        // GET: tlangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlangs tlangs = db.tlangs.Find(id);
            if (tlangs == null)
            {
                return HttpNotFound();
            }
            return View(tlangs);
        }

        // POST: tlangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLangs,Name,Status")] tlangs tlangs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlangs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tlangs);
        }

        // GET: tlangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlangs tlangs = db.tlangs.Find(id);
            if (tlangs == null)
            {
                return HttpNotFound();
            }
            return View(tlangs);
        }

        // POST: tlangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tlangs tlangs = db.tlangs.Find(id);
            db.tlangs.Remove(tlangs);
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
