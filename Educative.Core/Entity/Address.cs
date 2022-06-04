using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educative.Core
{
    public class Address
    {
        [ForeignKey("Student")]
        public string AddressId { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Address Line 1")]
        public string Addr1 { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Address Line 2")]
        public string Add2 { get; set; } = string.Empty;

        [Required]
        [Display(Name = "City")]
        public string? City { get; set; }

        [Display(Name = "County")]
        public string County { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.PostalCode)]
        public string Postcode { get; set; } = string.Empty;
         public string StudentId { get; set; } = string.Empty!;
        public Student Student { get; set; } = new Student();

    }
}
