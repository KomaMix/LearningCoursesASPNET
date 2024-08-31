using LearningCourses.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCourses.Data
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly AppDbContext _dbContext;

        public CoursesRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task Add(string courseName, string description)
        {
            var course = new Course
            {
                Name = courseName,
                Description = description
            };

            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var course = await _dbContext.Courses
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();

            await _dbContext.SaveChangesAsync();
        }

        public Task<List<Course>> Get()
        {
            return _dbContext.Courses
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<Course?> GetById(int id)
        {
            return _dbContext.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Course?> GetByIdWithLessons(int id)
        {
            var course = await _dbContext.Courses
                .AsNoTracking()
                .Include(c => c.Lessons)
                .FirstOrDefaultAsync(c => c.Id == id);
            return course;
        }

        public Task<List<Course>> GetWithLessons()
        {
            return _dbContext.Courses
                .AsNoTracking()
                .Include(c => c.Lessons)
                .ToListAsync();
        }

        public async Task Update(int id, string courseName, string description)
        {
            await _dbContext.Courses
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Name, courseName)
                .SetProperty(c => c.Description, description));

            await _dbContext.SaveChangesAsync();
        }
    }
}
