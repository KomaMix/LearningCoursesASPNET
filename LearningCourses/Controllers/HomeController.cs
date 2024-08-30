using Microsoft.AspNetCore.Mvc;

namespace LearningCourses.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
