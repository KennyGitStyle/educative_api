using Educative.Core;
using Educative.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Educative.Infrastructure.Context
{
    public class EducativeContext : DbContext
    {
        public EducativeContext(DbContextOptions options) :
            base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; } = null!;

        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<Address> Addresses { get; set; } = null!;

        public DbSet<StudentCourse> StudentCourses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            


            modelBuilder
            .Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
            .HasOne<Student>(sc => sc.Student)
            .WithMany(s => s.StudentCourses)
            .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
            .HasOne<Course>(sc => sc.Course)
            .WithMany(s => s.StudentCourses)
            .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<Student>()
            .HasOne(a => a.Address)
            .WithOne(s => s.Student);

            
            
        }
    }
}
