using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using GHWebApp;
using GHWebApp.Helpers;
using GHWebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GHWebApp.Controllers
{
    [Authorize]
    public class temployeesController : Controller
    {
        private Model1 db = new Model1();

        // GET: temployees
        public ActionResult Index()
        {
            IQueryable<temployees> emplo;

            var reUserRol = GetRolByUser();
            if (reUserRol == "Applicant")
                emplo = db.temployees.Include(t => t.tdepts).Include(t => t.texps).Include(t => t.tjobs).Include(t => t.tlangs).Include(t => t.tskills)
                    .Include(t => t.ttrainings).Include(t => t.ttype).Where(w => w.UserName == User.Identity.Name);
            else
                emplo = db.temployees.Include(t => t.tdepts).Include(t => t.texps).Include(t => t.tjobs).Include(t => t.tlangs).Include(t => t.tskills).Include(t => t.ttrainings).Include(t => t.ttype);

            
            return View(emplo);
        }

        // GET: temployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            temployees temployees = db.temployees.Find(id);
            if (temployees == null)
            {
                return HttpNotFound();
            }
            return View(temployees);
        }

        // GET: temployees/Create
        public ActionResult Create()
        {
            var templ = new temployees();

            templ.tdepts = new tdepts();
            templ.texps = new texps();
            templ.tjobs = new tjobs();
            templ.tlangs = new tlangs();
            templ.tskills = new tskills();
            templ.ttrainings = new ttrainings();
            templ.ttype = new ttype();

            ViewBag.IDDept = new SelectList(db.tdepts, "IDDept", "Name");
            ViewBag.IDExp = new SelectList(db.texps, "IDExp", "JobName");
            ViewBag.IDJobs = new SelectList(db.tjobs, "IDJobs", "Name");
            ViewBag.IDLangs = new SelectList(db.tlangs, "IDLangs", "Name");
            ViewBag.IDSkills = new SelectList(db.tskills, "IDSkills", "Name");
            ViewBag.IDTraining = new SelectList(db.ttrainings, "IDTraining", "Name");
            ViewBag.IDType = new SelectList(db.ttype, "IDType", "Name");


            var reUserRol = GetRolByUser();
            ViewBag.vRolName = reUserRol;

            return View(templ);
        }

        // POST: temployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       public ActionResult Create([Bind(Include = "IDEmployees,RealID,FName,LName,IDJobs,IDDept,Salary,IDSkills,IDTraining,IDExp,IDLangs,Recommended,IDType,Status")] temployees temployees)
      //  public ActionResult Create([Bind(Exclude = "tdepts,texps,tjobs,tlangs,tskills,ttrainings,ttype")] temployees temployees)
        {
            if (ModelState.IsValid)
            {
                temployees.UserName = User.Identity.Name;

                var reUserRol = GetRolByUser();

                if (reUserRol == "Applicant")
                    temployees.IDType = 2;


                db.temployees.Add(temployees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDept = new SelectList(db.tdepts, "IDDept", "Name", temployees.IDDept);
            ViewBag.IDExp = new SelectList(db.texps, "IDExp", "JobName", temployees.IDExp);
            ViewBag.IDJobs = new SelectList(db.tjobs, "IDJobs", "Name", temployees.IDJobs);
            ViewBag.IDLangs = new SelectList(db.tlangs, "IDLangs", "Name", temployees.IDLangs);
            ViewBag.IDSkills = new SelectList(db.tskills, "IDSkills", "Name", temployees.IDSkills);
            ViewBag.IDTraining = new SelectList(db.ttrainings, "IDTraining", "Name", temployees.IDTraining);
            ViewBag.IDType = new SelectList(db.ttype, "IDType", "Name", temployees.IDType);


            return View(temployees);
        }

        // GET: temployees/Edit/5 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

           


                temployees temployees = db.temployees.Find(id);

            //Mapper.CreateMap<EmployeeViewModel, temployees>();  //creating map  
                            
              //  var vm = EmployeeViewModel.MapearComoViewModel(temployees);
               // ViewBag.Title = string.Format("Editando Ventanilla Usuario ({0})", vm.id);
              
           
            if (temployees == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDept = new SelectList(db.tdepts, "IDDept", "Name", temployees.IDDept);
            ViewBag.IDExp = new SelectList(db.texps, "IDExp", "JobName", temployees.IDExp);
            ViewBag.IDJobs = new SelectList(db.tjobs, "IDJobs", "Name", temployees.IDJobs);
            ViewBag.IDLangs = new SelectList(db.tlangs, "IDLangs", "Name", temployees.IDLangs);
            ViewBag.IDSkills = new SelectList(db.tskills, "IDSkills", "Name", temployees.IDSkills);
            ViewBag.IDTraining = new SelectList(db.ttrainings, "IDTraining", "Name", temployees.IDTraining);
            ViewBag.IDType = new SelectList(db.ttype, "IDType", "Name", temployees.IDType);


               var reUserRol = GetRolByUser();
            ViewBag.vRolName = reUserRol;
           // temployees.RolName = reUserRol;

        
            return View(temployees);
           // return View("EmployeeViewModel", vm);
            //   return RedirectToAction("Index");
        }

        // POST: temployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDEmployees,RealID,FName,LName,IDJobs,IDDept,Salary,IDSkills,IDTraining,IDExp,IDLangs,Recommended,IDType,Status,UserName,DescriptionApproved")] temployees temployees)
        {
            if (ModelState.IsValid)
            {
                var reUserRol = GetRolByUser();
               


                if (reUserRol == "Applicant")
                    temployees.IDType = 2;

                if (reUserRol == "Manager")
                    temployees.ApprovedDate = DateTime.Now;

                    db.Entry(temployees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDept = new SelectList(db.tdepts, "IDDept", "Name", temployees.IDDept);
            ViewBag.IDExp = new SelectList(db.texps, "IDExp", "JobName", temployees.IDExp);
            ViewBag.IDJobs = new SelectList(db.tjobs, "IDJobs", "Name", temployees.IDJobs);
            ViewBag.IDLangs = new SelectList(db.tlangs, "IDLangs", "Name", temployees.IDLangs);
            ViewBag.IDSkills = new SelectList(db.tskills, "IDSkills", "Name", temployees.IDSkills);
            ViewBag.IDTraining = new SelectList(db.ttrainings, "IDTraining", "Name", temployees.IDTraining);
            ViewBag.IDType = new SelectList(db.ttype, "IDType", "Name", temployees.IDType);
            // return View(temployees);
            return RedirectToAction("Index");
        }

        // GET: temployees/Delete/5
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.rManager)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            temployees temployees = db.temployees.Find(id);
            if (temployees == null)
            {
                return HttpNotFound();
            }
            return View(temployees);
        }

        // POST: temployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            temployees temployees = db.temployees.Find(id);
            db.temployees.Remove(temployees);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
        // GET: temployees/Delete/5
        [AuthorizeRoles(RolesUser.Administrator, RolesUser.rManager)]
        public ActionResult Contract(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            temployees temployees = db.temployees.Find(id);
            if (temployees != null)
            {
                temployees.IDType = 1;
                db.Entry(temployees).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            if (temployees == null)
            {
                return HttpNotFound();
            }

            // return View(temployees);
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



        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
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


    }
}
