using LearningCourses.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCourses.Data
{
	public interface ILessonsRepository
	{
		public Task<List<Lesson>> Get();
		public Task Add(int courseId, string name, string description);
	}
}
