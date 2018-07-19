using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AerialResources.Models
{
    public class TrapezeVideos
    {

        [Key]
        public int VideoID { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Level { get; set; }

        public string PreReqs { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
