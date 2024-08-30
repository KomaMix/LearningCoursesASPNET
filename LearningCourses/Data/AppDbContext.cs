using LearningCourses.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCourses.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) 
			: base(options) { }

		DbSet<Course> Courses { get; set; }
		DbSet<Lesson> Lessons { get; set; }
    }
}
