 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaLearn.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        private string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public DateTime EnrollmentDate { get; set; }

        public int CoursesId { get; set; }   //foreign key

        public Course Courses { get; set; }
    }
}