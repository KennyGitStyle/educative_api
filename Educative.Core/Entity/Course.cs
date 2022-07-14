using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Educative.Core.Entity;

namespace Educative.Core
{
    public class Course
    {
        [Key]
        public string CourseId { get; set; } = string.Empty!; 

        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; } = string.Empty!;

        [Required]
        [Display(Name = "Course Tutor")]
        public string CourseTutor { get; set; } = string.Empty!;

        [Required]
        [Display(Name = "Course Description")]
        [StringLength(200)]
        public string CourseDescription { get; set; } = string.Empty!;

        [Required]
        [StringLength(60)]
        public string CourseTopic { get; set; } = string.Empty!;

        public virtual ICollection<StudentCourse> StudentCourses { get; set; } 
    }
}
