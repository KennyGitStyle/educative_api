using Educative.Core;
using Educative.Infrastructure.Context;
using Educative.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Educative.Infrastructure.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly EducativeContext _context;

        public CourseRepository(EducativeContext context)
        {
            _context = context;
        }

        public async Task<Course> AddAsync(Course entity)
        {
            await _context.Courses.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetByIdAsync(string id)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == id);
        }

        public async Task<Course> UpdateAsync(Course entity)
        {
            if (entity.CourseId != null)
            {
                _context.Courses.Update (entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }

        public async Task DeleteAsync(string id)
        {
            if (id != null)
            {
                var findId = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
                _context.Courses.Remove(findId);
                await _context.SaveChangesAsync();
                
            }
            
        } 
    }
}
