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

    public class texpsController : Controller
    {
        private Model1 db = new Model1();

        // GET: texps
        public ActionResult Index()
        {
            return View(db.texps.ToList());
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
