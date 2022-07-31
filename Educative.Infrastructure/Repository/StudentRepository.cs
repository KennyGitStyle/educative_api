using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Educative.Core;
using Educative.Infrastructure.Context;
using Educative.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Educative.Infrastructure.Repository
{
    public class
    StudentRepository
    : GenericRepository<Student>, IStudentRepository
    {
        private readonly EducativeContext _context;

        public StudentRepository(EducativeContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> FilterAttendanceAsync(Expression<Func<Student, bool>> predicate)
        {
             return await _context.Students
                .Include(s => s.Attendance >= 80)
                .Include(sa => sa.Address.City == "New York")
                .Include(sc => sc.StudentCourses)
                .ThenInclude(cs => cs.CourseId == "Bus")
                .Where(predicate).OrderBy(x => x.Lastname).ToListAsync();   
        }
    }
}
