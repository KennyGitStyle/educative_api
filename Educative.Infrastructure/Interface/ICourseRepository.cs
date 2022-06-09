using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Educative.Core;

namespace Educative.Infrastructure.Interface
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
    
    }

    public interface ICourseRepos
    {
        Task<Course> GetByIdAsync(string id);

        Task<IEnumerable<Course>> GetAllAsync();

        Task<Course> AddAsync(Course entity);

        Task<Course> UpdateAsync(Course entity);

        Task DeleteAsync(string id);

        
    }
}
