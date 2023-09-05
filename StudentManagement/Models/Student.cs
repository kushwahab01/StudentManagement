using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string? StudentName { get; set; }
        [Required]
        public string? FatherName { get; set; }
        [Required]
        public string? MotherName { get; set; }
        [Required]
        public int StudentAge { get;set; }
        [Required]
        public string? Address { get; set; }
        [Required]

        public DateTime? RegistrationDate { get; set; }

        public int IsActive { get;set; }

    }
}
