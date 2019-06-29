using System;

namespace InstaLearn.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int CourseCategoryId { get; set; } //foreign key

        public DateTime? DateCreated { get; set; } //for Instructor => CRUD and students => CourseDetalis

        public DateTime? EndDate { get; set; } //60 days from date created

        public CourseCategory CourseCategory { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime? EnrollmentDate { get; set; }
        //on admin page only title category course id
    }
}