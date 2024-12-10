using System .ComponentModel .DataAnnotations;
using System .ComponentModel .DataAnnotations .Schema;

namespace DIPatternDemo_Layered .Models
    {
    [Table("employee")]
    public class Employee
        {
        [Key]
        public int EmpId {  get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        public decimal Salary { get; set; }
        }
    }
