using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Antlr.Runtime;
using AutoMapper;
using InstaLearn.Dtos;
using InstaLearn.Models;

namespace InstaLearn.Controllers.Api
{
    public class AllCoursesController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public IHttpActionResult Index()
        {
            var allCourse = _db.Courses.Include(c => c.CourseCategory).ToList().Select(Mapper.Map<Course, CourseDto>);
            return Ok(allCourse);
        }

        //Get api/details
        //for details
        public IHttpActionResult GetCourse(int? id,CourseDto courseDto)
        {
            var allCourse = _db.Courses.SingleOrDefault(c => c.Id == id);

            if (allCourse == null)
                return NotFound();

            if (id == null)
                return BadRequest();

            return Ok(Mapper.Map<Course, CourseDto>(allCourse));
        }

        //POST api/enroll
        [HttpPost]
        public IHttpActionResult Enroll(int id,CourseDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var courseInDb = _db.Courses.SingleOrDefault(c => c.Id == id);

            _db.Entry(courseInDb).State = EntityState.Modified;

             Mapper.Map(courseDto, courseInDb);
            _db.SaveChanges();

            return Ok(courseDto);

        }
    }
}
