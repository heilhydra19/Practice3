using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Practice3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice3.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var upcommingCourse = db.Courses.Where(p => p.DateTime > DateTime.Now).OrderBy(p => p.DateTime).ToList();
            foreach(Course i in upcommingCourse)
            {
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(i.LecturerId);
                i.Name = user.Name;
            }
            return View(upcommingCourse);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}