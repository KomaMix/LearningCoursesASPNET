using LearningCourses.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCourses.Data
{
	public interface ICoursesRepository
	{
		Task<List<Course>> Get();
		Task<List<Course>> GetWithLessons();
		Task<Course?> GetById(int id);
		Task<Course?> GetByIdWithLessons(int id);
		Task Add(string courseName, string description);
		Task Update(int id, string courseName, string description);
		Task Delete(int id);
	}
}
