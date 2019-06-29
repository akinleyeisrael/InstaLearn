using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InstaLearn.Models;

namespace InstaLearn.Dtos
{
    public class CourseCategoryDto
    {
        public int Id { get; set; }

        public CourseCategory CourseCategory { get; set; }
    }
}