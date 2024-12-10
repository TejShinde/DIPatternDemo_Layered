using System .ComponentModel .DataAnnotations;
using System .ComponentModel .DataAnnotations .Schema;

namespace DIPatternDemo_Layered .Models
    {
    [Table("Products")]
    public class Product
        {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
      

        [NotMapped] // do not map this Categorname in DB table 
        public string? CategoryName { get; set; }


        public string? ImageUrl { get; set; }
        }
    }
