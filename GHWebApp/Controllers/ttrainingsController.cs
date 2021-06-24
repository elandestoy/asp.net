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
    public class ttrainingsController : Controller
    {
        private Model1 db = new Model1();

        // GET: ttrainings
        public ActionResult Index()
        {
            var ttrainings = db.ttrainings.Include(t => t.tlevel);
            return View(ttrainings.ToList());
        }

        // GET: ttrainings/Details/5
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
        public ActionResult Create([Bind(Include = "IDTraining,Name,IDLevel,FromDate,ToDate,Place,Status")] ttrainings ttrainings)
        {
            if (ModelState.IsValid)
            {
                db.ttrainings.Add(ttrainings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDLevel = new SelectList(db.tlevel, "IDLevel", "Name", ttrainings.IDLevel);
            return View(ttrainings);
        }

        // GET: ttrainings/Edit/5
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
        public ActionResult Edit([Bind(Include = "IDTraining,Name,IDLevel,FromDate,ToDate,Place,Status")] ttrainings ttrainings)
        {
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
        public ActionResult DeleteConfirmed(int id)
        {
            ttrainings ttrainings = db.ttrainings.Find(id);
            db.ttrainings.Remove(ttrainings);
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
