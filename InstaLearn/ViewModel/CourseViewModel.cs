using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InstaLearn.Models;

namespace InstaLearn.ViewModel
{
    public class CourseViewModel
    {
        public string Title { get; set; }

        public int CourseCategoryId { get; set; }   //foreign key

        public DateTime DateCreated { get; set; }    //for Instructor => CRUD and students => CourseDetalis

        public DateTime EndDate { get; set; }    //60 days from date created

        public CourseCategory CourseCategory { get; set; }

    }
}