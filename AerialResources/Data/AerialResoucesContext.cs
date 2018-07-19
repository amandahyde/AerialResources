using AerialResources.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AerialResources.Data
{
    public class AerialResourcesContext : DbContext
    {

        public AerialResourcesContext(DbContextOptions<AerialResourcesContext> options) : base(options)
        {

        }

        public AerialResourcesContext()
        {

        }

        public DbSet<Course> Course { get; set; }

        public DbSet<AerialResources.Models.Move> Move { get; set; }

        public DbSet<AerialResources.Models.Student> Student { get; set; }

        public DbSet<AerialResources.Models.StudentCourse> StudentCourse { get; set; }

        //public DbSet<AerialResources.Models.Parent> Parent { get; set; }

        public DbSet<AerialResources.Models.TrapezeVideos> TrapezeVideos { get; set; }

        public DbSet<AerialResources.Models.RopeVideos> RopeVideos { get; set; }

        public DbSet<AerialResources.Models.LyraVideos> LyraVideos { get; set; }

        public DbSet<AerialResources.Models.SilksVideos> SilksVideos { get; set; }

        public DbSet<AerialResources.Models.SlingVideos> SlingVideos { get; set; }

        public DbSet<AerialResources.Models.DuoVideos> DuoVideos { get; set; }

       
    }
}
