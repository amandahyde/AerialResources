using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AerialResources.Models;

namespace AerialResources.DTO
{
    public class GetAllMovesCourses
    {
        public List<Course> courses = new List<Course>();

        public List<Move> moves = new List<Move>();

        public myMoves myMoves { get; set; }

    }
}
