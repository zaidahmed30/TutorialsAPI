using Microsoft.EntityFrameworkCore;
using TutorialsAPI.Models;

namespace TutorialsAPI.Data
{
   
        public class CourseContext : DbContext
        {
            public CourseContext(DbContextOptions<CourseContext> options)
                : base(options)
            {
            }

            public DbSet<Course> Courses { get; set; }
            public DbSet<Duration> Durations { get; set; }
            public DbSet<Teacher> Teachers { get; set; }
            public DbSet<CourseDetail> CourseDetails { get; set; }        

    }

}
