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
    public class StudentController : ApiController
    {
        private  ApplicationDbContext _db = new ApplicationDbContext();

        public IHttpActionResult Index()
        {
            var course = _db.Courses
                .Include(c => c.CourseCategory)
                .ToList()
                .Select(Mapper.Map<Course, CourseDto>);

            return Ok(course);
        }
    }
}
