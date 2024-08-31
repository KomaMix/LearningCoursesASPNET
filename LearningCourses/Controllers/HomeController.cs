using LearningCourses.Data;
using Microsoft.AspNetCore.Mvc;

namespace LearningCourses.Controllers
{
	public class HomeController : Controller
	{
		ICoursesRepository _coursesRepository;

        public HomeController(ICoursesRepository coursesRepository)
        {
            this._coursesRepository = coursesRepository;
        }
        public async Task<IActionResult> Index()
		{
			var courses = await _coursesRepository.GetWithLessons();
			return View(courses);
		}
	}
}
