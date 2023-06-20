using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical_13.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? MiddleName { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        [MaxLength(10)]
        [Required]
        public string MobileNumber { get; set; } = string.Empty;
        [MaxLength(100)]
        public string? Address { get; set; } = string.Empty;
        [Required]
        public decimal Salary { get; set; }

        [ForeignKey("DesignationDetail")]
        public int? DesignationId { get; set; }
        public DesignationDetail? DesignationDetail { get; set; }

    }
}
