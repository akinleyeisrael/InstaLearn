using InstaLearn.Models;
using InstaLearn.ViewModel;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace InstaLearn.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Course
        public ActionResult Index()
        {
            var courses = _db.Courses.Include(c => c.CourseCategory).ToList();
            return View(courses);
        }

        public ActionResult New(Course course) //Create()   
        {
            var courseCategory = _db.CourseCategories.ToList();

            var viewModel = new CourseViewModel
            {
                Id = course.Id,
                Title = course.Title,
                CourseCategory =
                    courseCategory,                         //from database cos entity framework does not load the object of the domain classes
                DateCreated = course.DateCreated,
                EndDate = course.EndDate
            };
            return View("CourseForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Course course)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CourseViewModel
                {
                    Id = course.Id,
                    Title = course.Title,
                    CourseCategory = _db.CourseCategories.ToList(),
                    DateCreated = course.DateCreated,
                    EndDate = course.EndDate,
                    CourseCategoryId = course.CourseCategoryId
                };
                return View("CourseForm", viewModel);
            }
            //CREATE
            if (course.Id == 0)
            {
                course.DateCreated = DateTime.Now;
                course.EndDate = DateTime.Now.AddDays(7);
                _db.Courses.Add(course);
            }
            //EDIT
            else
            {
                var courseInDb = _db.Courses.Single(c => c.Id == course.Id); //update the model
                courseInDb.Title = course.Title;
                courseInDb.CourseCategoryId = course.CourseCategoryId;
            }
            _db.SaveChanges();
            return RedirectToAction("Index", "Course");
        }
        //nullable cos value of int is not nullable
        public ActionResult Edit(int? id)
        {
            var course = _db.Courses.SingleOrDefault(c => c.Id == id);
            //Course nourse = _db.Courses.Find(id);
            if (id == null)
                return HttpNotFound(); //STANDARD 404 ERROR            
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
            //  ViewBag.CourseCategory = new SelectList(_db.CourseCategories.ToList(), viewModel.CourseCategory)
            return View("CourseForm", viewModel);
        }

        public ActionResult Details(int? id)
        {
            var course = _db.Courses.SingleOrDefault(c => c.Id == id); //comparing the database id with the variable id

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

        public ActionResult Delete(int? id)
        {
            var course = _db.Courses.SingleOrDefault(c => c.Id == id);

            if (id == null)
                return HttpNotFound();
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
            return View("Delete", viewModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var course = _db.Courses.SingleOrDefault(c => c.Id == id);

            _db.Courses.Remove(course);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Publish(int? id)
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


            return View("Publish", viewModel);
        }

        [HttpPost]
        [ActionName("Publish")]
        public ActionResult PublishConfirmed(Course course)
        {
            var courseInDb = _db.Courses.Find(course.Id);

            if (courseInDb.Id != 0)
            {
                courseInDb.DateCreated = DateTime.Today;
                courseInDb.EndDate = DateTime.Now.AddDays(30);
                courseInDb.IsAvailable = true;
            }

            //courseInDb.IsAvailable = true;
            //_db.Entry(courseInDb).State = EntityState.Modified;         
            _db.SaveChanges();
            return RedirectToAction("Index", "AllCourses");
        }
    }
}
