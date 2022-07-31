using System.Linq;
using System.Threading.Tasks;
using Educative.Core;
using Educative.Infrastructure.Context;
using Educative.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Educative.Infrastructure.Repository
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly EducativeContext _context;

        public CourseRepository(EducativeContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Course> GetCourseAsyncExplicit()
        {
            var course = await _context.Courses.Where(c => c.CourseId == "Bus").SingleAsync();

            await _context.Entry(course).Reference(c => c.CourseTutor).LoadAsync();

            return course;

        }

        

       
    }
}