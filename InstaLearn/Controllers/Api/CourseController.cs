using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using InstaLearn.Dtos;
using InstaLearn.Models;

namespace InstaLearn.Controllers.Api
{
    public class CourseController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public IEnumerable<CourseDto> GetCourses()
        {
            var courses = _db.Courses.Include(c => c.CourseCategory).ToList().Select(Mapper.Map<Course, CourseDto>);
            return courses;
        }

        //api course/id
        public IHttpActionResult GetCourse(int id)
        {
            var courseInDb = _db.Courses.SingleOrDefault(c => c.Id == id);

            if (courseInDb == null)
            {
                return BadRequest();
            }

            var course = Mapper.Map<Course, CourseDto>(courseInDb);

            return Ok(course);
        }

        //post api/course/
        [HttpPost]
        public IHttpActionResult CreateCourse(CourseDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var course = Mapper.Map<CourseDto, Course>(courseDto);

            _db.Courses.Add(course);
            _db.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + course.Id), courseDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateCourse(int id, CourseDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var courseInDb = _db.Courses.SingleOrDefault(c => c.Id == id);
            if (courseInDb == null)
            {
                return NotFound();
            }

            var course = Mapper.Map(courseDto, courseInDb);
            _db.SaveChanges();

            return Ok(course);
            //courseInDb.Title = courseDto.Title;
            //courseInDb.DateCreated = courseDto.DateCreated;
            //courseInDb.EndDate = courseDto.EndDate;
            //courseInDb.CourseCategoryId = courseDto.CourseCategoryId;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var courseInDb = _db.Courses.SingleOrDefault(c => c.Id == id);

            if (courseInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _db.Courses.Remove(courseInDb);
            _db.SaveChanges();
        }

        [HttpPut]
        public IHttpActionResult Publish(int id, CourseDto courseDto)
        {
            var courseInDb = _db.Courses.SingleOrDefault(c => c.Id == id);

            if (courseInDb == null)
                return NotFound();

            courseInDb.DateCreated = DateTime.Today;
            courseInDb.EndDate = DateTime.Today.AddDays(30);
            courseInDb.IsAvailable = true;

             Mapper.Map(courseDto,courseInDb);

            _db.Entry(courseInDb).State = EntityState.Modified;
            _db.SaveChanges();

            return Ok(courseInDb);
        }
    }
}