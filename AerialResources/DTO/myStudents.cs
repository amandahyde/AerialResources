using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AerialResources.DTO
{
    public class myStudents
    {
        public int StudentID { get; set; }

        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public bool Status { get; set; }


        public int ParentID { get; set; }
    }
}
