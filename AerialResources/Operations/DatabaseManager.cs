using AerialResources.Data;
using AerialResources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AerialResources.Operations
{
     
    public class DatabaseManager
    {
 private readonly AerialResourcesContext _context;
        public DatabaseManager(AerialResourcesContext context)
        {
            _context = context;
        }

        public static int CourseID { get; set; }

        public static int StudentID { get; set; }

        public string StudentName { get; set; }

        public static string VideoLink { get; set; }

        public Course GetCourseName(int  id)
        {
            var Course= _context.Course.Find(id);

            return Course;


        } 

    }
}
