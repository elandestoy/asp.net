using GHWebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using PagedList;
using GHWebApp.Models;
using GHWebApp.Helpers;
using System.Data;
using ClosedXML.Excel;
using System.IO;

namespace GHWebApp.Controllers
{

    [AuthorizeRoles(RolesUser.Administrator, RolesUser.rManager)]
    public class ReportsController : Controller
    {
        //
        private Model1 db = new Model1();

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
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
                                 where empl.Status == true

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
                                     TrainingName = trai.Name


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
            return View("EmployeeLists", employeeViews.ToPagedList(pageNumber, pageSize));


           // return View("EmployeeLists", employeeViews);
        }

        // GET: Student
        [HttpPost]
        public ActionResult BuscarEmployees( string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var ValorBusqueda = new EmployeeViewModel();

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            //var students = from s in db.temployees
            //               select s;

            var employeeViews = (from empl in db.temployees
                                 join trai in db.ttrainings on empl.IDTraining equals trai.IDTraining
                                 join ski in db.tskills on empl.IDSkills equals ski.IDSkills
                                 where empl.Status == true

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
                                     TrainingName = trai.Name


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
            return View("EmployeeLists", employeeViews.ToPagedList(pageNumber, pageSize));
        }


        // GET: Student
        [HttpGet]
        public ActionResult BuscarEmployeesFilter(string sortOrder, string currentFilter, string searchString, int? page, string vBuscarPor, 
            string Parametro1 , string Parametro2 = "")
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var ValorBusqueda = new EmployeeViewModel();

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            //var students = from s in db.temployees
            //               select s;

            var employeeViews = (from empl in db.temployees
                                 join trai in db.ttrainings on empl.IDTraining equals trai.IDTraining
                                 join ski in db.tskills on empl.IDSkills equals ski.IDSkills
                                 where empl.Status == true

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
                                     TrainingName = trai.Name


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
            return View("EmployeeLists", employeeViews.ToPagedList(pageNumber, pageSize));
        }



        [HttpPost]
        public FileResult Export()
        {
            Model1 db = new Model1();
            DataTable dt = new DataTable("EmployeeReport");
            dt.Columns.AddRange(new DataColumn[12] { new DataColumn("IDEmployees"),
                                            new DataColumn("FName"),
                                            new DataColumn("LName"),
                                            new DataColumn("Salary"),
                                            new DataColumn("RealID"),
                                            new DataColumn("Recommended"),
                                            new DataColumn("UserName"),
                                            new DataColumn("DescriptionApproved"),
                                            new DataColumn("ApprovedDate"),
                                            new DataColumn("ValoroBusqueda"),
                                            new DataColumn("SkillsName"),
                                            new DataColumn("TrainingName"),                                       


                                            });


            var employeeViews = (from empl in db.temployees
                                 join trai in db.ttrainings on empl.IDTraining equals trai.IDTraining
                                 join ski in db.tskills on empl.IDSkills equals ski.IDSkills
                                 where empl.Status == true

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
                                     TrainingName = trai.Name


                                 });


            foreach (var employe in employeeViews)
            {
                dt.Rows.Add(employe.IDEmployees, employe.FName, employe.LName, employe.Salary);
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
        }




    }
}
