using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AerialResources.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public bool Status { get; set; }


        public int ParentID { get; set; }
    }
}
