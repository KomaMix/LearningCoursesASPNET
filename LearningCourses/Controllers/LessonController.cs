using LearningCourses.Data;
using LearningCourses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private ILessonsRepository _lessonsRepository;
        public LessonController(ILessonsRepository lessonsRepository)
        {
            this._lessonsRepository = lessonsRepository;
        }

        [HttpGet]
        public async Task<List<Lesson>> Get()
        {
            return await _lessonsRepository.Get();
        }

        [HttpGet("{id}")]
        public Task<Lesson?> Get(int id)
        {
            return _lessonsRepository.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Lesson lesson)
        {
            await _lessonsRepository.Add(lesson.CourseId, lesson.Name, lesson.Description);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _lessonsRepository.Delete(id);
            return Ok();
        }
    }
}
