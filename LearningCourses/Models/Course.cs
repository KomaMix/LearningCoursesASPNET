namespace LearningCourses.Models
{
	public class Course
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public List<Lesson> Lessons { get; set; } = new List<Lesson>();
	}
}
