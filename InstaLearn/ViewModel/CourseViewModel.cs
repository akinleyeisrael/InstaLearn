using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using InstaLearn.Models;

namespace InstaLearn.ViewModel
{
    public class CourseViewModel
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public int CourseCategoryId { get; set; }   //foreign key

        //[DisplayFormat(DataFormatString = "{0:d MMM YYY}", ApplyFormatInEditMode = true)]
        public DateTime? DateCreated { get; set; }    //for Instructor => CRUD and students => CourseDetalis

        public DateTime? EndDate { get; set; }    //60 days from date created

        public IEnumerable<CourseCategory> CourseCategory { get; set; }

    }
}