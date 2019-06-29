using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaLearn.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int CourseCategoryId { get; set; }   //foreign key

        public DateTime DateCreated { get; set; }    //for Instructor => CRUD and students => CourseDetalis

        public DateTime EndDate { get; set; }    //60 days from date created

       /* public CourseCategoryDto CourseCategory { get; set; }  */   //reomove cos can break the api if any changes are made to it alt-create another dto

        public bool IsAvailable { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}