using LearningCourses.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCourses.Data
{
	public class AddDbContext : DbContext
	{
        public AddDbContext(DbContextOptions<AddDbContext> options) 
			: base(options) { }

		DbSet<Course> Courses { get; set; }
		DbSet<Lesson> Lessons { get; set; }
    }
}
