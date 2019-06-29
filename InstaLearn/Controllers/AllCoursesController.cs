using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InstaLearn.Models;
using InstaLearn.ViewModel;

namespace InstaLearn.Controllers
{
    public class AllCoursesController : Controller
    {
        //Original
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: AllCourses
        public ActionResult Index()
        {
            var course = _db.Courses.Include(c => c.CourseCategory).ToList();
            return View(course);
        }

        public ActionResult Details(int? id)
        {
            var course = _db.Courses.SingleOrDefault(c => c.Id == id);

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (course == null)
                return HttpNotFound();

            var viewModel = new CourseViewModel
            {
                Id = course.Id,
                Title = course.Title,
                CourseCategory = _db.CourseCategories.ToList(),
                DateCreated = course.DateCreated,
                EndDate = course.EndDate,
                CourseCategoryId = course.CourseCategoryId
            };
            return View(viewModel);
        }

        public ActionResult Enroll(int? id)
        {
            var courseInDb = _db.Courses.SingleOrDefault(c => c.Id == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (courseInDb == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CourseViewModel
            {
                Id = courseInDb.Id,
                Title = courseInDb.Title,
                CourseCategory = _db.CourseCategories.ToList(),
                DateCreated = courseInDb.DateCreated,
                EndDate = courseInDb.EndDate,
                CourseCategoryId = courseInDb.CourseCategoryId
            };

            return View(viewModel);
        }

        [HttpPost]
        [ActionName("Enroll")]
        public ActionResult Enrolled(int id)
        {
            var courseInDb = _db.Courses.SingleOrDefault(c => c.Id == id);

            if (courseInDb.Id != 0)
            {
                courseInDb.EnrollmentDate = DateTime.Today;
            }         
            _db.SaveChanges();
            return RedirectToAction("Index", "Student");


            //Course course = _db.Courses.Find(id);
            //course.EnrollmentDate = DateTime.Today;
            //_db.Entry(course).State = EntityState.Modified;
        }
    }
}