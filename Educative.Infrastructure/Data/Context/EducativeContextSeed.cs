using System.Text.Json;
using Educative.Core;
using Educative.Core.Entity;
using Educative.Infrastructure.Context;
using Microsoft.Extensions.Logging;

namespace Educative.Infrastructure.Data.Context
{
    public class EducativeContextSeed
    {
        public static async Task SeedDatabaseAsync(EducativeContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Students.Any())
                {
                    var studentData =
                        File
                            .ReadAllText("../Educative.Infrastructure/Data/Context/DataSeed/Students.json");

                    var students =
                        JsonSerializer.Deserialize<List<Student>>(studentData);

                    students.ForEach(s => context.Students.Add(s));

                    await context.SaveChangesAsync();
                }
                if (!context.Courses.Any())
                {
                    var courseData =
                        File
                            .ReadAllText("../Educative.Infrastructure/Data/Context/DataSeed/Courses.json");

                    var courses =
                        JsonSerializer.Deserialize<List<Course>>(courseData);

                    courses.ForEach(c => context.Courses.Add(c));

                    await context.SaveChangesAsync();
                }

                if (!context.Addresses.Any())
                {
                    var courseData =
                        File
                            .ReadAllText("../Educative.Infrastructure/Data/Context/DataSeed/Addresses.json");

                    var addresses =
                        JsonSerializer.Deserialize<List<Address>>(courseData);

                    addresses.ForEach(a => context.Addresses.Add(a));

                    await context.SaveChangesAsync();
                }
                if (!context.StudentCourses.Any())
                {
                    var studentCourseData =
                        File
                            .ReadAllText("../Educative.Infrastructure/Data/Context/DataSeed/StudentCourses.json");

                    var studentCourses =
                        JsonSerializer
                            .Deserialize
                            <List<StudentCourse>>(studentCourseData);

                    studentCourses
                        .ForEach(sc => context.StudentCourses.Add(sc));

                    await context.SaveChangesAsync();
                }

                


            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<EducativeContextSeed>();
                logger.LogError("Educative Context Seed Error: ", ex.Message);
            }
        }
    }
}
