using LearningCourses.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCourses.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) 
			: base(options) { }

		public DbSet<Course> Courses { get; set; }
		public DbSet<Lesson> Lessons { get; set; }
    }
}
