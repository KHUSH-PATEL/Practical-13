using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical_13.Models
{
    [Table("EmployeeData")]
    public class EmployeeTest1
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } =string.Empty;
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DOB { get; set; }
        public int? Age { get; set; }
    }
}
