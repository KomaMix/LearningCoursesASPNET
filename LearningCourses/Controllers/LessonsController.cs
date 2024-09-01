using LearningCourses.Data;
using LearningCourses.DTOs;
using LearningCourses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private ILessonsRepository _lessonsRepository;
        public LessonsController(ILessonsRepository lessonsRepository)
        {
            this._lessonsRepository = lessonsRepository;
        }

        // GET: api/Lessons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lesson>>> GetLessons()
        {
            var lessons = await _lessonsRepository.Get();
            return Ok(lessons);
        }

        // GET: api/Lessons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lesson>> GetLesson(int id)
        {
            var lesson = await _lessonsRepository.GetById(id);

            if (lesson == null)
            {
                return NotFound();
            }

            return Ok(lesson);
        }

        // GET: api/Lessons/Course/5
        [HttpGet("Course/{courseId}")]
        public async Task<ActionResult<IEnumerable<Lesson>>> GetLessonsByCourse(int courseId)
        {
            var lessons = await _lessonsRepository.GetByCourseId(courseId);
            return Ok(lessons);
        }

        // POST: api/Lessons
        [HttpPost]
        public async Task<ActionResult> CreateLesson([FromBody] LessonCreateDto lesson)
        {
            await _lessonsRepository.Add(lesson.CourseId, lesson.Name, lesson.Description);
            return Ok();
        }

        // DELETE: api/Lessons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var lesson = await _lessonsRepository.GetById(id);
            if (lesson == null)
            {
                return NotFound();
            }

            await _lessonsRepository.Delete(id);
            return NoContent();
        }
    }
}
