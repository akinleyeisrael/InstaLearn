using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaLearn.Models
{
    public class Instructor  
    {

        public int Id { get; set; }

        public string FirstName { get; set; }    //FULLNAME  shoould be binded with register View model3

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public int CoursesId { get; set; }   //foreign key

        public Course Courses { get; set; }

    }
}