using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AerialResources.Models
{
    public class Move
    {
       public int MoveID {get; set;}

        public string Name { get; set; }

        public string Description { get; set; }

        public int CourseID { get; set; }

        public string VideoLink { get; set; }

        public string PreReq { get; set; }
    }
}
