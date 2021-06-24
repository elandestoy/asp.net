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
    public class tjobsController : Controller
    {
        private Model1 db = new Model1();

        // GET: tjobs
        public ActionResult Index()
        {
            var tjobs = db.tjobs.Include(t => t.trisks);
            return View(tjobs.ToList());
        }

        // GET: tjobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tjobs tjobs = db.tjobs.Find(id);
            if (tjobs == null)
            {
                return HttpNotFound();
            }
            return View(tjobs);
        }

        // GET: tjobs/Create
        public ActionResult Create()
        {
            ViewBag.IDRisk = new SelectList(db.trisks, "IDRisk", "Name");
            return View();
        }

        // POST: tjobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDJobs,Name,IDRisk,MinSalary,MaxSalary,Status")] tjobs tjobs)
        {
            if (ModelState.IsValid)
            {
                db.tjobs.Add(tjobs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDRisk = new SelectList(db.trisks, "IDRisk", "Name", tjobs.IDRisk);
            return View(tjobs);
        }

        // GET: tjobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tjobs tjobs = db.tjobs.Find(id);
            if (tjobs == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDRisk = new SelectList(db.trisks, "IDRisk", "Name", tjobs.IDRisk);
            return View(tjobs);
        }

        // POST: tjobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDJobs,Name,IDRisk,MinSalary,MaxSalary,Status")] tjobs tjobs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tjobs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDRisk = new SelectList(db.trisks, "IDRisk", "Name", tjobs.IDRisk);
            return View(tjobs);
        }

        // GET: tjobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tjobs tjobs = db.tjobs.Find(id);
            if (tjobs == null)
            {
                return HttpNotFound();
            }
            return View(tjobs);
        }

        // POST: tjobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tjobs tjobs = db.tjobs.Find(id);
            db.tjobs.Remove(tjobs);
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
