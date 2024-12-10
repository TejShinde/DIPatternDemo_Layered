using System .ComponentModel .DataAnnotations .Schema;
using System .ComponentModel .DataAnnotations;

namespace DIPatternDemo_Layered .Models
    {
    [Table("Category")]
    public class Category
        {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }
        }

    }
