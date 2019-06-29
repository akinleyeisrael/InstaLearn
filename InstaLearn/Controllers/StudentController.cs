using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using InstaLearn.Models;

namespace InstaLearn.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Student
        public ActionResult Index()
        {
            var course = _db.Courses.Include(c => c.CourseCategory).ToList();
            return View(course);
        }
    }
}