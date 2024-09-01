using LearningCourses.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCourses.Data
{
    public class LessonsRepository : ILessonsRepository
    {
        private readonly AppDbContext _dbcontext;

        public LessonsRepository(AppDbContext dbContext)
        {
            this._dbcontext = dbContext;
        }

        public async Task Add(int courseId, string name, string description)
        {
            var lesson = new Lesson
            {
                CourseId = courseId,
                Name = name,
                Description = description
            };

            await _dbcontext.Lessons.AddAsync(lesson);
            await _dbcontext.SaveChangesAsync();
        }

        public Task<List<Lesson>> Get()
        {
            return _dbcontext.Lessons
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<List<Lesson>> GetByCourseId(int courseId)
        {
            return _dbcontext.Lessons
                .AsNoTracking()
                .Where(l => l.CourseId == courseId)
                .ToListAsync();
        }

        public Task<Lesson?> GetById(int lessonId)
        {
            return _dbcontext.Lessons
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == lessonId);
        }

        public async Task Delete(int lessonId)
        {
            await _dbcontext.Lessons
                .Where(l => l.Id == lessonId)
                .ExecuteDeleteAsync();
        }
    }
}
