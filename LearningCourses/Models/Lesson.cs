using System.ComponentModel.DataAnnotations.Schema;

namespace LearningCourses.Models
{
	public class Lesson
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int CourseId { get; set; }
		public Course? Course { get; set; }
	}
}
