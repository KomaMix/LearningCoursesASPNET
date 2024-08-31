using LearningCourses.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCourses.Data
{
	public interface ICoursesRepository
	{
		public Task<List<Course>> Get();
		public Task<List<Course>> GetWithLessons();
		public Task<Course?> GetById(int id);
		public Task Add(string courseName, string description);
		public Task Update(int id, string courseName, string description);
		public Task Delete(int id);
	}
}
