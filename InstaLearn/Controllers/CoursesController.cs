using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using InstaLearn.Models;
using InstaLearn.ViewModel;

namespace InstaLearn.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Course
        public ActionResult Index()
        {
            var courses = _db.Courses.Include(c => c.CourseCategory).ToList();
            return View(courses);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(Course model)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new CourseViewModel()
                {
                    Title = model.Title,
                    CourseCategory = model.CourseCategory
                };
                _db.SaveChanges();
                return View("Create",ViewModel);
            }

            return RedirectToAction("index");
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
