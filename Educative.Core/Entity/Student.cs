using System.ComponentModel.DataAnnotations;
using Educative.Core.Entity;

namespace Educative.Core;

public class Student
{
    
    [Key]
    [Required]
    public string StudentId { get; set; } = string.Empty!;
    [Required]
    [Display(Name = "Firstname")]
    public string Firstname { get; set; } = string.Empty!;
    [Display(Name = "Middlename")]
    public char? MiddlenameInitial { get; set; } 
    [Display(Name = "Lastname")]
    public string Lastname { get; set; } = string.Empty!;
    public DateTime? DateOfBirth { get; set; }
    public virtual Address Address { get; set; } = new Address();   
    [DataType(DataType.PhoneNumber)]
    public string PhoneNo { get; set; } = string.Empty!;
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty!;
    [MaxLength(100)]
    public int? Attendance { get; set; }
    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}
