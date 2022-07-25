using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Educative.Core;
using Educative.Infrastructure.Context;
using Educative.Infrastructure.Interface;

namespace Educative.Infrastructure.Repository
{
    public class
    StudentRepository
    : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(EducativeContext context) : base(context)
        {
        }

        public Task<IEnumerable<Student>> FilterAttendanceAsync(Expression<Func<Student, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
