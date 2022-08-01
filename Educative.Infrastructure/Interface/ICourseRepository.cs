using System.Threading.Tasks;
using Educative.Core;
using Educative.Infrastructure.Helpers;

namespace Educative.Infrastructure.Interface
{
    public interface ICourseRepository : IGenericRepository<Course> 
    {

        Task<PagedList<Course>> GetAllCourses(CourseParams courseParams);

    }
}
