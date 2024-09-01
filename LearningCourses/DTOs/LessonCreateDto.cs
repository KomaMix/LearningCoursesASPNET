namespace LearningCourses.DTOs
{
    public class LessonCreateDto
    {
        public int CourseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
