using LearningCourses.Data;
using Microsoft.AspNetCore.Mvc;

namespace LearningCourses.Components
{
	public class LessonList : ViewComponent
	{
		private readonly ILessonsRepository _lessonsRepository;

		public LessonList(ILessonsRepository lessonsRepository)
		{
			_lessonsRepository = lessonsRepository;
		}

		public async Task<IViewComponentResult> InvokeAsync(int courseId)
		{
			var lessons = await _lessonsRepository.GetByCourseId(courseId);
			return View(lessons);
		}
	}
}
