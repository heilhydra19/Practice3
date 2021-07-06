using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Practice3.Models;

namespace Practice3.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LecturerId,Place,DateTime,CategoryId")] Course course)
        {
            ModelState.Remove("LecturerId");
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (ModelState.IsValid)
            {
                course.LecturerId = user.Id;
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", course.CategoryId);
            return View(course);
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
