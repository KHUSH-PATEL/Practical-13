using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical_13.Models
{
    [Table("Designation")]
    public class DesignationDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Designation { get; set; } = string.Empty;
        public ICollection<Employee>? Employees { get; set; }
    }
}
