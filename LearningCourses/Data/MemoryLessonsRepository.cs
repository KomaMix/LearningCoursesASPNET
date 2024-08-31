using LearningCourses.Models;

namespace LearningCourses.Data
{
	public class MemoryLessonsRepository : ILessonsRepository
	{
		private List<Lesson> _lessons = new List<Lesson>
		{
			new Lesson
			{
				Id = 1,
				Name = "lesson_1",
				Description = "d1",
				CourseId = 1
			},
			new Lesson
			{
				Id = 2,
				Name = "lesson_2",
				Description = "d2",
				CourseId = 1
			},
			new Lesson
			{
				Id = 3,
				Name = "lesson_3",
				Description = "d3",
				CourseId = 2
			},
			new Lesson
			{
				Id = 4,
				Name = "lesson_4",
				Description = "d4",
				CourseId = 2
			},
			new Lesson
			{
				Id = 5,
				Name = "lesson_5",
				Description = "d5",
				CourseId = 3
			}

		};

		public Task Add(int courseId, string name, string description)
		{
			var newLesson = new Lesson
			{
				Id = _lessons.Max(l => l.Id) + 1, // Простое автоинкрементирование Id
				Name = name,
				Description = description,
				CourseId = courseId
			};
			_lessons.Add(newLesson);
			return Task.CompletedTask;
		}

		public Task<List<Lesson>> Get()
		{
			return Task.FromResult(_lessons.ToList());
		}

		public Task<Lesson?> GetById(int lessonId)
		{
			var lesson = _lessons.FirstOrDefault(l => l.Id == lessonId);
			return Task.FromResult(lesson);
		}

		public Task<List<Lesson>> GetByCourseId(int courseId)
		{
			var lessons = _lessons.Where(l => l.CourseId == courseId).ToList();
			return Task.FromResult(lessons);
		}

        public Task Delete(int lessonId)
		{
			_lessons.RemoveAll(l => l.Id == lessonId);

			return Task.CompletedTask;
		}
    }
}
