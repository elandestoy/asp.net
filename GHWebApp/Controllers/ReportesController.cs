

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ClosedXML.Excel;
using GHWebApp;
using GHWebApp.Helpers;
using GHWebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;

namespace GHWebApp.Controllers
{
    [AuthorizeRoles(RolesUser.Administrator, RolesUser.rManager)]
    public class ReportesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Home
        // GET: temployees
       
        public ActionResult Index()
        {
            IQueryable<temployees> emplo;

            //var reUserRol = GetRolByUser();
            //if (reUserRol == "Applicant")
            //    emplo = db.temployees.Include(t => t.tdepts).Include(t => t.texps).Include(t => t.tjobs).Include(t => t.tlangs).Include(t => t.tskills)
            //        .Include(t => t.ttrainings).Include(t => t.ttype).Where(w => w.UserName == User.Identity.Name);
            //else
                emplo = db.temployees.Include(t => t.tdepts).Include(t => t.texps).Include(t => t.tjobs).Include(t => t.tlangs).Include(t => t.tskills).Include(t => t.ttrainings).Include(t => t.ttype);


            return View("EmployeeLists",emplo);
        }

        [HttpPost]
        public ActionResult IndexBuscar(string buscarPor, 
            string textoBuscar, DateTime? fechaInicio , DateTime? fechaFinal)
        {

            IQueryable<temployees> emplo;



            if (buscarPor == "Training")
            {

                emplo = db.temployees.Include(t => t.tdepts).Include(t => t.texps)
                 .Include(t => t.tjobs).Include(t => t.tlangs)
                 .Include(t => t.tskills).Include(t => t.ttrainings)
                 .Include(t => t.ttype).Where(c => c.ttrainings.Name.Contains(textoBuscar));
            }
            else
            if (buscarPor == "Skills")
            {

                emplo = db.temployees.Include(t => t.tdepts).Include(t => t.texps)
                 .Include(t => t.tjobs).Include(t => t.tlangs)
                 .Include(t => t.tskills).Include(t => t.ttrainings)
                 .Include(t => t.ttype).Where(c => c.tskills.Name.Contains(textoBuscar));
            }
            else
                 if (buscarPor == "Range")
            {

                emplo = db.temployees.Include(t => t.tdepts).Include(t => t.texps)
                 .Include(t => t.tjobs).Include(t => t.tlangs)
                 .Include(t => t.tskills).Include(t => t.ttrainings)
                 .Include(t => t.ttype).Where(c => c.ApprovedDate.Value >= fechaInicio && c.ApprovedDate <= fechaFinal);
            }
            else
                 if (buscarPor == "Pending")
            {

                emplo = db.temployees.Include(t => t.tdepts).Include(t => t.texps)
                 .Include(t => t.tjobs).Include(t => t.tlangs)
                 .Include(t => t.tskills).Include(t => t.ttrainings)
                 .Include(t => t.ttype).Where(c => c.IDType==2);
            }
            else
            {
                emplo = db.temployees.Include(t => t.tdepts).Include(t => t.texps)
                   .Include(t => t.tjobs).Include(t => t.tlangs)
                   .Include(t => t.tskills).Include(t => t.ttrainings)
                   .Include(t => t.ttype);
            }
            


            return View("EmployeeLists", emplo);

         //   return View("EmployeeLists");
        }

        [HttpPost]
        public ActionResult ExportRedirect(string buscarPor,
            string textoBuscar, DateTime? fechaInicio, DateTime? fechaFinal)
        {
            Model1 db = new Model1();

            IQueryable<temployees> emplo;

           


            if (buscarPor == "Training")
            {

                emplo = db.temployees.Include(t => t.tdepts).Include(t => t.texps)
                 .Include(t => t.tjobs).Include(t => t.tlangs)
                 .Include(t => t.tskills).Include(t => t.ttrainings)
                 .Include(t => t.ttype).Where(c => c.ttrainings.Name.Contains(textoBuscar));
            }
            else
                if (buscarPor == "Skills")
            {

                emplo = db.temployees.Include(t => t.tdepts).Include(t => t.texps)
                 .Include(t => t.tjobs).Include(t => t.tlangs)
                 .Include(t => t.tskills).Include(t => t.ttrainings)
                 .Include(t => t.ttype).Where(c => c.tskills.Name.Contains(textoBuscar));
            }
            else
                     if (buscarPor == "Range")
            {

                emplo = db.temployees.Include(t => t.tdepts).Include(t => t.texps)
                 .Include(t => t.tjobs).Include(t => t.tlangs)
                 .Include(t => t.tskills).Include(t => t.ttrainings)
                 .Include(t => t.ttype).Where(c => c.ApprovedDate.Value >= fechaInicio && c.ApprovedDate <= fechaFinal);
            }
            else
            {
                emplo = db.temployees.Include(t => t.tdepts).Include(t => t.texps)
                   .Include(t => t.tjobs).Include(t => t.tlangs)
                   .Include(t => t.tskills).Include(t => t.ttrainings)
                   .Include(t => t.ttype);
            }


            DataTable dt = new DataTable("EmployeeReport");
            dt.Columns.AddRange(new DataColumn[11] { new DataColumn("IDEmployees"),
                                            new DataColumn("FName"),
                                            new DataColumn("LName"),
                                            new DataColumn("Salary"),
                                            new DataColumn("RealID"),
                                            new DataColumn("Recommended"),
                                            new DataColumn("UserName"),
                                            new DataColumn("DescriptionApproved"),
                                            new DataColumn("ApprovedDate"),                                           
                                            new DataColumn("SkillsName"),
                                            new DataColumn("TrainingName"),


                                            });

            foreach (var employe in emplo)
            {
                dt.Rows.Add(employe.IDEmployees, employe.FName, employe.LName, 
                    employe.Salary, employe.RealID, employe.Recommended, employe.UserName, employe.DescriptionApproved, 
                    employe.ApprovedDate, employe.tskills.Name, employe.ttrainings.Name);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }


          //  return RedirectToAction("Export", emplo);

        }


        public ActionResult PendingAprovalOld(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //  return View();
            //  return View("EmployeeLists");


            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var employeeViews = (from empl in db.temployees
                                 join trai in db.ttrainings on empl.IDTraining equals trai.IDTraining
                                 join ski in db.tskills on empl.IDSkills equals ski.IDSkills
                                 join sty in db.ttype on empl.IDType equals sty.IDType
                                  
                                 where empl.IDType ==2

                                 select new EmployeeViewModel()
                                 {
                                     IDEmployees = empl.IDEmployees,
                                     FName = empl.FName,
                                     LName = empl.LName,
                                     Salary = empl.Salary,
                                     RealID = empl.RealID,
                                     Recommended = empl.Recommended,
                                     UserName = empl.UserName,
                                     DescriptionApproved = empl.DescriptionApproved,
                                     ApprovedDate = (empl.ApprovedDate != null) ? empl.ApprovedDate.Value : DateTime.Now, //temporal
                                     ValoroBusqueda = "",
                                     SkillsName = ski.Name,
                                     TrainingName = trai.Name,
                                     TypeName = sty.Name

                                     //ttrainings = empl.ttrainings,
                                     //tskills = empl.tskills,
                                     //tjobs = empl.tjobs,
                                     //tdepts = empl.tdepts,
                                     //texps = empl.texps,
                                     //tlangs = empl.tlangs,
                                     //ttype = empl.ttype



                                 });



            if (!String.IsNullOrEmpty(searchString))
            {
                employeeViews = employeeViews.Where(s => s.LName.Contains(searchString)
                                       || s.FName.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    employeeViews = employeeViews.OrderByDescending(s => s.LName);
                    break;
                case "Date":
                    employeeViews = employeeViews.OrderBy(s => s.Salary);
                    break;
                case "date_desc":
                    employeeViews = employeeViews.OrderByDescending(s => s.Salary);
                    break;
                default:  // Name ascending 
                    employeeViews = employeeViews.OrderBy(s => s.LName);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View("EmployeePendingAproval", employeeViews.ToPagedList(pageNumber, pageSize));


            // return View("EmployeeLists", employeeViews);
        }

        [HttpPost]
        public ActionResult PendingAproval(string buscarPor,
           string textoBuscar, DateTime? fechaInicio, DateTime? fechaFinal)
        {

            IQueryable<temployees> emplo;

            if (buscarPor == "Training")
            {

                emplo = db.temployees.Include(t => t.tdepts).Include(t => t.texps)
                 .Include(t => t.tjobs).Include(t => t.tlangs)
                 .Include(t => t.tskills).Include(t => t.ttrainings)
                 .Include(t => t.ttype).Where(c => c.ttrainings.Name.Contains(textoBuscar) && c.IDType ==2);
            }
            else
            if (buscarPor == "Skills")
            {

                emplo = db.temployees.Include(t => t.tdepts).Include(t => t.texps)
                 .Include(t => t.tjobs).Include(t => t.tlangs)
                 .Include(t => t.tskills).Include(t => t.ttrainings)
                 .Include(t => t.ttype).Where(c => c.tskills.Name.Contains(textoBuscar) && c.IDType == 2);
            }
            else
                 if (buscarPor == "Range")
            {

                emplo = db.temployees.Include(t => t.tdepts).Include(t => t.texps)
                 .Include(t => t.tjobs).Include(t => t.tlangs)
                 .Include(t => t.tskills).Include(t => t.ttrainings)
                 .Include(t => t.ttype).Where(c => c.ApprovedDate.Value >= fechaInicio && c.ApprovedDate <= fechaFinal && c.IDType == 2);
            }
            else
            {
                emplo = db.temployees.Include(t => t.tdepts).Include(t => t.texps)
                   .Include(t => t.tjobs).Include(t => t.tlangs)
                   .Include(t => t.tskills).Include(t => t.ttrainings)
                   .Include(t => t.ttype).Where(d =>d.IDType == 2);
            }



            return View("EmployeePendingAproval", emplo);

            //   return View("EmployeeLists");
        }





    }
}