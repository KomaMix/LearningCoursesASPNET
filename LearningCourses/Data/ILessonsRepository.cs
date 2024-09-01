using LearningCourses.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCourses.Data
{
	public interface ILessonsRepository
	{
		Task<List<Lesson>> Get();
		Task Add(int courseId, string name, string description);
		Task<List<Lesson>> GetByCourseId(int courseId);
		Task<Lesson?> GetById(int lessonId);
		Task Delete(int lessonId);
	}
}
