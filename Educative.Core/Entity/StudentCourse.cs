namespace Educative.Core.Entity;

public class StudentCourse
{
    public string StudentId { get; set; } = string.Empty!;

    public Student Student { get; set; } = new Student();


    public string CourseId { get; set; } = string.Empty!;

    public Course Course { get; set; } = new Course();
}

