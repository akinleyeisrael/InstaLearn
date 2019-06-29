using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaLearn.Models
{
    public class UserRoles
    {
        public int Id { get; set; }

        public string AdminRole { get; set; }

        public  string InstructorRole { get; set; }

        public string StudentRole { get; set; }
    }
}