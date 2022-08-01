using System.Linq;
using System.Threading.Tasks;
using Educative.Core;
using Educative.Infrastructure.Context;
using Educative.Infrastructure.Helpers;
using Educative.Infrastructure.Interface;
using Educative.Infrastructure.QueryExtension;
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

        public async Task<PagedList<Course>> GetAllCourses(CourseParams courseParams)
        {
            var query = _context.Courses
                .SortCourse(courseParams.OrderBy)
                .SearchCourses(courseParams.SearchTerm)
                .FilterCourse(courseParams.Name, courseParams.Topic)
                .AsQueryable();

            var courses = await PagedList<Course>.ToPagedList(query, courseParams.PageNumber, courseParams.PageSize);


            return courses;
        }

       
    }
}