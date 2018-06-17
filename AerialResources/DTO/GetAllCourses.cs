using AerialResources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AerialResources.DTO
{
    public class GetAllCourses
    {

        public List<Course> courses = new List<Course>();

        public List<Student> students = new List<Student>();

        public List<StudentCourse> studentcourse = new List<StudentCourse>();

        public myCourses myCourses { get; set; }

        public myStudents myStudents { get; set; }

    }
}
