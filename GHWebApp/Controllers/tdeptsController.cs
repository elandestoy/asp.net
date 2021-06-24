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
    public class tdeptsController : Controller
    {
        private Model1 db = new Model1();

        // GET: tdepts
        public ActionResult Index()
        {
            return View(db.tdepts.ToList());
        }

        // GET: tdepts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tdepts tdepts = db.tdepts.Find(id);
            if (tdepts == null)
            {
                return HttpNotFound();
            }
            return View(tdepts);
        }

        // GET: tdepts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tdepts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDept,Name,Status")] tdepts tdepts)
        {
            if (ModelState.IsValid)
            {
                db.tdepts.Add(tdepts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tdepts);
        }

        // GET: tdepts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tdepts tdepts = db.tdepts.Find(id);
            if (tdepts == null)
            {
                return HttpNotFound();
            }
            return View(tdepts);
        }

        // POST: tdepts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDept,Name,Status")] tdepts tdepts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tdepts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tdepts);
        }

        // GET: tdepts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tdepts tdepts = db.tdepts.Find(id);
            if (tdepts == null)
            {
                return HttpNotFound();
            }
            return View(tdepts);
        }

        // POST: tdepts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tdepts tdepts = db.tdepts.Find(id);
            db.tdepts.Remove(tdepts);
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
