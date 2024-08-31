using LearningCourses.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCourses.Data
{
	public interface ILessonsRepository
	{
		public Task<List<Lesson>> Get();
		public Task Add(int courseId, string name, string description);
		public Task<List<Lesson>> GetByCourseId(int courseId);
		public Task<Lesson?> GetByLessonId(int lessonId);
	}
}
