using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AerialResources.Models
{
    public class StudentCourse
    {

        [Key]
        public int StudentCourseID { get; set; }

        public int CourseID { get; set; }

   
        public int StudentID { get; set; }
    }
}
