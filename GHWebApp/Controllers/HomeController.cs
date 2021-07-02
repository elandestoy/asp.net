using GHWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GHWebApp.Controllers
{
    public class HomeController : Controller
    {

        ApplicationDbContext context;
        
        public ActionResult Index()
        {
            ViewBag.vRolName = "";

            
            context = new ApplicationDbContext();

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
                Session["RolNa"] = usersWithRoles.RoleName;
            }
            else
            {
                ViewBag.vRolName = "";
                Session["RolNa"] = "";
            }



            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Gestión Humana Web Application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "© Enrique Landestoy 2021.";

            return View();
        }
    }
}