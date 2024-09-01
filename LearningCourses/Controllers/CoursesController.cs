using LearningCourses.Data;
using LearningCourses.DTOs;
using LearningCourses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesRepository _coursesRepository;

        public CoursesController(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        // GET: api/courses
        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetCourses()
        {
            var courses = await _coursesRepository.Get();
            return Ok(courses);
        }

        // GET: api/courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _coursesRepository.GetById(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // GET: api/courses/5/lessons
        [HttpGet("{id}/lessons")]
        public async Task<ActionResult<Course>> GetCourseWithLessons(int id)
        {
            var course = await _coursesRepository.GetByIdWithLessons(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // POST: api/courses
        [HttpPost]
        public async Task<ActionResult> CreateCourse([FromBody] CourseCreateDto courseDto)
        {
            if (courseDto == null)
            {
                return BadRequest();
            }

            await _coursesRepository.Add(courseDto.Name, courseDto.Description);

            return Ok();
        }

        // PUT: api/courses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseUpdateDto courseDto)
        {
            if (courseDto == null || id != courseDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _coursesRepository.Update(id, courseDto.Name, courseDto.Description);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            try
            {
                await _coursesRepository.Delete(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
