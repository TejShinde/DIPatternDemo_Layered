using System .ComponentModel .DataAnnotations;
using System .ComponentModel .DataAnnotations .Schema;

namespace DIPatternDemo_Layered .Models
    {
    [Table("Users")]
    public class User
        {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [NotMapped]
        public string ConfirmPassword { get; set; }
        }
    }
