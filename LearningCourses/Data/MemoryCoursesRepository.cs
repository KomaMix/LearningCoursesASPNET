using LearningCourses.Models;

namespace LearningCourses.Data
{
	public class MemoryCoursesRepository : ICoursesRepository
	{
		private List<Course> _courses = new List<Course>
		{
			new Course
			{
				Id = 1,
				Name = "CourseA",
				Description = "dA"
			},
			new Course
			{
				Id = 2,
				Name = "CourseB",
				Description = "dB"
			}
			,
			new Course
			{
				Id = 3,
				Name = "CourseC",
				Description = "dC"
			}
		};

		private readonly MemoryLessonsRepository _lessonsRepository;

		// Конструктор для инициализации MemoryLessonsRepository
		public MemoryCoursesRepository(MemoryLessonsRepository lessonsRepository)
		{
			_lessonsRepository = lessonsRepository;
		}

		public Task Add(string courseName, string description)
		{
			var newCourse = new Course
			{
				Id = _courses.Max(c => c.Id) + 1, // Простое автоинкрементирование Id
				Name = courseName,
				Description = description
			};
			_courses.Add(newCourse);
			return Task.CompletedTask;
		}

		public Task Delete(int id)
		{
			var course = _courses.FirstOrDefault(c => c.Id == id);
			if (course != null)
			{
				_courses.Remove(course);
			}
			return Task.CompletedTask;
		}

		public Task<List<Course>> Get()
		{
			return Task.FromResult(_courses.ToList());
		}

		public Task<Course?> GetById(int id)
		{
			var course = _courses.FirstOrDefault(c => c.Id == id);
			return Task.FromResult(course);
		}

		public Task<List<Course>> GetWithLessons()
		{
			var coursesWithLessons = _courses.Select(course =>
			{
				course.Lessons = _lessonsRepository.GetByCourseId(course.Id).Result;
				return course;
			}).ToList();

			return Task.FromResult(coursesWithLessons);
		}

		public Task Update(int id, string courseName, string description)
		{
			var course = _courses.FirstOrDefault(c => c.Id == id);
			if (course != null)
			{
				course.Name = courseName;
				course.Description = description;
			}
			return Task.CompletedTask;
		}
	}
}
